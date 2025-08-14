using System.Data.OleDb;
using System.Data.SQLite;
using System.Text;


namespace 指導者用ユーティリティ
{
    public partial class Frmマスタ移行 : Form
    {
        // MDB ファイルへの接続文字列
        private string connectionStringI = "";
        // SqLite ファイルへの接続文字列
        private string connectionStringO = "";
        // SqLite ファイル削除フラグ
        private Boolean oFileDelFlg = false;

        /// <summary>
        //              Initialize
        /// </summary>
        public Frmマスタ移行()
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
        //              ショートカットキー判定　Key Down
        /// </summary>
        /// <param name="keyData">キー情報</param>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            //［Alt］+［I］が押されたらキャッチ(移行元マスタファイル)
            if (keyData == (Keys.I | Keys.Alt))
            {
                BtnInFile.PerformClick();
            }
            //［Alt］+［O］が押されたらキャッチ(移行先フォルダ)
            if (keyData == (Keys.O | Keys.Alt))
            {
                BtnOutPath.PerformClick();
            }
            //［Alt］+［S］が押されたらキャッチ(移行開始)
            if (keyData == (Keys.S | Keys.Alt))
            {
                BtnStart.PerformClick();
            }
            //［F1］が押されたらキャッチ(マニュアル移行)
            if (keyData == Keys.F1)
            {
                PnlPassword.Visible = true;
                TxtPass.Text = "";
                TxtPass.Focus();
            }

            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        //              Form　Load 
        /// </summary>
        private void Frmマスタ移行_Load(object sender, EventArgs e)
        {
            // MDB ファイルへの接続文字列
            LblInFile.Text = Application.StartupPath + @"LetsTry01.mst";
            if (System.IO.File.Exists(Application.StartupPath + @"LetsTry04.ini"))
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance); // memo: Shift-JISを扱うためのおまじない
                StreamReader sr = new StreamReader(Application.StartupPath + @"LetsTry04.ini", Encoding.GetEncoding("Shift_JIS"));
                LblOutPath.Text = sr.ReadLine();
                sr.Close();
            }
            else
            {
                LblOutPath.Text = Application.StartupPath;
            }

