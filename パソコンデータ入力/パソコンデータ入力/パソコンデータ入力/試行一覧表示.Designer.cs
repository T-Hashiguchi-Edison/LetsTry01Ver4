namespace パソコンデータ入力
{
    partial class Frm試行一覧表示
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
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
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
            DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle25 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle19 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle20 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle21 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle22 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle23 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle24 = new DataGridViewCellStyle();
            BtnOK = new Button();
            LblMode = new Label();
            LblMaisu1 = new Label();
            TxtMode = new TextBox();
            LblUSerName = new Label();
            TxtUserName = new TextBox();
            NudID = new NumericUpDown();
            LblMaisu2 = new Label();
            BtnSelect = new Button();
            BtnNext = new Button();
            DgvModeQ = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            CardID = new DataGridViewTextBoxColumn();
            SimeiKana = new DataGridViewTextBoxColumn();
            NameKanji = new DataGridViewTextBoxColumn();
            ZipCode = new DataGridViewTextBoxColumn();
            Address = new DataGridViewTextBoxColumn();
            TelNo = new DataGridViewTextBoxColumn();
            MailAddress = new DataGridViewTextBoxColumn();
            Q1Answer = new DataGridViewTextBoxColumn();
            Q2Answer = new DataGridViewTextBoxColumn();
            Q3Answer = new DataGridViewTextBoxColumn();
            ElapsedTime = new DataGridViewTextBoxColumn();
            CheckCnt = new DataGridViewTextBoxColumn();
            DgvModeC = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn12 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn13 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)NudID).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DgvModeQ).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DgvModeC).BeginInit();
            SuspendLayout();
            // 
            // BtnOK
            // 
            BtnOK.Location = new Point(712, 544);
            BtnOK.Name = "BtnOK";
            BtnOK.Size = new Size(184, 32);
            BtnOK.TabIndex = 6;
            BtnOK.Text = "メニューへ戻る(N)";
            BtnOK.UseVisualStyleBackColor = true;
            BtnOK.Click += BtnOK_Click;
            // 
            // LblMode
            // 
            LblMode.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblMode.Location = new Point(8, 8);
            LblMode.Name = "LblMode";
            LblMode.Size = new Size(80, 24);
            LblMode.TabIndex = 0;
            LblMode.Text = "課題名";
            LblMode.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblMaisu1
            // 
            LblMaisu1.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblMaisu1.Location = new Point(24, 48);
            LblMaisu1.Name = "LblMaisu1";
            LblMaisu1.Size = new Size(56, 32);
            LblMaisu1.TabIndex = 7;
            LblMaisu1.Text = "枚数";
            LblMaisu1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // TxtMode
            // 
            TxtMode.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            TxtMode.ImeMode = ImeMode.Off;
            TxtMode.Location = new Point(88, 8);
            TxtMode.MaxLength = 8;
            TxtMode.Name = "TxtMode";
            TxtMode.ReadOnly = true;
            TxtMode.Size = new Size(176, 26);
            TxtMode.TabIndex = 1;
            TxtMode.TabStop = false;
            TxtMode.Text = "顧客伝票ミスチェック";
            // 
            // LblUSerName
            // 
            LblUSerName.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblUSerName.Location = new Point(280, 8);
            LblUSerName.Name = "LblUSerName";
            LblUSerName.Size = new Size(112, 24);
            LblUSerName.TabIndex = 2;
            LblUSerName.Text = "ユーザー名";
            LblUSerName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // TxtUserName
            // 
            TxtUserName.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            TxtUserName.ImeMode = ImeMode.Off;
            TxtUserName.Location = new Point(392, 8);
            TxtUserName.MaxLength = 8;
            TxtUserName.Name = "TxtUserName";
            TxtUserName.ReadOnly = true;
            TxtUserName.Size = new Size(280, 26);
            TxtUserName.TabIndex = 3;
            TxtUserName.TabStop = false;
            TxtUserName.Text = "あいうえお　かきくけこ";
            // 
            // NudID
            // 
            NudID.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            NudID.Location = new Point(80, 51);
            NudID.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            NudID.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NudID.Name = "NudID";
            NudID.Size = new Size(64, 26);
            NudID.TabIndex = 8;
            NudID.TextAlign = HorizontalAlignment.Right;
            NudID.Value = new decimal(new int[] { 999, 0, 0, 0 });
            // 
            // LblMaisu2
            // 
            LblMaisu2.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblMaisu2.Location = new Point(144, 48);
            LblMaisu2.Name = "LblMaisu2";
            LblMaisu2.Size = new Size(56, 32);
            LblMaisu2.TabIndex = 9;
            LblMaisu2.Text = "枚目";
            LblMaisu2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // BtnSelect
            // 
            BtnSelect.Location = new Point(200, 48);
            BtnSelect.Name = "BtnSelect";
            BtnSelect.Size = new Size(80, 32);
            BtnSelect.TabIndex = 10;
            BtnSelect.Text = "選択(S)";
            BtnSelect.UseVisualStyleBackColor = true;
            BtnSelect.Click += BtnSelect_Click;
            // 
            // BtnNext
            // 
            BtnNext.Location = new Point(520, 544);
            BtnNext.Name = "BtnNext";
            BtnNext.Size = new Size(184, 32);
            BtnNext.TabIndex = 5;
            BtnNext.Text = "解答・入力値の表示(K)";
            BtnNext.UseVisualStyleBackColor = true;
            BtnNext.Click += BtnNext_Click;
            // 
            // DgvModeQ
            // 
            DgvModeQ.AllowUserToAddRows = false;
            DgvModeQ.AllowUserToDeleteRows = false;
            DgvModeQ.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("ＭＳ Ｐゴシック", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DgvModeQ.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DgvModeQ.ColumnHeadersHeight = 20;
            DgvModeQ.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            DgvModeQ.Columns.AddRange(new DataGridViewColumn[] { ID, CardID, SimeiKana, NameKanji, ZipCode, Address, TelNo, MailAddress, Q1Answer, Q2Answer, Q3Answer, ElapsedTime, CheckCnt });
            dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = SystemColors.Window;
            dataGridViewCellStyle15.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dataGridViewCellStyle15.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = DataGridViewTriState.False;
            DgvModeQ.DefaultCellStyle = dataGridViewCellStyle15;
            DgvModeQ.Location = new Point(0, 88);
            DgvModeQ.MultiSelect = false;
            DgvModeQ.Name = "DgvModeQ";
            DgvModeQ.ReadOnly = true;
            DgvModeQ.RowHeadersVisible = false;
            DgvModeQ.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvModeQ.Size = new Size(912, 456);
            DgvModeQ.TabIndex = 4;
            DgvModeQ.Visible = false;
            DgvModeQ.CellClick += DgvMode_CellClick;
            DgvModeQ.CellDoubleClick += DgvMode_CellDoubleClick;
            DgvModeQ.KeyDown += DgvMode_KeyDown;
            // 
            // ID
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            ID.DefaultCellStyle = dataGridViewCellStyle2;
            ID.HeaderText = "枚数";
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Width = 50;
            // 
            // CardID
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            CardID.DefaultCellStyle = dataGridViewCellStyle3;
            CardID.HeaderText = "カードNo.";
            CardID.MaxInputLength = 100;
            CardID.Name = "CardID";
            CardID.ReadOnly = true;
            CardID.Width = 65;
            // 
            // SimeiKana
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            SimeiKana.DefaultCellStyle = dataGridViewCellStyle4;
            SimeiKana.HeaderText = "フリガナ";
            SimeiKana.Name = "SimeiKana";
            SimeiKana.ReadOnly = true;
            SimeiKana.Width = 65;
            // 
            // NameKanji
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            NameKanji.DefaultCellStyle = dataGridViewCellStyle5;
            NameKanji.HeaderText = "氏名";
            NameKanji.Name = "NameKanji";
            NameKanji.ReadOnly = true;
            NameKanji.Width = 65;
            // 
            // ZipCode
            // 
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ZipCode.DefaultCellStyle = dataGridViewCellStyle6;
            ZipCode.HeaderText = "郵便番号";
            ZipCode.Name = "ZipCode";
            ZipCode.ReadOnly = true;
            ZipCode.Width = 65;
            // 
            // Address
            // 
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Address.DefaultCellStyle = dataGridViewCellStyle7;
            Address.HeaderText = "住所";
            Address.Name = "Address";
            Address.ReadOnly = true;
            Address.Width = 65;
            // 
            // TelNo
            // 
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            TelNo.DefaultCellStyle = dataGridViewCellStyle8;
            TelNo.HeaderText = "電話番号";
            TelNo.Name = "TelNo";
            TelNo.ReadOnly = true;
            TelNo.Width = 65;
            // 
            // MailAddress
            // 
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            MailAddress.DefaultCellStyle = dataGridViewCellStyle9;
            MailAddress.HeaderText = "メールアドレス";
            MailAddress.Name = "MailAddress";
            MailAddress.ReadOnly = true;
            MailAddress.Width = 65;
            // 
            // Q1Answer
            // 
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Q1Answer.DefaultCellStyle = dataGridViewCellStyle10;
            Q1Answer.HeaderText = "問１";
            Q1Answer.Name = "Q1Answer";
            Q1Answer.ReadOnly = true;
            Q1Answer.Width = 65;
            // 
            // Q2Answer
            // 
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Q2Answer.DefaultCellStyle = dataGridViewCellStyle11;
            Q2Answer.HeaderText = "問２";
            Q2Answer.Name = "Q2Answer";
            Q2Answer.ReadOnly = true;
            Q2Answer.Width = 65;
            // 
            // Q3Answer
            // 
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Q3Answer.DefaultCellStyle = dataGridViewCellStyle12;
            Q3Answer.HeaderText = "問３";
            Q3Answer.Name = "Q3Answer";
            Q3Answer.ReadOnly = true;
            Q3Answer.Width = 65;
            // 
            // ElapsedTime
            // 
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ElapsedTime.DefaultCellStyle = dataGridViewCellStyle13;
            ElapsedTime.HeaderText = "所要時間";
            ElapsedTime.Name = "ElapsedTime";
            ElapsedTime.ReadOnly = true;
            ElapsedTime.Width = 120;
            // 
            // CheckCnt
            // 
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleCenter;
            CheckCnt.DefaultCellStyle = dataGridViewCellStyle14;
            CheckCnt.HeaderText = "チェック回数";
            CheckCnt.Name = "CheckCnt";
            CheckCnt.ReadOnly = true;
            CheckCnt.Width = 70;
            // 
            // DgvModeC
            // 
            DgvModeC.AllowUserToAddRows = false;
            DgvModeC.AllowUserToDeleteRows = false;
            DgvModeC.AllowUserToResizeRows = false;
            dataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = SystemColors.Control;
            dataGridViewCellStyle16.Font = new Font("ＭＳ Ｐゴシック", 9F);
            dataGridViewCellStyle16.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = DataGridViewTriState.True;
            DgvModeC.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            DgvModeC.ColumnHeadersHeight = 20;
            DgvModeC.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            DgvModeC.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8, dataGridViewTextBoxColumn12, dataGridViewTextBoxColumn13 });
            dataGridViewCellStyle25.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle25.BackColor = SystemColors.Window;
            dataGridViewCellStyle25.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dataGridViewCellStyle25.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle25.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle25.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle25.WrapMode = DataGridViewTriState.False;
            DgvModeC.DefaultCellStyle = dataGridViewCellStyle25;
            DgvModeC.Location = new Point(0, 88);
            DgvModeC.MultiSelect = false;
            DgvModeC.Name = "DgvModeC";
            DgvModeC.ReadOnly = true;
            DgvModeC.RowHeadersVisible = false;
            DgvModeC.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvModeC.Size = new Size(912, 456);
            DgvModeC.TabIndex = 11;
            DgvModeC.Visible = false;
            DgvModeC.CellClick += DgvMode_CellClick;
            DgvModeC.CellDoubleClick += DgvMode_CellDoubleClick;
            DgvModeC.KeyDown += DgvMode_KeyDown;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle17.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.WrapMode = DataGridViewTriState.False;
            dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle17;
            dataGridViewTextBoxColumn1.HeaderText = "枚数";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle18.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle18;
            dataGridViewTextBoxColumn2.HeaderText = "カードNo.";
            dataGridViewTextBoxColumn2.MaxInputLength = 100;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Width = 65;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle19.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle19;
            dataGridViewTextBoxColumn3.HeaderText = "顧客コード";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            dataGridViewTextBoxColumn3.Width = 65;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle20.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle20;
            dataGridViewTextBoxColumn4.HeaderText = "商品コード";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            dataGridViewTextBoxColumn4.Width = 65;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewCellStyle21.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle21;
            dataGridViewTextBoxColumn7.HeaderText = "電話番号";
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.ReadOnly = true;
            dataGridViewTextBoxColumn7.Width = 65;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewCellStyle22.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle22;
            dataGridViewTextBoxColumn8.HeaderText = "メールアドレス";
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            dataGridViewTextBoxColumn8.ReadOnly = true;
            dataGridViewTextBoxColumn8.Width = 65;
            // 
            // dataGridViewTextBoxColumn12
            // 
            dataGridViewCellStyle23.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewTextBoxColumn12.DefaultCellStyle = dataGridViewCellStyle23;
            dataGridViewTextBoxColumn12.HeaderText = "所要時間";
            dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            dataGridViewTextBoxColumn12.ReadOnly = true;
            dataGridViewTextBoxColumn12.Width = 120;
            // 
            // dataGridViewTextBoxColumn13
            // 
            dataGridViewCellStyle24.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewTextBoxColumn13.DefaultCellStyle = dataGridViewCellStyle24;
            dataGridViewTextBoxColumn13.HeaderText = "チェック回数";
            dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            dataGridViewTextBoxColumn13.ReadOnly = true;
            dataGridViewTextBoxColumn13.Width = 70;
            // 
            // Frm試行一覧表示
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(912, 580);
            Controls.Add(NudID);
            Controls.Add(TxtUserName);
            Controls.Add(TxtMode);
            Controls.Add(LblMaisu2);
            Controls.Add(LblMaisu1);
            Controls.Add(LblUSerName);
            Controls.Add(LblMode);
            Controls.Add(BtnSelect);
            Controls.Add(BtnNext);
            Controls.Add(BtnOK);
            Controls.Add(DgvModeQ);
            Controls.Add(DgvModeC);
            Name = "Frm試行一覧表示";
            Text = "やってみよう！パソコンデータ入力";
            Load += Frm試行一覧表示_Load;
            ((System.ComponentModel.ISupportInitialize)NudID).EndInit();
            ((System.ComponentModel.ISupportInitialize)DgvModeQ).EndInit();
            ((System.ComponentModel.ISupportInitialize)DgvModeC).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button BtnOK;
        private Label LblMode;
        private Label LblMaisu1;
        private TextBox TxtMode;
        private Label LblUSerName;
        private TextBox TxtUserName;
        private NumericUpDown NudID;
        private Label LblMaisu2;
        private Button BtnSelect;
        private Button BtnNext;
        private DataGridView DgvModeQ;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn CardID;
        private DataGridViewTextBoxColumn SimeiKana;
        private DataGridViewTextBoxColumn NameKanji;
        private DataGridViewTextBoxColumn ZipCode;
        private DataGridViewTextBoxColumn Address;
        private DataGridViewTextBoxColumn TelNo;
        private DataGridViewTextBoxColumn MailAddress;
        private DataGridViewTextBoxColumn Q1Answer;
        private DataGridViewTextBoxColumn Q2Answer;
        private DataGridViewTextBoxColumn Q3Answer;
        private DataGridViewTextBoxColumn ElapsedTime;
        private DataGridViewTextBoxColumn CheckCnt;
        private DataGridView DgvModeC;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
    }
}
