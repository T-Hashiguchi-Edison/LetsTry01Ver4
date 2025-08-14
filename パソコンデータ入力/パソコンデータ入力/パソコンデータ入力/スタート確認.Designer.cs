namespace パソコンデータ入力
{
    partial class Frmスタート確認
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
            BtnStart = new Button();
            BtnCancel = new Button();
            LblMessage1 = new Label();
            LblMessage2 = new Label();
            LblMessage3 = new Label();
            LblMessage4 = new Label();
            LblMessage5 = new Label();
            LblMessage6 = new Label();
            LblMessage7 = new Label();
            SuspendLayout();
            // 
            // BtnStart
            // 
            BtnStart.Location = new Point(250, 472);
            BtnStart.Name = "BtnStart";
            BtnStart.Size = new Size(184, 40);
            BtnStart.TabIndex = 8;
            BtnStart.Text = "スタート";
            BtnStart.UseVisualStyleBackColor = true;
            BtnStart.Click += BtnStart_Click;
            // 
            // BtnCancel
            // 
            BtnCancel.Location = new Point(472, 536);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(184, 32);
            BtnCancel.TabIndex = 9;
            BtnCancel.Text = "キャンセル";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // LblMessage1
            // 
            LblMessage1.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblMessage1.Location = new Point(26, 56);
            LblMessage1.Name = "LblMessage1";
            LblMessage1.Size = new Size(632, 32);
            LblMessage1.TabIndex = 1;
            LblMessage1.Text = "メッセージ１";
            LblMessage1.Visible = false;
            // 
            // LblMessage2
            // 
            LblMessage2.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblMessage2.Location = new Point(26, 112);
            LblMessage2.Name = "LblMessage2";
            LblMessage2.Size = new Size(632, 32);
            LblMessage2.TabIndex = 2;
            LblMessage2.Text = "メッセージ２";
            LblMessage2.Visible = false;
            // 
            // LblMessage3
            // 
            LblMessage3.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblMessage3.Location = new Point(26, 168);
            LblMessage3.Name = "LblMessage3";
            LblMessage3.Size = new Size(632, 32);
            LblMessage3.TabIndex = 3;
            LblMessage3.Text = "メッセージ３";
            LblMessage3.Visible = false;
            // 
            // LblMessage4
            // 
            LblMessage4.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblMessage4.Location = new Point(26, 224);
            LblMessage4.Name = "LblMessage4";
            LblMessage4.Size = new Size(632, 32);
            LblMessage4.TabIndex = 4;
            LblMessage4.Text = "メッセージ４";
            LblMessage4.Visible = false;
            // 
            // LblMessage5
            // 
            LblMessage5.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblMessage5.Location = new Point(26, 280);
            LblMessage5.Name = "LblMessage5";
            LblMessage5.Size = new Size(632, 32);
            LblMessage5.TabIndex = 5;
            LblMessage5.Text = "メッセージ５";
            LblMessage5.Visible = false;
            // 
            // LblMessage6
            // 
            LblMessage6.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblMessage6.Location = new Point(26, 336);
            LblMessage6.Name = "LblMessage6";
            LblMessage6.Size = new Size(632, 32);
            LblMessage6.TabIndex = 6;
            LblMessage6.Text = "メッセージ６";
            LblMessage6.Visible = false;
            // 
            // LblMessage7
            // 
            LblMessage7.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblMessage7.Location = new Point(26, 392);
            LblMessage7.Name = "LblMessage7";
            LblMessage7.Size = new Size(632, 32);
            LblMessage7.TabIndex = 7;
            LblMessage7.Text = "確認したら、「スタート」をクリックして、入力を始めてください。";
            LblMessage7.TextAlign = ContentAlignment.TopCenter;
            // 
            // Frmスタート確認
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(684, 571);
            Controls.Add(LblMessage7);
            Controls.Add(LblMessage6);
            Controls.Add(LblMessage5);
            Controls.Add(LblMessage4);
            Controls.Add(LblMessage3);
            Controls.Add(LblMessage2);
            Controls.Add(LblMessage1);
            Controls.Add(BtnCancel);
            Controls.Add(BtnStart);
            Name = "Frmスタート確認";
            Text = "やってみよう！パソコンデータ入力";
            Load += Frmスタート確認_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button BtnStart;
        private Button BtnCancel;
        private Label LblMessage1;
        private Label LblMessage2;
        private Label LblMessage3;
        private Label LblMessage4;
        private Label LblMessage5;
        private Label LblMessage6;
        private Label LblMessage7;
    }
}
