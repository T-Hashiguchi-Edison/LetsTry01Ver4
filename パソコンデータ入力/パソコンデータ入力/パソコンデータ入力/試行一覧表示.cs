using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using static パソコンデータ入力.構造体;

namespace パソコンデータ入力
{
    public partial class Frm試行一覧表示 : Form
    {
        //引継ぎ情報
        private DateTime StartTime = DateTime.Now;
        private List<構造体.アンケートカード項目> ListCardDataQ = new List<アンケートカード項目>();
        private List<構造体.アンケートカード入力値> ListInputDataQ = new List<アンケートカード入力値>();
        private List<構造体.アンケートカード項目> ListCorrectDataQ = new List<アンケートカード項目>();
        private List<構造体.顧客伝票カード項目> ListCardDataC = new List<構造体.顧客伝票カード項目>();
        private List<構造体.顧客伝票カード項目> ListBeforeDataC = new List<構造体.顧客伝票カード項目>();
        private List<構造体.顧客伝票カード入力値> ListInputDataC = new List<構造体.顧客伝票カード入力値>();
        private List<構造体.顧客伝票カード項目> ListCorrectDataC = new List<構造体.顧客伝票カード項目>();

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
        //              試行一覧表示
        /// </summary>
        /// <param name="prm">画面引継ぎ情報</param>
        /// <param name="prmStartTime">開始時間</param>
        /// <param name="prmListCardDataQ">アンケートカード情報</param>
        /// <param name="prmListInputDataQ">アンケートカード入力情報</param>
        /// <param name="prmListCorrectDataQ">アンケートカード正誤情報</param>
        /// <param name="prmListCardDataC">顧客伝票情報</param>
        /// <param name="prmListBeforeDataC">顧客伝票入力前情報</param>
        /// <param name="prmListInputDataC">顧客伝票入力情報</param>
        /// <param name="prmListCorrectDataC">顧客伝票正誤情報</param>
        public Frm試行一覧表示(FormCommon.Form_IF prm,
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

            //データグリッドビュー行挿入/削除　禁止
            DgvModeQ.AllowUserToAddRows = false;
            DgvModeQ.AllowUserToDeleteRows = false;
            DgvModeC.AllowUserToAddRows = false;
            DgvModeC.AllowUserToDeleteRows = false;

            //データグリッドビュー行の高さの変更　禁止
            DgvModeQ.AllowUserToResizeRows = false;
            DgvModeC.AllowUserToResizeRows = false;

            //データグリッドビュー罫線をなくす
            DgvModeQ.CellBorderStyle = DataGridViewCellBorderStyle.None;
            DgvModeC.CellBorderStyle = DataGridViewCellBorderStyle.None;

            //データグリッドビュー並べ替え　禁止
            foreach (DataGridViewColumn c in DgvModeQ.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;
            foreach (DataGridViewColumn c in DgvModeC.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

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
        //              ショートカットキー判定　Key Down
        /// </summary>
        /// <param name="keyData">キー情報</param>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            //［Alt］+［K］が押されたらキャッチ
            if (keyData == (Keys.K | Keys.Alt))
            {
                BtnNext.PerformClick();
            }
            //［Alt］+［N］が押されたらキャッチ
            if (keyData == (Keys.N | Keys.Alt))
            {
                BtnOK.PerformClick();
            }
            //［Alt］+［S］が押されたらキャッチ
            if (keyData == (Keys.S | Keys.Alt))
            {
                BtnSelect.PerformClick();
            }
            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        //              Form　Load
        /// </summary>
        private void Frm試行一覧表示_Load(object sender, EventArgs e)
        {
            int RowCnt = 0;

            //初期表示
            TxtUserName.Text = ifc.NameSi + "　" + ifc.NameMei;

            switch (ifc.Mode)
            {
                case FormCommon.Mode.アンケート入力:
                    if (ListCorrectDataQ.Count == 0)
                    {
                        NudID.Maximum = 1;
                        BtnSelect.Enabled = false;
                        BtnNext.Enabled = false;
                    }
                    else
                    {
                        NudID.Maximum = ListCorrectDataQ.Count;
                        BtnSelect.Enabled = true;
                        BtnNext.Enabled = true;

                    }
                    NudID.Value = 1;
                    RowCnt = 0;

                    TxtMode.Text = "アンケート入力";
                    foreach (構造体.アンケートカード項目 CorrectDataQ in ListCorrectDataQ)
                    {
                        RowCnt++;
                        DgvModeQ.Rows.Add(RowCnt,
                                          CorrectDataQ.id.ToString("0000"),
                                          CorrectDataQ.NameKana,
                                          CorrectDataQ.NameKanji,
                                          CorrectDataQ.ZipCode,
                                          CorrectDataQ.Address,
                                          CorrectDataQ.TelNo,
                                          CorrectDataQ.MailAddress,
                                          CorrectDataQ.Q1Answer,
                                          CorrectDataQ.Q2Answer,
                                          CorrectDataQ.Q3Answer,
                                          ListInputDataQ[RowCnt - 1].ElapsedTime,
                                          ListInputDataQ[RowCnt - 1].CheckCnt
                                          );
                    }
                    if (ifc.Course != FormCommon.Course.基礎トレーニング)
                    {
                        DgvModeQ.Columns[12].Visible = false;
                    }

                    DgvModeQ.Visible = true;
                    DgvModeC.Visible = false;
                    break;

                case FormCommon.Mode.顧客伝票修正:
                case FormCommon.Mode.顧客伝票チェック:
                    if (ListCorrectDataC.Count == 0)
                    {
                        NudID.Maximum = 1;
                        BtnSelect.Enabled = false;
                        BtnNext.Enabled = false;
                    }
                    else
                    {
                        NudID.Maximum = ListCorrectDataC.Count;
                        BtnSelect.Enabled = true;
                        BtnNext.Enabled = true;

                    }
                    NudID.Value = 1;
                    RowCnt = 0;

                    TxtMode.Text = "顧客伝票修正";
                    foreach (構造体.顧客伝票カード項目 CorrectDataC in ListCorrectDataC)
                    {
                        RowCnt++;
                        DgvModeC.Rows.Add(RowCnt,
                                          CorrectDataC.id.ToString("0000"),
                                          CorrectDataC.CustCd,
                                          CorrectDataC.ItemCd,
                                          CorrectDataC.TelNo,
                                          CorrectDataC.MailAddress,
                                          ListInputDataC[RowCnt - 1].ElapsedTime,
                                          ListInputDataC[RowCnt - 1].CheckCnt
                                          );
                    }
                    if (ifc.Course != FormCommon.Course.基礎トレーニング)
                    {
                        DgvModeC.Columns[7].Visible = false;
                    }

                    DgvModeQ.Visible = false;
                    DgvModeC.Visible = true;
                    break;

                default:
                    //パラメータ不正
                    MessageBox.Show("パラメータ不正(Mode)", "エラー");
                    共通プロパティ.ReturnMenu = true;
                    this.Dispose();
                    this.Close();
                    break;
            }
        }

        /// <summary>
        //              選択　Click
        /// </summary>
        private void BtnSelect_Click(object sender, EventArgs e)
        {
            if (DgvModeQ.Visible)
            {
                DgvModeQ.FirstDisplayedScrollingRowIndex = (int)NudID.Value - 1;
                DgvModeQ.Rows[(int)NudID.Value - 1].Selected = true;
            }
            if (DgvModeC.Visible)
            {
                DgvModeC.FirstDisplayedScrollingRowIndex = (int)NudID.Value - 1;
                DgvModeC.Rows[(int)NudID.Value - 1].Selected = true;
            }
        }

        /// <summary>
        //              解答・入力値表示　Click
        /// </summary>
        private void BtnNext_Click(object sender, EventArgs e)
        {
            switch (ifc.Mode)
            {
                case FormCommon.Mode.アンケート入力:
                    //非表示する
                    this.Visible = false;

                    //解答・入力値表示を表示する。
                    int idx1 = DgvModeQ.CurrentRow.Index;

                    Frm解答入力値表示アンケートカード入力 frm1 = new Frm解答入力値表示アンケートカード入力(ListCardDataQ[idx1],
                                                                                                           ListInputDataQ[idx1]
                                                                                                          );
                    frm1.ShowDialog();

                    //再表示する
                    this.Visible = true;
                    break;

                case FormCommon.Mode.顧客伝票修正:
                    //非表示する
                    this.Visible = false;

                    //解答・入力値表示を表示する。
                    int idx2 = DgvModeC.CurrentRow.Index;

                    Frm解答入力値表示顧客伝票修正 frm2 = new Frm解答入力値表示顧客伝票修正(ListCardDataC[idx2],
                                                                                           ListBeforeDataC[idx2],
                                                                                           ListInputDataC[idx2]
                                                                                          );
                    frm2.ShowDialog();

                    //再表示する
                    this.Visible = true;
                    break;

                case FormCommon.Mode.顧客伝票チェック:
                    //非表示する
                    this.Visible = false;

                    //解答・入力値表示を表示する。
                    int idx3 = DgvModeC.CurrentRow.Index;

                    Frm解答入力値表示顧客伝票ミスチェック frm3 = new Frm解答入力値表示顧客伝票ミスチェック(ListCardDataC[idx3],
                                                                                                           ListBeforeDataC[idx3],
                                                                                                           ListInputDataC[idx3]
                                                                                                          );
                    frm3.ShowDialog();

                    //再表示する
                    this.Visible = true;
                    break;

                default:
                    //パラメータ不正
                    MessageBox.Show("パラメータ不正(Mode)", "エラー");
                    共通プロパティ.ReturnMenu = true;
                    this.Dispose();
                    this.Close();
                    break;
            }

        }

        /// <summary>
        //              メニューへ戻る　Click
        /// </summary>
        private void BtnOK_Click(object sender, EventArgs e)
        {
            //非表示する
            this.Visible = false;

            this.Dispose();
            this.Close();
        }

        /// <summary>
        //              一覧　Click
        /// </summary>
        private void DgvMode_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                //ヘッダークリックは無視する
            }
            else
            {
                switch (ifc.Mode)
                {
                    case FormCommon.Mode.アンケート入力:
                        DgvModeQ.CurrentRow.Cells[0].Selected = true;
                        break;

                    case FormCommon.Mode.顧客伝票修正:
                    case FormCommon.Mode.顧客伝票チェック:
                        DgvModeC.CurrentRow.Cells[0].Selected = true;
                        break;

                    default:
                        //パラメータ不正
                        MessageBox.Show("パラメータ不正(Mode)", "エラー");
                        共通プロパティ.ReturnMenu = true;
                        this.Dispose();
                        this.Close();
                        break;
                }
            }
        }

        private void DgvMode_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                //ヘッダークリックは無視する
            }
            else
            {
                switch (ifc.Mode)
                {
                    case FormCommon.Mode.アンケート入力:
                        DgvModeQ.CurrentRow.Cells[0].Selected = true;
                        break;

                    case FormCommon.Mode.顧客伝票修正:
                    case FormCommon.Mode.顧客伝票チェック:
                        DgvModeC.CurrentRow.Cells[0].Selected = true;
                        break;

                    default:
                        //パラメータ不正
                        MessageBox.Show("パラメータ不正(Mode)", "エラー");
                        共通プロパティ.ReturnMenu = true;
                        this.Dispose();
                        this.Close();
                        break;
                }

                BtnNext.PerformClick();
            }

        }
        /// <summary>
        //              一覧　KeyDown
        /// </summary>
        private void DgvMode_KeyDown(object sender, KeyEventArgs e)
        {
            //Enter Key
            if (e.KeyCode == Keys.Enter)
            {
                //解答・入力値表示ボタンClick
                BtnNext.PerformClick();
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

    }
}
