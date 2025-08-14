using System.Data.SQLite;
using System.Text;
using System.Windows;

namespace 指導者用ユーティリティ
{
    public partial class Frm試行履歴選択 : Form
    {
        // SqLite ファイルへの接続文字列
        private string connectionString = "";

        //フォーム表示情報
        private string FullScreenMode = "";
        private int TopPosition = 0;
        private int LeftPosition = 0;
        private int FormWidth = 0;
        private int FormHeight = 0;

        //引継ぎパラメータ
        private int UserId = 0;
        private string UserName = "";

        //ファイル名
        private string InputFileName = "";
        private string ResultFileName = "";

        //最小化フォームサイズ(幅900、高さ571)
        private int MiniWidth = 900;
        private int MiniHeight = 571;

        //解析結果出力インターフェース
        解析結果出力IF.DetailData detailData = new 解析結果出力IF.DetailData();
        List<解析結果出力IF.DetailData> ListdetailData = new List<解析結果出力IF.DetailData>();
        解析結果出力IF.MaxMinData MaxMinData = new 解析結果出力IF.MaxMinData();

        //試行履歴データ
        public struct 試行履歴データ
        {
            public int id = 0;
            public string Times = "";
            public string StartDate = "";
            public string Course = "";
            public string WorkTime = "";
            public decimal WorkMaisu = 0;
            public decimal CorrectMaisu = 0;
            public decimal CorrectRate = 0;
            public int WorkCnt = 0;
            public int CorrectCnt = 0;
            public string Feedback = "";
            public string ColorCD = "";
            public string FormDisp = "";
            public string Teiji = "";
            public string DispProgress = "";
            public string DispTimer = "";
            public string DispRemain = "";
            public string DispGraph = "";
            public string ZipSearch = "";
            public string Sound = "";
            public decimal WorkKoumoku = 0;
            public decimal CorrectKoumoku = 0;
            public decimal CorrectKoumokuRate = 0;
            public string Timer = "";

            public 試行履歴データ()
            {
            }
        }

