namespace 指導者用ユーティリティ
{
    partial class Frm試行結果一覧
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
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
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
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle19 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
            DgvDetailQ = new DataGridView();
            MaisuQ = new DataGridViewTextBoxColumn();
            CardNoQ = new DataGridViewTextBoxColumn();
            KanaSimeiQ = new DataGridViewTextBoxColumn();
            SimeiQ = new DataGridViewTextBoxColumn();
            ZipCodeQ = new DataGridViewTextBoxColumn();
            AddressQ = new DataGridViewTextBoxColumn();
            TelNoQ = new DataGridViewTextBoxColumn();
            MailAddressQ = new DataGridViewTextBoxColumn();
            Question1Q = new DataGridViewTextBoxColumn();
            Question2Q = new DataGridViewTextBoxColumn();
            Question3Q = new DataGridViewTextBoxColumn();
            WorkTimeQ = new DataGridViewTextBoxColumn();
            BtnCancel = new Button();
            BtnInput = new Button();
            LblCourse = new Label();
            LblLevel = new Label();
            LblCnt2 = new Label();
            LblCnt = new Label();
            LblComment = new Label();
            TxtUserName = new TextBox();
            TxtCourse = new TextBox();
            DgvDetailC = new DataGridView();
            MaisuC = new DataGridViewTextBoxColumn();
            CardNoC = new DataGridViewTextBoxColumn();
            CustCdC = new DataGridViewTextBoxColumn();
            ItemCdC = new DataGridViewTextBoxColumn();
            TelNoC = new DataGridViewTextBoxColumn();
            MailAddressC = new DataGridViewTextBoxColumn();
            WorkTimeC = new DataGridViewTextBoxColumn();
            NudID = new NumericUpDown();
            LblMaisu2 = new Label();
            LblMaisu1 = new Label();
            BtnSelect = new Button();
            ((System.ComponentModel.ISupportInitialize)DgvDetailQ).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DgvDetailC).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NudID).BeginInit();
            SuspendLayout();
            // 
            // DgvDetailQ
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DgvDetailQ.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DgvDetailQ.ColumnHeadersHeight = 29;
            DgvDetailQ.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            DgvDetailQ.Columns.AddRange(new DataGridViewColumn[] { MaisuQ, CardNoQ, KanaSimeiQ, SimeiQ, ZipCodeQ, AddressQ, TelNoQ, MailAddressQ, Question1Q, Question2Q, Question3Q, WorkTimeQ });
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = SystemColors.Window;
            dataGridViewCellStyle12.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dataGridViewCellStyle12.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.False;
            DgvDetailQ.DefaultCellStyle = dataGridViewCellStyle12;
            DgvDetailQ.Location = new Point(24, 96);
            DgvDetailQ.MultiSelect = false;
            DgvDetailQ.Name = "DgvDetailQ";
            DgvDetailQ.ReadOnly = true;
            DgvDetailQ.RowHeadersVisible = false;
            DgvDetailQ.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvDetailQ.Size = new Size(704, 360);
            DgvDetailQ.TabIndex = 10;
            DgvDetailQ.CellClick += DgvDetailQ_CellClick;
            DgvDetailQ.CellDoubleClick += DgvDetailQ_CellDoubleClick;
            DgvDetailQ.KeyDown += DgvDetailQ_KeyDown;
            // 
            // MaisuQ
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            MaisuQ.DefaultCellStyle = dataGridViewCellStyle2;
            MaisuQ.HeaderText = "枚数";
            MaisuQ.Name = "MaisuQ";
            MaisuQ.ReadOnly = true;
            MaisuQ.Width = 70;
            // 
            // CardNoQ
            // 
            CardNoQ.HeaderText = "カードNo";
            CardNoQ.MaxInputLength = 100;
            CardNoQ.Name = "CardNoQ";
            CardNoQ.ReadOnly = true;
            CardNoQ.Width = 90;
            // 
            // KanaSimeiQ
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            KanaSimeiQ.DefaultCellStyle = dataGridViewCellStyle3;
            KanaSimeiQ.HeaderText = "フリガナ";
            KanaSimeiQ.Name = "KanaSimeiQ";
            KanaSimeiQ.ReadOnly = true;
            KanaSimeiQ.Width = 90;
            // 
            // SimeiQ
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            SimeiQ.DefaultCellStyle = dataGridViewCellStyle4;
            SimeiQ.HeaderText = "氏名";
            SimeiQ.Name = "SimeiQ";
            SimeiQ.ReadOnly = true;
            SimeiQ.Width = 90;
            // 
            // ZipCodeQ
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ZipCodeQ.DefaultCellStyle = dataGridViewCellStyle5;
            ZipCodeQ.HeaderText = "郵便番号";
            ZipCodeQ.Name = "ZipCodeQ";
            ZipCodeQ.ReadOnly = true;
            ZipCodeQ.Width = 90;
            // 
            // AddressQ
            // 
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            AddressQ.DefaultCellStyle = dataGridViewCellStyle6;
            AddressQ.HeaderText = "住所";
            AddressQ.Name = "AddressQ";
            AddressQ.ReadOnly = true;
            AddressQ.Width = 90;
            // 
            // TelNoQ
            // 
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            TelNoQ.DefaultCellStyle = dataGridViewCellStyle7;
            TelNoQ.HeaderText = "電話番号";
            TelNoQ.Name = "TelNoQ";
            TelNoQ.ReadOnly = true;
            TelNoQ.Width = 90;
            // 
            // MailAddressQ
            // 
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            MailAddressQ.DefaultCellStyle = dataGridViewCellStyle8;
            MailAddressQ.HeaderText = "メールアドレス";
            MailAddressQ.Name = "MailAddressQ";
            MailAddressQ.ReadOnly = true;
            MailAddressQ.Width = 90;
            // 
            // Question1Q
            // 
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Question1Q.DefaultCellStyle = dataGridViewCellStyle9;
            Question1Q.HeaderText = "問１";
            Question1Q.Name = "Question1Q";
            Question1Q.ReadOnly = true;
            Question1Q.Width = 90;
            // 
            // Question2Q
            // 
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Question2Q.DefaultCellStyle = dataGridViewCellStyle10;
            Question2Q.HeaderText = "問２";
            Question2Q.Name = "Question2Q";
            Question2Q.ReadOnly = true;
            Question2Q.Width = 90;
            // 
            // Question3Q
            // 
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Question3Q.DefaultCellStyle = dataGridViewCellStyle11;
            Question3Q.HeaderText = "問３";
            Question3Q.Name = "Question3Q";
            Question3Q.ReadOnly = true;
            // 
            // WorkTimeQ
            // 
            WorkTimeQ.HeaderText = "所要時間";
            WorkTimeQ.Name = "WorkTimeQ";
            WorkTimeQ.ReadOnly = true;
            WorkTimeQ.Width = 110;
            // 
            // BtnCancel
            // 
            BtnCancel.Location = new Point(624, 464);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(104, 32);
            BtnCancel.TabIndex = 14;
            BtnCancel.Text = "閉じる";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // BtnInput
            // 
            BtnInput.Location = new Point(472, 464);
            BtnInput.Name = "BtnInput";
            BtnInput.Size = new Size(136, 32);
            BtnInput.TabIndex = 13;
            BtnInput.Text = "正解と入力の比較";
            BtnInput.UseVisualStyleBackColor = true;
            BtnInput.Click += BtnInput_Click;
            // 
            // LblCourse
            // 
            LblCourse.Font = new Font("ＭＳ Ｐゴシック", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblCourse.Location = new Point(24, 8);
            LblCourse.Margin = new Padding(4, 0, 4, 0);
            LblCourse.Name = "LblCourse";
            LblCourse.Size = new Size(80, 24);
            LblCourse.TabIndex = 0;
            LblCourse.Text = "ユーザー名";
            LblCourse.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblLevel
            // 
            LblLevel.Font = new Font("ＭＳ Ｐゴシック", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblLevel.Location = new Point(24, 32);
            LblLevel.Margin = new Padding(4, 0, 4, 0);
            LblLevel.Name = "LblLevel";
            LblLevel.Size = new Size(80, 24);
            LblLevel.TabIndex = 2;
            LblLevel.Text = "コース";
            LblLevel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblCnt2
            // 
            LblCnt2.Font = new Font("ＭＳ Ｐゴシック", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblCnt2.Location = new Point(712, 72);
            LblCnt2.Margin = new Padding(4, 0, 4, 0);
            LblCnt2.Name = "LblCnt2";
            LblCnt2.Size = new Size(29, 24);
            LblCnt2.TabIndex = 9;
            LblCnt2.Text = "件";
            LblCnt2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblCnt
            // 
            LblCnt.Font = new Font("ＭＳ Ｐゴシック", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblCnt.Location = new Point(656, 72);
            LblCnt.Margin = new Padding(4, 0, 4, 0);
            LblCnt.Name = "LblCnt";
            LblCnt.Size = new Size(56, 24);
            LblCnt.TabIndex = 8;
            LblCnt.Text = "99,999";
            LblCnt.TextAlign = ContentAlignment.MiddleRight;
            // 
            // LblComment
            // 
            LblComment.Font = new Font("ＭＳ Ｐゴシック", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblComment.Location = new Point(24, 472);
            LblComment.Margin = new Padding(4, 0, 4, 0);
            LblComment.Name = "LblComment";
            LblComment.Size = new Size(248, 24);
            LblComment.TabIndex = 12;
            LblComment.Text = "この画面は最大化やリサイズができます。";
            LblComment.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // TxtUserName
            // 
            TxtUserName.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            TxtUserName.ImeMode = ImeMode.On;
            TxtUserName.Location = new Point(104, 8);
            TxtUserName.Margin = new Padding(4);
            TxtUserName.MaxLength = 30;
            TxtUserName.Name = "TxtUserName";
            TxtUserName.ReadOnly = true;
            TxtUserName.Size = new Size(592, 26);
            TxtUserName.TabIndex = 1;
            TxtUserName.TabStop = false;
            TxtUserName.Text = "てすと　たろう";
            // 
            // TxtCourse
            // 
            TxtCourse.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            TxtCourse.ImeMode = ImeMode.On;
            TxtCourse.Location = new Point(104, 32);
            TxtCourse.Margin = new Padding(4);
            TxtCourse.MaxLength = 30;
            TxtCourse.Name = "TxtCourse";
            TxtCourse.ReadOnly = true;
            TxtCourse.Size = new Size(592, 26);
            TxtCourse.TabIndex = 3;
            TxtCourse.TabStop = false;
            TxtCourse.Text = "顧客伝票ミスチェック　60分換算値　実力テスト／レベルアップトレーニング";
            // 
            // DgvDetailC
            // 
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = SystemColors.Control;
            dataGridViewCellStyle13.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dataGridViewCellStyle13.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = DataGridViewTriState.True;
            DgvDetailC.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            DgvDetailC.ColumnHeadersHeight = 29;
            DgvDetailC.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            DgvDetailC.Columns.AddRange(new DataGridViewColumn[] { MaisuC, CardNoC, CustCdC, ItemCdC, TelNoC, MailAddressC, WorkTimeC });
            dataGridViewCellStyle19.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = SystemColors.Window;
            dataGridViewCellStyle19.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dataGridViewCellStyle19.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle19.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = DataGridViewTriState.False;
            DgvDetailC.DefaultCellStyle = dataGridViewCellStyle19;
            DgvDetailC.Location = new Point(24, 96);
            DgvDetailC.MultiSelect = false;
            DgvDetailC.Name = "DgvDetailC";
            DgvDetailC.ReadOnly = true;
            DgvDetailC.RowHeadersVisible = false;
            DgvDetailC.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvDetailC.Size = new Size(704, 360);
            DgvDetailC.TabIndex = 11;
            DgvDetailC.CellClick += DgvDetailC_CellClick;
            DgvDetailC.CellDoubleClick += DgvDetailC_CellDoubleClick;
            DgvDetailC.KeyDown += DgvDetailC_KeyDown;
            // 
            // MaisuC
            // 
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleRight;
            MaisuC.DefaultCellStyle = dataGridViewCellStyle14;
            MaisuC.HeaderText = "枚数";
            MaisuC.Name = "MaisuC";
            MaisuC.ReadOnly = true;
            MaisuC.Width = 70;
            // 
            // CardNoC
            // 
            CardNoC.HeaderText = "カードNo";
            CardNoC.Name = "CardNoC";
            CardNoC.ReadOnly = true;
            CardNoC.Width = 90;
            // 
            // CustCdC
            // 
            dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleCenter;
            CustCdC.DefaultCellStyle = dataGridViewCellStyle15;
            CustCdC.HeaderText = "顧客コード";
            CustCdC.MaxInputLength = 90;
            CustCdC.Name = "CustCdC";
            CustCdC.ReadOnly = true;
            CustCdC.Width = 90;
            // 
            // ItemCdC
            // 
            dataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ItemCdC.DefaultCellStyle = dataGridViewCellStyle16;
            ItemCdC.HeaderText = "商品コード";
            ItemCdC.Name = "ItemCdC";
            ItemCdC.ReadOnly = true;
            ItemCdC.Width = 90;
            // 
            // TelNoC
            // 
            dataGridViewCellStyle17.Alignment = DataGridViewContentAlignment.MiddleCenter;
            TelNoC.DefaultCellStyle = dataGridViewCellStyle17;
            TelNoC.HeaderText = "電話番号";
            TelNoC.Name = "TelNoC";
            TelNoC.ReadOnly = true;
            TelNoC.Width = 90;
            // 
            // MailAddressC
            // 
            dataGridViewCellStyle18.Alignment = DataGridViewContentAlignment.MiddleCenter;
            MailAddressC.DefaultCellStyle = dataGridViewCellStyle18;
            MailAddressC.HeaderText = "メールアドレス";
            MailAddressC.Name = "MailAddressC";
            MailAddressC.ReadOnly = true;
            MailAddressC.Width = 90;
            // 
            // WorkTimeC
            // 
            WorkTimeC.HeaderText = "所要時間";
            WorkTimeC.Name = "WorkTimeC";
            WorkTimeC.ReadOnly = true;
            WorkTimeC.Width = 110;
            // 
            // NudID
            // 
            NudID.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            NudID.Location = new Point(64, 64);
            NudID.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            NudID.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NudID.Name = "NudID";
            NudID.Size = new Size(64, 26);
            NudID.TabIndex = 5;
            NudID.TextAlign = HorizontalAlignment.Right;
            NudID.Value = new decimal(new int[] { 999, 0, 0, 0 });
            // 
            // LblMaisu2
            // 
            LblMaisu2.Font = new Font("ＭＳ Ｐゴシック", 9.75F);
            LblMaisu2.Location = new Point(128, 64);
            LblMaisu2.Name = "LblMaisu2";
            LblMaisu2.Size = new Size(40, 24);
            LblMaisu2.TabIndex = 6;
            LblMaisu2.Text = "枚目";
            LblMaisu2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblMaisu1
            // 
            LblMaisu1.Font = new Font("ＭＳ Ｐゴシック", 9.75F);
            LblMaisu1.Location = new Point(32, 64);
            LblMaisu1.Name = "LblMaisu1";
            LblMaisu1.Size = new Size(40, 24);
            LblMaisu1.TabIndex = 4;
            LblMaisu1.Text = "枚数";
            LblMaisu1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // BtnSelect
            // 
            BtnSelect.Location = new Point(168, 64);
            BtnSelect.Name = "BtnSelect";
            BtnSelect.Size = new Size(80, 24);
            BtnSelect.TabIndex = 7;
            BtnSelect.Text = "選択(S)";
            BtnSelect.UseVisualStyleBackColor = true;
            // 
            // Frm試行結果一覧
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(746, 504);
            Controls.Add(NudID);
            Controls.Add(LblMaisu2);
            Controls.Add(LblMaisu1);
            Controls.Add(BtnSelect);
            Controls.Add(TxtCourse);
            Controls.Add(TxtUserName);
            Controls.Add(LblCnt);
            Controls.Add(LblCnt2);
            Controls.Add(LblLevel);
            Controls.Add(LblComment);
            Controls.Add(LblCourse);
            Controls.Add(BtnCancel);
            Controls.Add(BtnInput);
            Controls.Add(DgvDetailC);
            Controls.Add(DgvDetailQ);
            Name = "Frm試行結果一覧";
            Text = "解析結果の出力[試行結果一覧]";
            FormClosing += Frm試行結果一覧_FormClosing;
            Load += Frm試行結果一覧_Load;
            Resize += Frm試行結果一覧_Resize;
            ((System.ComponentModel.ISupportInitialize)DgvDetailQ).EndInit();
            ((System.ComponentModel.ISupportInitialize)DgvDetailC).EndInit();
            ((System.ComponentModel.ISupportInitialize)NudID).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DgvDetailQ;
        private Button BtnCancel;
        private Button BtnInput;
        private Label LblCourse;
        private Label LblLevel;
        private Label LblCnt2;
        private Label LblCnt;
        private Label LblComment;
        private TextBox TxtUserName;
        private TextBox TxtCourse;
        private DataGridView DgvDetailC;
        private NumericUpDown NudID;
        private Label LblMaisu2;
        private Label LblMaisu1;
        private Button BtnSelect;
        private DataGridViewTextBoxColumn MaisuQ;
        private DataGridViewTextBoxColumn CardNoQ;
        private DataGridViewTextBoxColumn KanaSimeiQ;
        private DataGridViewTextBoxColumn SimeiQ;
        private DataGridViewTextBoxColumn ZipCodeQ;
        private DataGridViewTextBoxColumn AddressQ;
        private DataGridViewTextBoxColumn TelNoQ;
        private DataGridViewTextBoxColumn MailAddressQ;
        private DataGridViewTextBoxColumn Question1Q;
        private DataGridViewTextBoxColumn Question2Q;
        private DataGridViewTextBoxColumn Question3Q;
        private DataGridViewTextBoxColumn WorkTimeQ;
        private DataGridViewTextBoxColumn MaisuC;
        private DataGridViewTextBoxColumn CardNoC;
        private DataGridViewTextBoxColumn CustCdC;
        private DataGridViewTextBoxColumn ItemCdC;
        private DataGridViewTextBoxColumn TelNoC;
        private DataGridViewTextBoxColumn MailAddressC;
        private DataGridViewTextBoxColumn WorkTimeC;
    }
}
