using System.Runtime.InteropServices;

namespace パソコンデータ入力
{
    public partial class Frm解答入力値表示顧客伝票ミスチェック : Form
    {
        // APIを呼び出すため、対象のＤＬＬをインポート
        [DllImport("USER32.DLL")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, UInt32 bRevert);

        [DllImport("USER32.DLL")]
        private static extern UInt32 RemoveMenu(IntPtr hMenu, UInt32 nPosition, UInt32 wFlags);

        // 定数定義
        private const UInt32 SC_CLOSE = 0x0000F060;
        private const UInt32 MF_BYCOMMAND = 0x00000000;

        /// <summary>
        //              解答入力値表示顧客伝票ミスチェック
        /// </summary>
        /// <param name="prmCardData">アンケートカード情報</param>
        /// <param name="prmBeforeData">入力情報</param>
        /// <param name="prmInputData">入力情報</param>
        public Frm解答入力値表示顧客伝票ミスチェック(構造体.顧客伝票カード項目 prmCardData,
                                                     構造体.顧客伝票カード項目 prmBeforeData,
                                                     構造体.顧客伝票カード入力値 prmInputData
                                                    )
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

            //初期表示
            TxtCardNo.Text = prmCardData.id.ToString("0000");
            RtxCorrectCustCd.Text = prmBeforeData.CustCd;
            RtxCorrectItemCd.Text = prmBeforeData.ItemCd;
            RtxCorrectTelNo.Text = prmBeforeData.TelNo;
            RtxCorrectMail.Text = prmBeforeData.MailAddress;

            RtxInputCustCd.Text = prmBeforeData.CustCd;
            RtxInputItemCd.Text = prmBeforeData.ItemCd;
            RtxInputTelNo.Text = prmBeforeData.TelNo;
            RtxInputMail.Text = prmBeforeData.MailAddress;

            RtxInputBeforeCustCd.Text = prmBeforeData.CustCd;
            RtxInputBeforeItemCd.Text = prmBeforeData.ItemCd;
            RtxInputBeforeTelNo.Text = prmBeforeData.TelNo;
            RtxInputBeforeMail.Text = prmBeforeData.MailAddress;

            //文字色変更
            ////正解文字色変更
            TextChangeColor(prmCardData.CustCd, RtxCorrectCustCd);
            TextChangeColor(prmCardData.ItemCd, RtxCorrectItemCd);
            TextChangeColor(prmCardData.TelNo, RtxCorrectTelNo);
            TextChangeColor(prmCardData.MailAddress, RtxCorrectMail);

            ////入力後文字色変更
            TextChangeColorAfter(prmInputData.CustCd, RtxInputCustCd);
            TextChangeColorAfter(prmInputData.ItemCd, RtxInputItemCd);
            TextChangeColorAfter(prmInputData.TelNo, RtxInputTelNo);
            TextChangeColorAfter(prmInputData.MailAddress, RtxInputMail);
        }

        /// <summary>
        //              Form　Load
        /// </summary>
        private void Frm解答入力値表示顧客伝票ミスチェック_Load(object sender, EventArgs e)
        {
            //特に処理なし
        }

        /// <summary>
        //              キャンセル　Click
        /// </summary>
        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        /// <summary>
        //              正解文字色変更
        /// </summary>
        /// <param name="inputText">対象入力情報</param>
        /// <param name="RtxTarget">対象RichTextBox</param>
        private void TextChangeColor(string inputText, System.Windows.Forms.RichTextBox RtxTarget)
        {
            char ChkChar;

            for (int i = 0; i < inputText.Length; i++)
            {
                ChkChar = inputText[i];
                if (ChkChar != RtxTarget.Text[i])
                {
                    RtxTarget.Select(i, 0);
                    //1文字選択する
                    RtxTarget.SelectionLength = 1;
                    //色を赤にする
                    RtxTarget.SelectionColor = Color.Red;
                }

            }
        }

        /// <summary>
        //              入力後文字色変更
        /// </summary>
        /// <param name="inputText">対象入力情報</param>
        /// <param name="RtxTarget">対象RichTextBox</param>
        private void TextChangeColorAfter(string inputText, System.Windows.Forms.RichTextBox RtxTarget)
        {
            char ChkChar;

            for (int i = 0; i < inputText.Length; i++)
            {
                ChkChar = inputText[i];
                if (ChkChar != 'N')
                {
                    RtxTarget.Select(i, 0);
                    //1文字選択する
                    RtxTarget.SelectionLength = 1;
                    //色を赤にする
                    RtxTarget.SelectionColor = Color.Red;
                }

            }
        }

    }

}