        /// <summary>
        //              試行履歴選択
        /// </summary>
        /// <param name="prmId">ユーザID</param>
        /// <param name="prmName">ユーザ名</param>
        public Frm試行履歴選択(int prmID, string prmName)
        {
            InitializeComponent();

            //中央に配置する
            this.StartPosition = FormStartPosition.CenterScreen;

            //フォームの最小化ボタンの表示、非表示を切り替える
            this.MinimizeBox = !this.MinimizeBox;

            //フォームが最小化されないようにする
            this.MinimizeBox = false;

            //データグリッドビュー行挿入/削除　禁止
            DgvDetail.AllowUserToAddRows = false;
            DgvDetail.AllowUserToDeleteRows = false;

            //データグリッドビュー列の幅、行の高さの変更　禁止
            //DgvDetail.AllowUserToResizeColumns = false;
            DgvDetail.AllowUserToResizeRows = false;

            //データグリッドビュー罫線をなくす
            DgvDetail.CellBorderStyle = DataGridViewCellBorderStyle.None;

            //データグリッドビュー並べ替え　禁止
            foreach (DataGridViewColumn c in DgvDetail.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            //このフォームの最小サイズを設定する
            this.MinimumSize = new System.Drawing.Size(MiniWidth, MiniHeight);

            //引継ぎパラメータセット
            UserId = prmID;
            UserName = prmName;
            TxtUserName.Text = UserName;
        }

        /// <summary>
        //              ショートカットキー判定　Key Down
        /// </summary>
        /// <param name="keyData">キー情報</param>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            //［Alt］+［K］が押されたらキャッチ(課題)
            if (keyData == (Keys.K | Keys.Alt))
            {
                CmbMode.Focus();
            }
            //［Alt］+［E］が押されたらキャッチ(試行時間)
            if (keyData == (Keys.E | Keys.Alt))
            {
                CmbTime.Focus();
            }
            //［Alt］+［C］が押されたらキャッチ(コース)
            if (keyData == (Keys.C | Keys.Alt))
            {
                CmbCourse.Focus();
            }
            //［Alt］+［H］が押されたらキャッチ(表示データ)
            if (keyData == (Keys.H | Keys.Alt))
            {
                CmbDisp.Focus();
            }
            //［Alt］+［D］が押されたらキャッチ(ユーザー比較)
            if (keyData == (Keys.D | Keys.Alt))
            {
                BtnDel.PerformClick();
            }

            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        //              Form　Load 
        /// </summary>
        private void Frm試行履歴選択_Load(object sender, EventArgs e)
        {
            // DB ファイルへの接続文字列
            if (System.IO.File.Exists(System.Windows.Forms.Application.StartupPath + @"\LetsTry04.ini"))
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                StreamReader sr = new StreamReader(System.Windows.Forms.Application.StartupPath + @"\LetsTry04.ini", Encoding.GetEncoding("Shift_JIS"));
                connectionString = SetPathString(sr.ReadLine());
                sr.Close();
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

            //初期表示
            CmbMode.SelectedIndex = 0;
            CmbTime.SelectedIndex = 0;
            CmbCourse.SelectedIndex = 0;
            CmbDisp.SelectedIndex = 0;

            this.ActiveControl = this.DgvDetail;

        }

        /// <summary>
        //              Form　Resize 
        /// </summary>
        private void Frm試行履歴選択_Resize(object sender, EventArgs e)
        {
            LblCnt.Location = new System.Drawing.Point(this.Size.Width - 106, 72);
            LblCnt2.Location = new System.Drawing.Point(this.Size.Width - 50, 72);
            DgvDetail.Size = new System.Drawing.Size(this.Size.Width - 58, this.Size.Height - 211);
            BtnDel.Location = new System.Drawing.Point(24, this.Size.Height - 75);
            LblComment.Location = new System.Drawing.Point(24, this.Size.Height - 115);
            BtnList.Location = new System.Drawing.Point(this.Size.Width - 362, this.Size.Height - 75);
            BtnResult.Location = new System.Drawing.Point(this.Size.Width - 250, this.Size.Height - 75);
            BtnCancel.Location = new System.Drawing.Point(this.Size.Width - 138, this.Size.Height - 75);
        }

        /// <summary>
        //              Form　Closing 
        /// </summary>
        private void Frm試行履歴選択_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 出力ファイルパス、初期表示位置設定
            SetFormInfo();
        }

        /// <summary>
        //              削除　Click
        /// </summary>
        private void BtnDel_Click(object sender, EventArgs e)
        {
            DeleteDetail();
        }

        /// <summary>
        //              試行一覧表示　Click
        /// </summary>
        private void BtnList_Click(object sender, EventArgs e)
        {
            BtnCancel.Enabled = false;

            //非表示する
            this.Visible = false;

            // 出力ファイルパス、初期表示位置設定
            SetFormInfo();

            string CourseNm = CmbMode.Text + "　" + CmbTime.Text + "　" + CmbCourse.Text;
            //入力値ファイル、解析結果ファイル名編集
            SetFileName(DgvDetail.CurrentRow.Index);

            Frm試行結果一覧 frm = new Frm試行結果一覧(UserName, CmbMode.SelectedIndex, CmbCourse.SelectedIndex, CourseNm, InputFileName, ResultFileName);
            frm.ShowDialog();

            //表示する
            this.Visible = true;

            // 出力ファイルパス、初期表示位置取得
            GetSetting();

            BtnCancel.Enabled = true;
        }

        /// <summary>
        //              解析結果表示　Click
        /// </summary>
        private void BtnResult_Click(object sender, EventArgs e)
        {
            BtnCancel.Enabled = false;

            // 出力ファイルパス、初期表示位置設定
            SetFormInfo();

            //非表示する
            this.Visible = false;

            string CourseNm = CmbMode.Text + "　" + CmbTime.Text + "　" + CmbCourse.Text;


            //解析結果出力IF編集
            SetInterFace();

            Frm解析結果出力 frm = new Frm解析結果出力(UserName, CmbMode.SelectedIndex, CmbCourse.SelectedIndex, CourseNm, ListdetailData, MaxMinData);
            frm.ShowDialog();

            //表示する
            this.Visible = true;

            // 出力ファイルパス、初期表示位置取得
            GetSetting();

            BtnCancel.Enabled = true;
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
        //              一覧　CellClick
        /// </summary>
        private void DgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                //ヘッダークリックは無視する
            }
            else
            {
                DgvDetail.CurrentRow.Cells[1].Selected = true;
            }
        }

