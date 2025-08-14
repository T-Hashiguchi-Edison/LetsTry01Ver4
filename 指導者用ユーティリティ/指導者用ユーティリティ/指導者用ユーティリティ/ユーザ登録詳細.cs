using System.Data.SQLite;
using System.Text;
using System.Text.RegularExpressions;


namespace 指導者用ユーティリティ
{
    public partial class Frmユーザ登録詳細 : Form
    {
        // SqLite ファイルへの接続文字列
        private string connectionStringO = "";
        private int setId = -1;                     //登録/更新用ID
        private Boolean InsSw = false;              //登録処理判定

        /// <summary>
        //              Initialize
        /// </summary>
        /// <param name="id">ユーザID</param>
        public Frmユーザ登録詳細(int id)
        {
            InitializeComponent();

            setId = id;
            InsSw = (id == -1);

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
            //［Alt］+［F］が押されたらキャッチ(フリガナ)
            if (keyData == (Keys.F | Keys.Alt))
            {
                TxtShiKana.Focus();
            }
            //［Alt］+［N］が押されたらキャッチ(氏名)
            if (keyData == (Keys.N | Keys.Alt))
            {
                TxtShiKanji.Focus();
            }

            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        //              Form　Load 
        /// </summary>
        private void Frmユーザ登録詳細_Load(object sender, EventArgs e)
        {
            // DBファイルの格納パス取得
            if (System.IO.File.Exists(Application.StartupPath + @"\LetsTry04.ini"))
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance); // memo: Shift-JISを扱うためのおまじない
                StreamReader sr = new StreamReader(Application.StartupPath + @"\LetsTry04.ini", Encoding.GetEncoding("Shift_JIS"));
                connectionStringO = SetPathStringOutput(sr.ReadLine());
                //データ取得
                getUserData(setId);
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
        //              登録ボタン　Click
        /// </summary>
        private void BtnOk_Click(object sender, EventArgs e)
        {
            try
            {
                // SQL クエリ
                string sql = "";
                SQLiteCommand com;

                //入力チェック
                if (CheckInput())
                {
                    // データＤＢを開く
                    using (SQLiteConnection con = new SQLiteConnection(SetconnectionStringOutput(connectionStringO)))
                    {
                        con.Open();

                        if (InsSw)                                                               //新規登録時
                        {
                            //ユーザマスタを登録する
                            sql = "Insert into ユーザマスタ Values(" + setId + "," +
                                                                 "'" + TxtShiKanji.Text + "'," +
                                                                 "'" + TxtMeiKanji.Text + "'," +
                                                                 "'" + TxtShiKana.Text + "'," +
                                                                 "'" + TxtMeiKana.Text + "'," +
                                                                       0 + "," +
                                                                       0 + "," +
                                                                       0 + "," +
                                                                       "datetime('now', 'localtime')," +
                                                                       "datetime('now', 'localtime')," +
                                                                     0 +
                                                                 ");";

                            com = new SQLiteCommand(sql, con);
                            com.ExecuteNonQuery();
                        }
                        else                                                                        //編集時
                        {
                            //ユーザマスタを更新する
                            sql = "Update ユーザマスタ SET UserShiKanji = '" + TxtShiKanji.Text + "'," +
                                                          "UserMeiKanji = '" + TxtMeiKanji.Text + "'," +
                                                          "UserShiKana  = '" + TxtShiKana.Text + "'," +
                                                          "UserMeiKana  = '" + TxtMeiKana.Text + "'," +
                                                          "UpdDate      = datetime('now', 'localtime') " +
                                                          "Where Id = " + setId.ToString() + ";";

                            com = new SQLiteCommand(sql, con);
                            com.ExecuteNonQuery();
                        }
                        con.Close();
                    }
                    this.Dispose();
                    this.Close();
                }
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
        //              ユーザマスタ　取得処理
        /// </summary>
        /// <param name="id">ユーザID</param>
        /// <returns>true:正常終了　false:異常終了</returns>
        private Boolean getUserData(int id)
        {
            try
            {
                string NameShiKanji = "";
                string NameMeiKanji = "";
                string NameShiKana = "";
                string NameMeiKana = "";

                // SQL クエリ
                string sql = "";

                // データＤＢを開く
                using (SQLiteConnection con = new SQLiteConnection(SetconnectionStringOutput(connectionStringO)))
                {
                    con.Open();

                    if (InsSw)                                                               //新規登録時
                    {
                        sql = "SELECT IFNULL(MAX(id),0) From ユーザマスタ";

                        using (SQLiteCommand command = new SQLiteCommand(sql, con))
                        {
                            using (SQLiteDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    // データの処理
                                    setId = reader.GetInt32(0) + 1;
                                }
                            }
                        }
                    }
                    else                                                                        //編集時
                    {
                        //ユーザマスタを取得して、表示する
                        sql = "SELECT * From ユーザマスタ Where id = " + id.ToString();

                        using (SQLiteCommand command = new SQLiteCommand(sql, con))
                        {
                            using (SQLiteDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    // データの処理
                                    // 例えば、reader.GetString(0) などを使ってフィールドの値を取得できます
                                    NameShiKanji = reader.GetString(1);
                                    NameMeiKanji = reader.GetString(2);
                                    NameShiKana = reader.GetString(3);
                                    NameMeiKana = reader.GetString(4);
                                }
                            }
                        }
                    }
                    con.Close();
                }

                //データ表示
                TxtShiKana.Text = NameShiKana;
                TxtMeiKana.Text = NameMeiKana;
                TxtShiKanji.Text = NameShiKanji;
                TxtMeiKanji.Text = NameMeiKanji;

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
        //              入力値チェック
        /// </summary>
        /// <returns>true:ＯＫ　false:入力エラー</returns>
        private Boolean CheckInput()
        {
            //フリガナ姓
            if (TxtShiKana.Text != "")
            {
                //全角カナチェック
                if (!IsZenKana(TxtShiKana.Text))
                {
                    MessageBox.Show("フリガナは全角カタカナで入力してください。", "入力エラー");
                    TxtShiKana.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("フリガナを入力してください。", "入力エラー");
                TxtShiKana.Focus();
                return false;
            }

            //フリガナ名
            if (TxtMeiKana.Text != "")
            {
                //全角カナチェック
                if (!IsZenKana(TxtMeiKana.Text))
                {
                    MessageBox.Show("フリガナは全角カタカナで入力してください。", "入力エラー");
                    TxtMeiKana.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("フリガナを入力してください。", "入力エラー");
                TxtMeiKana.Focus();
                return false;
            }

            //氏名姓
            if (TxtShiKanji.Text != "")
            {
                //全角チェック
                if (!IsZenkaku(TxtShiKanji.Text))
                {
                    MessageBox.Show("氏名は全角(スペース以外)で入力してください。", "入力エラー");
                    TxtShiKanji.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("氏名を入力してください。", "入力エラー");
                TxtShiKanji.Focus();
                return false;
            }

            //氏名名
            if (TxtMeiKanji.Text != "")
            {
                //全角チェック
                if (!IsZenkaku(TxtMeiKanji.Text))
                {
                    MessageBox.Show("氏名は全角(スペース以外)で入力してください。", "入力エラー");
                    TxtMeiKanji.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("氏名を入力してください。", "入力エラー");
                TxtMeiKanji.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        ///             全角カナチェック
        /// </summary>
        /// <param name="str">対象文字列</param>
        /// <returns>true:全角カナのみ　false:全角カナ以外を含む</returns>
        public static bool IsZenKana(string str)
        {
            // nullの場合はfalseを返す
            if (str == null)
            {
                return false;
            }

            // 全角カナチェック
            return Regex.IsMatch(str, @"^[\u30a0-\u30ff]*$");
        }

        /// <summary>
        ///             全角チェック
        /// </summary>
        /// <param name="str">対象文字列</param>
        /// <returns>true:全角のみ　false:全角以外を含む</returns>
        public static bool IsZenkaku(string str)
        {
            // nullの場合はfalseを返す
            if (str == null)
            {
                return false;
            }

            // 全角チェック
            return !Regex.IsMatch(str, @"[ -~｡-ﾟ　]");
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

