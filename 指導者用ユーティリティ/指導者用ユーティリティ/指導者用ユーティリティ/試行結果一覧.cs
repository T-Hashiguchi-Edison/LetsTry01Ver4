using Microsoft.VisualBasic.FileIO;
using System.Data.SQLite;
using System.Text;
using System.Windows;

namespace 指導者用ユーティリティ
{
    public partial class Frm試行結果一覧 : Form
    {
        // SqLite ファイルへの接続文字列
        private string connectionString = "";

        // 出力ファイルパス文字列
        private string? OutputDirString = "";

        //フォーム表示情報
        private string FullScreenMode = "";
        private int TopPosition = 0;
        private int LeftPosition = 0;
        private int FormWidth = 0;
        private int FormHeight = 0;

        //引継ぎパラメータ
        private string UserName = "";
        private int Mode = 0;
        private int Course = 0;
        private string CourseNm = "";
        private string FileNameI = "";
        private string FileNameR = "";

        //最小化フォームサイズ(幅762、高さ543)
        private int MiniWidth = 762;
        private int MiniHeight = 543;

        //表示行数
        private int DgvRowCount = 0;

        /// <summary>
        //              試行結果一覧
        /// </summary>
        /// <param name="prmUser">ユーザ名</param>
        /// <param name="prmMode">モード</param>
        /// <param name="prmCourse">コース</param>
        /// <param name="prmCourseNm">コース名称</param>
        /// <param name="prmFileI">入力値ファイル名</param>
        /// <param name="prmFileR">解析結果ファイル名</param>
        public Frm試行結果一覧(string prmUser, int prmMode, int prmCourse, string prmCourseNm, string prmFileI, string prmFileR)
        {
            InitializeComponent();

            //中央に配置する
            this.StartPosition = FormStartPosition.CenterScreen;

            //フォームの最小化ボタンの表示、非表示を切り替える
            this.MinimizeBox = !this.MinimizeBox;

            //フォームが最小化されないようにする
            this.MinimizeBox = false;

            //データグリッドビュー行挿入/削除　禁止
            DgvDetailQ.AllowUserToAddRows = false;
            DgvDetailQ.AllowUserToDeleteRows = false;
            DgvDetailC.AllowUserToAddRows = false;
            DgvDetailC.AllowUserToDeleteRows = false;

            //データグリッドビュー列の幅、行の高さの変更　禁止
            //DgvDetailQ.AllowUserToResizeColumns = false;
            DgvDetailQ.AllowUserToResizeRows = false;
            DgvDetailC.AllowUserToResizeRows = false;

            //データグリッドビュー罫線をなくす
            DgvDetailQ.CellBorderStyle = DataGridViewCellBorderStyle.None;
            DgvDetailC.CellBorderStyle = DataGridViewCellBorderStyle.None;

            //データグリッドビュー並べ替え　禁止
            foreach (DataGridViewColumn c in DgvDetailQ.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;
            foreach (DataGridViewColumn c in DgvDetailC.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            //このフォームの最小サイズを設定する
            this.MinimumSize = new System.Drawing.Size(MiniWidth, MiniHeight);

            //引継ぎパラメータセット
            UserName = prmUser;
            Mode = prmMode;
            Course = prmCourse;
            CourseNm = prmCourseNm;
            FileNameI = prmFileI;
            FileNameR = prmFileR;
        }

        /// <summary>
        //              Form　Load 
        /// </summary>
        private void Frm試行結果一覧_Load(object sender, EventArgs e)
        {
            // DB ファイルへの接続文字列
            if (System.IO.File.Exists(System.Windows.Forms.Application.StartupPath + @"\LetsTry04.ini"))
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                StreamReader sr = new StreamReader(System.Windows.Forms.Application.StartupPath + @"\LetsTry04.ini", Encoding.GetEncoding("Shift_JIS"));
                connectionString = SetPathString(sr.ReadLine());
                sr.Close();

                TxtUserName.Text = UserName;
                TxtCourse.Text = CourseNm;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("システム環境に問題があります。", "エラー");
                //終了
                this.Dispose();
                this.Close();
            }

            // 出力ファイルパス、初期表示位置取得
            GetSetting();

            DgvDetailQ.Visible = (Mode == 0);
            DgvDetailC.Visible = !DgvDetailQ.Visible;

            //初期表示
            GetDetailData();

            NudID.Minimum = 1;
            NudID.Maximum = (DgvRowCount > 0) ? DgvRowCount : 1;
            NudID.Value = 1;
            BtnSelect.Enabled = (DgvRowCount > 0);
            BtnInput.Enabled = (DgvRowCount > 0);

            this.ActiveControl = (DgvDetailQ.Visible) ? this.DgvDetailQ : this.DgvDetailC;
        }

        /// <summary>
        //              Form　Resize
        /// </summary>
        private void Frm試行結果一覧_Resize(object sender, EventArgs e)
        {
            LblCnt.Location = new System.Drawing.Point(this.Size.Width - 106, 72);
            LblCnt2.Location = new System.Drawing.Point(this.Size.Width - 50, 72);
            DgvDetailQ.Size = new System.Drawing.Size(this.Size.Width - 58, this.Size.Height - 183);
            DgvDetailC.Size = new System.Drawing.Size(this.Size.Width - 58, this.Size.Height - 183);
            LblComment.Location = new System.Drawing.Point(24, this.Size.Height - 71);
            BtnInput.Location = new System.Drawing.Point(this.Size.Width - 290, this.Size.Height - 79);
            BtnCancel.Location = new System.Drawing.Point(this.Size.Width - 138, this.Size.Height - 79);
        }

        /// <summary>
        //              Form　Closing 
        /// </summary>
        private void Frm試行結果一覧_FormClosing(object sender, FormClosingEventArgs e)
        {
            SetFormInfo();
        }

        /// <summary>
        //              選択　Click
        /// </summary>
        private void BtnSelect_Click(object sender, EventArgs e)
        {
            if (DgvDetailQ.Visible)
            {
                DgvDetailQ.FirstDisplayedScrollingRowIndex = (int)NudID.Value - 1;
                DgvDetailQ.Rows[(int)NudID.Value - 1].Selected = true;
            }
            if (DgvDetailC.Visible)
            {
                DgvDetailC.FirstDisplayedScrollingRowIndex = (int)NudID.Value - 1;
                DgvDetailC.Rows[(int)NudID.Value - 1].Selected = true;
            }
        }

        /// <summary>
        //              正解と入力の比較　Click
        /// </summary>
        private void BtnInput_Click(object sender, EventArgs e)
        {
            BtnCancel.Enabled = false;

            //非表示する
            this.Visible = false;

            string CardNo = "";
            string WorkTime = "";

            switch (Mode)
            {
                case 0:
                    CardNo = "" + DgvDetailQ.CurrentRow.Cells[1].Value.ToString();
                    WorkTime = "" + DgvDetailQ.CurrentRow.Cells[11].Value.ToString();
                    Frm入力値表示アンケートカード入力 frmQ = new Frm入力値表示アンケートカード入力(Course, CardNo, WorkTime, FileNameI);
                    frmQ.ShowDialog();
                    break;
                case 1:
                    CardNo = "" + DgvDetailC.CurrentRow.Cells[1].Value.ToString();
                    WorkTime = "" + DgvDetailC.CurrentRow.Cells[6].Value.ToString();
                    Frm入力値表示顧客伝票修正 frmD = new Frm入力値表示顧客伝票修正(Course, CardNo, WorkTime, FileNameI);
                    frmD.ShowDialog();
                    break;
                case 2:
                    CardNo = "" + DgvDetailC.CurrentRow.Cells[1].Value.ToString();
                    WorkTime = "" + DgvDetailC.CurrentRow.Cells[6].Value.ToString();
                    Frm入力値表示顧客伝票ミスチェック frmC = new Frm入力値表示顧客伝票ミスチェック(Course, CardNo, WorkTime, FileNameI);
                    frmC.ShowDialog();
                    break;
            }

            BtnCancel.Enabled = true;

            //表示する
            this.Visible = true;
        }

        /// <summary>
        //              閉じる　Click
        /// </summary>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        /// <summary>
        //              アンケート一覧　CellClick
        /// </summary>
        private void DgvDetailQ_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                //ヘッダークリックは無視する
            }
            else
            {
                DgvDetailQ.CurrentRow.Cells[1].Selected = true;
            }
        }

