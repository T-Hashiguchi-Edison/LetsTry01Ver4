using System.Runtime.InteropServices;
using System.Windows;

namespace パソコンデータ入力
{
    public partial class Frm試行条件目標設定 : Form
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
        //              試行条件目標設定
        /// </summary>
        /// <param name="prm">画面引継ぎ情報</param>
        public Frm試行条件目標設定(FormCommon.Form_IF prm)
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
        //              Form　Load
        /// </summary>
        private void Frm試行条件目標設定_Load(object sender, EventArgs e)
        {
            //初期表示
            //ディスプレイサイズ取得
            Double disp_width = SystemParameters.PrimaryScreenWidth;
            Double disp_height = SystemParameters.PrimaryScreenHeight;

            switch (ifc.Course)
            {
                case FormCommon.Course.実力テスト:
                    ////終了時間
                    RdiTime30.Checked = true;

                    ////入力画面の設定
                    ChkProgress.Enabled = false;
                    ChkTimer.Enabled = false;
                    ChkRemain.Enabled = false;
                    if ((disp_width < 1920) || (disp_height < 1080))
                    {
                        ChkImage.Enabled = false;
                        ChkInputForm.Enabled = false;
                    }
                    else
                    {
                        ChkImage.Enabled = false;
                        ChkInputForm.Enabled = true;
                    }

                    ChkProgress.Checked = false;
                    ChkTimer.Checked = false;
                    ChkRemain.Checked = false;
                    ChkImage.Checked = false;
                    ChkInputForm.Checked = false;

                    ////目標設定
                    GrpGoal.Enabled = false;

                    NudWorkCnt.Value = 0;
                    NudCorrectCnt.Value = 0;

                    ////フィードバックの選択
                    GrpFeedback.Enabled = false;

                    ChkGraph.Checked = false;
                    ChkErrorCheck.Checked = false;
                    ChkFinalFeedback.Checked = false;

                    break;

                case FormCommon.Course.基礎トレーニング:
                    ////終了時間
                    RdiTime30.Checked = true;

                    ////入力画面の設定
                    ChkProgress.Enabled = true;
                    ChkTimer.Enabled = false;
                    ChkRemain.Enabled = false;
                    if ((disp_width < 1920) || (disp_height < 1080))
                    {
                        ChkImage.Enabled = false;
                        ChkInputForm.Enabled = false;
                    }
                    else
                    {
                        ChkImage.Enabled = true;
                        ChkInputForm.Enabled = true;
                    }

                    ChkProgress.Checked = false;
                    ChkTimer.Checked = false;
                    ChkRemain.Checked = false;
                    ChkImage.Checked = false;
                    ChkInputForm.Checked = false;

                    ////目標設定
                    GrpGoal.Enabled = false;

                    NudWorkCnt.Value = 0;
                    NudCorrectCnt.Value = 0;

                    ////フィードバックの選択
                    GrpFeedback.Enabled = true;

                    ChkGraph.Enabled = false;
                    ChkErrorCheck.Enabled = true;
                    ChkFinalFeedback.Enabled = false;

                    ChkGraph.Checked = false;
                    ChkErrorCheck.Checked = true;
                    ChkFinalFeedback.Checked = false;

                    break;

                case FormCommon.Course.レベルアップトレーニング:
                    ////終了時間
                    RdiTime30.Checked = true;

                    ////入力画面の設定
                    ChkProgress.Enabled = true;
                    ChkTimer.Enabled = true;
                    ChkRemain.Enabled = true;
                    if ((disp_width < 1920) || (disp_height < 1080))
                    {
                        ChkImage.Enabled = false;
                        ChkInputForm.Enabled = false;
                    }
                    else
                    {
                        ChkImage.Enabled = true;
                        ChkInputForm.Enabled = true;
                    }

                    ChkProgress.Checked = false;
                    ChkTimer.Checked = false;
                    ChkRemain.Checked = false;
                    ChkImage.Checked = false;
                    ChkInputForm.Checked = false;

                    ////目標設定
                    GrpGoal.Enabled = true;

                    NudWorkCnt.Enabled = true;
                    NudCorrectCnt.Enabled = true;

                    NudWorkCnt.Value = 0;
                    NudCorrectCnt.Value = 0;

                    ////フィードバックの選択
                    GrpFeedback.Enabled = true;

                    ChkGraph.Enabled = false;                       //グラフ機能は未対応とする
                                                                    //ChkGraph.Enabled = true;
                    ChkErrorCheck.Enabled = false;
                    ChkFinalFeedback.Enabled = true;

                    ChkGraph.Checked = false;                       //グラフ機能は未対応とする
                                                                    //ChkGraph.Checked = true;
                    ChkErrorCheck.Checked = false;
                    ChkFinalFeedback.Checked = true;

                    break;
                default:
                    System.Windows.Forms.MessageBox.Show("パラメータ不正(Course)", "エラー");
                    //パラメータ不正
                    this.Dispose();
                    this.Close();
                    break;
            }
        }

