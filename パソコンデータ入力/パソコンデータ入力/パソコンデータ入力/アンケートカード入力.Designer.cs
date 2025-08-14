namespace パソコンデータ入力
{
    partial class Frmアンケートカード入力
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
            components = new System.ComponentModel.Container();
            BtnNext = new Button();
            BtnCancel = new Button();
            RdiQ2_1 = new RadioButton();
            ChkQ3_1 = new CheckBox();
            TxtCardNo = new TextBox();
            LblNo = new Label();
            LblKanaSimei = new Label();
            TxtKanaSimei = new TextBox();
            LblKanjiSimei = new Label();
            TxtKanjiSimei = new TextBox();
            LblPostNo = new Label();
            TxtPostNo = new TextBox();
            BtnPostNoSearch = new Button();
            LblAddress = new Label();
            TxtAddress = new TextBox();
            LblTelNo = new Label();
            TxtTelNo = new TextBox();
            LblMailAddress = new Label();
            TxtMailAddress = new TextBox();
            PnlInput = new Panel();
            PbTimer = new ProgressBar();
            GrpProgress = new GroupBox();
            LblProgress11 = new Label();
            LblProgressTimer = new Label();
            LblProgress14 = new Label();
            LblProgressCount3 = new Label();
            LblProgress23 = new Label();
            LblProgress13 = new Label();
            LblProgressCount1 = new Label();
            LblProgress21 = new Label();
            LblProgressCount2 = new Label();
            LblProgress22 = new Label();
            LblProgress12 = new Label();
            LblQ3 = new Label();
            PnlQ3 = new Panel();
            ChkQ3_2 = new CheckBox();
            PnlQ2 = new Panel();
            RdiQ2_4 = new RadioButton();
            RdiQ2_2 = new RadioButton();
            RdiQ2_3 = new RadioButton();
            CmbQ1 = new ComboBox();
            BtnCheck = new Button();
            LblQ2 = new Label();
            LblQ1 = new Label();
            PnlQuestionCard = new Panel();
            LblQ3Value = new Label();
            LblQ2Value = new Label();
            LblQ1Value = new Label();
            PbxQ3 = new PictureBox();
            PbxQ2 = new PictureBox();
            PbxQ1 = new PictureBox();
            LblPostNo_C = new Label();
            LblCardNo_C = new Label();
            LineMailAddress = new Label();
            LineAddress = new Label();
            LineTelNo = new Label();
            LineSimei = new Label();
            LineTitle = new Label();
            LblTitle = new Label();
            LblNo_Q = new Label();
            LblMailAddress_C = new Label();
            LblAddress_C = new Label();
            LblQuestion3 = new Label();
            LblQuestion2 = new Label();
            LblQuestion1 = new Label();
            LblMailAddress_Q = new Label();
            LblAddress_Q = new Label();
            LblTelNo_C = new Label();
            LblTelNo_Q = new Label();
            LblKanjiSimei_C = new Label();
            LblKanjiSimei_Q = new Label();
            LblQuestion1_6 = new Label();
            LblQuestion1_4 = new Label();
            LblQuestion1_5 = new Label();
            LblQuestion2_3 = new Label();
            LblQuestion2_2 = new Label();
            LblQuestion1_3 = new Label();
            LblComment = new Label();
            LblQuestion3_2 = new Label();
            LblQuestion3_1 = new Label();
            LblQuestion2_1 = new Label();
            LblQuestion1_2 = new Label();
            LblQuestion1_1 = new Label();
            LblKanaSimei_C = new Label();
            LblKanaSimei_Q = new Label();
            EndTimer = new System.Windows.Forms.Timer(components);
            RunTimer = new System.Windows.Forms.Timer(components);
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            PnlInput.SuspendLayout();
            GrpProgress.SuspendLayout();
            PnlQ3.SuspendLayout();
            PnlQ2.SuspendLayout();
            PnlQuestionCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PbxQ3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PbxQ2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PbxQ1).BeginInit();
            SuspendLayout();
            // 
            // BtnNext
            // 
            BtnNext.Font = new Font("ＭＳ Ｐゴシック", 15.75F);
            BtnNext.Location = new Point(241, 624);
            BtnNext.Name = "BtnNext";
            BtnNext.Size = new Size(222, 40);
            BtnNext.TabIndex = 12;
            BtnNext.Text = "次へ(N)";
            BtnNext.UseVisualStyleBackColor = true;
            BtnNext.Click += BtnNext_Click;
            // 
            // BtnCancel
            // 
            BtnCancel.Font = new Font("ＭＳ Ｐゴシック", 15.75F);
            BtnCancel.Location = new Point(576, 680);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(112, 40);
            BtnCancel.TabIndex = 14;
            BtnCancel.Text = "中止(C)";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // RdiQ2_1
            // 
            RdiQ2_1.Font = new Font("ＭＳ Ｐゴシック", 15.75F);
            RdiQ2_1.Location = new Point(8, 8);
            RdiQ2_1.Name = "RdiQ2_1";
            RdiQ2_1.Size = new Size(200, 40);
            RdiQ2_1.TabIndex = 1;
            RdiQ2_1.TabStop = true;
            RdiQ2_1.Text = "役に立った";
            RdiQ2_1.UseVisualStyleBackColor = true;
            // 
            // ChkQ3_1
            // 
            ChkQ3_1.Font = new Font("ＭＳ Ｐゴシック", 15.75F);
            ChkQ3_1.Location = new Point(8, 8);
            ChkQ3_1.Name = "ChkQ3_1";
            ChkQ3_1.Size = new Size(200, 32);
            ChkQ3_1.TabIndex = 1;
            ChkQ3_1.Text = "希望する";
            ChkQ3_1.UseVisualStyleBackColor = true;
            // 
            // TxtCardNo
            // 
            TxtCardNo.BorderStyle = BorderStyle.None;
            TxtCardNo.Enabled = false;
            TxtCardNo.Font = new Font("ＭＳ Ｐゴシック", 15.75F);
            TxtCardNo.ForeColor = SystemColors.ControlText;
            TxtCardNo.ImeMode = ImeMode.Off;
            TxtCardNo.Location = new Point(152, 74);
            TxtCardNo.MaxLength = 4;
            TxtCardNo.Name = "TxtCardNo";
            TxtCardNo.ReadOnly = true;
            TxtCardNo.Size = new Size(72, 21);
            TxtCardNo.TabIndex = 1;
            TxtCardNo.Text = "0001";
            // 
            // LblNo
            // 
            LblNo.BackColor = SystemColors.Control;
            LblNo.Font = new Font("ＭＳ Ｐゴシック", 15.75F);
            LblNo.Location = new Point(24, 72);
            LblNo.Name = "LblNo";
            LblNo.Size = new Size(120, 24);
            LblNo.TabIndex = 26;
            LblNo.Text = "NO.";
            LblNo.TextAlign = ContentAlignment.BottomRight;
            // 
            // LblKanaSimei
            // 
            LblKanaSimei.Font = new Font("ＭＳ Ｐゴシック", 15.75F);
            LblKanaSimei.Location = new Point(0, 120);
            LblKanaSimei.Name = "LblKanaSimei";
            LblKanaSimei.Size = new Size(152, 24);
            LblKanaSimei.TabIndex = 28;
            LblKanaSimei.Text = "フリガナ";
            LblKanaSimei.TextAlign = ContentAlignment.BottomRight;
            // 
            // TxtKanaSimei
            // 
            TxtKanaSimei.Font = new Font("ＭＳ Ｐゴシック", 15.75F);
            TxtKanaSimei.ImeMode = ImeMode.On;
            TxtKanaSimei.Location = new Point(152, 120);
            TxtKanaSimei.MaxLength = 30;
            TxtKanaSimei.Name = "TxtKanaSimei";
            TxtKanaSimei.Size = new Size(264, 28);
            TxtKanaSimei.TabIndex = 2;
            TxtKanaSimei.Text = "アイウエオカキクケコサシスセソ";
            // 
            // LblKanjiSimei
            // 
            LblKanjiSimei.Font = new Font("ＭＳ Ｐゴシック", 15.75F);
            LblKanjiSimei.Location = new Point(0, 168);
            LblKanjiSimei.Name = "LblKanjiSimei";
            LblKanjiSimei.Size = new Size(152, 24);
            LblKanjiSimei.TabIndex = 30;
            LblKanjiSimei.Text = "名前";
            LblKanjiSimei.TextAlign = ContentAlignment.BottomRight;
            // 
            // TxtKanjiSimei
            // 
            TxtKanjiSimei.Font = new Font("ＭＳ Ｐゴシック", 15.75F);
            TxtKanjiSimei.ImeMode = ImeMode.On;
            TxtKanjiSimei.Location = new Point(152, 168);
            TxtKanjiSimei.MaxLength = 20;
            TxtKanjiSimei.Name = "TxtKanjiSimei";
            TxtKanjiSimei.Size = new Size(264, 28);
            TxtKanjiSimei.TabIndex = 3;
            TxtKanjiSimei.Text = "あいうえおかきくけこさしすせそ";
            // 
            // LblPostNo
            // 
            LblPostNo.Font = new Font("ＭＳ Ｐゴシック", 15.75F);
            LblPostNo.Location = new Point(0, 216);
            LblPostNo.Name = "LblPostNo";
            LblPostNo.Size = new Size(152, 24);
            LblPostNo.TabIndex = 32;
            LblPostNo.Text = "〒";
            LblPostNo.TextAlign = ContentAlignment.BottomRight;
            // 
            // TxtPostNo
            // 
            TxtPostNo.Font = new Font("ＭＳ Ｐゴシック", 15.75F);
            TxtPostNo.ImeMode = ImeMode.Off;
            TxtPostNo.Location = new Point(152, 216);
            TxtPostNo.MaxLength = 8;
            TxtPostNo.Name = "TxtPostNo";
            TxtPostNo.Size = new Size(120, 28);
            TxtPostNo.TabIndex = 4;
            TxtPostNo.Text = "890-0001";
            // 
            // BtnPostNoSearch
            // 
            BtnPostNoSearch.Font = new Font("ＭＳ Ｐゴシック", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            BtnPostNoSearch.Location = new Point(272, 216);
            BtnPostNoSearch.Name = "BtnPostNoSearch";
            BtnPostNoSearch.Size = new Size(88, 32);
            BtnPostNoSearch.TabIndex = 5;
            BtnPostNoSearch.Text = "▽検索(Z)";
            BtnPostNoSearch.UseVisualStyleBackColor = true;
            BtnPostNoSearch.Click += BtnPostNoSearch_Click;
            // 
            // LblAddress
            // 
            LblAddress.Font = new Font("ＭＳ Ｐゴシック", 15.75F);
            LblAddress.Location = new Point(0, 264);
            LblAddress.Name = "LblAddress";
            LblAddress.Size = new Size(152, 24);
            LblAddress.TabIndex = 34;
            LblAddress.Text = "住所";
            LblAddress.TextAlign = ContentAlignment.BottomRight;
            // 
            // TxtAddress
            // 
            TxtAddress.Font = new Font("ＭＳ Ｐゴシック", 15.75F);
            TxtAddress.ImeMode = ImeMode.On;
            TxtAddress.Location = new Point(152, 264);
            TxtAddress.MaxLength = 50;
            TxtAddress.Name = "TxtAddress";
            TxtAddress.Size = new Size(512, 28);
            TxtAddress.TabIndex = 6;
            TxtAddress.Text = "あいうえおかきくけこさしすせそたちつてとなにぬねのはひふへほ";
            // 
            // LblTelNo
            // 
            LblTelNo.Font = new Font("ＭＳ Ｐゴシック", 15.75F);
            LblTelNo.Location = new Point(0, 312);
            LblTelNo.Name = "LblTelNo";
            LblTelNo.Size = new Size(152, 24);
            LblTelNo.TabIndex = 36;
            LblTelNo.Text = "電話番号";
            LblTelNo.TextAlign = ContentAlignment.BottomRight;
            // 
            // TxtTelNo
            // 
            TxtTelNo.Font = new Font("ＭＳ Ｐゴシック", 15.75F);
            TxtTelNo.ImeMode = ImeMode.Off;
            TxtTelNo.Location = new Point(152, 312);
            TxtTelNo.MaxLength = 30;
            TxtTelNo.Name = "TxtTelNo";
            TxtTelNo.Size = new Size(264, 28);
            TxtTelNo.TabIndex = 7;
            TxtTelNo.Text = "090-0000-0000";
            // 
            // LblMailAddress
            // 
            LblMailAddress.Font = new Font("ＭＳ Ｐゴシック", 15.75F);
            LblMailAddress.Location = new Point(0, 352);
            LblMailAddress.Name = "LblMailAddress";
            LblMailAddress.Size = new Size(152, 24);
            LblMailAddress.TabIndex = 38;
            LblMailAddress.Text = "メールアドレス";
            LblMailAddress.TextAlign = ContentAlignment.BottomRight;
            // 
            // TxtMailAddress
            // 
            TxtMailAddress.Font = new Font("ＭＳ Ｐゴシック", 15.75F);
            TxtMailAddress.ImeMode = ImeMode.Off;
            TxtMailAddress.Location = new Point(152, 352);
            TxtMailAddress.MaxLength = 80;
            TxtMailAddress.Name = "TxtMailAddress";
            TxtMailAddress.Size = new Size(512, 28);
            TxtMailAddress.TabIndex = 8;
            TxtMailAddress.Text = "abcdefghij@klmnopqrst.ne.jp";
            // 
            // PnlInput
            // 
            PnlInput.Controls.Add(PbTimer);
            PnlInput.Controls.Add(GrpProgress);
            PnlInput.Controls.Add(LblQ3);
            PnlInput.Controls.Add(PnlQ3);
            PnlInput.Controls.Add(PnlQ2);
            PnlInput.Controls.Add(CmbQ1);
            PnlInput.Controls.Add(BtnCheck);
            PnlInput.Controls.Add(BtnCancel);
            PnlInput.Controls.Add(LblQ2);
            PnlInput.Controls.Add(BtnNext);
            PnlInput.Controls.Add(LblQ1);
            PnlInput.Controls.Add(LblNo);
            PnlInput.Controls.Add(LblMailAddress);
            PnlInput.Controls.Add(BtnPostNoSearch);
            PnlInput.Controls.Add(TxtMailAddress);
            PnlInput.Controls.Add(TxtCardNo);
            PnlInput.Controls.Add(LblTelNo);
            PnlInput.Controls.Add(TxtKanaSimei);
            PnlInput.Controls.Add(TxtTelNo);
            PnlInput.Controls.Add(LblKanaSimei);
            PnlInput.Controls.Add(LblAddress);
            PnlInput.Controls.Add(TxtKanjiSimei);
            PnlInput.Controls.Add(TxtAddress);
            PnlInput.Controls.Add(LblKanjiSimei);
            PnlInput.Controls.Add(LblPostNo);
            PnlInput.Controls.Add(TxtPostNo);
            PnlInput.Location = new Point(608, 0);
            PnlInput.Name = "PnlInput";
            PnlInput.Size = new Size(704, 744);
            PnlInput.TabIndex = 1;
            // 
            // PbTimer
            // 
            PbTimer.Location = new Point(480, 112);
            PbTimer.Name = "PbTimer";
            PbTimer.Size = new Size(216, 23);
            PbTimer.Style = ProgressBarStyle.Continuous;
            PbTimer.TabIndex = 47;
            // 
            // GrpProgress
            // 
            GrpProgress.Controls.Add(LblProgress11);
            GrpProgress.Controls.Add(LblProgressTimer);
            GrpProgress.Controls.Add(LblProgress14);
            GrpProgress.Controls.Add(LblProgressCount3);
            GrpProgress.Controls.Add(LblProgress23);
            GrpProgress.Controls.Add(LblProgress13);
            GrpProgress.Controls.Add(LblProgressCount1);
            GrpProgress.Controls.Add(LblProgress21);
            GrpProgress.Controls.Add(LblProgressCount2);
            GrpProgress.Controls.Add(LblProgress22);
            GrpProgress.Controls.Add(LblProgress12);
            GrpProgress.Font = new Font("ＭＳ 明朝", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            GrpProgress.Location = new Point(480, 8);
            GrpProgress.Name = "GrpProgress";
            GrpProgress.Size = new Size(216, 96);
            GrpProgress.TabIndex = 46;
            GrpProgress.TabStop = false;
            GrpProgress.Text = "進捗状況";
            // 
            // LblProgress11
            // 
            LblProgress11.Font = new Font("ＭＳ 明朝", 12F);
            LblProgress11.ImageAlign = ContentAlignment.MiddleLeft;
            LblProgress11.Location = new Point(8, 24);
            LblProgress11.Name = "LblProgress11";
            LblProgress11.Size = new Size(128, 16);
            LblProgress11.TabIndex = 31;
            LblProgress11.Text = "目標作業枚数：";
            LblProgress11.TextAlign = ContentAlignment.BottomRight;
            // 
            // LblProgressTimer
            // 
            LblProgressTimer.Font = new Font("ＭＳ 明朝", 12F);
            LblProgressTimer.ImageAlign = ContentAlignment.MiddleRight;
            LblProgressTimer.Location = new Point(136, 72);
            LblProgressTimer.Name = "LblProgressTimer";
            LblProgressTimer.Size = new Size(72, 16);
            LblProgressTimer.TabIndex = 35;
            LblProgressTimer.Text = "99分99秒";
            LblProgressTimer.TextAlign = ContentAlignment.BottomLeft;
            // 
            // LblProgress14
            // 
            LblProgress14.Font = new Font("ＭＳ 明朝", 12F);
            LblProgress14.Location = new Point(8, 72);
            LblProgress14.Name = "LblProgress14";
            LblProgress14.Size = new Size(128, 16);
            LblProgress14.TabIndex = 37;
            LblProgress14.Text = "残り時間　　：";
            LblProgress14.TextAlign = ContentAlignment.BottomRight;
            // 
            // LblProgressCount3
            // 
            LblProgressCount3.Font = new Font("ＭＳ 明朝", 12F);
            LblProgressCount3.ImageAlign = ContentAlignment.MiddleRight;
            LblProgressCount3.Location = new Point(136, 56);
            LblProgressCount3.Name = "LblProgressCount3";
            LblProgressCount3.Size = new Size(32, 16);
            LblProgressCount3.TabIndex = 32;
            LblProgressCount3.Text = "999";
            LblProgressCount3.TextAlign = ContentAlignment.BottomRight;
            // 
            // LblProgress23
            // 
            LblProgress23.Font = new Font("ＭＳ 明朝", 12F);
            LblProgress23.Location = new Point(168, 56);
            LblProgress23.Name = "LblProgress23";
            LblProgress23.Size = new Size(24, 16);
            LblProgress23.TabIndex = 33;
            LblProgress23.Text = "枚";
            LblProgress23.TextAlign = ContentAlignment.BottomRight;
            // 
            // LblProgress13
            // 
            LblProgress13.Font = new Font("ＭＳ 明朝", 12F);
            LblProgress13.Location = new Point(8, 56);
            LblProgress13.Name = "LblProgress13";
            LblProgress13.Size = new Size(128, 16);
            LblProgress13.TabIndex = 34;
            LblProgress13.Text = "終わった枚数：";
            LblProgress13.TextAlign = ContentAlignment.BottomRight;
            // 
            // LblProgressCount1
            // 
            LblProgressCount1.Font = new Font("ＭＳ 明朝", 12F);
            LblProgressCount1.ImageAlign = ContentAlignment.MiddleRight;
            LblProgressCount1.Location = new Point(136, 24);
            LblProgressCount1.Name = "LblProgressCount1";
            LblProgressCount1.Size = new Size(32, 16);
            LblProgressCount1.TabIndex = 29;
            LblProgressCount1.Text = "999";
            LblProgressCount1.TextAlign = ContentAlignment.BottomRight;
            // 
            // LblProgress21
            // 
            LblProgress21.Font = new Font("ＭＳ 明朝", 12F);
            LblProgress21.Location = new Point(168, 24);
            LblProgress21.Name = "LblProgress21";
            LblProgress21.Size = new Size(24, 16);
            LblProgress21.TabIndex = 30;
            LblProgress21.Text = "枚";
            LblProgress21.TextAlign = ContentAlignment.BottomRight;
            // 
            // LblProgressCount2
            // 
            LblProgressCount2.Font = new Font("ＭＳ 明朝", 12F);
            LblProgressCount2.ImageAlign = ContentAlignment.MiddleRight;
            LblProgressCount2.Location = new Point(136, 40);
            LblProgressCount2.Name = "LblProgressCount2";
            LblProgressCount2.Size = new Size(32, 16);
            LblProgressCount2.TabIndex = 28;
            LblProgressCount2.Text = "999";
            LblProgressCount2.TextAlign = ContentAlignment.BottomRight;
            // 
            // LblProgress22
            // 
            LblProgress22.Font = new Font("ＭＳ 明朝", 12F);
            LblProgress22.Location = new Point(168, 40);
            LblProgress22.Name = "LblProgress22";
            LblProgress22.Size = new Size(24, 16);
            LblProgress22.TabIndex = 28;
            LblProgress22.Text = "枚";
            LblProgress22.TextAlign = ContentAlignment.BottomRight;
            // 
            // LblProgress12
            // 
            LblProgress12.Font = new Font("ＭＳ 明朝", 12F);
            LblProgress12.Location = new Point(8, 40);
            LblProgress12.Name = "LblProgress12";
            LblProgress12.Size = new Size(128, 16);
            LblProgress12.TabIndex = 28;
            LblProgress12.Text = "目標正解枚数：";
            LblProgress12.TextAlign = ContentAlignment.BottomRight;
            // 
            // LblQ3
            // 
            LblQ3.Font = new Font("ＭＳ Ｐゴシック", 15.75F);
            LblQ3.Location = new Point(0, 552);
            LblQ3.Name = "LblQ3";
            LblQ3.Size = new Size(152, 24);
            LblQ3.TabIndex = 45;
            LblQ3.Text = "問３";
            LblQ3.TextAlign = ContentAlignment.BottomRight;
            // 
            // PnlQ3
            // 
            PnlQ3.Controls.Add(ChkQ3_2);
            PnlQ3.Controls.Add(ChkQ3_1);
            PnlQ3.Font = new Font("ＭＳ Ｐゴシック", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            PnlQ3.Location = new Point(152, 544);
            PnlQ3.Name = "PnlQ3";
            PnlQ3.Size = new Size(424, 56);
            PnlQ3.TabIndex = 11;
            // 
            // ChkQ3_2
            // 
            ChkQ3_2.Font = new Font("ＭＳ Ｐゴシック", 15.75F);
            ChkQ3_2.Location = new Point(208, 8);
            ChkQ3_2.Name = "ChkQ3_2";
            ChkQ3_2.Size = new Size(200, 32);
            ChkQ3_2.TabIndex = 2;
            ChkQ3_2.Text = "希望しない";
            ChkQ3_2.UseVisualStyleBackColor = true;
            // 
            // PnlQ2
            // 
            PnlQ2.Controls.Add(RdiQ2_4);
            PnlQ2.Controls.Add(RdiQ2_2);
            PnlQ2.Controls.Add(RdiQ2_3);
            PnlQ2.Controls.Add(RdiQ2_1);
            PnlQ2.Font = new Font("ＭＳ Ｐゴシック", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            PnlQ2.Location = new Point(152, 440);
            PnlQ2.Name = "PnlQ2";
            PnlQ2.Size = new Size(440, 96);
            PnlQ2.TabIndex = 10;
            // 
            // RdiQ2_4
            // 
            RdiQ2_4.Font = new Font("ＭＳ Ｐゴシック", 15.75F);
            RdiQ2_4.Location = new Point(208, 48);
            RdiQ2_4.Name = "RdiQ2_4";
            RdiQ2_4.Size = new Size(224, 40);
            RdiQ2_4.TabIndex = 4;
            RdiQ2_4.TabStop = true;
            RdiQ2_4.Text = "回答なし";
            RdiQ2_4.UseVisualStyleBackColor = true;
            // 
            // RdiQ2_2
            // 
            RdiQ2_2.Font = new Font("ＭＳ Ｐゴシック", 15.75F);
            RdiQ2_2.Location = new Point(208, 8);
            RdiQ2_2.Name = "RdiQ2_2";
            RdiQ2_2.Size = new Size(224, 40);
            RdiQ2_2.TabIndex = 2;
            RdiQ2_2.TabStop = true;
            RdiQ2_2.Text = "ふつう";
            RdiQ2_2.UseVisualStyleBackColor = true;
            // 
            // RdiQ2_3
            // 
            RdiQ2_3.Font = new Font("ＭＳ Ｐゴシック", 15.75F);
            RdiQ2_3.Location = new Point(8, 48);
            RdiQ2_3.Name = "RdiQ2_3";
            RdiQ2_3.Size = new Size(200, 40);
            RdiQ2_3.TabIndex = 3;
            RdiQ2_3.TabStop = true;
            RdiQ2_3.Text = "期待はずれだった";
            RdiQ2_3.UseVisualStyleBackColor = true;
            // 
            // CmbQ1
            // 
            CmbQ1.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbQ1.Font = new Font("ＭＳ Ｐゴシック", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            CmbQ1.FormattingEnabled = true;
            CmbQ1.Items.AddRange(new object[] { "0.回答なし", "1.書店で実物を見て", "2.チラシを見て", "3.書店店員に紹介されて", "4.学校から紹介されて", "5.知人に紹介されて", "6.その他" });
            CmbQ1.Location = new Point(152, 400);
            CmbQ1.Name = "CmbQ1";
            CmbQ1.Size = new Size(264, 29);
            CmbQ1.TabIndex = 9;
            // 
            // BtnCheck
            // 
            BtnCheck.Font = new Font("ＭＳ Ｐゴシック", 15.75F);
            BtnCheck.Location = new Point(24, 664);
            BtnCheck.Name = "BtnCheck";
            BtnCheck.Size = new Size(144, 40);
            BtnCheck.TabIndex = 13;
            BtnCheck.Text = "チェック(A)";
            BtnCheck.UseVisualStyleBackColor = true;
            BtnCheck.Click += BtnCheck_Click;
            // 
            // LblQ2
            // 
            LblQ2.Font = new Font("ＭＳ Ｐゴシック", 15.75F);
            LblQ2.Location = new Point(0, 456);
            LblQ2.Name = "LblQ2";
            LblQ2.Size = new Size(152, 24);
            LblQ2.TabIndex = 40;
            LblQ2.Text = "問２";
            LblQ2.TextAlign = ContentAlignment.BottomRight;
            // 
            // LblQ1
            // 
            LblQ1.Font = new Font("ＭＳ Ｐゴシック", 15.75F);
            LblQ1.Location = new Point(0, 400);
            LblQ1.Name = "LblQ1";
            LblQ1.Size = new Size(152, 24);
            LblQ1.TabIndex = 40;
            LblQ1.Text = "問１";
            LblQ1.TextAlign = ContentAlignment.BottomRight;
            // 
            // PnlQuestionCard
            // 
            PnlQuestionCard.BackColor = Color.White;
            PnlQuestionCard.Controls.Add(LblQ3Value);
            PnlQuestionCard.Controls.Add(LblQ2Value);
            PnlQuestionCard.Controls.Add(LblQ1Value);
            PnlQuestionCard.Controls.Add(PbxQ3);
            PnlQuestionCard.Controls.Add(PbxQ2);
            PnlQuestionCard.Controls.Add(PbxQ1);
            PnlQuestionCard.Controls.Add(LblPostNo_C);
            PnlQuestionCard.Controls.Add(LblCardNo_C);
            PnlQuestionCard.Controls.Add(LineMailAddress);
            PnlQuestionCard.Controls.Add(LineAddress);
            PnlQuestionCard.Controls.Add(LineTelNo);
            PnlQuestionCard.Controls.Add(LineSimei);
            PnlQuestionCard.Controls.Add(LineTitle);
            PnlQuestionCard.Controls.Add(LblTitle);
            PnlQuestionCard.Controls.Add(LblNo_Q);
            PnlQuestionCard.Controls.Add(LblMailAddress_C);
            PnlQuestionCard.Controls.Add(LblAddress_C);
            PnlQuestionCard.Controls.Add(LblQuestion3);
            PnlQuestionCard.Controls.Add(LblQuestion2);
            PnlQuestionCard.Controls.Add(LblQuestion1);
            PnlQuestionCard.Controls.Add(LblMailAddress_Q);
            PnlQuestionCard.Controls.Add(LblAddress_Q);
            PnlQuestionCard.Controls.Add(LblTelNo_C);
            PnlQuestionCard.Controls.Add(LblTelNo_Q);
            PnlQuestionCard.Controls.Add(LblKanjiSimei_C);
            PnlQuestionCard.Controls.Add(LblKanjiSimei_Q);
            PnlQuestionCard.Controls.Add(LblQuestion1_6);
            PnlQuestionCard.Controls.Add(LblQuestion1_4);
            PnlQuestionCard.Controls.Add(LblQuestion1_5);
            PnlQuestionCard.Controls.Add(LblQuestion2_3);
            PnlQuestionCard.Controls.Add(LblQuestion2_2);
            PnlQuestionCard.Controls.Add(LblQuestion1_3);
            PnlQuestionCard.Controls.Add(LblComment);
            PnlQuestionCard.Controls.Add(LblQuestion3_2);
            PnlQuestionCard.Controls.Add(LblQuestion3_1);
            PnlQuestionCard.Controls.Add(LblQuestion2_1);
            PnlQuestionCard.Controls.Add(LblQuestion1_2);
            PnlQuestionCard.Controls.Add(LblQuestion1_1);
            PnlQuestionCard.Controls.Add(LblKanaSimei_C);
            PnlQuestionCard.Controls.Add(LblKanaSimei_Q);
            PnlQuestionCard.Location = new Point(0, 0);
            PnlQuestionCard.Name = "PnlQuestionCard";
            PnlQuestionCard.Size = new Size(608, 744);
            PnlQuestionCard.TabIndex = 2;
            // 
            // LblQ3Value
            // 
            LblQ3Value.Font = new Font("ＭＳ Ｐゴシック", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblQ3Value.Location = new Point(544, 648);
            LblQ3Value.Name = "LblQ3Value";
            LblQ3Value.Size = new Size(40, 32);
            LblQ3Value.TabIndex = 33;
            LblQ3Value.Text = "Q3";
            LblQ3Value.TextAlign = ContentAlignment.BottomLeft;
            LblQ3Value.Visible = false;
            // 
            // LblQ2Value
            // 
            LblQ2Value.Font = new Font("ＭＳ Ｐゴシック", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblQ2Value.Location = new Point(552, 568);
            LblQ2Value.Name = "LblQ2Value";
            LblQ2Value.Size = new Size(40, 32);
            LblQ2Value.TabIndex = 33;
            LblQ2Value.Text = "Q2";
            LblQ2Value.TextAlign = ContentAlignment.BottomLeft;
            LblQ2Value.Visible = false;
            // 
            // LblQ1Value
            // 
            LblQ1Value.Font = new Font("ＭＳ Ｐゴシック", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblQ1Value.Location = new Point(544, 360);
            LblQ1Value.Name = "LblQ1Value";
            LblQ1Value.Size = new Size(40, 32);
            LblQ1Value.TabIndex = 32;
            LblQ1Value.Text = "Q1";
            LblQ1Value.TextAlign = ContentAlignment.BottomLeft;
            LblQ1Value.Visible = false;
            // 
            // PbxQ3
            // 
            PbxQ3.BackColor = Color.Transparent;
            PbxQ3.Location = new Point(136, 688);
            PbxQ3.Name = "PbxQ3";
            PbxQ3.Size = new Size(32, 32);
            PbxQ3.TabIndex = 31;
            PbxQ3.TabStop = false;
            PbxQ3.Visible = false;
            // 
            // PbxQ2
            // 
            PbxQ2.BackColor = Color.Transparent;
            PbxQ2.Location = new Point(80, 688);
            PbxQ2.Name = "PbxQ2";
            PbxQ2.Size = new Size(48, 40);
            PbxQ2.TabIndex = 30;
            PbxQ2.TabStop = false;
            PbxQ2.Visible = false;
            // 
            // PbxQ1
            // 
            PbxQ1.BackColor = Color.Transparent;
            PbxQ1.Location = new Point(24, 688);
            PbxQ1.Name = "PbxQ1";
            PbxQ1.Size = new Size(48, 40);
            PbxQ1.TabIndex = 29;
            PbxQ1.TabStop = false;
            PbxQ1.Visible = false;
            // 
            // LblPostNo_C
            // 
            LblPostNo_C.Font = new Font("ＭＳ Ｐゴシック", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblPostNo_C.Location = new Point(160, 176);
            LblPostNo_C.Name = "LblPostNo_C";
            LblPostNo_C.Size = new Size(136, 32);
            LblPostNo_C.TabIndex = 28;
            LblPostNo_C.Text = "890-0001";
            LblPostNo_C.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblCardNo_C
            // 
            LblCardNo_C.Font = new Font("ＭＳ Ｐゴシック", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblCardNo_C.Location = new Point(480, 0);
            LblCardNo_C.Name = "LblCardNo_C";
            LblCardNo_C.Size = new Size(56, 32);
            LblCardNo_C.TabIndex = 26;
            LblCardNo_C.Text = "999";
            LblCardNo_C.TextAlign = ContentAlignment.BottomLeft;
            // 
            // LineMailAddress
            // 
            LineMailAddress.BorderStyle = BorderStyle.FixedSingle;
            LineMailAddress.Font = new Font("ＭＳ Ｐゴシック", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LineMailAddress.Location = new Point(72, 352);
            LineMailAddress.Name = "LineMailAddress";
            LineMailAddress.Size = new Size(504, 1);
            LineMailAddress.TabIndex = 26;
            LineMailAddress.TextAlign = ContentAlignment.BottomCenter;
            // 
            // LineAddress
            // 
            LineAddress.BorderStyle = BorderStyle.FixedSingle;
            LineAddress.Font = new Font("ＭＳ Ｐゴシック", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LineAddress.Location = new Point(72, 240);
            LineAddress.Name = "LineAddress";
            LineAddress.Size = new Size(504, 1);
            LineAddress.TabIndex = 26;
            LineAddress.TextAlign = ContentAlignment.BottomCenter;
            // 
            // LineTelNo
            // 
            LineTelNo.BorderStyle = BorderStyle.FixedSingle;
            LineTelNo.Font = new Font("ＭＳ Ｐゴシック", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LineTelNo.Location = new Point(160, 280);
            LineTelNo.Name = "LineTelNo";
            LineTelNo.Size = new Size(416, 1);
            LineTelNo.TabIndex = 26;
            LineTelNo.TextAlign = ContentAlignment.BottomCenter;
            // 
            // LineSimei
            // 
            LineSimei.BorderStyle = BorderStyle.FixedSingle;
            LineSimei.Font = new Font("ＭＳ Ｐゴシック", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LineSimei.Location = new Point(128, 168);
            LineSimei.Name = "LineSimei";
            LineSimei.Size = new Size(448, 1);
            LineSimei.TabIndex = 26;
            LineSimei.TextAlign = ContentAlignment.BottomCenter;
            // 
            // LineTitle
            // 
            LineTitle.BorderStyle = BorderStyle.FixedSingle;
            LineTitle.Font = new Font("ＭＳ Ｐゴシック", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LineTitle.Location = new Point(30, 72);
            LineTitle.Name = "LineTitle";
            LineTitle.Size = new Size(546, 2);
            LineTitle.TabIndex = 26;
            LineTitle.TextAlign = ContentAlignment.BottomCenter;
            // 
            // LblTitle
            // 
            LblTitle.Font = new Font("ＭＳ Ｐゴシック", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblTitle.Location = new Point(0, 40);
            LblTitle.Name = "LblTitle";
            LblTitle.Size = new Size(608, 32);
            LblTitle.TabIndex = 26;
            LblTitle.Text = "「仕事とパソコン」読者アンケート";
            LblTitle.TextAlign = ContentAlignment.BottomCenter;
            // 
            // LblNo_Q
            // 
            LblNo_Q.Font = new Font("ＭＳ Ｐゴシック", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblNo_Q.Location = new Point(416, 0);
            LblNo_Q.Name = "LblNo_Q";
            LblNo_Q.Size = new Size(64, 32);
            LblNo_Q.TabIndex = 26;
            LblNo_Q.Text = "NO.";
            LblNo_Q.TextAlign = ContentAlignment.BottomRight;
            // 
            // LblMailAddress_C
            // 
            LblMailAddress_C.Font = new Font("ＭＳ Ｐゴシック", 20.25F);
            LblMailAddress_C.Location = new Point(72, 320);
            LblMailAddress_C.Name = "LblMailAddress_C";
            LblMailAddress_C.Size = new Size(504, 32);
            LblMailAddress_C.TabIndex = 28;
            LblMailAddress_C.Text = "abcdefghij@klmnopqrst.ne.jp";
            LblMailAddress_C.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblAddress_C
            // 
            LblAddress_C.Font = new Font("ＭＳ Ｐゴシック", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblAddress_C.Location = new Point(72, 208);
            LblAddress_C.Name = "LblAddress_C";
            LblAddress_C.Size = new Size(504, 32);
            LblAddress_C.TabIndex = 28;
            LblAddress_C.Text = "あいうえおかきくけこさしすせそたちつてとなに";
            LblAddress_C.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblQuestion3
            // 
            LblQuestion3.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Bold);
            LblQuestion3.Location = new Point(32, 608);
            LblQuestion3.Name = "LblQuestion3";
            LblQuestion3.Size = new Size(568, 24);
            LblQuestion3.TabIndex = 28;
            LblQuestion3.Text = "●問３ あなたは弊社の出版カタログの送付をご希望されますか。";
            LblQuestion3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblQuestion2
            // 
            LblQuestion2.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Bold);
            LblQuestion2.Location = new Point(32, 528);
            LblQuestion2.Name = "LblQuestion2";
            LblQuestion2.Size = new Size(568, 24);
            LblQuestion2.TabIndex = 28;
            LblQuestion2.Text = "●問２ この本はあなたのお役に立ちましたか。";
            LblQuestion2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblQuestion1
            // 
            LblQuestion1.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Bold);
            LblQuestion1.Location = new Point(32, 368);
            LblQuestion1.Name = "LblQuestion1";
            LblQuestion1.Size = new Size(496, 24);
            LblQuestion1.TabIndex = 28;
            LblQuestion1.Text = "●問１ あなたはこの本を何でお知りになりましたか。";
            LblQuestion1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblMailAddress_Q
            // 
            LblMailAddress_Q.Font = new Font("ＭＳ Ｐゴシック", 15.75F, FontStyle.Bold);
            LblMailAddress_Q.Location = new Point(32, 288);
            LblMailAddress_Q.Name = "LblMailAddress_Q";
            LblMailAddress_Q.Size = new Size(168, 32);
            LblMailAddress_Q.TabIndex = 28;
            LblMailAddress_Q.Text = "●メールアドレス";
            LblMailAddress_Q.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblAddress_Q
            // 
            LblAddress_Q.Font = new Font("ＭＳ Ｐゴシック", 15.75F, FontStyle.Bold);
            LblAddress_Q.Location = new Point(32, 176);
            LblAddress_Q.Name = "LblAddress_Q";
            LblAddress_Q.Size = new Size(128, 32);
            LblAddress_Q.TabIndex = 28;
            LblAddress_Q.Text = "●ご住所 〒";
            LblAddress_Q.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblTelNo_C
            // 
            LblTelNo_C.Font = new Font("ＭＳ Ｐゴシック", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblTelNo_C.Location = new Point(160, 248);
            LblTelNo_C.Name = "LblTelNo_C";
            LblTelNo_C.Size = new Size(416, 32);
            LblTelNo_C.TabIndex = 28;
            LblTelNo_C.Text = "090-0000-0000";
            LblTelNo_C.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblTelNo_Q
            // 
            LblTelNo_Q.Font = new Font("ＭＳ Ｐゴシック", 15.75F, FontStyle.Bold);
            LblTelNo_Q.Location = new Point(32, 248);
            LblTelNo_Q.Name = "LblTelNo_Q";
            LblTelNo_Q.Size = new Size(136, 32);
            LblTelNo_Q.TabIndex = 28;
            LblTelNo_Q.Text = "●電話番号";
            LblTelNo_Q.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblKanjiSimei_C
            // 
            LblKanjiSimei_C.Font = new Font("ＭＳ Ｐゴシック", 20.25F);
            LblKanjiSimei_C.Location = new Point(128, 136);
            LblKanjiSimei_C.Name = "LblKanjiSimei_C";
            LblKanjiSimei_C.Size = new Size(448, 32);
            LblKanjiSimei_C.TabIndex = 28;
            LblKanjiSimei_C.Text = "あいうえおかきくけこさしすせそ";
            LblKanjiSimei_C.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblKanjiSimei_Q
            // 
            LblKanjiSimei_Q.Font = new Font("ＭＳ Ｐゴシック", 15.75F, FontStyle.Bold);
            LblKanjiSimei_Q.Location = new Point(32, 136);
            LblKanjiSimei_Q.Name = "LblKanjiSimei_Q";
            LblKanjiSimei_Q.Size = new Size(104, 32);
            LblKanjiSimei_Q.TabIndex = 28;
            LblKanjiSimei_Q.Text = "●お名前";
            LblKanjiSimei_Q.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblQuestion1_6
            // 
            LblQuestion1_6.Font = new Font("ＭＳ Ｐゴシック", 14.25F);
            LblQuestion1_6.Location = new Point(320, 480);
            LblQuestion1_6.Margin = new Padding(3, 0, 0, 0);
            LblQuestion1_6.Name = "LblQuestion1_6";
            LblQuestion1_6.Padding = new Padding(8, 0, 0, 0);
            LblQuestion1_6.Size = new Size(248, 40);
            LblQuestion1_6.TabIndex = 28;
            LblQuestion1_6.Text = "６．その他";
            LblQuestion1_6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblQuestion1_4
            // 
            LblQuestion1_4.Font = new Font("ＭＳ Ｐゴシック", 14.25F);
            LblQuestion1_4.Location = new Point(320, 440);
            LblQuestion1_4.Margin = new Padding(3, 0, 0, 0);
            LblQuestion1_4.Name = "LblQuestion1_4";
            LblQuestion1_4.Padding = new Padding(8, 0, 0, 0);
            LblQuestion1_4.Size = new Size(248, 40);
            LblQuestion1_4.TabIndex = 28;
            LblQuestion1_4.Text = "４．学校から紹介されて";
            LblQuestion1_4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblQuestion1_5
            // 
            LblQuestion1_5.Font = new Font("ＭＳ Ｐゴシック", 14.25F);
            LblQuestion1_5.Location = new Point(72, 480);
            LblQuestion1_5.Margin = new Padding(3, 0, 0, 0);
            LblQuestion1_5.Name = "LblQuestion1_5";
            LblQuestion1_5.Padding = new Padding(8, 0, 0, 0);
            LblQuestion1_5.Size = new Size(248, 40);
            LblQuestion1_5.TabIndex = 28;
            LblQuestion1_5.Text = "５．知人に紹介されて";
            LblQuestion1_5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblQuestion2_3
            // 
            LblQuestion2_3.Font = new Font("ＭＳ Ｐゴシック", 14.25F);
            LblQuestion2_3.Location = new Point(336, 560);
            LblQuestion2_3.Name = "LblQuestion2_3";
            LblQuestion2_3.Padding = new Padding(3, 0, 0, 0);
            LblQuestion2_3.Size = new Size(208, 40);
            LblQuestion2_3.TabIndex = 28;
            LblQuestion2_3.Text = "３．期待はずれだった";
            LblQuestion2_3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblQuestion2_2
            // 
            LblQuestion2_2.Font = new Font("ＭＳ Ｐゴシック", 14.25F);
            LblQuestion2_2.Location = new Point(224, 560);
            LblQuestion2_2.Name = "LblQuestion2_2";
            LblQuestion2_2.Padding = new Padding(3, 0, 0, 0);
            LblQuestion2_2.Size = new Size(112, 40);
            LblQuestion2_2.TabIndex = 28;
            LblQuestion2_2.Text = "２．ふつう";
            LblQuestion2_2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblQuestion1_3
            // 
            LblQuestion1_3.Font = new Font("ＭＳ Ｐゴシック", 14.25F);
            LblQuestion1_3.Location = new Point(72, 440);
            LblQuestion1_3.Margin = new Padding(3, 0, 0, 0);
            LblQuestion1_3.Name = "LblQuestion1_3";
            LblQuestion1_3.Padding = new Padding(8, 0, 0, 0);
            LblQuestion1_3.Size = new Size(248, 40);
            LblQuestion1_3.TabIndex = 28;
            LblQuestion1_3.Text = "３．書店店員に紹介されて";
            LblQuestion1_3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblComment
            // 
            LblComment.Font = new Font("ＭＳ Ｐゴシック", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblComment.Location = new Point(280, 696);
            LblComment.Name = "LblComment";
            LblComment.Size = new Size(288, 24);
            LblComment.TabIndex = 28;
            LblComment.Text = "ご回答ありがとうございました";
            LblComment.TextAlign = ContentAlignment.BottomLeft;
            // 
            // LblQuestion3_2
            // 
            LblQuestion3_2.Font = new Font("ＭＳ Ｐゴシック", 14.25F);
            LblQuestion3_2.Location = new Point(328, 640);
            LblQuestion3_2.Name = "LblQuestion3_2";
            LblQuestion3_2.Size = new Size(128, 24);
            LblQuestion3_2.TabIndex = 28;
            LblQuestion3_2.Text = "□希望しない";
            LblQuestion3_2.TextAlign = ContentAlignment.BottomLeft;
            // 
            // LblQuestion3_1
            // 
            LblQuestion3_1.Font = new Font("ＭＳ Ｐゴシック", 14.25F);
            LblQuestion3_1.Location = new Point(152, 640);
            LblQuestion3_1.Name = "LblQuestion3_1";
            LblQuestion3_1.Size = new Size(128, 24);
            LblQuestion3_1.TabIndex = 28;
            LblQuestion3_1.Text = "□希望する";
            LblQuestion3_1.TextAlign = ContentAlignment.BottomLeft;
            // 
            // LblQuestion2_1
            // 
            LblQuestion2_1.Font = new Font("ＭＳ Ｐゴシック", 14.25F);
            LblQuestion2_1.Location = new Point(72, 560);
            LblQuestion2_1.Name = "LblQuestion2_1";
            LblQuestion2_1.Padding = new Padding(3, 0, 0, 0);
            LblQuestion2_1.Size = new Size(152, 40);
            LblQuestion2_1.TabIndex = 28;
            LblQuestion2_1.Text = "１．役に立った";
            LblQuestion2_1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblQuestion1_2
            // 
            LblQuestion1_2.Font = new Font("ＭＳ Ｐゴシック", 14.25F);
            LblQuestion1_2.Location = new Point(320, 400);
            LblQuestion1_2.Margin = new Padding(3, 0, 0, 0);
            LblQuestion1_2.Name = "LblQuestion1_2";
            LblQuestion1_2.Padding = new Padding(8, 0, 0, 0);
            LblQuestion1_2.Size = new Size(248, 40);
            LblQuestion1_2.TabIndex = 28;
            LblQuestion1_2.Text = "２．チラシを見て";
            LblQuestion1_2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblQuestion1_1
            // 
            LblQuestion1_1.Font = new Font("ＭＳ Ｐゴシック", 14.25F);
            LblQuestion1_1.Location = new Point(72, 400);
            LblQuestion1_1.Margin = new Padding(3, 0, 0, 0);
            LblQuestion1_1.Name = "LblQuestion1_1";
            LblQuestion1_1.Padding = new Padding(8, 0, 0, 0);
            LblQuestion1_1.Size = new Size(248, 40);
            LblQuestion1_1.TabIndex = 28;
            LblQuestion1_1.Text = "１．書店で実物を見て";
            LblQuestion1_1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblKanaSimei_C
            // 
            LblKanaSimei_C.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblKanaSimei_C.Location = new Point(136, 104);
            LblKanaSimei_C.Name = "LblKanaSimei_C";
            LblKanaSimei_C.Size = new Size(440, 24);
            LblKanaSimei_C.TabIndex = 28;
            LblKanaSimei_C.Text = "アイウエオカキクケコサシスセソ";
            LblKanaSimei_C.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblKanaSimei_Q
            // 
            LblKanaSimei_Q.Font = new Font("ＭＳ Ｐゴシック", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblKanaSimei_Q.Location = new Point(64, 104);
            LblKanaSimei_Q.Name = "LblKanaSimei_Q";
            LblKanaSimei_Q.Size = new Size(72, 24);
            LblKanaSimei_Q.TabIndex = 28;
            LblKanaSimei_Q.Text = "フリガナ";
            LblKanaSimei_Q.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // EndTimer
            // 
            EndTimer.Tick += EndTimer_Tick;
            // 
            // RunTimer
            // 
            RunTimer.Tick += RunTimer_Tick;
            // 
            // Frmアンケートカード入力
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1316, 757);
            Controls.Add(PnlQuestionCard);
            Controls.Add(PnlInput);
            Name = "Frmアンケートカード入力";
            Text = "やってみよう！パソコンデータ入力";
            Load += Frmアンケートカード入力_Load;
            PnlInput.ResumeLayout(false);
            PnlInput.PerformLayout();
            GrpProgress.ResumeLayout(false);
            PnlQ3.ResumeLayout(false);
            PnlQ2.ResumeLayout(false);
            PnlQuestionCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PbxQ3).EndInit();
            ((System.ComponentModel.ISupportInitialize)PbxQ2).EndInit();
            ((System.ComponentModel.ISupportInitialize)PbxQ1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button BtnNext;
        private Button BtnCancel;
        private RadioButton RdiQ2_1;
        private CheckBox ChkQ3_1;
        private TextBox TxtCardNo;
        private Label LblNo;
        private Label LblKanaSimei;
        private TextBox TxtKanaSimei;
        private Label LblKanjiSimei;
        private TextBox TxtKanjiSimei;
        private Label LblPostNo;
        private TextBox TxtPostNo;
        private Button BtnPostNoSearch;
        private Label LblAddress;
        private TextBox TxtAddress;
        private Label LblTelNo;
        private TextBox TxtTelNo;
        private Label LblMailAddress;
        private TextBox TxtMailAddress;
        private Panel PnlInput;
        private Label LblQ1;
        private ComboBox CmbQ1;
        private Label LblQ2;
        private Panel PnlQ2;
        private Label LblQ3;
        private Panel PnlQ3;
        private RadioButton RdiQ2_4;
        private RadioButton RdiQ2_2;
        private RadioButton RdiQ2_3;
        private CheckBox ChkQ3_2;
        private Button BtnCheck;
        private GroupBox GrpProgress;
        private Label LblProgressCount2;
        private Label LblProgress22;
        private Label LblProgress12;
        private Panel PnlQuestionCard;
        private Label LblCardNo_C;
        private Label LblNo_Q;
        private Label LblTitle;
        private Label LineTitle;
        private Label LblKanjiSimei_Q;
        private Label LblKanaSimei_Q;
        private Label LineSimei;
        private Label LblKanjiSimei_C;
        private Label LblKanaSimei_C;
        private Label LineAddress;
        private Label LblAddress_C;
        private Label LblAddress_Q;
        private Label LblPostNo_C;
        private Label LineMailAddress;
        private Label LineTelNo;
        private Label LblMailAddress_C;
        private Label LblMailAddress_Q;
        private Label LblTelNo_C;
        private Label LblTelNo_Q;
        private Label LblQuestion1;
        private Label LblQuestion1_3;
        private Label LblQuestion1_1;
        private Label LblQuestion2;
        private Label LblQuestion1_6;
        private Label LblQuestion1_4;
        private Label LblQuestion1_5;
        private Label LblQuestion2_3;
        private Label LblQuestion2_2;
        private Label LblQuestion2_1;
        private Label LblQuestion1_2;
        private Label LblQuestion3;
        private Label LblComment;
        private Label LblQuestion3_2;
        private Label LblQuestion3_1;
        private System.Windows.Forms.Timer EndTimer;
        private Label LblProgressTimer;
        private Label LblProgress14;
        private Label LblProgressCount3;
        private Label LblProgress23;
        private Label LblProgress13;
        private Label LblProgressCount1;
        private Label LblProgress21;
        private Label LblProgress11;
        private System.Windows.Forms.Timer RunTimer;
        private ProgressBar PbTimer;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private PictureBox PbxQ1;
        private PictureBox PbxQ3;
        private PictureBox PbxQ2;
        private Label LblQ2Value;
        private Label LblQ1Value;
        private Label LblQ3Value;
    }
}
