using System.Data.SQLite;
using System.Runtime.InteropServices;
using System.Text;

namespace パソコンデータ入力
{
    public partial class Frm顧客伝票ミスチェック : Form
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
        private string cardDataTbl = "";                        //顧客伝票DB
        private string ErrorDataTbl = "";                       //顧客伝票エラーDB
        private TimeSpan TotalWorkTime = TimeSpan.Zero;         //作業時間合計

        private 構造体.顧客伝票カード項目 CurCardData;
        private 構造体.顧客伝票カード項目 CurBeforeData;
        private 構造体.顧客伝票カード入力値 CurInputData;
        private 構造体.顧客伝票カード項目 CurCorrectData;
        private 構造体.共通エラー文字種別 CurMojiData;
        private List<構造体.顧客伝票カード項目> ListCardData = new List<構造体.顧客伝票カード項目>();
        private List<構造体.顧客伝票カード項目> ListBeforeData = new List<構造体.顧客伝票カード項目>();
        private List<構造体.顧客伝票カード入力値> ListInputData = new List<構造体.顧客伝票カード入力値>();
        private List<構造体.顧客伝票カード項目> ListCorrectData = new List<構造体.顧客伝票カード項目>();
        private List<構造体.共通エラー文字種別> ListMojiData = new List<構造体.共通エラー文字種別>();

        private Random rndCard = new Random();                  //カード番号シャッフル用

        private Boolean EndTimerSW = false;                     //終了タイマースイッチ

        private Boolean LastInputSW = false;                    //最終データ入力スイッチ

        private RichTextBox RtxInput = new RichTextBox();
        private int RtxIdx = 0;

