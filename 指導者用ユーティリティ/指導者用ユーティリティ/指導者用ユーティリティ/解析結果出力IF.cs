namespace 指導者用ユーティリティ
{
    public class 解析結果出力IF
    {
        //明細データ
        public class DetailData
        {
            public string WorkTimes = "";
            public string Course = "";
            public string WorkDate = "";
            public int WorkTime = 0;
            public decimal WorkMaisu = 0;
            public decimal CorrectMaisu = 0;
            public decimal ErrorMaisu = 0;
            public decimal CorrectRate = 0;
            public decimal WorkItem = 0;
            public decimal CorrectItem = 0;
            public decimal ErrorItem = 0;
            public decimal CorrectItemRate = 0;
            public string FileNameI = "";
            public string FileNameR = "";
            public DetailData()
            {
            }
        }

        //最高値最低値データ
        public class MaxMinData
        {
            public int WorkTime = 0;
            public decimal MaxMaisu = 0;
            public decimal MaxRate = 0;
            public decimal MinMaisu = 0;
            public decimal MinRate = 0;
            public decimal MaxKoumoku = 0;
            public decimal MaxKoumokuRate = 0;
            public decimal MinKoumoku = 0;
            public decimal MinKoumokuRate = 0;
            public MaxMinData()
            {
            }
        }
    }

}
