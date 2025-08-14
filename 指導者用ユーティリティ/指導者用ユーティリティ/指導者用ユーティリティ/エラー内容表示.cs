using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using ScottPlot.Colormaps;
using ScottPlot.MultiplotLayouts;
using System.Data.SQLite;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using static 指導者用ユーティリティ.解析結果出力IF;

namespace 指導者用ユーティリティ
{
    public partial class Frmエラー内容表示 : Form
    {
        // SqLite ファイルへの接続文字列
        private string connectionString = "";
        private string connectionStringMst = "";

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
        private string WorkTimes = "";
        private string WorkTime = "";
        private string WorkDate = "";
        private string FileNameI = "";
        private string FileNameR = "";

        //エラー内容抽出データ
        public struct エラー内容抽出データ
        {
            public int CardNo = 0;
            public string Item = "";
            public string ErrorType = "";
            public string CharType = "";
            public string CorrectChar = "";
            public string ErrorChar = "";
            public string WorkTime = "";

            public エラー内容抽出データ()
            {
            }
        }

        //アンケート入力データ
        public struct アンケート入力データ
        {
            public string NameKana = "";
            public string NameKanji = "";
            public string ZipCode = "";
            public string Address = "";
            public string TelNo = "";
            public string MailAddress = "";
            public string Q1Answer = "";
            public string Q2Answer = "";
            public string Q3Answer = "";

            public アンケート入力データ()
            {
            }
        }

        //顧客伝票入力データ
        public struct 顧客伝票入力データ
        {
            public string CustCd = "";
            public string ItemCd = "";
            public string TelNo = "";
            public string MailAddress = "";

            public 顧客伝票入力データ()
            {
            }
        }

        //エラー内容抽出リスト
        List<エラー内容抽出データ> DetailList = new List<エラー内容抽出データ>();

        //最小化フォームサイズ(幅762、高さ543)
        private int MiniWidth = 762;
        private int MiniHeight = 543;

        /// <summary>
        //              Frm解析結果出力
        /// </summary>
        /// <param name="prmUser">ユーザ名</param>
        /// <param name="prmMode">モード</param>
        /// <param name="prmCourse">コース</param>
        /// <param name="prmCourseNm">コース名称</param>
        /// <param name="prmWorkTimes">試行回数</param>
        /// <param name="prmWorkTime">経過時間</param>
        /// <param name="prmWorkDate">実施日</param>
        /// <param name="prmListDetail">入力値ファイル</param>
        /// <param name="prmMaxMin">解析結果ファイル</param>
        public Frmエラー内容表示(string prmUser, int prmMode, int prmCourse, string prmCourseNm, string prmWorkTimes, string prmWorkTime,
                                 string prmWorkDate, string prmFileNameI, string prmFileNameR)
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
            //DgvTotal.AllowUserToResizeColumns = false;
            DgvDetail.AllowUserToResizeRows = false;

            //データグリッドビュー罫線をなくす
            DgvDetail.CellBorderStyle = DataGridViewCellBorderStyle.None;

            //データグリッドビュー並べ替え　禁止
            foreach (DataGridViewColumn c in DgvDetail.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            //このフォームの最小サイズを設定する
            this.MinimumSize = new System.Drawing.Size(MiniWidth, MiniHeight);

            //引継ぎパラメータセット
            UserName = prmUser;
            Mode = prmMode;
            Course = prmCourse;
            CourseNm = prmCourseNm;
            WorkTimes = prmWorkTimes;
            WorkTime = prmWorkTime;
            WorkDate = prmWorkDate;
            FileNameI = prmFileNameI;
            FileNameR = prmFileNameR;

        }

        /// <summary>
        //              ショートカットキー判定　Key Down
        /// </summary>
        /// <param name="keyData">キー情報</param>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            //［Alt］+［E］が押されたらキャッチ(エラー種別)
            if (keyData == (Keys.E | Keys.Alt))
            {
                if (CmbErrorType1.Visible)
                {
                    CmbErrorType1.Focus();
                }
                else
                {
                    CmbErrorType2.Focus();
                }
            }
            //［Alt］+［I］が押されたらキャッチ(項目名)
            if (keyData == (Keys.I | Keys.Alt))
            {
                if (CmbItemQ.Visible)
                {
                    CmbItemQ.Focus();
                }
                else
                {
                    CmbItemC.Focus();
                }
            }
            //［Alt］+［M］が押されたらキャッチ(文字種)
            if (keyData == (Keys.M | Keys.Alt))
            {
                CmbChar.Focus();
            }
            //［Alt］+［A］が押されたらキャッチ(ユーザー比較)
            if (keyData == (Keys.A | Keys.Alt))
            {
                BtnSave.PerformClick();
            }

            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        //              Form　Load 
        /// </summary>
        private void Frm解析結果出力_Load(object sender, EventArgs e)
        {
            // DB ファイルへの接続文字列
            if (System.IO.File.Exists(System.Windows.Forms.Application.StartupPath + @"\LetsTry04.ini"))
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                StreamReader sr = new StreamReader(System.Windows.Forms.Application.StartupPath + @"\LetsTry04.ini", Encoding.GetEncoding("Shift_JIS"));
                string fpath = "" + sr.ReadLine();
                connectionString = SetPathString(fpath);
                connectionStringMst = SetPathStringMst(fpath);
                sr.Close();

                TxtUserName.Text = UserName;
                TxtCourse.Text = CourseNm;
                TxtWorkTime.Text = WorkTime;
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
            ////データ取得
            GetDetailData();

            //初期値セット
            switch (Mode)
            {
                case 0:
                    //アンケート入力
                    CmbErrorType1.Visible = true;
                    CmbErrorType2.Visible = false;
                    CmbItemQ.Visible = true;
                    CmbItemC.Visible = false;
                    CmbErrorType1.SelectedIndex = 0;
                    CmbItemQ.SelectedIndex = 0;
                    CmbErrorType1.Enabled = false;
                    break;
                case 1:
                    //顧客伝票修正
                    CmbErrorType1.Visible = true;
                    CmbErrorType2.Visible = false;
                    CmbErrorType1.Enabled = true;
                    CmbItemQ.Visible = false;
                    CmbItemC.Visible = true;
                    CmbErrorType1.SelectedIndex = 0;
                    CmbItemC.SelectedIndex = 0;
                    break;
                case 2:
                    //顧客伝票ミスチェック
                    CmbErrorType1.Visible = false;
                    CmbErrorType2.Visible = true;
                    CmbItemQ.Visible = false;
                    CmbItemC.Visible = true;
                    CmbErrorType2.SelectedIndex = 0;
                    CmbItemC.SelectedIndex = 0;
                    break;
            }
            CmbChar.SelectedIndex = 0;
        }

