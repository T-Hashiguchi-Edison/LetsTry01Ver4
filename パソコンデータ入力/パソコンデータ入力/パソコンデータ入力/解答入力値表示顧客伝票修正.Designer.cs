namespace パソコンデータ入力

{
    partial class Frm解答入力値表示顧客伝票修正
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
            BtnBack = new Button();
            TxtCardNo = new TextBox();
            TxtMode = new TextBox();
            LblUSerName = new Label();
            LblMode = new Label();
            groupBox1 = new GroupBox();
            RtxInputBeforeMail = new RichTextBox();
            label5 = new Label();
            RtxInputMail = new RichTextBox();
            RtxCorrectMail = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            groupBox4 = new GroupBox();
            RtxInputBeforeCustCd = new RichTextBox();
            label3 = new Label();
            RtxInputCustCd = new RichTextBox();
            RtxCorrectCustCd = new RichTextBox();
            label7 = new Label();
            label8 = new Label();
            groupBox5 = new GroupBox();
            RtxInputBeforeItemCd = new RichTextBox();
            label6 = new Label();
            RtxInputItemCd = new RichTextBox();
            RtxCorrectItemCd = new RichTextBox();
            label9 = new Label();
            label10 = new Label();
            groupBox8 = new GroupBox();
            RtxInputBeforeTelNo = new RichTextBox();
            label4 = new Label();
            RtxInputTelNo = new RichTextBox();
            RtxCorrectTelNo = new RichTextBox();
            label15 = new Label();
            label16 = new Label();
            groupBox1.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox8.SuspendLayout();
            SuspendLayout();
            // 
            // BtnBack
            // 
            BtnBack.Font = new Font("ＭＳ Ｐゴシック", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            BtnBack.Location = new Point(856, 592);
            BtnBack.Name = "BtnBack";
            BtnBack.Size = new Size(200, 48);
            BtnBack.TabIndex = 8;
            BtnBack.Text = "試行一覧表示画面に戻る(N)";
            BtnBack.UseVisualStyleBackColor = true;
            BtnBack.Click += BtnBack_Click;
            // 
            // TxtCardNo
            // 
            TxtCardNo.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            TxtCardNo.ImeMode = ImeMode.Off;
            TxtCardNo.Location = new Point(320, 8);
            TxtCardNo.MaxLength = 8;
            TxtCardNo.Name = "TxtCardNo";
            TxtCardNo.ReadOnly = true;
            TxtCardNo.Size = new Size(64, 26);
            TxtCardNo.TabIndex = 3;
            TxtCardNo.TabStop = false;
            TxtCardNo.Text = "9999";
            // 
            // TxtMode
            // 
            TxtMode.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            TxtMode.ImeMode = ImeMode.Off;
            TxtMode.Location = new Point(92, 8);
            TxtMode.MaxLength = 8;
            TxtMode.Name = "TxtMode";
            TxtMode.ReadOnly = true;
            TxtMode.Size = new Size(176, 26);
            TxtMode.TabIndex = 1;
            TxtMode.TabStop = false;
            TxtMode.Text = "顧客伝票修正";
            // 
            // LblUSerName
            // 
            LblUSerName.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblUSerName.Location = new Point(284, 8);
            LblUSerName.Name = "LblUSerName";
            LblUSerName.Size = new Size(36, 24);
            LblUSerName.TabIndex = 2;
            LblUSerName.Text = "No.";
            LblUSerName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblMode
            // 
            LblMode.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblMode.Location = new Point(12, 8);
            LblMode.Name = "LblMode";
            LblMode.Size = new Size(80, 24);
            LblMode.TabIndex = 0;
            LblMode.Text = "課題名";
            LblMode.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(RtxInputBeforeMail);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(RtxInputMail);
            groupBox1.Controls.Add(RtxCorrectMail);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            groupBox1.Location = new Point(544, 248);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(528, 144);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "メールアドレス";
            // 
            // RtxInputBeforeMail
            // 
            RtxInputBeforeMail.BackColor = SystemColors.Control;
            RtxInputBeforeMail.Location = new Point(80, 64);
            RtxInputBeforeMail.Multiline = false;
            RtxInputBeforeMail.Name = "RtxInputBeforeMail";
            RtxInputBeforeMail.ReadOnly = true;
            RtxInputBeforeMail.Size = new Size(440, 32);
            RtxInputBeforeMail.TabIndex = 3;
            RtxInputBeforeMail.TabStop = false;
            RtxInputBeforeMail.Text = "";
            // 
            // label5
            // 
            label5.Location = new Point(8, 64);
            label5.Name = "label5";
            label5.Size = new Size(72, 32);
            label5.TabIndex = 2;
            label5.Text = "入力前";
            // 
            // RtxInputMail
            // 
            RtxInputMail.Location = new Point(80, 96);
            RtxInputMail.Multiline = false;
            RtxInputMail.Name = "RtxInputMail";
            RtxInputMail.ReadOnly = true;
            RtxInputMail.Size = new Size(440, 32);
            RtxInputMail.TabIndex = 5;
            RtxInputMail.TabStop = false;
            RtxInputMail.Text = "";
            // 
            // RtxCorrectMail
            // 
            RtxCorrectMail.Location = new Point(80, 32);
            RtxCorrectMail.Multiline = false;
            RtxCorrectMail.Name = "RtxCorrectMail";
            RtxCorrectMail.ReadOnly = true;
            RtxCorrectMail.Size = new Size(440, 32);
            RtxCorrectMail.TabIndex = 1;
            RtxCorrectMail.TabStop = false;
            RtxCorrectMail.Text = "アイウエオ　カキクケコ";
            // 
            // label1
            // 
            label1.Location = new Point(8, 96);
            label1.Name = "label1";
            label1.Size = new Size(72, 32);
            label1.TabIndex = 4;
            label1.Text = "入力後";
            // 
            // label2
            // 
            label2.Location = new Point(8, 32);
            label2.Name = "label2";
            label2.Size = new Size(72, 32);
            label2.TabIndex = 0;
            label2.Text = "正解";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(RtxInputBeforeCustCd);
            groupBox4.Controls.Add(label3);
            groupBox4.Controls.Add(RtxInputCustCd);
            groupBox4.Controls.Add(RtxCorrectCustCd);
            groupBox4.Controls.Add(label7);
            groupBox4.Controls.Add(label8);
            groupBox4.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            groupBox4.Location = new Point(8, 64);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(528, 144);
            groupBox4.TabIndex = 4;
            groupBox4.TabStop = false;
            groupBox4.Text = "顧客コード";
            // 
            // RtxInputBeforeCustCd
            // 
            RtxInputBeforeCustCd.BackColor = SystemColors.Control;
            RtxInputBeforeCustCd.Location = new Point(80, 64);
            RtxInputBeforeCustCd.Multiline = false;
            RtxInputBeforeCustCd.Name = "RtxInputBeforeCustCd";
            RtxInputBeforeCustCd.ReadOnly = true;
            RtxInputBeforeCustCd.Size = new Size(440, 32);
            RtxInputBeforeCustCd.TabIndex = 3;
            RtxInputBeforeCustCd.TabStop = false;
            RtxInputBeforeCustCd.Text = "";
            // 
            // label3
            // 
            label3.Location = new Point(8, 64);
            label3.Name = "label3";
            label3.Size = new Size(72, 32);
            label3.TabIndex = 2;
            label3.Text = "入力前";
            // 
            // RtxInputCustCd
            // 
            RtxInputCustCd.Location = new Point(80, 96);
            RtxInputCustCd.Multiline = false;
            RtxInputCustCd.Name = "RtxInputCustCd";
            RtxInputCustCd.ReadOnly = true;
            RtxInputCustCd.Size = new Size(440, 32);
            RtxInputCustCd.TabIndex = 5;
            RtxInputCustCd.TabStop = false;
            RtxInputCustCd.Text = "";
            // 
            // RtxCorrectCustCd
            // 
            RtxCorrectCustCd.Location = new Point(80, 32);
            RtxCorrectCustCd.Multiline = false;
            RtxCorrectCustCd.Name = "RtxCorrectCustCd";
            RtxCorrectCustCd.ReadOnly = true;
            RtxCorrectCustCd.Size = new Size(440, 32);
            RtxCorrectCustCd.TabIndex = 1;
            RtxCorrectCustCd.TabStop = false;
            RtxCorrectCustCd.Text = "アイウエオ　カキクケコ";
            // 
            // label7
            // 
            label7.Location = new Point(8, 96);
            label7.Name = "label7";
            label7.Size = new Size(72, 32);
            label7.TabIndex = 4;
            label7.Text = "入力後";
            // 
            // label8
            // 
            label8.Location = new Point(8, 32);
            label8.Name = "label8";
            label8.Size = new Size(72, 32);
            label8.TabIndex = 0;
            label8.Text = "正解";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(RtxInputBeforeItemCd);
            groupBox5.Controls.Add(label6);
            groupBox5.Controls.Add(RtxInputItemCd);
            groupBox5.Controls.Add(RtxCorrectItemCd);
            groupBox5.Controls.Add(label9);
            groupBox5.Controls.Add(label10);
            groupBox5.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            groupBox5.Location = new Point(8, 248);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(528, 144);
            groupBox5.TabIndex = 5;
            groupBox5.TabStop = false;
            groupBox5.Text = "商品コード";
            // 
            // RtxInputBeforeItemCd
            // 
            RtxInputBeforeItemCd.BackColor = SystemColors.Control;
            RtxInputBeforeItemCd.Location = new Point(80, 64);
            RtxInputBeforeItemCd.Multiline = false;
            RtxInputBeforeItemCd.Name = "RtxInputBeforeItemCd";
            RtxInputBeforeItemCd.ReadOnly = true;
            RtxInputBeforeItemCd.Size = new Size(440, 32);
            RtxInputBeforeItemCd.TabIndex = 3;
            RtxInputBeforeItemCd.TabStop = false;
            RtxInputBeforeItemCd.Text = "";
            // 
            // label6
            // 
            label6.Location = new Point(8, 64);
            label6.Name = "label6";
            label6.Size = new Size(72, 32);
            label6.TabIndex = 2;
            label6.Text = "入力前";
            // 
            // RtxInputItemCd
            // 
            RtxInputItemCd.Location = new Point(80, 96);
            RtxInputItemCd.Multiline = false;
            RtxInputItemCd.Name = "RtxInputItemCd";
            RtxInputItemCd.ReadOnly = true;
            RtxInputItemCd.Size = new Size(440, 32);
            RtxInputItemCd.TabIndex = 5;
            RtxInputItemCd.TabStop = false;
            RtxInputItemCd.Text = "";
            // 
            // RtxCorrectItemCd
            // 
            RtxCorrectItemCd.Location = new Point(80, 32);
            RtxCorrectItemCd.Multiline = false;
            RtxCorrectItemCd.Name = "RtxCorrectItemCd";
            RtxCorrectItemCd.ReadOnly = true;
            RtxCorrectItemCd.Size = new Size(440, 32);
            RtxCorrectItemCd.TabIndex = 1;
            RtxCorrectItemCd.TabStop = false;
            RtxCorrectItemCd.Text = "アイウエオ　カキクケコ";
            // 
            // label9
            // 
            label9.Location = new Point(8, 96);
            label9.Name = "label9";
            label9.Size = new Size(72, 32);
            label9.TabIndex = 4;
            label9.Text = "入力後";
            // 
            // label10
            // 
            label10.Location = new Point(8, 32);
            label10.Name = "label10";
            label10.Size = new Size(72, 32);
            label10.TabIndex = 0;
            label10.Text = "正解";
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(RtxInputBeforeTelNo);
            groupBox8.Controls.Add(label4);
            groupBox8.Controls.Add(RtxInputTelNo);
            groupBox8.Controls.Add(RtxCorrectTelNo);
            groupBox8.Controls.Add(label15);
            groupBox8.Controls.Add(label16);
            groupBox8.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            groupBox8.Location = new Point(544, 64);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(528, 144);
            groupBox8.TabIndex = 6;
            groupBox8.TabStop = false;
            groupBox8.Text = "電話番号";
            // 
            // RtxInputBeforeTelNo
            // 
            RtxInputBeforeTelNo.BackColor = SystemColors.Control;
            RtxInputBeforeTelNo.Location = new Point(80, 64);
            RtxInputBeforeTelNo.Multiline = false;
            RtxInputBeforeTelNo.Name = "RtxInputBeforeTelNo";
            RtxInputBeforeTelNo.ReadOnly = true;
            RtxInputBeforeTelNo.Size = new Size(440, 32);
            RtxInputBeforeTelNo.TabIndex = 3;
            RtxInputBeforeTelNo.TabStop = false;
            RtxInputBeforeTelNo.Text = "";
            // 
            // label4
            // 
            label4.Location = new Point(8, 64);
            label4.Name = "label4";
            label4.Size = new Size(72, 32);
            label4.TabIndex = 2;
            label4.Text = "入力前";
            // 
            // RtxInputTelNo
            // 
            RtxInputTelNo.Location = new Point(80, 96);
            RtxInputTelNo.Multiline = false;
            RtxInputTelNo.Name = "RtxInputTelNo";
            RtxInputTelNo.ReadOnly = true;
            RtxInputTelNo.Size = new Size(440, 32);
            RtxInputTelNo.TabIndex = 5;
            RtxInputTelNo.TabStop = false;
            RtxInputTelNo.Text = "";
            // 
            // RtxCorrectTelNo
            // 
            RtxCorrectTelNo.Location = new Point(80, 32);
            RtxCorrectTelNo.Multiline = false;
            RtxCorrectTelNo.Name = "RtxCorrectTelNo";
            RtxCorrectTelNo.ReadOnly = true;
            RtxCorrectTelNo.Size = new Size(440, 32);
            RtxCorrectTelNo.TabIndex = 1;
            RtxCorrectTelNo.TabStop = false;
            RtxCorrectTelNo.Text = "アイウエオ　カキクケコ";
            // 
            // label15
            // 
            label15.Location = new Point(8, 96);
            label15.Name = "label15";
            label15.Size = new Size(72, 32);
            label15.TabIndex = 4;
            label15.Text = "入力後";
            // 
            // label16
            // 
            label16.Location = new Point(8, 32);
            label16.Name = "label16";
            label16.Size = new Size(72, 32);
            label16.TabIndex = 0;
            label16.Text = "正解";
            // 
            // Frm解答入力値表示顧客伝票修正
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1085, 647);
            Controls.Add(TxtCardNo);
            Controls.Add(TxtMode);
            Controls.Add(LblUSerName);
            Controls.Add(LblMode);
            Controls.Add(groupBox1);
            Controls.Add(groupBox8);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(BtnBack);
            Name = "Frm解答入力値表示顧客伝票修正";
            Text = "やってみよう！パソコンデータ入力";
            Load += Frm解答入力値表示顧客伝票修正_Load;
            groupBox1.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox8.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button BtnBack;
        private TextBox TxtCardNo;
        private TextBox TxtMode;
        private Label LblUSerName;
        private Label LblMode;
        private GroupBox groupBox1;
        private RichTextBox RtxInputMail;
        private RichTextBox RtxCorrectMail;
        private Label label1;
        private Label label2;
        private GroupBox groupBox4;
        private RichTextBox RtxInputCustCd;
        private RichTextBox RtxCorrectCustCd;
        private Label label7;
        private Label label8;
        private GroupBox groupBox5;
        private RichTextBox RtxInputItemCd;
        private RichTextBox RtxCorrectItemCd;
        private Label label9;
        private Label label10;
        private GroupBox groupBox8;
        private RichTextBox RtxInputTelNo;
        private RichTextBox RtxCorrectTelNo;
        private Label label15;
        private Label label16;
        private RichTextBox RtxInputBeforeCustCd;
        private Label label3;
        private RichTextBox RtxInputBeforeMail;
        private Label label5;
        private RichTextBox RtxInputBeforeItemCd;
        private Label label6;
        private RichTextBox RtxInputBeforeTelNo;
        private Label label4;
    }
}
