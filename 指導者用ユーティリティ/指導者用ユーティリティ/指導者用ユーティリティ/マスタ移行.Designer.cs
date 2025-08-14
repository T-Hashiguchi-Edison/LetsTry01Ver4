namespace 指導者用ユーティリティ
{
    partial class Frmマスタ移行
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
            BtnStart = new Button();
            LblPostNo = new Label();
            LblQuestionnaire = new Label();
            LblCustomerInput = new Label();
            LblCustomerCheck = new Label();
            LblCustomerCheckErr = new Label();
            LblCustomerInputErr = new Label();
            LblQuestionnaire2 = new Label();
            LblCntPostNoResult = new Label();
            LblCntPostNo = new Label();
            LblCntQuestionnaire = new Label();
            LblCntQuestionnaireResult = new Label();
            LblCntCustomerInput = new Label();
            LblCntCustomerInputResult = new Label();
            LblCntCustomerInputErr = new Label();
            LblCntCustomerInputErrResult = new Label();
            LblCntQuestionnaire2 = new Label();
            LblCntQuestionnaire2Result = new Label();
            LblCntCustomerCheck = new Label();
            LblCntCustomerCheckResult = new Label();
            LblCntCustomerCheckErr = new Label();
            LblCntCustomerCheckErrResult = new Label();
            LblResult = new Label();
            LblInFile = new Label();
            BtnInFile = new Button();
            LblOutPath = new Label();
            BtnOutPath = new Button();
            BtnCancel = new Button();
            PnlPassword = new Panel();
            BtnPass = new Button();
            TxtPass = new TextBox();
            PnlPassword.SuspendLayout();
            SuspendLayout();
            // 
            // BtnStart
            // 
            BtnStart.BackgroundImageLayout = ImageLayout.Zoom;
            BtnStart.Font = new Font("ＭＳ Ｐゴシック", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            BtnStart.Location = new Point(28, 160);
            BtnStart.Margin = new Padding(4);
            BtnStart.Name = "BtnStart";
            BtnStart.Size = new Size(1045, 70);
            BtnStart.TabIndex = 2;
            BtnStart.Text = "移行開始(S)";
            BtnStart.UseVisualStyleBackColor = true;
            BtnStart.Click += BtnStart_Click;
            // 
            // LblPostNo
            // 
            LblPostNo.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblPostNo.Location = new Point(252, 250);
            LblPostNo.Margin = new Padding(4, 0, 4, 0);
            LblPostNo.Name = "LblPostNo";
            LblPostNo.Size = new Size(299, 40);
            LblPostNo.TabIndex = 5;
            LblPostNo.Text = "郵便番号マスタ";
            LblPostNo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblQuestionnaire
            // 
            LblQuestionnaire.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblQuestionnaire.Location = new Point(252, 290);
            LblQuestionnaire.Margin = new Padding(4, 0, 4, 0);
            LblQuestionnaire.Name = "LblQuestionnaire";
            LblQuestionnaire.Size = new Size(299, 40);
            LblQuestionnaire.TabIndex = 8;
            LblQuestionnaire.Text = "アンケート入力マスタ";
            LblQuestionnaire.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblCustomerInput
            // 
            LblCustomerInput.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblCustomerInput.Location = new Point(252, 330);
            LblCustomerInput.Margin = new Padding(4, 0, 4, 0);
            LblCustomerInput.Name = "LblCustomerInput";
            LblCustomerInput.Size = new Size(299, 40);
            LblCustomerInput.TabIndex = 11;
            LblCustomerInput.Text = "顧客伝票マスタ";
            LblCustomerInput.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblCustomerCheck
            // 
            LblCustomerCheck.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblCustomerCheck.Location = new Point(252, 450);
            LblCustomerCheck.Margin = new Padding(4, 0, 4, 0);
            LblCustomerCheck.Name = "LblCustomerCheck";
            LblCustomerCheck.Size = new Size(299, 40);
            LblCustomerCheck.TabIndex = 20;
            LblCustomerCheck.Text = "顧客伝票基礎マスタ";
            LblCustomerCheck.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblCustomerCheckErr
            // 
            LblCustomerCheckErr.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblCustomerCheckErr.Location = new Point(252, 490);
            LblCustomerCheckErr.Margin = new Padding(4, 0, 4, 0);
            LblCustomerCheckErr.Name = "LblCustomerCheckErr";
            LblCustomerCheckErr.Size = new Size(299, 40);
            LblCustomerCheckErr.TabIndex = 23;
            LblCustomerCheckErr.Text = "顧客伝票基礎エラーデータ";
            LblCustomerCheckErr.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblCustomerInputErr
            // 
            LblCustomerInputErr.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblCustomerInputErr.Location = new Point(252, 370);
            LblCustomerInputErr.Margin = new Padding(4, 0, 4, 0);
            LblCustomerInputErr.Name = "LblCustomerInputErr";
            LblCustomerInputErr.Size = new Size(299, 40);
            LblCustomerInputErr.TabIndex = 14;
            LblCustomerInputErr.Text = "顧客伝票エラーデータ";
            LblCustomerInputErr.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblQuestionnaire2
            // 
            LblQuestionnaire2.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblQuestionnaire2.Location = new Point(252, 410);
            LblQuestionnaire2.Margin = new Padding(4, 0, 4, 0);
            LblQuestionnaire2.Name = "LblQuestionnaire2";
            LblQuestionnaire2.Size = new Size(299, 40);
            LblQuestionnaire2.TabIndex = 17;
            LblQuestionnaire2.Text = "アンケート入力基礎マスタ";
            LblQuestionnaire2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblCntPostNoResult
            // 
            LblCntPostNoResult.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblCntPostNoResult.Location = new Point(560, 250);
            LblCntPostNoResult.Margin = new Padding(4, 0, 0, 0);
            LblCntPostNoResult.Name = "LblCntPostNoResult";
            LblCntPostNoResult.Size = new Size(84, 40);
            LblCntPostNoResult.TabIndex = 26;
            LblCntPostNoResult.Text = "0";
            LblCntPostNoResult.TextAlign = ContentAlignment.MiddleRight;
            // 
            // LblCntPostNo
            // 
            LblCntPostNo.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblCntPostNo.Location = new Point(644, 250);
            LblCntPostNo.Margin = new Padding(0, 0, 4, 0);
            LblCntPostNo.Name = "LblCntPostNo";
            LblCntPostNo.Size = new Size(131, 40);
            LblCntPostNo.TabIndex = 7;
            LblCntPostNo.Text = "／ 0";
            LblCntPostNo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblCntQuestionnaire
            // 
            LblCntQuestionnaire.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblCntQuestionnaire.Location = new Point(644, 290);
            LblCntQuestionnaire.Margin = new Padding(0, 0, 4, 0);
            LblCntQuestionnaire.Name = "LblCntQuestionnaire";
            LblCntQuestionnaire.Size = new Size(131, 40);
            LblCntQuestionnaire.TabIndex = 10;
            LblCntQuestionnaire.Text = "／ 0";
            LblCntQuestionnaire.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblCntQuestionnaireResult
            // 
            LblCntQuestionnaireResult.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblCntQuestionnaireResult.Location = new Point(560, 290);
            LblCntQuestionnaireResult.Margin = new Padding(4, 0, 0, 0);
            LblCntQuestionnaireResult.Name = "LblCntQuestionnaireResult";
            LblCntQuestionnaireResult.Size = new Size(84, 40);
            LblCntQuestionnaireResult.TabIndex = 9;
            LblCntQuestionnaireResult.Text = "0";
            LblCntQuestionnaireResult.TextAlign = ContentAlignment.MiddleRight;
            // 
            // LblCntCustomerInput
            // 
            LblCntCustomerInput.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblCntCustomerInput.Location = new Point(644, 330);
            LblCntCustomerInput.Margin = new Padding(0, 0, 4, 0);
            LblCntCustomerInput.Name = "LblCntCustomerInput";
            LblCntCustomerInput.Size = new Size(131, 40);
            LblCntCustomerInput.TabIndex = 13;
            LblCntCustomerInput.Text = "／ 0";
            LblCntCustomerInput.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblCntCustomerInputResult
            // 
            LblCntCustomerInputResult.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblCntCustomerInputResult.Location = new Point(560, 330);
            LblCntCustomerInputResult.Margin = new Padding(4, 0, 0, 0);
            LblCntCustomerInputResult.Name = "LblCntCustomerInputResult";
            LblCntCustomerInputResult.Size = new Size(84, 40);
            LblCntCustomerInputResult.TabIndex = 12;
            LblCntCustomerInputResult.Text = "0";
            LblCntCustomerInputResult.TextAlign = ContentAlignment.MiddleRight;
            // 
            // LblCntCustomerInputErr
            // 
            LblCntCustomerInputErr.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblCntCustomerInputErr.Location = new Point(644, 370);
            LblCntCustomerInputErr.Margin = new Padding(0, 0, 4, 0);
            LblCntCustomerInputErr.Name = "LblCntCustomerInputErr";
            LblCntCustomerInputErr.Size = new Size(131, 40);
            LblCntCustomerInputErr.TabIndex = 16;
            LblCntCustomerInputErr.Text = "／ 0";
            LblCntCustomerInputErr.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblCntCustomerInputErrResult
            // 
            LblCntCustomerInputErrResult.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblCntCustomerInputErrResult.Location = new Point(560, 370);
            LblCntCustomerInputErrResult.Margin = new Padding(4, 0, 0, 0);
            LblCntCustomerInputErrResult.Name = "LblCntCustomerInputErrResult";
            LblCntCustomerInputErrResult.Size = new Size(84, 40);
            LblCntCustomerInputErrResult.TabIndex = 15;
            LblCntCustomerInputErrResult.Text = "0";
            LblCntCustomerInputErrResult.TextAlign = ContentAlignment.MiddleRight;
            // 
            // LblCntQuestionnaire2
            // 
            LblCntQuestionnaire2.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblCntQuestionnaire2.Location = new Point(644, 410);
            LblCntQuestionnaire2.Margin = new Padding(0, 0, 4, 0);
            LblCntQuestionnaire2.Name = "LblCntQuestionnaire2";
            LblCntQuestionnaire2.Size = new Size(131, 40);
            LblCntQuestionnaire2.TabIndex = 19;
            LblCntQuestionnaire2.Text = "／ 0";
            LblCntQuestionnaire2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblCntQuestionnaire2Result
            // 
            LblCntQuestionnaire2Result.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblCntQuestionnaire2Result.Location = new Point(560, 410);
            LblCntQuestionnaire2Result.Margin = new Padding(4, 0, 0, 0);
            LblCntQuestionnaire2Result.Name = "LblCntQuestionnaire2Result";
            LblCntQuestionnaire2Result.Size = new Size(84, 40);
            LblCntQuestionnaire2Result.TabIndex = 18;
            LblCntQuestionnaire2Result.Text = "0";
            LblCntQuestionnaire2Result.TextAlign = ContentAlignment.MiddleRight;
            // 
            // LblCntCustomerCheck
            // 
            LblCntCustomerCheck.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblCntCustomerCheck.Location = new Point(644, 450);
            LblCntCustomerCheck.Margin = new Padding(0, 0, 4, 0);
            LblCntCustomerCheck.Name = "LblCntCustomerCheck";
            LblCntCustomerCheck.Size = new Size(131, 40);
            LblCntCustomerCheck.TabIndex = 22;
            LblCntCustomerCheck.Text = "／ 0";
            LblCntCustomerCheck.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblCntCustomerCheckResult
            // 
            LblCntCustomerCheckResult.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblCntCustomerCheckResult.Location = new Point(560, 450);
            LblCntCustomerCheckResult.Margin = new Padding(4, 0, 0, 0);
            LblCntCustomerCheckResult.Name = "LblCntCustomerCheckResult";
            LblCntCustomerCheckResult.Size = new Size(84, 40);
            LblCntCustomerCheckResult.TabIndex = 21;
            LblCntCustomerCheckResult.Text = "0";
            LblCntCustomerCheckResult.TextAlign = ContentAlignment.MiddleRight;
            // 
            // LblCntCustomerCheckErr
            // 
            LblCntCustomerCheckErr.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblCntCustomerCheckErr.Location = new Point(644, 490);
            LblCntCustomerCheckErr.Margin = new Padding(0, 0, 4, 0);
            LblCntCustomerCheckErr.Name = "LblCntCustomerCheckErr";
            LblCntCustomerCheckErr.Size = new Size(131, 40);
            LblCntCustomerCheckErr.TabIndex = 25;
            LblCntCustomerCheckErr.Text = "／ 0";
            LblCntCustomerCheckErr.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblCntCustomerCheckErrResult
            // 
            LblCntCustomerCheckErrResult.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblCntCustomerCheckErrResult.Location = new Point(560, 490);
            LblCntCustomerCheckErrResult.Margin = new Padding(4, 0, 0, 0);
            LblCntCustomerCheckErrResult.Name = "LblCntCustomerCheckErrResult";
            LblCntCustomerCheckErrResult.Size = new Size(84, 40);
            LblCntCustomerCheckErrResult.TabIndex = 24;
            LblCntCustomerCheckErrResult.Text = "0";
            LblCntCustomerCheckErrResult.TextAlign = ContentAlignment.MiddleRight;
            // 
            // LblResult
            // 
            LblResult.Font = new Font("ＭＳ Ｐゴシック", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblResult.ForeColor = Color.Green;
            LblResult.Location = new Point(28, 540);
            LblResult.Margin = new Padding(4, 0, 4, 0);
            LblResult.Name = "LblResult";
            LblResult.Size = new Size(1045, 60);
            LblResult.TabIndex = 26;
            LblResult.TextAlign = ContentAlignment.MiddleCenter;
            LblResult.Visible = false;
            // 
            // LblInFile
            // 
            LblInFile.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblInFile.Location = new Point(271, 62);
            LblInFile.Margin = new Padding(4, 0, 4, 0);
            LblInFile.Name = "LblInFile";
            LblInFile.Size = new Size(793, 40);
            LblInFile.TabIndex = 3;
            LblInFile.Text = "C:\\障害者職業総合センター\\LetsTry01Ver3\\LetsTry01.mst";
            LblInFile.TextAlign = ContentAlignment.MiddleLeft;
            LblInFile.Visible = false;
            // 
            // BtnInFile
            // 
            BtnInFile.Enabled = false;
            BtnInFile.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            BtnInFile.Location = new Point(28, 62);
            BtnInFile.Margin = new Padding(4);
            BtnInFile.Name = "BtnInFile";
            BtnInFile.Size = new Size(233, 40);
            BtnInFile.TabIndex = 0;
            BtnInFile.Text = "移行元マスタファイル(I)";
            BtnInFile.UseVisualStyleBackColor = true;
            BtnInFile.Visible = false;
            BtnInFile.Click += BtnInFile_Click;
            // 
            // LblOutPath
            // 
            LblOutPath.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblOutPath.Location = new Point(271, 112);
            LblOutPath.Margin = new Padding(4, 0, 4, 0);
            LblOutPath.Name = "LblOutPath";
            LblOutPath.Size = new Size(793, 40);
            LblOutPath.TabIndex = 4;
            LblOutPath.Text = "C:\\障害者職業総合センター\\LetsTry01Ver4";
            LblOutPath.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // BtnOutPath
            // 
            BtnOutPath.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            BtnOutPath.Location = new Point(28, 112);
            BtnOutPath.Margin = new Padding(4);
            BtnOutPath.Name = "BtnOutPath";
            BtnOutPath.Size = new Size(233, 40);
            BtnOutPath.TabIndex = 1;
            BtnOutPath.Text = "移行先フォルダ(O)";
            BtnOutPath.UseVisualStyleBackColor = true;
            BtnOutPath.Click += BtnOutPath_Click;
            // 
            // BtnCancel
            // 
            BtnCancel.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            BtnCancel.Location = new Point(952, 490);
            BtnCancel.Margin = new Padding(4);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(112, 40);
            BtnCancel.TabIndex = 27;
            BtnCancel.Text = "終了";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += btnCancel_Click;
            // 
            // PnlPassword
            // 
            PnlPassword.Controls.Add(BtnPass);
            PnlPassword.Controls.Add(TxtPass);
            PnlPassword.Location = new Point(888, 8);
            PnlPassword.Name = "PnlPassword";
            PnlPassword.Size = new Size(176, 48);
            PnlPassword.TabIndex = 28;
            PnlPassword.Visible = false;
            // 
            // BtnPass
            // 
            BtnPass.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            BtnPass.Location = new Point(96, 9);
            BtnPass.Name = "BtnPass";
            BtnPass.Size = new Size(72, 29);
            BtnPass.TabIndex = 1;
            BtnPass.Text = "OK";
            BtnPass.UseVisualStyleBackColor = true;
            BtnPass.Click += BtnPass_Click;
            // 
            // TxtPass
            // 
            TxtPass.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            TxtPass.Location = new Point(8, 9);
            TxtPass.Name = "TxtPass";
            TxtPass.PasswordChar = '*';
            TxtPass.Size = new Size(96, 29);
            TxtPass.TabIndex = 0;
            TxtPass.Text = "IkoAdmin";
            // 
            // Frmマスタ移行
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1101, 616);
            Controls.Add(PnlPassword);
            Controls.Add(BtnCancel);
            Controls.Add(BtnOutPath);
            Controls.Add(BtnInFile);
            Controls.Add(LblCntCustomerCheckErr);
            Controls.Add(LblCntCustomerCheckErrResult);
            Controls.Add(LblCntCustomerCheck);
            Controls.Add(LblCntCustomerCheckResult);
            Controls.Add(LblCntQuestionnaire2);
            Controls.Add(LblCntQuestionnaire2Result);
            Controls.Add(LblCntCustomerInputErr);
            Controls.Add(LblCntCustomerInputErrResult);
            Controls.Add(LblCntCustomerInput);
            Controls.Add(LblCntCustomerInputResult);
            Controls.Add(LblCntQuestionnaire);
            Controls.Add(LblCntQuestionnaireResult);
            Controls.Add(LblCntPostNo);
            Controls.Add(LblCntPostNoResult);
            Controls.Add(LblCustomerInputErr);
            Controls.Add(LblResult);
            Controls.Add(LblCustomerCheckErr);
            Controls.Add(LblCustomerCheck);
            Controls.Add(LblQuestionnaire2);
            Controls.Add(LblCustomerInput);
            Controls.Add(LblOutPath);
            Controls.Add(LblQuestionnaire);
            Controls.Add(LblInFile);
            Controls.Add(LblPostNo);
            Controls.Add(BtnStart);
            Margin = new Padding(4);
            Name = "Frmマスタ移行";
            Text = "マスタ移行";
            Load += Frmマスタ移行_Load;
            PnlPassword.ResumeLayout(false);
            PnlPassword.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Label LblPostNo;
        private System.Windows.Forms.Label LblQuestionnaire;
        private System.Windows.Forms.Label LblCustomerInput;
        private System.Windows.Forms.Label LblCustomerCheck;
        private System.Windows.Forms.Label LblCustomerCheckErr;
        private System.Windows.Forms.Label LblCustomerInputErr;
        private System.Windows.Forms.Label LblQuestionnaire2;
        private System.Windows.Forms.Label LblCntPostNoResult;
        private System.Windows.Forms.Label LblCntPostNo;
        private System.Windows.Forms.Label LblCntQuestionnaire;
        private System.Windows.Forms.Label LblCntQuestionnaireResult;
        private System.Windows.Forms.Label LblCntCustomerInput;
        private System.Windows.Forms.Label LblCntCustomerInputResult;
        private System.Windows.Forms.Label LblCntCustomerInputErr;
        private System.Windows.Forms.Label LblCntCustomerInputErrResult;
        private System.Windows.Forms.Label LblCntQuestionnaire2;
        private System.Windows.Forms.Label LblCntQuestionnaire2Result;
        private System.Windows.Forms.Label LblCntCustomerCheck;
        private System.Windows.Forms.Label LblCntCustomerCheckResult;
        private System.Windows.Forms.Label LblCntCustomerCheckErr;
        private System.Windows.Forms.Label LblCntCustomerCheckErrResult;
        private System.Windows.Forms.Label LblResult;
        private System.Windows.Forms.Label LblInFile;
        private System.Windows.Forms.Button BtnInFile;
        private System.Windows.Forms.Label LblOutPath;
        private System.Windows.Forms.Button BtnOutPath;
        private System.Windows.Forms.Button BtnCancel;
        private Panel PnlPassword;
        private Button BtnPass;
        private TextBox TxtPass;
    }
}