        /// <summary>
        //              Form　Resize
        /// </summary>
        private void Frm解析結果出力_Resize(object sender, EventArgs e)
        {
            LblCnt.Location = new System.Drawing.Point(this.Size.Width - 106, 88);
            LblCnt2.Location = new System.Drawing.Point(this.Size.Width - 50, 88);
            DgvDetail.Size = new System.Drawing.Size(this.Size.Width - 58, this.Size.Height - 199);
            BtnSave.Location = new System.Drawing.Point(16, this.Size.Height - 79);
            LblComment.Location = new System.Drawing.Point(160, this.Size.Height - 71);
            BtnCompair.Location = new System.Drawing.Point(this.Size.Width - 290, this.Size.Height - 79);
            BtnCancel.Location = new System.Drawing.Point(this.Size.Width - 138, this.Size.Height - 79);
        }

        /// <summary>
        //              Form　Closing 
        /// </summary>
        private void Frm解析結果出力_FormClosing(object sender, FormClosingEventArgs e)
        {
            SetFormInfo();
        }

        /// <summary>
        //              ComboBox　SelectedIndexChanged
        /// </summary>
        private void Cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //一覧表示
            DispDetail();
        }

        /// <summary>
        //              ファイル保存　Click
        /// </summary>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.FileName = "";
            sfd.InitialDirectory = OutputDirString;
            sfd.Filter = "CSVファイル(*.csv)|*.csv|すべてのファイル(*.*)|*.*";
            sfd.FilterIndex = 1;
            sfd.Title = "名前をつけて保存";
            sfd.RestoreDirectory = true;
            sfd.OverwritePrompt = true;
            sfd.CheckPathExists = true;