            connectionStringI = SetconnectionStringInput(LblInFile.Text);
            connectionStringO = SetPathStringOutput(LblOutPath.Text);
        }

        /// <summary>
        //              パスワードＯＫ　Click
        /// </summary>
        private void BtnPass_Click(object sender, EventArgs e)
        {
            if (TxtPass.Text == "IkoAdmin")
            {
                BtnInFile.Visible = true;
                BtnInFile.Enabled = true;
                LblInFile.Visible = true;
            }
            TxtPass.Text = "";
            PnlPassword.Visible = false;
        }

        /// <summary>
        //              移行元マスタファイル　Click
        /// </summary>
        private void BtnInFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = @"マスタファイル選択";
                openFileDialog.Filter = @"マスタファイル(*.mst)|*.mst|すべてのファイル(*.*)|*.*";
                openFileDialog.InitialDirectory = LblInFile.Text.Replace(@"\LetsTry01.mst", @"");

                //ファイル選択ダイアログを開く
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    LblInFile.Text = openFileDialog.FileName;
                    // MDB ファイルへの接続文字列
                    connectionStringI = SetconnectionStringInput(LblInFile.Text);
                }
            }
        }

        /// <summary>
        //              移行先マスタフォルダ　Click
        /// </summary>
        private void BtnOutPath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog openDirDialog = new FolderBrowserDialog())
            {
                openDirDialog.Description = "移行先マスタフォルダ選択";
                openDirDialog.RootFolder = Environment.SpecialFolder.Desktop;
                openDirDialog.SelectedPath = LblOutPath.Text;
                openDirDialog.ShowNewFolderButton = true;

                Boolean okFlg = false;
                oFileDelFlg = false;
                //ファイル選択ダイアログを開く
                if (openDirDialog.ShowDialog() == DialogResult.OK)
                {
                    if (System.IO.File.Exists(SetPathStringOutput(openDirDialog.SelectedPath)))
                    {
                        // メッセージボックスを表示
                        DialogResult result = MessageBox.Show("移行先にマスタが存在します。上書きしますか？", "", MessageBoxButtons.YesNo);

                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            okFlg = true;
                            oFileDelFlg = true;
                        }
                    }
                    else
                    {
                        okFlg = true;
                    }

                    if (okFlg)
                    {
                        LblOutPath.Text = openDirDialog.SelectedPath;
                        Uri uPath;
                        // SQLite ファイルへの接続文字列
                        connectionStringO = SetPathStringOutput(LblOutPath.Text);
                        uPath = new Uri(connectionStringO);
                        if (uPath.IsUnc)
                        {
                            connectionStringO = @"\" + connectionStringO;
                        }
                    }
                }
            }
        }

        /// <summary>
        //              移行ボタン　Click
        /// </summary>
        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (BtnInFile.Enabled)
            {
                BtnInFile.Enabled = false;
                BtnOutPath.Enabled = false;
                BtnStart.Enabled = false;
                BtnCancel.Enabled = false;
                LblResult.Visible = false;

                if (GetMasterCnt())                                             //入力テーブル件数取得
                {
                    if (ProcIkoPostNo())                                        //郵便番号マスタ 移行
                    {
                        if (ProcIkoQuestionLevelUp())                           //アンケート入力マスタ(レベルアップ)　移行
                        {
                            if (ProcIkoCustomerLevelUp())                       //顧客伝票マスタ(レベルアップ)　移行
                            {
                                if (ProcIkoCustomerLevelUpErr())                //顧客伝票エラーデータ(レベルアップ)　移行
                                {
                                    if (ProcIkoQuestionKiso())                  //アンケート入力マスタ(基礎トレ)　移行
                                    {
                                        if (ProcIkoCustomerCheck())             //顧客伝票マスタ(基礎トレ)　移行
                                        {
                                            if (ProcIkoCustomerCheckErr())      //顧客伝票エラーデータ(基礎トレ)　移行
                                            {
                                                //iniファイル出力
                                                SetIniFile();
                                                LblResult.Text = "正常終了";

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                BtnInFile.Enabled = false;
                BtnInFile.Visible = false;
                LblInFile.Visible = false;
                LblResult.Visible = true;
                BtnOutPath.Enabled = true;
                BtnStart.Enabled = true;
                BtnCancel.Enabled = true;
            }
            else
            {
                BtnOutPath.Enabled = false;
                BtnStart.Enabled = false;
                BtnCancel.Enabled = false;
                LblResult.Visible = false;

                //マスタファイルコピー
                if ((LblOutPath.Text != Application.StartupPath) && (LblOutPath.Text + @"\" != Application.StartupPath))
                {
                    System.IO.File.Copy(SetPathStringOutput(Application.StartupPath), SetPathStringOutput(LblOutPath.Text), true);
                }

                //件数表示
                if (GeOutputCnt())
                {
                    //iniファイル出力
                    SetIniFile();

                    LblResult.Text = "正常終了";

                    BtnOutPath.Enabled = true;
                    BtnStart.Enabled = true;
                    BtnCancel.Enabled = true;
                    LblResult.Visible = true;
                }
            }
        }

        /// <summary>
        //              キャンセルボタン　Click
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        /// <summary>
        //              出力テーブル件数取得
        /// </summary>
        /// <returns>true:正常終了　false:異常終了</returns>
        private Boolean GeOutputCnt()
        {
            try
            {
                // SQL クエリ
                string sql = "";

                // 接続を確立し、クエリを実行
                // 出力ＤＢを開く
                using (SQLiteConnection con = new SQLiteConnection(SetconnectionStringOutput(connectionStringO)))
                {
                    con.Open();
                    //郵便番号マスタ
                    sql = "Select count(1) From mstPostNo";

                    using (SQLiteCommand command = new SQLiteCommand(sql, con))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // データの処理
                                LblCntPostNoResult.Text = reader.GetInt32(0).ToString();
                                LblCntPostNo.Text = @"／" + LblCntPostNoResult.Text;
                            }
                        }
                    }

                    //アンケート入力マスタ(レベルアップ)　
                    sql = "Select count(1) From mstQuestionLevelUp";

                    using (SQLiteCommand command = new SQLiteCommand(sql, con))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // データの処理
                                LblCntQuestionnaireResult.Text = reader.GetInt32(0).ToString();
                                LblCntQuestionnaire.Text = @"／" + LblCntQuestionnaireResult.Text;
                            }
                        }
                    }

                    //顧客伝票マスタ(レベルアップ)　
                    sql = "Select count(1) From mstCustomerSlip";

                    using (SQLiteCommand command = new SQLiteCommand(sql, con))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // データの処理
                                LblCntCustomerInputResult.Text = reader.GetInt32(0).ToString();
                                LblCntCustomerInput.Text = @"／" + LblCntCustomerInputResult.Text;
                            }
                        }
                    }

                    //顧客伝票エラーデータ(レベルアップ)　
                    sql = "Select count(1) From mstCustomerSlipError";

                    using (SQLiteCommand command = new SQLiteCommand(sql, con))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // データの処理
                                LblCntCustomerInputErrResult.Text = reader.GetInt32(0).ToString();
                                LblCntCustomerInputErr.Text = @"／" + LblCntCustomerInputErrResult.Text;
                            }
                        }
                    }

                    //アンケート入力マスタ(基礎トレ)　
                    sql = "Select count(1) From mstQuestionBasic";

                    using (SQLiteCommand command = new SQLiteCommand(sql, con))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // データの処理
                                LblCntQuestionnaire2Result.Text = reader.GetInt32(0).ToString();
                                LblCntQuestionnaire2.Text = @"／" + LblCntQuestionnaire2Result.Text;
                            }
                        }
                    }

                    //顧客伝票マスタ(基礎トレ)　
                    sql = "Select count(1) From mstCustomerSlipBasic";

                    using (SQLiteCommand command = new SQLiteCommand(sql, con))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // データの処理
                                LblCntCustomerCheckResult.Text = reader.GetInt32(0).ToString();
                                LblCntCustomerCheck.Text = @"／" + LblCntCustomerCheckResult.Text;
                            }
                        }
                    }

                    //顧客伝票エラーデータ(基礎トレ)　移行
                    sql = "Select count(1) From mstCustomerSlipErrorBasic";

                    using (SQLiteCommand command = new SQLiteCommand(sql, con))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // データの処理
                                LblCntCustomerCheckErrResult.Text = reader.GetInt32(0).ToString();
                                LblCntCustomerCheckErr.Text = @"／" + LblCntCustomerCheckErrResult.Text;
                            }
                        }
                    }
                }

                return true;

            }
            catch (Exception ex)
            {
                LblResult.Text = ex.Message;
                return false;
            }
        }

        //              入力テーブル件数取得
        /// </summary>
        /// <returns>true:正常終了　false:異常終了</returns>
        private Boolean GetMasterCnt()
        {
            try
            {
                int cnt = 0;

                // SQL クエリ
                string query = "";

                // 接続を確立し、クエリを実行
                using (OleDbConnection con = new OleDbConnection(connectionStringI))
                {
                    con.Open();

                    //                                                              郵便番号マスタ
                    query = "SELECT Count(1) FROM KEN_ALL";
                    using (OleDbCommand command = new OleDbCommand(query, con))
                    {
                        // データを読み取る
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // データの処理
                                cnt = reader.GetInt32(0);

                                LblCntPostNoResult.Text = "0";
                                LblCntPostNo.Text = @"／" + cnt.ToString();
                                LblCntPostNo.Refresh();
                            }
                        }
                    }

                    //                                                              アンケート入力マスタ(レベルアップ)
                    query = "SELECT Count(1) FROM Mst01";
                    using (OleDbCommand command = new OleDbCommand(query, con))
                    {
                        // データを読み取る
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // データの処理
                                cnt = reader.GetInt32(0);

                                LblCntQuestionnaireResult.Text = "0";
                                LblCntQuestionnaire.Text = @"／" + cnt.ToString();
                                LblCntQuestionnaire.Refresh();
                            }
                        }
                    }

                    //                                                              顧客伝票修正マスタ
                    query = "SELECT Count(1) FROM Mst02";
                    using (OleDbCommand command = new OleDbCommand(query, con))
                    {
                        // データを読み取る
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // データの処理
                                cnt = reader.GetInt32(0);

                                LblCntCustomerInputResult.Text = "0";
                                LblCntCustomerInput.Text = @"／" + cnt.ToString();
                                LblCntCustomerInput.Refresh();
                            }
                        }
                    }

                    //                                                              顧客伝票修正エラーデータ
                    query = "SELECT Count(1) FROM Mst02Error";
                    using (OleDbCommand command = new OleDbCommand(query, con))
                    {
                        // データを読み取る
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // データの処理
                                cnt = reader.GetInt32(0);

                                LblCntCustomerInputErrResult.Text = "0";
                                LblCntCustomerInputErr.Text = @"／" + cnt.ToString();
                                LblCntCustomerInputErr.Refresh();
                            }
                        }
                    }

                    //                                                              アンケート入力マスタ(基礎トレ)
                    query = "SELECT Count(1) FROM Mst03";
                    using (OleDbCommand command = new OleDbCommand(query, con))
                    {
                        // データを読み取る
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // データの処理
                                cnt = reader.GetInt32(0);

                                LblCntQuestionnaire2Result.Text = "0";
                                LblCntQuestionnaire2.Text = @"／" + cnt.ToString();
                                LblCntQuestionnaire2.Refresh();
                            }
                        }
                    }

                    //                                                              顧客伝票ミスチェックマスタ
                    query = "SELECT Count(1) FROM Mst04";
                    using (OleDbCommand command = new OleDbCommand(query, con))
                    {
                        // データを読み取る
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // データの処理
                                cnt = reader.GetInt32(0);

                                LblCntCustomerCheckResult.Text = "0";
                                LblCntCustomerCheck.Text = @"／" + cnt.ToString();
                                LblCntCustomerCheck.Refresh();
                            }
                        }
                    }

                    //                                                              顧客伝票ミスチェックエラーデータ
                    query = "SELECT Count(1) FROM Mst04Error";
                    using (OleDbCommand command = new OleDbCommand(query, con))
                    {
                        // データを読み取る
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // データの処理
                                cnt = reader.GetInt32(0);

                                LblCntCustomerCheckErrResult.Text = "0";
                                LblCntCustomerCheckErr.Text = @"／" + cnt.ToString();
                                LblCntCustomerCheckErr.Refresh();
                            }
                        }
                    }
                    con.Close();
                }
                //移行先マスタの削除
                if (oFileDelFlg)
                {
                    File.Delete(connectionStringO);
                }
                else
                {
                    // 移行先ＤＢの存在チェック
                    if (System.IO.File.Exists(connectionStringO))
                    {
                        // メッセージボックスを表示
                        DialogResult result = MessageBox.Show("移行先にマスタが存在します。上書きしますか？", "", MessageBoxButtons.YesNo);

                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            File.Delete(connectionStringO);
                        }
                        else
                        {
                            return false;
                        }
                    }


                }

                return true;
            }

            catch (Exception ex)
            {
                LblResult.Text = ex.Message;
                return false;
            }
        }

        /// <summary>
        //              郵便番号マスタ　移行処理
        /// </summary>
        /// <returns>true:正常終了　false:異常終了</returns>
        private Boolean ProcIkoPostNo()
        {
            try
            {
                int cnt = 0;

                int id = 0;
                string DantaiCd = "";
                string ZipCode5 = "";
                string ZipCode7 = "";
                string TodofukenKana = "";
                string City1Kana = "";
                string City2Kana = "";
                string TodofukenKanji = "";
                string City1Kanji = "";
                string City2Kanji = "";
                int Flg10 = 0;
                int Flg11 = 0;
                int Flg12 = 0;
                int Flg13 = 0;
                int Flg14 = 0;
                int Flg15 = 0;

                // SQL クエリ
                string query = "SELECT * FROM KEN_ALL ORDER BY ID";

                // 接続を確立し、クエリを実行
                using (OleDbConnection conI = new OleDbConnection(connectionStringI))
                {
                    using (OleDbCommand command = new OleDbCommand(query, conI))
                    {
                        conI.Open();

                        // 出力ＤＢを開く
                        using (SQLiteConnection conO = new SQLiteConnection(SetconnectionStringOutput(connectionStringO)))
                        {
                            conO.Open();
                            //テーブル作成
                            string sql = "create table mstPostNo (id int , " +
                                                                 "DantaiCd varchar(5)," +
                                                                 "ZipCode5 varchar(5)," +
                                                                 "ZipCode7 varchar(7)," +
                                                                 "TodofukenKana varchar(20)," +
                                                                 "City1Kana varchar(50)," +
                                                                 "City2Kana varchar(150)," +
                                                                 "TodofukenKanji varchar(8)," +
                                                                 "City1Kanji varchar(20)," +
                                                                 "City2Kanji varchar(80)," +
                                                                 "Flg1 int," +
                                                                 "Flg2 int," +
                                                                 "Flg3 int," +
                                                                 "Flg4 int," +
                                                                 "Flg5 int," +
                                                                 "Flg6 int," +
                                                                 "PRIMARY KEY(id)" +
                                                                 ")";

                            SQLiteCommand com = new SQLiteCommand(sql, conO);
                            com.ExecuteNonQuery();

                            // データを読み取る
                            using (OleDbDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    // データの処理
                                    // 例えば、reader.GetString(0) などを使ってフィールドの値を取得できます
                                    id = reader.GetInt32(0); // 0 はフィールドのインデックス
                                    DantaiCd = reader.GetString(1);
                                    ZipCode5 = reader.GetString(2);
                                    ZipCode7 = reader.GetString(3);
                                    TodofukenKana = reader.GetString(4);
                                    City1Kana = reader.GetString(5);
                                    City2Kana = reader.GetString(6);
                                    TodofukenKanji = reader.GetString(7);
                                    City1Kanji = reader.GetString(8);
                                    City2Kanji = reader.GetString(9);
                                    Flg10 = reader.GetInt16(10);
                                    Flg11 = reader.GetInt16(11);
                                    Flg12 = reader.GetInt16(12);
                                    Flg13 = reader.GetInt16(13);
                                    Flg14 = reader.GetInt16(14);
                                    Flg15 = reader.GetInt16(15);

                                    //マスタ出力
                                    //テーブル作成
                                    sql = "Insert into mstPostNo Values(" + id + "," +
                                                                       "'" + DantaiCd + "'," +
                                                                       "'" + ZipCode5 + "'," +
                                                                       "'" + ZipCode7 + "'," +
                                                                       "'" + TodofukenKana + "'," +
                                                                       "'" + City1Kana + "'," +
                                                                       "'" + City2Kana + "'," +
                                                                       "'" + TodofukenKanji + "'," +
                                                                       "'" + City1Kanji + "'," +
                                                                       "'" + City2Kanji + "'," +
                                                                             Flg10 + "," +
                                                                             Flg11 + "," +
                                                                             Flg12 + "," +
                                                                             Flg13 + "," +
                                                                             Flg14 + "," +
                                                                             Flg15 +
                                                                       ");";

                                    com = new SQLiteCommand(sql, conO);
                                    com.ExecuteNonQuery();

                                    cnt++;
                                    LblCntPostNoResult.Text = cnt.ToString();
                                    LblCntPostNoResult.Refresh();
                                }
                            }
                            //index生成
                            sql = "Create index PostNoIndex on mstPostNo(ZipCode7);";

                            com = new SQLiteCommand(sql, conO);
                            com.ExecuteNonQuery();

                            conO.Close();
                        }
                        conI.Close();
                    }
                }

                return true;
            }

            catch (Exception ex)
            {
                LblResult.Text = ex.Message;
                return false;
            }
        }

        /// <summary>
        //              アンケート入力マスタ(レベルアップ)　移行処理
        /// </summary>
        /// <returns>true:正常終了　false:異常終了</returns>
        private Boolean ProcIkoQuestionLevelUp()
        {
            try
            {
                int cnt = 0;

                int id = 0;
                string NameKana = "";
                string NameKanji = "";
                string ZipCode = "";
                string Address = "";
                string TelNo = "";
                string MailAddress = "";
                string Q1Answer = "";
                string Q2Answer = "";
                string Q3Answer = "";
                int JyogaiFlg = 0;

                // SQL クエリ
                string query = "SELECT * FROM Mst01 ORDER BY Col01";

                // 接続を確立し、クエリを実行
                using (OleDbConnection conI = new OleDbConnection(connectionStringI))
                {
                    using (OleDbCommand command = new OleDbCommand(query, conI))
                    {
                        conI.Open();

                        // 出力ＤＢを開く
                        using (SQLiteConnection conO = new SQLiteConnection(SetconnectionStringOutput(connectionStringO)))
                        {
                            conO.Open();
                            //テーブル作成
                            string sql = "create table mstQuestionLevelUp (id int , " +
                                                                          "NameKana varchar(30)," +
                                                                          "NameKanji varchar(20)," +
                                                                          "ZipCode varchar(8)," +
                                                                          "Address varchar(50)," +
                                                                          "TelNo varchar(30)," +
                                                                          "MailAddress varchar(80)," +
                                                                          "Q1Answer varchar(1)," +
                                                                          "Q2Answer varchar(1)," +
                                                                          "Q3Answer varchar(1)," +
                                                                          "JyogaiFlg int," +
                                                                          "PRIMARY KEY(id)" +
                                                                          ")";

                            SQLiteCommand com = new SQLiteCommand(sql, conO);
                            com.ExecuteNonQuery();

                            // データを読み取る
                            using (OleDbDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    // データの処理
                                    // 例えば、reader.GetString(0) などを使ってフィールドの値を取得できます
                                    id = reader.GetInt32(0); // 0 はフィールドのインデックス
                                    NameKana = reader.GetString(1);
                                    NameKanji = reader.GetString(2);
                                    ZipCode = reader.GetString(3);
                                    Address = reader.GetString(4);
                                    TelNo = reader.GetString(5);
                                    MailAddress = reader.GetString(6);
                                    Q1Answer = (reader.GetValue(7) == DBNull.Value) ? "" : reader.GetString(7);
                                    Q2Answer = (reader.GetValue(8) == DBNull.Value) ? "" : reader.GetString(8);
                                    Q3Answer = (reader.GetValue(9) == DBNull.Value) ? "null" : reader.GetString(9);
                                    JyogaiFlg = reader.GetInt32(10);

                                    cnt++;
                                    LblCntQuestionnaireResult.Text = cnt.ToString();
                                    LblCntQuestionnaireResult.Refresh();

                                    //マスタ出力
                                    //テーブル作成
                                    sql = "Insert into mstQuestionLevelUp Values(" + id + "," +
                                                                               "'" + NameKana + "'," +
                                                                               "'" + NameKanji + "'," +
                                                                               "'" + ZipCode + "'," +
                                                                               "'" + Address + "'," +
                                                                               "'" + TelNo + "'," +
                                                                               "'" + MailAddress + "'," +
                                                                               "'" + Q1Answer + "'," +
                                                                               "'" + Q2Answer + "'," +
                                                                               "'" + Q3Answer + "'," +
                                                                                   +JyogaiFlg +
                                                                               ");";

                                    com = new SQLiteCommand(sql, conO);
                                    com.ExecuteNonQuery();

                                }
                            }
                            conO.Close();
                        }
                        conI.Close();
                    }
                }

                return true;
            }

            catch (Exception ex)
            {
                LblResult.Text = ex.Message;
                return false;
            }
        }

        /// <summary>
        //              顧客伝票マスタ(レベルアップ)　移行処理
        /// </summary>
        /// <returns>true:正常終了　false:異常終了</returns>
        private Boolean ProcIkoCustomerLevelUp()
        {
            try
            {
                int cnt = 0;

                int id = 0;
                string CustCd = "";
                string ItemCd = "";
                string TelNo = "";
                string MailAddress = "";
                int JyogaiFlg = 0;

                // SQL クエリ
                string query = "SELECT * FROM Mst02 ORDER BY Col01";

                // 接続を確立し、クエリを実行
                using (OleDbConnection conI = new OleDbConnection(connectionStringI))
                {
                    using (OleDbCommand command = new OleDbCommand(query, conI))
                    {
                        conI.Open();

                        // 出力ＤＢを開く
                        using (SQLiteConnection conO = new SQLiteConnection(SetconnectionStringOutput(connectionStringO)))
                        {
                            conO.Open();
                            //テーブル作成
                            string sql = "create table mstCustomerSlip (id int , " +
                                                                       "CustomerCd varchar(20)," +
                                                                       "ItemCd varchar(30)," +
                                                                       "TelNo varchar(30)," +
                                                                       "MailAddress varchar(80)," +
                                                                       "JyogaiFlg int," +
                                                                       "PRIMARY KEY(id)" +
                                                                       ")";

                            SQLiteCommand com = new SQLiteCommand(sql, conO);
                            com.ExecuteNonQuery();

                            // データを読み取る
                            using (OleDbDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    // データの処理
                                    // 例えば、reader.GetString(0) などを使ってフィールドの値を取得できます
                                    id = reader.GetInt32(0); // 0 はフィールドのインデックス
                                    CustCd = reader.GetString(1);
                                    ItemCd = reader.GetString(2);
                                    TelNo = reader.GetString(3);
                                    MailAddress = reader.GetString(4);
                                    JyogaiFlg = reader.GetInt32(5);

                                    cnt++;
                                    LblCntCustomerInputResult.Text = cnt.ToString();
                                    LblCntCustomerInputResult.Refresh();

                                    //マスタ出力
                                    //テーブル作成
                                    sql = "Insert into mstCustomerSlip Values(" + id + "," +
                                                                            "'" + CustCd + "'," +
                                                                            "'" + ItemCd + "'," +
                                                                            "'" + TelNo + "'," +
                                                                            "'" + MailAddress + "'," +
                                                                                +JyogaiFlg +
                                                                            ");";

                                    com = new SQLiteCommand(sql, conO);
                                    com.ExecuteNonQuery();

                                }
                            }
                            conO.Close();
                        }
                        conI.Close();
                    }
                }

                return true;
            }

            catch (Exception ex)
            {
                LblResult.Text = ex.Message;
                return false;
            }
        }

        /// <summary>
        //              顧客伝票エラーデータ(レベルアップ)　移行処理
        /// </summary>
        /// <returns>true:正常終了　false:異常終了</returns>
        private Boolean ProcIkoCustomerLevelUpErr()
        {
            try
            {
                int cnt = 0;

                int id = 0;
                string CustCd = "";
                string ItemCd = "";
                string TelNo = "";
                string MailAddress = "";
                int JyogaiFlg = 0;

                // SQL クエリ
                string query = "SELECT * FROM Mst02Error ORDER BY Col01";

                // 接続を確立し、クエリを実行
                using (OleDbConnection conI = new OleDbConnection(connectionStringI))
                {
                    using (OleDbCommand command = new OleDbCommand(query, conI))
                    {
                        conI.Open();

                        // 出力ＤＢを開く
                        using (SQLiteConnection conO = new SQLiteConnection(SetconnectionStringOutput(connectionStringO)))
                        {
                            conO.Open();
                            //テーブル作成
                            string sql = "create table mstCustomerSlipError (id int , " +
                                                                            "CustomerCd varchar(20)," +
                                                                            "ItemCd varchar(30)," +
                                                                            "TelNo varchar(30)," +
                                                                            "MailAddress varchar(80)," +
                                                                            "JyogaiFlg int," +
                                                                            "PRIMARY KEY(id)" +
                                                                            ")";

                            SQLiteCommand com = new SQLiteCommand(sql, conO);
                            com.ExecuteNonQuery();

                            // データを読み取る
                            using (OleDbDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    // データの処理
                                    // 例えば、reader.GetString(0) などを使ってフィールドの値を取得できます
                                    id = reader.GetInt32(0); // 0 はフィールドのインデックス
                                    CustCd = reader.GetString(1);
                                    ItemCd = reader.GetString(2);
                                    TelNo = reader.GetString(3);
                                    MailAddress = reader.GetString(4);
                                    JyogaiFlg = reader.GetInt32(5);

                                    cnt++;
                                    LblCntCustomerInputErrResult.Text = cnt.ToString();
                                    LblCntCustomerInputErrResult.Refresh();

                                    //マスタ出力
                                    //テーブル作成
                                    sql = "Insert into mstCustomerSlipError Values(" + id + "," +
                                                                            "'" + CustCd + "'," +
                                                                            "'" + ItemCd + "'," +
                                                                            "'" + TelNo + "'," +
                                                                            "'" + MailAddress + "'," +
                                                                                +JyogaiFlg +
                                                                            ");";

                                    com = new SQLiteCommand(sql, conO);
                                    com.ExecuteNonQuery();

                                }
                            }
                            conO.Close();
                        }
                        conI.Close();
                    }
                }

                return true;
            }

            catch (Exception ex)
            {
                LblResult.Text = ex.Message;
                return false;
            }
        }

        /// <summary>
        //              アンケート入力マスタ(基礎トレ)　移行処理
        /// </summary>
        /// <returns>true:正常終了　false:異常終了</returns>
        private Boolean ProcIkoQuestionKiso()
        {
            try
            {
                int cnt = 0;

                int id = 0;
                string NameKana = "";
                string NameKanji = "";
                string ZipCode = "";
                string Address = "";
                string TelNo = "";
                string MailAddress = "";
                string Q1Answer = "";
                string Q2Answer = "";
                string Q3Answer = "";
                int JyogaiFlg = 0;

                // SQL クエリ
                string query = "SELECT * FROM Mst03 ORDER BY Col01";

                // 接続を確立し、クエリを実行
                using (OleDbConnection conI = new OleDbConnection(connectionStringI))
                {
                    using (OleDbCommand command = new OleDbCommand(query, conI))
                    {
                        conI.Open();

                        // 出力ＤＢを開く
                        using (SQLiteConnection conO = new SQLiteConnection(SetconnectionStringOutput(connectionStringO)))
                        {
                            conO.Open();
                            //テーブル作成
                            string sql = "create table mstQuestionBasic (id int , " +
                                                                        "NameKana varchar(30)," +
                                                                        "NameKanji varchar(20)," +
                                                                        "ZipCode varchar(8)," +
                                                                        "Address varchar(50)," +
                                                                        "TelNo varchar(30)," +
                                                                        "MailAddress varchar(80)," +
                                                                        "Q1Answer varchar(1)," +
                                                                        "Q2Answer varchar(1)," +
                                                                        "Q3Answer varchar(1)," +
                                                                        "JyogaiFlg int," +
                                                                        "PRIMARY KEY(id)" +
                                                                        ")";

                            SQLiteCommand com = new SQLiteCommand(sql, conO);
                            com.ExecuteNonQuery();

                            // データを読み取る
                            using (OleDbDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    // データの処理
                                    // 例えば、reader.GetString(0) などを使ってフィールドの値を取得できます
                                    id = reader.GetInt32(0); // 0 はフィールドのインデックス
                                    NameKana = reader.GetString(1);
                                    NameKanji = reader.GetString(2);
                                    ZipCode = reader.GetString(3);
                                    Address = reader.GetString(4);
                                    TelNo = reader.GetString(5);
                                    MailAddress = reader.GetString(6);
                                    Q1Answer = (reader.GetValue(7) == DBNull.Value) ? "" : reader.GetString(7);
                                    Q2Answer = (reader.GetValue(8) == DBNull.Value) ? "" : reader.GetString(8);
                                    Q3Answer = (reader.GetValue(9) == DBNull.Value) ? "" : reader.GetString(9);
                                    JyogaiFlg = reader.GetInt32(10);

                                    cnt++;
                                    LblCntQuestionnaire2Result.Text = cnt.ToString();
                                    LblCntQuestionnaire2Result.Refresh();

                                    //マスタ出力
                                    //テーブル作成
                                    sql = "Insert into mstQuestionBasic Values(" + id + "," +
                                                                             "'" + NameKana + "'," +
                                                                             "'" + NameKanji + "'," +
                                                                             "'" + ZipCode + "'," +
                                                                             "'" + Address + "'," +
                                                                             "'" + TelNo + "'," +
                                                                             "'" + MailAddress + "'," +
                                                                             "'" + Q1Answer + "'," +
                                                                             "'" + Q2Answer + "'," +
                                                                             "'" + Q3Answer + "'," +
                                                                                 +JyogaiFlg +
                                                                             ");";

                                    com = new SQLiteCommand(sql, conO);
                                    com.ExecuteNonQuery();

                                }
                            }
                            conO.Close();
                        }
                        conI.Close();
                    }
                }

                return true;
            }



            catch (Exception ex)
            {
                LblResult.Text = ex.Message;
                return false;
            }
        }

        /// <summary>
        //              顧客伝票マスタ(基礎トレ)　移行処理
        /// </summary>
        /// <returns>true:正常終了　false:異常終了</returns>
        private Boolean ProcIkoCustomerCheck()
        {
            try
            {
                int cnt = 0;

                int id = 0;
                string CustCd = "";
                string ItemCd = "";
                string TelNo = "";
                string MailAddress = "";
                int JyogaiFlg = 0;

                // SQL クエリ
                string query = "SELECT * FROM Mst04 ORDER BY Col01";

                // 接続を確立し、クエリを実行
                using (OleDbConnection conI = new OleDbConnection(connectionStringI))
                {
                    using (OleDbCommand command = new OleDbCommand(query, conI))
                    {
                        conI.Open();

                        // 出力ＤＢを開く
                        using (SQLiteConnection conO = new SQLiteConnection(SetconnectionStringOutput(connectionStringO)))
                        {
                            conO.Open();
                            //テーブル作成
                            string sql = "create table mstCustomerSlipBasic (id int , " +
                                                                            "CustomerCd varchar(20)," +
                                                                            "ItemCd varchar(30)," +
                                                                            "TelNo varchar(30)," +
                                                                            "MailAddress varchar(80)," +
                                                                            "JyogaiFlg int," +
                                                                            "PRIMARY KEY(id)" +
                                                                            ")";

                            SQLiteCommand com = new SQLiteCommand(sql, conO);
                            com.ExecuteNonQuery();

                            // データを読み取る
                            using (OleDbDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    // データの処理
                                    // 例えば、reader.GetString(0) などを使ってフィールドの値を取得できます
                                    id = reader.GetInt32(0); // 0 はフィールドのインデックス
                                    CustCd = reader.GetString(1);
                                    ItemCd = reader.GetString(2);
                                    TelNo = reader.GetString(3);
                                    MailAddress = reader.GetString(4);
                                    JyogaiFlg = reader.GetInt32(5);

                                    cnt++;
                                    LblCntCustomerCheckResult.Text = cnt.ToString();
                                    LblCntCustomerCheckResult.Refresh();

                                    //マスタ出力
                                    //テーブル作成
                                    sql = "Insert into mstCustomerSlipBasic Values(" + id + "," +
                                                                                 "'" + CustCd + "'," +
                                                                                 "'" + ItemCd + "'," +
                                                                                 "'" + TelNo + "'," +
                                                                                 "'" + MailAddress + "'," +
                                                                                     +JyogaiFlg +
                                                                                 ");";

                                    com = new SQLiteCommand(sql, conO);
                                    com.ExecuteNonQuery();

                                }
                            }
                            conO.Close();
                        }
                        conI.Close();
                    }
                }

                return true;
            }

            catch (Exception ex)
            {
                LblResult.Text = ex.Message;
                return false;
            }
        }

        /// <summary>
        //              顧客伝票エラーデータ(基礎トレ)　移行処理
        /// </summary>
        /// <returns>true:正常終了　false:異常終了</returns>
        private Boolean ProcIkoCustomerCheckErr()
        {
            try
            {
                int cnt = 0;

                int id = 0;
                string CustCd = "";
                string ItemCd = "";
                string TelNo = "";
                string MailAddress = "";
                int JyogaiFlg = 0;

                // SQL クエリ
                string query = "SELECT * FROM Mst04Error ORDER BY Col01";

                // 接続を確立し、クエリを実行
                using (OleDbConnection conI = new OleDbConnection(connectionStringI))
                {
                    using (OleDbCommand command = new OleDbCommand(query, conI))
                    {
                        conI.Open();

                        // 出力ＤＢを開く
                        using (SQLiteConnection conO = new SQLiteConnection(SetconnectionStringOutput(connectionStringO)))
                        {
                            conO.Open();
                            //テーブル作成
                            string sql = "create table mstCustomerSlipErrorBasic (id int , " +
                                                                                 "CustomerCd varchar(20)," +
                                                                                 "ItemCd varchar(30)," +
                                                                                 "TelNo varchar(30)," +
                                                                                 "MailAddress varchar(80)," +
                                                                                 "JyogaiFlg int," +
                                                                                 "PRIMARY KEY(id)" +
                                                                                 ")";

                            SQLiteCommand com = new SQLiteCommand(sql, conO);
                            com.ExecuteNonQuery();

                            // データを読み取る
                            using (OleDbDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    // データの処理
                                    // 例えば、reader.GetString(0) などを使ってフィールドの値を取得できます
                                    id = reader.GetInt32(0); // 0 はフィールドのインデックス
                                    CustCd = reader.GetString(1);
                                    ItemCd = reader.GetString(2);
                                    TelNo = reader.GetString(3);
                                    MailAddress = reader.GetString(4);
                                    JyogaiFlg = reader.GetInt32(5);

                                    cnt++;
                                    LblCntCustomerCheckErrResult.Text = cnt.ToString();
                                    LblCntCustomerCheckErrResult.Refresh();

                                    //マスタ出力
                                    //テーブル作成
                                    sql = "Insert into mstCustomerSlipErrorBasic Values(" + id + "," +
                                                                                      "'" + CustCd + "'," +
                                                                                      "'" + ItemCd + "'," +
                                                                                      "'" + TelNo + "'," +
                                                                                      "'" + MailAddress + "'," +
                                                                                          +JyogaiFlg +
                                                                                      ");";

                                    com = new SQLiteCommand(sql, conO);
                                    com.ExecuteNonQuery();

                                }
                            }
                            conO.Close();
                        }
                        conI.Close();
                    }
                }

                return true;
            }

            catch (Exception ex)
            {
                LblResult.Text = ex.Message;
                return false;
            }
        }

        /// <summary>
        //              iniファイル　出力処理
        /// </summary>
        private void SetIniFile()
        {
            // 文字コードを指定
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance); // memo: Shift-JISを扱うためのおまじない
            Encoding enc = Encoding.GetEncoding("Shift_JIS");

            // ファイルを開く
            StreamWriter writer = new StreamWriter(Application.StartupPath + @"\LetsTry04.ini", false, enc);

            // テキストを書き込む
            writer.WriteLine(LblOutPath.Text);

            // ファイルを閉じる
            writer.Close();
        }

        /// <summary>
        //              移行元ＭＤＢ接続文字列セット
        /// </summary>
        /// <param name="fPath">データベースフルパス</param>
        /// <returns>MDB接続文字列</returns>
        private string SetconnectionStringInput(string fPath)
        {
            return @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fPath + @";Jet OLEDB:Database Password=jeed;";
        }

        /// <summary>
        //              移行先ＭＤＢ接続文字列セット
        /// </summary>
        /// <param name="con">コネクション文字列</param>
        /// <returns>SQLite接続文字列</returns>
        private string SetconnectionStringOutput(string con)
        {
            return "Data Source=" + con + ";Version=3;";
        }

        /// <summary>
        //              移行先ＭＤＢパスセット
        /// </summary>
        /// <param name="fPath">データベースフルパス</param>
        /// <returns>SQLiteデータベース名フルパス</returns>
        private string SetPathStringOutput(string fPath)
        {
            return fPath + @"\LetsTry04.mst";
        }

    }
}

