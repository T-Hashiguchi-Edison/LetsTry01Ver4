using System.Data.SQLite;
using System.Text;
using System.Windows;

namespace 指導者用ユーティリティ
{
    public partial class Frmユーザ比較 : Form
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

        //最小化フォームサイズ(幅567、高さ543)
        private int MiniWidth = 567;
        private int MiniHeight = 543;

        //各種ワーク項目
        public struct 順位ワーク
        {
            public int id = 0;
            public string UserName = "";
            public decimal MaxValue = 0;
            public int Rank = 0;

            public 順位ワーク()
            {
            }
        }

        public struct その他ワーク
        {
            public int id = 0;
            public int WorkCount = 0;
            public decimal CorrectRate = 0;
            public string WorkTime = "";

            public その他ワーク()
            {
            }
        }

        public struct ユーザ比較データ
        {
            public int id = 0;
            public int TotalRank = 0;
            public string UserName = "";
            public int WorkRank = 0;
            public string WorkTime = "";
            public int WorkNumber = 0;
            public int WorkCount = 0;
            public decimal WorkCorrectRate = 0;
            public int CorrectRank = 0;
            public string CorrectTime = "";
            public int CorrectNumber = 0;
            public int CorrectCount = 0;
            public decimal CorrectRate = 0;
            public string Last3timeWorkCount = "";
            public string Last3timeCorrectRate = "";
            public int TotalNumber = 0;

            public ユーザ比較データ()
            {
            }
        }

        /// <summary>
        //              ユーザ比較
        /// </summary>
        public Frmユーザ比較()
        {
            InitializeComponent();

            //中央に配置する
            this.StartPosition = FormStartPosition.CenterScreen;

            //フォームの最小化ボタンの表示、非表示を切り替える
            this.MinimizeBox = !this.MinimizeBox;

            //フォームが最小化されないようにする
            this.MinimizeBox = false;

            //データグリッドビュー行挿入/削除　禁止
            DgvComp.AllowUserToAddRows = false;
            DgvComp.AllowUserToDeleteRows = false;

            //データグリッドビュー列の幅、行の高さの変更　禁止
            //DgvComp.AllowUserToResizeColumns = false;
            DgvComp.AllowUserToResizeRows = false;

            //データグリッドビュー罫線をなくす
            DgvComp.CellBorderStyle = DataGridViewCellBorderStyle.None;

            //データグリッドビュー並べ替え　禁止
            foreach (DataGridViewColumn c in DgvComp.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            //このフォームの最小サイズを設定する
            this.MinimumSize = new System.Drawing.Size(MiniWidth, MiniHeight);

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
                CmbCourse.Focus();
            }
            //［Alt］+［E］が押されたらキャッチ(解析レベル)
            if (keyData == (Keys.E | Keys.Alt))
            {
                CmbLevel.Focus();
            }
            //［Alt］+［S］が押されたらキャッチ(ユーザー比較)
            if (keyData == (Keys.S | Keys.Alt))
            {
                BtnSave.PerformClick();
            }

            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        //              Form　Load 
        /// </summary>
        private void Frmユーザ比較_Load(object sender, EventArgs e)
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
            CmbCourse.SelectedIndex = 0;
            CmbLevel.SelectedIndex = 0;

        }

        /// <summary>
        //              Form　Resize 
        /// </summary>
        private void Frmユーザ比較_Resize(object sender, EventArgs e)
        {
            LblCnt.Location = new System.Drawing.Point(this.Size.Width - 103, 32);
            LblCnt2.Location = new System.Drawing.Point(this.Size.Width - 47, 32);
            DgvComp.Size = new System.Drawing.Size(this.Size.Width - 55, this.Size.Height - 143);
            BtnSave.Location = new System.Drawing.Point(24, this.Size.Height - 79);
            LblComment.Location = new System.Drawing.Point(120, this.Size.Height - 71);
            BtnCancel.Location = new System.Drawing.Point(this.Size.Width - 135, this.Size.Height - 79);
        }

        /// <summary>
        //              Form　Closing 
        /// </summary>
        private void Frmユーザ比較_FormClosing(object sender, FormClosingEventArgs e)
        {
            SetFormInfo();
        }

