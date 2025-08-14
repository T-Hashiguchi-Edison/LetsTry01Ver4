using System.Runtime.InteropServices;

namespace パソコンデータ入力
{
    public partial class Frmユーザメニュー : Form
    {
        private FormCommon.Form_IF ifc = new FormCommon.Form_IF();

        // APIを呼び出すため、対象のＤＬＬをインポート
        [DllImport("USER32.DLL")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, UInt32 bRevert);

        [DllImport("USER32.DLL")]
        private static extern UInt32 RemoveMenu(IntPtr hMenu, UInt32 nPosition, UInt32 wFlags);

        // 定数定義
        private const UInt32 SC_CLOSE = 0x0000F060;
        private const UInt32 MF_BYCOMMAND = 0x00000000;

        /// <summary>
        //              ユーザメニュー
        /// </summary>
        /// <param name="prm">画面引継ぎ情報</param>
        public Frmユーザメニュー(FormCommon.Form_IF prm)
        {
            InitializeComponent();

            //中央に配置する
            this.StartPosition = FormStartPosition.CenterScreen;

            //フォームの最大化ボタンの表示、非表示を切り替える
            this.MaximizeBox = !this.MaximizeBox;
            //フォームの最小化ボタンの表示、非表示を切り替える
            //this.MinimizeBox = !this.MinimizeBox;

            //ユーザーがサイズを変更できないようにする
            //最大化、最小化はできる
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //フォームが最大化されないようにする
            this.MaximizeBox = false;
            //フォームが最小化されないようにする
            //this.MinimizeBox = false;

            // コントロールボックスの［閉じる］ボタンの無効化
            IntPtr hMenu = GetSystemMenu(this.Handle, 0); // システムメニュー（フォームの）ハンドル取得する
            RemoveMenu(hMenu, SC_CLOSE, MF_BYCOMMAND);    // [×]ボタンを無効化する。

            //自分自身のバージョン情報を取得する
            System.Diagnostics.FileVersionInfo ver = System.Diagnostics.FileVersionInfo.GetVersionInfo(
                                                                        System.Reflection.Assembly.GetExecutingAssembly().Location);
            this.Text = "やってみよう！パソコンデータ入力 Ver" + ver.FileVersion;

            //フォームインターフェース
            ifc.Copy(prm);
        }

        /// <summary>
        //              ショートカットキー判定　Key Down
        /// </summary>
        /// <param name="keyData">キー情報</param>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            //［Alt］+［1］が押されたらキャッチ(アンケート入力)
            if ((keyData == (Keys.D1 | Keys.Alt)) || (keyData == (Keys.NumPad1 | Keys.Alt)))
            {
                BtnQuestion.PerformClick();
            }
            //［Alt］+［2］が押されたらキャッチ(顧客伝票修正)
            if ((keyData == (Keys.D2 | Keys.Alt)) || (keyData == (Keys.NumPad2 | Keys.Alt)))
            {
                BtnCustomer.PerformClick();
            }
            //［Alt］+［3］が押されたらキャッチ(顧客伝票チェック)
            if ((keyData == (Keys.D3 | Keys.Alt)) || (keyData == (Keys.NumPad3 | Keys.Alt)))
            {
                BtnCustomerCheck.PerformClick();
            }
            //［Alt］+［4］が押されたらキャッチ(終了)
            if ((keyData == (Keys.D4 | Keys.Alt)) || (keyData == (Keys.NumPad4 | Keys.Alt)))
            {
                BtnCancel.PerformClick();
            }

            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        //              Form　Load
        /// </summary>
        private void Frmユーザメニュー_Load(object sender, EventArgs e)
        {
            //特に処理なし
        }

        /// <summary>
        //              アンケート入力　Click
        /// </summary>
        private void BtnQuestion_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            ifc.Mode = FormCommon.Mode.アンケート入力;
            Frmコース選択 frm = new Frmコース選択(ifc);
            frm.ShowDialog();

            共通プロパティ.ReturnMenu = false;

            this.Visible = true;
        }

        /// <summary>
        //              顧客伝票修正　Click
        /// </summary>
        private void BtnCustomer_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            ifc.Mode = FormCommon.Mode.顧客伝票修正;
            Frmコース選択 frm = new Frmコース選択(ifc);
            frm.ShowDialog();

            共通プロパティ.ReturnMenu = false;

            this.Visible = true;
        }

        /// <summary>
        //              顧客伝票ミスチェック　Click
        /// </summary>
        private void BtnCustomerCheck_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            ifc.Mode = FormCommon.Mode.顧客伝票チェック;
            Frmコース選択 frm = new Frmコース選択(ifc);
            frm.ShowDialog();

            共通プロパティ.ReturnMenu = false;

            this.Visible = true;
        }
        /// <summary>
        //              終了　Click
        /// </summary>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

    }
}
