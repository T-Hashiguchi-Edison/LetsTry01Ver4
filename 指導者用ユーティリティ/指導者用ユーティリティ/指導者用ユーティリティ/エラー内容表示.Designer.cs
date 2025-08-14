namespace 指導者用ユーティリティ
{
    partial class Frmエラー内容表示
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
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            BtnCancel = new Button();
            BtnCompair = new Button();
            LblCourse = new Label();
            LblLevel = new Label();
            LblCnt2 = new Label();
            LblCnt = new Label();
            LblComment = new Label();
            TxtUserName = new TextBox();
            TxtCourse = new TextBox();
            LblWorkTime = new Label();
            CmbErrorType2 = new ComboBox();
            DgvDetail = new DataGridView();
            WorkTimesT = new DataGridViewTextBoxColumn();
            WorkDateT = new DataGridViewTextBoxColumn();
            WorkTimeT = new DataGridViewTextBoxColumn();
            CardNo = new DataGridViewTextBoxColumn();
            ItemT = new DataGridViewTextBoxColumn();
            ErrorTypeT = new DataGridViewTextBoxColumn();
            CharTypeT = new DataGridViewTextBoxColumn();
            CorrectCharT = new DataGridViewTextBoxColumn();
            ErrorCharT = new DataGridViewTextBoxColumn();
            HdnWorkTime = new DataGridViewTextBoxColumn();
            TxtWorkTime = new TextBox();
            LblErrorType = new Label();
            CmbErrorType1 = new ComboBox();
            LblItem = new Label();
            CmbItemQ = new ComboBox();
            CmbItemC = new ComboBox();
            LblChar = new Label();
            CmbChar = new ComboBox();
            BtnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)DgvDetail).BeginInit();
            SuspendLayout();
            // 
            // BtnCancel
            // 
            BtnCancel.Location = new Point(624, 464);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(104, 32);
            BtnCancel.TabIndex = 18;
            BtnCancel.Text = "閉じる";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // BtnCompair
            // 
            BtnCompair.Location = new Point(472, 464);
            BtnCompair.Name = "BtnCompair";
            BtnCompair.Size = new Size(136, 32);
            BtnCompair.TabIndex = 17;
            BtnCompair.Text = "正解と入力の比較";
            BtnCompair.UseVisualStyleBackColor = true;
            BtnCompair.Click += BtnCompair_Click;
            // 
            // LblCourse
            // 
            LblCourse.Font = new Font("ＭＳ Ｐゴシック", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblCourse.Location = new Point(24, 8);
            LblCourse.Margin = new Padding(4, 0, 4, 0);
            LblCourse.Name = "LblCourse";
            LblCourse.Size = new Size(88, 24);
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
            LblLevel.Size = new Size(88, 24);
            LblLevel.TabIndex = 2;
            LblLevel.Text = "コース";
            LblLevel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblCnt2
            // 
            LblCnt2.Font = new Font("ＭＳ Ｐゴシック", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblCnt2.Location = new Point(712, 88);
            LblCnt2.Margin = new Padding(4, 0, 4, 0);
            LblCnt2.Name = "LblCnt2";
            LblCnt2.Size = new Size(29, 24);
            LblCnt2.TabIndex = 13;
            LblCnt2.Text = "件";
            LblCnt2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblCnt
            // 
            LblCnt.Font = new Font("ＭＳ Ｐゴシック", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblCnt.Location = new Point(656, 88);
            LblCnt.Margin = new Padding(4, 0, 4, 0);
            LblCnt.Name = "LblCnt";
            LblCnt.Size = new Size(56, 24);
            LblCnt.TabIndex = 12;
            LblCnt.Text = "99,999";
            LblCnt.TextAlign = ContentAlignment.MiddleRight;
            // 
            // LblComment
            // 
            LblComment.Font = new Font("ＭＳ Ｐゴシック", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblComment.Location = new Point(160, 472);
            LblComment.Margin = new Padding(4, 0, 4, 0);
            LblComment.Name = "LblComment";
            LblComment.Size = new Size(248, 24);
            LblComment.TabIndex = 16;
            LblComment.Text = "この画面は最大化やリサイズができます。";
            LblComment.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // TxtUserName
            // 
            TxtUserName.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            TxtUserName.ImeMode = ImeMode.On;
            TxtUserName.Location = new Point(112, 8);
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
            TxtCourse.Location = new Point(112, 32);
            TxtCourse.Margin = new Padding(4);
            TxtCourse.MaxLength = 30;
            TxtCourse.Name = "TxtCourse";
            TxtCourse.ReadOnly = true;
            TxtCourse.Size = new Size(592, 26);
            TxtCourse.TabIndex = 3;
            TxtCourse.TabStop = false;
            TxtCourse.Text = "顧客伝票ミスチェック　60分換算値　実力テスト／レベルアップトレーニング";
            // 
            // LblWorkTime
            // 
            LblWorkTime.Font = new Font("ＭＳ Ｐゴシック", 9.75F);
            LblWorkTime.Location = new Point(24, 56);
            LblWorkTime.Name = "LblWorkTime";
            LblWorkTime.Size = new Size(88, 24);
            LblWorkTime.TabIndex = 4;
            LblWorkTime.Text = "経過時間";
            LblWorkTime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CmbErrorType2
            // 
            CmbErrorType2.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbErrorType2.Font = new Font("ＭＳ ゴシック", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            CmbErrorType2.FormattingEnabled = true;
            CmbErrorType2.Items.AddRange(new object[] { "全てのエラー", "見落とし", "過剰チェック" });
            CmbErrorType2.Location = new Point(112, 80);
            CmbErrorType2.Name = "CmbErrorType2";
            CmbErrorType2.Size = new Size(120, 24);
            CmbErrorType2.TabIndex = 7;
            CmbErrorType2.SelectedIndexChanged += Cmb_SelectedIndexChanged;
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
            DgvDetail.Columns.AddRange(new DataGridViewColumn[] { WorkTimesT, WorkDateT, WorkTimeT, CardNo, ItemT, ErrorTypeT, CharTypeT, CorrectCharT, ErrorCharT, HdnWorkTime });
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = SystemColors.Window;
            dataGridViewCellStyle10.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dataGridViewCellStyle10.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.False;
            DgvDetail.DefaultCellStyle = dataGridViewCellStyle10;
            DgvDetail.Location = new Point(16, 112);
            DgvDetail.MultiSelect = false;
            DgvDetail.Name = "DgvDetail";
            DgvDetail.ReadOnly = true;
            DgvDetail.RowHeadersVisible = false;
            DgvDetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvDetail.Size = new Size(720, 344);
            DgvDetail.TabIndex = 14;
            DgvDetail.TabStop = false;
            DgvDetail.CellClick += DgvDetail_CellClick;
            DgvDetail.CellDoubleClick += DgvDetail_CellDoubleClick;
            DgvDetail.KeyDown += DgvDetail_KeyDown;
            // 
            // WorkTimesT
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            WorkTimesT.DefaultCellStyle = dataGridViewCellStyle2;
            WorkTimesT.HeaderText = "試行回";
            WorkTimesT.Name = "WorkTimesT";
            WorkTimesT.ReadOnly = true;
            WorkTimesT.Width = 80;
            // 
            // WorkDateT
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            WorkDateT.DefaultCellStyle = dataGridViewCellStyle3;
            WorkDateT.HeaderText = "実施日";
            WorkDateT.Name = "WorkDateT";
            WorkDateT.ReadOnly = true;
            WorkDateT.Width = 180;
            // 
            // WorkTimeT
            // 
            WorkTimeT.HeaderText = "経過時間";
            WorkTimeT.Name = "WorkTimeT";
            WorkTimeT.ReadOnly = true;
            WorkTimeT.Width = 160;
            // 
            // CardNo
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            CardNo.DefaultCellStyle = dataGridViewCellStyle4;
            CardNo.HeaderText = "No";
            CardNo.Name = "CardNo";
            CardNo.ReadOnly = true;
            CardNo.Width = 90;
            // 
            // ItemT
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ItemT.DefaultCellStyle = dataGridViewCellStyle5;
            ItemT.HeaderText = "項目名";
            ItemT.Name = "ItemT";
            ItemT.ReadOnly = true;
            ItemT.Width = 130;
            // 
            // ErrorTypeT
            // 
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ErrorTypeT.DefaultCellStyle = dataGridViewCellStyle6;
            ErrorTypeT.HeaderText = "エラー種別";
            ErrorTypeT.Name = "ErrorTypeT";
            ErrorTypeT.ReadOnly = true;
            ErrorTypeT.Width = 90;
            // 
            // CharTypeT
            // 
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            CharTypeT.DefaultCellStyle = dataGridViewCellStyle7;
            CharTypeT.HeaderText = "文字種別";
            CharTypeT.Name = "CharTypeT";
            CharTypeT.ReadOnly = true;
            CharTypeT.Width = 110;
            // 
            // CorrectCharT
            // 
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            CorrectCharT.DefaultCellStyle = dataGridViewCellStyle8;
            CorrectCharT.HeaderText = "正解文字";
            CorrectCharT.Name = "CorrectCharT";
            CorrectCharT.ReadOnly = true;
            CorrectCharT.Width = 90;
            // 
            // ErrorCharT
            // 
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ErrorCharT.DefaultCellStyle = dataGridViewCellStyle9;
            ErrorCharT.HeaderText = "誤り文字";
            ErrorCharT.Name = "ErrorCharT";
            ErrorCharT.ReadOnly = true;
            ErrorCharT.Width = 90;
            // 
            // HdnWorkTime
            // 
            HdnWorkTime.HeaderText = "経過時間";
            HdnWorkTime.Name = "HdnWorkTime";
            HdnWorkTime.ReadOnly = true;
            HdnWorkTime.Visible = false;
            // 
            // TxtWorkTime
            // 
            TxtWorkTime.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            TxtWorkTime.ImeMode = ImeMode.On;
            TxtWorkTime.Location = new Point(112, 56);
            TxtWorkTime.Margin = new Padding(4);
            TxtWorkTime.MaxLength = 30;
            TxtWorkTime.Name = "TxtWorkTime";
            TxtWorkTime.ReadOnly = true;
            TxtWorkTime.Size = new Size(152, 26);
            TxtWorkTime.TabIndex = 5;
            TxtWorkTime.TabStop = false;
            TxtWorkTime.Text = "15分～30分未満";
            // 
            // LblErrorType
            // 
            LblErrorType.Font = new Font("ＭＳ Ｐゴシック", 9.75F);
            LblErrorType.Location = new Point(24, 80);
            LblErrorType.Name = "LblErrorType";
            LblErrorType.Size = new Size(88, 24);
            LblErrorType.TabIndex = 6;
            LblErrorType.Text = "エラー種別(E)";
            LblErrorType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CmbErrorType1
            // 
            CmbErrorType1.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbErrorType1.Font = new Font("ＭＳ ゴシック", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            CmbErrorType1.FormattingEnabled = true;
            CmbErrorType1.Items.AddRange(new object[] { "全てのエラー", "入力エラー", "見落とし", "過剰修正" });
            CmbErrorType1.Location = new Point(112, 80);
            CmbErrorType1.Name = "CmbErrorType1";
            CmbErrorType1.Size = new Size(120, 24);
            CmbErrorType1.TabIndex = 7;
            CmbErrorType1.SelectedIndexChanged += Cmb_SelectedIndexChanged;
            // 
            // LblItem
            // 
            LblItem.Font = new Font("ＭＳ Ｐゴシック", 9.75F);
            LblItem.Location = new Point(232, 80);
            LblItem.Name = "LblItem";
            LblItem.Size = new Size(64, 24);
            LblItem.TabIndex = 8;
            LblItem.Text = "項目名(I)";
            LblItem.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CmbItemQ
            // 
            CmbItemQ.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbItemQ.Font = new Font("ＭＳ ゴシック", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            CmbItemQ.FormattingEnabled = true;
            CmbItemQ.Items.AddRange(new object[] { "全て", "フリガナ", "氏名", "郵便番号", "住所", "電話番号", "メールアドレス", "問１", "問２", "問３" });
            CmbItemQ.Location = new Point(296, 80);
            CmbItemQ.Name = "CmbItemQ";
            CmbItemQ.Size = new Size(144, 24);
            CmbItemQ.TabIndex = 9;
            CmbItemQ.SelectedIndexChanged += Cmb_SelectedIndexChanged;
            // 
            // CmbItemC
            // 
            CmbItemC.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbItemC.Font = new Font("ＭＳ ゴシック", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            CmbItemC.FormattingEnabled = true;
            CmbItemC.Items.AddRange(new object[] { "全て", "顧客コード", "商品コード", "電話番号", "メールアドレス" });
            CmbItemC.Location = new Point(296, 80);
            CmbItemC.Name = "CmbItemC";
            CmbItemC.Size = new Size(144, 24);
            CmbItemC.TabIndex = 9;
            CmbItemC.SelectedIndexChanged += Cmb_SelectedIndexChanged;
            // 
            // LblChar
            // 
            LblChar.Font = new Font("ＭＳ Ｐゴシック", 9.75F);
            LblChar.Location = new Point(440, 80);
            LblChar.Name = "LblChar";
            LblChar.Size = new Size(64, 24);
            LblChar.TabIndex = 10;
            LblChar.Text = "文字種(M)";
            LblChar.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CmbChar
            // 
            CmbChar.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbChar.Font = new Font("ＭＳ ゴシック", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            CmbChar.FormattingEnabled = true;
            CmbChar.Items.AddRange(new object[] { "全て", "カナ", "漢字", "数字", "英大文字", "英小文字", "記号" });
            CmbChar.Location = new Point(504, 80);
            CmbChar.Name = "CmbChar";
            CmbChar.Size = new Size(104, 24);
            CmbChar.TabIndex = 11;
            CmbChar.SelectedIndexChanged += Cmb_SelectedIndexChanged;
            // 
            // BtnSave
            // 
            BtnSave.Location = new Point(16, 464);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(136, 32);
            BtnSave.TabIndex = 15;
            BtnSave.Text = "ファイル保存(A)";
            BtnSave.UseVisualStyleBackColor = true;
            BtnSave.Click += BtnSave_Click;
            // 
            // Frmエラー内容表示
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(746, 504);
            Controls.Add(CmbChar);
            Controls.Add(DgvDetail);
            Controls.Add(LblCnt);
            Controls.Add(LblChar);
            Controls.Add(LblCnt2);
            Controls.Add(LblItem);
            Controls.Add(LblErrorType);
            Controls.Add(LblWorkTime);
            Controls.Add(TxtCourse);
            Controls.Add(TxtUserName);
            Controls.Add(LblLevel);
            Controls.Add(LblCourse);
            Controls.Add(BtnCancel);
            Controls.Add(BtnSave);
            Controls.Add(BtnCompair);
            Controls.Add(TxtWorkTime);
            Controls.Add(LblComment);
            Controls.Add(CmbItemC);
            Controls.Add(CmbItemQ);
            Controls.Add(CmbErrorType2);
            Controls.Add(CmbErrorType1);
            Name = "Frmエラー内容表示";
            Text = "解析結果の出力[エラー内容の表示]";
            FormClosing += Frm解析結果出力_FormClosing;
            Load += Frm解析結果出力_Load;
            Resize += Frm解析結果出力_Resize;
            ((System.ComponentModel.ISupportInitialize)DgvDetail).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button BtnCancel;
        private Button BtnCompair;
        private Label LblCourse;
        private Label LblLevel;
        private Label LblCnt2;
        private Label LblCnt;
        private Label LblComment;
        private TextBox TxtUserName;
        private TextBox TxtCourse;
        private Label LblWorkTime;
        private ComboBox CmbErrorType2;
        private DataGridView DgvDetail;
        private TextBox TxtWorkTime;
        private Label LblErrorType;
        private ComboBox CmbErrorType1;
        private Label LblItem;
        private ComboBox CmbItemQ;
        private ComboBox CmbItemC;
        private Label LblChar;
        private ComboBox CmbChar;
        private Button BtnSave;
        private DataGridViewTextBoxColumn WorkTimesT;
        private DataGridViewTextBoxColumn WorkDateT;
        private DataGridViewTextBoxColumn WorkTimeT;
        private DataGridViewTextBoxColumn CardNo;
        private DataGridViewTextBoxColumn ItemT;
        private DataGridViewTextBoxColumn ErrorTypeT;
        private DataGridViewTextBoxColumn CharTypeT;
        private DataGridViewTextBoxColumn CorrectCharT;
        private DataGridViewTextBoxColumn ErrorCharT;
        private DataGridViewTextBoxColumn HdnWorkTime;
    }
}
