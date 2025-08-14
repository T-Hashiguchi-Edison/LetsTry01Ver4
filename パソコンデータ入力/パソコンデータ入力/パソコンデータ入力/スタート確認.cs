using System.Data.SQLite;
using System.Runtime.InteropServices;
using System.Text;

namespace パソコンデータ入力
{
    public partial class Frmスタート確認 : Form
    {
        // SqLite ファイルへの接続文字列
        private string connectionString = "";

        //マスタ情報
        private int Teiji = 0;
        private int Start_No = 0;
        private int Start_No1 = 0;
        private int Start_No2 = 0;
        private int Start_No3 = 0;
        private int FormDisp = 0;
        private int FormLR = 0;
        private int ZipSearch = 0;

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
        //              スタート確認
        /// </summary>
        /// <param name="prm">画面引継ぎ情報</param>
        public Frmスタート確認(FormCommon.Form_IF prm)
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
        private void Frmスタート確認_Load(object sender, EventArgs e)
        {
            // DB ファイルへの接続文字列
            if (System.IO.File.Exists(Application.StartupPath + @"\LetsTry04.ini"))
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                StreamReader sr = new StreamReader(Application.StartupPath + @"\LetsTry04.ini", Encoding.GetEncoding("Shift_JIS"));
                connectionString = SetPathString(sr.ReadLine());
                //データ取得
                getMaster();
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
            switch (ifc.Mode)
            {
                case FormCommon.Mode.アンケート入力:
                    LblMessage1.Text = "これからアンケート入力を始めます。";
                    switch (FormDisp)
                    {
                        case FormCommon.FormDisp.紙:
                            LblMessage2.Text = "紙のアンケートカードを使います。";
                            break;
                        case FormCommon.FormDisp.画面:
                            LblMessage2.Text = "画面のアンケートカードを使います。";
                            break;
                        default:
                            //パラメータ不正
                            MessageBox.Show("パラメータ不正(FormDisp)", "エラー");
                            共通プロパティ.ReturnMenu = true;
                            this.Dispose();
                            this.Close();
                            break;
                    }
                    switch (Teiji)
                    {
                        case FormCommon.Teiji.番号順:
                            if (Start_No == 0)
                            {
                                if (Start_No1 == 0)
                                {
                                    LblMessage3.Text = "アンケートカードは番号順に出てきます。開始ＮＯはＮＯ0001からです。";
                                }
                                else
                                {
                                    LblMessage3.Text = "アンケートカードは番号順に出てきます。開始ＮＯはＮＯ" + Start_No1.ToString("0000") + "からです。";
                                }
                            }
                            else
                            {
                                LblMessage3.Text = "アンケートカードは番号順に出てきます。開始ＮＯはＮＯ" + Start_No.ToString("0000") + "からです。";
                            }
                            break;
                        case FormCommon.Teiji.シャッフル:
                            LblMessage3.Text = "アンケートカードはランダムに出てきます。";
                            break;
                        default:
                            //パラメータ不正
                            MessageBox.Show("パラメータ不正(Teiji)", "エラー");
                            共通プロパティ.ReturnMenu = true;
                            this.Dispose();
                            this.Close();
                            break;
                    }
                    break;
                case FormCommon.Mode.顧客伝票修正:
                    LblMessage1.Text = "これから顧客伝票修正を始めます。";
                    switch (FormDisp)
                    {
                        case FormCommon.FormDisp.紙:
                            LblMessage2.Text = "紙の顧客伝票を使います。";
                            break;
                        case FormCommon.FormDisp.画面:
                            LblMessage2.Text = "画面の顧客伝票を使います。";
                            break;
                        default:
                            //パラメータ不正
                            MessageBox.Show("パラメータ不正(FormDisp)", "エラー");
                            共通プロパティ.ReturnMenu = true;
                            this.Dispose();
                            this.Close();
                            break;
                    }
                    switch (Teiji)
                    {
                        case FormCommon.Teiji.番号順:
                            if (Start_No == 0)
                            {
                                if (Start_No2 == 0)
                                {
                                    LblMessage3.Text = "伝票は番号順に出てきます。開始ＮＯはＮＯ0001からです。";
                                }
                                else
                                {
                                    LblMessage3.Text = "伝票は番号順に出てきます。開始ＮＯはＮＯ" + Start_No2.ToString("0000") + "からです。";
                                }
                            }
                            else
                            {
                                LblMessage3.Text = "伝票は番号順に出てきます。開始ＮＯはＮＯ" + Start_No.ToString("0000") + "からです。";
                            }
                            break;
                        case FormCommon.Teiji.シャッフル:
                            LblMessage3.Text = "伝票はランダムに出てきます。";
                            break;
                        default:
                            //パラメータ不正
                            MessageBox.Show("パラメータ不正(Teiji)", "エラー");
                            共通プロパティ.ReturnMenu = true;
                            this.Dispose();
                            this.Close();
                            break;
                    }
                    break;
                case FormCommon.Mode.顧客伝票チェック:
                    LblMessage1.Text = "これから顧客伝票ミスチェックを始めます。";
                    switch (FormDisp)
                    {
                        case FormCommon.FormDisp.紙:
                            LblMessage2.Text = "紙の顧客伝票を使います。";
                            break;
                        case FormCommon.FormDisp.画面:
                            LblMessage2.Text = "画面の顧客伝票を使います。";
                            break;
                        default:
                            //パラメータ不正
                            MessageBox.Show("パラメータ不正(FormDisp)", "エラー");
                            共通プロパティ.ReturnMenu = true;
                            this.Dispose();
                            this.Close();
                            break;
                    }
                    switch (Teiji)
                    {
                        case FormCommon.Teiji.番号順:
                            if (Start_No == 0)
                            {
                                if (Start_No3 == 0)
                                {
                                    LblMessage3.Text = "伝票は番号順に出てきます。開始ＮＯはＮＯ0001からです。";
                                }
                                else
                                {
                                    LblMessage3.Text = "伝票は番号順に出てきます。開始ＮＯはＮＯ" + Start_No3.ToString("0000") + "からです。";
                                }
                            }
                            else
                            {
                                LblMessage3.Text = "伝票は番号順に出てきます。開始ＮＯはＮＯ" + Start_No.ToString("0000") + "からです。";
                            }
                            break;
                        case FormCommon.Teiji.シャッフル:
                            LblMessage3.Text = "伝票はランダムに出てきます。";
                            break;
                        default:
                            //パラメータ不正
                            共通プロパティ.ReturnMenu = true;
                            MessageBox.Show("パラメータ不正(Teiji)", "エラー");
                            this.Dispose();
                            this.Close();
                            break;
                    }
                    break;
                default:
                    //パラメータ不正
                    MessageBox.Show("パラメータ不正(Mode)", "エラー");
                    共通プロパティ.ReturnMenu = true;
                    this.Dispose();
                    this.Close();
                    break;
            }

            LblMessage4.Text = "時間は" + ifc.Timer.ToString("00") + "分です。";
            LblMessage5.Text = "目標作業枚数は" + ifc.WorkCnt.ToString() + "枚です。";
            LblMessage6.Text = "目標正しい枚数は" + ifc.CorrectCnt.ToString() + "枚です。";

            switch (ifc.Course)
            {
                case FormCommon.Course.実力テスト:
                    LblMessage1.Visible = true;
                    LblMessage2.Visible = true;
                    LblMessage3.Visible = true;
                    LblMessage4.Visible = true;
                    LblMessage5.Visible = false;
                    LblMessage6.Visible = false;
                    LblMessage7.Visible = true;
                    break;

                case FormCommon.Course.基礎トレーニング:
                    LblMessage1.Visible = true;
                    LblMessage2.Visible = true;
                    LblMessage3.Visible = true;
                    LblMessage4.Visible = false;
                    LblMessage5.Visible = false;
                    LblMessage6.Visible = false;
                    LblMessage7.Visible = true;
                    break;

                case FormCommon.Course.レベルアップトレーニング:
                    LblMessage1.Visible = true;
                    LblMessage2.Visible = true;
                    LblMessage3.Visible = true;
                    LblMessage4.Visible = true;
                    LblMessage5.Visible = true;
                    LblMessage6.Visible = true;
                    LblMessage7.Visible = true;
                    break;
                default:
                    //パラメータ不正
                    MessageBox.Show("パラメータ不正(Course)", "エラー");
                    共通プロパティ.ReturnMenu = true;
                    this.Dispose();
                    this.Close();
                    break;
            }
        }

