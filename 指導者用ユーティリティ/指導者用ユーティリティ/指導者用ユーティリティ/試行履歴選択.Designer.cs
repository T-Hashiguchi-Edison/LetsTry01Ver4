namespace 指導者用ユーティリティ
{
    partial class Frm試行履歴選択
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle19 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
            DgvDetail = new DataGridView();
            BtnCancel = new Button();
            BtnDel = new Button();
            LblName = new Label();
            LblTime = new Label();
            LblCnt2 = new Label();
            LblCnt = new Label();
            CmbMode = new ComboBox();
            CmbTime = new ComboBox();
            LblCourse = new Label();
            LblMode = new Label();
            CmbCourse = new ComboBox();
            LblDisp = new Label();
            CmbDisp = new ComboBox();
            TxtUserName = new TextBox();
            LblDetail = new Label();
            LblComment = new Label();
            BtnResult = new Button();
            BtnList = new Button();
            ID = new DataGridViewTextBoxColumn();
            CheckTimes = new DataGridViewCheckBoxColumn();
            Times = new DataGridViewTextBoxColumn();
            StartDate = new DataGridViewTextBoxColumn();
            Course = new DataGridViewTextBoxColumn();
            WorkTime = new DataGridViewTextBoxColumn();
            WorkMaisu = new DataGridViewTextBoxColumn();
            CorrectMaisu = new DataGridViewTextBoxColumn();
            CorrectRate = new DataGridViewTextBoxColumn();
            WorkCnt = new DataGridViewTextBoxColumn();
            CorrectCnt = new DataGridViewTextBoxColumn();
            Feedback = new DataGridViewTextBoxColumn();
            ColorCD = new DataGridViewTextBoxColumn();
            FormDisp = new DataGridViewTextBoxColumn();
            Teiji = new DataGridViewTextBoxColumn();
            DispProgress = new DataGridViewTextBoxColumn();
            DispTimer = new DataGridViewTextBoxColumn();
            DispRemain = new DataGridViewTextBoxColumn();
            DispGraph = new DataGridViewTextBoxColumn();
            ZipSearch = new DataGridViewTextBoxColumn();
            Sound = new DataGridViewTextBoxColumn();
            AnswerKomoku = new DataGridViewTextBoxColumn();
            CorrectKomoku = new DataGridViewTextBoxColumn();
            CorrectKoumokuRate = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)DgvDetail).BeginInit();
            SuspendLayout();
            // 
            // DgvDetail
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DgvDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DgvDetail.ColumnHeadersHeight = 29;
            DgvDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            DgvDetail.Columns.AddRange(new DataGridViewColumn[] { ID, CheckTimes, Times, StartDate, Course, WorkTime, WorkMaisu, CorrectMaisu, CorrectRate, WorkCnt, CorrectCnt, Feedback, ColorCD, FormDisp, Teiji, DispProgress, DispTimer, DispRemain, DispGraph, ZipSearch, Sound, AnswerKomoku, CorrectKomoku, CorrectKoumokuRate });
            dataGridViewCellStyle19.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = SystemColors.Window;
            dataGridViewCellStyle19.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dataGridViewCellStyle19.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle19.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = DataGridViewTriState.False;
            DgvDetail.DefaultCellStyle = dataGridViewCellStyle19;
            DgvDetail.Location = new Point(24, 96);
            DgvDetail.MultiSelect = false;
            DgvDetail.Name = "DgvDetail";
            DgvDetail.RowHeadersVisible = false;
            DgvDetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvDetail.Size = new Size(840, 360);
            DgvDetail.TabIndex = 13;
            DgvDetail.CellClick += DgvDetail_CellClick;
            DgvDetail.CellDoubleClick += DgvDetail_CellDoubleClick;
            DgvDetail.KeyDown += DgvDetail_KeyDown;
            // 
            // BtnCancel
            // 
            BtnCancel.Location = new Point(760, 496);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(104, 32);
            BtnCancel.TabIndex = 18;
            BtnCancel.Text = "閉じる";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // BtnDel
            // 
            BtnDel.Location = new Point(24, 496);
            BtnDel.Name = "BtnDel";
            BtnDel.Size = new Size(88, 32);
            BtnDel.TabIndex = 15;
            BtnDel.Text = "削除(D)";
            BtnDel.UseVisualStyleBackColor = true;
            BtnDel.Click += BtnDel_Click;
            // 
            // LblName
            // 
            LblName.Font = new Font("ＭＳ Ｐゴシック", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblName.Location = new Point(24, 0);
            LblName.Margin = new Padding(4, 0, 4, 0);
            LblName.Name = "LblName";
            LblName.Size = new Size(72, 24);
            LblName.TabIndex = 0;
            LblName.Text = "ユーザー名";
            LblName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblTime
            // 
            LblTime.Font = new Font("ＭＳ Ｐゴシック", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblTime.Location = new Point(216, 24);
            LblTime.Margin = new Padding(4, 0, 4, 0);
            LblTime.Name = "LblTime";
            LblTime.Size = new Size(96, 24);
            LblTime.TabIndex = 4;
            LblTime.Text = "試行実時間(E)";
            LblTime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblCnt2
            // 
            LblCnt2.Font = new Font("ＭＳ Ｐゴシック", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblCnt2.Location = new Point(848, 72);
            LblCnt2.Margin = new Padding(4, 0, 4, 0);
            LblCnt2.Name = "LblCnt2";
            LblCnt2.Size = new Size(29, 24);
            LblCnt2.TabIndex = 12;
            LblCnt2.Text = "件";
            LblCnt2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblCnt
            // 
            LblCnt.Font = new Font("ＭＳ Ｐゴシック", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblCnt.Location = new Point(792, 72);
            LblCnt.Margin = new Padding(4, 0, 4, 0);
            LblCnt.Name = "LblCnt";
            LblCnt.Size = new Size(56, 24);
            LblCnt.TabIndex = 11;
            LblCnt.Text = "99,999";
            LblCnt.TextAlign = ContentAlignment.MiddleRight;
            // 
            // CmbMode
            // 
            CmbMode.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbMode.Font = new Font("ＭＳ ゴシック", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            CmbMode.FormattingEnabled = true;
            CmbMode.Items.AddRange(new object[] { "アンケート入力", "顧客伝票修正", "顧客伝票ミスチェック" });
            CmbMode.Location = new Point(24, 48);
            CmbMode.Name = "CmbMode";
            CmbMode.Size = new Size(184, 24);
            CmbMode.TabIndex = 3;
            CmbMode.SelectedIndexChanged += CmbMode_SelectedIndexChanged;
            // 
            // CmbTime
            // 
            CmbTime.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbTime.Font = new Font("ＭＳ ゴシック", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            CmbTime.FormattingEnabled = true;
            CmbTime.Items.AddRange(new object[] { "15分", "30分", "45分", "60分", "60分換算値", "試行中止" });
            CmbTime.Location = new Point(216, 48);
            CmbTime.Name = "CmbTime";
            CmbTime.Size = new Size(112, 24);
            CmbTime.TabIndex = 5;
            CmbTime.SelectedIndexChanged += CmbTime_SelectedIndexChanged;
            // 
            // LblCourse
            // 
            LblCourse.Font = new Font("ＭＳ Ｐゴシック", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblCourse.Location = new Point(24, 24);
            LblCourse.Margin = new Padding(4, 0, 4, 0);
            LblCourse.Name = "LblCourse";
            LblCourse.Size = new Size(56, 24);
            LblCourse.TabIndex = 2;
            LblCourse.Text = "課題(K)";
            LblCourse.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblMode
            // 
            LblMode.Font = new Font("ＭＳ Ｐゴシック", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblMode.Location = new Point(336, 24);
            LblMode.Margin = new Padding(4, 0, 4, 0);
            LblMode.Name = "LblMode";
            LblMode.Size = new Size(96, 24);
            LblMode.TabIndex = 6;
            LblMode.Text = "コース(C)";
            LblMode.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CmbCourse
            // 
            CmbCourse.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbCourse.Font = new Font("ＭＳ ゴシック", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            CmbCourse.FormattingEnabled = true;
            CmbCourse.Items.AddRange(new object[] { "実力テスト／レベルアップトレーニング", "基礎トレーニング" });
            CmbCourse.Location = new Point(336, 48);
            CmbCourse.Name = "CmbCourse";
            CmbCourse.Size = new Size(320, 24);
            CmbCourse.TabIndex = 7;
            CmbCourse.SelectedIndexChanged += CmbCourse_SelectedIndexChanged;
            // 
            // LblDisp
            // 
            LblDisp.Font = new Font("ＭＳ Ｐゴシック", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblDisp.Location = new Point(664, 24);
            LblDisp.Margin = new Padding(4, 0, 4, 0);
            LblDisp.Name = "LblDisp";
            LblDisp.Size = new Size(96, 24);
            LblDisp.TabIndex = 8;
            LblDisp.Text = "表示データ(H)";
            LblDisp.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CmbDisp
            // 
            CmbDisp.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbDisp.Font = new Font("ＭＳ ゴシック", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            CmbDisp.FormattingEnabled = true;
            CmbDisp.Items.AddRange(new object[] { "全て", "実力テスト最大作業量回", "実力テスト最大正解率回" });
            CmbDisp.Location = new Point(664, 48);
            CmbDisp.Name = "CmbDisp";
            CmbDisp.Size = new Size(200, 24);
            CmbDisp.TabIndex = 9;
            CmbDisp.SelectedIndexChanged += CmbDisp_SelectedIndexChanged;
            // 
            // TxtUserName
            // 
            TxtUserName.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            TxtUserName.ImeMode = ImeMode.On;
            TxtUserName.Location = new Point(96, 0);
            TxtUserName.Margin = new Padding(4);
            TxtUserName.MaxLength = 30;
            TxtUserName.Name = "TxtUserName";
            TxtUserName.ReadOnly = true;
            TxtUserName.Size = new Size(205, 26);
            TxtUserName.TabIndex = 1;
            TxtUserName.TabStop = false;
            // 
            // LblDetail
            // 
            LblDetail.Font = new Font("ＭＳ Ｐゴシック", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblDetail.Location = new Point(24, 72);
            LblDetail.Margin = new Padding(4, 0, 4, 0);
            LblDetail.Name = "LblDetail";
            LblDetail.Size = new Size(72, 24);
            LblDetail.TabIndex = 10;
            LblDetail.Text = "試行履歴";
            LblDetail.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblComment
            // 
            LblComment.Font = new Font("ＭＳ Ｐゴシック", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblComment.Location = new Point(24, 456);
            LblComment.Margin = new Padding(4, 0, 4, 0);
            LblComment.Name = "LblComment";
            LblComment.Size = new Size(448, 40);
            LblComment.TabIndex = 14;
            LblComment.Text = "解析したい試行回のチェックをONにして［解析結果表示］ボタンを押してください。\r\nこの画面は最大化やリサイズができます。";
            LblComment.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // BtnResult
            // 
            BtnResult.Location = new Point(648, 496);
            BtnResult.Name = "BtnResult";
            BtnResult.Size = new Size(104, 32);
            BtnResult.TabIndex = 17;
            BtnResult.Text = "解析結果表示";
            BtnResult.UseVisualStyleBackColor = true;
            BtnResult.Click += BtnResult_Click;
            // 
            // BtnList
            // 
            BtnList.Location = new Point(536, 496);
            BtnList.Name = "BtnList";
            BtnList.Size = new Size(104, 32);
            BtnList.TabIndex = 16;
            BtnList.Text = "試行一覧表示";
            BtnList.UseVisualStyleBackColor = true;
            BtnList.Click += BtnList_Click;
            // 
            // ID
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            ID.DefaultCellStyle = dataGridViewCellStyle2;
            ID.HeaderText = "ID";
            ID.Name = "ID";
            ID.Visible = false;
            // 
            // CheckTimes
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.NullValue = false;
            CheckTimes.DefaultCellStyle = dataGridViewCellStyle3;
            CheckTimes.HeaderText = "";
            CheckTimes.Name = "CheckTimes";
            CheckTimes.Resizable = DataGridViewTriState.False;
            CheckTimes.Width = 20;
            // 
            // Times
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Times.DefaultCellStyle = dataGridViewCellStyle4;
            Times.HeaderText = "試行回";
            Times.Name = "Times";
            Times.Resizable = DataGridViewTriState.True;
            Times.SortMode = DataGridViewColumnSortMode.NotSortable;
            Times.Width = 90;
            // 
            // StartDate
            // 
            StartDate.HeaderText = "実施日";
            StartDate.MaxInputLength = 140;
            StartDate.Name = "StartDate";
            StartDate.Width = 160;
            // 
            // Course
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Course.DefaultCellStyle = dataGridViewCellStyle5;
            Course.HeaderText = "コース";
            Course.Name = "Course";
            Course.Width = 60;
            // 
            // WorkTime
            // 
            WorkTime.HeaderText = "試行実時間";
            WorkTime.Name = "WorkTime";
            // 
            // WorkMaisu
            // 
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleRight;
            WorkMaisu.DefaultCellStyle = dataGridViewCellStyle6;
            WorkMaisu.HeaderText = "作業量";
            WorkMaisu.Name = "WorkMaisu";
            WorkMaisu.Width = 70;
            // 
            // CorrectMaisu
            // 
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleRight;
            CorrectMaisu.DefaultCellStyle = dataGridViewCellStyle7;
            CorrectMaisu.HeaderText = "正しい枚数";
            CorrectMaisu.Name = "CorrectMaisu";
            // 
            // CorrectRate
            // 
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleRight;
            CorrectRate.DefaultCellStyle = dataGridViewCellStyle8;
            CorrectRate.HeaderText = "正解率";
            CorrectRate.Name = "CorrectRate";
            CorrectRate.Width = 70;
            // 
            // WorkCnt
            // 
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleRight;
            WorkCnt.DefaultCellStyle = dataGridViewCellStyle9;
            WorkCnt.HeaderText = "目標作業枚数";
            WorkCnt.Name = "WorkCnt";
            WorkCnt.Width = 120;
            // 
            // CorrectCnt
            // 
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleRight;
            CorrectCnt.DefaultCellStyle = dataGridViewCellStyle10;
            CorrectCnt.HeaderText = "目標正しい枚数";
            CorrectCnt.Name = "CorrectCnt";
            CorrectCnt.Width = 120;
            // 
            // Feedback
            // 
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Feedback.DefaultCellStyle = dataGridViewCellStyle11;
            Feedback.HeaderText = "結果呈示";
            Feedback.Name = "Feedback";
            Feedback.Width = 90;
            // 
            // ColorCD
            // 
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColorCD.DefaultCellStyle = dataGridViewCellStyle12;
            ColorCD.HeaderText = "選択色";
            ColorCD.Name = "ColorCD";
            ColorCD.Width = 70;
            // 
            // FormDisp
            // 
            FormDisp.HeaderText = "課題媒体";
            FormDisp.Name = "FormDisp";
            FormDisp.Width = 90;
            // 
            // Teiji
            // 
            Teiji.HeaderText = "呈示方法";
            Teiji.Name = "Teiji";
            Teiji.Width = 90;
            // 
            // DispProgress
            // 
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DispProgress.DefaultCellStyle = dataGridViewCellStyle13;
            DispProgress.HeaderText = "進捗呈示";
            DispProgress.Name = "DispProgress";
            DispProgress.Width = 90;
            // 
            // DispTimer
            // 
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DispTimer.DefaultCellStyle = dataGridViewCellStyle14;
            DispTimer.HeaderText = "タイマー";
            DispTimer.Name = "DispTimer";
            DispTimer.Width = 80;
            // 
            // DispRemain
            // 
            dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DispRemain.DefaultCellStyle = dataGridViewCellStyle15;
            DispRemain.HeaderText = "残り時間";
            DispRemain.Name = "DispRemain";
            DispRemain.Width = 90;
            // 
            // DispGraph
            // 
            dataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DispGraph.DefaultCellStyle = dataGridViewCellStyle16;
            DispGraph.HeaderText = "グラフ";
            DispGraph.Name = "DispGraph";
            DispGraph.Width = 70;
            // 
            // ZipSearch
            // 
            dataGridViewCellStyle17.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ZipSearch.DefaultCellStyle = dataGridViewCellStyle17;
            ZipSearch.HeaderText = "〒";
            ZipSearch.Name = "ZipSearch";
            ZipSearch.Width = 50;
            // 
            // Sound
            // 
            dataGridViewCellStyle18.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Sound.DefaultCellStyle = dataGridViewCellStyle18;
            Sound.HeaderText = "切替音";
            Sound.Name = "Sound";
            Sound.Width = 70;
            // 
            // AnswerKomoku
            // 
            AnswerKomoku.HeaderText = "作業項目量";
            AnswerKomoku.Name = "AnswerKomoku";
            AnswerKomoku.ReadOnly = true;
            AnswerKomoku.Visible = false;
            // 
            // CorrectKomoku
            // 
            CorrectKomoku.HeaderText = "正しい項目数";
            CorrectKomoku.Name = "CorrectKomoku";
            CorrectKomoku.ReadOnly = true;
            CorrectKomoku.Visible = false;
            // 
            // CorrectKoumokuRate
            // 
            CorrectKoumokuRate.HeaderText = "正解率";
            CorrectKoumokuRate.Name = "CorrectKoumokuRate";
            CorrectKoumokuRate.ReadOnly = true;
            CorrectKoumokuRate.Visible = false;
            // 
            // Frm試行履歴選択
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(884, 532);
            Controls.Add(TxtUserName);
            Controls.Add(CmbDisp);
            Controls.Add(CmbCourse);
            Controls.Add(CmbTime);
            Controls.Add(CmbMode);
            Controls.Add(LblCnt);
            Controls.Add(LblDisp);
            Controls.Add(LblCnt2);
            Controls.Add(LblMode);
            Controls.Add(LblTime);
            Controls.Add(LblComment);
            Controls.Add(LblDetail);
            Controls.Add(LblCourse);
            Controls.Add(LblName);
            Controls.Add(BtnList);
            Controls.Add(BtnResult);
            Controls.Add(BtnCancel);
            Controls.Add(BtnDel);
            Controls.Add(DgvDetail);
            Name = "Frm試行履歴選択";
            Text = "解析結果の出力[試行履歴の選択]";
            FormClosing += Frm試行履歴選択_FormClosing;
            Load += Frm試行履歴選択_Load;
            Resize += Frm試行履歴選択_Resize;
            ((System.ComponentModel.ISupportInitialize)DgvDetail).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DgvDetail;
        private Button BtnCancel;
        private Button BtnDel;
        private Label LblName;
        private Label LblTime;
        private Label LblCnt2;
        private Label LblCnt;
        private ComboBox CmbMode;
        private ComboBox CmbTime;
        private Label LblCourse;
        private Label LblMode;
        private ComboBox CmbCourse;
        private Label LblDisp;
        private ComboBox CmbDisp;
        private TextBox TxtUserName;
        private Label LblDetail;
        private Label LblComment;
        private Button BtnResult;
        private Button BtnList;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewCheckBoxColumn CheckTimes;
        private DataGridViewTextBoxColumn Times;
        private DataGridViewTextBoxColumn StartDate;
        private DataGridViewTextBoxColumn Course;
        private DataGridViewTextBoxColumn WorkTime;
        private DataGridViewTextBoxColumn WorkMaisu;
        private DataGridViewTextBoxColumn CorrectMaisu;
        private DataGridViewTextBoxColumn CorrectRate;
        private DataGridViewTextBoxColumn WorkCnt;
        private DataGridViewTextBoxColumn CorrectCnt;
        private DataGridViewTextBoxColumn Feedback;
        private DataGridViewTextBoxColumn ColorCD;
        private DataGridViewTextBoxColumn FormDisp;
        private DataGridViewTextBoxColumn Teiji;
        private DataGridViewTextBoxColumn DispProgress;
        private DataGridViewTextBoxColumn DispTimer;
        private DataGridViewTextBoxColumn DispRemain;
        private DataGridViewTextBoxColumn DispGraph;
        private DataGridViewTextBoxColumn ZipSearch;
        private DataGridViewTextBoxColumn Sound;
        private DataGridViewTextBoxColumn AnswerKomoku;
        private DataGridViewTextBoxColumn CorrectKomoku;
        private DataGridViewTextBoxColumn CorrectKoumokuRate;
    }
}
