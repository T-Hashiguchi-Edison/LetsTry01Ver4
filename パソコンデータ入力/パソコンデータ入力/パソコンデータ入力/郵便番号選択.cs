namespace パソコンデータ入力
{
    public partial class Frm郵便番号選択 : Form
    {
        /// <summary>
        //              郵便番号選択
        /// </summary>
        /// <param name="PostNo">郵便番号</param>
        /// <param name="AddressList">住所一覧情報</param>
        public Frm郵便番号選択(String PostNo, List<String> AddressList)
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
            DgvAddress.AllowUserToAddRows = false;
            DgvAddress.AllowUserToDeleteRows = false;

            //データグリッドビュー列の幅、行の高さの変更　禁止
            DgvAddress.AllowUserToResizeColumns = false;
            DgvAddress.AllowUserToResizeRows = false;

            //データグリッドビュー罫線をなくす
            DgvAddress.CellBorderStyle = DataGridViewCellBorderStyle.None;

            //データグリッドビュー並べ替え　禁止
            foreach (DataGridViewColumn c in DgvAddress.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;


            //自分自身のバージョン情報を取得する
            System.Diagnostics.FileVersionInfo ver = System.Diagnostics.FileVersionInfo.GetVersionInfo(
                                                                        System.Reflection.Assembly.GetExecutingAssembly().Location);
            this.Text = "やってみよう！パソコンデータ入力 Ver" + ver.FileVersion;

            //データ表示
            setAddressList(PostNo, AddressList);
        }

        /// <summary>
        //              Form　Load
        /// </summary>
        private void Frm郵便番号選択_Load(object sender, EventArgs e)
        {
            //特に処理なし
        }

        /// <summary>
        //              ＯＫ　Click
        /// </summary>
        private void BtnOK_Click(object sender, EventArgs e)
        {
            BtnCancel.Enabled = false;

            //非表示する
            this.Visible = false;

            //住所を表示する。
            共通プロパティ.SelectedAddress = DgvAddress.CurrentRow.Cells[0].Value.ToString();

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
        private void DgvAddress_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                //ヘッダークリックは無視する
            }
            else
            {
                DgvAddress.CurrentRow.Cells[0].Selected = true;
            }
        }

        /// <summary>
        //              一覧　DoubleClick
        /// </summary>
        private void DgvAddress_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                //ヘッダークリックは無視する
            }
            else
            {
                DgvAddress.CurrentRow.Cells[0].Selected = true;
                BtnOK.PerformClick();
            }
        }

        /// <summary>
        //              一覧　KeyDown
        /// </summary>
        private void DgvAddress_KeyDown(object sender, KeyEventArgs e)
        {
            //Enter Key
            if (e.KeyCode == Keys.Enter)
            {
                //編集ボタンClick
                BtnOK.PerformClick();
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
        //              郵便番号一覧表示処理
        /// </summary>
        /// <returns>true:正常終了　false:異常終了</returns>
        private Boolean setAddressList(String PostNo, List<String> AddressList)
        {
            //一覧クリア
            DgvAddress.Rows.Clear();

            LblPostNo.Text = PostNo;
            LblKensu.Text = AddressList.Count.ToString();
            foreach (var Address in AddressList)
            {
                DgvAddress.Rows.Add(Address);
            }
            return true;
        }

    }
}
