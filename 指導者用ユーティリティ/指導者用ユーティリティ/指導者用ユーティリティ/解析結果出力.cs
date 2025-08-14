using Microsoft.VisualBasic.FileIO;
using ScottPlot.MultiplotLayouts;
using System.Data.SQLite;
using System.Text;
using System.Windows;
using static 指導者用ユーティリティ.解析結果出力IF;

namespace 指導者用ユーティリティ
{
    public partial class Frm解析結果出力 : Form
    {
        //Tab表示制御
        private TabPageManager _tabPageManager;

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
        private List<解析結果出力IF.DetailData> ListDetailData = new List<DetailData>();
        private List<解析結果出力IF.MaxMinData> ListMaxMinData = new List<MaxMinData>();

        //入力値ファイル抽出データ
        public struct 入力値ファイル抽出データ
        {
            public string WorkTime = "";
            public int CardNo = 0;

            public 入力値ファイル抽出データ()
            {
            }
        }

        //解析結果ファイル抽出データ
        public struct 解析結果ファイル抽出データ
        {
            public string WorkTime = "";
            public int CardNo = 0;
            public int ErrorCount = 0;

            public 解析結果ファイル抽出データ()
            {
            }
        }

        //項目別文字種別集計値データ
        public struct 項目別文字種別集計値データ
        {
            public string WorkTime = "";
            public int CardNo = 0;
            public int[] ErrorCount = new int[9];

            public 項目別文字種別集計値データ()
            {
            }
        }

        //項目別明細データ
        public class ItemDetailData
        {
            public string WorkTimes = "";
            public string WorkDate = "";
            public int WorkTime = 0;
            public decimal NameKana = 0;
            public decimal NameKanji = 0;
            public decimal ZipCode = 0;
            public decimal Address = 0;
            public decimal TelNoQ = 0;
            public decimal MailAddrssQ = 0;
            public decimal Q1 = 0;
            public decimal Q2 = 0;
            public decimal Q3 = 0;
            public decimal CustCd = 0;
            public decimal ItemCd = 0;
            public decimal TelNoC = 0;
            public decimal MailAddrssC = 0;
            public ItemDetailData()
            {
            }
        }

        //文字種別明細データ
        public class CharDetailData
        {
            public string WorkTimes = "";
            public string WorkDate = "";
            public int WorkTime = 0;
            public decimal Kana = 0;
            public decimal Kanji = 0;
            public decimal Suuji = 0;
            public decimal OuEiji = 0;
            public decimal KoEiji = 0;
            public decimal Kigou = 0;
            public CharDetailData()
            {
            }
        }

