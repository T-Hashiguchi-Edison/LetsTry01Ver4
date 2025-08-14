using Microsoft.VisualBasic.FileIO;
using System.Data.SQLite;
using System.Runtime.InteropServices;
using System.Text;

namespace 指導者用ユーティリティ
{
    public partial class Frm入力値表示顧客伝票ミスチェック : Form
    {
        // SqLite ファイルへの接続文字列
        private string connectionString = "";

        private string cardDataTbl = "";                        //顧客伝票DB
        private string ErrorDataTbl = "";                       //顧客伝票エラーDB

        private string cardNo = "";
        private string WorkTime = "";
        private string FileName = "";

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
        /// <param name="prmCourse">コース</param>
        /// <param name="prmCardNo">顧客伝票No</param>
        /// <param name="prmWorkTome">所要時間</param>
        /// <param name="prmFileName">入力ファイル</param>
        public Frm入力値表示顧客伝票ミスチェック(int prmCourse, string prmCardNo, string prmWorkTime, string prmFileName)
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

            //パラメータセット
            cardNo = prmCardNo;
            WorkTime = prmWorkTime;
            FileName = prmFileName;
            cardDataTbl = (prmCourse == 0) ? "MstCustomerSlip" : "MstCustomerSlipBasic";
            ErrorDataTbl = (prmCourse == 0) ? "MstCustomerSlipError" : "MstCustomerSlipErrorBasic";
        }

        /// <summary>
        //              Form Load
        /// </summary>
        private void Frm入力値表示顧客伝票ミスチェック_Load(object sender, EventArgs e)
        {
            // DB ファイルへの接続文字列
            if (System.IO.File.Exists(System.Windows.Forms.Application.StartupPath + @"\LetsTry04.ini"))
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                StreamReader sr = new StreamReader(System.Windows.Forms.Application.StartupPath + @"\LetsTry04.ini", Encoding.GetEncoding("Shift_JIS"));
                connectionString = SetPathString(sr.ReadLine());
                sr.Close();

                //初期表示
                DispInputInfo();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("システム環境に問題があります。", "エラー");
                //終了
                this.Dispose();
                this.Close();
            }
        }

        /// <summary>
        //              キャンセル　Click
        /// </summary>
        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        //              初期表示　処理
        /// </summary>
        /// <returns>true:正常終了　false:異常終了</returns>
        private Boolean DispInputInfo()
        {
            string InputCustCd = "";
            string InputItemCd = "";
            string InputTelNo = "";
            string InputMail = "";
            string CorrectCustCd = "";
            string CorrectItemCd = "";
            string CorrectTelNo = "";
            string CorrectMail = "";

            try
            {
                if (!File.Exists(FileName))
                {
                    System.Windows.Forms.MessageBox.Show("システム環境に問題があります。(File Not Found(" + FileName + "))", "エラー");
                    //終了
                    this.Dispose();
                    this.Close();
                    return false;
                }

                TxtCardNo.Text = cardNo;

                //入力値ファイル取得
                using (TextFieldParser txtParser = new TextFieldParser(FileName))
                {
                    txtParser.SetDelimiters(",");
                    Boolean DispSw = false;

                    while (!txtParser.EndOfData)
                    {
                        string[]? values = txtParser.ReadFields();
                        int CellCount = 0;
                        foreach (string value in values)
                        {
                            if (value == "開始時刻") break;

                            switch (CellCount)
                            {
                                case 2:
                                    DispSw = (WorkTime == value);
                                    break;
                                case 4:
                                    if (DispSw) DispSw = (cardNo == value);
                                    break;
                                case 5:
                                    if (DispSw) InputCustCd = value;
                                    break;
                                case 6:
                                    if (DispSw) InputItemCd = value;
                                    break;
                                case 7:
                                    if (DispSw) InputTelNo = value;
                                    break;
                                case 8:
                                    if (DispSw) InputMail = value;
                                    break;
                            }
                            CellCount++;
                        }

                        //表示したら抜ける
                        if (DispSw) break;
                    }
                }

                // SQL クエリ
                string sql = "";

                // データＤＢを開く
                using (SQLiteConnection con = new SQLiteConnection(SetconnectionString(connectionString)))
                {
                    con.Open();

                    //顧客伝票データを取得して、表示する
                    sql = "SELECT * From " + cardDataTbl + " WHERE id = " + cardNo;

                    using (SQLiteCommand command = new SQLiteCommand(sql, con))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // データの処理
                                CorrectCustCd = reader.GetString(1);
                                CorrectItemCd = reader.GetString(2);
                                CorrectTelNo = reader.GetString(3);
                                CorrectMail = reader.GetString(4);
                            }
                        }
                    }

                    //顧客伝票エラーデータを取得して、表示する
                    sql = "SELECT * From " + ErrorDataTbl + " WHERE id = " + cardNo;

                    using (SQLiteCommand command = new SQLiteCommand(sql, con))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // データの処理
                                RtxInputCustCd.Text = reader.GetString(1);
                                RtxInputItemCd.Text = reader.GetString(2);
                                RtxInputTelNo.Text = reader.GetString(3);
                                RtxInputMail.Text = reader.GetString(4);
                                RtxInputBeforeCustCd.Text = reader.GetString(1);
                                RtxInputBeforeItemCd.Text = reader.GetString(2);
                                RtxInputBeforeTelNo.Text = reader.GetString(3);
                                RtxInputBeforeMail.Text = reader.GetString(4);
                                RtxCorrectCustCd.Text = reader.GetString(1);
                                RtxCorrectItemCd.Text = reader.GetString(2);
                                RtxCorrectTelNo.Text = reader.GetString(3);
                                RtxCorrectMail.Text = reader.GetString(4);
                            }
                        }
                    }
                    con.Close();
                }

                //文字色変更
                ////正解文字色変更
                TextChangeColor(CorrectCustCd, RtxCorrectCustCd);
                TextChangeColor(CorrectItemCd, RtxCorrectItemCd);
                TextChangeColor(CorrectTelNo, RtxCorrectTelNo);
                TextChangeColor(CorrectMail, RtxCorrectMail);

                ////入力後文字色変更
                TextChangeColorAfter(InputCustCd, RtxInputCustCd);
                TextChangeColorAfter(InputItemCd, RtxInputItemCd);
                TextChangeColorAfter(InputTelNo, RtxInputTelNo);
                TextChangeColorAfter(InputMail, RtxInputMail);

                return true;
            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "エラー");
                //終了
                this.Dispose();
                this.Close();
                return false;
            }
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
            return fPath + @"\LetsTry04.mst";
        }

    }

}
