using System.Runtime.InteropServices;

namespace パソコンデータ入力
{
    public partial class Frm解答入力値表示アンケートカード入力 : Form
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
        //              解答入力値表示アンケートカード入力
        /// </summary>
        /// <param name="prmCardData">アンケートカード情報</param>
        /// <param name="prmInputData">入力情報</param>
        public Frm解答入力値表示アンケートカード入力(構造体.アンケートカード項目 prmCardData, 構造体.アンケートカード入力値 prmInputData)
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
            RtxCorrectKana.Text = prmCardData.NameKana;
            RtxCorrectKanji.Text = prmCardData.NameKanji;
            RtxCorrectZip.Text = prmCardData.ZipCode;
            RtxCorrectAddress.Text = prmCardData.Address;
            RtxCorrectTelNo.Text = prmCardData.TelNo;
            RtxCorrectMail.Text = prmCardData.MailAddress;
            RtxCorrectQ1.Text = prmCardData.Q1Answer;
            RtxCorrectQ2.Text = prmCardData.Q2Answer;
            RtxCorrectQ3.Text = prmCardData.Q3Answer;

            RtxInputKana.Text = prmInputData.NameKana;
            RtxInputKanji.Text = prmInputData.NameKanji;
            RtxInputZip.Text = prmInputData.ZipCode;
            RtxInputAddress.Text = prmInputData.Address;
            RtxInputTelNo.Text = prmInputData.TelNo;
            RtxInputMail.Text = prmInputData.MailAddress;
            RtxInputQ1.Text = prmInputData.Q1Answer;
            RtxInputQ2.Text = prmInputData.Q2Answer;
            RtxInputQ3.Text = prmInputData.Q3Answer;
        }

        /// <summary>
        //              Form　Load
        /// </summary>
        private void Frm解答入力値表示アンケートカード入力_Load(object sender, EventArgs e)
        {
            //文字色変更
            TextChangeColor(RtxCorrectKana, RtxInputKana);
            TextChangeColor(RtxCorrectKanji, RtxInputKanji);
            TextChangeColor(RtxCorrectZip, RtxInputZip);
            TextChangeColor(RtxCorrectAddress, RtxInputAddress);
            TextChangeColor(RtxCorrectTelNo, RtxInputTelNo);
            TextChangeColor(RtxCorrectMail, RtxInputMail);
            TextChangeColorQ1();
            TextChangeColorQ2();
            TextChangeColorQ3();
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
        //              文字色変更
        /// </summary>
        /// <param name="RtxCorrect">正解RichTextBox</param>
        /// <param name="RtxInput">入力後RichTextBox</param>
        private void TextChangeColor(System.Windows.Forms.RichTextBox RtxCorrect, System.Windows.Forms.RichTextBox RtxInput)
        {
            char ChkChar;

            for (int i = 0; i < RtxInput.Text.Length; i++)
            {
                ChkChar = RtxInput.Text[i];
                if (i > RtxCorrect.Text.Length - 1)
                {
                    RtxInput.Select(i, 0);
                    //1文字選択する
                    RtxInput.SelectionLength = 1;
                    //色を赤にする
                    RtxInput.SelectionColor = Color.Red;

                }
                else if (RtxCorrect.Text[i] != ChkChar)
                {
                    RtxInput.Select(i, 0);
                    //1文字選択する
                    RtxInput.SelectionLength = 1;
                    //色を赤にする
                    RtxInput.SelectionColor = Color.Red;
                }

            }
        }

        /// <summary>
        //              文字色変更問１
        /// </summary>
        private void TextChangeColorQ1()
        {
            if (RtxCorrectQ1.Text != RtxInputQ1.Text)
            {
                RtxInputQ1.ForeColor = Color.Red;
            }

            switch (RtxCorrectQ1.Text)
            {
                case "0":
                    RtxCorrectQ1.Text = "0.回答なし";
                    break;
                case "1":
                    RtxCorrectQ1.Text = "1.書店で実物を見て";
                    break;
                case "2":
                    RtxCorrectQ1.Text = "2.チラシを見て";
                    break;
                case "3":
                    RtxCorrectQ1.Text = "3.書店店員に紹介されて";
                    break;
                case "4":
                    RtxCorrectQ1.Text = "4.学校から紹介されて";
                    break;
                case "5":
                    RtxCorrectQ1.Text = "5.知人に紹介されて";
                    break;
                case "6":
                    RtxCorrectQ1.Text = "6.その他";
                    break;
            }

            switch (RtxInputQ1.Text)
            {
                case "0":
                    RtxInputQ1.Text = "0.回答なし";
                    break;
                case "1":
                    RtxInputQ1.Text = "1.書店で実物を見て";
                    break;
                case "2":
                    RtxInputQ1.Text = "2.チラシを見て";
                    break;
                case "3":
                    RtxInputQ1.Text = "3.書店店員に紹介されて";
                    break;
                case "4":
                    RtxInputQ1.Text = "4.学校から紹介されて";
                    break;
                case "5":
                    RtxInputQ1.Text = "5.知人に紹介されて";
                    break;
                case "6":
                    RtxInputQ1.Text = "6.その他";
                    break;
            }
        }

        /// <summary>
        //              文字色変更問２
        /// </summary>
        private void TextChangeColorQ2()
        {
            if (RtxCorrectQ2.Text != RtxInputQ2.Text)
            {
                RtxInputQ2.ForeColor = Color.Red;
            }

            switch (RtxCorrectQ2.Text)
            {
                case "0":
                    RtxCorrectQ2.Text = "回答なし";
                    break;
                case "1":
                    RtxCorrectQ2.Text = "1.役に立った";
                    break;
                case "2":
                    RtxCorrectQ2.Text = "2.ふつう";
                    break;
                case "3":
                    RtxCorrectQ2.Text = "3.期待はずれだった";
                    break;
            }

            switch (RtxInputQ2.Text)
            {
                case "0":
                    RtxInputQ2.Text = "回答なし";
                    break;
                case "1":
                    RtxInputQ2.Text = "1.役に立った";
                    break;
                case "2":
                    RtxInputQ2.Text = "2.ふつう";
                    break;
                case "3":
                    RtxInputQ2.Text = "3.期待はずれだった";
                    break;
            }
        }

        /// <summary>
        //              文字色変更問３
        /// </summary>
        private void TextChangeColorQ3()
        {
            if (RtxCorrectQ3.Text != RtxInputQ3.Text)
            {
                RtxInputQ3.ForeColor = Color.Red;
            }

            switch (RtxCorrectQ3.Text)
            {
                case "0":
                    RtxCorrectQ3.Text = "";
                    break;
                case "1":
                    RtxCorrectQ3.Text = "希望する";
                    break;
                case "2":
                    RtxCorrectQ3.Text = "希望しない";
                    break;
                case "両方ともON":
                    RtxCorrectQ3.Text = "希望する　希望しない";
                    break;
            }

            switch (RtxInputQ3.Text)
            {
                case "0":
                    RtxInputQ3.Text = "";
                    break;
                case "1":
                    RtxInputQ3.Text = "希望する";
                    break;
                case "2":
                    RtxInputQ3.Text = "希望しない";
                    break;
                case "両方ともON":
                    RtxInputQ3.Text = "希望する　希望しない";
                    break;
            }
        }

    }
}