        /// <summary>
        //              スタート　Click
        /// </summary>
        private void BtnStart_Click(object sender, EventArgs e)
        {
            BtnCancel.Enabled = false;

            //非表示する
            this.Visible = false;

            //初期表示
            switch (ifc.Mode)
            {
                case FormCommon.Mode.アンケート入力:
                    SetParam();
                    Frmアンケートカード入力 frmQ = new Frmアンケートカード入力(ifc);
                    frmQ.ShowDialog();

                    break;
                case FormCommon.Mode.顧客伝票修正:
                    SetParam();
                    Frm顧客伝票修正 frmD = new Frm顧客伝票修正(ifc);
                    frmD.ShowDialog();

                    break;
                default:
                    SetParam();
                    Frm顧客伝票ミスチェック frmC = new Frm顧客伝票ミスチェック(ifc);
                    frmC.ShowDialog();

                    break;
            }

            if (共通プロパティ.ReturnMenu)
            {
                this.Dispose();
                this.Close();
            }
            else
            {
                BtnCancel.Enabled = true;

                //終了する
                this.Dispose();
                this.Close();
            }


        }

        /// <summary>
        //              キャンセル　Click
        /// </summary>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            共通プロパティ.ReturnMenu = true;
            this.Dispose();
            this.Close();
        }

