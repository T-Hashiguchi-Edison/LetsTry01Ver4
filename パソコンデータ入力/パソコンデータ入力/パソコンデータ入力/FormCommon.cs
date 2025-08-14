namespace パソコンデータ入力
{
    /// <summary>
    /// 共通クラス
    /// </summary>
    public static class FormCommon
    {
        /// <summary>
        //           フォームインターフェース
        /// </summary>
        public struct Form_IF
        {
            public int Id;              //ユーザID
            public string NameSi;       //氏
            public string NameMei;      //名
            public int Mode;            //メニュー  (1:アンケート入力 2:顧客伝票修正 3:顧客伝票チェック)
            public int Course;          //コース    (1:実力テスト 2:基礎トレーニング 3:レベルアップトレーニング)
            public int Timer;           //終了時間 
            public int DispProgress;    //進捗状況表示　(0:OFF 1:ON) 
            public int DispTimer;       //タイマー表示　(0:OFF 1:ON) =====>分秒表示
            public int DispRemain;      //残り時間表示　(0:OFF 1:ON) =====>プログレスバー表示
            public int InputImage;      //印刷物イメージ　(0:通常 1:拡大) 
            public int InputForm;       //入力画面　　　　(0:通常 1:拡大) 
            public int WorkCnt;         //作業枚数 
            public int CorrectCnt;      //正しい枚数 
            public int DispGraph;       //グラフ表示　(0:OFF 1:ON) 
            public int DispErrChk;      //エラーチェック結果のフィードバック　(0:OFF 1:ON) 
            public int DispFinal;       //最終フィードバック　(0:OFF 1:ON) 
            public int Teiji;           //呈示方法　(0:番号順 1:シャッフル)
            public int Start_No;        //開始番号　(0:前回の続き 1～500:開始番号)
            public int Start_No1;       //アンケートカード開始番号(前回の続き時)
            public int Start_No2;       //顧客伝票開始番号(前回の続き時)
            public int Start_No3;       //顧客伝票開始番号(前回の続き時)
            public int FormDisp;        //表示方法　(0:紙 1:画面)
            public int FormLR;          //表示位置　(0:左 1:右)
            public int ZipSearch;       //郵便番号検索　(0:使用しない 1:使用する)

            /// <summary>
            //           初期化
            /// </summary>
            /// <param name="UserId">ユーザID</param>
            public void Initialize(int UserId,string UserSi,string UserMei)
            {
                Id = UserId;
                NameSi = UserSi;
                NameMei = UserMei;
                Mode = 0;
                Course = 0;
                Timer = 0;
                DispProgress = 0;
                DispTimer = 0;
                DispRemain = 0;
                InputImage = 0;
                InputForm = 0;
                WorkCnt = 0;
                CorrectCnt = 0;
                DispGraph = 0;
                DispErrChk = 0;
                DispFinal = 0;
                Teiji = 0;
                Start_No = 0;
                Start_No1 = 0;
                Start_No2 = 0;
                Start_No3 = 0;
                FormDisp = 0;
                FormLR = 0;
                ZipSearch = 0;
            }

            /// <summary>
            //           コピー
            /// </summary>
            /// <param name="FormIF">ユーザID</param>
            public void Copy(Form_IF FormIF)
            {
                Id = FormIF.Id;
                NameSi = FormIF.NameSi;
                NameMei = FormIF.NameMei;   
                Mode = FormIF.Mode;
                Course = FormIF.Course;
                Timer = FormIF.Timer;
                DispProgress = FormIF.DispProgress;
                DispTimer = FormIF.DispTimer;
                DispRemain = FormIF.DispRemain;
                InputImage = FormIF.InputImage;
                InputForm = FormIF.InputForm;
                WorkCnt = FormIF.WorkCnt;
                CorrectCnt = FormIF.CorrectCnt;
                DispGraph = FormIF.DispGraph;
                DispErrChk = FormIF.DispErrChk;
                DispFinal = FormIF.DispFinal;
                Teiji = FormIF.Teiji;
                Start_No = FormIF.Start_No;
                Start_No1 = FormIF.Start_No1;
                Start_No2 = FormIF.Start_No2;
                Start_No3 = FormIF.Start_No3;
                FormDisp = FormIF.FormDisp;
                FormLR = FormIF.FormLR;
                ZipSearch = FormIF.ZipSearch;

            }
        }

        /// <summary>
        //           処理モード
        /// </summary>
        public class Mode
        {
            public const int アンケート入力 = 1;
            public const int 顧客伝票修正 = 2;
            public const int 顧客伝票チェック = 3;
        }

        /// <summary>
        //           コース
        /// </summary>
        public class Course
        {
            public const int 実力テスト = 1;
            public const int 基礎トレーニング = 2;
            public const int レベルアップトレーニング = 3;
        }

        /// <summary>
        //           表示
        /// </summary>
        public class Displey
        {
            public const int 表示しない = 0;
            public const int 表示する = 1;
        }

        /// <summary>
        //           画面拡大
        /// </summary>
        public class Expansion
        {
            public const int 通常 = 0;
            public const int 拡大 = 1;
        }

        /// <summary>
        //           カード/伝票
        /// </summary>
        public class FormDisp
        {
            public const int 紙 = 0;
            public const int 画面 = 1;
        }

        /// <summary>
        //           呈示方法
        /// </summary>
        public class Teiji
        {
            public const int 番号順 = 1;
            public const int シャッフル = 2;
        }

        /// <summary>
        //           表示位置
        /// </summary>
        public class DispLR
        {
            public const int 左 = 0;
            public const int 右 = 1;
        }

        /// <summary>
        //           郵便番号検索
        /// </summary>
        public class ZipSearch
        {
            public const int 未使用 = 0;
            public const int 使用 = 1;
        }
    }

    /// <summary>
    /// 共通プロパティ
    /// </summary>
    public static class 共通プロパティ
    {
        //住所選択
        public static String? SelectedAddress { get; set; }
        //ユーザメニュー戻し
        public static Boolean ReturnMenu { get; set; }
    }

    /// <summary>
    /// 構造体
    /// </summary>
    public static class 構造体
    {
        public struct アンケートカード入力値
        {
            public DateTime StartTime = DateTime.MinValue;
            public DateTime EndTime = DateTime.MaxValue;
            public string ElapsedTime = "";

            public string JogaiFlg = "";

            public string id = "";
            public string NameKana = "";
            public string NameKanji = "";
            public string ZipCode = "";
            public string Address = "";
            public string TelNo = "";
            public string MailAddress = "";
            public string Q1Answer = "";
            public string Q2Answer = "";
            public string Q3Answer = "";

            public int CheckCnt = 0;

            public アンケートカード入力値()
            {
            }
        }

        public struct アンケートカード項目
        {
            public int id = 0;
            public string NameKana = "";
            public string NameKanji = "";
            public string ZipCode = "";
            public string Address = "";
            public string TelNo = "";
            public string MailAddress = "";
            public string Q1Answer = "";
            public string Q2Answer = "";
            public string Q3Answer = "";
            public アンケートカード項目()
            {
            }
        }

        public struct 顧客伝票カード入力値
        {
            public DateTime StartTime = DateTime.MinValue;
            public DateTime EndTime = DateTime.MaxValue;
            public string ElapsedTime = "";

            public string JogaiFlg = "";

            public string id = "";
            public string CustCd = "";
            public string ItemCd = "";
            public string TelNo = "";
            public string MailAddress = "";

            public int CheckCnt = 0;

            public 顧客伝票カード入力値()
            {
            }
        }

        public struct 顧客伝票カード項目
        {
            public int id = 0;
            public string CustCd = "";
            public string ItemCd = "";
            public string TelNo = "";
            public string MailAddress = "";
            public 顧客伝票カード項目()
            {
            }
        }

        public struct 共通エラー文字種別
        {
            public int id = 0;
            public string Kana = "";
            public string Kanji = "";
            public string Suuji = "";
            public string EiOumoji = "";
            public string EiKomoji = "";
            public string Kigou = "";
            public 共通エラー文字種別()
            {
            }
        }
    }
}
