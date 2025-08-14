using Microsoft.VisualBasic.FileIO;
using System.Data.SQLite;
using System.Runtime.InteropServices;
using System.Text;

namespace 指導者用ユーティリティ
{
    public partial class Frm入力値表示アンケートカード入力 : Form
    {
        // SqLite ファイルへの接続文字列
        private string connectionString = "";

        private string cardDataTbl = "";                        //アンケートカードDB

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
        //              解答入力値表示アンケートカード入力
        /// </summary>
        /// <param name="prmCourse">コース</param>
        /// <param name="prmCardNo">アンケートカードNo</param>
        /// <param name="prmWorkTome">所要時間</param>
        /// <param name="prmFileName">入力ファイル</param>
        public Frm入力値表示アンケートカード入力(int prmCourse, string prmCardNo, string prmWorkTime, string prmFileName)
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
            cardDataTbl = (prmCourse == 0) ? "MstQuestionLevelUp" : "MstQuestionBasic";
        }

        /// <summary>
        //              Form Load
        /// </summary>
        private void Frm入力値表示アンケートカード入力_Load(object sender, EventArgs e)
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
            try
            {
                if (!File.Exists(FileName))
                {
                    //終了
                    System.Windows.Forms.MessageBox.Show("システム環境に問題があります。(File Not Found(" + FileName + "))", "エラー");
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
                                    if (DispSw) RtxInputKana.Text = value;
                                    break;
                                case 6:
                                    if (DispSw) RtxInputKanji.Text = value;
                                    break;
                                case 7:
                                    if (DispSw) RtxInputZip.Text = value;
                                    break;
                                case 8:
                                    if (DispSw) RtxInputAddress.Text = value;
                                    break;
                                case 9:
                                    if (DispSw) RtxInputTelNo.Text = value;
                                    break;
                                case 10:
                                    if (DispSw) RtxInputMail.Text = value;
                                    break;
                                case 11:
                                    if (DispSw) RtxInputQ1.Text = value;
                                    break;
                                case 12:
                                    if (DispSw) RtxInputQ2.Text = value;
                                    break;
                                case 13:
                                    if (DispSw) RtxInputQ3.Text = value;
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

                    //アンケートカードデータを取得して、表示する
                    sql = "SELECT * From " + cardDataTbl + " WHERE id = " + cardNo;

                    using (SQLiteCommand command = new SQLiteCommand(sql, con))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // データの処理
                                RtxCorrectKana.Text = reader.GetString(1);
                                RtxCorrectKanji.Text = reader.GetString(2);
                                RtxCorrectZip.Text = reader.GetString(3);
                                RtxCorrectAddress.Text = reader.GetString(4);
                                RtxCorrectTelNo.Text = reader.GetString(5);
                                RtxCorrectMail.Text = reader.GetString(6);
                                RtxCorrectQ1.Text = reader.GetString(7);
                                RtxCorrectQ2.Text = reader.GetString(8);
                                RtxCorrectQ3.Text = reader.GetString(9);
                            }
                        }
                    }
                    con.Close();
                }

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
                case "":
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
                case "":
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
                case "":
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
                case "":
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
                case "":
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
                case "":
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