        /// <summary>
        //              試行条件マスタ、ユーザマスタ　取得処理
        /// </summary>
        /// <returns>true:正常終了　false:異常終了</returns>
        private Boolean getMaster()
        {
            try
            {

                // SQL クエリ
                string sql = "";
                int cnt = 0;

                // データＤＢを開く
                using (SQLiteConnection con = new SQLiteConnection(SetconnectionString(connectionString)))
                {
                    con.Open();

                    //試行条件マスタを取得する
                    //マスタ作成
                    sql = "CREATE TABLE IF NOT EXISTS 試行条件マスタ(id        int , " +
                                                                    "Teiji     int ," +
                                                                    "StartNo   int ," +
                                                                    "QFormDisp int ," +
                                                                    "QFormLR   int ," +
                                                                    "ZipSearch int ," +
                                                                    "InsDate   datetime ," +
                                                                    "UpdDate   datetime ," +
                                                                    "PRIMARY KEY(id)" +
                                                                  ")";

                    SQLiteCommand com = new SQLiteCommand(sql, con);
                    com.ExecuteNonQuery();

                    sql = "SELECT * From 試行条件マスタ WHERE id = 1";

                    using (SQLiteCommand command = new SQLiteCommand(sql, con))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // データの処理
                                Teiji = reader.GetInt32(1);
                                Start_No = reader.GetInt32(2);
                                FormDisp = reader.GetInt32(3);
                                FormLR = reader.GetInt32(4);
                                ZipSearch = reader.GetInt32(5);
                                cnt++;
                            }
                            if (cnt == 0)
                            {
                                sql = "Insert into 試行条件マスタ Values(" + 1 + "," +                          //ID
                                                                             1 + "," +                          //呈示方法(1:番号順)
                                                                             0 + "," +                          //開始No(0:前回の続き)
                                                                             1 + "," +                          //表示方法(1:画面表示)
                                                                             0 + "," +                          //表示位置(0:左)
                                                                             1 + "," +                          //郵便番号検索(1:有効)
                                                                            "datetime('now', 'localtime')," +
                                                                            "datetime('now', 'localtime')" +
                                                                     ");";

                                com = new SQLiteCommand(sql, con);
                                com.ExecuteNonQuery();
                                // データの処理
                                Teiji = 0;
                                Start_No = 0;
                                FormDisp = 1;
                                FormLR = 0;
                                ZipSearch = 1;
                            }
                        }
                    }

                    //ユーザマスタを取得して、表示する
                    sql = "SELECT * From ユーザマスタ WHERE id = " + ifc.Id.ToString();

                    using (SQLiteCommand command = new SQLiteCommand(sql, con))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // データの処理
                                Start_No1 = reader.GetInt32(5);
                                Start_No2 = reader.GetInt32(6);
                                Start_No3 = reader.GetInt32(7);
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
        //              パラメータセット
        /// </summary>
        private void SetParam()
        {
            ifc.Teiji = Teiji;
            ifc.Start_No = Start_No;
            ifc.Start_No1 = Start_No1;
            ifc.Start_No2 = Start_No2;
            ifc.Start_No3 = Start_No3;
            ifc.FormDisp = FormDisp;
            ifc.FormLR = FormLR;
            ifc.ZipSearch = ZipSearch;
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
