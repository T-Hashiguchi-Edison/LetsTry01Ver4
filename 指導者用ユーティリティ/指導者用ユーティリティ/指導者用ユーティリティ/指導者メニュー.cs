using System.Runtime.InteropServices;


namespace 指導者用ユーティリティ
{
    public partial class Frm指導者メニュー : Form
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct DEVMODE
        {
            private const int CCHDEVICENAME = 0x20;
            private const int CCHFORMNAME = 0x20;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
            public string dmDeviceName; // デバイス名
            public short dmSpecVersion;
            public short dmDriverVersion;
            public short dmSize; // DEVMODE構造体のサイズ
            public short dmDriverExtra;
            public int dmFields;
            public int dmPositionX; // ディスプレイ位置X
            public int dmPositionY; // ディスプレイ位置Y
            public ScreenOrientation dmDisplayOrientation;
            public int dmDisplayFixedOutput;
            public short dmColor;
            public short dmDuplex;
            public short dmYResolution;
            public short dmTTOption;
            public short dmCollate;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
            public string dmFormName;
            public short dmLogPixels;
            public int dmBitsPerPel;
            public int dmPelsWidth; // ディスプレイ解像度（横幅）
            public int dmPelsHeight; // ディスプレイ解像度（高さ）
            public int dmDisplayFlags;
            public int dmDisplayFrequency;
            public int dmICMMethod;
            public int dmICMIntent;
            public int dmMediaType;
            public int dmDitherType;
            public int dmReserved1;
            public int dmReserved2;
            public int dmPanningWidth;
            public int dmPanningHeight;
        }

        [DllImport("user32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern bool EnumDisplaySettingsA(string lpszDeviceName, int iModeNum, ref DEVMODE lpDevMode);
        /// <summary>
        //              Initialize
        /// </summary>
        public Frm指導者メニュー()
        {
            InitializeComponent();

            //中央に配置する
            this.StartPosition = FormStartPosition.CenterScreen;

            //ユーザーがサイズを変更できないようにする
            //最大化、最小化はできる
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //フォームの最大化ボタンの表示、非表示を切り替える
            this.MaximizeBox = !this.MaximizeBox;
            //フォームの最小化ボタンの表示、非表示を切り替える
            this.MinimizeBox = !this.MinimizeBox;

            //フォームが最大化されないようにする
            this.MaximizeBox = false;
            //フォームが最小化されないようにする
            this.MinimizeBox = false;

            //自分自身のバージョン情報を取得する
            System.Diagnostics.FileVersionInfo ver = System.Diagnostics.FileVersionInfo.GetVersionInfo(
                                                                        System.Reflection.Assembly.GetExecutingAssembly().Location);
            this.Text= "指導者用ユーティリティ Ver" + ver.FileVersion;
        }

        /// <summary>
        //              Form　Load 
        /// </summary>
        private void Frm指導者メニュー_Load(object sender, EventArgs e)
        {
            // 現在のマウスカーソルがあるスクリーンを取得
            Screen currentScreen = Screen.FromPoint(Cursor.Position);
            // スクリーンの拡大率を取得
            int scale = getScaleOfScreen(currentScreen);
            if (scale != 100)
            {
                MessageBox.Show("ディスプレイの拡大率が" + scale.ToString() + "%です。" + Environment.NewLine +
                                "このアプリは拡大率が100%でないと正しく画面表示されません。" + Environment.NewLine +
                                "拡大率を100%に変更する、または他のＰＣでご利用になってください。"
                                , "警告");
            }
        }

        /// <summary>
        //              ショートカットキー判定　Key Down
        /// </summary>
        /// <param name="keyData">キー情報</param>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            //［Alt］+［1］が押されたらキャッチ(マスタ移行)
            if ((keyData == (Keys.D1 | Keys.Alt)) || (keyData == (Keys.NumPad1 | Keys.Alt)))
            {
                BtnMstIko.PerformClick();
            }
            //［Alt］+［2］が押されたらキャッチ(ユーザ登録・編集・削除)
            if ((keyData == (Keys.D2 | Keys.Alt)) || (keyData == (Keys.NumPad2 | Keys.Alt)))
            {
                BtnUserMst.PerformClick();
            }
            //［Alt］+［3］が押されたらキャッチ(試行条件の設定)
            if ((keyData == (Keys.D3 | Keys.Alt)) || (keyData == (Keys.NumPad3 | Keys.Alt)))
            {
                BtnCondition.PerformClick();
            }
            //［Alt］+［4］が押されたらキャッチ(解析結果の出力)
            if ((keyData == (Keys.D4 | Keys.Alt)) || (keyData == (Keys.NumPad4 | Keys.Alt)))
            {
                BtnReport.PerformClick();
            }
            //［Alt］+［5］が押されたらキャッチ(終了)
            if ((keyData == (Keys.D5 | Keys.Alt)) || (keyData == (Keys.NumPad5 | Keys.Alt)))
            {
                BtnEnd.PerformClick();
            }

            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        ///             マスタ移行ボタン Click
        /// </summary>
        private void BtnMstIko_Click(object sender, EventArgs e)
        {
            Frmマスタ移行 frm = new Frmマスタ移行();
            frm.ShowDialog();
        }

        /// <summary>
        ///             ユーザ登録・編集・削除ボタン Click
        /// </summary>
        private void BtnUserMst_Click(object sender, EventArgs e)
        {
            Frmユーザ登録 frm = new Frmユーザ登録();
            frm.ShowDialog();
        }

        /// <summary>
        ///             試行条件の設定ボタン Click
        /// </summary>
        private void BtnCondition_Click(object sender, EventArgs e)
        {
            Frm試行条件 frm = new Frm試行条件();
            frm.ShowDialog();
        }

        /// <summary>
        ///             解析結果の出力ボタン Click
        /// </summary>
        private void BtnReport_Click(object sender, EventArgs e)
        {
            Frmユーザ選択 frm = new Frmユーザ選択();
            frm.ShowDialog();
        }

        /// <summary>
        ///             終了ボタン Click
        /// </summary>
        private void BtnEnd_Click(object sender, EventArgs e)
        {
            //アプリケーションを終了する
            Application.Exit();
        }

        /// <summary>
        ///             拡大率取得 Click
        /// </summary>
        /// <param name="screen">コネクション文字列</param>
        /// <returns>拡大率</returns>
        public static int getScaleOfScreen(Screen screen)
        {
            DEVMODE dm = new DEVMODE();
            dm.dmSize = (short)Marshal.SizeOf(typeof(DEVMODE));
            int ENUM_CURRENT_SETTINGS = -1;
            EnumDisplaySettingsA(screen.DeviceName, ENUM_CURRENT_SETTINGS, ref dm);
            int scale = (screen.Bounds.Width * 100) / dm.dmPelsWidth;
            return scale;
        }

    }
}
