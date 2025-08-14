namespace 指導者用ユーティリティ
{
    partial class Frmユーザ比較
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
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DgvComp = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            TotalRank = new DataGridViewTextBoxColumn();
            NameKnj = new DataGridViewTextBoxColumn();
            WorkRank = new DataGridViewTextBoxColumn();
            WorkTime = new DataGridViewTextBoxColumn();
            WorkNumber = new DataGridViewTextBoxColumn();
            WorkCount = new DataGridViewTextBoxColumn();
            WorkCorrectRate = new DataGridViewTextBoxColumn();
            CorrectRank = new DataGridViewTextBoxColumn();
            CorrectTime = new DataGridViewTextBoxColumn();
            CorrectNumber = new DataGridViewTextBoxColumn();
            CorrectCount = new DataGridViewTextBoxColumn();
            CorrectRate = new DataGridViewTextBoxColumn();
            Last3TimeCount = new DataGridViewTextBoxColumn();
            Last3TimeCorrectRate = new DataGridViewTextBoxColumn();
            BtnCancel = new Button();
            BtnSave = new Button();
            LblCourse = new Label();
            LblLevel = new Label();
            LblCnt2 = new Label();
            LblCnt = new Label();
            CmbCourse = new ComboBox();
            CmbLevel = new ComboBox();
            LblComment = new Label();
            ((System.ComponentModel.ISupportInitialize)DgvComp).BeginInit();
            SuspendLayout();
            // 
            // DgvComp
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DgvComp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DgvComp.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvComp.Columns.AddRange(new DataGridViewColumn[] { ID, TotalRank, NameKnj, WorkRank, WorkTime, WorkNumber, WorkCount, WorkCorrectRate, CorrectRank, CorrectTime, CorrectNumber, CorrectCount, CorrectRate, Last3TimeCount, Last3TimeCorrectRate });
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = SystemColors.Window;
            dataGridViewCellStyle11.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dataGridViewCellStyle11.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.False;
            DgvComp.DefaultCellStyle = dataGridViewCellStyle11;
            DgvComp.Location = new Point(24, 56);
            DgvComp.MultiSelect = false;
            DgvComp.Name = "DgvComp";
            DgvComp.ReadOnly = true;
            DgvComp.RowHeadersVisible = false;
            DgvComp.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvComp.Size = new Size(512, 400);
            DgvComp.TabIndex = 0;
            DgvComp.CellClick += DgvComp_CellClick;
            DgvComp.CellDoubleClick += DgvComp_CellDoubleClick;
            DgvComp.KeyDown += DgvComp_KeyDown;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Visible = false;
            // 
            // TotalRank
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            TotalRank.DefaultCellStyle = dataGridViewCellStyle2;
            TotalRank.HeaderText = "順位";
            TotalRank.Name = "TotalRank";
            TotalRank.ReadOnly = true;
            TotalRank.Width = 70;
            // 
            // NameKnj
            // 
            NameKnj.HeaderText = "氏名";
            NameKnj.MaxInputLength = 100;
            NameKnj.Name = "NameKnj";
            NameKnj.ReadOnly = true;
            NameKnj.Width = 150;
            // 
            // WorkRank
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            WorkRank.DefaultCellStyle = dataGridViewCellStyle3;
            WorkRank.HeaderText = "作業量の順位";
            WorkRank.Name = "WorkRank";
            WorkRank.ReadOnly = true;
            WorkRank.Width = 130;
            // 
            // WorkTime
            // 
            WorkTime.HeaderText = "試行実時間";
            WorkTime.Name = "WorkTime";
            WorkTime.ReadOnly = true;
            WorkTime.Width = 130;
            // 
            // WorkNumber
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleRight;
            WorkNumber.DefaultCellStyle = dataGridViewCellStyle4;
            WorkNumber.HeaderText = "試行回";
            WorkNumber.Name = "WorkNumber";
            WorkNumber.ReadOnly = true;
            WorkNumber.Width = 130;
            // 
            // WorkCount
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleRight;
            WorkCount.DefaultCellStyle = dataGridViewCellStyle5;
            WorkCount.HeaderText = "作業量";
            WorkCount.Name = "WorkCount";
            WorkCount.ReadOnly = true;
            // 
            // WorkCorrectRate
            // 
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleRight;
            WorkCorrectRate.DefaultCellStyle = dataGridViewCellStyle6;
            WorkCorrectRate.HeaderText = "正解率";
            WorkCorrectRate.Name = "WorkCorrectRate";
            WorkCorrectRate.ReadOnly = true;
            // 
            // CorrectRank
            // 
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleRight;
            CorrectRank.DefaultCellStyle = dataGridViewCellStyle7;
            CorrectRank.HeaderText = "正解率の順位";
            CorrectRank.Name = "CorrectRank";
            CorrectRank.ReadOnly = true;
            CorrectRank.Width = 130;
            // 
            // CorrectTime
            // 
            CorrectTime.HeaderText = "試行実時間";
            CorrectTime.Name = "CorrectTime";
            CorrectTime.ReadOnly = true;
            CorrectTime.Width = 130;
            // 
            // CorrectNumber
            // 
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleRight;
            CorrectNumber.DefaultCellStyle = dataGridViewCellStyle8;
            CorrectNumber.HeaderText = "試行回";
            CorrectNumber.Name = "CorrectNumber";
            CorrectNumber.ReadOnly = true;
            CorrectNumber.Width = 130;
            // 
            // CorrectCount
            // 
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleRight;
            CorrectCount.DefaultCellStyle = dataGridViewCellStyle9;
            CorrectCount.HeaderText = "作業量";
            CorrectCount.Name = "CorrectCount";
            CorrectCount.ReadOnly = true;
            // 
            // CorrectRate
            // 
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleRight;
            CorrectRate.DefaultCellStyle = dataGridViewCellStyle10;
            CorrectRate.HeaderText = "正解率";
            CorrectRate.Name = "CorrectRate";
            CorrectRate.ReadOnly = true;
            // 
            // Last3TimeCount
            // 
            Last3TimeCount.HeaderText = "最終３回分の作業量";
            Last3TimeCount.Name = "Last3TimeCount";
            Last3TimeCount.ReadOnly = true;
            Last3TimeCount.Width = 210;
            // 
            // Last3TimeCorrectRate
            // 
            Last3TimeCorrectRate.HeaderText = "最終３回分の正解率";
            Last3TimeCorrectRate.Name = "Last3TimeCorrectRate";
            Last3TimeCorrectRate.ReadOnly = true;
            Last3TimeCorrectRate.Width = 210;
            // 
            // BtnCancel
            // 
            BtnCancel.Location = new Point(432, 464);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(104, 32);
            BtnCancel.TabIndex = 3;
            BtnCancel.Text = "閉じる";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // BtnSave
            // 
            BtnSave.Location = new Point(24, 464);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(88, 32);
            BtnSave.TabIndex = 1;
            BtnSave.Text = "保存(S)";
            BtnSave.UseVisualStyleBackColor = true;
            BtnSave.Click += BtnSave_Click;
            // 
            // LblCourse
            // 
            LblCourse.Font = new Font("ＭＳ Ｐゴシック", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblCourse.Location = new Point(24, 8);
            LblCourse.Margin = new Padding(4, 0, 4, 0);
            LblCourse.Name = "LblCourse";
            LblCourse.Size = new Size(56, 24);
            LblCourse.TabIndex = 4;
            LblCourse.Text = "課題(K)";
            LblCourse.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblLevel
            // 
            LblLevel.Font = new Font("ＭＳ Ｐゴシック", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblLevel.Location = new Point(288, 8);
            LblLevel.Margin = new Padding(4, 0, 4, 0);
            LblLevel.Name = "LblLevel";
            LblLevel.Size = new Size(96, 24);
            LblLevel.TabIndex = 5;
            LblLevel.Text = "解析レベル(E)";
            LblLevel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblCnt2
            // 
            LblCnt2.Font = new Font("ＭＳ Ｐゴシック", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblCnt2.Location = new Point(520, 32);
            LblCnt2.Margin = new Padding(4, 0, 4, 0);
            LblCnt2.Name = "LblCnt2";
            LblCnt2.Size = new Size(29, 24);
            LblCnt2.TabIndex = 8;
            LblCnt2.Text = "件";
            LblCnt2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblCnt
            // 
            LblCnt.Font = new Font("ＭＳ Ｐゴシック", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblCnt.Location = new Point(464, 32);
            LblCnt.Margin = new Padding(4, 0, 4, 0);
            LblCnt.Name = "LblCnt";
            LblCnt.Size = new Size(56, 24);
            LblCnt.TabIndex = 7;
            LblCnt.Text = "99,999";
            LblCnt.TextAlign = ContentAlignment.MiddleRight;
            // 
            // CmbCourse
            // 
            CmbCourse.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbCourse.Font = new Font("ＭＳ ゴシック", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            CmbCourse.FormattingEnabled = true;
            CmbCourse.Items.AddRange(new object[] { "アンケート入力", "顧客伝票修正", "顧客伝票ミスチェック" });
            CmbCourse.Location = new Point(80, 8);
            CmbCourse.Name = "CmbCourse";
            CmbCourse.Size = new Size(192, 24);
            CmbCourse.TabIndex = 9;
            CmbCourse.SelectedIndexChanged += CmbCourse_SelectedIndexChanged;
            // 
            // CmbLevel
            // 
            CmbLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbLevel.Font = new Font("ＭＳ ゴシック", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            CmbLevel.FormattingEnabled = true;
            CmbLevel.Items.AddRange(new object[] { "枚数レベル", "項目レベル" });
            CmbLevel.Location = new Point(384, 8);
            CmbLevel.Name = "CmbLevel";
            CmbLevel.Size = new Size(120, 24);
            CmbLevel.TabIndex = 9;
            CmbLevel.SelectedIndexChanged += CmbLevel_SelectedIndexChanged;
            // 
            // LblComment
            // 
            LblComment.Font = new Font("ＭＳ Ｐゴシック", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblComment.Location = new Point(120, 472);
            LblComment.Margin = new Padding(4, 0, 4, 0);
            LblComment.Name = "LblComment";
            LblComment.Size = new Size(248, 24);
            LblComment.TabIndex = 4;
            LblComment.Text = "この画面は最大化やリサイズができます。";
            LblComment.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Frmユーザ比較
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(551, 504);
            Controls.Add(CmbLevel);
            Controls.Add(CmbCourse);
            Controls.Add(LblCnt);
            Controls.Add(LblCnt2);
            Controls.Add(LblLevel);
            Controls.Add(LblComment);
            Controls.Add(LblCourse);
            Controls.Add(BtnCancel);
            Controls.Add(BtnSave);
            Controls.Add(DgvComp);
            Name = "Frmユーザ比較";
            Text = "解析結果の出力[ユーザー比較]";
            FormClosing += Frmユーザ比較_FormClosing;
            Load += Frmユーザ比較_Load;
            Resize += Frmユーザ比較_Resize;
            ((System.ComponentModel.ISupportInitialize)DgvComp).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DgvComp;
        private Button BtnCancel;
        private Button BtnSave;
        private Label LblCourse;
        private Label LblLevel;
        private Label LblCnt2;
        private Label LblCnt;
        private ComboBox CmbCourse;
        private ComboBox CmbLevel;
        private Label LblComment;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn TotalRank;
        private DataGridViewTextBoxColumn NameKnj;
        private DataGridViewTextBoxColumn WorkRank;
        private DataGridViewTextBoxColumn WorkTime;
        private DataGridViewTextBoxColumn WorkNumber;
        private DataGridViewTextBoxColumn WorkCount;
        private DataGridViewTextBoxColumn WorkCorrectRate;
        private DataGridViewTextBoxColumn CorrectRank;
        private DataGridViewTextBoxColumn CorrectTime;
        private DataGridViewTextBoxColumn CorrectNumber;
        private DataGridViewTextBoxColumn CorrectCount;
        private DataGridViewTextBoxColumn CorrectRate;
        private DataGridViewTextBoxColumn Last3TimeCount;
        private DataGridViewTextBoxColumn Last3TimeCorrectRate;
    }
}