        /// <summary>
        //              一覧　DoubleClick
        /// </summary>
        private void DgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                //ヘッダークリックは無視する
            }
            else
            {
                DgvDetail.CurrentRow.Cells[1].Selected = true;
                BtnList.PerformClick();
            }
        }

        /// <summary>
        //              一覧　KeyDown
        /// </summary>
        private void DgvDetail_KeyDown(object sender, KeyEventArgs e)
        {
            //Enter Key
            if (e.KeyCode == Keys.Enter)
            {
                BtnList.PerformClick();
                e.Handled = true;
            }

            //Tab Key
            if (e.KeyCode == Keys.Tab)
            {
                //フォーカス移動
                BtnDel.Focus();
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
        //              課題　SelectedIndexChanged
        /// </summary>
        private void CmbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            //データ取得
            GetDetailData();

        }

        /// <summary>
        //              試行実時間　SelectedIndexChanged
        /// </summary>
        private void CmbTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            //データ取得
            GetDetailData();

        }

        /// <summary>
        //              コース　SelectedIndexChanged
        /// </summary>
        private void CmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            //コースがレベル/テストの時だけ表示データを選択することができる
            CmbDisp.Enabled = (CmbCourse.SelectedIndex == 0);
            //データ取得
            GetDetailData();
        }

        /// <summary>
        //              表示データ　SelectedIndexChanged
        /// </summary>
        private void CmbDisp_SelectedIndexChanged(object sender, EventArgs e)
        {
            //データ取得
            GetDetailData();

        }

        /// <summary>
        //              初期表示位置取得
        /// </summary>
        /// <returns>true:正常終了　false:異常終了</returns>
        private Boolean GetSetting()
        {
            try
            {
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

        //              一覧取得処理
        /// </summary>
        /// <returns>true:正常終了　false:異常終了</returns>
        private Boolean GetDetailData()
        {

            //課題、試行実時間、コース、表示データが選択されていない場合は抜ける。
            if ((CmbMode.SelectedIndex < 0) ||
                (CmbTime.SelectedIndex < 0) ||
                (CmbCourse.SelectedIndex < 0) ||
                (CmbDisp.SelectedIndex < 0)
               ) return true;

            try
            {
                string SelectMode = "";
                string SelectTimer = "";
                string SelectCourse = "";
                string SelectDisp = "";
                int wkCnt = 0;
                decimal maxValue = 0;

                試行履歴データ rowData = new 試行履歴データ();
                List<試行履歴データ> DetailData = new List<試行履歴データ>();

                // SQL クエリ
                string sql = "";

                //一覧クリア
                DgvDetail.Rows.Clear();

                // データＤＢを開く
                using (SQLiteConnection con = new SQLiteConnection(SetconnectionString(connectionString)))
                {
                    con.Open();

                    //マスタ作成
                    sql = "CREATE TABLE IF NOT EXISTS 履歴データ(id                     integer PRIMARY KEY AUTOINCREMENT, " +
                                                                "UserID                 int," +
                                                                "Mode                   varchar(1)," +
                                                                "StartDate              datetime," +
                                                                "Teiji                  varchar(1)," +
                                                                "Timer                  varchar(1)," +
                                                                "FormDisp               varchar(1)," +
                                                                "FormLR                 varchar(1)," +
                                                                "DispProgress           varchar(1)," +
                                                                "DispTimer              varchar(1)," +
                                                                "DispRemain             varchar(1)," +
                                                                "DispGraph              varchar(1)," +
                                                                "ZipSearch              varchar(1)," +
                                                                "Sound                  varchar(1)," +
                                                                "Course                 varchar(1)," +
                                                                "AnswerMaisu            int," +
                                                                "AnswerKoumoku          int," +
                                                                "CorrectMaisu           int," +
                                                                "CorrectKoumoku         int," +
                                                                "CorrectRate            real," +
                                                                "CorrectKoumokuRate     real," +
                                                                "AnswerMaisuHour        real," +
                                                                "AnswerKoumokuHour      real," +
                                                                "CorrectMaisuHour       real," +
                                                                "CorrectKoumokuHour     real," +
                                                                "CorrectRateHour        real," +
                                                                "CorrectKoumokuRateHour real," +
                                                                "WorkCnt                int," +
                                                                "CorrectCnt             int," +
                                                                "Feedback               varchar(1)," +
                                                                "ColorCD                varchar(1)," +
                                                                "CancelFlg              varchar(1)," +
                                                                "WorkTime               varchar(8)," +
                                                                "InsDate                datetime," +
                                                                "UpdDate                datetime," +
                                                                "DelFlg                 int" +
                                                                ")";

                    SQLiteCommand com = new SQLiteCommand(sql, con);
                    com.ExecuteNonQuery();

                    //Index作成
                    sql = "CREATE INDEX IF NOT EXISTS IdxUserID ON 履歴データ(UserID)";
                    com = new SQLiteCommand(sql, con);
                    com.ExecuteNonQuery();
                    sql = "CREATE INDEX IF NOT EXISTS IdxMode ON 履歴データ(Mode)";
                    com = new SQLiteCommand(sql, con);
                    com.ExecuteNonQuery();
                    sql = "CREATE INDEX IF NOT EXISTS IdxStartDate ON 履歴データ(StartDate)";
                    com = new SQLiteCommand(sql, con);
                    com.ExecuteNonQuery();

                    //課題
                    SelectMode = (CmbMode.SelectedIndex + 1).ToString();
                    //作業実時間
                    SelectTimer = (CmbTime.SelectedIndex + 1).ToString();
                    //コース
                    SelectCourse = (CmbCourse.SelectedIndex + 1).ToString();
                    //表示データ
                    SelectDisp = CmbDisp.SelectedIndex.ToString();

                    //sql生成
                    sql = "SELECT id"                                       //0
                        + "     , StartDate"                                //1
                        + "     , Course"                                   //2
                        + "     , WorkTime"                                 //3
                        + "     , AnswerMaisu"                              //4
                        + "     , CorrectMaisu"                             //5
                        + "     , CorrectRate"                              //6
                        + "     , AnswerMaisuHour"                          //7
                        + "     , CorrectMaisuHour"                         //8
                        + "     , CorrectRateHour"                          //9
                        + "     , WorkCnt"                                  //10
                        + "     , CorrectCnt"                               //11
                        + "     , Feedback"                                 //12
                        + "     , ColorCD"                                  //13
                        + "     , FormDisp"                                 //14
                        + "     , FormLR"                                   //15
                        + "     , Teiji"                                    //16
                        + "     , DispProgress"                             //17
                        + "     , DispTimer"                                //18
                        + "     , DispRemain"                               //19
                        + "     , DispGraph"                                //20
                        + "     , ZipSearch"                                //21
                        + "     , Sound"                                    //22
                        + "     , AnswerKoumoku"                            //23
                        + "     , CorrectKoumoku"                           //24
                        + "     , CorrectKoumokuRate"                       //25
                        + "     , AnswerKoumokuHour"                        //26
                        + "     , CorrectKoumokuHour"                       //27
                        + "     , CorrectKoumokuRateHour"                   //28
                        + "     , Timer"                                    //29
                        + "  FROM 履歴データ"
                        + "  WHERE UserId = " + UserId
                        + "    AND Mode = '" + SelectMode + "'";

                    switch (SelectTimer)
                    {
                        case "1":                                           //15分
                        case "2":                                           //30分
                        case "3":                                           //45分
                        case "4":                                           //60分
                            sql = sql
                                + "    AND Timer = '" + SelectTimer + "'"
                                + "    AND CancelFlg = ''";
                            break;
                        case "5":                                           //60分換算
                            sql = sql
                                + "    AND CancelFlg = ''";
                            break;
                        case "6":                                           //試行中止
                            sql = sql
                                + "    AND CancelFlg = '1'";
                            break;
                    }

                    switch (SelectCourse)
                    {
                        case "1":                                           //実力テスト／レベルアップトレーニング
                            sql = sql
                                + "    AND Course IN ('1','3')";
                            break;
                        case "2":                                           //基礎トレーニング
                            sql = sql
                                + "    AND Course = '2'";
                            break;
                    }

                    sql = sql
                        + "    AND DelFlg = 0"
                        + "  ORDER BY id";

                    using (SQLiteCommand command = new SQLiteCommand(sql, con))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            DetailData = new List<試行履歴データ>();
                            wkCnt = 0;
                            while (reader.Read())
                            {
                                wkCnt++;
                                // データの処理
                                rowData = new 試行履歴データ();
                                rowData.id = reader.GetInt32(0);
                                rowData.Times = wkCnt.ToString() + "回目";
                                rowData.StartDate = reader.GetDateTime(1).ToString("yyyy/MM/dd HH:mm:ss");
                                switch (reader.GetString(2))
                                {
                                    case "1":
                                        rowData.Course = "テスト";
                                        break;
                                    case "2":
                                        rowData.Course = "基礎";
                                        break;
                                    case "3":
                                        rowData.Course = "レベル";
                                        break;
                                }

                                if (reader.GetString(3) != "00分00秒") rowData.WorkTime = reader.GetString(3);

                                if (SelectTimer == "5")                   //60分換算
                                {
                                    rowData.WorkMaisu = reader.GetDecimal(7);
                                    rowData.CorrectMaisu = reader.GetDecimal(8);
                                    rowData.CorrectRate = reader.GetDecimal(9);
                                    rowData.WorkKoumoku = reader.GetDecimal(26);
                                    rowData.CorrectKoumoku = reader.GetDecimal(27);
                                    rowData.CorrectKoumokuRate = reader.GetDecimal(28);
                                }
                                else
                                {
                                    rowData.WorkMaisu = reader.GetInt32(4);
                                    rowData.CorrectMaisu = reader.GetInt32(5);
                                    rowData.CorrectRate = reader.GetDecimal(6);
                                    rowData.WorkKoumoku = reader.GetDecimal(23);
                                    rowData.CorrectKoumoku = reader.GetDecimal(24);
                                    rowData.CorrectKoumokuRate = reader.GetDecimal(25);
                                }

                                rowData.WorkCnt = reader.GetInt32(10);
                                rowData.CorrectCnt = reader.GetInt32(11);

                                switch (reader.GetString(12))
                                {
                                    case "1":
                                        rowData.Feedback = "音";
                                        break;
                                    case "2":
                                        rowData.Feedback = "図形";
                                        break;
                                    case "3":
                                        rowData.Feedback = "文字色";
                                        switch (reader.GetString(13))
                                        {
                                            case "1":
                                                rowData.ColorCD = "黒";
                                                break;
                                            case "2":
                                                rowData.ColorCD = "赤";
                                                break;
                                            case "3":
                                                rowData.ColorCD = "青";
                                                break;
                                            case "4":
                                                rowData.ColorCD = "緑";
                                                break;
                                            case "5":
                                                rowData.ColorCD = "黄";
                                                break;
                                            case "6":
                                                rowData.ColorCD = "オレンジ";
                                                break;
                                        }
                                        break;
                                }

                                if (reader.GetString(14) == "1")
                                {
                                    if (reader.GetString(15) == "1")
                                    {
                                        rowData.FormDisp = "画面左";
                                    }
                                    else
                                    {
                                        rowData.FormDisp = "画面右";
                                    }
                                }
                                else
                                {
                                    rowData.FormDisp = "紙";
                                }

                                if (reader.GetString(16) == "1")
                                {
                                    rowData.Teiji = "番号順";
                                }
                                else
                                {
                                    rowData.Teiji = "シャッフル";
                                }

                                if (reader.GetString(17) == "1")
                                {
                                    rowData.DispProgress = "○";
                                }
                                else
                                {
                                    rowData.DispProgress = "×";
                                }

                                if (reader.GetString(18) == "1")
                                {
                                    rowData.DispTimer = "○";
                                }
                                else
                                {
                                    rowData.DispTimer = "×";
                                }

                                if (reader.GetString(19) == "1")
                                {
                                    rowData.DispRemain = "○";
                                }
                                else
                                {
                                    rowData.DispRemain = "×";
                                }

                                if (reader.GetString(20) == "1")
                                {
                                    rowData.DispGraph = "○";
                                }
                                else
                                {
                                    rowData.DispGraph = "×";
                                }

                                if (reader.GetString(21) == "1")
                                {
                                    rowData.ZipSearch = "○";
                                }
                                else
                                {
                                    rowData.ZipSearch = "×";
                                }

                                if (reader.GetString(22) == "1")
                                {
                                    rowData.Sound = "○";
                                }
                                else
                                {
                                    rowData.Sound = "×";
                                }

                                switch (reader.GetString(29))
                                {
                                    case "1":
                                        rowData.Timer = "15分";
                                        break;
                                    case "2":
                                        rowData.Timer = "30分";
                                        break;
                                    case "3":
                                        rowData.Timer = "45分";
                                        break;
                                    case "4":
                                        rowData.Timer = "60分";
                                        break;
                                    default:
                                        rowData.Timer = "不明";
                                        break;
                                }

                                DetailData.Add(rowData);
                            }
                        }
                    }

                    DgvDetail.Rows.Clear();
                    maxValue = 0;

                    foreach (試行履歴データ tmpRowdata in DetailData)
                    {
                        if ((CmbCourse.SelectedIndex == 0) && (CmbDisp.SelectedIndex != 0))
                        {
                            //実力テスト以外は表示しない
                            if (tmpRowdata.Course != "テスト")
                            {
                                continue;
                            }

                            if (CmbDisp.SelectedIndex == 1)                      //最大枚数の場合 
                            {
                                if (tmpRowdata.WorkMaisu > maxValue)
                                {
                                    //新しい最大枚数の場合、一覧をクリアして表示する
                                    DgvDetail.Rows.Clear();
                                    maxValue = tmpRowdata.WorkMaisu;
                                }
                                else if (tmpRowdata.WorkMaisu < maxValue)
                                {
                                    //最大枚数ではない場合、表示しない
                                    continue;
                                }
                            }
                            else                                                 //最大正解率の場合
                            {
                                if (tmpRowdata.CorrectRate > maxValue)
                                {
                                    //新しい最大正解率の場合、一覧をクリアして表示する
                                    DgvDetail.Rows.Clear();
                                    maxValue = tmpRowdata.CorrectRate;
                                }
                                else if (tmpRowdata.CorrectRate < maxValue)
                                {
                                    //最大正解率ではない場合、表示しない
                                    continue;
                                }
                            }
                        }

                        //一覧表示
                        DgvDetail.Rows.Add(tmpRowdata.id
                                       , true
                                       , tmpRowdata.Times
                                       , tmpRowdata.StartDate
                                       , tmpRowdata.Course
                                       , ((SelectTimer == "6") ? tmpRowdata.WorkTime : tmpRowdata.Timer)
                                       , ((SelectTimer == "5") ? (Math.Truncate(tmpRowdata.WorkMaisu * 10) / 10).ToString()
                                                               : tmpRowdata.WorkMaisu.ToString()) + "枚"
                                       , ((SelectTimer == "5") ? (Math.Truncate(tmpRowdata.CorrectMaisu * 10) / 10).ToString()
                                                               : tmpRowdata.CorrectMaisu.ToString()) + "枚"
                                       , Math.Round(tmpRowdata.CorrectRate, 1, MidpointRounding.AwayFromZero).ToString() + "%"
                                       , ((tmpRowdata.Course == "レベル") ? tmpRowdata.WorkCnt.ToString() + "枚" : "")
                                       , ((tmpRowdata.Course == "レベル") ? tmpRowdata.CorrectCnt.ToString() + "枚" : "")
                                       , tmpRowdata.Feedback
                                       , tmpRowdata.ColorCD
                                       , tmpRowdata.FormDisp
                                       , tmpRowdata.Teiji
                                       , tmpRowdata.DispProgress
                                       , tmpRowdata.DispTimer
                                       , tmpRowdata.DispRemain
                                       , tmpRowdata.DispGraph
                                       , tmpRowdata.ZipSearch
                                       , tmpRowdata.Sound
                                       , ((SelectTimer == "5") ? (Math.Truncate(tmpRowdata.WorkKoumoku * 10) / 10).ToString()
                                                               : tmpRowdata.WorkKoumoku.ToString()) + "枚"
                                       , ((SelectTimer == "5") ? (Math.Truncate(tmpRowdata.CorrectKoumoku * 10) / 10).ToString()
                                                               : tmpRowdata.CorrectKoumoku.ToString()) + "枚"
                                       , Math.Round(tmpRowdata.CorrectKoumokuRate, 1, MidpointRounding.AwayFromZero).ToString() + "%"
                                        );
                    }
                    con.Close();
                }
                BtnDel.Enabled = (DgvDetail.Rows.Count > 0);
                BtnList.Enabled = (DgvDetail.Rows.Count > 0);
                BtnResult.Enabled = (DgvDetail.Rows.Count > 0);

                LblCnt.Text = DgvDetail.Rows.Count.ToString("#,0");
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
        //              明細削除
        /// </summary>
        /// <param name="FileName">出力ファイル(フルパス)</param>
        private void DeleteDetail()
        {
            // SQL クエリ
            string sql = "";
            SQLiteCommand com;

            int id = (int)DgvDetail.CurrentRow.Cells[0].Value;

            // メッセージボックスを表示
            DialogResult result = System.Windows.Forms.MessageBox.Show("選択された試行回（" +
                                                                       DgvDetail.CurrentRow.Cells[2].Value + " " +
                                                                       DgvDetail.CurrentRow.Cells[3].Value + "）" +
                                                                       "の履歴を削除してよろしいですか？",

                                                  "削除", MessageBoxButtons.YesNo);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                // データＤＢを開く
                using (SQLiteConnection con = new SQLiteConnection(SetconnectionString(connectionString)))
                {
                    try
                    {
                        //入力値ファイル、解析結果ファイル名編集
                        SetFileName(DgvDetail.CurrentRow.Index);
                        //入力値ファイル、解析結果ファイルの削除
                        if (File.Exists(InputFileName)) File.Delete(InputFileName);
                        if (File.Exists(ResultFileName)) File.Delete(ResultFileName);

                        con.Open();

                        //履歴データを更新する
                        sql = "Update 履歴データ SET   DelFlg  = 1," +
                                                      "UpdDate = datetime('now', 'localtime') " +
                                                "WHERE Id = " + id.ToString() + ";";

                        com = new SQLiteCommand(sql, con);
                        com.ExecuteNonQuery();
                        con.Close();
                    }

                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message, "エラー");
                        //終了
                        this.Dispose();
                        this.Close();
                    }
                }

            }

            //データ再取得
            GetDetailData();
        }

        /// <summary>
        //              インターフェース　編集
        /// </summary>
        private void SetInterFace()
        {
            ListdetailData = new List<解析結果出力IF.DetailData>();
            MaxMinData = new 解析結果出力IF.MaxMinData();
            Boolean firstSw = true;

            for (int row = 0; row < DgvDetail.RowCount; row++)
            {
                if ((Boolean)DgvDetail.Rows[row].Cells[1].Value)
                {
                    detailData = new 解析結果出力IF.DetailData();
                    detailData.WorkTimes = "" + DgvDetail.Rows[row].Cells[2].Value.ToString();
                    detailData.Course = "" + DgvDetail.Rows[row].Cells[4].Value.ToString();
                    detailData.WorkDate = "" + DgvDetail.Rows[row].Cells[3].Value.ToString();
                    detailData.WorkTime = 0;  //0:全体
                    detailData.WorkMaisu = decimal.Parse(DgvDetail.Rows[row].Cells[6].Value.ToString().Replace("枚", ""));
                    detailData.CorrectMaisu = decimal.Parse(DgvDetail.Rows[row].Cells[7].Value.ToString().Replace("枚", ""));
                    detailData.ErrorMaisu = detailData.WorkMaisu - detailData.CorrectMaisu;
                    detailData.CorrectRate = decimal.Parse(DgvDetail.Rows[row].Cells[8].Value.ToString().Replace("%", ""));
                    detailData.WorkItem = decimal.Parse(DgvDetail.Rows[row].Cells[21].Value.ToString().Replace("枚", ""));
                    detailData.CorrectItem = decimal.Parse(DgvDetail.Rows[row].Cells[22].Value.ToString().Replace("枚", ""));
                    detailData.ErrorItem = detailData.WorkItem - detailData.CorrectItem;
                    detailData.CorrectItemRate = decimal.Parse(DgvDetail.Rows[row].Cells[23].Value.ToString().Replace("%", ""));
                    //ファイル名編集
                    SetFileName(row);
                    detailData.FileNameI = InputFileName;
                    detailData.FileNameR = ResultFileName;

                    ListdetailData.Add(detailData);

                    //最高値最低値取得
                    if (firstSw)
                    {
                        MaxMinData.WorkTime = 0;  //0:全体
                        MaxMinData.MaxMaisu = detailData.WorkMaisu;
                        MaxMinData.MinMaisu = detailData.WorkMaisu;
                        MaxMinData.MaxRate = detailData.CorrectRate;
                        MaxMinData.MinRate = detailData.CorrectRate;
                        MaxMinData.MaxKoumoku = detailData.WorkItem;
                        MaxMinData.MinKoumoku = detailData.WorkItem;
                        MaxMinData.MaxKoumokuRate = detailData.CorrectItemRate;
                        MaxMinData.MinKoumokuRate = detailData.CorrectItemRate;

                        firstSw = false;
                    }
                    else
                    {
                        if (MaxMinData.MaxMaisu < detailData.WorkMaisu) MaxMinData.MaxMaisu = detailData.WorkMaisu;
                        if (MaxMinData.MinMaisu > detailData.WorkMaisu) MaxMinData.MinMaisu = detailData.WorkMaisu;
                        if (MaxMinData.MaxRate < detailData.CorrectRate) MaxMinData.MaxRate = detailData.CorrectRate;
                        if (MaxMinData.MinRate > detailData.CorrectRate) MaxMinData.MinRate = detailData.CorrectRate;
                        if (MaxMinData.MaxKoumoku < detailData.WorkItem) MaxMinData.MaxKoumoku = detailData.WorkItem;
                        if (MaxMinData.MinKoumoku > detailData.WorkItem) MaxMinData.MinKoumoku = detailData.WorkItem;
                        if (MaxMinData.MaxKoumokuRate < detailData.CorrectItemRate) MaxMinData.MaxKoumokuRate = detailData.CorrectItemRate;
                        if (MaxMinData.MinKoumokuRate > detailData.CorrectItemRate) MaxMinData.MinKoumokuRate = detailData.CorrectItemRate;
                    }
                }
            }

        }

        /// <summary>
        //              ファイル名　編集
        /// </summary>
        /// <param name="row">行位置(フルパス)</param>
        private void SetFileName(int row)
        {
            string timeStamp = "" + DgvDetail.Rows[row].Cells[3].Value.ToString();
            timeStamp = timeStamp.Replace("/", "");
            timeStamp = timeStamp.Replace(":", "");
            timeStamp = timeStamp.Replace(" ", "_");

            switch (CmbMode.SelectedIndex)
            {
                case 0:
                    InputFileName = "解析結果\\" + UserId.ToString() + "\\"
                                  + timeStamp + "_入力値_アンケート_" + UserName.Replace("　", "_") + ".csv";
                    ResultFileName = "解析結果\\" + UserId.ToString() + "\\"
                                   + timeStamp + "_解析結果_アンケート_" + UserName.Replace("　", "_") + ".csv";
                    break;
                case 1:
                    InputFileName = "解析結果\\" + UserId.ToString() + "\\"
                                  + timeStamp + "_入力値_顧客伝票_" + UserName.Replace("　", "_") + ".csv";
                    ResultFileName = "解析結果\\" + UserId.ToString() + "\\"
                                   + timeStamp + "_解析結果_顧客伝票_" + UserName.Replace("　", "_") + ".csv";
                    break;
                case 2:
                    InputFileName = "解析結果\\" + UserId.ToString() + "\\"
                                  + timeStamp + "_入力値_ミスチェック_" + UserName.Replace("　", "_") + ".csv";
                    ResultFileName = "解析結果\\" + UserId.ToString() + "\\"
                                   + timeStamp + "_解析結果_ミスチェック_" + UserName.Replace("　", "_") + ".csv";
                    break;
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
                                                                        "''," +
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
                                                                        "''," +
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
