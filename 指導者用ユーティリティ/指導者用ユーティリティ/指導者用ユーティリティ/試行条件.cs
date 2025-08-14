using System.Data.SQLite;
using System.Text;


namespace 指導者用ユーティリティ
{
    public partial class Frm試行条件 : Form
    {
        // SqLite ファイルへの接続文字列
        private string connectionStringO = "";

        /// <summary>
        //              Initialize
        /// </summary>
        /// <param name="id">ユーザID</param>
        public Frm試行条件()
        {
            InitializeComponent();

            //中央に配置する
            this.StartPosition = FormStartPosition.CenterScreen;

            //フォームの最大化ボタンの表示、非表示を切り替える
            this.MaximizeBox = !this.MaximizeBox;
            //フォームの最小化ボタンの表示、非表示を切り替える
            this.MinimizeBox = !this.MinimizeBox;

            //ユーザーがサイズを変更できないようにする
            //最大化、最小化はできる
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //フォームが最大化されないようにする
            this.MaximizeBox = false;
            //フォームが最小化されないようにする
            this.MinimizeBox = false;
        }

        /// <summary>
        //              Form　Load 
        /// </summary>
        private void Frm試行条件_Load(object sender, EventArgs e)
        {
            // DBファイルの格納パス取得
            if (System.IO.File.Exists(Application.StartupPath + @"\LetsTry04.ini"))
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance); // memo: Shift-JISを扱うためのおまじない
                StreamReader sr = new StreamReader(Application.StartupPath + @"\LetsTry04.ini", Encoding.GetEncoding("Shift_JIS"));
                connectionStringO = SetPathStringOutput(sr.ReadLine());
                //データ取得
                getConditionData();
            }
            else
            {
                MessageBox.Show("システム環境に問題があります。", "エラー");
                //終了
                this.Dispose();
                this.Close();
            }
        }

        /// <summary>
        //              ショートカットキー判定　Key Down
        /// </summary>
        /// <param name="keyData">キー情報</param>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            //［Alt］+［H］が押されたらキャッチ(解析結果の出力)
            if (keyData == (Keys.H | Keys.Alt))
            {
                BtnReport.PerformClick();
            }
            //［Alt］+［B］が押されたらキャッチ(番号順)
            if (keyData == (Keys.B | Keys.Alt))
            {
                RdiTeiji1.Checked = true;
            }
            //［Alt］+［S］が押されたらキャッチ(シャッフル)
            if (keyData == (Keys.S | Keys.Alt))
            {
                RdiTeiji2.Checked = true;
            }
            //［Alt］+［E］が押されたらキャッチ(前回の続き)
            if (keyData == (Keys.E | Keys.Alt))
            {
                if (GrpStart.Enabled)
                {
                    RdiStart1.Checked = true;
                }
            }
            //［Alt］+［N］が押されたらキャッチ(開始NO指定)
            if (keyData == (Keys.N | Keys.Alt))
            {
                if (GrpStart.Enabled)
                {
                    RdiStart2.Checked = true;
                }
            }
            //［Alt］+［P］が押されたらキャッチ(アンケートカード・顧客伝票の印刷物イメージを画面に表示する)
            if (keyData == (Keys.P | Keys.Alt))
            {
                ChkFormQuestion.Checked = !ChkFormQuestion.Checked;
            }
            //［Alt］+［L］が押されたらキャッチ(左)
            if (keyData == (Keys.L | Keys.Alt))
            {
                if (PnlFormQuestion.Enabled)
                {
                    RdiFormQuestion1.Checked = true;
                }
            }
            //［Alt］+［R］が押されたらキャッチ(右)
            if (keyData == (Keys.R | Keys.Alt))
            {
                if (PnlFormQuestion.Enabled)
                {
                    RdiFormQuestion2.Checked = true;
                }
            }
            //［Alt］+［Z］が押されたらキャッチ(郵便番号検索を有効にする)
            if (keyData == (Keys.Z | Keys.Alt))
            {
                ChkZipSearch.Checked = !ChkZipSearch.Checked;
            }

            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        ///             解析結果の出力ボタン Click
        /// </summary>
        private void BtnReport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("解析結果の出力は工事中です");
            //Frmユーザ登録 frm = new Frmユーザ登録();
            //frm.ShowDialog();
        }

        /// <summary>
        //              ＯＫボタン　Click
        /// </summary>
        private void BtnOk_Click(object sender, EventArgs e)
        {
            try
            {
                // SQL クエリ
                string sql = "";
                SQLiteCommand com;
                int Teiji = 0;
                int StartNo = 0;
                int QFormDisp = 0;
                int QFormLR = 0;
                int ZipSearch = 0;

                //呈示方法
                if (RdiTeiji1.Checked)
                {
                    Teiji = 1;
                }
                else
                {
                    Teiji = 2;
                }
                //開始No設定
                if (RdiStart1.Checked)
                {
                    StartNo = 0;
                }
                else
                {
                    StartNo = Decimal.ToInt32(NudStart.Value);
                }
                //アンケートカード・顧客伝票の印刷物イメージを画面に表示する
                if (ChkFormQuestion.Checked)
                {
                    QFormDisp = 1;
                }
                else
                {
                    QFormDisp = 0;
                }
                //表示位置
                if (RdiFormQuestion1.Checked)
                {
                    QFormLR = 0;
                }
                else
                {
                    QFormLR = 1;
                }
                //郵便番号検索を有効にする
                if (ChkZipSearch.Checked)
                {
                    ZipSearch = 1;
                }
                else
                {
                    ZipSearch = 0;
                }

                // データＤＢを開く
                using (SQLiteConnection con = new SQLiteConnection(SetconnectionStringOutput(connectionStringO)))
                {
                    con.Open();

                    //ユーザマスタを更新する
                    sql = "Update 試行条件マスタ SET Teiji = " + Teiji + ", " +
                                                  "StartNo   = " + StartNo + ", " +
                                                  "QFormDisp = " + QFormDisp + ", " +
                                                  "QFormLR   = " + QFormLR + ", " +
                                                  "ZipSearch = " + ZipSearch + ", " +
                                                  "UpdDate   = datetime('now', 'localtime') " +
                                                  "Where Id = 1;";

                    com = new SQLiteCommand(sql, con);
                    com.ExecuteNonQuery();

                    con.Close();
                }
                this.Dispose();
                this.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
                //終了
                this.Dispose();
                this.Close();
            }
        }

        /// <summary>
        //              キャンセルボタン　Click
        /// </summary>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        /// <summary>
        //              番号順　Check
        /// </summary>
        private void RdiTeiji1_CheckedChanged(object sender, EventArgs e)
        {
            GrpStart.Enabled = RdiTeiji1.Checked;
        }

        /// <summary>
        //              シャッフル　Check
        /// </summary>
        private void RdiTeiji2_CheckedChanged(object sender, EventArgs e)
        {
            GrpStart.Enabled = !RdiTeiji2.Checked;
        }

        /// <summary>
        //              前回の続き　Check
        /// </summary>
        private void RdiStart1_CheckedChanged(object sender, EventArgs e)
        {
            NudStart.Enabled = !RdiStart1.Checked;
        }

        /// <summary>
        //              開始NO指定　Check
        /// </summary>
        private void RdiStart2_CheckedChanged(object sender, EventArgs e)
        {
            NudStart.Enabled = RdiStart2.Checked;
        }

        /// <summary>
        //              アンケートカード・顧客伝票の印刷物イメージを画面に表示する　Check
        /// </summary>
        private void ChkFormQuestion_CheckedChanged(object sender, EventArgs e)
        {
            PnlFormQuestion.Enabled = ChkFormQuestion.Checked;
        }

        /// <summary>
        //              条件マスタ　取得処理
        /// </summary>
        /// <returns>true:正常終了　false:異常終了</returns>
        private Boolean getConditionData()
        {
            try
            {
                // SQL クエリ
                string sql = "";
                int cnt = 0;

                // データＤＢを開く
                using (SQLiteConnection con = new SQLiteConnection(SetconnectionStringOutput(connectionStringO)))
                {
                    con.Open();

                    //マスタ作成
                    sql = "CREATE TABLE IF NOT EXISTS 試行条件マスタ(id        int , " +
                                                                    "Teiji     int ," +
                                                                    "StartNo   int ," +
                                                                    "QFormDisp int ," +
                                                                    "QFormLR   int ," +
                                                                    "ZipSearch int ," +
                                                                    "InsDate   datetime ," +
                                                                    "UpdDate   datetime ," +
                                                                    "PRIMARY KEY(id)" +
                                                                  ")";

                    SQLiteCommand com = new SQLiteCommand(sql, con);
                    com.ExecuteNonQuery();

                    //試行条件マスタを取得して、表示する
                    sql = "SELECT * From 試行条件マスタ Where id = 1";

                    using (SQLiteCommand command = new SQLiteCommand(sql, con))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // データの処理
                                RdiTeiji1.Checked = (reader.GetInt32(1) == 1);
                                RdiTeiji2.Checked = (reader.GetInt32(1) != 1);
                                RdiStart1.Checked = (reader.GetInt32(2) == 0);
                                RdiStart2.Checked = (reader.GetInt32(2) > 0);
                                if (reader.GetInt32(2) > 0)
                                {
                                    NudStart.Value = reader.GetInt32(2);
                                }
                                else
                                {
                                    NudStart.Value = 1;
                                }
                                ChkFormQuestion.Checked = (reader.GetInt32(3) == 1);
                                PnlFormQuestion.Enabled = ChkFormQuestion.Checked;
                                RdiFormQuestion1.Checked = (reader.GetInt32(4) == 0);
                                RdiFormQuestion2.Checked = (reader.GetInt32(4) != 0);
                                ChkZipSearch.Checked = (reader.GetInt32(5) == 1);
                                cnt++;
                            }
                            if (cnt == 0)
                            {
                                sql = "Insert into 試行条件マスタ Values(" + 1 + "," +                          //ID
                                                                             1 + "," +                          //呈示方法(1:番号順)
                                                                             0 + "," +                          //開始No(0:前回の続き)
                                                                             1 + "," +                          //表示方法(1:画面表示)
                                                                             0 + "," +                          //表示位置(0:左)
                                                                             1 + "," +                          //郵便番号検索(1:有効)
                                                                            "datetime('now', 'localtime')," +
                                                                            "datetime('now', 'localtime')" +
                                                                     ");";

                                com = new SQLiteCommand(sql, con);
                                com.ExecuteNonQuery();
                                // データの処理
                                RdiTeiji1.Checked = true;
                                RdiTeiji2.Checked = false;
                                RdiStart1.Checked = true;
                                RdiStart2.Checked = false;
                                NudStart.Value = 1;
                                ChkFormQuestion.Checked = true;
                                RdiFormQuestion1.Checked = true;
                                RdiFormQuestion2.Checked = false;
                                ChkZipSearch.Checked = true;
                            }
                        }
                    }
                    con.Close();
                }

                return true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
                //終了
                this.Dispose();
                this.Close();
                return false;
            }
        }

        /// <summary>
        //              ＤＢ接続文字列セット
        /// </summary>
        /// <param name="con">コネクション文字列</param>
        /// <returns>SQLite接続文字列</returns>
        private string SetconnectionStringOutput(string con)
        {
            return "Data Source=" + con + ";Version=3;";
        }

        /// <summary>
        //              ＤＢパスセット
        /// </summary>
        /// <param name="fPath">データベースフルパス</param>
        /// <returns>SQLiteデータベース名フルパス</returns>
        private string SetPathStringOutput(string? fPath)
        {
            return fPath + @"\LetsTry04.dat";
        }

    }
}