        private List<ItemDetailData> ListItemData = new List<ItemDetailData>();
        private List<CharDetailData> ListCharData = new List<CharDetailData>();

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
        /// <param name="prmListDetail">解析結果出力IF</param>
        /// <param name="prmMaxMin">最高値最低値データ</param>
        public Frm解析結果出力(string prmUser, int prmMode, int prmCourse, string prmCourseNm,
                               List<解析結果出力IF.DetailData> prmListDetail, 解析結果出力IF.MaxMinData prmMaxMin)
        {
            InitializeComponent();

            //中央に配置する
            this.StartPosition = FormStartPosition.CenterScreen;

            //フォームの最小化ボタンの表示、非表示を切り替える
            this.MinimizeBox = !this.MinimizeBox;

            //フォームが最小化されないようにする
            this.MinimizeBox = false;

            //データグリッドビュー行挿入/削除　禁止
            DgvTotal.AllowUserToAddRows = false;
            DgvTotal.AllowUserToDeleteRows = false;
            DgvItem.AllowUserToAddRows = false;
            DgvItem.AllowUserToDeleteRows = false;
            DgvChar.AllowUserToAddRows = false;
            DgvChar.AllowUserToDeleteRows = false;

            //データグリッドビュー列の幅、行の高さの変更　禁止
            //DgvTotal.AllowUserToResizeColumns = false;
            DgvTotal.AllowUserToResizeRows = false;
            DgvItem.AllowUserToResizeRows = false;
            DgvChar.AllowUserToResizeRows = false;

            //データグリッドビュー罫線をなくす
            DgvTotal.CellBorderStyle = DataGridViewCellBorderStyle.None;
            DgvItem.CellBorderStyle = DataGridViewCellBorderStyle.None;
            DgvChar.CellBorderStyle = DataGridViewCellBorderStyle.None;

            //データグリッドビュー並べ替え　禁止
            foreach (DataGridViewColumn c in DgvTotal.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;
            foreach (DataGridViewColumn c in DgvItem.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;
            foreach (DataGridViewColumn c in DgvChar.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            //このフォームの最小サイズを設定する
            this.MinimumSize = new System.Drawing.Size(MiniWidth, MiniHeight);

            //引継ぎパラメータセット
            UserName = prmUser;
            Mode = prmMode;
            Course = prmCourse;
            CourseNm = prmCourseNm;
            foreach (解析結果出力IF.DetailData DetailData in prmListDetail)
            {
                ListDetailData.Add(DetailData);
            }

            ListMaxMinData.Add(prmMaxMin);
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

            //TabPageManagerオブジェクトの作成
            _tabPageManager = new TabPageManager(TclDetail);

            // 出力ファイルパス、初期表示位置取得
            GetSetting();

            if (CourseNm.Contains("60分換算"))
            {
                //項目別と文字種別の一覧は非表示
                _tabPageManager.ChangeTabPageVisible(1, false);
                _tabPageManager.ChangeTabPageVisible(2, false);
                CmbWorkTime.Enabled = false;
                BtnErrorDetail.Visible = false;
            }
            else
            {
                //項目別集計値一覧
                if (CourseNm.Contains("アンケート"))
                {
                    for (int i = 12; i < 16; i++)
                    {
                        DgvItem.Columns[i].Visible = false;
                    }
                }
                else
                {
                    for (int i = 3; i < 12; i++)
                    {
                        DgvItem.Columns[i].Visible = false;
                    }
                }
            }

            //集計値一覧
            if (CourseNm.Contains("基礎トレーニング"))
            {
                for (int i = 12; i < 19; i++)
                {
                    DgvTotal.Columns[i].Visible = false;
                }
            }

            //初期表示
            ////データ取得
            GetDetailData();

            ////経過時間を全体にする
            CmbWorkTime.SelectedIndex = 0;
        }

        /// <summary>
        //              Form　Resize
        /// </summary>
        private void Frm解析結果出力_Resize(object sender, EventArgs e)
        {
            LblCnt.Location = new System.Drawing.Point(this.Size.Width - 106, 88);
            LblCnt2.Location = new System.Drawing.Point(this.Size.Width - 50, 88);
            TclDetail.Size = new System.Drawing.Size(this.Size.Width - 58, this.Size.Height - 167);
            DgvTotal.Size = new System.Drawing.Size(this.Size.Width - 58, this.Size.Height - 199);
            DgvItem.Size = new System.Drawing.Size(this.Size.Width - 58, this.Size.Height - 199);
            DgvChar.Size = new System.Drawing.Size(this.Size.Width - 58, this.Size.Height - 199);
            LblComment.Location = new System.Drawing.Point(24, this.Size.Height - 71);
            BtnErrorDetail.Location = new System.Drawing.Point(this.Size.Width - 290, this.Size.Height - 79);
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
        //              経過時間　SelectedIndexChanged
        /// </summary>
        private void CmbWorkTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            //各集計値一覧表示
            DispDetail();
        }

        /// <summary>
        //              エラー内容の表示　Click
        /// </summary>
        private void BtnErrorDetail_Click(object sender, EventArgs e)
        {
            BtnCancel.Enabled = false;

            //非表示する
            this.Visible = false;

            int idx = 0;

            switch (TclDetail.SelectedIndex)
            {
                case 0:
                    idx = DgvTotal.CurrentRow.Index;
                    break;
                case 1:
                    idx = DgvItem.CurrentRow.Index;
                    break;
                case 2:
                    idx = DgvChar.CurrentRow.Index;
                    break;
            }

            Frmエラー内容表示 frm = new Frmエラー内容表示(UserName, Mode, Course, CourseNm, ListDetailData[idx].WorkTimes, CmbWorkTime.Text,
                                                          ListDetailData[idx].WorkDate, ListDetailData[idx].FileNameI,
                                                          ListDetailData[idx].FileNameR);
            frm.ShowDialog();

            BtnCancel.Enabled = true;

            //表示する
            this.Visible = true;

            // 出力ファイルパス、初期表示位置取得
            GetSetting();
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
        //              集計値一覧　CellClick
        /// </summary>
        private void DgvTotal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                //ヘッダークリックは無視する
            }
            else
            {
                DgvTotal.CurrentRow.Cells[0].Selected = true;
            }
        }

        /// <summary>
        //              集計値一覧　DoubleClick
        /// </summary>
        private void DgvTotal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                //ヘッダークリックは無視する
            }
            else
            {
                DgvTotal.CurrentRow.Cells[0].Selected = true;
                BtnErrorDetail.PerformClick();
            }
        }

