using System.Data.SQLite;
using System.Text;

namespace パソコンデータ入力
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

            //自分自身のバージョン情報を取得する
            System.Diagnostics.FileVersionInfo ver = System.Diagnostics.FileVersionInfo.GetVersionInfo(
                                                                        System.Reflection.Assembly.GetExecutingAssembly().Location);
            this.Text = "やってみよう！パソコンデータ入力 Ver" + ver.FileVersion;
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
        //              次へ　Click
        /// </summary>
        private void BtnNext_Click(object sender, EventArgs e)
        {
            BtnCancel.Enabled = false;

            //非表示する
            this.Visible = false;

            //ユーザメニューを表示する。
            int id = (int)DgvUserMst.CurrentRow.Cells[0].Value;
            string NameSi = (string)DgvUserMst.CurrentRow.Cells[3].Value;
            string NameMei = (string)DgvUserMst.CurrentRow.Cells[4].Value;

            FormCommon.Form_IF prm = new FormCommon.Form_IF();
            prm.Initialize(id, NameSi, NameMei);
            Frmユーザメニュー frm = new Frmユーザメニュー(prm);
            frm.ShowDialog();

            BtnCancel.Enabled = true;

            //終了する
            this.Dispose();
            this.Close();
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

                                DgvUserMst.Rows.Add(id, NameShiKanji + "　" + NameMeiKanji, NameShiKana + "　" + NameMeiKana, NameShiKanji, NameMeiKanji);

                                cnt++;
                            }
                        }
                    }
                    con.Close();
                }
                if (cnt == 0)
                {
                    MessageBox.Show("管理者に連絡し、ユーザ登録を行ってください。");
                    BtnNext.Enabled = false;
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
