namespace パソコンデータ入力
{ 

    partial class Frmチェックメッセージ
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
            BtnOK = new Button();
            LblMessage = new Label();
            SuspendLayout();
            // 
            // BtnOK
            // 
            BtnOK.Location = new Point(269, 416);
            BtnOK.Name = "BtnOK";
            BtnOK.Size = new Size(184, 40);
            BtnOK.TabIndex = 8;
            BtnOK.Text = "ＯＫ";
            BtnOK.UseVisualStyleBackColor = true;
            BtnOK.Click += BtnOK_Click;
            // 
            // LblMessage
            // 
            LblMessage.Font = new Font("ＭＳ Ｐゴシック", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblMessage.Location = new Point(28, 221);
            LblMessage.Name = "LblMessage";
            LblMessage.Size = new Size(667, 45);
            LblMessage.TabIndex = 4;
            LblMessage.Text = "メッセージ";
            LblMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Frmチェックメッセージ
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(723, 486);
            Controls.Add(LblMessage);
            Controls.Add(BtnOK);
            Name = "Frmチェックメッセージ";
            Text = "やってみよう！パソコンデータ入力";
            Load += Frmチェックメッセージ_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button BtnOK;
        private Label LblMessage;
    }
}
