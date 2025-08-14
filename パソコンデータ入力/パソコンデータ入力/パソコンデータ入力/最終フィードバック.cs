using System.Data.SQLite;
using System.Runtime.InteropServices;
using System.Text;
using static パソコンデータ入力.構造体;

namespace パソコンデータ入力
{
    public partial class Frm最終フィードバック : Form
    {
        // SqLite ファイルへの接続文字列
        private string connectionString = "";

        //引継ぎ情報
        private DateTime StartTime = DateTime.Now;
        private List<構造体.アンケートカード項目> ListCardDataQ = new List<アンケートカード項目>();
        private List<構造体.アンケートカード入力値> ListInputDataQ = new List<アンケートカード入力値>();
        private List<構造体.アンケートカード項目> ListCorrectDataQ = new List<アンケートカード項目>();
        private List<構造体.顧客伝票カード項目> ListCardDataC = new List<構造体.顧客伝票カード項目>();
        private List<構造体.顧客伝票カード項目> ListBeforeDataC = new List<構造体.顧客伝票カード項目>();
        private List<構造体.顧客伝票カード入力値> ListInputDataC = new List<構造体.顧客伝票カード入力値>();
        private List<構造体.顧客伝票カード項目> ListCorrectDataC = new List<構造体.顧客伝票カード項目>();

        //履歴データ情報
        private int ResultCnt = 0;
        private int ResultCorrectCnt = 0;

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
        //              最終フィードバック
        /// </summary>
        /// <param name="prm">画面引継ぎ情報</param>
        /// <param name="prmStartTime">開始時間</param>
        /// <param name="prmListCardDataQ">アンケートカード情報</param>
        /// <param name="prmListInputDataQ">アンケートカード入力情報</param>
        /// <param name="prmListCorrectDataQ">アンケートカード正誤情報</param>
        /// <param name="prmListCardDataC">顧客伝票情報</param>
        /// <param name="prmListInputDataC">顧客伝票入力前情報</param>
        /// <param name="prmListInputDataC">顧客伝票入力情報</param>
        /// <param name="prmListCorrectDataC">顧客伝票正誤情報</param>
        public Frm最終フィードバック(FormCommon.Form_IF prm,
                                     DateTime prmStartTime,
                                     List<構造体.アンケートカード項目> prmListCardDataQ,
                                     List<構造体.アンケートカード入力値> prmListInputDataQ,
                                     List<構造体.アンケートカード項目> prmListCorrectDataQ,
                                     List<構造体.顧客伝票カード項目> prmListCardDataC,
                                     List<構造体.顧客伝票カード項目> prmListBeforeDataC,
                                     List<構造体.顧客伝票カード入力値> prmListInputDataC,
                                     List<構造体.顧客伝票カード項目> prmListCorrectDataC
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

            //フォームインターフェース
            ifc.Copy(prm);
            StartTime = prmStartTime;
            foreach (構造体.アンケートカード項目 CardDataQ in prmListCardDataQ)
            {
                ListCardDataQ.Add(CardDataQ);
            }
            foreach (構造体.アンケートカード入力値 InputDataQ in prmListInputDataQ)
            {
                ListInputDataQ.Add(InputDataQ);
            }
            foreach (構造体.アンケートカード項目 CorrectDataQ in prmListCorrectDataQ)
            {
                ListCorrectDataQ.Add(CorrectDataQ);
            }
            foreach (構造体.顧客伝票カード項目 CardDataC in prmListCardDataC)
            {
                ListCardDataC.Add(CardDataC);
            }
            foreach (構造体.顧客伝票カード項目 BeforeDataC in prmListBeforeDataC)
            {
                ListBeforeDataC.Add(BeforeDataC);
            }
            foreach (構造体.顧客伝票カード入力値 InputDataC in prmListInputDataC)
            {
                ListInputDataC.Add(InputDataC);
            }
            foreach (構造体.顧客伝票カード項目 CorrectDataC in prmListCorrectDataC)
            {
                ListCorrectDataC.Add(CorrectDataC);
            }

        }

        /// <summary>
        //              Form　Load
        /// </summary>
        private void Frm最終フィードバック_Load(object sender, EventArgs e)
        {
            // DB ファイルへの接続文字列
            if (System.IO.File.Exists(Application.StartupPath + @"\LetsTry04.ini"))
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                StreamReader sr = new StreamReader(Application.StartupPath + @"\LetsTry04.ini", Encoding.GetEncoding("Shift_JIS"));
                connectionString = SetPathString(sr.ReadLine());
                //データ取得
                get履歴データ();
            }
            else
            {
                MessageBox.Show("システム環境に問題があります。", "エラー");
                //終了
                共通プロパティ.ReturnMenu = true;
                this.Dispose();
                this.Close();
            }

            //初期表示
            LblWorkCnt.Text = ifc.WorkCnt.ToString();
            LblResultCnt.Text = ResultCnt.ToString();
            LblCorrectCnt.Text = ifc.CorrectCnt.ToString();
            LblResultCorrectCnt.Text = ResultCorrectCnt.ToString();
        }

        /// <summary>
        //              OK　Click
        /// </summary>
        private void BtnOK_Click(object sender, EventArgs e)
        {
            //非表示する
            this.Visible = false;

            Frm試行一覧表示 frm = new Frm試行一覧表示(ifc,
                                                      StartTime,
                                                      ListCardDataQ,
                                                      ListInputDataQ,
                                                      ListCorrectDataQ,
                                                      ListCardDataC,
                                                      ListBeforeDataC,
                                                      ListInputDataC,
                                                      ListCorrectDataC
                                                     );
            frm.ShowDialog();


        }

        /// <summary>
        //              履歴データ　取得処理
        /// </summary>
        /// <returns>true:正常終了　false:異常終了</returns>
        private Boolean get履歴データ()
        {
            try
            {

                // SQL クエリ
                string sql = "";

                // データＤＢを開く
                using (SQLiteConnection con = new SQLiteConnection(SetconnectionString(connectionString)))
                {
                    con.Open();

                    //履歴データを取得して、表示する
                    sql = "SELECT AnswerMaisu,CorrectMaisu From 履歴データ WHERE StartDate =  datetime('" + StartTime.ToString("yyyy-MM-dd HH:mm:ss") + "')";

                    using (SQLiteCommand command = new SQLiteCommand(sql, con))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // データの処理
                                ResultCnt = reader.GetInt32(0);
                                ResultCorrectCnt = reader.GetInt32(1);
                            }
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
                共通プロパティ.ReturnMenu = true;
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
