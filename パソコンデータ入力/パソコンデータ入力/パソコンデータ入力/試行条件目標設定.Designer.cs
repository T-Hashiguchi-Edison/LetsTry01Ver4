namespace パソコンデータ入力

{
    partial class Frm試行条件目標設定
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
            BtnNext = new Button();
            BtnCancel = new Button();
            GrpTime = new GroupBox();
            RdiTime60 = new RadioButton();
            RdiTime45 = new RadioButton();
            RdiTime30 = new RadioButton();
            RdiTime15 = new RadioButton();
            GrpInputForm = new GroupBox();
            ChkInputForm = new CheckBox();
            ChkImage = new CheckBox();
            ChkTimer = new CheckBox();
            ChkRemain = new CheckBox();
            ChkProgress = new CheckBox();
            GrpGoal = new GroupBox();
            LblCorrectCnt2 = new Label();
            LblWorkCnt2 = new Label();
            LblCorrectCnt = new Label();
            LblWorkCnt = new Label();
            NudCorrectCnt = new NumericUpDown();
            NudWorkCnt = new NumericUpDown();
            GrpFeedback = new GroupBox();
            ChkErrorCheck = new CheckBox();
            ChkFinalFeedback = new CheckBox();
            ChkGraph = new CheckBox();
            GrpTime.SuspendLayout();
            GrpInputForm.SuspendLayout();
            GrpGoal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NudCorrectCnt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NudWorkCnt).BeginInit();
            GrpFeedback.SuspendLayout();
            SuspendLayout();
            // 
            // BtnNext
            // 
            BtnNext.Location = new Point(280, 536);
            BtnNext.Name = "BtnNext";
            BtnNext.Size = new Size(184, 32);
            BtnNext.TabIndex = 23;
            BtnNext.Text = "次へ";
            BtnNext.UseVisualStyleBackColor = true;
            BtnNext.Click += BtnNext_Click;
            // 
            // BtnCancel
            // 
            BtnCancel.Location = new Point(472, 536);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(184, 32);
            BtnCancel.TabIndex = 24;
            BtnCancel.Text = "キャンセル";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // GrpTime
            // 
            GrpTime.Controls.Add(RdiTime60);
            GrpTime.Controls.Add(RdiTime45);
            GrpTime.Controls.Add(RdiTime30);
            GrpTime.Controls.Add(RdiTime15);
            GrpTime.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            GrpTime.Location = new Point(24, 16);
            GrpTime.Name = "GrpTime";
            GrpTime.Size = new Size(632, 72);
            GrpTime.TabIndex = 1;
            GrpTime.TabStop = false;
            GrpTime.Text = "終了時間";
            // 
            // RdiTime60
            // 
            RdiTime60.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            RdiTime60.Location = new Point(296, 32);
            RdiTime60.Name = "RdiTime60";
            RdiTime60.Size = new Size(88, 32);
            RdiTime60.TabIndex = 5;
            RdiTime60.TabStop = true;
            RdiTime60.Text = "60分";
            RdiTime60.UseVisualStyleBackColor = true;
            // 
            // RdiTime45
            // 
            RdiTime45.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            RdiTime45.Location = new Point(208, 32);
            RdiTime45.Name = "RdiTime45";
            RdiTime45.Size = new Size(88, 32);
            RdiTime45.TabIndex = 4;
            RdiTime45.TabStop = true;
            RdiTime45.Text = "45分";
            RdiTime45.UseVisualStyleBackColor = true;
            // 
            // RdiTime30
            // 
            RdiTime30.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            RdiTime30.Location = new Point(120, 32);
            RdiTime30.Name = "RdiTime30";
            RdiTime30.Size = new Size(88, 32);
            RdiTime30.TabIndex = 3;
            RdiTime30.TabStop = true;
            RdiTime30.Text = "30分";
            RdiTime30.UseVisualStyleBackColor = true;
            // 
            // RdiTime15
            // 
            RdiTime15.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            RdiTime15.Location = new Point(32, 32);
            RdiTime15.Name = "RdiTime15";
            RdiTime15.Size = new Size(88, 32);
            RdiTime15.TabIndex = 2;
            RdiTime15.TabStop = true;
            RdiTime15.Text = "15分";
            RdiTime15.UseVisualStyleBackColor = true;
            // 
            // GrpInputForm
            // 
            GrpInputForm.Controls.Add(ChkInputForm);
            GrpInputForm.Controls.Add(ChkImage);
            GrpInputForm.Controls.Add(ChkTimer);
            GrpInputForm.Controls.Add(ChkRemain);
            GrpInputForm.Controls.Add(ChkProgress);
            GrpInputForm.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            GrpInputForm.Location = new Point(24, 96);
            GrpInputForm.Name = "GrpInputForm";
            GrpInputForm.Size = new Size(632, 200);
            GrpInputForm.TabIndex = 6;
            GrpInputForm.TabStop = false;
            GrpInputForm.Text = "入力画面の設定";
            // 
            // ChkInputForm
            // 
            ChkInputForm.Location = new Point(32, 160);
            ChkInputForm.Name = "ChkInputForm";
            ChkInputForm.Size = new Size(560, 32);
            ChkInputForm.TabIndex = 11;
            ChkInputForm.Text = "入力画面の拡大";
            ChkInputForm.UseVisualStyleBackColor = true;
            // 
            // ChkImage
            // 
            ChkImage.Location = new Point(32, 128);
            ChkImage.Name = "ChkImage";
            ChkImage.Size = new Size(560, 32);
            ChkImage.TabIndex = 10;
            ChkImage.Text = "印刷物イメージの拡大";
            ChkImage.UseVisualStyleBackColor = true;
            // 
            // ChkTimer
            // 
            ChkTimer.Location = new Point(32, 64);
            ChkTimer.Name = "ChkTimer";
            ChkTimer.Size = new Size(560, 32);
            ChkTimer.TabIndex = 8;
            ChkTimer.Text = "タイマーを表示する";
            ChkTimer.UseVisualStyleBackColor = true;
            // 
            // ChkRemain
            // 
            ChkRemain.Location = new Point(32, 96);
            ChkRemain.Name = "ChkRemain";
            ChkRemain.Size = new Size(560, 32);
            ChkRemain.TabIndex = 9;
            ChkRemain.Text = "残り時間を表示する";
            ChkRemain.UseVisualStyleBackColor = true;
            // 
            // ChkProgress
            // 
            ChkProgress.Location = new Point(32, 32);
            ChkProgress.Name = "ChkProgress";
            ChkProgress.Size = new Size(560, 32);
            ChkProgress.TabIndex = 7;
            ChkProgress.Text = "進捗状況画面を表示する";
            ChkProgress.UseVisualStyleBackColor = true;
            // 
            // GrpGoal
            // 
            GrpGoal.Controls.Add(LblCorrectCnt2);
            GrpGoal.Controls.Add(LblWorkCnt2);
            GrpGoal.Controls.Add(LblCorrectCnt);
            GrpGoal.Controls.Add(LblWorkCnt);
            GrpGoal.Controls.Add(NudCorrectCnt);
            GrpGoal.Controls.Add(NudWorkCnt);
            GrpGoal.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            GrpGoal.Location = new Point(24, 304);
            GrpGoal.Name = "GrpGoal";
            GrpGoal.Size = new Size(632, 72);
            GrpGoal.TabIndex = 12;
            GrpGoal.TabStop = false;
            GrpGoal.Text = "目標設定";
            // 
            // LblCorrectCnt2
            // 
            LblCorrectCnt2.Location = new Point(408, 32);
            LblCorrectCnt2.Name = "LblCorrectCnt2";
            LblCorrectCnt2.Size = new Size(32, 24);
            LblCorrectCnt2.TabIndex = 18;
            LblCorrectCnt2.Text = "枚";
            LblCorrectCnt2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblWorkCnt2
            // 
            LblWorkCnt2.Location = new Point(184, 32);
            LblWorkCnt2.Name = "LblWorkCnt2";
            LblWorkCnt2.Size = new Size(32, 24);
            LblWorkCnt2.TabIndex = 17;
            LblWorkCnt2.Text = "枚";
            LblWorkCnt2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblCorrectCnt
            // 
            LblCorrectCnt.Location = new Point(232, 32);
            LblCorrectCnt.Name = "LblCorrectCnt";
            LblCorrectCnt.Size = new Size(112, 24);
            LblCorrectCnt.TabIndex = 15;
            LblCorrectCnt.Text = "正しい枚数";
            LblCorrectCnt.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblWorkCnt
            // 
            LblWorkCnt.Location = new Point(24, 32);
            LblWorkCnt.Name = "LblWorkCnt";
            LblWorkCnt.Size = new Size(96, 24);
            LblWorkCnt.TabIndex = 13;
            LblWorkCnt.Text = "作業枚数";
            LblWorkCnt.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // NudCorrectCnt
            // 
            NudCorrectCnt.Location = new Point(344, 32);
            NudCorrectCnt.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            NudCorrectCnt.Name = "NudCorrectCnt";
            NudCorrectCnt.Size = new Size(64, 26);
            NudCorrectCnt.TabIndex = 16;
            NudCorrectCnt.TextAlign = HorizontalAlignment.Right;
            // 
            // NudWorkCnt
            // 
            NudWorkCnt.Location = new Point(120, 32);
            NudWorkCnt.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            NudWorkCnt.Name = "NudWorkCnt";
            NudWorkCnt.Size = new Size(64, 26);
            NudWorkCnt.TabIndex = 14;
            NudWorkCnt.TextAlign = HorizontalAlignment.Right;
            // 
            // GrpFeedback
            // 
            GrpFeedback.Controls.Add(ChkErrorCheck);
            GrpFeedback.Controls.Add(ChkFinalFeedback);
            GrpFeedback.Controls.Add(ChkGraph);
            GrpFeedback.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            GrpFeedback.Location = new Point(24, 384);
            GrpFeedback.Name = "GrpFeedback";
            GrpFeedback.Size = new Size(632, 136);
            GrpFeedback.TabIndex = 19;
            GrpFeedback.TabStop = false;
            GrpFeedback.Text = "フィードバックの設定";
            // 
            // ChkErrorCheck
            // 
            ChkErrorCheck.Location = new Point(32, 64);
            ChkErrorCheck.Name = "ChkErrorCheck";
            ChkErrorCheck.Size = new Size(560, 32);
            ChkErrorCheck.TabIndex = 21;
            ChkErrorCheck.Text = "エラーチェック結果のフィードバックをする";
            ChkErrorCheck.UseVisualStyleBackColor = true;
            // 
            // ChkFinalFeedback
            // 
            ChkFinalFeedback.Location = new Point(32, 96);
            ChkFinalFeedback.Name = "ChkFinalFeedback";
            ChkFinalFeedback.Size = new Size(560, 32);
            ChkFinalFeedback.TabIndex = 22;
            ChkFinalFeedback.Text = "最終フィードバックをする";
            ChkFinalFeedback.UseVisualStyleBackColor = true;
            // 
            // ChkGraph
            // 
            ChkGraph.Location = new Point(32, 32);
            ChkGraph.Name = "ChkGraph";
            ChkGraph.Size = new Size(560, 32);
            ChkGraph.TabIndex = 20;
            ChkGraph.Text = "グラフを表示する";
            ChkGraph.UseVisualStyleBackColor = true;
            // 
            // Frm試行条件目標設定
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(673, 571);
            Controls.Add(GrpFeedback);
            Controls.Add(GrpInputForm);
            Controls.Add(GrpGoal);
            Controls.Add(GrpTime);
            Controls.Add(BtnCancel);
            Controls.Add(BtnNext);
            Name = "Frm試行条件目標設定";
            Text = "やってみよう！パソコンデータ入力";
            Load += Frm試行条件目標設定_Load;
            GrpTime.ResumeLayout(false);
            GrpInputForm.ResumeLayout(false);
            GrpGoal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NudCorrectCnt).EndInit();
            ((System.ComponentModel.ISupportInitialize)NudWorkCnt).EndInit();
            GrpFeedback.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button BtnNext;
        private Button BtnCancel;
        private GroupBox GrpTime;
        private RadioButton RdiTime60;
        private RadioButton RdiTime45;
        private RadioButton RdiTime30;
        private RadioButton RdiTime15;
        private GroupBox GrpInputForm;
        private CheckBox ChkProgress;
        private CheckBox ChkInputForm;
        private CheckBox ChkImage;
        private CheckBox ChkTimer;
        private CheckBox ChkRemain;
        private GroupBox GrpGoal;
        private NumericUpDown NudCorrectCnt;
        private NumericUpDown NudWorkCnt;
        private Label LblCorrectCnt2;
        private Label LblWorkCnt2;
        private Label LblCorrectCnt;
        private Label LblWorkCnt;
        private GroupBox GrpFeedback;
        private CheckBox ChkErrorCheck;
        private CheckBox ChkFinalFeedback;
        private CheckBox ChkGraph;
    }
}
