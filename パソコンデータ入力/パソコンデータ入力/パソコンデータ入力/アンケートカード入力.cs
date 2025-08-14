using Microsoft.VisualBasic;
using System.Data.SQLite;
using System.Runtime.InteropServices;
using System.Text;

namespace パソコンデータ入力
{

    public partial class Frmアンケートカード入力 : Form
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

        // 変数定義
        private string? fpath = "";                              //データベースパス
        private string connectionStringD = "";                  // SqLite データファイルへの接続文字列
        private string connectionStringM = "";                  // SqLite マスタファイルへの接続文字列
        private DateTime StartTime = DateTime.Now;              //開始時間
        private DateTime EndTime = DateTime.Now;                //終了時間
        private int InputCount = 0;                             //終わった枚数
        private int cardNO = 0;                                 //入力カード番号 
        private string cardDataTbl = "";                        //アンケートカードDB
        private TimeSpan TotalWorkTime = TimeSpan.Zero;         //作業時間合計

        private 構造体.アンケートカード項目 CurCardData;
        private 構造体.アンケートカード入力値 CurInputData;
        private 構造体.アンケートカード項目 CurCorrectData;
        private 構造体.共通エラー文字種別 CurMojiData;
        private List<構造体.アンケートカード項目> ListCardData = new List<構造体.アンケートカード項目>();
        private List<構造体.アンケートカード入力値> ListInputData = new List<構造体.アンケートカード入力値>();
        private List<構造体.アンケートカード項目> ListCorrectData = new List<構造体.アンケートカード項目>();
        private List<構造体.共通エラー文字種別> ListMojiData = new List<構造体.共通エラー文字種別>();

        private Random rndCard = new Random();                  //カード番号シャッフル用

        private Boolean EndTimerSW = false;                     //終了タイマースイッチ

        private Boolean LastInputSW = false;                    //最終データ入力スイッチ

        /// <summary>
        //              アンケートカード入力
        /// </summary>
        /// <param name="prm">画面引継ぎ情報</param>
        public Frmアンケートカード入力(FormCommon.Form_IF prm)
        {
            InitializeComponent();

            //フォームインターフェース
            ifc.Copy(prm);

            // DB ファイルへの接続文字列
            if (System.IO.File.Exists(Application.StartupPath + @"\LetsTry04.ini"))
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                StreamReader sr = new StreamReader(Application.StartupPath + @"\LetsTry04.ini", Encoding.GetEncoding("Shift_JIS"));
                fpath = sr.ReadLine();
                connectionStringD = SetPathStringD(fpath);
                connectionStringM = SetPathStringM(fpath);
            }
            else
            {
                MessageBox.Show("システム環境に問題があります。", "エラー");
                //終了
                共通プロパティ.ReturnMenu = true;
                this.Dispose();
                this.Close();
            }

