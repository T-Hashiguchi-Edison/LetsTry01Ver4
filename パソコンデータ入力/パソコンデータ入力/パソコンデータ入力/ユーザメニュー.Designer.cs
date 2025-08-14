namespace パソコンデータ入力
{
    partial class Frmユーザメニュー
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
            BtnQuestion = new Button();
            label1 = new Label();
            BtnCustomer = new Button();
            BtnCustomerCheck = new Button();
            BtnCancel = new Button();
            SuspendLayout();
            // 
            // BtnQuestion
            // 
            BtnQuestion.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            BtnQuestion.Location = new Point(128, 176);
            BtnQuestion.Name = "BtnQuestion";
            BtnQuestion.Size = new Size(400, 64);
            BtnQuestion.TabIndex = 1;
            BtnQuestion.Text = "１．アンケート入力(1)";
            BtnQuestion.TextAlign = ContentAlignment.MiddleLeft;
            BtnQuestion.UseVisualStyleBackColor = true;
            BtnQuestion.Click += BtnQuestion_Click;
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ControlLightLight;
            label1.Font = new Font("ＭＳ Ｐゴシック", 36F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label1.ForeColor = Color.DeepSkyBlue;
            label1.Location = new Point(-8, 0);
            label1.Name = "label1";
            label1.Size = new Size(688, 152);
            label1.TabIndex = 3;
            label1.Text = "やってみよう！\r\nパソコンデータ入力";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BtnCustomer
            // 
            BtnCustomer.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            BtnCustomer.Location = new Point(128, 256);
            BtnCustomer.Name = "BtnCustomer";
            BtnCustomer.Size = new Size(400, 64);
            BtnCustomer.TabIndex = 2;
            BtnCustomer.Text = "２．顧客伝票修正(2)";
            BtnCustomer.TextAlign = ContentAlignment.MiddleLeft;
            BtnCustomer.UseVisualStyleBackColor = true;
            BtnCustomer.Click += BtnCustomer_Click;
            // 
            // BtnCustomerCheck
            // 
            BtnCustomerCheck.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            BtnCustomerCheck.Location = new Point(128, 336);
            BtnCustomerCheck.Name = "BtnCustomerCheck";
            BtnCustomerCheck.Size = new Size(400, 64);
            BtnCustomerCheck.TabIndex = 4;
            BtnCustomerCheck.Text = "３．顧客伝票ミスチェック(3)";
            BtnCustomerCheck.TextAlign = ContentAlignment.MiddleLeft;
            BtnCustomerCheck.UseVisualStyleBackColor = true;
            BtnCustomerCheck.Click += BtnCustomerCheck_Click;
            // 
            // BtnCancel
            // 
            BtnCancel.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            BtnCancel.Location = new Point(128, 416);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(400, 64);
            BtnCancel.TabIndex = 2;
            BtnCancel.Text = "４．終了(4)";
            BtnCancel.TextAlign = ContentAlignment.MiddleLeft;
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // Frmユーザメニュー
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(673, 512);
            Controls.Add(label1);
            Controls.Add(BtnCancel);
            Controls.Add(BtnCustomerCheck);
            Controls.Add(BtnCustomer);
            Controls.Add(BtnQuestion);
            Name = "Frmユーザメニュー";
            Text = "やってみよう！パソコンデータ入力";
            Load += Frmユーザメニュー_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button BtnQuestion;
        private Label label1;
        private Button BtnCustomer;
        private Button BtnCustomerCheck;
        private Button BtnCancel;
    }
}