        /// <summary>
        //              顧客伝票ミスチェック
        /// </summary>
        /// <param name="prm">画面引継ぎ情報</param>
        public Frm顧客伝票ミスチェック(FormCommon.Form_IF prm)
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
                cardDataTbl = "MstCustomerSlipBasic";
                ErrorDataTbl = "MstCustomerSlipErrorBasic";
            }
            else
            {
                cardDataTbl = "MstCustomerSlip";
                ErrorDataTbl = "MstCustomerSlipError";
            }
            //画面設定
            if ((ifc.InputImage == FormCommon.Expansion.拡大) && (ifc.InputForm == FormCommon.Expansion.拡大))
            {
                //フォームのサイズ
                if (ifc.FormDisp == FormCommon.FormDisp.画面)
                {
                    this.Size = new Size(1696, 872);
                    PnlQuestionCard.Visible = true;
                }
                else
                {
                    this.Size = new Size(856, 872);
                    PnlQuestionCard.Visible = false;
                }

                if (ifc.FormLR == FormCommon.DispLR.左)
                {
                    //顧客伝票
                    PnlQuestionCard.Location = new Point(0, 80);
                    SetPnlCustomerSlipLarge();

                    //入力フォーム
                    if (ifc.FormDisp == FormCommon.FormDisp.画面)
                    {
                        PnlInput.Location = new Point(824, 0);
                    }
                    else
                    {
                        PnlInput.Location = new Point(0, 0);
                    }
                    SetPnlInputLarge();
                }
                else
                {
                    //顧客伝票
                    PnlQuestionCard.Location = new Point(856, 80);
                    SetPnlCustomerSlipLarge();

                    //入力フォーム
                    PnlInput.Location = new Point(0, 0);
                    SetPnlInputLarge();
                }
            }
            else if ((ifc.InputImage == FormCommon.Expansion.拡大) && (ifc.InputForm == FormCommon.Expansion.通常))
            {
                //フォームのサイズ
                if (ifc.FormDisp == FormCommon.FormDisp.画面)
                {
                    this.Size = new Size(1384, 656);
                    PnlQuestionCard.Visible = true;
                }
                else
                {
                    this.Size = new Size(560, 656);
                    PnlQuestionCard.Visible = false;
                }

                if (ifc.FormLR == FormCommon.DispLR.左)
                {
                    //顧客伝票
                    PnlQuestionCard.Location = new Point(0, 80);
                    SetPnlCustomerSlipLarge();

                    //入力フォーム
                    if (ifc.FormDisp == FormCommon.FormDisp.画面)
                    {
                        PnlInput.Location = new Point(824, 0);
                    }
                    else
                    {
                        PnlInput.Location = new Point(0, 0);
                    }
                    SetPnlInputOrigin();
                }
                else
                {
                    //顧客伝票
                    PnlQuestionCard.Location = new Point(544, 80);
                    SetPnlCustomerSlipLarge();

                    //入力フォーム
                    if (ifc.FormDisp == FormCommon.FormDisp.画面)
                    {
                        PnlInput.Location = new Point(0, 0);
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
                    this.Size = new Size(1480, 872);
                    PnlQuestionCard.Visible = true;
                }
                else
                {
                    this.Size = new Size(872, 872);
                    PnlQuestionCard.Visible = false;
                }

                if (ifc.FormLR == FormCommon.DispLR.左)
                {
                    //顧客伝票
                    PnlQuestionCard.Location = new Point(0, 80);
                    SetPnlCustomerSlipOrigin();

                    //入力フォーム
                    if (ifc.FormDisp == FormCommon.FormDisp.画面)
                    {
                        PnlInput.Location = new Point(608, 8);
                    }
                    else
                    {
                        PnlInput.Location = new Point(0, 0);
                    }
                    SetPnlInputLarge();
                }
                else
                {
                    //顧客伝票
                    PnlQuestionCard.Location = new Point(856, 80);
                    SetPnlCustomerSlipOrigin();

                    //入力フォーム
                    PnlInput.Location = new Point(0, 0);
                    SetPnlInputLarge();
                }
            }
            else
            {
                //フォームのサイズ
                if (ifc.FormDisp == FormCommon.FormDisp.画面)
                {
                    this.Size = new Size(1168, 652);
                    PnlQuestionCard.Visible = true;
                }
                else
                {
                    this.Size = new Size(560, 656);
                    PnlQuestionCard.Visible = false;
                }

                if (ifc.FormLR == FormCommon.DispLR.左)
                {
                    //顧客伝票
                    PnlQuestionCard.Location = new Point(0, 80);
                    SetPnlCustomerSlipOrigin();

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
                    //顧客伝票
                    PnlQuestionCard.Location = new Point(544, 80);
                    SetPnlCustomerSlipOrigin();

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
            //［F1］が押されたらキャッチ(選択)
            if (keyData == Keys.F1)
            {
                BtnSelect.PerformClick();
            }
            //［F2］が押されたらキャッチ(選択)
            if (keyData == Keys.F2)
            {
                BtnSelCan.PerformClick();
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
        private void Frm顧客伝票ミスチェック_Load(object sender, EventArgs e)
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
                    cardNO = ifc.Start_No3 - 1;
                }
            }

            //各配列のクリア
            ListCardData.Clear();
            ListBeforeData.Clear();
            ListInputData.Clear();
            ListCorrectData.Clear();
            ListMojiData.Clear();

            //入力フォームのクリア(カード№は更新しない)
            ClearInputForm(false);
            //顧客伝票データ表示
            DispCard();
            //顧客伝票カードエラーデータ表示
            DispErrCard();

        }

        /// <summary>
        //              顧客コード　Enterk
        /// </summary>
        private void RtxCustCd_Enter(object sender, EventArgs e)
        {
            RtxInput = RtxCustCd;
            RtxIdx = 1;
        }

        /// <summary>
        //              商品コード　Enterk
        /// </summary>
        private void RtxItemCd_Enter(object sender, EventArgs e)
        {
            RtxInput = RtxItemCd;
            RtxIdx = 2;
        }

        /// <summary>
        //              電話番号　Enterk
        /// </summary>
        private void RtxTelNo_Enter(object sender, EventArgs e)
        {
            RtxInput = RtxTelNo;
            RtxIdx = 3;
        }

        /// <summary>
        //              メールアドレス　Enterk
        /// </summary>
        private void RtxMailAddress_Enter(object sender, EventArgs e)
        {
            RtxInput = RtxMailAddress;
            RtxIdx = 4;
        }

        /// <summary>
        //              指摘　Click
        /// </summary>
        private void BtnSelect_Click(object sender, EventArgs e)
        {
            //色を赤にする
            RtxInput.SelectionColor = Color.Red;

            int pos = RtxInput.SelectionStart;
            int len = RtxInput.SelectionLength;

            switch (RtxIdx)
            {
                case 1:
                    CurInputData.CustCd = CurInputData.CustCd.Remove(pos, len).Insert(pos, "".PadRight(len, 'C'));
                    break;
                case 2:
                    CurInputData.ItemCd = CurInputData.ItemCd.Remove(pos, len).Insert(pos, "".PadRight(len, 'C'));
                    break;
                case 3:
                    CurInputData.TelNo = CurInputData.TelNo.Remove(pos, len).Insert(pos, "".PadRight(len, 'C'));
                    break;
                case 4:
                    CurInputData.MailAddress = CurInputData.MailAddress.Remove(pos, len).Insert(pos, "".PadRight(len, 'C'));
                    break;
            }

        }

        /// <summary>
        //              指摘解除　Click
        /// </summary>
        private void BtnSelCan_Click(object sender, EventArgs e)
        {
            //色を黒にする
            RtxInput.SelectionColor = Color.Black;

            int pos = RtxInput.SelectionStart;
            int len = RtxInput.SelectionLength;

            switch (RtxIdx)
            {
                case 1:
                    CurInputData.CustCd = CurInputData.CustCd.Remove(pos, len).Insert(pos, "".PadRight(len, 'N'));
                    break;
                case 2:
                    CurInputData.ItemCd = CurInputData.ItemCd.Remove(pos, len).Insert(pos, "".PadRight(len, 'N'));
                    break;
                case 3:
                    CurInputData.TelNo = CurInputData.TelNo.Remove(pos, len).Insert(pos, "".PadRight(len, 'N'));
                    break;
                case 4:
                    CurInputData.MailAddress = CurInputData.MailAddress.Remove(pos, len).Insert(pos, "".PadRight(len, 'N'));
                    break;
            }

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
            ListBeforeData.Add(CurBeforeData);
            ListInputData.Add(CurInputData);
            ListCorrectData.Add(CurCorrectData);
            ListMojiData.Add(CurMojiData);

            //入力フォームのクリア(カード№の更新)
            ClearInputForm(true);
            //顧客伝票カードデータ表示
            DispCard();
            //顧客伝票カードエラーデータ表示
            DispErrCard();

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

                    ListBeforeData.Add(CurBeforeData);
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
                                                                          new List<構造体.アンケートカード項目>(),
                                                                          new List<構造体.アンケートカード入力値>(),
                                                                          new List<構造体.アンケートカード項目>(),
                                                                          ListCardData,
                                                                          ListBeforeData,
                                                                          ListInputData,
                                                                          ListCorrectData
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
                                                              new List<構造体.アンケートカード項目>(),
                                                              new List<構造体.アンケートカード入力値>(),
                                                              new List<構造体.アンケートカード項目>(),
                                                              ListCardData,
                                                              ListBeforeData,
                                                              ListInputData,
                                                              ListCorrectData
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
        //              顧客伝票　通常
        /// </summary>
        private void SetPnlCustomerSlipOrigin()
        {
            //顧客伝票
            PnlQuestionCard.Size = new Size(608, 424);
            {
                //カードNo
                LblNo_Q.Location = new Point(416, 40);
                LblNo_Q.Size = new Size(64, 32);
                LblNo_Q.Font = new Font("ＭＳ Ｐゴシック", 15.75f);

                LblCardNo_C.Location = new Point(480, 40);
                LblCardNo_C.Size = new Size(56, 32);
                LblCardNo_C.Font = new Font("ＭＳ Ｐゴシック", 15.75f);

                //タイトル
                LblTitle.Location = new Point(232, 40);
                LblTitle.Size = new Size(144, 32);
                LblTitle.Font = new Font("ＭＳ Ｐゴシック", 20.25f);

                LineTitle.Location = new Point(230, 72);
                LineTitle.Size = new Size(144, 2);

                //顧客コード
                LblCustCd_Q.Location = new Point(16, 136);
                LblCustCd_Q.Size = new Size(144, 32);
                LblCustCd_Q.Font = new Font("ＭＳ Ｐゴシック", 15.75f, FontStyle.Bold);

                LblCustCd_C.Location = new Point(160, 136);
                LblCustCd_C.Size = new Size(448, 32);
                LblCustCd_C.Font = new Font("ＭＳ Ｐゴシック", 20.25f);

                LineCustCd.Location = new Point(160, 168);
                LineCustCd.Size = new Size(416, 1);

                //商品コード
                LblItemCd_Q.Location = new Point(16, 192);
                LblItemCd_Q.Size = new Size(144, 32);
                LblItemCd_Q.Font = new Font("ＭＳ Ｐゴシック", 15.75f, FontStyle.Bold);

                LblItemCd_C.Location = new Point(160, 192);
                LblItemCd_C.Size = new Size(448, 32);
                LblItemCd_C.Font = new Font("ＭＳ Ｐゴシック", 20.25f);

                LineItemCd.Location = new Point(160, 224);
                LineItemCd.Size = new Size(416, 1);

                //電話番号
                LblTelNo_Q.Location = new Point(16, 248);
                LblTelNo_Q.Size = new Size(144, 32);
                LblTelNo_Q.Font = new Font("ＭＳ Ｐゴシック", 15.75f, FontStyle.Bold);

                LblTelNo_C.Location = new Point(160, 248);
                LblTelNo_C.Size = new Size(360, 32);
                LblTelNo_C.Font = new Font("ＭＳ Ｐゴシック", 20.25f);

                LineTelNo.Location = new Point(160, 280);
                LineTelNo.Size = new Size(416, 1);

                //メールアドレス
                LblMailAddress_Q.Location = new Point(16, 304);
                LblMailAddress_Q.Size = new Size(144, 32);
                LblMailAddress_Q.Font = new Font("ＭＳ Ｐゴシック", 15.75f, FontStyle.Bold);

                LblMailAddress_C.Location = new Point(160, 304);
                LblMailAddress_C.Size = new Size(504, 32);
                LblMailAddress_C.Font = new Font("ＭＳ Ｐゴシック", 20.25f);

                LineMailAddress.Location = new Point(160, 336);
                LineMailAddress.Size = new Size(416, 1);

            }
        }

        /// <summary>
        //              顧客伝票　拡大
        /// </summary>
        private void SetPnlCustomerSlipLarge()
        {
            //顧客伝票
            PnlQuestionCard.Size = new Size(824, 480);
            {
                //カードNo
                LblNo_Q.Location = new Point(608, 24);
                LblNo_Q.Size = new Size(64, 48);
                LblNo_Q.Font = new Font("ＭＳ Ｐゴシック", 21.75f);

                LblCardNo_C.Location = new Point(672, 24);
                LblCardNo_C.Size = new Size(88, 48);
                LblCardNo_C.Font = new Font("ＭＳ Ｐゴシック", 21.75f);

                //タイトル
                LblTitle.Location = new Point(324, 16);
                LblTitle.Size = new Size(176, 56);
                LblTitle.Font = new Font("ＭＳ Ｐゴシック", 27.75f);

                LineTitle.Location = new Point(324, 72);
                LineTitle.Size = new Size(178, 2);

                //顧客コード
                LblCustCd_Q.Location = new Point(16, 144);
                LblCustCd_Q.Size = new Size(200, 40);
                LblCustCd_Q.Font = new Font("ＭＳ Ｐゴシック", 20.25f, FontStyle.Bold);

                LblCustCd_C.Location = new Point(216, 136);
                LblCustCd_C.Size = new Size(592, 48);
                LblCustCd_C.Font = new Font("ＭＳ Ｐゴシック", 27.75f);

                LineCustCd.Location = new Point(216, 184);
                LineCustCd.Size = new Size(592, 1);

                //商品コード
                LblItemCd_Q.Location = new Point(16, 224);
                LblItemCd_Q.Size = new Size(200, 40);
                LblItemCd_Q.Font = new Font("ＭＳ Ｐゴシック", 20.25f, FontStyle.Bold);

                LblItemCd_C.Location = new Point(216, 216);
                LblItemCd_C.Size = new Size(592, 48);
                LblItemCd_C.Font = new Font("ＭＳ Ｐゴシック", 27.75f);

                LineItemCd.Location = new Point(216, 264);
                LineItemCd.Size = new Size(592, 1);

                //電話番号
                LblTelNo_Q.Location = new Point(16, 304);
                LblTelNo_Q.Size = new Size(200, 40);
                LblTelNo_Q.Font = new Font("ＭＳ Ｐゴシック", 20.25f, FontStyle.Bold);

                LblTelNo_C.Location = new Point(216, 296);
                LblTelNo_C.Size = new Size(592, 48);
                LblTelNo_C.Font = new Font("ＭＳ Ｐゴシック", 27.75f);

                LineTelNo.Location = new Point(216, 344);
                LineTelNo.Size = new Size(592, 1);

                //メールアドレス
                LblMailAddress_Q.Location = new Point(16, 384);
                LblMailAddress_Q.Size = new Size(200, 40);
                LblMailAddress_Q.Font = new Font("ＭＳ Ｐゴシック", 20.25f, FontStyle.Bold);

                LblMailAddress_C.Location = new Point(216, 376);
                LblMailAddress_C.Size = new Size(592, 48);
                LblMailAddress_C.Font = new Font("ＭＳ Ｐゴシック", 26.25f);

                LineMailAddress.Location = new Point(216, 424);
                LineMailAddress.Size = new Size(592, 1);

            }
        }

        /// <summary>
        //              入力フォーム　通常
        /// </summary>
        private void SetPnlInputOrigin()
        {
            //入力フォーム
            PnlInput.Size = new Size(544, 616);
            {
                //進捗状況
                GrpProgress.Location = new Point(312, 8);
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
                            PbTimer.Location = new Point(312, 112);
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
                            PbTimer.Location = new Point(312, 112);
                            PbTimer.Visible = (ifc.DispRemain == FormCommon.Displey.表示する);
                        }
                        else
                        {
                            PbTimer.Location = new Point(312, 8);
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
                LblNo.Location = new Point(24, 128);
                LblNo.Size = new Size(128, 24);
                LblNo.Font = new Font("ＭＳ Ｐゴシック", 15.75f);

                TxtCardNo.Location = new Point(152, 130);
                TxtCardNo.Size = new Size(72, 35);
                TxtCardNo.Font = new Font("ＭＳ Ｐゴシック", 15.75f);

                //顧客コード
                LblCustCd.Location = new Point(0, 216);
                LblCustCd.Size = new Size(152, 24);
                LblCustCd.Font = new Font("ＭＳ Ｐゴシック", 15.75f);

                RtxCustCd.Location = new Point(152, 216);
                RtxCustCd.Size = new Size(352, 32);
                RtxCustCd.Font = new Font("ＭＳ Ｐゴシック", 15.75f);

                //商品コード
                LblItemCd.Location = new Point(0, 272);
                LblItemCd.Size = new Size(152, 24);
                LblItemCd.Font = new Font("ＭＳ Ｐゴシック", 15.75f);

                RtxItemCd.Location = new Point(152, 272);
                RtxItemCd.Size = new Size(352, 32);
                RtxItemCd.Font = new Font("ＭＳ Ｐゴシック", 15.75f);

                //電話番号
                LblTelNo.Location = new Point(0, 328);
                LblTelNo.Size = new Size(152, 24);
                LblTelNo.Font = new Font("ＭＳ Ｐゴシック", 15.75f);

                RtxTelNo.Location = new Point(152, 328);
                RtxTelNo.Size = new Size(352, 32);
                RtxTelNo.Font = new Font("ＭＳ Ｐゴシック", 15.75f);

                //メールアドレス
                LblMailAddress.Location = new Point(0, 384);
                LblMailAddress.Size = new Size(152, 24);
                LblMailAddress.Font = new Font("ＭＳ Ｐゴシック", 15.75f);

                RtxMailAddress.Location = new Point(152, 384);
                RtxMailAddress.Size = new Size(352, 32);
                RtxMailAddress.Font = new Font("ＭＳ Ｐゴシック", 15.75f);

                //指摘
                BtnSelect.Location = new Point(24, 440);
                BtnSelect.Size = new Size(240, 40);
                BtnSelect.Font = new Font("ＭＳ Ｐゴシック", 11.25f);

                //指摘解除
                BtnSelCan.Location = new Point(280, 440);
                BtnSelCan.Size = new Size(240, 40);
                BtnSelCan.Font = new Font("ＭＳ Ｐゴシック", 11.25f);

                //次へ
                BtnNext.Location = new Point(160, 504);
                BtnNext.Size = new Size(222, 40);
                BtnNext.Font = new Font("ＭＳ Ｐゴシック", 15.75f);

                //チェック
                BtnCheck.Location = new Point(24, 552);
                BtnCheck.Size = new Size(144, 40);
                BtnCheck.Font = new Font("ＭＳ Ｐゴシック", 15.75f);
                BtnCheck.Visible = (ifc.DispErrChk == FormCommon.Displey.表示する);

                //中止
                BtnCancel.Location = new Point(416, 568);
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
            PnlInput.Size = new Size(856, 832);
            {
                //進捗状況
                GrpProgress.Location = new Point(616, 8);
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
                            PbTimer.Location = new Point(616, 112);
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
                            PbTimer.Location = new Point(616, 112);
                            PbTimer.Visible = (ifc.DispRemain == FormCommon.Displey.表示する);
                        }
                        else
                        {
                            PbTimer.Location = new Point(616, 0);
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
                LblNo.Location = new Point(24, 112);
                LblNo.Size = new Size(120, 40);
                LblNo.Font = new Font("ＭＳ Ｐゴシック", 27.75f);

                TxtCardNo.Location = new Point(144, 114);
                TxtCardNo.Size = new Size(104, 37);
                TxtCardNo.Font = new Font("ＭＳ Ｐゴシック", 27.75f);

                //顧客コード
                LblCustCd.Location = new Point(0, 216);
                LblCustCd.Size = new Size(248, 40);
                LblCustCd.Font = new Font("ＭＳ Ｐゴシック", 27.75f);

                RtxCustCd.Location = new Point(248, 216);
                RtxCustCd.Size = new Size(584, 48);
                RtxCustCd.Font = new Font("ＭＳ Ｐゴシック", 27.75f);

                //商品コード
                LblItemCd.Location = new Point(0, 296);
                LblItemCd.Size = new Size(248, 40);
                LblItemCd.Font = new Font("ＭＳ Ｐゴシック", 27.75f);

                RtxItemCd.Location = new Point(248, 296);
                RtxItemCd.Size = new Size(584, 48);
                RtxItemCd.Font = new Font("ＭＳ Ｐゴシック", 27.75f);

                //電話番号
                LblTelNo.Location = new Point(0, 376);
                LblTelNo.Size = new Size(248, 40);
                LblTelNo.Font = new Font("ＭＳ Ｐゴシック", 27.75f);

                RtxTelNo.Location = new Point(248, 376);
                RtxTelNo.Size = new Size(584, 48);
                RtxTelNo.Font = new Font("ＭＳ Ｐゴシック", 27.75f);

                //メールアドレス
                LblMailAddress.Location = new Point(0, 456);
                LblMailAddress.Size = new Size(248, 40);
                LblMailAddress.Font = new Font("ＭＳ Ｐゴシック", 27.75f);

                RtxMailAddress.Location = new Point(248, 456);
                RtxMailAddress.Size = new Size(584, 48);
                RtxMailAddress.Font = new Font("ＭＳ Ｐゴシック", 27.75f);

                //指摘
                BtnSelect.Location = new Point(32, 544);
                BtnSelect.Size = new Size(384, 56);
                BtnSelect.Font = new Font("ＭＳ Ｐゴシック", 20.25f);

                //指摘解除
                BtnSelCan.Location = new Point(438, 544);
                BtnSelCan.Size = new Size(384, 56);
                BtnSelCan.Font = new Font("ＭＳ Ｐゴシック", 20.25f);

                //次へ
                BtnNext.Location = new Point(320, 664);
                BtnNext.Size = new Size(240, 56);
                BtnNext.Font = new Font("ＭＳ Ｐゴシック", 27.75f);

                //チェック
                BtnCheck.Location = new Point(24, 728);
                BtnCheck.Size = new Size(208, 56);
                BtnCheck.Font = new Font("ＭＳ Ｐゴシック", 27.75f);
                BtnCheck.Visible = (ifc.DispErrChk == FormCommon.Displey.表示する);

                //中止
                BtnCancel.Location = new Point(640, 752);
                BtnCancel.Size = new Size(176, 56);
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
            LblCustCd.ForeColor = Color.Black;
            RtxCustCd.Text = "";

            //氏名
            LblItemCd.ForeColor = Color.Black;
            RtxItemCd.Text = "";

            //電話番号
            LblTelNo.ForeColor = Color.Black;
            RtxTelNo.Text = "";

            //メールアドレス
            LblMailAddress.ForeColor = Color.Black;
            RtxMailAddress.Text = "";

            //フォーカスセット
            RtxCustCd.Focus();
        }

        /// <summary>
        //              顧客伝票カード　表示
        /// </summary>
        private void DispCard()
        {
            //顧客伝票カードデータ取得
            getCardData();

            //カードNo
            LblCardNo_C.Text = cardNO.ToString("0000");

            //顧客コード
            LblCustCd_C.Text = CurCardData.CustCd;

            //商品コード
            LblItemCd_C.Text = CurCardData.ItemCd;

            //電話番号
            LblTelNo_C.Text = CurCardData.TelNo;

            //メールアドレス
            LblMailAddress_C.Text = CurCardData.MailAddress;

        }

        /// <summary>
        //              顧客伝票カードエラーデータ　表示
        /// </summary>
        private void DispErrCard()
        {
            //顧客伝票カードエラーデータ取得
            getCardErrData();

            //カードNo
            TxtCardNo.Text = cardNO.ToString("0000");

            //顧客コード
            RtxCustCd.Text = CurBeforeData.CustCd;

            //商品コード
            RtxItemCd.Text = CurBeforeData.ItemCd;

            //電話番号
            RtxTelNo.Text = CurBeforeData.TelNo;

            //メールアドレス
            RtxMailAddress.Text = CurBeforeData.MailAddress;

            //フォーカスセット
            RtxCustCd.Focus();
            RtxCustCd.Select(0, 0);


        }

        /// <summary>
        //              顧客伝票カードデータ　取得処理
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

                    CurCardData = new 構造体.顧客伝票カード項目();
                    CurCardData.id = 0;

                    while (CurCardData.id == 0)
                    {
                        //顧客伝票カードデータを取得して、表示する
                        sql = "SELECT * From " + cardDataTbl + " WHERE id = " + cardNO.ToString() + " and jyogaiflg = 0";

                        using (SQLiteCommand command = new SQLiteCommand(sql, con))
                        {
                            using (SQLiteDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    // データの処理
                                    CurCardData.id = reader.GetInt32(0);
                                    CurCardData.CustCd = reader.GetString(1);
                                    CurCardData.ItemCd = reader.GetString(2);
                                    CurCardData.TelNo = reader.GetString(3);
                                    CurCardData.MailAddress = reader.GetString(4);
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
        //              顧客伝票カードエラーデータ　取得処理
        /// </summary>
        /// <returns>true:正常終了　false:異常終了</returns>
        private Boolean getCardErrData()
        {
            try
            {
                // SQL クエリ
                string sql = "";

                // データＤＢを開く
                using (SQLiteConnection con = new SQLiteConnection(SetconnectionString(connectionStringM)))
                {
                    con.Open();

                    CurBeforeData = new 構造体.顧客伝票カード項目();
                    CurInputData = new 構造体.顧客伝票カード入力値();
                    //CurInputData.StartTime = StartTime;
                    CurInputData.StartTime = DateTime.Now;
                    CurInputData.id = "";

                    while (CurInputData.id == "")
                    {
                        //顧客伝票カードデータを取得して、表示する
                        sql = "SELECT * From " + ErrorDataTbl + " WHERE id = " + cardNO.ToString() + " and jyogaiflg = 0";

                        using (SQLiteCommand command = new SQLiteCommand(sql, con))
                        {
                            using (SQLiteDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    // データの処理
                                    CurInputData.id = reader.GetInt32(0).ToString("0000");
                                    CurBeforeData.CustCd = reader.GetString(1);
                                    CurBeforeData.ItemCd = reader.GetString(2);
                                    CurBeforeData.TelNo = reader.GetString(3);
                                    CurBeforeData.MailAddress = reader.GetString(4);
                                    CurInputData.CustCd = "".PadRight(CurBeforeData.CustCd.Length, 'N');
                                    CurInputData.ItemCd = "".PadRight(CurBeforeData.ItemCd.Length, 'N');
                                    CurInputData.TelNo = "".PadRight(CurBeforeData.TelNo.Length, 'N');
                                    CurInputData.MailAddress = "".PadRight(CurBeforeData.MailAddress.Length, 'N');
                                }
                            }
                        }
                        if (CurInputData.id == "")
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
        //              入力フォーム　チェック
        /// </summary>
        private Boolean CheckInput(Boolean DispFlg)
        {
            Boolean Ret = true;

            CurCorrectData = new 構造体.顧客伝票カード項目();
            CurMojiData = new 構造体.共通エラー文字種別();

            //カード№
            CurCorrectData.id = cardNO;
            CurMojiData.id = cardNO;

            //顧客コード
            LblCustCd.ForeColor = Color.Black;

            for (int i = 0; i < LblCustCd_C.Text.Length; i++)
            {
                if (CurInputData.CustCd[i] == 'N')
                {
                    if (RtxCustCd.Text[i] != LblCustCd_C.Text[i])
                    {
                        CurCorrectData.CustCd = "×";

                        //文字チェック
                        CheckChar(LblCustCd_C.Text[i]);

                        if (DispFlg) LblCustCd.ForeColor = Color.Red;
                        Ret = false;
                    }
                }
                else if (CurInputData.CustCd[i] == 'C')
                {
                    if (RtxCustCd.Text[i] == LblCustCd_C.Text[i])
                    {
                        CurCorrectData.CustCd = "×";

                        //文字チェック
                        CheckChar(LblCustCd_C.Text[i]);

                        if (DispFlg) LblCustCd.ForeColor = Color.Red;
                        Ret = false;
                    }
                }
            }

            //商品コード
            LblItemCd.ForeColor = Color.Black;

            for (int i = 0; i < LblItemCd_C.Text.Length; i++)
            {
                if (CurInputData.ItemCd[i] == 'N')
                {
                    if (RtxItemCd.Text[i] != LblItemCd_C.Text[i])
                    {
                        CurCorrectData.ItemCd = "×";

                        //文字チェック
                        CheckChar(LblItemCd_C.Text[i]);

                        if (DispFlg) LblItemCd.ForeColor = Color.Red;
                        Ret = false;
                    }
                }
                else if (CurInputData.ItemCd[i] == 'C')
                {
                    if (RtxItemCd.Text[i] == LblItemCd_C.Text[i])
                    {
                        CurCorrectData.ItemCd = "×";

                        //文字チェック
                        CheckChar(LblItemCd_C.Text[i]);

                        if (DispFlg) LblItemCd.ForeColor = Color.Red;
                        Ret = false;
                    }
                }
            }

            //電話番号
            LblTelNo.ForeColor = Color.Black;

            for (int i = 0; i < LblTelNo_C.Text.Length; i++)
            {
                if (CurInputData.TelNo[i] == 'N')
                {
                    if (RtxTelNo.Text[i] != LblTelNo_C.Text[i])
                    {
                        CurCorrectData.TelNo = "×";

                        //文字チェック
                        CheckChar(LblTelNo_C.Text[i]);

                        if (DispFlg) LblTelNo.ForeColor = Color.Red;
                        Ret = false;
                    }
                }
                else if (CurInputData.TelNo[i] == 'C')
                {
                    if (RtxTelNo.Text[i] == LblTelNo_C.Text[i])
                    {
                        CurCorrectData.TelNo = "×";

                        //文字チェック
                        CheckChar(LblTelNo_C.Text[i]);

                        if (DispFlg) LblTelNo.ForeColor = Color.Red;
                        Ret = false;
                    }
                }
            }

            //メールアドレス
            LblMailAddress.ForeColor = Color.Black;

            for (int i = 0; i < LblMailAddress_C.Text.Length; i++)
            {
                if (CurInputData.MailAddress[i] == 'N')
                {
                    if (RtxMailAddress.Text[i] != LblMailAddress_C.Text[i])
                    {
                        CurCorrectData.MailAddress = "×";

                        //文字チェック
                        CheckChar(LblMailAddress_C.Text[i]);

                        if (DispFlg) LblMailAddress.ForeColor = Color.Red;
                        Ret = false;
                    }
                }
                else if (CurInputData.MailAddress[i] == 'C')
                {
                    if (RtxMailAddress.Text[i] == LblMailAddress_C.Text[i])
                    {
                        CurCorrectData.MailAddress = "×";

                        //文字チェック
                        CheckChar(LblMailAddress_C.Text[i]);

                        if (DispFlg) LblMailAddress.ForeColor = Color.Red;
                        Ret = false;
                    }
                }
                {
                }
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
                    sql = "UPDATE ユーザマスタ SET Start_No3 = " + cardNO.ToString() + ","
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
        private void CheckChar(Char CheckChar)
        {

            //カタカナ
            if (('\u30A1' <= CheckChar && CheckChar <= '\u30FA') ||
                ('\u30FC' <= CheckChar && CheckChar <= '\u30FF') ||
                ('\u31F0' <= CheckChar && CheckChar <= '\u31FF') ||
                ('\u3099' <= CheckChar && CheckChar <= '\u309C') ||
                ('\uFF66' <= CheckChar && CheckChar <= '\uFF9F'))
            {
                CurMojiData.Kana = "×";
            }
            //数字
            else if ('0' <= CheckChar && CheckChar <= '9')
            {
                CurMojiData.Suuji = "×";
            }
            //英大文字
            else if ('A' <= CheckChar && CheckChar <= 'Z')
            {
                CurMojiData.EiOumoji = "×";
            }
            //英小文字
            else if ('a' <= CheckChar && CheckChar <= 'z')
            {
                CurMojiData.EiKomoji = "×";
            }
            //記号
            else if (char.IsSymbol(CheckChar))
            {
                CurMojiData.Kigou = "×";
            }
            else if (CheckChar == '-' || CheckChar == '.' || CheckChar == ',' || CheckChar == '@')
            {
                CurMojiData.Kigou = "×";
            }
            //漢字
            else
            {
                CurMojiData.Kanji = "×";
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
            int CntCustCd = 0;
            int CntItemCd = 0;
            int CntTelNo = 0;
            int CntMailAddress = 0;
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
                          + "_入力値_ミスチェック_" + ifc.NameSi + "_" + ifc.NameMei + ".csv";

                //解析結果ファイル名
                FileResult = "解析結果\\" + ifc.Id + "\\" + StartTime.ToString("yyyyMMdd") + "_" + StartTime.ToString("HHmmss")
                           + "_解析結果_ミスチェック_" + ifc.NameSi + "_" + ifc.NameMei + ".csv";

                //入力値ファイル出力
                using (StreamWriter sw = new StreamWriter(FileInput, false, Encoding.UTF8))
                {
                    sw.WriteLine("開始時刻,終了時刻,経過時間,評価除外フラグ,NO.,顧客コード,商品コード,電話番号,メールアドレス" +
                                 ((ifc.Course == FormCommon.Course.基礎トレーニング) ? ",チェック" : ""));

                    foreach (構造体.顧客伝票カード入力値 InputData in ListInputData)
                    {
                        CntInputData++;
                        if ((CntInputData == ListInputData.Count) && (LastInputSW)) break;

                        sw.WriteLine(InputData.StartTime.ToString("HH:mm:ss") + "," +
                                     InputData.EndTime.ToString("HH:mm:ss") + "," +
                                     InputData.ElapsedTime + "," +
                                     InputData.JogaiFlg + "," +
                                     InputData.id + "," +
                                     InputData.CustCd + "," +
                                     InputData.ItemCd + "," +
                                     InputData.TelNo + "," +
                                     InputData.MailAddress +
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

                    sw.WriteLine("顧客伝票ミスチェック・解析結果");
                    sw.WriteLine("");

                    sw.WriteLine("■採点結果");
                    sw.WriteLine("作業枚数,正解枚数,エラー枚数,正解率,エラー率,開始時刻,終了時刻");

                    CntInputData = 0;
                    foreach (構造体.顧客伝票カード項目 CorrectData in ListCorrectData)
                    {
                        CntInputData++;
                        if ((CntInputData == ListInputData.Count) && (LastInputSW)) break;

                        if (CorrectData.CustCd != "" ||
                            CorrectData.ItemCd != "" ||
                            CorrectData.TelNo != "" ||
                            CorrectData.MailAddress != "")
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
                    sw.WriteLine("エラー,カードNo.,顧客コード,商品コード,電話番号,メールアドレス,経過時間");

                    Cnt = 0;
                    CntCustCd = 0;
                    CntItemCd = 0;
                    CntTelNo = 0;
                    CntMailAddress = 0;
                    CntInputData = 0;

                    foreach (構造体.顧客伝票カード項目 InputData in ListCorrectData)
                    {
                        CntInputData++;
                        if ((CntInputData == ListInputData.Count) && (LastInputSW)) break;

                        if (InputData.CustCd == "×") CntCustCd++;
                        if (InputData.ItemCd == "×") CntItemCd++;
                        if (InputData.TelNo == "×") CntTelNo++;
                        if (InputData.MailAddress == "×") CntMailAddress++;

                        if ((InputData.CustCd == "×") ||
                            (InputData.ItemCd == "×") ||
                            (InputData.TelNo == "×") ||
                            (InputData.MailAddress == "×"))
                        {
                            Cnt++;
                            sw.WriteLine(Cnt.ToString() + "," +
                                         InputData.id.ToString("0000") + "," +
                                         InputData.CustCd + "," +
                                         InputData.ItemCd + "," +
                                         InputData.TelNo + "," +
                                         InputData.MailAddress + "," +
                                         ListInputData[CntInputData - 1].ElapsedTime
                                        );
                        }
                    }
                    sw.WriteLine("合計," +
                                 "," +
                                 CntCustCd.ToString() + "枚," +
                                 CntItemCd.ToString() + "枚," +
                                 CntTelNo.ToString() + "枚," +
                                 CntMailAddress.ToString() + "枚"
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
                foreach (構造体.顧客伝票カード項目 CorrectData in ListCorrectData)
                {
                    CntInputData++;
                    if ((CntInputData == ListInputData.Count) && (LastInputSW)) break;

                    if (CorrectData.CustCd != "" ||
                        CorrectData.ItemCd != "" ||
                        CorrectData.TelNo != "" ||
                        CorrectData.MailAddress != "")
                    {
                        if (CorrectData.CustCd == "") CorrectKoumoku++;
                        if (CorrectData.ItemCd == "") CorrectKoumoku++;
                        if (CorrectData.TelNo == "") CorrectKoumoku++;
                        if (CorrectData.MailAddress == "") CorrectKoumoku++;
                    }
                    else
                    {
                        CorrectMaisu++;
                        CorrectKoumoku = CorrectKoumoku + 4;
                    }
                }
                AnswerKoumoku = AnswerMaisu * 4;

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