            //テーブル設定
            if (ifc.Course == FormCommon.Course.基礎トレーニング)
            {
                cardDataTbl = "MstQuestionBasic";
            }
            else
            {
                cardDataTbl = "MstQuestionLevelUp";
            }
            //画面設定
            if ((ifc.InputImage == FormCommon.Expansion.拡大) && (ifc.InputForm == FormCommon.Expansion.拡大))
            {
                //フォームのサイズ
                if (ifc.FormDisp == FormCommon.FormDisp.画面)
                {
                    this.Size = new Size(1920, 1024);
                    PnlQuestionCard.Visible = true;
                }
                else
                {
                    this.Size = new Size(1160, 1024);
                    PnlQuestionCard.Visible = false;
                }

                if (ifc.FormLR == FormCommon.DispLR.左)
                {
                    //アンケートカード
                    PnlQuestionCard.Location = new Point(0, 0);
                    SetPnlQuestionCardLarge();

                    //入力フォーム
                    if (ifc.FormDisp == FormCommon.FormDisp.画面)
                    {
                        PnlInput.Location = new Point(760, 8);
                    }
                    else
                    {
                        PnlInput.Location = new Point(0, 8);
                    }
                    SetPnlInputLarge();
                }
                else
                {
                    //アンケートカード
                    PnlQuestionCard.Location = new Point(1144, 0);
                    SetPnlQuestionCardLarge();

                    //入力フォーム
                    PnlInput.Location = new Point(0, 8);
                    SetPnlInputLarge();
                }
            }
            else if ((ifc.InputImage == FormCommon.Expansion.拡大) && (ifc.InputForm == FormCommon.Expansion.通常))
            {
                //フォームのサイズ
                if (ifc.FormDisp == FormCommon.FormDisp.画面)
                {
                    this.Size = new Size(1475, 1024);
                    PnlQuestionCard.Visible = true;
                }
                else
                {
                    this.Size = new Size(728, 792);
                    PnlQuestionCard.Visible = false;
                }

                if (ifc.FormLR == FormCommon.DispLR.左)
                {
                    //アンケートカード
                    PnlQuestionCard.Location = new Point(0, 0);
                    SetPnlQuestionCardLarge();

                    //入力フォーム
                    if (ifc.FormDisp == FormCommon.FormDisp.画面)
                    {
                        PnlInput.Location = new Point(760, 128);
                    }
                    else
                    {
                        PnlInput.Location = new Point(0, 0);
                    }
                    SetPnlInputOrigin();
                }
                else
                {
                    //アンケートカード
                    PnlQuestionCard.Location = new Point(704, 0);
                    SetPnlQuestionCardLarge();

                    //入力フォーム
                    if (ifc.FormDisp == FormCommon.FormDisp.画面)
                    {
                        PnlInput.Location = new Point(0, 128);
                    }
                    else
                    {
                        PnlInput.Location = new Point(0, 0);
                    }
                    SetPnlInputOrigin();
                }
            }
            else if ((ifc.InputImage == FormCommon.Expansion.通常) && (ifc.InputForm == FormCommon.Expansion.拡大))
            {
                //フォームのサイズ
                if (ifc.FormDisp == FormCommon.FormDisp.画面)
                {
                    this.Size = new Size(1766, 1024);
                    PnlQuestionCard.Visible = true;
                }
                else
                {
                    this.Size = new Size(1160, 1024);
                    PnlQuestionCard.Visible = false;
                }

                if (ifc.FormLR == FormCommon.DispLR.左)
                {
                    //アンケートカード
                    PnlQuestionCard.Location = new Point(0, 128);
                    SetPnlQuestionCardOrigin();

                    //入力フォーム
                    if (ifc.FormDisp == FormCommon.FormDisp.画面)
                    {
                        PnlInput.Location = new Point(608, 8);
                    }
                    else
                    {
                        PnlInput.Location = new Point(0, 8);
                    }
                    SetPnlInputLarge();
                }
                else
                {
                    //アンケートカード
                    PnlQuestionCard.Location = new Point(1144, 128);
                    SetPnlQuestionCardOrigin();

                    //入力フォーム
                    PnlInput.Location = new Point(0, 8);
                    SetPnlInputLarge();
                }
            }
            else
            {
                //フォームのサイズ
                if (ifc.FormDisp == FormCommon.FormDisp.画面)
                {
                    this.Size = new Size(1332, 752);
                    PnlQuestionCard.Visible = true;
                }
                else
                {
                    this.Size = new Size(728, 752);
                    PnlQuestionCard.Visible = false;
                }

                if (ifc.FormLR == FormCommon.DispLR.左)
                {
                    //アンケートカード
                    PnlQuestionCard.Location = new Point(0, 0);
                    SetPnlQuestionCardOrigin();

                    //入力フォーム
                    if (ifc.FormDisp == FormCommon.FormDisp.画面)
                    {
                        PnlInput.Location = new Point(608, 0);
                    }
                    else
                    {
                        PnlInput.Location = new Point(0, 0);
                    }
                    SetPnlInputOrigin();
                }
                else
                {
                    //アンケートカード
                    PnlQuestionCard.Location = new Point(704, 0);
                    SetPnlQuestionCardOrigin();

                    PnlInput.Location = new Point(0, 0);
                    SetPnlInputOrigin();
                }
            }

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
        }

        /// <summary>
        //              ショートカットキー判定　Key Down
        /// </summary>
        /// <param name="keyData">キー情報</param>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            //［Alt］+［Z］が押されたらキャッチ(郵便番号検索)
            if (keyData == (Keys.Z | Keys.Alt))
            {
                BtnPostNoSearch.PerformClick();
            }
            //［Alt］+［N］が押されたらキャッチ(次へ)
            if (keyData == (Keys.N | Keys.Alt))
            {
                BtnNext.PerformClick();
            }
            //［Alt］+［A］が押されたらキャッチ(チェック)
            if (keyData == (Keys.A | Keys.Alt))
            {
                BtnCheck.PerformClick();
            }
            //［Alt］+［C］が押されたらキャッチ(中止)
            if (keyData == (Keys.C | Keys.Alt))
            {
                BtnCancel.PerformClick();
            }

            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        //              Form　Load
        /// </summary>
        private void Frmアンケートカード入力_Load(object sender, EventArgs e)
        {
            //初期表示

            ////終了タイマー設定
            EndTimer.Interval = ifc.Timer * 60 * 1000;
            EndTimer.Enabled = true;

            //実行タイマー設定
            RunTimer.Enabled = true;

            //タイマーバー設定
            PbTimer.Minimum = 0;
            PbTimer.Maximum = ifc.Timer * 60 * 1000;
            PbTimer.Value = 0;

            //進捗状況設定値の表示
            LblProgressCount1.Text = ifc.WorkCnt.ToString();
            LblProgressCount2.Text = ifc.CorrectCnt.ToString();

            //カード番号
            if (ifc.Teiji == FormCommon.Teiji.番号順)
            {
                if (ifc.Start_No > 0)
                {
                    cardNO = ifc.Start_No - 1;
                }
                else
                {
                    cardNO = ifc.Start_No1 - 1;
                }
            }

            //各配列のクリア
            ListCardData.Clear();
            ListInputData.Clear();
            ListCorrectData.Clear();
            ListMojiData.Clear();

            //入力フォームのクリア(カード№は更新しない)
            ClearInputForm(false);
            //アンケートカードデータ表示
            DispCard();
        }

        /// <summary>
        //              検索　Click
        /// </summary>
        private void BtnPostNoSearch_Click(object sender, EventArgs e)
        {
            //郵便番号検索処理
            SearchZipCode();
        }

        /// <summary>
        //              次へ　Click
        /// </summary>
        private void BtnNext_Click(object sender, EventArgs e)
        {
            BtnCancel.Enabled = false;

            //入力チェック
            CheckInput(false);

            CurInputData.EndTime = DateTime.Now;
            TimeSpan ElapsedTime = CurInputData.EndTime - CurInputData.StartTime;
            Double ElapsedMillSecond = ElapsedTime.TotalMilliseconds / 1000;
            CurInputData.ElapsedTime = Math.Truncate((ElapsedMillSecond / 60)).ToString("00") + "分"
                                     + (ElapsedMillSecond % 60).ToString("00") + "秒";
            //次への時のみ、作業時間合計を設定する
            //TotalWorkTime = TotalWorkTime + ElapsedTime;
            TotalWorkTime = ElapsedTime;


            ListCardData.Add(CurCardData);
            ListInputData.Add(CurInputData);
            ListCorrectData.Add(CurCorrectData);
            ListMojiData.Add(CurMojiData);

            //入力フォームのクリア(カード№の更新)
            ClearInputForm(true);
            //アンケートカードデータ表示
            DispCard();

            BtnCancel.Enabled = true;

        }

        /// <summary>
        //              チェック　Click
        /// </summary>
        private void BtnCheck_Click(object sender, EventArgs e)
        {
            string Msg = "";
            BtnCancel.Enabled = false;

            //入力チェック
            if (CheckInput(true))
            {
                Msg = "まちがいはありません。次へすすんでください。";
            }
            else
            {
                Msg = "まちがいがあります。なおしてください。";
            }
            Frmチェックメッセージ frm = new Frmチェックメッセージ(Msg);
            frm.ShowDialog();

            BtnCancel.Enabled = true;
        }

        /// <summary>
        //              中止　Click
        /// </summary>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = System.Windows.Forms.DialogResult.Yes;

            //確認
            if (!EndTimerSW) result = MessageBox.Show("作業を終了してよろしいですか？", "中止確認", MessageBoxButtons.YesNo);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                EndTime = DateTime.Now;
                //実行タイマーを止めて開放する
                RunTimer.Stop();
                RunTimer.Dispose();

                if (CurInputData.CheckCnt > 0)
                {
                    LastInputSW = true;
                    ListCardData.Add(CurCardData);

                    CurInputData.EndTime = DateTime.Now;
                    TimeSpan ElapsedTime = CurInputData.EndTime - CurInputData.StartTime;
                    Double ElapsedMillSecond = ElapsedTime.TotalMilliseconds / 1000;
                    CurInputData.ElapsedTime = Math.Truncate((ElapsedMillSecond / 60)).ToString("00") + "分"
                                             + (ElapsedMillSecond % 60).ToString("00") + "秒";

                    ListInputData.Add(CurInputData);
                    ListCorrectData.Add(CurCorrectData);
                    ListMojiData.Add(CurMojiData);
                }


                //解析結果テキスト出力
                OutputResultText();

                //履歴データ出力
                OutputHistoryData();

                //次画面へ
                共通プロパティ.ReturnMenu = true;

                if (ifc.Course == FormCommon.Course.実力テスト)
                {
                    this.Dispose();
                    this.Close();
                }
                else if ((ifc.Course == FormCommon.Course.レベルアップトレーニング) && (ifc.DispFinal == FormCommon.Displey.表示する))
                {
                    //最終フィードバック画面
                    this.Visible = false;

                    Frm最終フィードバック frm = new Frm最終フィードバック(ifc,
                                                                          StartTime,
                                                                          ListCardData,
                                                                          ListInputData,
                                                                          ListCorrectData,
                                                                          new List<構造体.顧客伝票カード項目>(),
                                                                          new List<構造体.顧客伝票カード項目>(),
                                                                          new List<構造体.顧客伝票カード入力値>(),
                                                                          new List<構造体.顧客伝票カード項目>()
                                                                         );

                    frm.ShowDialog();

                    this.Dispose();
                    this.Close();
                }
                else
                {
                    //それ以外は結果確認画面
                    this.Visible = false;

                    Frm試行一覧表示 frm = new Frm試行一覧表示(ifc,
                                                              StartTime,
                                                              ListCardData,
                                                              ListInputData,
                                                              ListCorrectData,
                                                              new List<構造体.顧客伝票カード項目>(),
                                                              new List<構造体.顧客伝票カード項目>(),
                                                              new List<構造体.顧客伝票カード入力値>(),
                                                              new List<構造体.顧客伝票カード項目>()
                                                             );
                    frm.ShowDialog();

                    this.Dispose();
                    this.Close();
                }
            }
        }

        /// <summary>
        //              終了タイマー処理
        /// </summary>
        private void EndTimer_Tick(object sender, EventArgs e)
        {
            EndTimerSW = true;

            //中止ボタンをクリック
            BtnCancel.PerformClick();
        }

        /// <summary>
        //              実行タイマー処理
        /// </summary>
        private void RunTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan RemainTime = DateTime.Now - StartTime;

            if (PbTimer.Maximum > RemainTime.TotalMilliseconds)
            {
                Double RemainMillSecond = (EndTimer.Interval - RemainTime.TotalMilliseconds) / 1000;
                LblProgressTimer.Text = Math.Truncate((RemainMillSecond / 60)).ToString("00") + "分" + (RemainMillSecond % 60).ToString("00") + "秒";

                PbTimer.Value = (int)Math.Truncate(RemainTime.TotalMilliseconds);
            }
        }

        /// <summary>
        //              アンケートカード　通常
        /// </summary>
        private void SetPnlQuestionCardOrigin()
        {
            //アンケートカード
            PnlQuestionCard.Size = new Size(608, 704);
            {
                //カードNo
                LblNo_Q.Location = new Point(416, 0);
                LblNo_Q.Size = new Size(64, 32);
                LblNo_Q.Font = new Font("ＭＳ Ｐゴシック", 15.75f);

                LblCardNo_C.Location = new Point(480, 0);
                LblCardNo_C.Size = new Size(56, 32);
                LblCardNo_C.Font = new Font("ＭＳ Ｐゴシック", 15.75f);

                //タイトル
                LblTitle.Location = new Point(0, 40);
                LblTitle.Size = new Size(608, 32);
                LblTitle.Font = new Font("ＭＳ Ｐゴシック", 20.25f);

                LineTitle.Location = new Point(30, 72);
                LineTitle.Size = new Size(546, 2);

                //フリガナ
                LblKanaSimei_Q.Location = new Point(64, 104);
                LblKanaSimei_Q.Size = new Size(72, 24);
                LblKanaSimei_Q.Font = new Font("ＭＳ Ｐゴシック", 12f, FontStyle.Bold);

                LblKanaSimei_C.Location = new Point(136, 104);
                LblKanaSimei_C.Size = new Size(440, 24);
                LblKanaSimei_C.Font = new Font("ＭＳ Ｐゴシック", 14.25f);

                //氏名
                LblKanjiSimei_Q.Location = new Point(32, 136);
                LblKanjiSimei_Q.Size = new Size(104, 32);
                LblKanjiSimei_Q.Font = new Font("ＭＳ Ｐゴシック", 15.75f, FontStyle.Bold);

                LblKanjiSimei_C.Location = new Point(128, 136);
                LblKanjiSimei_C.Size = new Size(448, 32);
                LblKanjiSimei_C.Font = new Font("ＭＳ Ｐゴシック", 20.25f);

                LineSimei.Location = new Point(128, 168);
                LineSimei.Size = new Size(448, 1);

                //住所
                LblAddress_Q.Location = new Point(32, 176);
                LblAddress_Q.Size = new Size(128, 32);
                LblAddress_Q.Font = new Font("ＭＳ Ｐゴシック", 15.75f, FontStyle.Bold);

                LblPostNo_C.Location = new Point(152, 176);
                LblPostNo_C.Size = new Size(136, 32);
                LblPostNo_C.Font = new Font("ＭＳ Ｐゴシック", 18f);

                LblAddress_C.Location = new Point(72, 208);
                LblAddress_C.Size = new Size(504, 32);
                LblAddress_C.Font = new Font("ＭＳ Ｐゴシック", 18f);

                LineAddress.Location = new Point(72, 240);
                LineAddress.Size = new Size(504, 1);

                //電話番号
                LblTelNo_Q.Location = new Point(32, 248);
                LblTelNo_Q.Size = new Size(128, 32);
                LblTelNo_Q.Font = new Font("ＭＳ Ｐゴシック", 15.75f, FontStyle.Bold);

                LblTelNo_C.Location = new Point(160, 248);
                LblTelNo_C.Size = new Size(360, 32);
                LblTelNo_C.Font = new Font("ＭＳ Ｐゴシック", 20.25f);

                LineTelNo.Location = new Point(160, 280);
                LineTelNo.Size = new Size(416, 1);

                //メールアドレス
                LblMailAddress_Q.Location = new Point(32, 288);
                LblMailAddress_Q.Size = new Size(168, 32);
                LblMailAddress_Q.Font = new Font("ＭＳ Ｐゴシック", 15.75f, FontStyle.Bold);

                LblMailAddress_C.Location = new Point(72, 320);
                LblMailAddress_C.Size = new Size(504, 32);
                LblMailAddress_C.Font = new Font("ＭＳ Ｐゴシック", 20.25f);

                LineMailAddress.Location = new Point(72, 352);
                LineMailAddress.Size = new Size(504, 1);

                //問１
                LblQuestion1.Location = new Point(32, 368);
                LblQuestion1.Size = new Size(496, 32);
                LblQuestion1.Font = new Font("ＭＳ Ｐゴシック", 14.25f, FontStyle.Bold);

                LblQuestion1_1.Location = new Point(72, 400);
                LblQuestion1_1.Size = new Size(248, 40);
                LblQuestion1_1.Font = new Font("ＭＳ Ｐゴシック", 14.25f);

                LblQuestion1_2.Location = new Point(320, 400);
                LblQuestion1_2.Size = new Size(248, 40);
                LblQuestion1_2.Font = new Font("ＭＳ Ｐゴシック", 14.25f);

                LblQuestion1_3.Location = new Point(72, 440);
                LblQuestion1_3.Size = new Size(248, 40);
                LblQuestion1_3.Font = new Font("ＭＳ Ｐゴシック", 14.25f);

                LblQuestion1_4.Location = new Point(320, 440);
                LblQuestion1_4.Size = new Size(248, 40);
                LblQuestion1_4.Font = new Font("ＭＳ Ｐゴシック", 14.25f);

                LblQuestion1_5.Location = new Point(72, 480);
                LblQuestion1_5.Size = new Size(248, 40);
                LblQuestion1_5.Font = new Font("ＭＳ Ｐゴシック", 14.25f);

                LblQuestion1_6.Location = new Point(320, 480);
                LblQuestion1_6.Size = new Size(248, 40);
                LblQuestion1_6.Font = new Font("ＭＳ Ｐゴシック", 14.25f);

                //問２
                LblQuestion2.Location = new Point(32, 528);
                LblQuestion2.Size = new Size(568, 32);
                LblQuestion2.Font = new Font("ＭＳ Ｐゴシック", 14.25f, FontStyle.Bold);

                LblQuestion2_1.Location = new Point(72, 560);
                LblQuestion2_1.Size = new Size(152, 40);
                LblQuestion2_1.Font = new Font("ＭＳ Ｐゴシック", 14.25f);

                LblQuestion2_2.Location = new Point(224, 560);
                LblQuestion2_2.Size = new Size(112, 40);
                LblQuestion2_2.Font = new Font("ＭＳ Ｐゴシック", 14.25f);

                LblQuestion2_3.Location = new Point(336, 560);
                LblQuestion2_3.Size = new Size(208, 40);
                LblQuestion2_3.Font = new Font("ＭＳ Ｐゴシック", 14.25f);

                //問３
                LblQuestion3.Location = new Point(32, 608);
                LblQuestion3.Size = new Size(560, 32);
                LblQuestion3.Font = new Font("ＭＳ Ｐゴシック", 14.25f, FontStyle.Bold);

                LblQuestion3_1.Location = new Point(152, 640);
                LblQuestion3_1.Size = new Size(128, 32);
                LblQuestion3_1.Font = new Font("ＭＳ Ｐゴシック", 14.25f);

                LblQuestion3_2.Location = new Point(328, 640);
                LblQuestion3_2.Size = new Size(128, 32);
                LblQuestion3_2.Font = new Font("ＭＳ Ｐゴシック", 14.25f);

                //フッター
                LblComment.Visible = false;
                //LblComment.Location = new Point(280, 696);
                //LblComment.Size = new Size(288, 32);
                //LblComment.Font = new Font("ＭＳ Ｐゴシック", 15.75f);
            }
        }

        /// <summary>
        //              アンケートカード　拡大
        /// </summary>
        private void SetPnlQuestionCardLarge()
        {
            //アンケートカード
            PnlQuestionCard.Size = new Size(760, 992);
            {
                //カードNo
                LblNo_Q.Location = new Point(420, 0);
                LblNo_Q.Size = new Size(224, 48);
                LblNo_Q.Font = new Font("ＭＳ Ｐゴシック", 21.75f);

                LblCardNo_C.Location = new Point(640, 0);
                LblCardNo_C.Size = new Size(88, 48);
                LblCardNo_C.Font = new Font("ＭＳ Ｐゴシック", 21.75f);

                //タイトル
                LblTitle.Location = new Point(0, 48);
                LblTitle.Size = new Size(760, 56);
                LblTitle.Font = new Font("ＭＳ Ｐゴシック", 27.75f);

                LineTitle.Location = new Point(30, 104);
                LineTitle.Size = new Size(700, 2);

                //フリガナ
                LblKanaSimei_Q.Location = new Point(64, 144);
                LblKanaSimei_Q.Size = new Size(96, 32);
                LblKanaSimei_Q.Font = new Font("ＭＳ Ｐゴシック", 15.75f, FontStyle.Bold);

                LblKanaSimei_C.Location = new Point(160, 144);
                LblKanaSimei_C.Size = new Size(528, 40);
                LblKanaSimei_C.Font = new Font("ＭＳ Ｐゴシック", 20.25f);

                //氏名
                LblKanjiSimei_Q.Location = new Point(32, 192);
                LblKanjiSimei_Q.Size = new Size(128, 40);
                LblKanjiSimei_Q.Font = new Font("ＭＳ Ｐゴシック", 20.25f, FontStyle.Bold);

                LblKanjiSimei_C.Location = new Point(160, 192);
                LblKanjiSimei_C.Size = new Size(528, 48);
                LblKanjiSimei_C.Font = new Font("ＭＳ Ｐゴシック", 27.75f);

                LineSimei.Location = new Point(152, 240);
                LineSimei.Size = new Size(572, 1);

                //住所
                LblAddress_Q.Location = new Point(32, 248);
                LblAddress_Q.Size = new Size(160, 40);
                LblAddress_Q.Font = new Font("ＭＳ Ｐゴシック", 20.25f, FontStyle.Bold);

                LblPostNo_C.Location = new Point(184, 248);
                LblPostNo_C.Size = new Size(136, 40);
                LblPostNo_C.Font = new Font("ＭＳ Ｐゴシック", 20.25f);

                LblAddress_C.Location = new Point(72, 296);
                LblAddress_C.Size = new Size(652, 48);
                LblAddress_C.Font = new Font("ＭＳ Ｐゴシック", 24f);

                LineAddress.Location = new Point(72, 344);
                LineAddress.Size = new Size(652, 1);

                //電話番号
                LblTelNo_Q.Location = new Point(32, 360);
                LblTelNo_Q.Size = new Size(168, 40);
                LblTelNo_Q.Font = new Font("ＭＳ Ｐゴシック", 20.25f, FontStyle.Bold);

                LblTelNo_C.Location = new Point(200, 352);
                LblTelNo_C.Size = new Size(456, 48);
                LblTelNo_C.Font = new Font("ＭＳ Ｐゴシック", 27.75f);

                LineTelNo.Location = new Point(200, 400);
                LineTelNo.Size = new Size(524, 1);

                //メールアドレス
                LblMailAddress_Q.Location = new Point(32, 416);
                LblMailAddress_Q.Size = new Size(224, 40);
                LblMailAddress_Q.Font = new Font("ＭＳ Ｐゴシック", 20.25f, FontStyle.Bold);

                LblMailAddress_C.Location = new Point(72, 448);
                LblMailAddress_C.Size = new Size(652, 56);
                LblMailAddress_C.Font = new Font("ＭＳ Ｐゴシック", 26.25f);

                LineMailAddress.Location = new Point(72, 504);
                LineMailAddress.Size = new Size(652, 1);

                //問１
                LblQuestion1.Location = new Point(32, 536);
                LblQuestion1.Size = new Size(680, 40);
                LblQuestion1.Font = new Font("ＭＳ Ｐゴシック", 18f, FontStyle.Bold);

                LblQuestion1_1.Location = new Point(72, 584);
                LblQuestion1_1.Size = new Size(320, 40);
                LblQuestion1_1.Font = new Font("ＭＳ Ｐゴシック", 18f);

                LblQuestion1_2.Location = new Point(392, 584);
                LblQuestion1_2.Size = new Size(320, 40);
                LblQuestion1_2.Font = new Font("ＭＳ Ｐゴシック", 18f);

                LblQuestion1_3.Location = new Point(72, 632);
                LblQuestion1_3.Size = new Size(320, 40);
                LblQuestion1_3.Font = new Font("ＭＳ Ｐゴシック", 18f);

                LblQuestion1_4.Location = new Point(392, 632);
                LblQuestion1_4.Size = new Size(320, 40);
                LblQuestion1_4.Font = new Font("ＭＳ Ｐゴシック", 18f);

                LblQuestion1_5.Location = new Point(72, 680);
                LblQuestion1_5.Size = new Size(320, 40);
                LblQuestion1_5.Font = new Font("ＭＳ Ｐゴシック", 18f);

                LblQuestion1_6.Location = new Point(392, 680);
                LblQuestion1_6.Size = new Size(320, 40);
                LblQuestion1_6.Font = new Font("ＭＳ Ｐゴシック", 18f);

                //問２
                LblQuestion2.Location = new Point(32, 736);
                LblQuestion2.Size = new Size(680, 40);
                LblQuestion2.Font = new Font("ＭＳ Ｐゴシック", 18f, FontStyle.Bold);

                LblQuestion2_1.Location = new Point(72, 784);
                LblQuestion2_1.Size = new Size(216, 40);
                LblQuestion2_1.Font = new Font("ＭＳ Ｐゴシック", 18f);

                LblQuestion2_2.Location = new Point(266, 784);
                LblQuestion2_2.Size = new Size(136, 40);
                LblQuestion2_2.Font = new Font("ＭＳ Ｐゴシック", 18f);

                LblQuestion2_3.Location = new Point(424, 784);
                LblQuestion2_3.Size = new Size(264, 40);
                LblQuestion2_3.Font = new Font("ＭＳ Ｐゴシック", 18f);

                //問３
                LblQuestion3.Location = new Point(32, 840);
                LblQuestion3.Size = new Size(728, 40);
                LblQuestion3.Font = new Font("ＭＳ Ｐゴシック", 18f, FontStyle.Bold);

                LblQuestion3_1.Location = new Point(192, 888);
                LblQuestion3_1.Size = new Size(176, 40);
                LblQuestion3_1.Font = new Font("ＭＳ Ｐゴシック", 18f);

                LblQuestion3_2.Location = new Point(392, 888);
                LblQuestion3_2.Size = new Size(176, 40);
                LblQuestion3_2.Font = new Font("ＭＳ Ｐゴシック", 18f);

                //フッター
                LblComment.Location = new Point(352, 944);
                LblComment.Size = new Size(360, 40);
                LblComment.Font = new Font("ＭＳ Ｐゴシック", 20.25f);
            }
        }

        /// <summary>
        //              入力フォーム　通常
        /// </summary>
        private void SetPnlInputOrigin()
        {
            //入力フォーム
            PnlInput.Size = new Size(704, 704);
            {
                //進捗状況
                GrpProgress.Location = new Point(480, 8);
                GrpProgress.Text = "進捗状況";
                switch (ifc.Course)
                {
                    case FormCommon.Course.基礎トレーニング:
                        LblProgress11.Visible = false;
                        LblProgressCount1.Visible = false;
                        LblProgress21.Visible = false;
                        LblProgress12.Visible = false;
                        LblProgressCount2.Visible = false;
                        LblProgress22.Visible = false;
                        LblProgress13.Location = new Point(8, 40);
                        LblProgress13.Visible = true;
                        LblProgressCount3.Location = new Point(136, 40);
                        LblProgressCount3.Visible = true;
                        LblProgress23.Location = new Point(168, 40);
                        LblProgress23.Visible = true;
                        LblProgress14.Visible = false;
                        LblProgressTimer.Visible = false;
                        GrpProgress.Visible = (ifc.DispProgress == FormCommon.Displey.表示する);
                        PbTimer.Visible = false;
                        break;
                    case FormCommon.Course.レベルアップトレーニング:
                        if (ifc.DispProgress == FormCommon.Displey.表示する)
                        {
                            LblProgress11.Visible = true;
                            LblProgressCount1.Visible = true;
                            LblProgress21.Visible = true;
                            LblProgress12.Visible = true;
                            LblProgressCount2.Visible = true;
                            LblProgress22.Visible = true;
                            LblProgress13.Location = new Point(8, 56);
                            LblProgress13.Visible = true;
                            LblProgressCount3.Location = new Point(136, 56);
                            LblProgressCount3.Visible = true;
                            LblProgress23.Location = new Point(168, 56);
                            LblProgress23.Visible = true;
                            LblProgress14.Visible = (ifc.DispTimer == FormCommon.Displey.表示する);
                            LblProgressTimer.Visible = (ifc.DispTimer == FormCommon.Displey.表示する);
                            GrpProgress.Visible = true;
                            PbTimer.Location = new Point(480, 112);
                            PbTimer.Visible = (ifc.DispRemain == FormCommon.Displey.表示する);
                        }
                        else if (ifc.DispTimer == FormCommon.Displey.表示する)
                        {
                            LblProgress11.Visible = false;
                            LblProgressCount1.Visible = false;
                            LblProgress21.Visible = false;
                            LblProgress12.Visible = false;
                            LblProgressCount2.Visible = false;
                            LblProgress22.Visible = false;
                            LblProgress13.Visible = false;
                            LblProgressCount3.Visible = false;
                            LblProgress23.Visible = false;
                            LblProgress14.Location = new Point(8, 24);
                            LblProgress14.Visible = true;
                            LblProgressTimer.Location = new Point(136, 24);
                            LblProgressTimer.Visible = true;
                            GrpProgress.Visible = true;
                            GrpProgress.Text = "";
                            PbTimer.Location = new Point(480, 112);
                            PbTimer.Visible = (ifc.DispRemain == FormCommon.Displey.表示する);
                        }
                        else
                        {
                            PbTimer.Location = new Point(480, 8);
                            PbTimer.Visible = (ifc.DispRemain == FormCommon.Displey.表示する);
                            GrpProgress.Visible = false;
                        }
                        break;
                    case FormCommon.Course.実力テスト:
                        GrpProgress.Visible = false;
                        PbTimer.Visible = false;
                        break;
                }

                //カードNo
                LblNo.Location = new Point(16, 72);
                LblNo.Size = new Size(128, 24);
                LblNo.Font = new Font("ＭＳ Ｐゴシック", 15.75f);

                TxtCardNo.Location = new Point(152, 74);
                TxtCardNo.Size = new Size(72, 35);
                TxtCardNo.Font = new Font("ＭＳ Ｐゴシック", 15.75f);

                //フリガナ
                LblKanaSimei.Location = new Point(16, 120);
                LblKanaSimei.Size = new Size(128, 24);
                LblKanaSimei.Font = new Font("ＭＳ Ｐゴシック", 15.75f);

                TxtKanaSimei.Location = new Point(152, 120);
                TxtKanaSimei.Size = new Size(264, 35);
                TxtKanaSimei.Font = new Font("ＭＳ Ｐゴシック", 15.75f);

                //氏名
                LblKanjiSimei.Location = new Point(16, 168);
                LblKanjiSimei.Size = new Size(128, 24);
                LblKanjiSimei.Font = new Font("ＭＳ Ｐゴシック", 15.75f);

                TxtKanjiSimei.Location = new Point(152, 168);
                TxtKanjiSimei.Size = new Size(264, 35);
                TxtKanjiSimei.Font = new Font("ＭＳ Ｐゴシック", 15.75f);

                //郵便番号
                LblPostNo.Location = new Point(16, 216);
                LblPostNo.Size = new Size(128, 24);
                LblPostNo.Font = new Font("ＭＳ Ｐゴシック", 15.75f);

                TxtPostNo.Location = new Point(152, 216);
                TxtPostNo.Size = new Size(120, 35);
                TxtPostNo.Font = new Font("ＭＳ Ｐゴシック", 15.75f);

                BtnPostNoSearch.Location = new Point(272, 216);
                BtnPostNoSearch.Size = new Size(88, 32);
                BtnPostNoSearch.Font = new Font("ＭＳ Ｐゴシック", 12f);
                BtnPostNoSearch.Visible = (ifc.ZipSearch == FormCommon.ZipSearch.使用);

                //住所
                LblAddress.Location = new Point(16, 264);
                LblAddress.Size = new Size(128, 24);
                LblAddress.Font = new Font("ＭＳ Ｐゴシック", 15.75f);

                TxtAddress.Location = new Point(152, 264);
                TxtAddress.Size = new Size(512, 35);
                TxtAddress.Font = new Font("ＭＳ Ｐゴシック", 15.75f);

                //電話番号
                LblTelNo.Location = new Point(16, 312);
                LblTelNo.Size = new Size(128, 24);
                LblTelNo.Font = new Font("ＭＳ Ｐゴシック", 15.75f);

                TxtTelNo.Location = new Point(152, 312);
                TxtTelNo.Size = new Size(264, 35);
                TxtTelNo.Font = new Font("ＭＳ Ｐゴシック", 15.75f);

                //メールアドレス
                LblMailAddress.Location = new Point(0, 352);
                LblMailAddress.Size = new Size(144, 24);
                LblMailAddress.Font = new Font("ＭＳ Ｐゴシック", 15.75f);

                TxtMailAddress.Location = new Point(152, 352);
                TxtMailAddress.Size = new Size(512, 35);
                TxtMailAddress.Font = new Font("ＭＳ Ｐゴシック", 15.75f);

                //問１
                LblQ1.Location = new Point(16, 400);
                LblQ1.Size = new Size(128, 24);
                LblQ1.Font = new Font("ＭＳ Ｐゴシック", 15.75f);

                CmbQ1.Location = new Point(152, 400);
                CmbQ1.Size = new Size(264, 38);
                CmbQ1.Font = new Font("ＭＳ Ｐゴシック", 15.75f);

                //問２
                LblQ2.Location = new Point(16, 456);
                LblQ2.Size = new Size(128, 24);
                LblQ2.Font = new Font("ＭＳ Ｐゴシック", 15.75f);

                PnlQ2.Location = new Point(152, 440);
                PnlQ2.Size = new Size(440, 96);
                PnlQ2.Font = new Font("ＭＳ Ｐゴシック", 15.75f);
                {
                    RdiQ2_1.Location = new Point(8, 8);
                    RdiQ2_1.Size = new Size(200, 40);
                    RdiQ2_1.Font = new Font("ＭＳ Ｐゴシック", 15.75f);

                    RdiQ2_2.Location = new Point(208, 8);
                    RdiQ2_2.Size = new Size(224, 40);
                    RdiQ2_2.Font = new Font("ＭＳ Ｐゴシック", 15.75f);

                    RdiQ2_3.Location = new Point(8, 48);
                    RdiQ2_3.Size = new Size(200, 40);
                    RdiQ2_3.Font = new Font("ＭＳ Ｐゴシック", 15.75f);

                    RdiQ2_4.Location = new Point(208, 48);
                    RdiQ2_4.Size = new Size(224, 40);
                    RdiQ2_4.Font = new Font("ＭＳ Ｐゴシック", 15.75f);
                }

                //問３
                LblQ3.Location = new Point(16, 552);
                LblQ3.Size = new Size(128, 24);
                LblQ3.Font = new Font("ＭＳ Ｐゴシック", 15.75f);

                PnlQ3.Location = new Point(152, 536);
                PnlQ3.Size = new Size(424, 56);
                PnlQ3.Font = new Font("ＭＳ Ｐゴシック", 15.75f);
                {
                    ChkQ3_1.Location = new Point(8, 8);
                    ChkQ3_1.Size = new Size(200, 40);
                    ChkQ3_1.Font = new Font("ＭＳ Ｐゴシック", 15.75f);

                    ChkQ3_2.Location = new Point(208, 8);
                    ChkQ3_2.Size = new Size(200, 40);
                    ChkQ3_2.Font = new Font("ＭＳ Ｐゴシック", 15.75f);
                }

                //次へ
                BtnNext.Location = new Point(241, 604);
                BtnNext.Size = new Size(222, 40);
                BtnNext.Font = new Font("ＭＳ Ｐゴシック", 15.75f);

                //チェック
                BtnCheck.Location = new Point(24, 624);
                BtnCheck.Size = new Size(144, 40);
                BtnCheck.Font = new Font("ＭＳ Ｐゴシック", 15.75f);
                BtnCheck.Visible = (ifc.DispErrChk == FormCommon.Displey.表示する);

                //中止
                BtnCancel.Location = new Point(576, 640);
                BtnCancel.Size = new Size(112, 40);
                BtnCancel.Font = new Font("ＭＳ Ｐゴシック", 15.75f);

            }
        }

        /// <summary>
        //              入力フォーム　拡大
        /// </summary>
        private void SetPnlInputLarge()
        {
            //入力フォーム
            PnlInput.Size = new Size(1136, 976);
            {
                //進捗状況
                GrpProgress.Location = new Point(912, 0);
                GrpProgress.Text = "進捗状況";
                switch (ifc.Course)
                {
                    case FormCommon.Course.基礎トレーニング:
                        LblProgress11.Visible = false;
                        LblProgressCount1.Visible = false;
                        LblProgress21.Visible = false;
                        LblProgress12.Visible = false;
                        LblProgressCount2.Visible = false;
                        LblProgress22.Visible = false;
                        LblProgress13.Location = new Point(8, 40);
                        LblProgress13.Visible = true;
                        LblProgressCount3.Location = new Point(136, 40);
                        LblProgressCount3.Visible = true;
                        LblProgress23.Location = new Point(168, 40);
                        LblProgress23.Visible = true;
                        LblProgress14.Visible = false;
                        LblProgressTimer.Visible = false;
                        GrpProgress.Visible = (ifc.DispProgress == FormCommon.Displey.表示する);
                        PbTimer.Visible = false;
                        break;
                    case FormCommon.Course.レベルアップトレーニング:
                        if (ifc.DispProgress == FormCommon.Displey.表示する)
                        {
                            LblProgress11.Visible = true;
                            LblProgressCount1.Visible = true;
                            LblProgress21.Visible = true;
                            LblProgress12.Visible = true;
                            LblProgressCount2.Visible = true;
                            LblProgress22.Visible = true;
                            LblProgress13.Location = new Point(8, 56);
                            LblProgress13.Visible = true;
                            LblProgressCount3.Location = new Point(136, 56);
                            LblProgressCount3.Visible = true;
                            LblProgress23.Location = new Point(168, 56);
                            LblProgress23.Visible = true;
                            LblProgress14.Visible = (ifc.DispTimer == FormCommon.Displey.表示する);
                            LblProgressTimer.Visible = (ifc.DispTimer == FormCommon.Displey.表示する);
                            GrpProgress.Text = "";
                            GrpProgress.Visible = true;
                            PbTimer.Location = new Point(912, 104);
                            PbTimer.Visible = (ifc.DispRemain == FormCommon.Displey.表示する);
                        }
                        else if (ifc.DispTimer == FormCommon.Displey.表示する)
                        {
                            LblProgress11.Visible = false;
                            LblProgressCount1.Visible = false;
                            LblProgress21.Visible = false;
                            LblProgress12.Visible = false;
                            LblProgressCount2.Visible = false;
                            LblProgress22.Visible = false;
                            LblProgress13.Visible = false;
                            LblProgressCount3.Visible = false;
                            LblProgress23.Visible = false;
                            LblProgress14.Location = new Point(8, 24);
                            LblProgress14.Visible = true;
                            LblProgressTimer.Location = new Point(136, 24);
                            LblProgressTimer.Visible = true;
                            GrpProgress.Visible = true;
                            PbTimer.Location = new Point(912, 104);
                            PbTimer.Visible = (ifc.DispRemain == FormCommon.Displey.表示する);
                        }
                        else
                        {
                            PbTimer.Location = new Point(912, 0);
                            PbTimer.Visible = (ifc.DispRemain == FormCommon.Displey.表示する);
                            GrpProgress.Visible = false;
                        }
                        break;
                    case FormCommon.Course.実力テスト:
                        GrpProgress.Visible = false;
                        PbTimer.Visible = false;
                        break;
                }

                //カードNo
                LblNo.Location = new Point(24, 16);
                LblNo.Size = new Size(216, 40);
                LblNo.Font = new Font("ＭＳ Ｐゴシック", 27.75f);

                TxtCardNo.Location = new Point(256, 20);
                TxtCardNo.Size = new Size(144, 40);
                TxtCardNo.Font = new Font("ＭＳ Ｐゴシック", 27.75f);

                //フリガナ
                LblKanaSimei.Location = new Point(24, 80);
                LblKanaSimei.Size = new Size(216, 40);
                LblKanaSimei.Font = new Font("ＭＳ Ｐゴシック", 27.75f);

                TxtKanaSimei.Location = new Point(256, 80);
                TxtKanaSimei.Size = new Size(432, 40);
                TxtKanaSimei.Font = new Font("ＭＳ Ｐゴシック", 27.75f);

                //氏名
                LblKanjiSimei.Location = new Point(24, 144);
                LblKanjiSimei.Size = new Size(216, 40);
                LblKanjiSimei.Font = new Font("ＭＳ Ｐゴシック", 27.75f);

                TxtKanjiSimei.Location = new Point(256, 144);
                TxtKanjiSimei.Size = new Size(432, 40);
                TxtKanjiSimei.Font = new Font("ＭＳ Ｐゴシック", 27.75f);

                //郵便番号
                LblPostNo.Location = new Point(24, 208);
                LblPostNo.Size = new Size(216, 40);
                LblPostNo.Font = new Font("ＭＳ Ｐゴシック", 27.75f);

                TxtPostNo.Location = new Point(256, 208);
                TxtPostNo.Size = new Size(168, 40);
                TxtPostNo.Font = new Font("ＭＳ Ｐゴシック", 27.75f);

                BtnPostNoSearch.Location = new Point(424, 208);
                BtnPostNoSearch.Size = new Size(176, 40);
                BtnPostNoSearch.Font = new Font("ＭＳ Ｐゴシック", 24f);
                BtnPostNoSearch.Visible = (ifc.ZipSearch == FormCommon.ZipSearch.使用);

                //住所
                LblAddress.Location = new Point(24, 272);
                LblAddress.Size = new Size(216, 40);
                LblAddress.Font = new Font("ＭＳ Ｐゴシック", 27.75f);

                TxtAddress.Location = new Point(256, 272);
                TxtAddress.Size = new Size(880, 40);
                TxtAddress.Font = new Font("ＭＳ Ｐゴシック", 27.75f);

                //電話番号
                LblTelNo.Location = new Point(24, 336);
                LblTelNo.Size = new Size(216, 40);
                LblTelNo.Font = new Font("ＭＳ Ｐゴシック", 27.75f);

                TxtTelNo.Location = new Point(256, 336);
                TxtTelNo.Size = new Size(432, 40);
                TxtTelNo.Font = new Font("ＭＳ Ｐゴシック", 27.75f);

                //メールアドレス
                LblMailAddress.Location = new Point(0, 400);
                LblMailAddress.Size = new Size(256, 40);
                LblMailAddress.Font = new Font("ＭＳ Ｐゴシック", 27.75f);

                TxtMailAddress.Location = new Point(256, 400);
                TxtMailAddress.Size = new Size(880, 40);
                TxtMailAddress.Font = new Font("ＭＳ Ｐゴシック", 27.75f);

                //問１
                LblQ1.Location = new Point(24, 464);
                LblQ1.Size = new Size(216, 40);
                LblQ1.Font = new Font("ＭＳ Ｐゴシック", 27.75f);

                CmbQ1.Location = new Point(256, 464);
                CmbQ1.Size = new Size(456, 40);
                CmbQ1.Font = new Font("ＭＳ Ｐゴシック", 27.75f);

                //問２
                LblQ2.Location = new Point(24, 536);
                LblQ2.Size = new Size(216, 40);
                LblQ2.Font = new Font("ＭＳ Ｐゴシック", 27.75f);

                PnlQ2.Location = new Point(256, 520);
                PnlQ2.Size = new Size(664, 144);
                PnlQ2.Font = new Font("ＭＳ Ｐゴシック", 27.75f);
                {
                    RdiQ2_1.Location = new Point(8, 8);
                    RdiQ2_1.Size = new Size(336, 64);
                    RdiQ2_1.Font = new Font("ＭＳ Ｐゴシック", 27.75f);

                    RdiQ2_2.Location = new Point(336, 8);
                    RdiQ2_2.Size = new Size(336, 64);
                    RdiQ2_2.Font = new Font("ＭＳ Ｐゴシック", 27.75f);

                    RdiQ2_3.Location = new Point(8, 72);
                    RdiQ2_3.Size = new Size(336, 64);
                    RdiQ2_3.Font = new Font("ＭＳ Ｐゴシック", 27.75f);

                    RdiQ2_4.Location = new Point(336, 72);
                    RdiQ2_4.Size = new Size(336, 64);
                    RdiQ2_4.Font = new Font("ＭＳ Ｐゴシック", 27.75f);
                }

                //問３
                LblQ3.Location = new Point(24, 680);
                LblQ3.Size = new Size(216, 40);
                LblQ3.Font = new Font("ＭＳ Ｐゴシック", 27.75f);

                PnlQ3.Location = new Point(256, 664);
                PnlQ3.Size = new Size(632, 80);
                PnlQ3.Font = new Font("ＭＳ Ｐゴシック", 27.75f);
                {
                    ChkQ3_1.Location = new Point(8, 8);
                    ChkQ3_1.Size = new Size(304, 64);
                    ChkQ3_1.Font = new Font("ＭＳ Ｐゴシック", 27.75f);

                    ChkQ3_2.Location = new Point(336, 8);
                    ChkQ3_2.Size = new Size(304, 64);
                    ChkQ3_2.Font = new Font("ＭＳ Ｐゴシック", 27.75f);
                }

                //次へ
                BtnNext.Location = new Point(402, 744);
                BtnNext.Size = new Size(332, 56);
                BtnNext.Font = new Font("ＭＳ Ｐゴシック", 27.75f);

                //チェック
                BtnCheck.Location = new Point(24, 904);
                BtnCheck.Size = new Size(192, 56);
                BtnCheck.Font = new Font("ＭＳ Ｐゴシック", 27.75f);
                BtnCheck.Visible = (ifc.DispErrChk == FormCommon.Displey.表示する);

                //中止
                BtnCancel.Location = new Point(968, 912);
                BtnCancel.Size = new Size(152, 56);
                BtnCancel.Font = new Font("ＭＳ Ｐゴシック", 27.75f);

            }
        }

        /// <summary>
        //              入力フォーム　クリア
        /// </summary>
        private void ClearInputForm(Boolean setCardNo)
        {
            LblProgressCount3.Text = InputCount.ToString();

            //カードNo
            if (ifc.Teiji == FormCommon.Teiji.番号順)
            {
                cardNO++;
                if (cardNO > 500)
                {
                    cardNO = 1;
                }
                if (setCardNo)
                {
                    UpdateCardNo();
                }
            }
            else
            {
                cardNO = rndCard.Next(1, 501);
            }
            TxtCardNo.Text = cardNO.ToString("0000");

            //フリガナ
            LblKanaSimei.ForeColor = Color.Black;
            TxtKanaSimei.Text = "";

            //氏名
            LblKanjiSimei.ForeColor = Color.Black;
            TxtKanjiSimei.Text = "";

            //郵便番号
            LblPostNo.ForeColor = Color.Black;
            TxtPostNo.Text = "";

            //住所
            LblAddress.ForeColor = Color.Black;
            TxtAddress.Text = "";

            //電話番号
            LblTelNo.ForeColor = Color.Black;
            TxtTelNo.Text = "";

            //メールアドレス
            LblMailAddress.ForeColor = Color.Black;
            TxtMailAddress.Text = "";

            //問１
            LblQ1.ForeColor = Color.Black;
            CmbQ1.SelectedIndex = 0;

            //問２
            LblQ2.ForeColor = Color.Black;
            RdiQ2_4.Checked = true;

            //問３
            LblQ3.ForeColor = Color.Black;
            ChkQ3_1.Checked = false;
            ChkQ3_2.Checked = false;

            //フォーカスセット
            TxtKanaSimei.Focus();
            TxtKanaSimei.Select(0, 0);

        }

        /// <summary>
        //              アンケートカード　表示
        /// </summary>
        private void DispCard()
        {
            //アンケートカードデータ取得
            getCardData();

            //カードNo
            LblCardNo_C.Text = cardNO.ToString("0000");

            //フリガナ
            LblKanaSimei_C.Text = CurCardData.NameKana;

            //氏名
            LblKanjiSimei_C.Text = CurCardData.NameKanji;

            //住所
            LblPostNo_C.Text = CurCardData.ZipCode;

            LblAddress_C.Text = CurCardData.Address;

            //電話番号
            LblTelNo_C.Text = CurCardData.TelNo;

            //メールアドレス
            LblMailAddress_C.Text = CurCardData.MailAddress;

            //問１
            {
                LblQ1Value.Text = CurCardData.Q1Answer;
                if (string.IsNullOrEmpty(LblQ1Value.Text))
                {
                    LblQ1Value.Text = "0";
                }

                PbxQ1.Visible = false;

                if (LblQ1Value.Text != "0")
                {
                    //描画先とするImageオブジェクトを作成する
                    Bitmap canvas = new Bitmap(PbxQ1.Width, PbxQ1.Height);
                    //ImageオブジェクトのGraphicsオブジェクトを作成する
                    Graphics g = Graphics.FromImage(canvas);

                    //楕円を黒で描く
                    if (ifc.InputImage == FormCommon.Expansion.拡大)
                    {
                        Pen BoldPen = new Pen(Color.FromArgb(255, 0, 0, 0), 4);
                        g.DrawEllipse(BoldPen, 4, 4, 32, 24);
                    }
                    else
                    {
                        Pen BoldPen = new Pen(Color.FromArgb(255, 0, 0, 0), 3);
                        g.DrawEllipse(BoldPen, 2, 2, 32, 24);
                    }

                    //リソースを解放する
                    g.Dispose();

                    //PictureBoxに表示する
                    PbxQ1.Image = canvas;

                    switch (CurCardData.Q1Answer)
                    {
                        case "1":
                            PbxQ1.Parent = LblQuestion1_1;
                            break;
                        case "2":
                            PbxQ1.Parent = LblQuestion1_2;
                            break;
                        case "3":
                            PbxQ1.Parent = LblQuestion1_3;
                            break;
                        case "4":
                            PbxQ1.Parent = LblQuestion1_4;
                            break;
                        case "5":
                            PbxQ1.Parent = LblQuestion1_5;
                            break;
                        case "6":
                            PbxQ1.Parent = LblQuestion1_6;
                            break;
                    }
                    if (ifc.InputImage == FormCommon.Expansion.拡大)
                    {
                        PbxQ1.Location = new Point(0, 4);
                    }
                    else
                    {
                        PbxQ1.Location = new Point(0, 8);
                    }
                    PbxQ1.Size = new Size(40, 40);
                    PbxQ1.Visible = true;
                }
            }

            //問２
            {
                LblQ2Value.Text = CurCardData.Q2Answer;
                if (string.IsNullOrEmpty(LblQ2Value.Text))
                {
                    LblQ2Value.Text = "0";
                }

                PbxQ2.Visible = false;

                if (LblQ2Value.Text != "0")
                {
                    //描画先とするImageオブジェクトを作成する
                    Bitmap canvas = new Bitmap(PbxQ2.Width, PbxQ2.Height);
                    //ImageオブジェクトのGraphicsオブジェクトを作成する
                    Graphics g = Graphics.FromImage(canvas);

                    //楕円を黒で描く
                    if (ifc.InputImage == FormCommon.Expansion.拡大)
                    {
                        Pen BoldPen = new Pen(Color.FromArgb(255, 0, 0, 0), 4);
                        g.DrawEllipse(BoldPen, 4, 4, 32, 24);
                    }
                    else
                    {
                        Pen BoldPen = new Pen(Color.FromArgb(255, 0, 0, 0), 3);
                        g.DrawEllipse(BoldPen, 2, 2, 32, 24);
                    }

                    //リソースを解放する
                    g.Dispose();

                    //PictureBoxに表示する
                    PbxQ2.Image = canvas;

                    switch (CurCardData.Q2Answer)
                    {
                        case "1":
                            PbxQ2.Parent = LblQuestion2_1;
                            break;
                        case "2":
                            PbxQ2.Parent = LblQuestion2_2;
                            break;
                        case "3":
                            PbxQ2.Parent = LblQuestion2_3;
                            break;
                    }
                    if (ifc.InputImage == FormCommon.Expansion.拡大)
                    {
                        PbxQ2.Location = new Point(0, 4);
                    }
                    else
                    {
                        PbxQ2.Location = new Point(0, 8);
                    }
                    PbxQ2.Size = new Size(40, 40);
                    PbxQ2.Visible = true;
                }
            }

            //問３
            {
                LblQ3Value.Text = CurCardData.Q3Answer;
                if (string.IsNullOrEmpty(LblQ3Value.Text))
                {
                    LblQ3Value.Text = "0";
                }

                PbxQ3.Visible = false;

                if (LblQ3Value.Text != "0")
                {
                    //描画先とするImageオブジェクトを作成する
                    Bitmap canvas = new Bitmap(PbxQ3.Width, PbxQ3.Height);
                    //ImageオブジェクトのGraphicsオブジェクトを作成する
                    Graphics g = Graphics.FromImage(canvas);

                    //レ点を黒で描く
                    if (ifc.InputImage == FormCommon.Expansion.拡大)
                    {
                        Pen BoldPen = new Pen(Color.FromArgb(255, 0, 0, 0), 4);
                        g.DrawLine(BoldPen, 10, 16, 18, 28);
                        g.DrawLine(BoldPen, 18, 28, 28, 4);
                    }
                    else
                    {
                        Pen BoldPen = new Pen(Color.FromArgb(255, 0, 0, 0), 3);
                        g.DrawLine(BoldPen, 8, 12, 14, 20);
                        g.DrawLine(BoldPen, 14, 20, 22, 4);
                    }

                    //リソースを解放する
                    g.Dispose();

                    //PictureBoxに表示する
                    PbxQ3.Image = canvas;

                    switch (CurCardData.Q3Answer)
                    {
                        case "1":
                            PbxQ3.Parent = LblQuestion3_1;
                            break;
                        case "2":
                            PbxQ3.Parent = LblQuestion3_2;
                            break;
                    }
                    PbxQ3.Location = new Point(0, 4);
                    PbxQ3.Size = new Size(48, 36);
                    PbxQ3.Visible = true;
                }
            }

        }

        /// <summary>
        //              アンケートカードデータ　取得処理
        /// </summary>
        /// <returns>true:正常終了　false:異常終了</returns>
        private Boolean getCardData()
        {
            try
            {
                // SQL クエリ
                string sql = "";

                // データＤＢを開く
                using (SQLiteConnection con = new SQLiteConnection(SetconnectionString(connectionStringM)))
                {
                    con.Open();

                    CurCardData = new 構造体.アンケートカード項目();
                    CurCardData.id = 0;

                    while (CurCardData.id == 0)
                    {
                        //アンケートカードデータを取得して、表示する
                        sql = "SELECT * From " + cardDataTbl + " WHERE id = " + cardNO.ToString() + " and jyogaiflg = 0";

                        using (SQLiteCommand command = new SQLiteCommand(sql, con))
                        {
                            using (SQLiteDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    // データの処理
                                    CurCardData.id = reader.GetInt32(0);
                                    CurCardData.NameKana = reader.GetString(1);
                                    CurCardData.NameKanji = reader.GetString(2);
                                    CurCardData.ZipCode = reader.GetString(3);
                                    CurCardData.Address = reader.GetString(4);
                                    CurCardData.TelNo = reader.GetString(5);
                                    CurCardData.MailAddress = reader.GetString(6);
                                    CurCardData.Q1Answer = reader.GetString(7);
                                    CurCardData.Q2Answer = reader.GetString(8);
                                    CurCardData.Q3Answer = reader.GetString(9);
                                }
                            }
                        }
                        if (CurCardData.id == 0)
                        {
                            if (ifc.Teiji == FormCommon.Teiji.番号順)
                            {
                                cardNO++;
                                if (cardNO > 500)
                                {
                                    cardNO = 1;
                                }
                            }
                            else
                            {
                                cardNO = rndCard.Next(1, 501);
                            }
                            TxtCardNo.Text = cardNO.ToString("0000");
                        }
                    }
                    con.Close();
                }

                CurInputData = new 構造体.アンケートカード入力値();
                //CurInputData.StartTime = StartTime;
                CurInputData.StartTime = DateTime.Now;
                CurInputData.id = cardNO.ToString("0000");

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
        //              郵便番号　検索処理
        /// </summary>
        /// <returns>true:正常終了　false:異常終了</returns>
        private Boolean SearchZipCode()
        {
            String ZipCode7 = "";
            var AddressKanji = new List<String>();

            //郵便番号7桁編集
            if (TxtPostNo.Text.Length == 8)
            {
                ZipCode7 = TxtPostNo.Text.Substring(0, 3) + TxtPostNo.Text.Substring(4, 4);
            }
            else
            {
                ZipCode7 = TxtPostNo.Text;
            }
            try
            {
                // SQL クエリ
                string sql = "";

                // データＤＢを開く
                using (SQLiteConnection con = new SQLiteConnection(SetconnectionString(connectionStringM)))
                {
                    con.Open();

                    //ユーザマスタを取得して、表示する
                    sql = "SELECT TodofukenKanji||City1Kanji||City2Kanji as AddressKanji From MstPostNo WHERE ZipCode7 = '" + ZipCode7 + "'";

                    using (SQLiteCommand command = new SQLiteCommand(sql, con))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // データの処理
                                AddressKanji.Add(reader.GetString(0));
                            }
                        }
                    }
                    con.Close();
                }
                if (AddressKanji.Count == 1)
                {
                    TxtAddress.Text = AddressKanji[0];
                    TxtAddress.Focus();
                    TxtAddress.Select(TxtAddress.Text.Length, 0);

                }
                else if (AddressKanji.Count > 1)
                {
                    共通プロパティ.SelectedAddress = null;

                    Frm郵便番号選択 frm = new Frm郵便番号選択(TxtPostNo.Text, AddressKanji);
                    frm.ShowDialog();
                    if (共通プロパティ.SelectedAddress != null)
                    {
                        TxtAddress.Text = 共通プロパティ.SelectedAddress;
                        TxtAddress.Focus();
                        TxtAddress.Select(TxtAddress.Text.Length, 0);
                    }
                }
                else
                {
                    MessageBox.Show("郵便番号が見つかりません。");
                }

                return AddressKanji.Count > 0;
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
        //              入力フォーム　チェック
        /// </summary>
        private Boolean CheckInput(Boolean DispFlg)
        {
            Boolean Ret = true;

            CurCorrectData = new 構造体.アンケートカード項目();
            CurMojiData = new 構造体.共通エラー文字種別();

            //カード№
            CurCorrectData.id = cardNO;
            CurMojiData.id = cardNO;
            //フリガナ
            if (TxtKanaSimei.Text != LblKanaSimei_C.Text)
            {
                CurCorrectData.NameKana = "×";

                //文字チェック
                CheckChar(LblKanaSimei_C.Text, TxtKanaSimei.Text);

                if (DispFlg) LblKanaSimei.ForeColor = Color.Red;
                Ret = false;
            }
            else
            {
                LblKanaSimei.ForeColor = Color.Black;
            }
            CurInputData.NameKana = TxtKanaSimei.Text;

            //氏名
            if (TxtKanjiSimei.Text != LblKanjiSimei_C.Text)
            {
                CurCorrectData.NameKanji = "×";

                //文字チェック
                CheckChar(LblKanjiSimei_C.Text, TxtKanjiSimei.Text);

                if (DispFlg) LblKanjiSimei.ForeColor = Color.Red;
                Ret = false;
            }
            else
            {
                LblKanjiSimei.ForeColor = Color.Black;
            }
            CurInputData.NameKanji = TxtKanjiSimei.Text;

            //郵便番号
            if (TxtPostNo.Text != LblPostNo_C.Text)
            {
                CurCorrectData.ZipCode = "×";

                //文字チェック
                CheckChar(LblPostNo_C.Text, TxtPostNo.Text);

                if (DispFlg) LblPostNo.ForeColor = Color.Red;
                Ret = false;
            }
            else
            {
                LblPostNo.ForeColor = Color.Black;
            }
            CurInputData.ZipCode = TxtPostNo.Text;

            //住所
            if (TxtAddress.Text != LblAddress_C.Text)
            {
                CurCorrectData.Address = "×";

                //文字チェック
                CheckChar(LblAddress_C.Text, TxtAddress.Text);

                if (DispFlg) LblAddress.ForeColor = Color.Red;
                Ret = false;
            }
            else
            {
                LblAddress.ForeColor = Color.Black;
            }
            CurInputData.Address = TxtAddress.Text;

            //電話番号
            if (TxtTelNo.Text != LblTelNo_C.Text)
            {
                CurCorrectData.TelNo = "×";

                //文字チェック
                CheckChar(LblTelNo_C.Text, TxtTelNo.Text);

                if (DispFlg) LblTelNo.ForeColor = Color.Red;
                Ret = false;
            }
            else
            {
                LblTelNo.ForeColor = Color.Black;
            }
            CurInputData.TelNo = TxtTelNo.Text;

            //メールアドレス
            if (TxtMailAddress.Text != LblMailAddress_C.Text)
            {
                CurCorrectData.MailAddress = "×";

                //文字チェック
                CheckChar(LblMailAddress_C.Text, TxtMailAddress.Text);

                if (DispFlg) LblMailAddress.ForeColor = Color.Red;
                Ret = false;
            }
            else
            {
                LblMailAddress.ForeColor = Color.Black;
            }
            CurInputData.MailAddress = TxtMailAddress.Text;

            //問１
            int Q1Value = CmbQ1.SelectedIndex;
            if (Q1Value.ToString() != LblQ1Value.Text)
            {
                CurCorrectData.Q1Answer = "×";

                //文字チェック
                CheckChar(LblQ1Value.Text, Q1Value.ToString());

                if (DispFlg) LblQ1.ForeColor = Color.Red;
                Ret = false;
            }
            else
            {
                LblQ1.ForeColor = Color.Black;
            }
            CurInputData.Q1Answer = Q1Value.ToString();

            //問２
            string Q2Value = "0";
            if (RdiQ2_1.Checked) Q2Value = "1";
            if (RdiQ2_2.Checked) Q2Value = "2";
            if (RdiQ2_3.Checked) Q2Value = "3";
            if (Q2Value != LblQ2Value.Text)
            {
                CurCorrectData.Q2Answer = "×";

                //文字チェック
                CheckChar(LblQ2Value.Text, Q2Value.ToString());

                if (DispFlg) LblQ2.ForeColor = Color.Red;
                Ret = false;
            }
            else
            {
                LblQ2.ForeColor = Color.Black;
            }
            CurInputData.Q2Answer = Q2Value.ToString();

            //問３
            if ((ChkQ3_1.Checked) && (ChkQ3_2.Checked))
            {
                CurCorrectData.Q3Answer = "×";

                //文字チェック
                CheckChar(LblQ3Value.Text, "3");

                if (DispFlg) LblQ3.ForeColor = Color.Red;
                Ret = false;
            }
            else if ((ChkQ3_1.Checked) && (LblQ3Value.Text != "1"))
            {
                CurCorrectData.Q3Answer = "×";

                //文字チェック
                CheckChar(LblQ3Value.Text, "1");

                if (DispFlg) LblQ3.ForeColor = Color.Red;
                Ret = false;
            }
            else if ((ChkQ3_2.Checked) && (LblQ3Value.Text != "2"))
            {
                CurCorrectData.Q3Answer = "×";

                //文字チェック
                CheckChar(LblQ3Value.Text, "2");

                if (DispFlg) LblQ3.ForeColor = Color.Red;
                Ret = false;
            }
            else if (!(ChkQ3_1.Checked) && !(ChkQ3_2.Checked) && (LblQ3Value.Text != "0"))
            {
                CurCorrectData.Q3Answer = "×";

                //文字チェック
                CheckChar(LblQ3Value.Text, "0");

                if (DispFlg) LblQ3.ForeColor = Color.Red;
                Ret = false;
            }
            else
            {
                LblQ3.ForeColor = Color.Black;
            }

            if ((ChkQ3_1.Checked) && (ChkQ3_2.Checked))
            {
                CurInputData.Q3Answer = "両方ともON";
            }
            else if (ChkQ3_1.Checked)
            {
                CurInputData.Q3Answer = "1";
            }
            else if (ChkQ3_2.Checked)
            {
                CurInputData.Q3Answer = "2";
            }
            else
            {
                CurInputData.Q3Answer = "0";
            }

            if (DispFlg) CurInputData.CheckCnt++;

            //件数カウント
            if (!DispFlg) InputCount++;

            return Ret;
        }

        /// <summary>
        //              カード№更新
        /// </summary>
        private void UpdateCardNo()
        {
            try
            {
                // SQL クエリ
                string sql = "";
                SQLiteCommand com;

                // データＤＢを開く
                using (SQLiteConnection con = new SQLiteConnection(SetconnectionString(connectionStringD)))
                {
                    con.Open();

                    //ユーザマスタを取得して、表示する
                    sql = "UPDATE ユーザマスタ SET Start_No1 = " + cardNO.ToString() + ","
                        + "UpdDate   = datetime('now', 'localtime') "
                        + " WHERE id = " + ifc.Id.ToString();

                    com = new SQLiteCommand(sql, con);
                    com.ExecuteNonQuery();

                    con.Close();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
                //終了
                共通プロパティ.ReturnMenu = true;
                this.Dispose();
                this.Close();
            }
        }

        /// <summary>
        //              文字チェック
        /// </summary>
        /// <param name="MasterStr">カード文字列</param>
        /// <param name="InputStr">入力文字列</param>
        private void CheckChar(string MasterStr, string InputStr)
        {

            for (int i = 0; i < MasterStr.Length; i++)
            {
                char ChkChar = ControlChars.Tab;
                if (i < InputStr.Length) ChkChar = InputStr[i];

                if (MasterStr[i] != ChkChar)
                {
                    //カタカナ
                    if (('\u30A1' <= MasterStr[i] && MasterStr[i] <= '\u30FA') ||
                        ('\u30FC' <= MasterStr[i] && MasterStr[i] <= '\u30FF') ||
                        ('\u31F0' <= MasterStr[i] && MasterStr[i] <= '\u31FF') ||
                        ('\u3099' <= MasterStr[i] && MasterStr[i] <= '\u309C') ||
                        ('\uFF66' <= MasterStr[i] && MasterStr[i] <= '\uFF9F'))
                    {
                        CurMojiData.Kana = "×";
                    }
                    //数字
                    else if ('0' <= MasterStr[i] && MasterStr[i] <= '9')
                    {
                        CurMojiData.Suuji = "×";
                    }
                    //英大文字
                    else if ('A' <= MasterStr[i] && MasterStr[i] <= 'Z')
                    {
                        CurMojiData.EiOumoji = "×";
                    }
                    //英小文字
                    else if ('a' <= MasterStr[i] && MasterStr[i] <= 'z')
                    {
                        CurMojiData.EiKomoji = "×";
                    }
                    //記号
                    else if (char.IsSymbol(MasterStr[i]))
                    {
                        CurMojiData.Kigou = "×";
                    }
                    else if (MasterStr[i] == '-' || MasterStr[i] == '.' || MasterStr[i] == ',' || MasterStr[i] == '@')
                    {
                        CurMojiData.Kigou = "×";
                    }
                    //漢字
                    else
                    {
                        CurMojiData.Kanji = "×";
                    }
                }
                if (InputStr.Length > MasterStr.Length)
                {
                    CurMojiData.Kigou = "×";
                }
            }

        }

        /// <summary>
        //              解析結果出力
        /// </summary>
        private void OutputResultText()
        {
            string FileInput = "";
            string FileResult = "";
            int Cnt = 0;
            int CntNameKana = 0;
            int CntNameKan = 0;
            int CntZipCode = 0;
            int CntAddress = 0;
            int CntTelNo = 0;
            int CntMailAddress = 0;
            int CntQ1Answer = 0;
            int CntQ2Answer = 0;
            int CntQ3Answer = 0;
            int CntKana = 0;
            int CntKanji = 0;
            int CntSuuji = 0;
            int CntEiOumoji = 0;
            int CntEiKomoji = 0;
            int CntKigou = 0;
            int CntInputData = 0;

            try
            {
                if (!Directory.Exists("解析結果")) Directory.CreateDirectory("解析結果");
                if (!Directory.Exists("解析結果\\" + ifc.Id)) Directory.CreateDirectory("解析結果\\" + ifc.Id);

                //入力値ファイル名
                FileInput = "解析結果\\" + ifc.Id + "\\" + StartTime.ToString("yyyyMMdd") + "_" + StartTime.ToString("HHmmss")
                          + "_入力値_アンケート_" + ifc.NameSi + "_" + ifc.NameMei + ".csv";

                //解析結果ファイル名
                FileResult = "解析結果\\" + ifc.Id + "\\" + StartTime.ToString("yyyyMMdd") + "_" + StartTime.ToString("HHmmss")
                           + "_解析結果_アンケート_" + ifc.NameSi + "_" + ifc.NameMei + ".csv";

                //入力値ファイル出力
                using (StreamWriter sw = new StreamWriter(FileInput, false, Encoding.UTF8))
                {
                    sw.WriteLine("開始時刻,終了時刻,経過時間,評価除外フラグ,NO.,フリガナ,氏名,郵便番号,住所,電話番号,メールアドレス,問１,問２,問３" +
                                 ((ifc.Course == FormCommon.Course.基礎トレーニング) ? ",チェック" : ""));


                    foreach (構造体.アンケートカード入力値 InputData in ListInputData)
                    {
                        CntInputData++;
                        if ((CntInputData == ListInputData.Count) && (LastInputSW)) break;

                        sw.WriteLine(InputData.StartTime.ToString("HH:mm:ss") + "," +
                                     InputData.EndTime.ToString("HH:mm:ss") + "," +
                                     InputData.ElapsedTime + "," +
                                     InputData.JogaiFlg + "," +
                                     InputData.id + "," +
                                     InputData.NameKana + "," +
                                     InputData.NameKanji + "," +
                                     InputData.ZipCode + "," +
                                     InputData.Address + "," +
                                     InputData.TelNo + "," +
                                     InputData.MailAddress + "," +
                                     ((InputData.Q1Answer == "0") ? "" : InputData.Q1Answer) + "," +
                                     ((InputData.Q2Answer == "0") ? "" : InputData.Q2Answer) + "," +
                                     ((InputData.Q3Answer == "0") ? "" : InputData.Q3Answer) +
                                     ((ifc.Course == FormCommon.Course.基礎トレーニング) ? "," + InputData.CheckCnt.ToString() : "")
                                    );
                    }
                }

                //解析結果ファイル出力
                using (StreamWriter sw = new StreamWriter(FileResult, false, Encoding.UTF8))
                {
                    Decimal WorkCnt = ListCorrectData.Count;
                    Decimal OKCnt = 0;
                    Decimal NGCnt = 0;
                    String OKAve = "";
                    String NGAve = "";
                    String OutputLine = "";

                    if (LastInputSW) WorkCnt--;

                    sw.WriteLine("アンケート入力・解析結果");
                    sw.WriteLine("");

                    sw.WriteLine("■採点結果");
                    sw.WriteLine("作業枚数,正解枚数,エラー枚数,正解率,エラー率,開始時刻,終了時刻");

                    CntInputData = 0;
                    foreach (構造体.アンケートカード項目 CorrectData in ListCorrectData)
                    {
                        CntInputData++;
                        if ((CntInputData == ListInputData.Count) && (LastInputSW)) break;

                        if (CorrectData.NameKana != "" ||
                            CorrectData.NameKanji != "" ||
                            CorrectData.ZipCode != "" ||
                            CorrectData.Address != "" ||
                            CorrectData.TelNo != "" ||
                            CorrectData.MailAddress != "" ||
                            CorrectData.Q1Answer != "" ||
                            CorrectData.Q2Answer != "" ||
                            CorrectData.Q3Answer != "")
                        {
                            NGCnt++;
                        }
                        else
                        {
                            OKCnt++;
                        }
                    }

                    if (WorkCnt > 0)
                    {
                        OKAve = Math.Round((OKCnt / WorkCnt) * 100, 2, MidpointRounding.AwayFromZero).ToString("0.00") + "%";
                        NGAve = Math.Round((NGCnt / WorkCnt) * 100, 2, MidpointRounding.AwayFromZero).ToString("0.00") + "%";
                    }
                    else
                    {
                        OKAve = "0.00%";
                        NGAve = "0.00%";
                    }
                    sw.WriteLine(WorkCnt.ToString() + "枚," +
                                 OKCnt.ToString() + "枚," +
                                 NGCnt.ToString() + "枚," +
                                 OKAve + "," +
                                 NGAve + "," +
                                 StartTime.ToString("yyyy/MM/dd HH:mm:ss") + "," +
                                 EndTime.ToString("yyyy/MM/dd HH:mm:ss")
                                );
                    sw.WriteLine("");

                    sw.WriteLine("■目標設定");
                    sw.WriteLine("コース,目標作業枚数,目標正しい枚数,フィードバック方法,選択色");

                    switch (ifc.Course)
                    {
                        case FormCommon.Course.実力テスト:
                            OutputLine = "実力テスト,,,,";
                            break;

                        case FormCommon.Course.基礎トレーニング:
                            OutputLine = "基礎トレーニング,,,,";
                            break;
                        case FormCommon.Course.レベルアップトレーニング:
                            OutputLine = "レベルアップトレーニング,"
                                       + ifc.WorkCnt.ToString() + "枚,"
                                       + ifc.CorrectCnt.ToString() + "枚,"
                                       + "文字色,黒";                               //フィードバックは「文字色,黒」で固定
                            break;
                        default:
                            OutputLine = ",,,,";
                            break;
                    }
                    sw.WriteLine(OutputLine);
                    sw.WriteLine("");

                    sw.WriteLine("■試行条件の設定");
                    sw.WriteLine("終了設定時間,課題媒体,呈示方法,進捗呈示,残り時間タイマー,〒,切替音");

                    //終了設定時間
                    OutputLine = ifc.Timer.ToString() + "分,";
                    //課題媒体
                    switch (ifc.FormDisp)
                    {
                        case FormCommon.FormDisp.紙:
                            OutputLine += "紙,";
                            break;
                        case FormCommon.FormDisp.画面:
                            OutputLine += "画面,";
                            break;
                        default:
                            OutputLine = ",";
                            break;
                    }
                    //呈示方法
                    switch (ifc.Teiji)
                    {
                        case FormCommon.Teiji.番号順:
                            OutputLine += "番号順,";
                            break;

                        case FormCommon.Teiji.シャッフル:
                            OutputLine += "シャッフル,";
                            break;
                        default:
                            OutputLine = ",";
                            break;
                    }
                    //進捗呈示
                    switch (ifc.DispProgress)
                    {
                        case FormCommon.Displey.表示する:
                            OutputLine += "○,";
                            break;

                        case FormCommon.Displey.表示しない:
                            OutputLine += "×,";
                            break;
                        default:
                            OutputLine = ",";
                            break;
                    }
                    //残り時間タイマー                  //タイマー表示が対象
                    switch (ifc.DispTimer)
                    {
                        case FormCommon.Displey.表示する:
                            OutputLine += "○,";
                            break;

                        case FormCommon.Displey.表示しない:
                            OutputLine += "×,";
                            break;
                        default:
                            OutputLine = ",";
                            break;
                    }
                    //〒
                    switch (ifc.ZipSearch)
                    {
                        case FormCommon.ZipSearch.使用:
                            OutputLine += "○,";
                            break;

                        case FormCommon.ZipSearch.未使用:
                            OutputLine += "×,";
                            break;
                        default:
                            OutputLine = ",";
                            break;
                    }
                    //切替音
                    OutputLine += "×";
                    sw.WriteLine(OutputLine);
                    sw.WriteLine("");

                    sw.WriteLine("■項目別エラー一覧");
                    sw.WriteLine("エラー,カードNo.,フリガナ,名前,郵便番号,住所,電話番号,メールアドレス,問１,問２,問３,経過時間");

                    Cnt = 0;
                    CntNameKana = 0;
                    CntNameKan = 0;
                    CntZipCode = 0;
                    CntAddress = 0;
                    CntTelNo = 0;
                    CntMailAddress = 0;
                    CntQ1Answer = 0;
                    CntQ2Answer = 0;
                    CntQ3Answer = 0;
                    CntInputData = 0;

                    foreach (構造体.アンケートカード項目 InputData in ListCorrectData)
                    {
                        CntInputData++;
                        if ((CntInputData == ListInputData.Count) && (LastInputSW)) break;

                        if (InputData.NameKana == "×") CntNameKana++;
                        if (InputData.NameKanji == "×") CntNameKan++;
                        if (InputData.ZipCode == "×") CntZipCode++;
                        if (InputData.Address == "×") CntAddress++;
                        if (InputData.TelNo == "×") CntTelNo++;
                        if (InputData.MailAddress == "×") CntMailAddress++;
                        if (InputData.Q1Answer == "×") CntQ1Answer++;
                        if (InputData.Q2Answer == "×") CntQ2Answer++;
                        if (InputData.Q3Answer == "×") CntQ3Answer++;

                        if ((InputData.NameKana == "×") ||
                            (InputData.NameKanji == "×") ||
                            (InputData.ZipCode == "×") ||
                            (InputData.Address == "×") ||
                            (InputData.TelNo == "×") ||
                            (InputData.MailAddress == "×") ||
                            (InputData.Q1Answer == "×") ||
                            (InputData.Q2Answer == "×") ||
                            (InputData.Q3Answer == "×"))
                        {
                            Cnt++;
                            sw.WriteLine(Cnt.ToString() + "," +
                                         InputData.id.ToString("0000") + "," +
                                         InputData.NameKana + "," +
                                         InputData.NameKanji + "," +
                                         InputData.ZipCode + "," +
                                         InputData.Address + "," +
                                         InputData.TelNo + "," +
                                         InputData.MailAddress + "," +
                                         InputData.Q1Answer + "," +
                                         InputData.Q2Answer + "," +
                                         InputData.Q3Answer + "," +
                                         ListInputData[CntInputData - 1].ElapsedTime
                                        );
                        }
                    }
                    sw.WriteLine("合計," +
                                 "," +
                                 CntNameKana.ToString() + "枚," +
                                 CntNameKan.ToString() + "枚," +
                                 CntZipCode.ToString() + "枚," +
                                 CntAddress.ToString() + "枚," +
                                 CntTelNo.ToString() + "枚," +
                                 CntMailAddress.ToString() + "枚," +
                                 CntQ1Answer.ToString() + "枚," +
                                 CntQ2Answer.ToString() + "枚," +
                                 CntQ3Answer.ToString() + "枚"
                                );
                    sw.WriteLine("");

                    sw.WriteLine("■文字種別エラー一覧");
                    sw.WriteLine("エラー,カードNo.,カナ,漢字,数字,英大文字,英小文字,記号等,経過時間");

                    Cnt = 0;
                    CntKana = 0;
                    CntKanji = 0;
                    CntSuuji = 0;
                    CntEiOumoji = 0;
                    CntEiKomoji = 0;
                    CntKigou = 0;
                    CntInputData = 0;

                    foreach (構造体.共通エラー文字種別 InputData in ListMojiData)
                    {
                        CntInputData++;
                        if ((CntInputData == ListInputData.Count) && (LastInputSW)) break;

                        if (InputData.Kana == "×") CntKana++;
                        if (InputData.Kanji == "×") CntKanji++;
                        if (InputData.Suuji == "×") CntSuuji++;
                        if (InputData.EiOumoji == "×") CntEiOumoji++;
                        if (InputData.EiKomoji == "×") CntEiKomoji++;
                        if (InputData.Kigou == "×") CntKigou++;

                        if ((InputData.Kana == "×") ||
                            (InputData.Kanji == "×") ||
                            (InputData.Suuji == "×") ||
                            (InputData.EiOumoji == "×") ||
                            (InputData.EiKomoji == "×") ||
                            (InputData.Kigou == "×"))
                        {
                            Cnt++;
                            sw.WriteLine(Cnt.ToString() + "," +
                                         InputData.id.ToString("0000") + "," +
                                         InputData.Kana + "," +
                                         InputData.Kanji + "," +
                                         InputData.Suuji + "," +
                                         InputData.EiOumoji + "," +
                                         InputData.EiKomoji + "," +
                                         InputData.Kigou + "," +
                                         ListInputData[CntInputData - 1].ElapsedTime
                                        );
                        }
                    }
                    sw.WriteLine("合計," +
                                 "," +
                                 CntKana.ToString() + "枚," +
                                 CntKanji.ToString() + "枚," +
                                 CntSuuji.ToString() + "枚," +
                                 CntEiOumoji.ToString() + "枚," +
                                 CntEiKomoji.ToString() + "枚," +
                                 CntKigou.ToString() + "枚"
                                );
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
                //終了
                共通プロパティ.ReturnMenu = true;
                this.Dispose();
                this.Close();
            }
        }

        /// <summary>
        //              履歴データ出力
        /// </summary>
        /// <returns>true:正常終了　false:異常終了</returns>
        private Boolean OutputHistoryData()
        {
            try
            {
                int Timer = 0;
                string FormLR = "";
                string DispProgress = "";
                string DispTimer = "";
                string DispRemain = "";
                string DispGraph = "";
                string ZipSearch = "";
                int CntInputData = 0;
                Decimal AnswerMaisu = ListCorrectData.Count;
                Decimal AnswerKoumoku = 0;
                Decimal CorrectMaisu = 0;
                Decimal CorrectKoumoku = 0;
                Decimal CorrectRate = 0;
                Decimal CorrectKoumokuRate = 0;
                Decimal AnswerMaisuHour = 0;
                Decimal AnswerKoumokuHour = 0;
                Decimal CorrectMaisuHour = 0;
                Decimal CorrectKoumokuHour = 0;
                Decimal CorrectRateHour = 0;
                Decimal CorrectKoumokuRateHour = 0;
                string CancelFlg = "";
                string WorkTime = "";


                //終了時間
                switch (ifc.Timer)
                {
                    case 15:
                        Timer = 1;
                        break;
                    case 30:
                        Timer = 2;
                        break;
                    case 45:
                        Timer = 3;
                        break;
                    case 60:
                        Timer = 4;
                        break;
                    default:
                        break;
                }

                //表示位置
                switch (ifc.FormLR)
                {
                    case FormCommon.DispLR.左:
                        FormLR = "1";
                        break;
                    case FormCommon.DispLR.右:
                        FormLR = "2";
                        break;
                    default:
                        break;
                }

                //進捗状況表示
                if (ifc.DispProgress == FormCommon.Displey.表示する) DispProgress = "1";

                //タイマー表示
                if (ifc.DispTimer == FormCommon.Displey.表示する) DispTimer = "1";

                //残り時間表示
                if (ifc.DispRemain == FormCommon.Displey.表示する) DispRemain = "1";

                //グラフ表示
                if (ifc.DispGraph == FormCommon.Displey.表示する) DispGraph = "1";

                //郵便番号検索
                if (ifc.ZipSearch == FormCommon.ZipSearch.使用) ZipSearch = "1";

                //回答枚数、回答項目数、正解枚数、正解項目数、正解率(枚数)、正解率(項目数)
                CntInputData = 0;
                foreach (構造体.アンケートカード項目 CorrectData in ListCorrectData)
                {
                    CntInputData++;
                    if ((CntInputData == ListInputData.Count) && (LastInputSW)) break;

                    if (CorrectData.NameKana != "" ||
                        CorrectData.NameKanji != "" ||
                        CorrectData.ZipCode != "" ||
                        CorrectData.Address != "" ||
                        CorrectData.TelNo != "" ||
                        CorrectData.MailAddress != "" ||
                        CorrectData.Q1Answer != "" ||
                        CorrectData.Q2Answer != "" ||
                        CorrectData.Q3Answer != "")
                    {
                        if (CorrectData.NameKana == "") CorrectKoumoku++;
                        if (CorrectData.NameKanji == "") CorrectKoumoku++;
                        if (CorrectData.ZipCode == "") CorrectKoumoku++;
                        if (CorrectData.Address == "") CorrectKoumoku++;
                        if (CorrectData.TelNo == "") CorrectKoumoku++;
                        if (CorrectData.MailAddress == "") CorrectKoumoku++;
                        if (CorrectData.Q1Answer == "") CorrectKoumoku++;
                        if (CorrectData.Q2Answer == "") CorrectKoumoku++;
                        if (CorrectData.Q3Answer == "") CorrectKoumoku++;
                    }
                    else
                    {
                        CorrectMaisu++;
                        CorrectKoumoku = CorrectKoumoku + 9;
                    }
                }
                AnswerKoumoku = AnswerMaisu * 9;

                if (AnswerMaisu > 0)
                {
                    CorrectRate = Math.Round((CorrectMaisu / AnswerMaisu) * 100, 6, MidpointRounding.AwayFromZero);
                    CorrectKoumokuRate = Math.Round((CorrectKoumoku / AnswerKoumoku) * 100, 6, MidpointRounding.AwayFromZero);
                }

                //60分あたりの(回答枚数、回答項目数、正解枚数、正解項目数、正解率(枚数)、正解率(項目数))
                AnswerMaisuHour = Math.Round((AnswerMaisu / ifc.Timer) * 60, 6, MidpointRounding.AwayFromZero);
                AnswerKoumokuHour = Math.Round((AnswerKoumoku / ifc.Timer) * 60, 6, MidpointRounding.AwayFromZero);
                CorrectMaisuHour = Math.Round((CorrectMaisu / ifc.Timer) * 60, 6, MidpointRounding.AwayFromZero);
                CorrectKoumokuHour = Math.Round((CorrectKoumoku / ifc.Timer) * 60, 6, MidpointRounding.AwayFromZero);
                if (AnswerMaisuHour > 0)
                {
                    CorrectRateHour = Math.Round((CorrectMaisuHour / AnswerMaisuHour) * 100, 6, MidpointRounding.AwayFromZero);
                    CorrectKoumokuRateHour = Math.Round((CorrectKoumokuHour / AnswerKoumokuHour) * 100, 6, MidpointRounding.AwayFromZero);
                }

                //中止フラグ
                if (!EndTimerSW) CancelFlg = "1";

                //作業時間
                Double ElapsedMillSecond = TotalWorkTime.TotalMilliseconds / 1000;
                WorkTime = Math.Truncate((ElapsedMillSecond / 60)).ToString("00") + "分"
                                       + (ElapsedMillSecond % 60).ToString("00") + "秒";


                // SQL クエリ
                string sql = "";

                // データＤＢを開く
                using (SQLiteConnection con = new SQLiteConnection(SetconnectionString(connectionStringD)))
                {
                    con.Open();

                    //マスタ作成
                    sql = "CREATE TABLE IF NOT EXISTS 履歴データ(id                     integer PRIMARY KEY AUTOINCREMENT, " +
                                                                "UserID                 int," +
                                                                "Mode                   varchar(1)," +
                                                                "StartDate              datetime," +
                                                                "Teiji                  varchar(1)," +
                                                                "Timer                  varchar(1)," +
                                                                "FormDisp               varchar(1)," +
                                                                "FormLR                 varchar(1)," +
                                                                "DispProgress           varchar(1)," +
                                                                "DispTimer              varchar(1)," +
                                                                "DispRemain             varchar(1)," +
                                                                "DispGraph              varchar(1)," +
                                                                "ZipSearch              varchar(1)," +
                                                                "Sound                  varchar(1)," +
                                                                "Course                 varchar(1)," +
                                                                "AnswerMaisu            int," +
                                                                "AnswerKoumoku          int," +
                                                                "CorrectMaisu           int," +
                                                                "CorrectKoumoku         int," +
                                                                "CorrectRate            real," +
                                                                "CorrectKoumokuRate     real," +
                                                                "AnswerMaisuHour        real," +
                                                                "AnswerKoumokuHour      real," +
                                                                "CorrectMaisuHour       real," +
                                                                "CorrectKoumokuHour     real," +
                                                                "CorrectRateHour        real," +
                                                                "CorrectKoumokuRateHour real," +
                                                                "WorkCnt                int," +
                                                                "CorrectCnt             int," +
                                                                "Feedback               varchar(1)," +
                                                                "ColorCD                varchar(1)," +
                                                                "CancelFlg              varchar(1)," +
                                                                "WorkTime               varchar(8)," +
                                                                "InsDate                datetime," +
                                                                "UpdDate                datetime," +
                                                                "DelFlg                 int" +
                                                                ")";

                    SQLiteCommand com = new SQLiteCommand(sql, con);
                    com.ExecuteNonQuery();

                    //Index作成
                    sql = "CREATE INDEX IF NOT EXISTS IdxUserID ON 履歴データ(UserID)";
                    com = new SQLiteCommand(sql, con);
                    com.ExecuteNonQuery();
                    sql = "CREATE INDEX IF NOT EXISTS IdxMode ON 履歴データ(Mode)";
                    com = new SQLiteCommand(sql, con);
                    com.ExecuteNonQuery();
                    sql = "CREATE INDEX IF NOT EXISTS IdxStartDate ON 履歴データ(StartDate)";
                    com = new SQLiteCommand(sql, con);
                    com.ExecuteNonQuery();

                    //履歴データを登録する
                    sql = "Insert into 履歴データ(UserID," +
                                                 "Mode," +
                                                 "StartDate," +
                                                 "Teiji," +
                                                 "Timer," +
                                                 "FormDisp," +
                                                 "FormLR," +
                                                 "DispProgress," +
                                                 "DispTimer," +
                                                 "DispRemain," +
                                                 "DispGraph," +
                                                 "ZipSearch," +
                                                 "Sound," +
                                                 "Course," +
                                                 "AnswerMaisu," +
                                                 "AnswerKoumoku," +
                                                 "CorrectMaisu," +
                                                 "CorrectKoumoku," +
                                                 "CorrectRate," +
                                                 "CorrectKoumokuRate," +
                                                 "AnswerMaisuHour," +
                                                 "AnswerKoumokuHour," +
                                                 "CorrectMaisuHour," +
                                                 "CorrectKoumokuHour," +
                                                 "CorrectRateHour," +
                                                 "CorrectKoumokuRateHour," +
                                                 "WorkCnt," +
                                                 "CorrectCnt," +
                                                 "Feedback," +
                                                 "ColorCD," +
                                                 "CancelFlg," +
                                                 "WorkTime," +
                                                 "InsDate," +
                                                 "UpdDate," +
                                                 "DelFlg) " +
                        "Values(" + ifc.Id + ","                                                            //UserID
                                  + "'" + ifc.Mode + "',"                                                   //Mode
                                  + "datetime('" + StartTime.ToString("yyyy-MM-dd HH:mm:ss") + "')" + ","     //StartDate
                                  + "'" + ifc.Teiji + "',"                                                  //Teiji                  
                                  + "'" + Timer.ToString() + "',"                                           //Timer                  
                                  + "'" + ifc.FormDisp + "',"                                               //FormDisp               
                                  + "'" + FormLR + "',"                                                     //FormLR                 
                                  + "'" + DispProgress + "',"                                               //DispProgress           
                                  + "'" + DispTimer + "',"                                                  //DispTimer              
                                  + "'" + DispRemain + "',"                                                 //DispRemain             
                                  + "'" + DispGraph + "',"                                                  //DispGraph              
                                  + "'" + ZipSearch + "',"                                                  //ZipSearch              
                                  + "''" + ","                                                              //Sound
                                  + "'" + ifc.Course + "',"                                                 //Course                 
                                  + AnswerMaisu.ToString("0.000000") + ","                                  //AnswerMaisu            
                                  + AnswerKoumoku.ToString("0.000000") + ","                                //AnswerKoumoku          
                                  + CorrectMaisu.ToString("0.000000") + ","                                 //CorrectMaisu           
                                  + CorrectKoumoku.ToString("0.000000") + ","                               //CorrectKoumoku         
                                  + CorrectRate.ToString("0.000000") + ","                                  //CorrectRate            
                                  + CorrectKoumokuRate.ToString("0.000000") + ","                           //CorrectKoumokuRate     
                                  + AnswerMaisuHour.ToString("0.000000") + ","                              //AnswerMaisuHour        
                                  + AnswerKoumokuHour.ToString("0.000000") + ","                            //AnswerKoumokuHour      
                                  + CorrectMaisuHour.ToString("0.000000") + ","                             //CorrectMaisuHour       
                                  + CorrectKoumokuHour.ToString("0.000000") + ","                           //CorrectKoumokuHour     
                                  + CorrectRateHour.ToString("0.000000") + ","                              //CorrectRateHour        
                                  + CorrectKoumokuRateHour.ToString("0.000000") + ","                       //CorrectKoumokuRateHour 
                                  + ifc.WorkCnt.ToString() + ","                                            //WorkCnt                
                                  + ifc.CorrectCnt.ToString() + ","                                         //CorrectCnt             
                                  + "'3'" + ","                                                             //Feedback               
                                  + "'1'" + ","                                                             //ColorCD                
                                  + "'" + CancelFlg + "',"                                                  //CancelFlg              
                                  + "'" + WorkTime + "',"                                                    //WorkTime               
                                  + "datetime('now', 'localtime'),"                                         //InsDate
                                  + "datetime('now', 'localtime'),"                                         //UpdDate
                                  + "0"                                                                     //DelFlg
                                  + ");";

                    com = new SQLiteCommand(sql, con);
                    com.ExecuteNonQuery();

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
        private string SetconnectionString(string con)
        {
            return "Data Source=" + con + ";Version=3;";
        }

        /// <summary>
        //              マスタＤＢパスセット
        /// </summary>
        /// <param name="fPath">データベースフルパス</param>
        /// <returns>SQLiteデータベース名フルパス</returns>
        private string SetPathStringM(string? fPath)
        {
            return fPath + @"\LetsTry04.mst";
        }

        /// <summary>
        //              データＤＢパスセット
        /// </summary>
        /// <param name="fPath">データベースフルパス</param>
        /// <returns>SQLiteデータベース名フルパス</returns>
        private string SetPathStringD(string? fPath)
        {
            return fPath + @"\LetsTry04.dat";
        }

    }

}



