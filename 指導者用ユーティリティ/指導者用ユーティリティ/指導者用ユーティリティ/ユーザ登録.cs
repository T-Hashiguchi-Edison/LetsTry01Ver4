using System.Data.SQLite;
using System.Text;


namespace 指導者用ユーティリティ
{
    public partial class Frmユーザ登録 : Form
    {
        // SqLite ファイルへの接続文字列
        private string connectionStringO = "";

        /// <summary>
        //              Initialize
        /// </summary>
        public Frmユーザ登録()
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

            //データグリッドビュー行挿入/削除　禁止
            DgvUserMst.AllowUserToAddRows = false;
            DgvUserMst.AllowUserToDeleteRows = false;

            //データグリッドビュー列の幅、行の高さの変更　禁止
            DgvUserMst.AllowUserToResizeColumns = false;
            DgvUserMst.AllowUserToResizeRows = false;

            //データグリッドビュー罫線をなくす
            DgvUserMst.CellBorderStyle = DataGridViewCellBorderStyle.None;

            //データグリッドビュー並べ替え　禁止
            foreach (DataGridViewColumn c in DgvUserMst.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        /// <summary>
        //              ショートカットキー判定　Key Down
        /// </summary>
        /// <param name="keyData">キー情報</param>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            //［Alt］+［N］が押されたらキャッチ(新規登録)
            if (keyData == (Keys.N | Keys.Alt))
            {
                BtnIns.PerformClick();
            }
            //［Alt］+［E］が押されたらキャッチ(編集)
            if (keyData == (Keys.E | Keys.Alt))
            {
                BtnUpd.PerformClick();
            }
            //［Alt］+［D］が押されたらキャッチ(削除)
            if (keyData == (Keys.D | Keys.Alt))
            {
                BtnDel.PerformClick();
            }

            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        //              Form　Load 
        /// </summary>
        private void Frmユーザ登録_Load(object sender, EventArgs e)
        {
            // DBファイルの格納パス取得
            if (System.IO.File.Exists(Application.StartupPath + @"\LetsTry04.ini"))
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance); // memo: Shift-JISを扱うためのおまじない
                StreamReader sr = new StreamReader(Application.StartupPath + @"\LetsTry04.ini", Encoding.GetEncoding("Shift_JIS"));
                connectionStringO = SetPathStringOutput(fPath: sr.ReadLine());
                //ユーザマスタ取得
                getUserMst();
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
        //              新規作成ボタン　Click
        /// </summary>
        private void BtnIns_Click(object sender, EventArgs e)
        {
            BtnIns.Enabled = false;
            BtnUpd.Enabled = false;
            BtnDel.Enabled = false;
            BtnCancel.Enabled = false;

            Frmユーザ登録詳細 frm = new Frmユーザ登録詳細(-1);
            frm.ShowDialog();

            //ユーザマスタ取得
            getUserMst();

            BtnIns.Enabled = true;
            if (LblMstCnt.Text == "0")
            {
                BtnUpd.Enabled = false;
                BtnDel.Enabled = false;
            }
            else
            {
                BtnUpd.Enabled = true;
                BtnDel.Enabled = true;
            }
            BtnCancel.Enabled = true;
        }

        /// <summary>
        //              編集ボタン　Click
        /// </summary>
        private void BtnUpd_Click(object sender, EventArgs e)
        {
            BtnIns.Enabled = false;
            BtnUpd.Enabled = false;
            BtnDel.Enabled = false;
            BtnCancel.Enabled = false;

            int id = (int)DgvUserMst.CurrentRow.Cells[0].Value;
            Frmユーザ登録詳細 frm = new Frmユーザ登録詳細(id);
            frm.ShowDialog();

            //ユーザマスタ取得
            getUserMst();

            BtnIns.Enabled = true;
            if (LblMstCnt.Text == "0")
            {
                BtnUpd.Enabled = false;
                BtnDel.Enabled = false;
            }
            else
            {
                BtnUpd.Enabled = true;
                BtnDel.Enabled = true;
            }
            BtnCancel.Enabled = true;
        }

        /// <summary>
        //              削除ボタン　Click
        /// </summary>
        private void BtnDel_Click(object sender, EventArgs e)
        {
            // SQL クエリ
            string sql = "";
            SQLiteCommand com;

            BtnIns.Enabled = false;
            BtnUpd.Enabled = false;
            BtnDel.Enabled = false;
            BtnCancel.Enabled = false;

            int id = (int)DgvUserMst.CurrentRow.Cells[0].Value;

            // メッセージボックスを表示
            DialogResult result = MessageBox.Show("ユーザ登録名を削除してよろしいですか？" + "\n\n" + DgvUserMst.CurrentRow.Cells[2].Value,
                                                  "ユーザマスタ削除", MessageBoxButtons.YesNo);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    // データＤＢを開く
                    using (SQLiteConnection con = new SQLiteConnection(SetconnectionStringOutput(connectionStringO)))
                    {
                        con.Open();

                        //ユーザマスタを更新する
                        sql = "Update ユーザマスタ SET   DelFlg  = 1," +
                                                        "UpdDate = datetime('now', 'localtime') " +
                                                  "WHERE Id = " + id.ToString() + ";";

                        com = new SQLiteCommand(sql, con);
                        com.ExecuteNonQuery();
                        con.Close();
                    }
                }

                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message, "エラー");
                    //終了
                    this.Dispose();
                    this.Close();
                }

            }

            //ユーザマスタ取得
            getUserMst();

            BtnIns.Enabled = true;
            if (LblMstCnt.Text == "0")
            {
                BtnUpd.Enabled = false;
                BtnDel.Enabled = false;
            }
            else
            {
                BtnUpd.Enabled = true;
                BtnDel.Enabled = true;
            }
            BtnCancel.Enabled = true;
        }

        /// <summary>
        //              一覧　Click
        /// </summary>
        private void DgvUserMst_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                //ヘッダークリックは無視する
            }
            else
            {
                DgvUserMst.CurrentRow.Cells[0].Selected = true;
            }
        }

        /// <summary>
        //              一覧　DoubleClick
        /// </summary>
        private void DgvUserMst_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                //ヘッダークリックは無視する
            }
            else
            {
                DgvUserMst.CurrentRow.Cells[0].Selected = true;
                BtnUpd.PerformClick();
            }
        }

        /// <summary>
        //              一覧　KeyDown
        /// </summary>
        private void DgvUserMst_KeyDown(object sender, KeyEventArgs e)
        {
            //Enter Key
            if (e.KeyCode == Keys.Enter)
            {
                //編集ボタンClick
                BtnUpd.PerformClick();
                //フォーカスが下に移動しないようにする
                e.Handled = true;
            }

            //Tab Key
            if (e.KeyCode == Keys.Tab)
            {
                //↓キーを送信する
                SendKeys.Send("{DOWN}");
                //フォーカスが横に移動しないようにする
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
        //              キャンセルボタン　Click
        /// </summary>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        /// <summary>
        //              ユーザマスタ　一覧取得処理
        /// </summary>
        /// <returns>true:正常終了　false:異常終了</returns>
        private Boolean getUserMst()
        {
            try
            {
                int cnt = 0;

                int id = 0;
                string NameShiKanji = "";
                string NameMeiKanji = "";
                string NameShiKana = "";
                string NameMeiKana = "";

                // SQL クエリ
                string sql = "";

                //一覧クリア
                DgvUserMst.Rows.Clear();

                // データＤＢを開く
                using (SQLiteConnection con = new SQLiteConnection(SetconnectionStringOutput(connectionStringO)))
                {
                    con.Open();

                    //マスタ作成
                    sql = "CREATE TABLE IF NOT EXISTS ユーザマスタ(id int , " +
                                                                  "UserShiKanji varchar(60)," +
                                                                  "UserMeiKanji varchar(60)," +
                                                                  "UserShiKana  varchar(60)," +
                                                                  "UserMeiKana  varchar(60)," +
                                                                  "Start_No1    int," +
                                                                  "Start_No2    int," +
                                                                  "Start_No3    int," +
                                                                  "InsDate      datetime," +
                                                                  "UpdDate      datetime," +
                                                                  "DelFlg       int," +
                                                                  "PRIMARY KEY(id)" +
                                                                  ")";

                    SQLiteCommand com = new SQLiteCommand(sql, con);
                    com.ExecuteNonQuery();

                    //ユーザマスタを取得して、表示する
                    sql = "SELECT * From ユーザマスタ WHERE DelFlg = 0 Order by id DESC";

                    using (SQLiteCommand command = new SQLiteCommand(sql, con))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // データの処理
                                id = reader.GetInt32(0);
                                NameShiKanji = reader.GetString(1);
                                NameMeiKanji = reader.GetString(2);
                                NameShiKana = reader.GetString(3);
                                NameMeiKana = reader.GetString(4);

                                DgvUserMst.Rows.Add(id, NameShiKanji + "　" + NameMeiKanji, NameShiKana + "　" + NameMeiKana);

                                cnt++;
                            }
                        }
                        LblMstCnt.Text = cnt.ToString();
                        if (cnt == 0)
                        {
                            BtnIns.Enabled = true;
                            BtnUpd.Enabled = false;
                            BtnDel.Enabled = false;
                        }
                        else
                        {
                            BtnIns.Enabled = true;
                            BtnUpd.Enabled = true;
                            BtnDel.Enabled = true;
                            DgvUserMst.Rows[0].Selected = true;
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