        /// <summary>
        //              次へ　Click
        /// </summary>
        private void BtnNext_Click(object sender, EventArgs e)
        {
            //入力チェック

            if (!InputCheck())
            {
                return;
            }

            BtnCancel.Enabled = false;

            //非表示する
            this.Visible = false;

            ////スタート確認を表示する。
            //終了時間
            if (RdiTime15.Checked)
            {
                ifc.Timer = 15;
            }
            else if (RdiTime30.Checked)
            {
                ifc.Timer = 30;
            }
            else if (RdiTime45.Checked)
            {
                ifc.Timer = 45;
            }
            else if (RdiTime60.Checked)
            {
                ifc.Timer = 60;
            }
            //進捗状況画面表示
            if (ChkProgress.Checked)
            {
                ifc.DispProgress = FormCommon.Displey.表示する;
            }
            else
            {
                ifc.DispProgress = FormCommon.Displey.表示しない;
            }
            //タイマー表示
            if (ChkTimer.Checked)
            {
                ifc.DispTimer = FormCommon.Displey.表示する;
            }
            else
            {
                ifc.DispTimer = FormCommon.Displey.表示しない;
            }
            //残り時間表示
            if (ChkRemain.Checked)
            {
                ifc.DispRemain = FormCommon.Displey.表示する;
            }
            else
            {
                ifc.DispRemain = FormCommon.Displey.表示しない;
            }
            //印刷物の拡大
            if (ChkImage.Checked)
            {
                ifc.InputImage = FormCommon.Expansion.拡大;
            }
            else
            {
                ifc.InputImage = FormCommon.Expansion.通常;
            }
            //入力画面の拡大
            if (ChkInputForm.Checked)
            {
                ifc.InputForm = FormCommon.Expansion.拡大;
            }
            else
            {
                ifc.InputForm = FormCommon.Expansion.通常;
            }
            //作業枚数
            ifc.WorkCnt = Decimal.ToInt32(NudWorkCnt.Value);
            //正しい枚数
            ifc.CorrectCnt = Decimal.ToInt32(NudCorrectCnt.Value);
            //グラフ表示
            if (ChkGraph.Checked)
            {
                ifc.DispGraph = FormCommon.Displey.表示する;
            }
            else
            {
                ifc.DispGraph = FormCommon.Displey.表示しない;
            }
            //エラーチェック結果のフィードバック
            if (ChkErrorCheck.Checked)
            {
                ifc.DispErrChk = FormCommon.Displey.表示する;
            }
            else
            {
                ifc.DispErrChk = FormCommon.Displey.表示しない;
            }
            //エラーチェック結果のフィードバック
            if (ChkFinalFeedback.Checked)
            {
                ifc.DispFinal = FormCommon.Displey.表示する;
            }
            else
            {
                ifc.DispFinal = FormCommon.Displey.表示しない;
            }

            Frmスタート確認 frm = new Frmスタート確認(ifc);
            frm.ShowDialog();

            if (共通プロパティ.ReturnMenu)
            {
                this.Dispose();
                this.Close();
            }
            else
            {
                BtnCancel.Enabled = true;

                //表示する
                this.Visible = true;
            }

        }

        /// <summary>
        //              キャンセル　Click
        /// </summary>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        /// <summary>
        //              入力チェック
        /// </summary>
        private Boolean InputCheck()
        {
            //レベルアップトレーニングの場合、作業枚数と正しい枚数の値が正しいかチェックする
            if (ifc.Course == FormCommon.Course.レベルアップトレーニング)
            {
                //作業枚数
                if (NudWorkCnt.Value <= 0)
                {
                    System.Windows.Forms.MessageBox.Show("作業枚数の入力に誤りがあります。" + Environment.NewLine + "1～500までの範囲で入力してください。", "エラー");
                    return false;
                }
                if (NudWorkCnt.Value > 500)
                {
                    System.Windows.Forms.MessageBox.Show("作業枚数の入力に誤りがあります。" + Environment.NewLine + "1～500までの範囲で入力してください。", "エラー");
                    return false;
                }
                //正しい枚数
                if (NudCorrectCnt.Value <= 0)
                {
                    System.Windows.Forms.MessageBox.Show("正しい枚数の入力に誤りがあります。" + Environment.NewLine + "1～500までの範囲で入力してください。", "エラー");
                    return false;
                }
                if (NudCorrectCnt.Value > 500)
                {
                    System.Windows.Forms.MessageBox.Show("正しい枚数の入力に誤りがあります。" + Environment.NewLine + "1～500までの範囲で入力してください。", "エラー");
                    return false;
                }
                //作業枚数、正しい枚数
                if (NudCorrectCnt.Value > NudWorkCnt.Value)
                {
                    System.Windows.Forms.MessageBox.Show("目標枚数の入力に誤りがあります。" + Environment.NewLine + "正しい枚数は作業枚数以下の枚数をで入力してください。", "エラー");
                    return false;
                }
            }


            return true;
        }

    }
}