        /// <summary>
        //              アンケート一覧　DoubleClick
        /// </summary>
        private void DgvDetailQ_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                //ヘッダークリックは無視する
            }
            else
            {
                DgvDetailQ.CurrentRow.Cells[1].Selected = true;
                BtnInput.PerformClick();
            }
        }

        /// <summary>
        //              アンケート一覧　KeyDown
        /// </summary>
        private void DgvDetailQ_KeyDown(object sender, KeyEventArgs e)
        {
            //Tab Key
            if (e.KeyCode == Keys.Tab)
            {
                //フォーカス移動
                BtnInput.Focus();
                e.Handled = true;
            }

            //←→Key
            if ((e.KeyCode == Keys.Left) || (e.KeyCode == Keys.Right))
            {
                //フォーカスが横に移動しないようにする
                e.Handled = true;
            }
        }

        /// <summary>
        //              顧客伝票一覧　CellClick
        /// </summary>
        private void DgvDetailC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                //ヘッダークリックは無視する
            }
            else
            {
                DgvDetailC.CurrentRow.Cells[1].Selected = true;
            }
        }

        /// <summary>
        //             顧客伝票一覧　DoubleClick
        /// </summary>
        private void DgvDetailC_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                //ヘッダークリックは無視する
            }
            else
            {
                DgvDetailC.CurrentRow.Cells[1].Selected = true;
                BtnInput.PerformClick();
            }
        }

        /// <summary>
        //              顧客伝票一覧　KeyDown
        /// </summary>
        private void DgvDetailC_KeyDown(object sender, KeyEventArgs e)
        {
            //Tab Key
            if (e.KeyCode == Keys.Tab)
            {
                //フォーカス移動
                BtnInput.Focus();
                e.Handled = true;
            }

            //←→Key
            if ((e.KeyCode == Keys.Left) || (e.KeyCode == Keys.Right))
            {
                //フォーカスが横に移動しないようにする
                e.Handled = true;
            }
        }

        /// <summary>
        //              出力ファイルパス、初期表示位置取得
        /// </summary>
        /// <returns>true:正常終了　false:異常終了</returns>
        private Boolean GetSetting()
        {
            try
            {
                OutputDirString = System.Windows.Forms.Application.StartupPath;
                FullScreenMode = "";
                TopPosition = 0;
                LeftPosition = 0;
                FormWidth = 0;
                FormHeight = 0;

                int cnt = 0;
                // SQL クエリ
                string sql = "";

                // データＤＢを開く
                using (SQLiteConnection con = new SQLiteConnection(SetconnectionString(connectionString)))
                {
                    con.Open();

                    //テーブル作成
                    sql = "CREATE TABLE IF NOT EXISTS ユーザ比較設定データ(id             int," +
                                                                          "OutputPath     text," +
                                                                          "FullScreenMode varchar(1)," +
                                                                          "TopPosition    int," +
                                                                          "LeftPosition   int," +
                                                                          "FormWidth      int," +
                                                                          "FormHeight     int," +
                                                                          "InsDate        datetime," +
                                                                          "UpdDate        datetime" +
                                                                         ")";

                    SQLiteCommand com = new SQLiteCommand(sql, con);
                    com.ExecuteNonQuery();

                    sql = "SELECT * FROM ユーザ比較設定データ WHERE id = 1";

                    using (SQLiteCommand command = new SQLiteCommand(sql, con))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            cnt = 0;
                            while (reader.Read())
                            {
                                // データの処理
                                OutputDirString = reader.GetString(1);
                                FullScreenMode = reader.GetString(2);
                                TopPosition = reader.GetInt32(3);
                                LeftPosition = reader.GetInt32(4);
                                FormWidth = reader.GetInt32(5);
                                FormHeight = reader.GetInt32(6);
                                cnt++;
                            }
                        }
                    }

                    if (cnt != 0)
                    {
                        //初期表示位置、サイズの変更
                        this.Top = TopPosition;
                        this.Left = LeftPosition;
                        this.Width = FormWidth;
                        this.Height = FormHeight;
                        if (FullScreenMode == "1")
                        {
                            this.WindowState = FormWindowState.Maximized;
                        }
                        else
                        {
                            this.WindowState = FormWindowState.Normal;
                        }

                        //出力パス有効性チェック
                        if (!System.IO.Directory.Exists(OutputDirString))
                        {
                            OutputDirString = System.Windows.Forms.Application.StartupPath;
                        }
                    }
                    else
                    {
                        //中央に配置する
                        this.StartPosition = FormStartPosition.CenterScreen;
                    }

                    con.Close();
                }

                return true;
            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "エラー");
                //終了
                this.Dispose();
                this.Close();
                return false;
            }
        }

        //              試行結果一覧　一覧取得処理
        /// </summary>
        /// <returns>true:正常終了　false:異常終了</returns>
        private Boolean GetDetailData()
        {
            try
            {
                if (!File.Exists(FileNameI)) return true;
                if (!File.Exists(FileNameR)) return true;

                DataGridView TartgetDgv = (DgvDetailQ.Visible) ? this.DgvDetailQ : this.DgvDetailC;

                //入力値ファイル取得
                if (!File.Exists(FileNameI))
                {
                    System.Windows.Forms.MessageBox.Show("システム環境に問題があります。(File Not Found(" + FileNameI + "))", "エラー");
                    //終了
                    this.Dispose();
                    this.Close();
                    return false;
                }

                using (TextFieldParser txtParser = new TextFieldParser(FileNameI))
                {
                    txtParser.SetDelimiters(",");

                    DgvRowCount = 0;
                    while (!txtParser.EndOfData)
                    {
                        string[]? values = txtParser.ReadFields();
                        int CellCount = 0;
                        foreach (string value in values)
                        {
                            if (value == "開始時刻") break;

                            switch (CellCount)
                            {
                                case 0:
                                    DgvRowCount++;
                                    TartgetDgv.Rows.Add();
                                    TartgetDgv.Rows[DgvRowCount - 1].Cells[0].Value = DgvRowCount;
                                    break;
                                case 2:
                                    if (DgvDetailQ.Visible) TartgetDgv.Rows[DgvRowCount - 1].Cells[11].Value = value;
                                    if (DgvDetailC.Visible) TartgetDgv.Rows[DgvRowCount - 1].Cells[6].Value = value;
                                    break;
                                case 4:
                                    TartgetDgv.Rows[DgvRowCount - 1].Cells[1].Value = value;
                                    break;
                            }
                            CellCount++;
                        }
                    }
                }

                //解析結果ファイル取得
                if (!File.Exists(FileNameR))
                {
                    System.Windows.Forms.MessageBox.Show("システム環境に問題があります。(File Not Found(" + FileNameR + "))", "エラー");
                    //終了
                    this.Dispose();
                    this.Close();
                    return false;
                }

                using (TextFieldParser txtParser = new TextFieldParser(FileNameR))
                {
                    txtParser.SetDelimiters(",");

                    int TargetRow = 0;
                    Boolean EditSw = false;

                    while (!txtParser.EndOfData)
                    {
                        string[]? values = txtParser.ReadFields();
                        int CellCount = 0;
                        string[] SetValue = new string[9];

                        foreach (string value in values)
                        {
                            if (value == "アンケート入力・解析結果") break;
                            if (value == "顧客伝票修正・解析結果") break;
                            if (value == "顧客伝票ミスチェック・解析結果") break;
                            if (value == "エラー") break;
                            if (value == "合計") break;

                            if (value == "■採点結果") EditSw = false;
                            if (value == "■目標設定") EditSw = false; ;
                            if (value == "■試行条件の設定") EditSw = false; ;
                            if (value == "■項目別エラー一覧") EditSw = true;
                            if (value == "■文字種別エラー一覧") EditSw = false; ;

                            if (!EditSw) break;

                            switch (CellCount)
                            {
                                case 1:
                                    for (; TargetRow < TartgetDgv.Rows.Count; TargetRow++)
                                    {
                                        if (TartgetDgv.Rows[TargetRow].Cells[CellCount].Value.ToString() == value) break;
                                    }
                                    break;
                                case 2:
                                case 3:
                                case 4:
                                case 5:
                                case 7:
                                case 8:
                                case 9:
                                case 10:
                                    SetValue[CellCount - 2] = value;
                                    break;
                                case 6:
                                    if (DgvDetailQ.Visible)
                                    {
                                        SetValue[CellCount - 2] = value;
                                    }
                                    else
                                    {
                                        for (; TargetRow < TartgetDgv.Rows.Count; TargetRow++)
                                        {
                                            if (TartgetDgv.Rows[TargetRow].Cells[CellCount].Value.ToString() == value) break;
                                        }
                                        if (TargetRow < TartgetDgv.Rows.Count)
                                        {
                                            for (int i = 0; i < 4; i++)
                                            {
                                                TartgetDgv.Rows[TargetRow].Cells[i + 2].Value = SetValue[i];
                                            }
                                        }
                                    }
                                    break;
                                case 11:
                                    for (; TargetRow < TartgetDgv.Rows.Count; TargetRow++)
                                    {
                                        if (TartgetDgv.Rows[TargetRow].Cells[CellCount].Value.ToString() == value) break;
                                    }
                                    if (TargetRow < TartgetDgv.Rows.Count)
                                    {
                                        for (int i = 0; i < 9; i++)
                                        {
                                            TartgetDgv.Rows[TargetRow].Cells[i + 2].Value = SetValue[i];
                                        }
                                    }
                                    break;
                            }
                            CellCount++;
                        }
                    }
                }

                return true;
            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "エラー");
                //終了
                this.Dispose();
                this.Close();
                return false;
            }
        }

        /// <summary>
        //              フォーム表示情報　更新処理
        /// </summary>
        /// <returns>true:正常終了　false:異常終了</returns>
        private Boolean SetFormInfo()
        {
            try
            {

                int cnt = 0;
                // SQL クエリ
                string sql = "";

                FullScreenMode = (this.WindowState == FormWindowState.Maximized) ? "1" : "";

                TopPosition = this.Top;
                LeftPosition = this.Left;
                FormWidth = this.Width;
                FormHeight = this.Height;

                // データＤＢを開く
                using (SQLiteConnection con = new SQLiteConnection(SetconnectionString(connectionString)))
                {
                    con.Open();

                    sql = "SELECT * FROM ユーザ比較設定データ WHERE id = 1";

                    using (SQLiteCommand command = new SQLiteCommand(sql, con))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            cnt = 0;
                            while (reader.Read())
                            {
                                cnt++;
                            }
                        }
                    }

                    if (cnt != 0)
                    {
                        if (FullScreenMode == "1")
                        {
                            sql = "UPDATE ユーザ比較設定データ"
                                + "   SET FullScreenMode = '" + FullScreenMode + "',"
                                + "       UpdDate        = datetime('now', 'localtime') "
                                + " WHERE id = 1";
                        }
                        else
                        {
                            sql = "UPDATE ユーザ比較設定データ"
                                + "   SET FullScreenMode = '" + FullScreenMode + "',"
                                + "       TopPosition    = " + TopPosition.ToString() + ","
                                + "       LeftPosition   = " + LeftPosition.ToString() + ","
                                + "       FormWidth      = " + FormWidth.ToString() + ","
                                + "       FormHeight     = " + FormHeight.ToString() + ","
                                + "       UpdDate        = datetime('now', 'localtime') "
                                + " WHERE id = 1";
                        }
                    }
                    else
                    {
                        if (FullScreenMode == "1")
                        {
                            //ディスプレイサイズ取得
                            Double DisplayWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
                            Double DisplayHeight = SystemParameters.PrimaryScreenHeight;
                            int PosTop = (int)((DisplayHeight - MiniHeight) / 2);
                            int PosWidth = (int)((DisplayWidth - MiniWidth) / 2);

                            sql = "INSERT INTO  ユーザ比較設定データ Values(1," +
                                                                        "'" + OutputDirString + "'," +
                                                                        "'" + FullScreenMode + "'," +
                                                                        PosTop.ToString() + "," +
                                                                        PosWidth.ToString() + "," +
                                                                        MiniWidth.ToString() + "," +
                                                                        MiniHeight.ToString() + "," +
                                                                        "datetime('now', 'localtime')," +
                                                                        "datetime('now', 'localtime')" +
                                                                      ")";
                        }
                        else
                        {
                            sql = "INSERT INTO  ユーザ比較設定データ Values(1," +
                                                                        "'" + OutputDirString + "'," +
                                                                        "''," +
                                                                        TopPosition.ToString() + "," +
                                                                        LeftPosition.ToString() + "," +
                                                                        FormWidth.ToString() + "," +
                                                                        FormHeight.ToString() + "," +
                                                                        "datetime('now', 'localtime')," +
                                                                        "datetime('now', 'localtime')" +
                                                                      ")";
                        }
                    }

                    SQLiteCommand com = new SQLiteCommand(sql, con);
                    com.ExecuteNonQuery();

                    con.Close();
                }
                return true;
            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "エラー");
                return false;
            }
        }

        /// <summary>
        //              ＤＢ接続文字列セット
        /// </summary>
        /// <param name="con">コネクション文字列</param>
        /// <returns>SQLite接続文字列</returns>
        private string SetconnectionString(string con)
        {
            return "Data Source=" + con + ";Version=3;";
        }

        /// <summary>
        //              ＤＢパスセット
        /// </summary>
        /// <param name="fPath">データベースフルパス</param>
        /// <returns>SQLiteデータベース名フルパス</returns>
        private string SetPathString(string? fPath)
        {
            return fPath + @"\LetsTry04.dat";
        }

    }
}