        /// <summary>
        //              保存　Click
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
        private void DgvComp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                //ヘッダークリックは無視する
            }
            else
            {
                DgvComp.CurrentRow.Cells[1].Selected = true;
            }
        }

        /// <summary>
        //              一覧　CellDoubleClick
        /// </summary>
        private void DgvComp_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                //ヘッダークリックは無視する
            }
            else
            {
                DgvComp.CurrentRow.Cells[1].Selected = true;
            }
        }
        /// <summary>
        //              一覧　KeyDown
        /// </summary>
        private void DgvComp_KeyDown(object sender, KeyEventArgs e)
        {
            //Tab Key
            if (e.KeyCode == Keys.Tab)
            {
                //フォーカス移動
                BtnSave.Focus();
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
        private void CmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            //データ取得
            GetUserCompData();
        }

        /// <summary>
        //              解析レベル　SelectedIndexChanged
        /// </summary>
        private void CmbLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            //データ取得
            GetUserCompData();

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

        //              ユーザ比較データ　一覧取得処理
        /// </summary>
        /// <returns>true:正常終了　false:異常終了</returns>
        private Boolean GetUserCompData()
        {

            //課題、解析レベルが選択されていない場合は抜ける。
            if ((CmbCourse.SelectedIndex < 0) || (CmbLevel.SelectedIndex < 0)) return true;

            try
            {
                int Rank = 0;
                int BeforeRank = 0;
                int wkCnt = 0;

                順位ワーク wkRank = new 順位ワーク();
                その他ワーク wkOther = new その他ワーク();
                ユーザ比較データ rowData = new ユーザ比較データ();
                List<順位ワーク> ListRankWork = new List<順位ワーク>();
                List<順位ワーク> ListRankCorrect = new List<順位ワーク>();
                List<ユーザ比較データ> tmpRankTotal = new List<ユーザ比較データ>();
                List<ユーザ比較データ> tmpRankTotal3 = new List<ユーザ比較データ>();
                List<ユーザ比較データ> RankTotal = new List<ユーザ比較データ>();

                // SQL クエリ
                string sql = "";

                //一覧クリア
                DgvComp.Rows.Clear();

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

                    ////////////////////////////////////////////////////////////////////////////////////作業量順位
                    if (CmbLevel.SelectedIndex == 0)
                    {
                        //枚数レベル
                        sql = CreateRankSql("AnswerMaisuHour", CmbCourse.SelectedIndex + 1);
                    }
                    else
                    {
                        //項目レベル
                        sql = CreateRankSql("AnswerKoumokuHour", CmbCourse.SelectedIndex + 1);
                    }

                    using (SQLiteCommand command = new SQLiteCommand(sql, con))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            ListRankWork = new List<順位ワーク>();
                            while (reader.Read())
                            {
                                // データの処理
                                wkRank = new 順位ワーク();
                                wkRank.id = reader.GetInt32(0);
                                wkRank.UserName = reader.GetString(1) + "　" + reader.GetString(2);
                                wkRank.MaxValue = reader.GetDecimal(3);
                                if ((ListRankWork.Count == 0) || (ListRankWork[ListRankWork.Count - 1].MaxValue != wkRank.MaxValue)) Rank = ListRankWork.Count + 1;
                                wkRank.Rank = Rank;
                                ListRankWork.Add(wkRank);
                            }
                        }
                    }

                    ////////////////////////////////////////////////////////////////////////////////////正解率順位
                    if (CmbLevel.SelectedIndex == 0)
                    {
                        //枚数レベル
                        sql = CreateRankSql("CorrectRateHour", CmbCourse.SelectedIndex + 1);
                    }
                    else
                    {
                        //項目レベル
                        sql = CreateRankSql("CorrectKoumokuRateHour", CmbCourse.SelectedIndex + 1);
                    }

                    using (SQLiteCommand command = new SQLiteCommand(sql, con))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            ListRankCorrect = new List<順位ワーク>();
                            while (reader.Read())
                            {
                                // データの処理
                                wkRank = new 順位ワーク();
                                wkRank.id = reader.GetInt32(0);
                                wkRank.UserName = reader.GetString(1) + "　" + reader.GetString(2);
                                wkRank.MaxValue = reader.GetDecimal(3);
                                if ((ListRankCorrect.Count == 0) || (ListRankCorrect[ListRankCorrect.Count - 1].MaxValue != wkRank.MaxValue)) Rank = ListRankCorrect.Count + 1;
                                wkRank.Rank = Rank;
                                ListRankCorrect.Add(wkRank);
                            }
                        }
                    }

                    ////////////////////////////////////////////////////////////////////////////////////総合順位
                    tmpRankTotal = new List<ユーザ比較データ>();
                    foreach (順位ワーク tmpRank in ListRankWork)
                    {
                        foreach (順位ワーク tmpRank2 in ListRankCorrect)
                        {
                            if (tmpRank.id == tmpRank2.id)
                            {
                                rowData = new ユーザ比較データ();
                                rowData.id = tmpRank.id;
                                rowData.UserName = tmpRank.UserName;
                                rowData.TotalRank = tmpRank.Rank + tmpRank2.Rank;
                                rowData.WorkRank = tmpRank.Rank;
                                rowData.WorkCount = decimal.ToInt32(tmpRank.MaxValue);
                                rowData.CorrectRank = tmpRank2.Rank;
                                rowData.CorrectRate = tmpRank2.MaxValue;
                                tmpRankTotal.Add((rowData));
                                break;
                            }
                        }
                    }

                    //総合順位順に並び替え
                    var tmpRankTotal2 = tmpRankTotal.OrderBy(x => x.TotalRank);

                    wkCnt = 0;
                    BeforeRank = 0;

                    tmpRankTotal3 = new List<ユーザ比較データ>();
                    foreach (ユーザ比較データ tmpRowdata in tmpRankTotal2)
                    {
                        wkCnt++;
                        rowData = new ユーザ比較データ();
                        if (tmpRowdata.TotalRank != BeforeRank) Rank = wkCnt;
                        BeforeRank = tmpRowdata.TotalRank;

                        rowData.id = tmpRowdata.id;
                        rowData.UserName = tmpRowdata.UserName;
                        rowData.TotalRank = Rank;
                        rowData.WorkRank = tmpRowdata.WorkRank;
                        rowData.WorkCount = tmpRowdata.WorkCount;
                        rowData.WorkCorrectRate = tmpRowdata.WorkCorrectRate;
                        rowData.CorrectRank = tmpRowdata.CorrectRank;
                        rowData.WorkCorrectRate = tmpRowdata.WorkCorrectRate;
                        rowData.CorrectRate = tmpRowdata.CorrectRate;

                        tmpRankTotal3.Add(rowData);
                    }

                    //表示順に並び替え
                    var tmpRankTotal4 = tmpRankTotal3.OrderByDescending(x => x.TotalRank).ThenByDescending(x => x.id);

                    ////////////////////////////////////////////////////////////////////////////////////その他項目の取得
                    RankTotal = new List<ユーザ比較データ>();
                    foreach (ユーザ比較データ tmpRowdata in tmpRankTotal4)
                    {
                        rowData = new ユーザ比較データ();
                        rowData.id = tmpRowdata.id;
                        rowData.TotalRank = tmpRowdata.TotalRank;
                        rowData.UserName = tmpRowdata.UserName;
                        rowData.WorkRank = tmpRowdata.WorkRank;
                        rowData.WorkCount = tmpRowdata.WorkCount;
                        rowData.CorrectRank = tmpRowdata.CorrectRank;
                        rowData.CorrectRate = tmpRowdata.CorrectRate;

                        if (CmbLevel.SelectedIndex == 0)
                        {
                            //枚数レベル
                            sql = CreateOtherSql(tmpRowdata.id, "AnswerMaisuHour", "CorrectRateHour", CmbCourse.SelectedIndex + 1);
                        }
                        else
                        {
                            //項目レベル
                            sql = CreateOtherSql(tmpRowdata.id, "AnswerKoumokuHour", "CorrectKoumokuRateHour", CmbCourse.SelectedIndex + 1);
                        }

                        using (SQLiteCommand command = new SQLiteCommand(sql, con))
                        {
                            using (SQLiteDataReader reader = command.ExecuteReader())
                            {
                                wkCnt = 0;
                                while (reader.Read())
                                {
                                    // データの処理
                                    wkOther = new その他ワーク();
                                    wkOther.id = reader.GetInt32(0);
                                    wkOther.WorkCount = (int)reader.GetDecimal(1);
                                    wkOther.CorrectRate = reader.GetDecimal(2);
                                    wkOther.WorkTime = reader.GetString(3);

                                    //最大作業数
                                    if (wkOther.WorkCount == tmpRowdata.WorkCount)
                                    {
                                        //未セットの場合は無条件にセット
                                        if (rowData.WorkTime == "")
                                        {
                                            rowData.WorkTime = wkOther.WorkTime;
                                            rowData.WorkNumber = wkCnt;     //とりあえず降順の回数のままセット
                                            rowData.WorkCorrectRate = wkOther.CorrectRate;
                                        }
                                        else
                                        {
                                            if (wkOther.CorrectRate > rowData.WorkCorrectRate)           ////////正解率が高い場合、セット
                                            {
                                                rowData.WorkTime = wkOther.WorkTime;
                                                rowData.WorkNumber = wkCnt;     //とりあえず降順の回数のままセット
                                                rowData.WorkCorrectRate = wkOther.CorrectRate;
                                            }
                                            else if (wkOther.CorrectRate < rowData.WorkCorrectRate)      ////////正解率が低い場合、何もしない
                                            {
                                            }
                                            else if ((wkOther.WorkTime.CompareTo(rowData.WorkTime) < 0)) ////////作業時間が短い場合、セット
                                            {
                                                rowData.WorkTime = wkOther.WorkTime;
                                                rowData.WorkNumber = wkCnt;     //とりあえず降順の回数のままセット
                                                rowData.WorkCorrectRate = wkOther.CorrectRate;
                                            }
                                        }
                                    }
                                    //最高正解率
                                    if (wkOther.CorrectRate == tmpRowdata.CorrectRate)
                                    {
                                        //未セットの場合は無条件にセット
                                        if (rowData.CorrectTime == "")
                                        {
                                            rowData.CorrectTime = wkOther.WorkTime;
                                            rowData.CorrectNumber = wkCnt;     //とりあえず降順の回数のままセット
                                            rowData.CorrectCount = wkOther.WorkCount;
                                        }
                                        else
                                        {
                                            if (wkOther.WorkCount > rowData.CorrectCount)           ////////作業量が多い場合、セット
                                            {
                                                rowData.CorrectTime = wkOther.WorkTime;
                                                rowData.CorrectNumber = wkCnt;     //とりあえず降順の回数のままセット
                                                rowData.CorrectCount = wkOther.WorkCount;
                                            }
                                            else if (wkOther.WorkCount < rowData.CorrectCount)      ////////作業量が少ない場合、何もしない
                                            {
                                            }
                                            else if ((wkOther.WorkTime.CompareTo(rowData.WorkTime) < 0)) ////////作業時間が短い場合、セット
                                            {
                                                rowData.CorrectTime = wkOther.WorkTime;
                                                rowData.CorrectNumber = wkCnt;     //とりあえず降順の回数のままセット
                                                rowData.CorrectCount = wkOther.WorkCount;
                                            }
                                        }
                                    }
                                    //最終３回
                                    if (wkCnt == 0)
                                    {
                                        rowData.Last3timeWorkCount = wkOther.WorkCount.ToString() + "枚";
                                        rowData.Last3timeCorrectRate = Math.Round(wkOther.CorrectRate, 1, MidpointRounding.AwayFromZero) + "％";
                                    }
                                    else if (wkCnt < 3)
                                    {
                                        rowData.Last3timeWorkCount = rowData.Last3timeWorkCount + "／" + wkOther.WorkCount.ToString() + "枚";
                                        rowData.Last3timeCorrectRate = rowData.Last3timeCorrectRate + "／"
                                                                     + Math.Round(wkOther.CorrectRate, 1, MidpointRounding.AwayFromZero) + "％";
                                    }

                                    wkCnt++;
                                }
                            }
                        }
                        rowData.TotalNumber = wkCnt;
                        if (wkCnt > 0)
                        {
                            //試行回編集
                            rowData.WorkNumber = (wkCnt - rowData.WorkNumber);
                            rowData.CorrectNumber = (wkCnt - rowData.CorrectNumber);
                        }
                        RankTotal.Add(rowData);
                    }

                    //ユーザ比較データ表示
                    DgvComp.Rows.Clear();
                    foreach (ユーザ比較データ tmpRowdata in RankTotal)
                    {
                        DgvComp.Rows.Add(tmpRowdata.id
                                       , tmpRowdata.TotalRank + "位"
                                       , tmpRowdata.UserName
                                       , tmpRowdata.WorkRank + "位"
                                       , ((tmpRowdata.TotalNumber == 0) ? "" : tmpRowdata.WorkTime)
                                       , ((tmpRowdata.TotalNumber == 0) ? "" : tmpRowdata.WorkNumber + "回目／" + tmpRowdata.TotalNumber + "回")
                                       , ((tmpRowdata.TotalNumber == 0) ? "" : tmpRowdata.WorkCount + "枚")
                                       , ((tmpRowdata.TotalNumber == 0) ? "" : Math.Round(tmpRowdata.WorkCorrectRate, 1, MidpointRounding.AwayFromZero) + "％")
                                       , tmpRowdata.CorrectRank + "位"
                                       , ((tmpRowdata.TotalNumber == 0) ? "" : tmpRowdata.CorrectTime)
                                       , ((tmpRowdata.TotalNumber == 0) ? "" : tmpRowdata.CorrectNumber + "回目／" + tmpRowdata.TotalNumber + "回")
                                       , ((tmpRowdata.TotalNumber == 0) ? "" : tmpRowdata.CorrectCount + "枚")
                                       , ((tmpRowdata.TotalNumber == 0) ? "" : Math.Round(tmpRowdata.CorrectRate, 1, MidpointRounding.AwayFromZero) + "％")
                                       , tmpRowdata.Last3timeWorkCount
                                       , tmpRowdata.Last3timeCorrectRate
                                        );
                    }
                    con.Close();
                }

                LblCnt.Text = DgvComp.Rows.Count.ToString("#,0");
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
        //              CSV出力
        /// </summary>
        /// <param name="FileName">出力ファイル(フルパス)</param>
        /// <returns>true:正常終了　false:異常終了</returns>
        private Boolean CreateCSV(string FileName)
        {
            try
            {
                //入力値ファイル出力
                using (StreamWriter sw = new StreamWriter(FileName, false, Encoding.UTF8))
                {
                    sw.WriteLine("\"順位\",\"氏名\",\"作業量の順位\",\"試行実時間\",\"試行回\",\"作業量\",\"正解率\",\"正解率の順位\",\"試行実時間\"," +
                                 "\"試行回\",\"作業量\",\"正解率\",\"最終３回分の作業量\",\"最終３回分の正解率\"");


                    for (int row = 0; row < DgvComp.Rows.Count; row++)
                    {
                        sw.WriteLine("\"" + DgvComp.Rows[row].Cells[1].Value.ToString() + "\"," +
                                     "\"" + DgvComp.Rows[row].Cells[2].Value.ToString() + "\"," +
                                     "\"" + DgvComp.Rows[row].Cells[3].Value.ToString() + "\"," +
                                     "\"" + DgvComp.Rows[row].Cells[4].Value.ToString() + "\"," +
                                     "\"" + DgvComp.Rows[row].Cells[5].Value.ToString() + "\"," +
                                     "\"" + DgvComp.Rows[row].Cells[6].Value.ToString() + "\"," +
                                     "\"" + DgvComp.Rows[row].Cells[7].Value.ToString() + "\"," +
                                     "\"" + DgvComp.Rows[row].Cells[8].Value.ToString() + "\"," +
                                     "\"" + DgvComp.Rows[row].Cells[9].Value.ToString() + "\"," +
                                     "\"" + DgvComp.Rows[row].Cells[10].Value.ToString() + "\"," +
                                     "\"" + DgvComp.Rows[row].Cells[11].Value.ToString() + "\"," +
                                     "\"" + DgvComp.Rows[row].Cells[12].Value.ToString() + "\"," +
                                     "\"" + DgvComp.Rows[row].Cells[13].Value.ToString() + "\"," +
                                     "\"" + DgvComp.Rows[row].Cells[14].Value.ToString() + "\""
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
        //              順位取得用SQL編集
        /// </summary>
        /// <param name="ColumnName">最大値取得カラム</param>
        /// <param name="Mode">処理モード</param>
        /// <returns>SQL文</returns>
        private string CreateRankSql(string ColumnName, int Mode)
        {
            return "SELECT US.id"
                 + "     , US.UserShiKanji"
                 + "     , US.UserMeiKanji"
                 + "     , ifnull(HS.MaxValue, -1) MaxValue"
                 + "  FROM ユーザマスタ as US"
                 + "       LEFT JOIN(SELECT HI.UserID"
                 + "                      , MAX(HI." + ColumnName + ") MaxValue"
                 + "                   FROM 履歴データ as HI"
                 + "                  WHERE HI.Mode = " + Mode.ToString()
                 + "                    AND HI.Course = 1"
                 + "                    AND HI.DelFlg = 0"
                 + "                  GROUP BY HI.UserID"
                 + "                ) as HS"
                 + "         ON US.id = HS.UserID"
                 + "  WHERE US.DelFlg = 0"
                 + "  ORDER BY MaxValue DESC";
        }

        /// <summary>
        //              その他項目取得用SQL編集
        /// </summary>
        /// <param name="UserId">ユーザＩＤ</param>
        /// <param name="ColumnWork">取得作業量カラム</param>
        /// <param name="ColumnCorrect">取得正解率カラム</param>
        /// <param name="Mode">処理モード</param>
        /// <returns>SQL文</returns>
        private string CreateOtherSql(int UserId, string ColumnWork, string ColumnCorrect, int Mode)
        {
            return "SELECT UserID"
                 + "     , " + ColumnWork
                 + "     , " + ColumnCorrect
                 + "     , WorkTime"
                 + "  FROM 履歴データ"
                 + " WHERE UserID = " + UserId.ToString()
                 + "   AND Mode = " + Mode.ToString()
                 + "   AND Course = 1"
                 + "   AND DelFlg = 0"
                 + "  ORDER BY StartDate DESC";
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
