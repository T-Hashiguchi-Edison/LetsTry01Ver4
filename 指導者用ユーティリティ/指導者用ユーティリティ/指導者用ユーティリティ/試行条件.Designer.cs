namespace 指導者用ユーティリティ
{
    partial class Frm試行条件
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            BtnOk = new Button();
            BtnCancel = new Button();
            LblFormQuestion = new Label();
            GrpTeiji = new GroupBox();
            RdiTeiji2 = new RadioButton();
            RdiTeiji1 = new RadioButton();
            GrpStart = new GroupBox();
            NudStart = new NumericUpDown();
            RdiStart2 = new RadioButton();
            RdiStart1 = new RadioButton();
            GrpForm = new GroupBox();
            PnlFormQuestion = new Panel();
            RdiFormQuestion1 = new RadioButton();
            RdiFormQuestion2 = new RadioButton();
            ChkZipSearch = new CheckBox();
            ChkFormQuestion = new CheckBox();
            BtnReport = new Button();
            GrpTeiji.SuspendLayout();
            GrpStart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NudStart).BeginInit();
            GrpForm.SuspendLayout();
            PnlFormQuestion.SuspendLayout();
            SuspendLayout();
            // 
            // BtnOk
            // 
            BtnOk.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            BtnOk.Location = new Point(401, 430);
            BtnOk.Margin = new Padding(4);
            BtnOk.Name = "BtnOk";
            BtnOk.Size = new Size(149, 40);
            BtnOk.TabIndex = 15;
            BtnOk.Text = "OK";
            BtnOk.UseVisualStyleBackColor = true;
            BtnOk.Click += BtnOk_Click;
            // 
            // BtnCancel
            // 
            BtnCancel.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            BtnCancel.Location = new Point(588, 430);
            BtnCancel.Margin = new Padding(4);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(149, 40);
            BtnCancel.TabIndex = 16;
            BtnCancel.Text = "キャンセル";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // LblFormQuestion
            // 
            LblFormQuestion.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblFormQuestion.Location = new Point(65, 70);
            LblFormQuestion.Margin = new Padding(4, 0, 4, 0);
            LblFormQuestion.Name = "LblFormQuestion";
            LblFormQuestion.Size = new Size(103, 50);
            LblFormQuestion.TabIndex = 9;
            LblFormQuestion.Text = "表示位置";
            LblFormQuestion.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // GrpTeiji
            // 
            GrpTeiji.Controls.Add(RdiTeiji2);
            GrpTeiji.Controls.Add(RdiTeiji1);
            GrpTeiji.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            GrpTeiji.Location = new Point(37, 30);
            GrpTeiji.Margin = new Padding(4);
            GrpTeiji.Name = "GrpTeiji";
            GrpTeiji.Padding = new Padding(4);
            GrpTeiji.Size = new Size(700, 90);
            GrpTeiji.TabIndex = 0;
            GrpTeiji.TabStop = false;
            GrpTeiji.Text = "呈示方法";
            // 
            // RdiTeiji2
            // 
            RdiTeiji2.AutoSize = true;
            RdiTeiji2.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            RdiTeiji2.Location = new Point(224, 40);
            RdiTeiji2.Margin = new Padding(4);
            RdiTeiji2.Name = "RdiTeiji2";
            RdiTeiji2.Size = new Size(130, 23);
            RdiTeiji2.TabIndex = 2;
            RdiTeiji2.TabStop = true;
            RdiTeiji2.Text = "シャッフル(S)";
            RdiTeiji2.UseVisualStyleBackColor = true;
            RdiTeiji2.CheckedChanged += RdiTeiji2_CheckedChanged;
            // 
            // RdiTeiji1
            // 
            RdiTeiji1.AutoSize = true;
            RdiTeiji1.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            RdiTeiji1.Location = new Point(28, 40);
            RdiTeiji1.Margin = new Padding(4);
            RdiTeiji1.Name = "RdiTeiji1";
            RdiTeiji1.Size = new Size(108, 23);
            RdiTeiji1.TabIndex = 1;
            RdiTeiji1.TabStop = true;
            RdiTeiji1.Text = "番号順(B)";
            RdiTeiji1.UseVisualStyleBackColor = true;
            RdiTeiji1.CheckedChanged += RdiTeiji1_CheckedChanged;
            // 
            // GrpStart
            // 
            GrpStart.Controls.Add(NudStart);
            GrpStart.Controls.Add(RdiStart2);
            GrpStart.Controls.Add(RdiStart1);
            GrpStart.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            GrpStart.Location = new Point(37, 130);
            GrpStart.Margin = new Padding(4);
            GrpStart.Name = "GrpStart";
            GrpStart.Padding = new Padding(4);
            GrpStart.Size = new Size(700, 90);
            GrpStart.TabIndex = 3;
            GrpStart.TabStop = false;
            GrpStart.Text = "開始NO設定";
            // 
            // NudStart
            // 
            NudStart.Location = new Point(401, 40);
            NudStart.Margin = new Padding(4);
            NudStart.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            NudStart.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NudStart.Name = "NudStart";
            NudStart.Size = new Size(65, 26);
            NudStart.TabIndex = 6;
            NudStart.TextAlign = HorizontalAlignment.Right;
            NudStart.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // RdiStart2
            // 
            RdiStart2.AutoSize = true;
            RdiStart2.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            RdiStart2.Location = new Point(224, 40);
            RdiStart2.Margin = new Padding(4);
            RdiStart2.Name = "RdiStart2";
            RdiStart2.Size = new Size(152, 23);
            RdiStart2.TabIndex = 5;
            RdiStart2.TabStop = true;
            RdiStart2.Text = "開始NO指定(N)";
            RdiStart2.UseVisualStyleBackColor = true;
            RdiStart2.CheckedChanged += RdiStart2_CheckedChanged;
            // 
            // RdiStart1
            // 
            RdiStart1.AutoSize = true;
            RdiStart1.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            RdiStart1.Location = new Point(28, 40);
            RdiStart1.Margin = new Padding(4);
            RdiStart1.Name = "RdiStart1";
            RdiStart1.Size = new Size(142, 23);
            RdiStart1.TabIndex = 4;
            RdiStart1.TabStop = true;
            RdiStart1.Text = "前回の続き(E)";
            RdiStart1.UseVisualStyleBackColor = true;
            RdiStart1.CheckedChanged += RdiStart1_CheckedChanged;
            // 
            // GrpForm
            // 
            GrpForm.Controls.Add(PnlFormQuestion);
            GrpForm.Controls.Add(ChkZipSearch);
            GrpForm.Controls.Add(ChkFormQuestion);
            GrpForm.Controls.Add(LblFormQuestion);
            GrpForm.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            GrpForm.Location = new Point(37, 230);
            GrpForm.Margin = new Padding(4);
            GrpForm.Name = "GrpForm";
            GrpForm.Padding = new Padding(4);
            GrpForm.Size = new Size(700, 180);
            GrpForm.TabIndex = 7;
            GrpForm.TabStop = false;
            GrpForm.Text = "入力画面の設定";
            // 
            // PnlFormQuestion
            // 
            PnlFormQuestion.Controls.Add(RdiFormQuestion1);
            PnlFormQuestion.Controls.Add(RdiFormQuestion2);
            PnlFormQuestion.Location = new Point(168, 70);
            PnlFormQuestion.Margin = new Padding(4);
            PnlFormQuestion.Name = "PnlFormQuestion";
            PnlFormQuestion.Size = new Size(187, 50);
            PnlFormQuestion.TabIndex = 10;
            // 
            // RdiFormQuestion1
            // 
            RdiFormQuestion1.AutoSize = true;
            RdiFormQuestion1.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            RdiFormQuestion1.Location = new Point(9, 10);
            RdiFormQuestion1.Margin = new Padding(4);
            RdiFormQuestion1.Name = "RdiFormQuestion1";
            RdiFormQuestion1.Size = new Size(68, 23);
            RdiFormQuestion1.TabIndex = 11;
            RdiFormQuestion1.TabStop = true;
            RdiFormQuestion1.Text = "左(L)";
            RdiFormQuestion1.UseVisualStyleBackColor = true;
            // 
            // RdiFormQuestion2
            // 
            RdiFormQuestion2.AutoSize = true;
            RdiFormQuestion2.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            RdiFormQuestion2.Location = new Point(103, 10);
            RdiFormQuestion2.Margin = new Padding(4);
            RdiFormQuestion2.Name = "RdiFormQuestion2";
            RdiFormQuestion2.Size = new Size(70, 23);
            RdiFormQuestion2.TabIndex = 12;
            RdiFormQuestion2.TabStop = true;
            RdiFormQuestion2.Text = "右(R)";
            RdiFormQuestion2.UseVisualStyleBackColor = true;
            // 
            // ChkZipSearch
            // 
            ChkZipSearch.AutoSize = true;
            ChkZipSearch.Location = new Point(37, 130);
            ChkZipSearch.Margin = new Padding(4);
            ChkZipSearch.Name = "ChkZipSearch";
            ChkZipSearch.Size = new Size(270, 23);
            ChkZipSearch.TabIndex = 13;
            ChkZipSearch.Text = "郵便番号検索を有効にする(Z)";
            ChkZipSearch.UseVisualStyleBackColor = true;
            // 
            // ChkFormQuestion
            // 
            ChkFormQuestion.AutoSize = true;
            ChkFormQuestion.Location = new Point(37, 40);
            ChkFormQuestion.Margin = new Padding(4);
            ChkFormQuestion.Name = "ChkFormQuestion";
            ChkFormQuestion.Size = new Size(548, 23);
            ChkFormQuestion.TabIndex = 8;
            ChkFormQuestion.Text = "アンケートカード・顧客伝票の印刷物イメージを画面に表示する(P)";
            ChkFormQuestion.UseVisualStyleBackColor = true;
            ChkFormQuestion.CheckedChanged += ChkFormQuestion_CheckedChanged;
            // 
            // BtnReport
            // 
            BtnReport.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            BtnReport.Location = new Point(37, 430);
            BtnReport.Margin = new Padding(4);
            BtnReport.Name = "BtnReport";
            BtnReport.Size = new Size(224, 40);
            BtnReport.TabIndex = 14;
            BtnReport.Text = "解析結果の出力(H)";
            BtnReport.UseVisualStyleBackColor = true;
            BtnReport.Click += BtnReport_Click;
            // 
            // Frm試行条件
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(769, 492);
            Controls.Add(GrpStart);
            Controls.Add(GrpForm);
            Controls.Add(GrpTeiji);
            Controls.Add(BtnCancel);
            Controls.Add(BtnReport);
            Controls.Add(BtnOk);
            Margin = new Padding(4);
            Name = "Frm試行条件";
            Text = "試行条件の設定";
            Load += Frm試行条件_Load;
            GrpTeiji.ResumeLayout(false);
            GrpTeiji.PerformLayout();
            GrpStart.ResumeLayout(false);
            GrpStart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NudStart).EndInit();
            GrpForm.ResumeLayout(false);
            GrpForm.PerformLayout();
            PnlFormQuestion.ResumeLayout(false);
            PnlFormQuestion.PerformLayout();
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Label LblFormQuestion;
        private System.Windows.Forms.GroupBox GrpTeiji;
        private System.Windows.Forms.RadioButton RdiTeiji2;
        private System.Windows.Forms.RadioButton RdiTeiji1;
        private System.Windows.Forms.GroupBox GrpStart;
        private System.Windows.Forms.RadioButton RdiStart2;
        private System.Windows.Forms.RadioButton RdiStart1;
        private System.Windows.Forms.NumericUpDown NudStart;
        private System.Windows.Forms.GroupBox GrpForm;
        private System.Windows.Forms.CheckBox ChkFormQuestion;
        private System.Windows.Forms.RadioButton RdiFormQuestion2;
        private System.Windows.Forms.RadioButton RdiFormQuestion1;
        private System.Windows.Forms.Panel PnlFormQuestion;
        private System.Windows.Forms.CheckBox ChkZipSearch;
        private System.Windows.Forms.Button BtnReport;
    }
}

