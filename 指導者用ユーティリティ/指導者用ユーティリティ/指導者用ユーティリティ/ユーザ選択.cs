using System.Data.SQLite;
using System.Text;

namespace 指導者用ユーティリティ
{
    public partial class Frmユーザ選択 : Form
    {
        // SqLite ファイルへの接続文字列
        private string connectionString = "";

        /// <summary>
        //              ユーザ選択
        /// </summary>
        public Frmユーザ選択()
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
            //［Alt］+［L］が押されたらキャッチ(ユーザーリストへ)
            if (keyData == (Keys.L | Keys.Alt))
            {
                DgvUserMst.Focus();
            }
            //［Alt］+［C］が押されたらキャッチ(ユーザー比較)
            if (keyData == (Keys.C | Keys.Alt))
            {
                BtnComparison.PerformClick();
            }
            //［Alt］+［N］が押されたらキャッチ(次へ)
            if (keyData == (Keys.N | Keys.Alt))
            {
                BtnNext.PerformClick();
            }

            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        //              Form　Load 
        /// </summary>
        private void Frmユーザ選択_Load(object sender, EventArgs e)
        {
            // DB ファイルへの接続文字列
            if (System.IO.File.Exists(Application.StartupPath + @"\LetsTry04.ini"))
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                StreamReader sr = new StreamReader(Application.StartupPath + @"\LetsTry04.ini", Encoding.GetEncoding("Shift_JIS"));
                connectionString = SetPathString(sr.ReadLine());
                //データ取得
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
        //              ユーザー比較　Click
        /// </summary>
        private void BtnComparison_Click(object sender, EventArgs e)
        {
            BtnCancel.Enabled = false;
            BtnNext.Enabled = false;

            //非表示する
            this.Visible = false;

            //ユーザー比較を表示する。
            Frmユーザ比較 frm = new Frmユーザ比較();
            frm.ShowDialog();

            this.Visible = true;
            BtnCancel.Enabled = true;
            BtnNext.Enabled = true;

        }

        /// <summary>
        //              次へ　Click
        /// </summary>
        private void BtnNext_Click(object sender, EventArgs e)
        {
            BtnCancel.Enabled = false;

            //非表示する
            this.Visible = false;

            //ユーザメニューを表示する。
            int UserId = (int)DgvUserMst.CurrentRow.Cells[0].Value;
            string UserName = (string)DgvUserMst.CurrentRow.Cells[1].Value;

            Frm試行履歴選択 frm = new Frm試行履歴選択(UserId, UserName);
            frm.ShowDialog();

            //表示する
            this.Visible = true;
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
                DgvUserMst.CurrentRow.Cells[1].Selected = true;
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
                DgvUserMst.CurrentRow.Cells[1].Selected = true;
                BtnNext.PerformClick();
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
                BtnNext.PerformClick();
                //フォーカスが下に移動しないようにする
                e.Handled = true;
            }

            //Tab Key
            if (e.KeyCode == Keys.Tab)
            {
                //フォーカス移動
                BtnComparison.Focus();
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
                using (SQLiteConnection con = new SQLiteConnection(SetconnectionString(connectionString)))
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
                    }
                    con.Close();
                }

                BtnComparison.Enabled = (cnt > 0);
                BtnNext.Enabled = (cnt > 0);

                LblCnt.Text = cnt.ToString("#,0");
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