        /// <summary>
        //              集計値一覧　KeyDown
        /// </summary>
        private void DgvTotal_KeyDown(object sender, KeyEventArgs e)
        {
            //Tab Key
            if (e.KeyCode == Keys.Tab)
            {
                //フォーカス移動
                BtnErrorDetail.Focus();
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
        //              項目別集計値一覧　CellClick
        /// </summary>
        private void DgvItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                //ヘッダークリックは無視する
            }
            else
            {
                DgvItem.CurrentRow.Cells[0].Selected = true;
            }
        }

        /// <summary>
        //              項目別集計値一覧　DoubleClick
        /// </summary>
        private void DgvItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                //ヘッダークリックは無視する
            }
            else
            {
                DgvItem.CurrentRow.Cells[0].Selected = true;
                BtnErrorDetail.PerformClick();
            }
        }

        /// <summary>
        //              項目別集計値一覧　KeyDown
        /// </summary>
        private void DgvItem_KeyDown(object sender, KeyEventArgs e)
        {
            //Tab Key
            if (e.KeyCode == Keys.Tab)
            {
                //フォーカス移動
                BtnErrorDetail.Focus();
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
        //              文字種別集計値一覧　CellClick
        /// </summary>
        private void DgvChar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                //ヘッダークリックは無視する
            }
            else
            {
                DgvChar.CurrentRow.Cells[0].Selected = true;
            }
        }

        /// <summary>
        //              文字種別集計値一覧　DoubleClick
        /// </summary>
        private void DgvChar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                //ヘッダークリックは無視する
            }
            else
            {
                DgvChar.CurrentRow.Cells[0].Selected = true;
                BtnErrorDetail.PerformClick();
            }
        }

        /// <summary>
        //              文字種別集計値一覧　KeyDown
        /// </summary>
        private void DgvChar_KeyDown(object sender, KeyEventArgs e)
        {
            //Tab Key
            if (e.KeyCode == Keys.Tab)
            {
                //フォーカス移動
                BtnErrorDetail.Focus();
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

        //              解析結果出力　一覧取得処理
        /// </summary>
        /// <returns>true:正常終了　false:異常終了</returns>
        private Boolean GetDetailData()
        {
            try
            {
                List<解析結果出力IF.DetailData> addDetailData = new List<DetailData>();
                DetailData wkDD;
                ItemDetailData wkID;
                CharDetailData wkCD;
                MaxMinData wkMD;
                ItemDetailData TotalID;
                CharDetailData TotalCD;

                foreach (解析結果出力IF.DetailData DD in ListDetailData)
                {
                    List<入力値ファイル抽出データ> ListInput = new List<入力値ファイル抽出データ>();
                    List<解析結果ファイル抽出データ> ListResult = new List<解析結果ファイル抽出データ>();
                    List<項目別文字種別集計値データ> ListItem = new List<項目別文字種別集計値データ>();
                    List<項目別文字種別集計値データ> ListChar = new List<項目別文字種別集計値データ>();

                    wkDD = new DetailData();
                    wkID = new ItemDetailData();
                    wkCD = new CharDetailData();
                    wkMD = new MaxMinData();
                    TotalID = new ItemDetailData();
                    TotalCD = new CharDetailData();

                    //入力値ファイル取得
                    if (!File.Exists(DD.FileNameI))
                    {
                        System.Windows.Forms.MessageBox.Show("システム環境に問題があります。(File Not Found(" + DD.FileNameI + "))", "エラー");
                        //終了
                        this.Dispose();
                        this.Close();
                        return false;
                    }

                    using (TextFieldParser txtParser = new TextFieldParser(DD.FileNameI))
                    {
                        txtParser.SetDelimiters(",");

                        入力値ファイル抽出データ inputData = new 入力値ファイル抽出データ();

                        while (!txtParser.EndOfData)
                        {
                            string[]? values = txtParser.ReadFields();
                            int CellCount = 0;
                            foreach (string value in values)
                            {
                                if (value == "開始時刻") break;

                                switch (CellCount)
                                {
                                    case 2:
                                        inputData.WorkTime = value;
                                        break;
                                    case 4:
                                        inputData.CardNo = int.Parse(value);
                                        ListInput.Add(inputData);
                                        break;
                                }
                                CellCount++;
                            }
                        }
                    }

                    //解析結果ファイル取得
                    if (!File.Exists(DD.FileNameR))
                    {
                        System.Windows.Forms.MessageBox.Show("システム環境に問題があります。(File Not Found(" + DD.FileNameR + "))", "エラー");
                        //終了
                        this.Dispose();
                        this.Close();
                        return false;
                    }

                    using (TextFieldParser txtParser = new TextFieldParser(DD.FileNameR))
                    {
                        txtParser.SetDelimiters(",");

                        解析結果ファイル抽出データ ResultData = new 解析結果ファイル抽出データ();
                        項目別文字種別集計値データ ItemData = new 項目別文字種別集計値データ();
                        項目別文字種別集計値データ CharData = new 項目別文字種別集計値データ();
                        Boolean ItemSw = false;
                        Boolean CharSw = false;

                        while (!txtParser.EndOfData)
                        {
                            string[]? values = txtParser.ReadFields();
                            int CellCountItem = 0;
                            int CellCountChar = 0;

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
                                if (value == "■文字種別エラー一覧")
                                {
                                    ItemSw = false;
                                    CharSw = true;
                                }

                                //項目別エラー一覧
                                if (ItemSw)
                                {
                                    switch (CellCountItem)
                                    {
                                        case 1:
                                            ResultData.CardNo = int.Parse(value);
                                            ItemData.CardNo = int.Parse(value);
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
                                                ResultData.ErrorCount++;
                                                ItemData.ErrorCount[CellCountItem - 2]++;
                                            }
                                            break;
                                        case 6:
                                            if (Mode == 0)
                                            {
                                                if (value == "×")
                                                {
                                                    ResultData.ErrorCount++;
                                                    ItemData.ErrorCount[CellCountItem - 2]++;
                                                }

                                            }
                                            else
                                            {
                                                ResultData.WorkTime = value;
                                                ItemData.WorkTime = value;
                                                ListResult.Add(ResultData);
                                                ListItem.Add(ItemData);
                                                ResultData = new 解析結果ファイル抽出データ();
                                                ItemData = new 項目別文字種別集計値データ();
                                            }
                                            break;
                                        case 11:
                                            ResultData.WorkTime = value;
                                            ItemData.WorkTime = value;
                                            ListResult.Add(ResultData);
                                            ListItem.Add(ItemData);
                                            ResultData = new 解析結果ファイル抽出データ();
                                            ItemData = new 項目別文字種別集計値データ();
                                            break;
                                    }
                                    CellCountItem++;
                                }

                                if (CharSw)
                                {
                                    switch (CellCountChar)
                                    {
                                        case 1:
                                            CharData.CardNo = int.Parse(value);
                                            break;
                                        case 2:
                                        case 3:
                                        case 4:
                                        case 5:
                                        case 6:
                                        case 7:
                                            if (value == "×") CharData.ErrorCount[CellCountChar - 2]++;
                                            break;
                                        case 8:
                                            CharData.WorkTime = value;
                                            ListChar.Add(CharData);
                                            CharData = new 項目別文字種別集計値データ();
                                            break;
                                    }
                                    CellCountChar++;
                                }

                            }
                        }
                    }

                    //経過時間単位のListDetailData/ListItemData/ListCharData編集
                    int wkWorkTime = 0;
                    int ResultIdx = 0;

                    foreach (入力値ファイル抽出データ ID in ListInput)
                    {
                        if ((ID.WorkTime.CompareTo("00分00秒") >= 0) && (ID.WorkTime.CompareTo("15分00秒") < 0))
                        {
                            wkWorkTime = 1;
                        }
                        else if ((ID.WorkTime.CompareTo("15分00秒") >= 0) && (ID.WorkTime.CompareTo("30分00秒") < 0))
                        {
                            wkWorkTime = 2;
                        }
                        else if ((ID.WorkTime.CompareTo("30分00秒") >= 0) && (ID.WorkTime.CompareTo("45分00秒") < 0))
                        {
                            wkWorkTime = 3;
                        }
                        else
                        {
                            wkWorkTime = 4;
                        }

                        if (wkWorkTime != wkDD.WorkTime)
                        {
                            //編集中の行をリストアップ
                            if (wkDD.WorkTime > 0)
                            {
                                //////ListDetailData
                                wkDD.CorrectMaisu = wkDD.WorkMaisu - wkDD.ErrorMaisu;
                                wkDD.CorrectRate = Math.Round((wkDD.CorrectMaisu / wkDD.WorkMaisu) * 100, 1, MidpointRounding.AwayFromZero);
                                wkDD.WorkItem = (Mode == 0) ? wkDD.WorkMaisu * 9 : wkDD.WorkMaisu * 4;
                                wkDD.CorrectItem = wkDD.WorkItem - wkDD.ErrorItem;
                                wkDD.CorrectItemRate = Math.Round((wkDD.CorrectItem / wkDD.WorkItem) * 100, 1, MidpointRounding.AwayFromZero);
                                addDetailData.Add(wkDD);
                                //////ListItemData
                                TotalID.NameKana = TotalID.NameKana + wkID.NameKana;
                                TotalID.NameKanji = TotalID.NameKanji + wkID.NameKanji;
                                TotalID.ZipCode = TotalID.ZipCode + wkID.ZipCode;
                                TotalID.Address = TotalID.Address + wkID.Address;
                                TotalID.TelNoQ = TotalID.TelNoQ + wkID.TelNoQ;
                                TotalID.MailAddrssQ = TotalID.MailAddrssQ + wkID.MailAddrssQ;
                                TotalID.Q1 = TotalID.Q1 + wkID.Q1;
                                TotalID.Q2 = TotalID.Q2 + wkID.Q2;
                                TotalID.Q3 = TotalID.Q3 + wkID.Q3;
                                TotalID.CustCd = TotalID.CustCd + wkID.CustCd;
                                TotalID.ItemCd = TotalID.ItemCd + wkID.ItemCd;
                                TotalID.TelNoC = TotalID.TelNoC + wkID.TelNoC;
                                TotalID.MailAddrssC = TotalID.MailAddrssC + wkID.MailAddrssC;
                                ListItemData.Add(wkID);
                                //////ListCharData
                                TotalCD.Kana = TotalCD.Kana + wkCD.Kana;
                                TotalCD.Kanji = TotalCD.Kanji + wkCD.Kanji;
                                TotalCD.Suuji = TotalCD.Suuji + wkCD.Suuji;
                                TotalCD.OuEiji = TotalCD.OuEiji + wkCD.OuEiji;
                                TotalCD.KoEiji = TotalCD.KoEiji + wkCD.KoEiji;
                                TotalCD.Kigou = TotalCD.Kigou + wkCD.Kigou;
                                ListCharData.Add(wkCD);
                            }
                            //該当なしの経過時間帯のデータをリストアップ
                            for (int i = wkDD.WorkTime + 1; i < wkWorkTime; i++)
                            {
                                //////ListDetailData
                                wkDD = new DetailData();
                                wkDD.WorkTimes = DD.WorkTimes;
                                wkDD.Course = DD.Course;
                                wkDD.WorkDate = DD.WorkDate;
                                wkDD.WorkTime = i;
                                wkDD.FileNameI = DD.FileNameI;
                                wkDD.FileNameR = DD.FileNameR;
                                addDetailData.Add(wkDD);
                                //////ListItemData
                                wkID = new ItemDetailData();
                                wkID.WorkTimes = DD.WorkTimes;
                                wkID.WorkDate = DD.WorkDate;
                                wkID.WorkTime = wkWorkTime;
                                wkID.WorkTime = i;
                                ListItemData.Add(wkID);
                                //////ListCharData
                                wkCD = new CharDetailData();
                                wkCD.WorkTimes = DD.WorkTimes;
                                wkCD.WorkDate = DD.WorkDate;
                                wkCD.WorkTime = wkWorkTime;
                                wkCD.WorkTime = i;
                                ListCharData.Add(wkCD);
                            }
                            //取得行の編集
                            //////ListDetailData
                            wkDD = new DetailData();
                            wkDD.WorkTimes = DD.WorkTimes;
                            wkDD.Course = DD.Course;
                            wkDD.WorkDate = DD.WorkDate;
                            wkDD.WorkTime = wkWorkTime;
                            wkDD.WorkMaisu++;
                            wkDD.FileNameI = DD.FileNameI;
                            wkDD.FileNameR = DD.FileNameR;
                            //////ListItemData
                            wkID = new ItemDetailData();
                            wkID.WorkTimes = DD.WorkTimes;
                            wkID.WorkDate = DD.WorkDate;
                            wkID.WorkTime = wkWorkTime;
                            //////ListCharData
                            wkCD = new CharDetailData();
                            wkCD.WorkTimes = DD.WorkTimes;
                            wkCD.WorkDate = DD.WorkDate;
                            wkCD.WorkTime = wkWorkTime;
                        }
                        else
                        {
                            wkDD.WorkMaisu++;
                        }
                        //エラー件数の取得
                        if (ListResult.Count > ResultIdx)
                        {
                            if (ListResult[ResultIdx].WorkTime.CompareTo(ID.WorkTime) == 0)
                            {
                                if (ListResult[ResultIdx].CardNo == ID.CardNo)
                                {
                                    //////ListDetailData
                                    wkDD.ErrorMaisu++;
                                    wkDD.ErrorItem = wkDD.ErrorItem + ListResult[ResultIdx].ErrorCount;
                                    //////ListItemData
                                    if (Mode == 0)
                                    {
                                        wkID.NameKana = wkID.NameKana + ListItem[ResultIdx].ErrorCount[0];
                                        wkID.NameKanji = wkID.NameKanji + ListItem[ResultIdx].ErrorCount[1];
                                        wkID.ZipCode = wkID.ZipCode + ListItem[ResultIdx].ErrorCount[2];
                                        wkID.Address = wkID.Address + ListItem[ResultIdx].ErrorCount[3];
                                        wkID.TelNoQ = wkID.TelNoQ + ListItem[ResultIdx].ErrorCount[4];
                                        wkID.MailAddrssQ = wkID.MailAddrssQ + ListItem[ResultIdx].ErrorCount[5];
                                        wkID.Q1 = wkID.Q1 + ListItem[ResultIdx].ErrorCount[6];
                                        wkID.Q2 = wkID.Q2 + ListItem[ResultIdx].ErrorCount[7];
                                        wkID.Q3 = wkID.Q3 + ListItem[ResultIdx].ErrorCount[8];
                                    }
                                    else
                                    {
                                        wkID.CustCd = wkID.CustCd + ListItem[ResultIdx].ErrorCount[0];
                                        wkID.ItemCd = wkID.NameKana + ListItem[ResultIdx].ErrorCount[1];
                                        wkID.TelNoC = wkID.TelNoC + ListItem[ResultIdx].ErrorCount[2];
                                        wkID.MailAddrssC = wkID.MailAddrssC + ListItem[ResultIdx].ErrorCount[3];
                                    }
                                    //////ListCharData
                                    wkCD.Kana = wkCD.Kana + ListChar[ResultIdx].ErrorCount[0];
                                    wkCD.Kanji = wkCD.Kanji + ListChar[ResultIdx].ErrorCount[1];
                                    wkCD.Suuji = wkCD.Suuji + ListChar[ResultIdx].ErrorCount[2];
                                    wkCD.OuEiji = wkCD.OuEiji + ListChar[ResultIdx].ErrorCount[3];
                                    wkCD.KoEiji = wkCD.KoEiji + ListChar[ResultIdx].ErrorCount[4];
                                    wkCD.Kigou = wkCD.Kigou + ListChar[ResultIdx].ErrorCount[5];

                                    ResultIdx++;
                                }
                            }
                        }
                    }

                    ////編集中の行をリストアップ
                    if (wkDD.WorkTime > 0)
                    {
                        //////ListDetailData
                        wkDD.CorrectMaisu = wkDD.WorkMaisu - wkDD.ErrorMaisu;
                        wkDD.CorrectRate = Math.Round((wkDD.CorrectMaisu / wkDD.WorkMaisu) * 100, 1, MidpointRounding.AwayFromZero);
                        wkDD.WorkItem = (Mode == 0) ? wkDD.WorkMaisu * 9 : wkDD.WorkMaisu * 4;
                        wkDD.CorrectItem = wkDD.WorkItem - wkDD.ErrorItem;
                        wkDD.CorrectItemRate = Math.Round((wkDD.CorrectItem / wkDD.WorkItem) * 100, 1, MidpointRounding.AwayFromZero);
                        addDetailData.Add(wkDD);
                        //////ListItemData
                        TotalID.NameKana = TotalID.NameKana + wkID.NameKana;
                        TotalID.NameKanji = TotalID.NameKanji + wkID.NameKanji;
                        TotalID.ZipCode = TotalID.ZipCode + wkID.ZipCode;
                        TotalID.Address = TotalID.Address + wkID.Address;
                        TotalID.TelNoQ = TotalID.TelNoQ + wkID.TelNoQ;
                        TotalID.MailAddrssQ = TotalID.MailAddrssQ + wkID.MailAddrssQ;
                        TotalID.Q1 = TotalID.Q1 + wkID.Q1;
                        TotalID.Q2 = TotalID.Q2 + wkID.Q2;
                        TotalID.Q3 = TotalID.Q3 + wkID.Q3;
                        TotalID.CustCd = TotalID.CustCd + wkID.CustCd;
                        TotalID.ItemCd = TotalID.ItemCd + wkID.ItemCd;
                        TotalID.TelNoC = TotalID.TelNoC + wkID.TelNoC;
                        TotalID.MailAddrssC = TotalID.MailAddrssC + wkID.MailAddrssC;
                        ListItemData.Add(wkID);
                        //////ListCharData
                        TotalCD.Kana = TotalCD.Kana + wkCD.Kana;
                        TotalCD.Kanji = TotalCD.Kanji + wkCD.Kanji;
                        TotalCD.Suuji = TotalCD.Suuji + wkCD.Suuji;
                        TotalCD.OuEiji = TotalCD.OuEiji + wkCD.OuEiji;
                        TotalCD.KoEiji = TotalCD.KoEiji + wkCD.KoEiji;
                        TotalCD.Kigou = TotalCD.Kigou + wkCD.Kigou;
                        ListCharData.Add(wkCD);
                    }
                    ////該当なしの経過時間帯のデータをリストアップ
                    for (int i = wkDD.WorkTime + 1; i < 5; i++)
                    {
                        //////ListDetailData
                        wkDD = new DetailData();
                        wkDD.WorkTimes = DD.WorkTimes;
                        wkDD.Course = DD.Course;
                        wkDD.WorkDate = DD.WorkDate;
                        wkDD.WorkTime = i;
                        wkDD.FileNameI = DD.FileNameI;
                        wkDD.FileNameR = DD.FileNameR;
                        addDetailData.Add(wkDD);
                        //////ListItemData
                        wkID = new ItemDetailData();
                        wkID.WorkTimes = DD.WorkTimes;
                        wkID.WorkDate = DD.WorkDate;
                        wkID.WorkTime = wkWorkTime;
                        wkID.WorkTime = i;
                        ListItemData.Add(wkID);
                        //////ListCharData
                        wkCD = new CharDetailData();
                        wkCD.WorkTimes = DD.WorkTimes;
                        wkCD.WorkDate = DD.WorkDate;
                        wkCD.WorkTime = wkWorkTime;
                        wkCD.WorkTime = i;
                        ListCharData.Add(wkCD);
                    }

                    //全体のListItemData/ListCharData出力
                    //////ListItemData
                    TotalID.WorkTimes = DD.WorkTimes;
                    TotalID.WorkDate = DD.WorkDate;
                    TotalID.WorkTime = wkWorkTime;
                    TotalID.WorkTime = 0;
                    ListItemData.Add(TotalID);

                    //////ListCharData
                    TotalCD.WorkTimes = DD.WorkTimes;
                    TotalCD.WorkDate = DD.WorkDate;
                    TotalCD.WorkTime = wkWorkTime;
                    TotalCD.WorkTime = 0;
                    ListCharData.Add(TotalCD);
                }

                //経過時間単位のListMaxMinData編集
                ////4つの時間帯のリストを作成する
                for (int i = 0; i < 4; i++)
                {
                    wkMD = new MaxMinData();
                    ListMaxMinData.Add(wkMD);
                }
                ////addDetailDataから最大値と最低値をセットする
                foreach (DetailData DD in addDetailData)
                {
                    if (ListMaxMinData[DD.WorkTime].WorkTime == 0)
                    {
                        ListMaxMinData[DD.WorkTime].WorkTime = DD.WorkTime;
                        ListMaxMinData[DD.WorkTime].MaxMaisu = DD.WorkMaisu;
                        ListMaxMinData[DD.WorkTime].MinMaisu = DD.WorkMaisu;
                        ListMaxMinData[DD.WorkTime].MaxRate = DD.CorrectRate;
                        ListMaxMinData[DD.WorkTime].MinRate = DD.CorrectRate;
                        ListMaxMinData[DD.WorkTime].MaxKoumoku = DD.WorkItem;
                        ListMaxMinData[DD.WorkTime].MinKoumoku = DD.WorkItem;
                        ListMaxMinData[DD.WorkTime].MaxKoumokuRate = DD.CorrectItemRate;
                        ListMaxMinData[DD.WorkTime].MinKoumokuRate = DD.CorrectItemRate;
                    }
                    else
                    {
                        if (ListMaxMinData[DD.WorkTime].MaxMaisu < DD.WorkMaisu) ListMaxMinData[DD.WorkTime].MaxMaisu = DD.WorkMaisu;
                        if (ListMaxMinData[DD.WorkTime].MinMaisu > DD.WorkMaisu) ListMaxMinData[DD.WorkTime].MinMaisu = DD.WorkMaisu;
                        if (ListMaxMinData[DD.WorkTime].MaxRate < DD.CorrectRate) ListMaxMinData[DD.WorkTime].MaxRate = DD.CorrectRate;
                        if (ListMaxMinData[DD.WorkTime].MinRate > DD.CorrectRate) ListMaxMinData[DD.WorkTime].MinRate = DD.CorrectRate;
                        if (ListMaxMinData[DD.WorkTime].MaxKoumoku < DD.WorkItem) ListMaxMinData[DD.WorkTime].MaxKoumoku = DD.WorkItem;
                        if (ListMaxMinData[DD.WorkTime].MinKoumoku > DD.WorkItem) ListMaxMinData[DD.WorkTime].MinKoumoku = DD.WorkItem;
                        if (ListMaxMinData[DD.WorkTime].MaxKoumokuRate < DD.CorrectItemRate) ListMaxMinData[DD.WorkTime].MaxKoumokuRate = DD.CorrectItemRate;
                        if (ListMaxMinData[DD.WorkTime].MinKoumokuRate > DD.CorrectItemRate) ListMaxMinData[DD.WorkTime].MinKoumokuRate = DD.CorrectItemRate;
                    }

                    //ListDetailDataにaddDetailDataを追加
                    ListDetailData.Add(DD);
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

        //              解析結果出力　一覧表示処理
        /// </summary>
        /// <returns>true:正常終了　false:異常終了</returns>
        private Boolean DispDetail()
        {
            //集計値一覧
            DgvTotal.Rows.Clear();

            foreach (DetailData DD in ListDetailData)
            {
                if (DD.WorkTime == CmbWorkTime.SelectedIndex)
                {
                    DgvTotal.Rows.Add(DD.WorkTimes
                                    , DD.Course
                                    , DD.WorkDate
                                    , CmbWorkTime.Text
                                    , DD.WorkMaisu + "枚"
                                    , DD.CorrectMaisu + "枚"
                                    , DD.ErrorMaisu + "枚"
                                    , DD.CorrectRate + "%"
                                    , DD.WorkItem
                                    , DD.CorrectItem
                                    , DD.ErrorItem
                                    , DD.CorrectItemRate + "%"
                                    , ((ListMaxMinData[DD.WorkTime].MaxMaisu == DD.WorkMaisu) ? "〇" : "")
                                    , ((ListMaxMinData[DD.WorkTime].MaxRate == DD.CorrectRate) ? "〇" : "")
                                    , ((ListMaxMinData[DD.WorkTime].MinMaisu == DD.WorkMaisu) ? "●" : "")
                                    , ((ListMaxMinData[DD.WorkTime].MinRate == DD.CorrectRate) ? "●" : "")
                                    , ((ListMaxMinData[DD.WorkTime].MaxKoumoku == DD.WorkItem) ? "〇" : "")
                                    , ((ListMaxMinData[DD.WorkTime].MaxKoumokuRate == DD.CorrectItemRate) ? "〇" : "")
                                    , ((ListMaxMinData[DD.WorkTime].MinKoumoku == DD.WorkItem) ? "●" : "")
                                    , ((ListMaxMinData[DD.WorkTime].MinKoumokuRate == DD.CorrectItemRate) ? "●" : "")
                                      );
                }
            }

            //項目別集計値一覧
            DgvItem.Rows.Clear();

            foreach (ItemDetailData ID in ListItemData)
            {
                if (ID.WorkTime == CmbWorkTime.SelectedIndex)
                {
                    DgvItem.Rows.Add(ID.WorkTimes
                                   , ID.WorkDate
                                   , CmbWorkTime.Text
                                   , ID.NameKana + "枚"
                                   , ID.NameKanji + "枚"
                                   , ID.ZipCode + "枚"
                                   , ID.Address + "枚"
                                   , ID.TelNoQ + "枚"
                                   , ID.MailAddrssQ + "枚"
                                   , ID.Q1 + "枚"
                                   , ID.Q2 + "枚"
                                   , ID.Q3 + "枚"
                                   , ID.CustCd + "枚"
                                   , ID.ItemCd + "枚"
                                   , ID.TelNoC + "枚"
                                   , ID.MailAddrssC + "枚"
                                     );
                }
            }

            //文字種別集計値一覧
            DgvChar.Rows.Clear();

            foreach (CharDetailData CD in ListCharData)
            {
                if (CD.WorkTime == CmbWorkTime.SelectedIndex)
                {
                    DgvChar.Rows.Add(CD.WorkTimes
                                   , CD.WorkDate
                                   , CmbWorkTime.Text
                                   , CD.Kana + "枚"
                                   , CD.Kanji + "枚"
                                   , CD.Suuji + "枚"
                                   , CD.OuEiji + "枚"
                                   , CD.KoEiji + "枚"
                                   , CD.Kigou + "枚"
                                     );
                }
            }

            LblCnt.Text = DgvTotal.Rows.Count.ToString("#,0");
            BtnErrorDetail.Enabled = (DgvTotal.Rows.Count > 0);

            return true;
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
