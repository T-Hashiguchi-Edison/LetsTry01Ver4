namespace 指導者用ユーティリティ

{
    partial class Frm入力値表示アンケートカード入力
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
            GrpGoal = new GroupBox();
            RtxInputKana = new RichTextBox();
            RtxCorrectKana = new RichTextBox();
            LblCorrectCnt = new Label();
            LblWorkCnt = new Label();
            TxtCardNo = new TextBox();
            TxtMode = new TextBox();
            LblUSerName = new Label();
            LblMode = new Label();
            groupBox1 = new GroupBox();
            RtxInputMail = new RichTextBox();
            RtxCorrectMail = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            groupBox2 = new GroupBox();
            RtxInputKanji = new RichTextBox();
            RtxCorrectKanji = new RichTextBox();
            label3 = new Label();
            label4 = new Label();
            groupBox3 = new GroupBox();
            RtxInputQ1 = new RichTextBox();
            RtxCorrectQ1 = new RichTextBox();
            label5 = new Label();
            label6 = new Label();
            groupBox4 = new GroupBox();
            RtxInputZip = new RichTextBox();
            RtxCorrectZip = new RichTextBox();
            label7 = new Label();
            label8 = new Label();
            groupBox5 = new GroupBox();
            RtxInputAddress = new RichTextBox();
            RtxCorrectAddress = new RichTextBox();
            label9 = new Label();
            label10 = new Label();
            groupBox6 = new GroupBox();
            RtxInputQ2 = new RichTextBox();
            RtxCorrectQ2 = new RichTextBox();
            label11 = new Label();
            label12 = new Label();
            groupBox7 = new GroupBox();
            RtxInputQ3 = new RichTextBox();
            RtxCorrectQ3 = new RichTextBox();
            label13 = new Label();
            label14 = new Label();
            groupBox8 = new GroupBox();
            RtxInputTelNo = new RichTextBox();
            RtxCorrectTelNo = new RichTextBox();
            label15 = new Label();
            label16 = new Label();
            GrpGoal.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox7.SuspendLayout();
            groupBox8.SuspendLayout();
            SuspendLayout();
            // 
            // BtnBack
            // 
            BtnBack.Font = new Font("ＭＳ Ｐゴシック", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            BtnBack.Location = new Point(856, 592);
            BtnBack.Name = "BtnBack";
            BtnBack.Size = new Size(200, 48);
            BtnBack.TabIndex = 13;
            BtnBack.Text = "閉じる";
            BtnBack.UseVisualStyleBackColor = true;
            BtnBack.Click += BtnBack_Click;
            // 
            // GrpGoal
            // 
            GrpGoal.Controls.Add(RtxInputKana);
            GrpGoal.Controls.Add(RtxCorrectKana);
            GrpGoal.Controls.Add(LblCorrectCnt);
            GrpGoal.Controls.Add(LblWorkCnt);
            GrpGoal.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            GrpGoal.Location = new Point(8, 48);
            GrpGoal.Name = "GrpGoal";
            GrpGoal.Size = new Size(528, 112);
            GrpGoal.TabIndex = 4;
            GrpGoal.TabStop = false;
            GrpGoal.Text = "フリガナ";
            // 
            // RtxInputKana
            // 
            RtxInputKana.Location = new Point(80, 64);
            RtxInputKana.Multiline = false;
            RtxInputKana.Name = "RtxInputKana";
            RtxInputKana.ReadOnly = true;
            RtxInputKana.Size = new Size(440, 32);
            RtxInputKana.TabIndex = 3;
            RtxInputKana.TabStop = false;
            RtxInputKana.Text = "";
            // 
            // RtxCorrectKana
            // 
            RtxCorrectKana.Location = new Point(80, 32);
            RtxCorrectKana.Multiline = false;
            RtxCorrectKana.Name = "RtxCorrectKana";
            RtxCorrectKana.ReadOnly = true;
            RtxCorrectKana.Size = new Size(440, 32);
            RtxCorrectKana.TabIndex = 1;
            RtxCorrectKana.TabStop = false;
            RtxCorrectKana.Text = "アイウエオ　カキクケコ";
            // 
            // LblCorrectCnt
            // 
            LblCorrectCnt.Location = new Point(24, 64);
            LblCorrectCnt.Name = "LblCorrectCnt";
            LblCorrectCnt.Size = new Size(56, 32);
            LblCorrectCnt.TabIndex = 2;
            LblCorrectCnt.Text = "入力";
            // 
            // LblWorkCnt
            // 
            LblWorkCnt.Location = new Point(24, 32);
            LblWorkCnt.Name = "LblWorkCnt";
            LblWorkCnt.Size = new Size(56, 32);
            LblWorkCnt.TabIndex = 0;
            LblWorkCnt.Text = "正解";
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
            TxtMode.Text = "アンケート入力";
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
            groupBox1.Controls.Add(RtxInputMail);
            groupBox1.Controls.Add(RtxCorrectMail);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            groupBox1.Location = new Point(544, 48);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(528, 112);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "メールアドレス";
            // 
            // RtxInputMail
            // 
            RtxInputMail.Location = new Point(80, 64);
            RtxInputMail.Multiline = false;
            RtxInputMail.Name = "RtxInputMail";
            RtxInputMail.ReadOnly = true;
            RtxInputMail.Size = new Size(440, 32);
            RtxInputMail.TabIndex = 3;
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
            label1.Location = new Point(24, 64);
            label1.Name = "label1";
            label1.Size = new Size(56, 32);
            label1.TabIndex = 2;
            label1.Text = "入力";
            // 
            // label2
            // 
            label2.Location = new Point(24, 32);
            label2.Name = "label2";
            label2.Size = new Size(56, 32);
            label2.TabIndex = 0;
            label2.Text = "正解";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(RtxInputKanji);
            groupBox2.Controls.Add(RtxCorrectKanji);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label4);
            groupBox2.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            groupBox2.Location = new Point(8, 168);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(528, 112);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "お名前";
            // 
            // RtxInputKanji
            // 
            RtxInputKanji.Location = new Point(80, 64);
            RtxInputKanji.Multiline = false;
            RtxInputKanji.Name = "RtxInputKanji";
            RtxInputKanji.ReadOnly = true;
            RtxInputKanji.Size = new Size(440, 32);
            RtxInputKanji.TabIndex = 3;
            RtxInputKanji.TabStop = false;
            RtxInputKanji.Text = "";
            // 
            // RtxCorrectKanji
            // 
            RtxCorrectKanji.Location = new Point(80, 32);
            RtxCorrectKanji.Multiline = false;
            RtxCorrectKanji.Name = "RtxCorrectKanji";
            RtxCorrectKanji.ReadOnly = true;
            RtxCorrectKanji.Size = new Size(440, 32);
            RtxCorrectKanji.TabIndex = 1;
            RtxCorrectKanji.TabStop = false;
            RtxCorrectKanji.Text = "アイウエオ　カキクケコ";
            // 
            // label3
            // 
            label3.Location = new Point(24, 64);
            label3.Name = "label3";
            label3.Size = new Size(56, 32);
            label3.TabIndex = 2;
            label3.Text = "入力";
            // 
            // label4
            // 
            label4.Location = new Point(24, 32);
            label4.Name = "label4";
            label4.Size = new Size(56, 32);
            label4.TabIndex = 0;
            label4.Text = "正解";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(RtxInputQ1);
            groupBox3.Controls.Add(RtxCorrectQ1);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(label6);
            groupBox3.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            groupBox3.Location = new Point(544, 168);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(528, 112);
            groupBox3.TabIndex = 10;
            groupBox3.TabStop = false;
            groupBox3.Text = "問１";
            // 
            // RtxInputQ1
            // 
            RtxInputQ1.Location = new Point(80, 64);
            RtxInputQ1.Multiline = false;
            RtxInputQ1.Name = "RtxInputQ1";
            RtxInputQ1.ReadOnly = true;
            RtxInputQ1.Size = new Size(440, 32);
            RtxInputQ1.TabIndex = 3;
            RtxInputQ1.TabStop = false;
            RtxInputQ1.Text = "";
            // 
            // RtxCorrectQ1
            // 
            RtxCorrectQ1.Location = new Point(80, 32);
            RtxCorrectQ1.Multiline = false;
            RtxCorrectQ1.Name = "RtxCorrectQ1";
            RtxCorrectQ1.ReadOnly = true;
            RtxCorrectQ1.Size = new Size(440, 32);
            RtxCorrectQ1.TabIndex = 1;
            RtxCorrectQ1.TabStop = false;
            RtxCorrectQ1.Text = "アイウエオ　カキクケコ";
            // 
            // label5
            // 
            label5.Location = new Point(24, 64);
            label5.Name = "label5";
            label5.Size = new Size(56, 32);
            label5.TabIndex = 2;
            label5.Text = "入力";
            // 
            // label6
            // 
            label6.Location = new Point(24, 32);
            label6.Name = "label6";
            label6.Size = new Size(56, 32);
            label6.TabIndex = 0;
            label6.Text = "正解";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(RtxInputZip);
            groupBox4.Controls.Add(RtxCorrectZip);
            groupBox4.Controls.Add(label7);
            groupBox4.Controls.Add(label8);
            groupBox4.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            groupBox4.Location = new Point(8, 288);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(528, 112);
            groupBox4.TabIndex = 6;
            groupBox4.TabStop = false;
            groupBox4.Text = "〒（郵便番号）";
            // 
            // RtxInputZip
            // 
            RtxInputZip.Location = new Point(80, 64);
            RtxInputZip.Multiline = false;
            RtxInputZip.Name = "RtxInputZip";
            RtxInputZip.ReadOnly = true;
            RtxInputZip.Size = new Size(440, 32);
            RtxInputZip.TabIndex = 3;
            RtxInputZip.TabStop = false;
            RtxInputZip.Text = "";
            // 
            // RtxCorrectZip
            // 
            RtxCorrectZip.Location = new Point(80, 32);
            RtxCorrectZip.Multiline = false;
            RtxCorrectZip.Name = "RtxCorrectZip";
            RtxCorrectZip.ReadOnly = true;
            RtxCorrectZip.Size = new Size(440, 32);
            RtxCorrectZip.TabIndex = 1;
            RtxCorrectZip.TabStop = false;
            RtxCorrectZip.Text = "アイウエオ　カキクケコ";
            // 
            // label7
            // 
            label7.Location = new Point(24, 64);
            label7.Name = "label7";
            label7.Size = new Size(56, 32);
            label7.TabIndex = 2;
            label7.Text = "入力";
            // 
            // label8
            // 
            label8.Location = new Point(24, 32);
            label8.Name = "label8";
            label8.Size = new Size(56, 32);
            label8.TabIndex = 0;
            label8.Text = "正解";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(RtxInputAddress);
            groupBox5.Controls.Add(RtxCorrectAddress);
            groupBox5.Controls.Add(label9);
            groupBox5.Controls.Add(label10);
            groupBox5.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            groupBox5.Location = new Point(8, 408);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(528, 112);
            groupBox5.TabIndex = 7;
            groupBox5.TabStop = false;
            groupBox5.Text = "ご住所";
            // 
            // RtxInputAddress
            // 
            RtxInputAddress.Location = new Point(80, 64);
            RtxInputAddress.Multiline = false;
            RtxInputAddress.Name = "RtxInputAddress";
            RtxInputAddress.ReadOnly = true;
            RtxInputAddress.Size = new Size(440, 32);
            RtxInputAddress.TabIndex = 3;
            RtxInputAddress.TabStop = false;
            RtxInputAddress.Text = "";
            // 
            // RtxCorrectAddress
            // 
            RtxCorrectAddress.Location = new Point(80, 32);
            RtxCorrectAddress.Multiline = false;
            RtxCorrectAddress.Name = "RtxCorrectAddress";
            RtxCorrectAddress.ReadOnly = true;
            RtxCorrectAddress.Size = new Size(440, 32);
            RtxCorrectAddress.TabIndex = 1;
            RtxCorrectAddress.TabStop = false;
            RtxCorrectAddress.Text = "アイウエオ　カキクケコ";
            // 
            // label9
            // 
            label9.Location = new Point(24, 64);
            label9.Name = "label9";
            label9.Size = new Size(56, 32);
            label9.TabIndex = 2;
            label9.Text = "入力";
            // 
            // label10
            // 
            label10.Location = new Point(24, 32);
            label10.Name = "label10";
            label10.Size = new Size(56, 32);
            label10.TabIndex = 0;
            label10.Text = "正解";
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(RtxInputQ2);
            groupBox6.Controls.Add(RtxCorrectQ2);
            groupBox6.Controls.Add(label11);
            groupBox6.Controls.Add(label12);
            groupBox6.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            groupBox6.Location = new Point(544, 288);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(528, 112);
            groupBox6.TabIndex = 11;
            groupBox6.TabStop = false;
            groupBox6.Text = "問２";
            // 
            // RtxInputQ2
            // 
            RtxInputQ2.Location = new Point(80, 64);
            RtxInputQ2.Multiline = false;
            RtxInputQ2.Name = "RtxInputQ2";
            RtxInputQ2.ReadOnly = true;
            RtxInputQ2.Size = new Size(440, 32);
            RtxInputQ2.TabIndex = 3;
            RtxInputQ2.TabStop = false;
            RtxInputQ2.Text = "";
            // 
            // RtxCorrectQ2
            // 
            RtxCorrectQ2.Location = new Point(80, 32);
            RtxCorrectQ2.Multiline = false;
            RtxCorrectQ2.Name = "RtxCorrectQ2";
            RtxCorrectQ2.ReadOnly = true;
            RtxCorrectQ2.Size = new Size(440, 32);
            RtxCorrectQ2.TabIndex = 1;
            RtxCorrectQ2.TabStop = false;
            RtxCorrectQ2.Text = "アイウエオ　カキクケコ";
            // 
            // label11
            // 
            label11.Location = new Point(24, 64);
            label11.Name = "label11";
            label11.Size = new Size(56, 32);
            label11.TabIndex = 2;
            label11.Text = "入力";
            // 
            // label12
            // 
            label12.Location = new Point(24, 32);
            label12.Name = "label12";
            label12.Size = new Size(56, 32);
            label12.TabIndex = 0;
            label12.Text = "正解";
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(RtxInputQ3);
            groupBox7.Controls.Add(RtxCorrectQ3);
            groupBox7.Controls.Add(label13);
            groupBox7.Controls.Add(label14);
            groupBox7.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            groupBox7.Location = new Point(544, 408);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(528, 112);
            groupBox7.TabIndex = 12;
            groupBox7.TabStop = false;
            groupBox7.Text = "問３";
            // 
            // RtxInputQ3
            // 
            RtxInputQ3.Location = new Point(80, 64);
            RtxInputQ3.Multiline = false;
            RtxInputQ3.Name = "RtxInputQ3";
            RtxInputQ3.ReadOnly = true;
            RtxInputQ3.Size = new Size(440, 32);
            RtxInputQ3.TabIndex = 3;
            RtxInputQ3.TabStop = false;
            RtxInputQ3.Text = "";
            // 
            // RtxCorrectQ3
            // 
            RtxCorrectQ3.Location = new Point(80, 32);
            RtxCorrectQ3.Multiline = false;
            RtxCorrectQ3.Name = "RtxCorrectQ3";
            RtxCorrectQ3.ReadOnly = true;
            RtxCorrectQ3.Size = new Size(440, 32);
            RtxCorrectQ3.TabIndex = 1;
            RtxCorrectQ3.TabStop = false;
            RtxCorrectQ3.Text = "アイウエオ　カキクケコ";
            // 
            // label13
            // 
            label13.Location = new Point(24, 64);
            label13.Name = "label13";
            label13.Size = new Size(56, 32);
            label13.TabIndex = 2;
            label13.Text = "入力";
            // 
            // label14
            // 
            label14.Location = new Point(24, 32);
            label14.Name = "label14";
            label14.Size = new Size(56, 32);
            label14.TabIndex = 0;
            label14.Text = "正解";
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(RtxInputTelNo);
            groupBox8.Controls.Add(RtxCorrectTelNo);
            groupBox8.Controls.Add(label15);
            groupBox8.Controls.Add(label16);
            groupBox8.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            groupBox8.Location = new Point(8, 528);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(528, 112);
            groupBox8.TabIndex = 8;
            groupBox8.TabStop = false;
            groupBox8.Text = "電話番号";
            // 
            // RtxInputTelNo
            // 
            RtxInputTelNo.Location = new Point(80, 64);
            RtxInputTelNo.Multiline = false;
            RtxInputTelNo.Name = "RtxInputTelNo";
            RtxInputTelNo.ReadOnly = true;
            RtxInputTelNo.Size = new Size(440, 32);
            RtxInputTelNo.TabIndex = 3;
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
            label15.Location = new Point(24, 64);
            label15.Name = "label15";
            label15.Size = new Size(56, 32);
            label15.TabIndex = 2;
            label15.Text = "入力";
            // 
            // label16
            // 
            label16.Location = new Point(24, 32);
            label16.Name = "label16";
            label16.Size = new Size(56, 32);
            label16.TabIndex = 0;
            label16.Text = "正解";
            // 
            // Frm入力値表示アンケートカード入力
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1085, 641);
            Controls.Add(TxtCardNo);
            Controls.Add(TxtMode);
            Controls.Add(LblUSerName);
            Controls.Add(LblMode);
            Controls.Add(groupBox7);
            Controls.Add(groupBox3);
            Controls.Add(groupBox6);
            Controls.Add(groupBox1);
            Controls.Add(groupBox8);
            Controls.Add(groupBox5);
            Controls.Add(groupBox2);
            Controls.Add(groupBox4);
            Controls.Add(GrpGoal);
            Controls.Add(BtnBack);
            Name = "Frm入力値表示アンケートカード入力";
            Text = "解析結果の出力[正解と入力の比較]";
            Load += Frm入力値表示アンケートカード入力_Load;
            GrpGoal.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            groupBox7.ResumeLayout(false);
            groupBox8.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button BtnBack;
        private GroupBox GrpGoal;
        private Label LblCorrectCnt;
        private Label LblWorkCnt;
        private TextBox TxtCardNo;
        private TextBox TxtMode;
        private Label LblUSerName;
        private Label LblMode;
        private RichTextBox RtxInputKana;
        private RichTextBox RtxCorrectKana;
        private GroupBox groupBox1;
        private RichTextBox RtxInputMail;
        private RichTextBox RtxCorrectMail;
        private Label label1;
        private Label label2;
        private GroupBox groupBox2;
        private RichTextBox RtxInputKanji;
        private RichTextBox RtxCorrectKanji;
        private Label label3;
        private Label label4;
        private GroupBox groupBox3;
        private RichTextBox RtxInputQ1;
        private RichTextBox RtxCorrectQ1;
        private Label label5;
        private Label label6;
        private GroupBox groupBox4;
        private RichTextBox RtxInputZip;
        private RichTextBox RtxCorrectZip;
        private Label label7;
        private Label label8;
        private GroupBox groupBox5;
        private RichTextBox RtxInputAddress;
        private RichTextBox RtxCorrectAddress;
        private Label label9;
        private Label label10;
        private GroupBox groupBox6;
        private RichTextBox RtxInputQ2;
        private RichTextBox RtxCorrectQ2;
        private Label label11;
        private Label label12;
        private GroupBox groupBox7;
        private RichTextBox RtxInputQ3;
        private RichTextBox RtxCorrectQ3;
        private Label label13;
        private Label label14;
        private GroupBox groupBox8;
        private RichTextBox RtxInputTelNo;
        private RichTextBox RtxCorrectTelNo;
        private Label label15;
        private Label label16;
    }
}
