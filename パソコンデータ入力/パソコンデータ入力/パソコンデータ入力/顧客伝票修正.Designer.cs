namespace パソコンデータ入力
{
    partial class Frm顧客伝票修正
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
            TxtCardNo = new TextBox();
            LblNo = new Label();
            LblCustCd = new Label();
            TxtCustCd = new TextBox();
            LblItemCd = new Label();
            TxtItemCd = new TextBox();
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
            BtnCheck = new Button();
            PnlQuestionCard = new Panel();
            LblCardNo_C = new Label();
            LineMailAddress = new Label();
            LineTelNo = new Label();
            LineItemCd = new Label();
            LineCustCd = new Label();
            LineTitle = new Label();
            LblNo_Q = new Label();
            LblMailAddress_C = new Label();
            LblMailAddress_Q = new Label();
            LblTelNo_C = new Label();
            LblTelNo_Q = new Label();
            LblItemCd_C = new Label();
            LblItemCd_Q = new Label();
            LblCustCd_C = new Label();
            LblCustCd_Q = new Label();
            LblTitle = new Label();
            EndTimer = new System.Windows.Forms.Timer(components);
            RunTimer = new System.Windows.Forms.Timer(components);
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            PnlInput.SuspendLayout();
            GrpProgress.SuspendLayout();
            PnlQuestionCard.SuspendLayout();
            SuspendLayout();
            // 
            // BtnNext
            // 
            BtnNext.Font = new Font("ＭＳ Ｐゴシック", 27.75F);
            BtnNext.Location = new Point(320, 664);
            BtnNext.Name = "BtnNext";
            BtnNext.Size = new Size(240, 56);
            BtnNext.TabIndex = 5;
            BtnNext.Text = "次へ(N)";
            BtnNext.UseVisualStyleBackColor = true;
            BtnNext.Click += BtnNext_Click;
            // 
            // BtnCancel
            // 
            BtnCancel.Font = new Font("ＭＳ Ｐゴシック", 27.75F);
            BtnCancel.Location = new Point(640, 752);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(176, 56);
            BtnCancel.TabIndex = 7;
            BtnCancel.Text = "中止(C)";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // TxtCardNo
            // 
            TxtCardNo.BorderStyle = BorderStyle.None;
            TxtCardNo.Enabled = false;
            TxtCardNo.Font = new Font("ＭＳ Ｐゴシック", 27.75F);
            TxtCardNo.ForeColor = SystemColors.ControlText;
            TxtCardNo.ImeMode = ImeMode.Off;
            TxtCardNo.Location = new Point(144, 114);
            TxtCardNo.MaxLength = 4;
            TxtCardNo.Name = "TxtCardNo";
            TxtCardNo.ReadOnly = true;
            TxtCardNo.Size = new Size(104, 37);
            TxtCardNo.TabIndex = 0;
            TxtCardNo.Text = "0001";
            // 
            // LblNo
            // 
            LblNo.BackColor = SystemColors.Control;
            LblNo.Font = new Font("ＭＳ Ｐゴシック", 27.75F);
            LblNo.Location = new Point(24, 112);
            LblNo.Name = "LblNo";
            LblNo.Size = new Size(120, 40);
            LblNo.TabIndex = 8;
            LblNo.Text = "NO.";
            LblNo.TextAlign = ContentAlignment.BottomRight;
            // 
            // LblCustCd
            // 
            LblCustCd.Font = new Font("ＭＳ Ｐゴシック", 27.75F);
            LblCustCd.Location = new Point(0, 216);
            LblCustCd.Name = "LblCustCd";
            LblCustCd.Size = new Size(248, 40);
            LblCustCd.TabIndex = 9;
            LblCustCd.Text = "顧客コード";
            LblCustCd.TextAlign = ContentAlignment.BottomRight;
            // 
            // TxtCustCd
            // 
            TxtCustCd.Font = new Font("ＭＳ Ｐゴシック", 27.75F);
            TxtCustCd.ImeMode = ImeMode.Off;
            TxtCustCd.Location = new Point(248, 216);
            TxtCustCd.MaxLength = 30;
            TxtCustCd.Name = "TxtCustCd";
            TxtCustCd.Size = new Size(584, 44);
            TxtCustCd.TabIndex = 1;
            TxtCustCd.Text = "ABCDEFGHIJ";
            // 
            // LblItemCd
            // 
            LblItemCd.Font = new Font("ＭＳ Ｐゴシック", 27.75F);
            LblItemCd.Location = new Point(0, 296);
            LblItemCd.Name = "LblItemCd";
            LblItemCd.Size = new Size(248, 40);
            LblItemCd.TabIndex = 10;
            LblItemCd.Text = "商品コード";
            LblItemCd.TextAlign = ContentAlignment.BottomRight;
            // 
            // TxtItemCd
            // 
            TxtItemCd.Font = new Font("ＭＳ Ｐゴシック", 27.75F);
            TxtItemCd.ImeMode = ImeMode.Off;
            TxtItemCd.Location = new Point(248, 296);
            TxtItemCd.MaxLength = 20;
            TxtItemCd.Name = "TxtItemCd";
            TxtItemCd.Size = new Size(584, 44);
            TxtItemCd.TabIndex = 2;
            TxtItemCd.Text = "ABCDEFGHIJKLMNO";
            // 
            // LblTelNo
            // 
            LblTelNo.Font = new Font("ＭＳ Ｐゴシック", 27.75F);
            LblTelNo.Location = new Point(0, 376);
            LblTelNo.Name = "LblTelNo";
            LblTelNo.Size = new Size(248, 40);
            LblTelNo.TabIndex = 11;
            LblTelNo.Text = "電話番号";
            LblTelNo.TextAlign = ContentAlignment.BottomRight;
            // 
            // TxtTelNo
            // 
            TxtTelNo.Font = new Font("ＭＳ Ｐゴシック", 27.75F);
            TxtTelNo.ImeMode = ImeMode.Off;
            TxtTelNo.Location = new Point(248, 376);
            TxtTelNo.MaxLength = 30;
            TxtTelNo.Name = "TxtTelNo";
            TxtTelNo.Size = new Size(584, 44);
            TxtTelNo.TabIndex = 3;
            TxtTelNo.Text = "090-0000-0000";
            // 
            // LblMailAddress
            // 
            LblMailAddress.Font = new Font("ＭＳ Ｐゴシック", 27.75F);
            LblMailAddress.Location = new Point(0, 456);
            LblMailAddress.Name = "LblMailAddress";
            LblMailAddress.Size = new Size(248, 40);
            LblMailAddress.TabIndex = 12;
            LblMailAddress.Text = "メールアドレス";
            LblMailAddress.TextAlign = ContentAlignment.BottomRight;
            // 
            // TxtMailAddress
            // 
            TxtMailAddress.Font = new Font("ＭＳ Ｐゴシック", 27.75F);
            TxtMailAddress.ImeMode = ImeMode.Off;
            TxtMailAddress.Location = new Point(248, 456);
            TxtMailAddress.MaxLength = 80;
            TxtMailAddress.Name = "TxtMailAddress";
            TxtMailAddress.Size = new Size(584, 44);
            TxtMailAddress.TabIndex = 4;
            TxtMailAddress.Text = "abcdefghij12345678@abcdefghi.ne.jp";
            // 
            // PnlInput
            // 
            PnlInput.Controls.Add(PbTimer);
            PnlInput.Controls.Add(GrpProgress);
            PnlInput.Controls.Add(BtnCheck);
            PnlInput.Controls.Add(BtnCancel);
            PnlInput.Controls.Add(BtnNext);
            PnlInput.Controls.Add(LblNo);
            PnlInput.Controls.Add(LblMailAddress);
            PnlInput.Controls.Add(TxtMailAddress);
            PnlInput.Controls.Add(TxtCardNo);
            PnlInput.Controls.Add(LblTelNo);
            PnlInput.Controls.Add(TxtCustCd);
            PnlInput.Controls.Add(TxtTelNo);
            PnlInput.Controls.Add(LblCustCd);
            PnlInput.Controls.Add(TxtItemCd);
            PnlInput.Controls.Add(LblItemCd);
            PnlInput.Location = new Point(824, 0);
            PnlInput.Name = "PnlInput";
            PnlInput.Size = new Size(856, 832);
            PnlInput.TabIndex = 0;
            // 
            // PbTimer
            // 
            PbTimer.Location = new Point(616, 112);
            PbTimer.Name = "PbTimer";
            PbTimer.Size = new Size(216, 23);
            PbTimer.Style = ProgressBarStyle.Continuous;
            PbTimer.TabIndex = 14;
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
            GrpProgress.Location = new Point(616, 8);
            GrpProgress.Name = "GrpProgress";
            GrpProgress.Size = new Size(216, 96);
            GrpProgress.TabIndex = 13;
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
            LblProgress11.TabIndex = 1;
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
            LblProgressTimer.TabIndex = 0;
            LblProgressTimer.Text = "99分99秒";
            LblProgressTimer.TextAlign = ContentAlignment.BottomLeft;
            // 
            // LblProgress14
            // 
            LblProgress14.Font = new Font("ＭＳ 明朝", 12F);
            LblProgress14.Location = new Point(8, 72);
            LblProgress14.Name = "LblProgress14";
            LblProgress14.Size = new Size(128, 16);
            LblProgress14.TabIndex = 10;
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
            LblProgressCount3.TabIndex = 8;
            LblProgressCount3.Text = "999";
            LblProgressCount3.TextAlign = ContentAlignment.BottomRight;
            // 
            // LblProgress23
            // 
            LblProgress23.Font = new Font("ＭＳ 明朝", 12F);
            LblProgress23.Location = new Point(168, 56);
            LblProgress23.Name = "LblProgress23";
            LblProgress23.Size = new Size(24, 16);
            LblProgress23.TabIndex = 9;
            LblProgress23.Text = "枚";
            LblProgress23.TextAlign = ContentAlignment.BottomRight;
            // 
            // LblProgress13
            // 
            LblProgress13.Font = new Font("ＭＳ 明朝", 12F);
            LblProgress13.Location = new Point(8, 56);
            LblProgress13.Name = "LblProgress13";
            LblProgress13.Size = new Size(128, 16);
            LblProgress13.TabIndex = 7;
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
            LblProgressCount1.TabIndex = 2;
            LblProgressCount1.Text = "999";
            LblProgressCount1.TextAlign = ContentAlignment.BottomRight;
            // 
            // LblProgress21
            // 
            LblProgress21.Font = new Font("ＭＳ 明朝", 12F);
            LblProgress21.Location = new Point(168, 24);
            LblProgress21.Name = "LblProgress21";
            LblProgress21.Size = new Size(24, 16);
            LblProgress21.TabIndex = 3;
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
            LblProgressCount2.TabIndex = 5;
            LblProgressCount2.Text = "999";
            LblProgressCount2.TextAlign = ContentAlignment.BottomRight;
            // 
            // LblProgress22
            // 
            LblProgress22.Font = new Font("ＭＳ 明朝", 12F);
            LblProgress22.Location = new Point(168, 40);
            LblProgress22.Name = "LblProgress22";
            LblProgress22.Size = new Size(24, 16);
            LblProgress22.TabIndex = 6;
            LblProgress22.Text = "枚";
            LblProgress22.TextAlign = ContentAlignment.BottomRight;
            // 
            // LblProgress12
            // 
            LblProgress12.Font = new Font("ＭＳ 明朝", 12F);
            LblProgress12.Location = new Point(8, 40);
            LblProgress12.Name = "LblProgress12";
            LblProgress12.Size = new Size(128, 16);
            LblProgress12.TabIndex = 4;
            LblProgress12.Text = "目標正解枚数：";
            LblProgress12.TextAlign = ContentAlignment.BottomRight;
            // 
            // BtnCheck
            // 
            BtnCheck.Font = new Font("ＭＳ Ｐゴシック", 27.75F);
            BtnCheck.Location = new Point(24, 728);
            BtnCheck.Name = "BtnCheck";
            BtnCheck.Size = new Size(208, 56);
            BtnCheck.TabIndex = 6;
            BtnCheck.Text = "チェック(A)";
            BtnCheck.UseVisualStyleBackColor = true;
            BtnCheck.Click += BtnCheck_Click;
            // 
            // PnlQuestionCard
            // 
            PnlQuestionCard.BackColor = Color.White;
            PnlQuestionCard.Controls.Add(LblCardNo_C);
            PnlQuestionCard.Controls.Add(LineMailAddress);
            PnlQuestionCard.Controls.Add(LineTelNo);
            PnlQuestionCard.Controls.Add(LineItemCd);
            PnlQuestionCard.Controls.Add(LineCustCd);
            PnlQuestionCard.Controls.Add(LineTitle);
            PnlQuestionCard.Controls.Add(LblNo_Q);
            PnlQuestionCard.Controls.Add(LblMailAddress_C);
            PnlQuestionCard.Controls.Add(LblMailAddress_Q);
            PnlQuestionCard.Controls.Add(LblTelNo_C);
            PnlQuestionCard.Controls.Add(LblTelNo_Q);
            PnlQuestionCard.Controls.Add(LblItemCd_C);
            PnlQuestionCard.Controls.Add(LblItemCd_Q);
            PnlQuestionCard.Controls.Add(LblCustCd_C);
            PnlQuestionCard.Controls.Add(LblCustCd_Q);
            PnlQuestionCard.Controls.Add(LblTitle);
            PnlQuestionCard.Location = new Point(0, 80);
            PnlQuestionCard.Name = "PnlQuestionCard";
            PnlQuestionCard.Size = new Size(824, 480);
            PnlQuestionCard.TabIndex = 1;
            // 
            // LblCardNo_C
            // 
            LblCardNo_C.Font = new Font("ＭＳ Ｐゴシック", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblCardNo_C.Location = new Point(672, 24);
            LblCardNo_C.Name = "LblCardNo_C";
            LblCardNo_C.Size = new Size(88, 48);
            LblCardNo_C.TabIndex = 2;
            LblCardNo_C.Text = "9999";
            LblCardNo_C.TextAlign = ContentAlignment.BottomLeft;
            // 
            // LineMailAddress
            // 
            LineMailAddress.BorderStyle = BorderStyle.FixedSingle;
            LineMailAddress.Font = new Font("ＭＳ Ｐゴシック", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LineMailAddress.Location = new Point(216, 424);
            LineMailAddress.Name = "LineMailAddress";
            LineMailAddress.Size = new Size(592, 1);
            LineMailAddress.TabIndex = 15;
            LineMailAddress.TextAlign = ContentAlignment.BottomCenter;
            // 
            // LineTelNo
            // 
            LineTelNo.BorderStyle = BorderStyle.FixedSingle;
            LineTelNo.Font = new Font("ＭＳ Ｐゴシック", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LineTelNo.Location = new Point(216, 344);
            LineTelNo.Name = "LineTelNo";
            LineTelNo.Size = new Size(592, 1);
            LineTelNo.TabIndex = 12;
            LineTelNo.TextAlign = ContentAlignment.BottomCenter;
            // 
            // LineItemCd
            // 
            LineItemCd.BorderStyle = BorderStyle.FixedSingle;
            LineItemCd.Font = new Font("ＭＳ Ｐゴシック", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LineItemCd.Location = new Point(216, 264);
            LineItemCd.Name = "LineItemCd";
            LineItemCd.Size = new Size(592, 1);
            LineItemCd.TabIndex = 9;
            LineItemCd.TextAlign = ContentAlignment.BottomCenter;
            // 
            // LineCustCd
            // 
            LineCustCd.BorderStyle = BorderStyle.FixedSingle;
            LineCustCd.Font = new Font("ＭＳ Ｐゴシック", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LineCustCd.Location = new Point(216, 184);
            LineCustCd.Name = "LineCustCd";
            LineCustCd.Size = new Size(592, 1);
            LineCustCd.TabIndex = 6;
            LineCustCd.TextAlign = ContentAlignment.BottomCenter;
            // 
            // LineTitle
            // 
            LineTitle.BorderStyle = BorderStyle.FixedSingle;
            LineTitle.Font = new Font("ＭＳ Ｐゴシック", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LineTitle.Location = new Point(324, 72);
            LineTitle.Name = "LineTitle";
            LineTitle.Size = new Size(176, 2);
            LineTitle.TabIndex = 3;
            LineTitle.TextAlign = ContentAlignment.BottomCenter;
            // 
            // LblNo_Q
            // 
            LblNo_Q.Font = new Font("ＭＳ Ｐゴシック", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblNo_Q.Location = new Point(608, 24);
            LblNo_Q.Name = "LblNo_Q";
            LblNo_Q.Size = new Size(64, 48);
            LblNo_Q.TabIndex = 1;
            LblNo_Q.Text = "NO.";
            LblNo_Q.TextAlign = ContentAlignment.BottomRight;
            // 
            // LblMailAddress_C
            // 
            LblMailAddress_C.Font = new Font("ＭＳ Ｐゴシック", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblMailAddress_C.Location = new Point(216, 376);
            LblMailAddress_C.Name = "LblMailAddress_C";
            LblMailAddress_C.Size = new Size(592, 48);
            LblMailAddress_C.TabIndex = 14;
            LblMailAddress_C.Text = "abcdefghij12345678@abcdefghi.ne.jp";
            LblMailAddress_C.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblMailAddress_Q
            // 
            LblMailAddress_Q.Font = new Font("ＭＳ Ｐゴシック", 21.75F, FontStyle.Bold);
            LblMailAddress_Q.Location = new Point(16, 384);
            LblMailAddress_Q.Name = "LblMailAddress_Q";
            LblMailAddress_Q.Size = new Size(200, 40);
            LblMailAddress_Q.TabIndex = 13;
            LblMailAddress_Q.Text = "メールアドレス";
            LblMailAddress_Q.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblTelNo_C
            // 
            LblTelNo_C.Font = new Font("ＭＳ Ｐゴシック", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblTelNo_C.Location = new Point(216, 296);
            LblTelNo_C.Name = "LblTelNo_C";
            LblTelNo_C.Size = new Size(592, 48);
            LblTelNo_C.TabIndex = 11;
            LblTelNo_C.Text = "090-0000-0000";
            LblTelNo_C.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblTelNo_Q
            // 
            LblTelNo_Q.Font = new Font("ＭＳ Ｐゴシック", 21.75F, FontStyle.Bold);
            LblTelNo_Q.Location = new Point(16, 304);
            LblTelNo_Q.Name = "LblTelNo_Q";
            LblTelNo_Q.Size = new Size(200, 40);
            LblTelNo_Q.TabIndex = 10;
            LblTelNo_Q.Text = "電話番号";
            LblTelNo_Q.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblItemCd_C
            // 
            LblItemCd_C.Font = new Font("ＭＳ Ｐゴシック", 27.75F);
            LblItemCd_C.Location = new Point(216, 216);
            LblItemCd_C.Name = "LblItemCd_C";
            LblItemCd_C.Size = new Size(592, 48);
            LblItemCd_C.TabIndex = 8;
            LblItemCd_C.Text = "ABCDEFGHIJKLMNO";
            LblItemCd_C.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblItemCd_Q
            // 
            LblItemCd_Q.Font = new Font("ＭＳ Ｐゴシック", 21.75F, FontStyle.Bold);
            LblItemCd_Q.Location = new Point(16, 224);
            LblItemCd_Q.Name = "LblItemCd_Q";
            LblItemCd_Q.Size = new Size(200, 40);
            LblItemCd_Q.TabIndex = 7;
            LblItemCd_Q.Text = "商品コード";
            LblItemCd_Q.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblCustCd_C
            // 
            LblCustCd_C.Font = new Font("ＭＳ Ｐゴシック", 27.75F);
            LblCustCd_C.Location = new Point(216, 136);
            LblCustCd_C.Name = "LblCustCd_C";
            LblCustCd_C.Size = new Size(592, 48);
            LblCustCd_C.TabIndex = 5;
            LblCustCd_C.Text = "ABCDEFGHIJ";
            LblCustCd_C.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblCustCd_Q
            // 
            LblCustCd_Q.Font = new Font("ＭＳ Ｐゴシック", 21.75F, FontStyle.Bold);
            LblCustCd_Q.Location = new Point(16, 144);
            LblCustCd_Q.Name = "LblCustCd_Q";
            LblCustCd_Q.Size = new Size(200, 40);
            LblCustCd_Q.TabIndex = 4;
            LblCustCd_Q.Text = "顧客コード";
            LblCustCd_Q.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblTitle
            // 
            LblTitle.Font = new Font("ＭＳ Ｐゴシック", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblTitle.Location = new Point(324, 16);
            LblTitle.Name = "LblTitle";
            LblTitle.Size = new Size(176, 56);
            LblTitle.TabIndex = 0;
            LblTitle.Text = "顧客伝票";
            LblTitle.TextAlign = ContentAlignment.BottomCenter;
            // 
            // EndTimer
            // 
            EndTimer.Tick += EndTimer_Tick;
            // 
            // RunTimer
            // 
            RunTimer.Tick += RunTimer_Tick;
            // 
            // Frm顧客伝票修正
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1680, 833);
            Controls.Add(PnlQuestionCard);
            Controls.Add(PnlInput);
            Name = "Frm顧客伝票修正";
            Text = "やってみよう！パソコンデータ入力";
            Load += Frm顧客伝票修正_Load;
            PnlInput.ResumeLayout(false);
            PnlInput.PerformLayout();
            GrpProgress.ResumeLayout(false);
            PnlQuestionCard.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button BtnNext;
        private Button BtnCancel;
        private TextBox TxtCardNo;
        private Label LblNo;
        private Label LblCustCd;
        private TextBox TxtCustCd;
        private Label LblItemCd;
        private TextBox TxtItemCd;
        private Label LblTelNo;
        private TextBox TxtTelNo;
        private Label LblMailAddress;
        private TextBox TxtMailAddress;
        private Panel PnlInput;
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
        private Label LblCustCd_Q;
        private Label LineCustCd;
        private Label LblCustCd_C;
        private Label LineMailAddress;
        private Label LineTelNo;
        private Label LblMailAddress_C;
        private Label LblMailAddress_Q;
        private Label LblTelNo_C;
        private Label LblTelNo_Q;
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
        private Label LineItemCd;
        private Label LblItemCd_C;
        private Label LblItemCd_Q;
    }
}