            //ダイアログを表示する
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                CreateCSV(sfd.FileName);
                SetOutputPath(sfd.FileName);
                sfd.Dispose();
            }

        }

        /// <summary>
        //              正解と入力の比較　Click
        /// </summary>
        private void BtnCompair_Click(object sender, EventArgs e)
        {
            BtnCancel.Enabled = false;

            //非表示する
            this.Visible = false;

            string CardNo = "";
            string WorkTime = "";

            CardNo = "" + DgvDetail.CurrentRow.Cells[3].Value.ToString();
            WorkTime = "" + DgvDetail.CurrentRow.Cells[9].Value.ToString();
            switch (Mode)
            {
                case 0:
                    Frm入力値表示アンケートカード入力 frmQ = new Frm入力値表示アンケートカード入力(Course, CardNo, WorkTime, FileNameI);
                    frmQ.ShowDialog();
                    break;
                case 1:
                    Frm入力値表示顧客伝票修正 frmD = new Frm入力値表示顧客伝票修正(Course, CardNo, WorkTime, FileNameI);
                    frmD.ShowDialog();
                    break;
                case 2:
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
                DgvDetail.CurrentRow.Cells[0].Selected = true;
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
                DgvDetail.CurrentRow.Cells[0].Selected = true;
                BtnCompair.PerformClick();
            }
        }

        /// <summary>
        //              一覧　KeyDown
        /// </summary>
        private void DgvDetail_KeyDown(object sender, KeyEventArgs e)
        {
            //Tab Key
            if (e.KeyCode == Keys.Tab)
            {
                //フォーカス移動
                BtnCompair.Focus();
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

        //              一覧データ取得処理
        /// </summary>
        /// <returns>true:正常終了　false:異常終了</returns>
        private Boolean GetDetailData()
        {
            try
            {
                int CardNo = 0;
                int svCardNo = 0;
                string svWorkTime = "";
                string sql = "";
                string cardDataTbl = "";

                List<エラー内容抽出データ> tmpCardErrorList = new List<エラー内容抽出データ>();
                List<エラー内容抽出データ> CardErrorList = new List<エラー内容抽出データ>();

                DetailList = new List<エラー内容抽出データ>();

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

                    Boolean ItemSw = false;

                    while (!txtParser.EndOfData)
                    {
                        string[]? values = txtParser.ReadFields();
                        int CellCount = 0;
                        エラー内容抽出データ tmpCardErrorData = new エラー内容抽出データ();
                        エラー内容抽出データ CardErrorData = new エラー内容抽出データ();

                        foreach (string value in values)
                        {
                            if (value == "アンケート入力・解析結果") break;
                            if (value == "顧客伝票修正・解析結果") break;
                            if (value == "顧客伝票ミスチェック・解析結果") break;
                            if (value == "エラー") break;
                            if (value == "合計") break;
                            if (value == "■採点結果") break;
                            if (value == "■目標設定") break;
                            if (value == "■試行条件の設定") break;

                            if (value == "■項目別エラー一覧") ItemSw = true;
                            if (value == "■文字種別エラー一覧") ItemSw = false;

                            //エラー項目取得
                            if (ItemSw)
                            {
                                switch (CellCount)
                                {
                                    case 1:
                                        CardNo = int.Parse(value);
                                        tmpCardErrorList = new List<エラー内容抽出データ>();
                                        break;
                                    case 2:
                                    case 3:
                                    case 4:
                                    case 5:
                                    case 7:
                                    case 8:
                                    case 9:
                                    case 10:
                                        if (value == "×")
                                        {
                                            tmpCardErrorData.CardNo = CardNo;
                                            switch (CellCount)
                                            {
                                                case 2:
                                                    tmpCardErrorData.Item = (Mode == 0) ? "フリガナ" : "顧客コード";
                                                    break;
                                                case 3:
                                                    tmpCardErrorData.Item = (Mode == 0) ? "氏名" : "商品コード";
                                                    break;
                                                case 4:
                                                    tmpCardErrorData.Item = (Mode == 0) ? "郵便番号" : "電話番号";
                                                    break;
                                                case 5:
                                                    tmpCardErrorData.Item = (Mode == 0) ? "住所" : "メールアドレス";
                                                    break;
                                                case 7:
                                                    tmpCardErrorData.Item = (Mode == 0) ? "メールアドレス" : "";
                                                    break;
                                                case 8:
                                                    tmpCardErrorData.Item = (Mode == 0) ? "問１" : "";
                                                    break;
                                                case 9:
                                                    tmpCardErrorData.Item = (Mode == 0) ? "問２" : "";
                                                    break;
                                                case 10:
                                                    tmpCardErrorData.Item = (Mode == 0) ? "問３" : "";
                                                    break;
                                            }
                                            tmpCardErrorList.Add(tmpCardErrorData);
                                            tmpCardErrorData = new エラー内容抽出データ();
                                        }
                                        break;
                                    case 6:
                                        if (Mode == 0)
                                        {
                                            tmpCardErrorData.CardNo = CardNo;
                                            tmpCardErrorData.Item = "電話番号";
                                            tmpCardErrorList.Add(tmpCardErrorData);
                                            tmpCardErrorData = new エラー内容抽出データ();
                                        }
                                        else
                                        {
                                            foreach (エラー内容抽出データ TC in tmpCardErrorList)
                                            {
                                                CardErrorData = new エラー内容抽出データ();
                                                CardErrorData.CardNo = TC.CardNo;
                                                CardErrorData.Item = TC.Item;
                                                CardErrorData.WorkTime = value;
                                                CardErrorList.Add(CardErrorData);
                                            }
                                        }
                                        break;
                                    case 11:
                                        foreach (エラー内容抽出データ TC in tmpCardErrorList)
                                        {
                                            CardErrorData = new エラー内容抽出データ();
                                            CardErrorData.CardNo = TC.CardNo;
                                            CardErrorData.Item = TC.Item;
                                            CardErrorData.WorkTime = value;
                                            CardErrorList.Add(CardErrorData);
                                        }
                                        break;
                                }

                                CellCount++;
                            }
                        }
                    }
                }

                //エラー内容取得
                svCardNo = 0;
                svWorkTime = "";

                アンケート入力データ CorrectQ = new アンケート入力データ();
                アンケート入力データ InputQ = new アンケート入力データ();
                顧客伝票入力データ CorrectC = new 顧客伝票入力データ();
                顧客伝票入力データ ErrorC = new 顧客伝票入力データ();
                顧客伝票入力データ InputC = new 顧客伝票入力データ();

                foreach (エラー内容抽出データ EL in CardErrorList)
                {
                    switch (Mode)
                    {
                        case 0:
                            //正しいデータを取得
                            if (svCardNo != EL.CardNo)
                            {
                                // データＤＢを開く
                                using (SQLiteConnection con = new SQLiteConnection(SetconnectionString(connectionStringMst)))
                                {
                                    con.Open();

                                    //アンケートカードデータを取得する
                                    cardDataTbl = (Course == 0) ? "MstQuestionLevelUp" : "MstQuestionBasic";
                                    svCardNo = EL.CardNo;

                                    sql = "SELECT * From " + cardDataTbl + " WHERE id = " + svCardNo.ToString();

                                    using (SQLiteCommand command = new SQLiteCommand(sql, con))
                                    {
                                        using (SQLiteDataReader reader = command.ExecuteReader())
                                        {
                                            while (reader.Read())
                                            {
                                                // データの処理
                                                CorrectQ = new アンケート入力データ();
                                                CorrectQ.NameKana = reader.GetString(1);
                                                CorrectQ.NameKanji = reader.GetString(2);
                                                CorrectQ.ZipCode = reader.GetString(3);
                                                CorrectQ.Address = reader.GetString(4);
                                                CorrectQ.TelNo = reader.GetString(5);
                                                CorrectQ.MailAddress = reader.GetString(6);
                                                CorrectQ.Q1Answer = reader.GetString(7);
                                                CorrectQ.Q2Answer = reader.GetString(8);
                                                CorrectQ.Q3Answer = reader.GetString(9);
                                            }
                                        }
                                    }
                                    con.Close();
                                }
                            }

                            //入力データを取得
                            //入力値ファイル取得
                            if ((svCardNo != EL.CardNo) || (svWorkTime != EL.WorkTime))
                            {
                                if (!File.Exists(FileNameI))
                                {
                                    System.Windows.Forms.MessageBox.Show("システム環境に問題があります。(File Not Found(" + FileNameI + "))",
                                                                         "エラー");
                                    //終了
                                    this.Dispose();
                                    this.Close();
                                    return false;
                                }

                                using (TextFieldParser txtParser = new TextFieldParser(FileNameI))
                                {
                                    txtParser.SetDelimiters(",");

                                    while (!txtParser.EndOfData)
                                    {
                                        string[]? values = txtParser.ReadFields();
                                        int CellCount = 0;
                                        Boolean CorrespondSw = false;
                                        Boolean BreakSw = false;

                                        foreach (string value in values)
                                        {
                                            if (value == "開始時刻") break;

                                            switch (CellCount)
                                            {
                                                case 2:
                                                    CorrespondSw = (value == EL.WorkTime);
                                                    break;
                                                case 4:
                                                    CorrespondSw = (int.Parse(value) == EL.CardNo);
                                                    InputQ = new アンケート入力データ();
                                                    break;
                                                case 5:
                                                    InputQ.NameKana = value;
                                                    break;
                                                case 6:
                                                    InputQ.NameKanji = value;
                                                    break;
                                                case 7:
                                                    InputQ.ZipCode = value;
                                                    break;
                                                case 8:
                                                    InputQ.Address = value;
                                                    break;
                                                case 9:
                                                    InputQ.TelNo = value;
                                                    break;
                                                case 10:
                                                    InputQ.MailAddress = value;
                                                    break;
                                                case 11:
                                                    InputQ.Q1Answer = value;
                                                    break;
                                                case 12:
                                                    InputQ.Q2Answer = value;
                                                    break;
                                                case 13:
                                                    switch (value)
                                                    {
                                                        case "0":
                                                            InputQ.Q3Answer = "";
                                                            break;
                                                        case "1":
                                                        case "2":
                                                            InputQ.Q3Answer = value;
                                                            break;
                                                        case "両方ともON":
                                                            InputQ.Q3Answer = "3";
                                                            break;
                                                    }
                                                    BreakSw = true;

                                                    break;
                                            }
                                            CellCount++;
                                            if ((CellCount > 2) && (!CorrespondSw)) break;
                                        }

                                        if (BreakSw) break;
                                    }
                                }
                            }

                            //エラー内容編集
                            switch (EL.Item)
                            {
                                case "フリガナ":
                                    CheckQuestion(CorrectQ.NameKana, InputQ.NameKana, EL, ref DetailList);
                                    break;
                                case "氏名":
                                    CheckQuestion(CorrectQ.NameKanji, InputQ.NameKanji, EL, ref DetailList);
                                    break;
                                case "郵便番号":
                                    CheckQuestion(CorrectQ.ZipCode, InputQ.ZipCode, EL, ref DetailList);
                                    break;
                                case "住所":
                                    CheckQuestion(CorrectQ.Address, InputQ.Address, EL, ref DetailList);
                                    break;
                                case "電話番号":
                                    CheckQuestion(CorrectQ.TelNo, InputQ.TelNo, EL, ref DetailList);
                                    break;
                                case "メールアドレス":
                                    CheckQuestion(CorrectQ.MailAddress, InputQ.MailAddress, EL, ref DetailList);
                                    break;
                                case "問１":
                                    CheckQuestion(CorrectQ.Q1Answer, InputQ.Q1Answer, EL, ref DetailList);
                                    break;
                                case "問２":
                                    CheckQuestion(CorrectQ.Q2Answer, InputQ.Q2Answer, EL, ref DetailList);
                                    break;
                                case "問３":
                                    CheckQuestion(CorrectQ.Q3Answer, InputQ.Q3Answer, EL, ref DetailList);
                                    break;
                            }
                            break;
                        case 1:
                            //正しいデータを取得
                            if (svCardNo != EL.CardNo)
                            {
                                // データＤＢを開く
                                using (SQLiteConnection con = new SQLiteConnection(SetconnectionString(connectionStringMst)))
                                {
                                    con.Open();

                                    //顧客伝票データを取得する
                                    cardDataTbl = (Course == 0) ? "MstCustomerSlip" : "MstCustomerSlipBasic";
                                    svCardNo = EL.CardNo;

                                    sql = "SELECT * From " + cardDataTbl + " WHERE id = " + svCardNo.ToString();

                                    using (SQLiteCommand command = new SQLiteCommand(sql, con))
                                    {
                                        using (SQLiteDataReader reader = command.ExecuteReader())
                                        {
                                            while (reader.Read())
                                            {
                                                // データの処理
                                                CorrectC = new 顧客伝票入力データ();
                                                CorrectC.CustCd = reader.GetString(1);
                                                CorrectC.ItemCd = reader.GetString(2);
                                                CorrectC.TelNo = reader.GetString(3);
                                                CorrectC.MailAddress = reader.GetString(4);
                                            }
                                        }
                                    }

                                    //顧客伝票エラーデータを取得する
                                    cardDataTbl = (Course == 0) ? "MstCustomerSlipError" : "MstCustomerSlipErrorBasic";
                                    svCardNo = EL.CardNo;

                                    sql = "SELECT * From " + cardDataTbl + " WHERE id = " + svCardNo.ToString();

                                    using (SQLiteCommand command = new SQLiteCommand(sql, con))
                                    {
                                        using (SQLiteDataReader reader = command.ExecuteReader())
                                        {
                                            while (reader.Read())
                                            {
                                                // データの処理
                                                ErrorC = new 顧客伝票入力データ();
                                                ErrorC.CustCd = reader.GetString(1);
                                                ErrorC.ItemCd = reader.GetString(2);
                                                ErrorC.TelNo = reader.GetString(3);
                                                ErrorC.MailAddress = reader.GetString(4);
                                            }
                                        }
                                    }
                                    con.Close();
                                }
                            }

                            //入力データを取得
                            //入力値ファイル取得
                            if ((svCardNo != EL.CardNo) || (svWorkTime != EL.WorkTime))
                            {
                                if (!File.Exists(FileNameI))
                                {
                                    System.Windows.Forms.MessageBox.Show("システム環境に問題があります。(File Not Found(" + FileNameI + "))",
                                                                         "エラー");
                                    //終了
                                    this.Dispose();
                                    this.Close();
                                    return false;
                                }

                                using (TextFieldParser txtParser = new TextFieldParser(FileNameI))
                                {
                                    txtParser.SetDelimiters(",");

                                    while (!txtParser.EndOfData)
                                    {
                                        string[]? values = txtParser.ReadFields();
                                        int CellCount = 0;
                                        Boolean CorrespondSw = false;
                                        Boolean BreakSw = false;

                                        foreach (string value in values)
                                        {
                                            if (value == "開始時刻") break;

                                            switch (CellCount)
                                            {
                                                case 2:
                                                    CorrespondSw = (value == EL.WorkTime);
                                                    break;
                                                case 4:
                                                    CorrespondSw = (int.Parse(value) == EL.CardNo);
                                                    InputC = new 顧客伝票入力データ();
                                                    break;
                                                case 5:
                                                    InputC.CustCd = value;
                                                    break;
                                                case 6:
                                                    InputC.ItemCd = value;
                                                    break;
                                                case 7:
                                                    InputC.TelNo = value;
                                                    break;
                                                case 8:
                                                    InputC.MailAddress = value;
                                                    BreakSw = true;
                                                    break;
                                            }
                                            CellCount++;
                                            if ((CellCount > 2) && (!CorrespondSw)) break;
                                        }

                                        if (BreakSw) break;
                                    }
                                }
                            }

                            //エラー内容編集
                            switch (EL.Item)
                            {
                                case "顧客コード":
                                    CheckCustomer(CorrectC.CustCd, ErrorC.CustCd, InputC.CustCd, EL, ref DetailList);
                                    break;
                                case "商品コード":
                                    CheckCustomer(CorrectC.ItemCd, ErrorC.ItemCd, InputC.ItemCd, EL, ref DetailList);
                                    break;
                                case "電話番号":
                                    CheckCustomer(CorrectC.TelNo, ErrorC.TelNo, InputC.TelNo, EL, ref DetailList);
                                    break;
                                case "メールアドレス":
                                    CheckCustomer(CorrectC.MailAddress, ErrorC.MailAddress, InputC.MailAddress, EL, ref DetailList);
                                    break;
                            }
                            break;
                        case 2:
                            //正しいデータを取得
                            if (svCardNo != EL.CardNo)
                            {
                                // データＤＢを開く
                                using (SQLiteConnection con = new SQLiteConnection(SetconnectionString(connectionStringMst)))
                                {
                                    con.Open();

                                    //顧客伝票データを取得する
                                    cardDataTbl = (Course == 0) ? "MstCustomerSlip" : "MstCustomerSlipBasic";
                                    svCardNo = EL.CardNo;

                                    sql = "SELECT * From " + cardDataTbl + " WHERE id = " + svCardNo.ToString();

                                    using (SQLiteCommand command = new SQLiteCommand(sql, con))
                                    {
                                        using (SQLiteDataReader reader = command.ExecuteReader())
                                        {
                                            while (reader.Read())
                                            {
                                                // データの処理
                                                CorrectC = new 顧客伝票入力データ();
                                                CorrectC.CustCd = reader.GetString(1);
                                                CorrectC.ItemCd = reader.GetString(2);
                                                CorrectC.TelNo = reader.GetString(3);
                                                CorrectC.MailAddress = reader.GetString(4);
                                            }
                                        }
                                    }

                                    //顧客伝票エラーデータを取得する
                                    cardDataTbl = (Course == 0) ? "MstCustomerSlipError" : "MstCustomerSlipErrorBasic";
                                    svCardNo = EL.CardNo;

                                    sql = "SELECT * From " + cardDataTbl + " WHERE id = " + svCardNo.ToString();

                                    using (SQLiteCommand command = new SQLiteCommand(sql, con))
                                    {
                                        using (SQLiteDataReader reader = command.ExecuteReader())
                                        {
                                            while (reader.Read())
                                            {
                                                // データの処理
                                                ErrorC = new 顧客伝票入力データ();
                                                ErrorC.CustCd = reader.GetString(1);
                                                ErrorC.ItemCd = reader.GetString(2);
                                                ErrorC.TelNo = reader.GetString(3);
                                                ErrorC.MailAddress = reader.GetString(4);
                                            }
                                        }
                                    }
                                    con.Close();
                                }
                            }

                            //入力データを取得
                            //入力値ファイル取得
                            if ((svCardNo != EL.CardNo) || (svWorkTime != EL.WorkTime))
                            {
                                if (!File.Exists(FileNameI))
                                {
                                    System.Windows.Forms.MessageBox.Show("システム環境に問題があります。(File Not Found(" + FileNameI + "))",
                                                                         "エラー");
                                    //終了
                                    this.Dispose();
                                    this.Close();
                                    return false;
                                }

                                using (TextFieldParser txtParser = new TextFieldParser(FileNameI))
                                {
                                    txtParser.SetDelimiters(",");

                                    while (!txtParser.EndOfData)
                                    {
                                        string[]? values = txtParser.ReadFields();
                                        int CellCount = 0;
                                        Boolean CorrespondSw = false;
                                        Boolean BreakSw = false;

                                        foreach (string value in values)
                                        {
                                            if (value == "開始時刻") break;

                                            switch (CellCount)
                                            {
                                                case 2:
                                                    CorrespondSw = (value == EL.WorkTime);
                                                    break;
                                                case 4:
                                                    CorrespondSw = (int.Parse(value) == EL.CardNo);
                                                    InputC = new 顧客伝票入力データ();
                                                    break;
                                                case 5:
                                                    InputC.CustCd = value;
                                                    break;
                                                case 6:
                                                    InputC.ItemCd = value;
                                                    break;
                                                case 7:
                                                    InputC.TelNo = value;
                                                    break;
                                                case 8:
                                                    InputC.MailAddress = value;
                                                    BreakSw = true;
                                                    break;
                                            }
                                            CellCount++;
                                            if ((CellCount > 2) && (!CorrespondSw)) break;
                                        }

                                        if (BreakSw) break;
                                    }
                                }
                            }

                            //エラー内容編集
                            switch (EL.Item)
                            {
                                case "顧客コード":
                                    CheckCustomerCheck(CorrectC.CustCd, ErrorC.CustCd, InputC.CustCd, EL, ref DetailList);
                                    break;
                                case "商品コード":
                                    CheckCustomerCheck(CorrectC.ItemCd, ErrorC.ItemCd, InputC.ItemCd, EL, ref DetailList);
                                    break;
                                case "電話番号":
                                    CheckCustomerCheck(CorrectC.TelNo, ErrorC.TelNo, InputC.TelNo, EL, ref DetailList);
                                    break;
                                case "メールアドレス":
                                    CheckCustomerCheck(CorrectC.MailAddress, ErrorC.MailAddress, InputC.MailAddress, EL, ref DetailList);
                                    break;
                            }
                            break;
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

        //              一覧表示処理
        /// </summary>
        /// <returns>true:正常終了　false:異常終了</returns>
        private Boolean DispDetail()
        {
            Boolean DispSw = true;
            //集計値一覧
            DgvDetail.Rows.Clear();

            foreach (エラー内容抽出データ DD in DetailList)
            {
                DispSw = true;
                switch (Mode)
                {
                    case 0:
                        //アンケート入力
                        ////項目名
                        switch (CmbItemQ.SelectedIndex)
                        {
                            case 0:
                                break;
                            case 1:
                                if (DD.Item != "フリガナ") DispSw = false;
                                break;
                            case 2:
                                if (DD.Item != "氏名") DispSw = false;
                                break;
                            case 3:
                                if (DD.Item != "郵便番号") DispSw = false;
                                break;
                            case 4:
                                if (DD.Item != "住所") DispSw = false;
                                break;
                            case 5:
                                if (DD.Item != "電話番号") DispSw = false;
                                break;
                            case 6:
                                if (DD.Item != "メールアドレス") DispSw = false;
                                break;
                            case 7:
                                if (DD.Item != "問１") DispSw = false;
                                break;
                            case 8:
                                if (DD.Item != "問２") DispSw = false;
                                break;
                            case 9:
                                if (DD.Item != "問３") DispSw = false;
                                break;
                            default:
                                DispSw = false;
                                break;
                        }
                        break;
                    case 1:
                        //顧客伝票修正
                        ////エラー種別
                        switch (CmbErrorType1.SelectedIndex)
                        {
                            case 0:
                                break;
                            case 1:
                                if (DD.ErrorType != "入力エラー") DispSw = false;
                                break;
                            case 2:
                                if (DD.ErrorType != "見落とし") DispSw = false;
                                break;
                            case 3:
                                if (DD.ErrorType != "過剰修正") DispSw = false;
                                break;
                            default:
                                DispSw = false;
                                break;
                        }
                        ////項目名
                        switch (CmbItemC.SelectedIndex)
                        {
                            case 0:
                                break;
                            case 1:
                                if (DD.Item != "顧客コード") DispSw = false;
                                break;
                            case 2:
                                if (DD.Item != "商品コード") DispSw = false;
                                break;
                            case 3:
                                if (DD.Item != "電話番号") DispSw = false;
                                break;
                            case 4:
                                if (DD.Item != "メールアドレス") DispSw = false;
                                break;
                            default:
                                DispSw = false;
                                break;
                        }
                        break;
                    case 2:
                        //顧客伝票ミスチェック
                        ////エラー種別
                        switch (CmbErrorType2.SelectedIndex)
                        {
                            case 0:
                                break;
                            case 1:
                                if (DD.ErrorType != "見落とし") DispSw = false;
                                break;
                            case 2:
                                if (DD.ErrorType != "過剰チェック") DispSw = false;
                                break;
                            default:
                                DispSw = false;
                                break;
                        }
                        ////項目名
                        switch (CmbItemC.SelectedIndex)
                        {
                            case 0:
                                break;
                            case 1:
                                if (DD.Item != "顧客コード") DispSw = false;
                                break;
                            case 2:
                                if (DD.Item != "商品コード") DispSw = false;
                                break;
                            case 3:
                                if (DD.Item != "電話番号") DispSw = false;
                                break;
                            case 4:
                                if (DD.Item != "メールアドレス") DispSw = false;
                                break;
                            default:
                                DispSw = false;
                                break;
                        }
                        break;
                }

                //文字種別
                if (DispSw)
                {
                    switch (CmbChar.SelectedIndex)
                    {
                        case 0:
                            break;
                        case 1:
                            if (DD.CharType != "カナ") DispSw = false;
                            break;
                        case 2:
                            if (DD.CharType != "漢字") DispSw = false;
                            break;
                        case 3:
                            if (DD.CharType != "数字") DispSw = false;
                            break;
                        case 4:
                            if (DD.CharType != "英大文字") DispSw = false;
                            break;
                        case 5:
                            if (DD.CharType != "英小文字") DispSw = false;
                            break;
                        case 6:
                            if (DD.CharType != "記号") DispSw = false;
                            break;
                        default:
                            DispSw = false;
                            break;
                    }
                }

                if (DispSw)
                {
                    DgvDetail.Rows.Add(WorkTimes
                                     , WorkDate
                                     , WorkTime
                                     , DD.CardNo.ToString("0000")
                                     , DD.Item
                                     , DD.ErrorType
                                     , DD.CharType
                                     , DD.CorrectChar
                                     , DD.ErrorChar
                                     , DD.WorkTime
                                      );
                }
            }

            LblCnt.Text = DgvDetail.Rows.Count.ToString("#,0");
            BtnSave.Enabled = (DgvDetail.Rows.Count > 0);
            BtnCompair.Enabled = (DgvDetail.Rows.Count > 0);

            return true;
        }

        /// <summary>
        //              アンケート入力チェック処理
        /// </summary>
        /// <param name="strCorrect">正解文字列</param>
        /// <param name="strInput">入力値文字列</param>
        /// <param name="ErrorData">CardErrorList</param>
        /// <param name="strInput">入力値文字列</param>
        private void CheckQuestion(string strCorrect, string strInput,
                                   エラー内容抽出データ ErrorData, ref List<エラー内容抽出データ> ErrorDetailList)
        {
            char ChkChar;
            エラー内容抽出データ ErrorDetailData;
            for (int i = 0; i < strInput.Length; i++)
            {
                ChkChar = strInput[i];
                if (i > strCorrect.Length - 1)
                {
                    ErrorDetailData = new エラー内容抽出データ();
                    ErrorDetailData.CardNo = ErrorData.CardNo;
                    ErrorDetailData.Item = ErrorData.Item;
                    ErrorDetailData.ErrorType = "";
                    ErrorDetailData.CharType = "記号等";
                    ErrorDetailData.CorrectChar = "";
                    ErrorDetailData.ErrorChar = ChkChar.ToString();
                    ErrorDetailData.WorkTime = ErrorData.WorkTime;
                    ErrorDetailList.Add(ErrorDetailData);
                }
                else if (strCorrect[i] != ChkChar)
                {
                    ErrorDetailData = new エラー内容抽出データ();
                    ErrorDetailData.CardNo = ErrorData.CardNo;
                    ErrorDetailData.Item = ErrorData.Item;
                    ErrorDetailData.ErrorType = "";
                    ErrorDetailData.CharType = CheckChar(strCorrect[i]);
                    ErrorDetailData.CorrectChar = strCorrect[i].ToString();
                    ErrorDetailData.ErrorChar = ChkChar.ToString();
                    ErrorDetailData.WorkTime = ErrorData.WorkTime;
                    ErrorDetailList.Add(ErrorDetailData);
                }
            }
            for (int i = strInput.Length; i < strCorrect.Length; i++)
            {
                ErrorDetailData = new エラー内容抽出データ();
                ErrorDetailData.CardNo = ErrorData.CardNo;
                ErrorDetailData.Item = ErrorData.Item;
                ErrorDetailData.ErrorType = "";
                ErrorDetailData.CharType = CheckChar(strCorrect[i]);
                ErrorDetailData.CorrectChar = strCorrect[i].ToString();
                ErrorDetailData.ErrorChar = "";
                ErrorDetailData.WorkTime = ErrorData.WorkTime;
                ErrorDetailList.Add(ErrorDetailData);
            }
        }

        /// <summary>
        //              顧客伝票修正チェック処理
        /// </summary>
        /// <param name="strCorrect">正解文字列</param>
        /// <param name="strError">エラー文字列</param>
        /// <param name="strInput">入力値文字列</param>
        /// <param name="ErrorData">CardErrorList</param>
        /// <param name="strInput">入力値文字列</param>
        private void CheckCustomer(string strCorrect, string strError, string strInput,
                                   エラー内容抽出データ ErrorData, ref List<エラー内容抽出データ> ErrorDetailList)
        {
            char ChkChar;
            エラー内容抽出データ ErrorDetailData;
            for (int i = 0; i < strInput.Length; i++)
            {
                ChkChar = strInput[i];
                if (i > strCorrect.Length - 1)
                {
                    ErrorDetailData = new エラー内容抽出データ();
                    ErrorDetailData.CardNo = ErrorData.CardNo;
                    ErrorDetailData.Item = ErrorData.Item;
                    ErrorDetailData.ErrorType = "過剰修正";
                    ErrorDetailData.CharType = "記号等";
                    ErrorDetailData.CorrectChar = "";
                    ErrorDetailData.ErrorChar = ChkChar.ToString();
                    ErrorDetailData.WorkTime = ErrorData.WorkTime;
                    ErrorDetailList.Add(ErrorDetailData);
                }
                else if (strCorrect[i] != ChkChar)
                {
                    ErrorDetailData = new エラー内容抽出データ();
                    ErrorDetailData.CardNo = ErrorData.CardNo;
                    ErrorDetailData.Item = ErrorData.Item;
                    if (strCorrect[i] == strError[i])
                    {
                        ErrorDetailData.ErrorType = "過剰修正";
                    }
                    else if (strError[i] == ChkChar)
                    {
                        ErrorDetailData.ErrorType = "見落とし";
                    }
                    else
                    {
                        ErrorDetailData.ErrorType = "入力エラー";
                    }
                    ErrorDetailData.CharType = CheckChar(strCorrect[i]);
                    ErrorDetailData.CorrectChar = strCorrect[i].ToString() + strError[i].ToString();
                    ErrorDetailData.ErrorChar = ChkChar.ToString();
                    ErrorDetailData.WorkTime = ErrorData.WorkTime;
                    ErrorDetailList.Add(ErrorDetailData);
                }
            }
            for (int i = strInput.Length; i < strCorrect.Length; i++)
            {
                ErrorDetailData = new エラー内容抽出データ();
                ErrorDetailData.CardNo = ErrorData.CardNo;
                ErrorDetailData.Item = ErrorData.Item;
                if (strCorrect[i] == strError[i])
                {
                    ErrorDetailData.ErrorType = "過剰修正";
                }
                else
                {
                    ErrorDetailData.ErrorType = "入力エラー";
                }
                ErrorDetailData.CharType = CheckChar(strCorrect[i]);
                ErrorDetailData.CorrectChar = strCorrect[i].ToString() + strError[i].ToString();
                ErrorDetailData.ErrorChar = "";
                ErrorDetailData.WorkTime = ErrorData.WorkTime;
                ErrorDetailList.Add(ErrorDetailData);
            }
        }

        /// <summary>
        //              顧客伝票ミスチェックチェック処理
        /// </summary>
        /// <param name="strCorrect">正解文字列</param>
        /// <param name="strError">エラー文字列</param>
        /// <param name="strInput">入力値文字列</param>
        /// <param name="ErrorData">CardErrorList</param>
        /// <param name="strInput">入力値文字列</param>
        private void CheckCustomerCheck(string strCorrect, string strError, string strInput,
                                        エラー内容抽出データ ErrorData, ref List<エラー内容抽出データ> ErrorDetailList)
        {
            char ChkChar;
            エラー内容抽出データ ErrorDetailData;
            for (int i = 0; i < strInput.Length; i++)
            {
                ChkChar = strInput[i];
                if (strCorrect[i] != strError[i])
                {
                    if (ChkChar == 'N')
                    {
                        ErrorDetailData = new エラー内容抽出データ();
                        ErrorDetailData.CardNo = ErrorData.CardNo;
                        ErrorDetailData.Item = ErrorData.Item;
                        ErrorDetailData.ErrorType = "見落とし";
                        ErrorDetailData.CharType = CheckChar(strCorrect[i]);
                        ErrorDetailData.CorrectChar = strCorrect[i].ToString();
                        ErrorDetailData.ErrorChar = strError[i].ToString();
                        ErrorDetailData.WorkTime = ErrorData.WorkTime;
                        ErrorDetailList.Add(ErrorDetailData);
                    }
                }
                else
                {
                    if (ChkChar == 'C')
                    {
                        ErrorDetailData = new エラー内容抽出データ();
                        ErrorDetailData.CardNo = ErrorData.CardNo;
                        ErrorDetailData.Item = ErrorData.Item;
                        ErrorDetailData.ErrorType = "過剰チェック";
                        ErrorDetailData.CharType = CheckChar(strCorrect[i]);
                        ErrorDetailData.CorrectChar = strCorrect[i].ToString();
                        ErrorDetailData.ErrorChar = strError[i].ToString();
                        ErrorDetailData.WorkTime = ErrorData.WorkTime;
                        ErrorDetailList.Add(ErrorDetailData);
                    }
                }
            }
        }

        /// <summary>
        //              文字チェック
        /// </summary>
        /// <param name="TargetChar">対象文字</param>
        /// <returns>文字種別</returns>
        private static string CheckChar(char TargetChar)
        {

            //カナ
            if (('\u30A1' <= TargetChar && TargetChar <= '\u30FA') ||
                ('\u30FC' <= TargetChar && TargetChar <= '\u30FF') ||
                ('\u31F0' <= TargetChar && TargetChar <= '\u31FF') ||
                ('\u3099' <= TargetChar && TargetChar <= '\u309C') ||
                ('\uFF66' <= TargetChar && TargetChar <= '\uFF9F'))
            {
                return "カナ";
            }
            //数字
            else if ('0' <= TargetChar && TargetChar <= '9')
            {
                return "数字";
            }
            //英大文字
            else if ('A' <= TargetChar && TargetChar <= 'Z')
            {
                return "英大文字";
            }
            //英小文字
            else if ('a' <= TargetChar && TargetChar <= 'z')
            {
                return "英小文字";
            }
            //記号等
            else if (char.IsSymbol(TargetChar))
            {
                return "記号等";
            }
            else if (TargetChar == '-' || TargetChar == '.' || TargetChar == ',' || TargetChar == '@')
            {
                return "記号等";
            }
            //漢字
            else
            {
                return "漢字";
            }

        }

        /// <summary>
        //              CSV出力
        /// </summary>
        /// <param name="FileName">出力ファイル(フルパス)</param>
        /// <returns>true:正常終了　false:異常終了</returns>
        private Boolean CreateCSV(string FileName)
        {
            try
            {
                //ファイル出力
                using (StreamWriter sw = new StreamWriter(FileName, false, Encoding.UTF8))
                {
                    sw.WriteLine("\"試行回\",\"実施日\",\"経過時間\",\"NO\",\"項目名\",\"エラー種類\",\"文字種\",\"正解文字\",\"誤り文字\"");


                    for (int row = 0; row < DgvDetail.Rows.Count; row++)
                    {
                        sw.WriteLine("\"" + DgvDetail.Rows[row].Cells[0].Value.ToString() + "\"," +
                                     "\"" + DgvDetail.Rows[row].Cells[1].Value.ToString() + "\"," +
                                     "\"" + DgvDetail.Rows[row].Cells[2].Value.ToString() + "\"," +
                                     "\"" + DgvDetail.Rows[row].Cells[3].Value.ToString() + "\"," +
                                     "\"" + DgvDetail.Rows[row].Cells[4].Value.ToString() + "\"," +
                                     "\"" + DgvDetail.Rows[row].Cells[5].Value.ToString() + "\"," +
                                     "\"" + DgvDetail.Rows[row].Cells[6].Value.ToString() + "\"," +
                                     "\"" + DgvDetail.Rows[row].Cells[7].Value.ToString() + "\"," +
                                     "\"" + DgvDetail.Rows[row].Cells[8].Value.ToString() + "\""
                                    );
                    }
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
        //              出力パス　更新処理
        /// </summary>
        /// <param name="FileName">出力ファイル(フルパス)</param>
        /// <returns>true:正常終了　false:異常終了</returns>
        private Boolean SetOutputPath(string FileName)
        {
            try
            {

                int cnt = 0;
                // SQL クエリ
                string sql = "";

                OutputDirString = System.IO.Path.GetDirectoryName(FileName);

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
                        sql = "UPDATE ユーザ比較設定データ"
                            + "   SET OutputPath = '" + OutputDirString + "',"
                            + "       UpdDate    = datetime('now', 'localtime') "
                            + " WHERE id = 1";
                    }
                    else
                    {
                        sql = "INSERT INTO  ユーザ比較設定データ Values(1," +
                                                                        "'" + OutputDirString + "'," +
                                                                        "''," +
                                                                        "0" + "," +
                                                                        "0" + "," +
                                                                        "0" + "," +
                                                                        "0" + "," +
                                                                        "datetime('now', 'localtime')," +
                                                                        "datetime('now', 'localtime')" +
                                                                      ")";
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

        /// <summary>
        //              マスタＤＢパスセット
        /// </summary>
        /// <param name="fPath">データベースフルパス</param>
        /// <returns>SQLiteデータベース名フルパス</returns>
        private string SetPathStringMst(string? fPath)
        {
            return fPath + @"\LetsTry04.mst";
        }

    }
}
