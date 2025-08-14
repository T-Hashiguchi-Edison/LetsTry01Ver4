namespace パソコンデータ入力

{
    partial class Frm郵便番号選択
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
            DgvAddress = new DataGridView();
            Address = new DataGridViewTextBoxColumn();
            BtnOK = new Button();
            BtnCancel = new Button();
            LblSyori = new Label();
            LblPostNoTitle = new Label();
            LblPostNo = new Label();
            LblKensuTitle = new Label();
            LblKensu = new Label();
            ((System.ComponentModel.ISupportInitialize)DgvAddress).BeginInit();
            SuspendLayout();
            // 
            // DgvAddress
            // 
            DgvAddress.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvAddress.Columns.AddRange(new DataGridViewColumn[] { Address });
            DgvAddress.Location = new Point(24, 128);
            DgvAddress.MultiSelect = false;
            DgvAddress.Name = "DgvAddress";
            DgvAddress.ReadOnly = true;
            DgvAddress.RowHeadersVisible = false;
            DgvAddress.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvAddress.Size = new Size(1008, 400);
            DgvAddress.TabIndex = 0;
            DgvAddress.CellClick += DgvAddress_CellClick;
            DgvAddress.CellDoubleClick += DgvAddress_CellDoubleClick;
            DgvAddress.KeyDown += DgvAddress_KeyDown;
            // 
            // Address
            // 
            dataGridViewCellStyle1.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            Address.DefaultCellStyle = dataGridViewCellStyle1;
            Address.HeaderText = "住所";
            Address.MaxInputLength = 128;
            Address.Name = "Address";
            Address.ReadOnly = true;
            Address.Width = 988;
            // 
            // BtnOK
            // 
            BtnOK.Location = new Point(337, 536);
            BtnOK.Name = "BtnOK";
            BtnOK.Size = new Size(184, 32);
            BtnOK.TabIndex = 1;
            BtnOK.Text = "ＯＫ";
            BtnOK.UseVisualStyleBackColor = true;
            BtnOK.Click += BtnOK_Click;
            // 
            // BtnCancel
            // 
            BtnCancel.Location = new Point(529, 536);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(184, 32);
            BtnCancel.TabIndex = 2;
            BtnCancel.Text = "キャンセル";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // LblSyori
            // 
            LblSyori.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblSyori.Location = new Point(24, 8);
            LblSyori.Name = "LblSyori";
            LblSyori.Size = new Size(560, 64);
            LblSyori.TabIndex = 29;
            LblSyori.Text = "郵便番号検索で複数の住所が見つかりました。\r\nリストからあてはまるものをクリックして［ＯＫ］ボタンを押してください。";
            LblSyori.TextAlign = ContentAlignment.BottomLeft;
            // 
            // LblPostNoTitle
            // 
            LblPostNoTitle.Font = new Font("ＭＳ Ｐゴシック", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblPostNoTitle.Location = new Point(24, 96);
            LblPostNoTitle.Name = "LblPostNoTitle";
            LblPostNoTitle.Size = new Size(96, 32);
            LblPostNoTitle.TabIndex = 30;
            LblPostNoTitle.Text = "郵便番号：";
            LblPostNoTitle.TextAlign = ContentAlignment.BottomLeft;
            // 
            // LblPostNo
            // 
            LblPostNo.Font = new Font("ＭＳ Ｐゴシック", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblPostNo.Location = new Point(120, 96);
            LblPostNo.Name = "LblPostNo";
            LblPostNo.Size = new Size(96, 32);
            LblPostNo.TabIndex = 30;
            LblPostNo.Text = "999-9999";
            LblPostNo.TextAlign = ContentAlignment.BottomLeft;
            // 
            // LblKensuTitle
            // 
            LblKensuTitle.Font = new Font("ＭＳ Ｐゴシック", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblKensuTitle.Location = new Point(1008, 96);
            LblKensuTitle.Name = "LblKensuTitle";
            LblKensuTitle.Size = new Size(24, 32);
            LblKensuTitle.TabIndex = 30;
            LblKensuTitle.Text = "件";
            LblKensuTitle.TextAlign = ContentAlignment.BottomLeft;
            // 
            // LblKensu
            // 
            LblKensu.Font = new Font("ＭＳ Ｐゴシック", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblKensu.Location = new Point(960, 96);
            LblKensu.Name = "LblKensu";
            LblKensu.Size = new Size(48, 32);
            LblKensu.TabIndex = 30;
            LblKensu.Text = "999";
            LblKensu.TextAlign = ContentAlignment.BottomRight;
            // 
            // Frm郵便番号選択
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1050, 571);
            Controls.Add(LblPostNo);
            Controls.Add(LblKensu);
            Controls.Add(LblKensuTitle);
            Controls.Add(LblPostNoTitle);
            Controls.Add(LblSyori);
            Controls.Add(BtnCancel);
            Controls.Add(BtnOK);
            Controls.Add(DgvAddress);
            Name = "Frm郵便番号選択";
            Text = "やってみよう！パソコンデータ入力";
            Load += Frm郵便番号選択_Load;
            ((System.ComponentModel.ISupportInitialize)DgvAddress).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DgvAddress;
        private Button BtnOK;
        private Button BtnCancel;
        private Label LblSyori;
        private Label LblPostNoTitle;
        private Label LblPostNo;
        private Label LblKensuTitle;
        private Label LblKensu;
        private DataGridViewTextBoxColumn Address;
    }
}
