namespace パソコンデータ入力
{
    partial class Frmコース選択
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
            BtnTest = new Button();
            BtnBasic = new Button();
            BtnLevelUp = new Button();
            BtnCancel = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // BtnTest
            // 
            BtnTest.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            BtnTest.Location = new Point(128, 88);
            BtnTest.Name = "BtnTest";
            BtnTest.Size = new Size(400, 64);
            BtnTest.TabIndex = 1;
            BtnTest.Text = "１．実力テスト(1)";
            BtnTest.TextAlign = ContentAlignment.MiddleLeft;
            BtnTest.UseVisualStyleBackColor = true;
            BtnTest.Click += BtnTest_Click;
            // 
            // BtnBasic
            // 
            BtnBasic.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            BtnBasic.Location = new Point(128, 168);
            BtnBasic.Name = "BtnBasic";
            BtnBasic.Size = new Size(400, 64);
            BtnBasic.TabIndex = 2;
            BtnBasic.Text = "２．基礎トレーニング(2)";
            BtnBasic.TextAlign = ContentAlignment.MiddleLeft;
            BtnBasic.UseVisualStyleBackColor = true;
            BtnBasic.Click += BtnBasic_Click;
            // 
            // BtnLevelUp
            // 
            BtnLevelUp.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            BtnLevelUp.Location = new Point(128, 248);
            BtnLevelUp.Name = "BtnLevelUp";
            BtnLevelUp.Size = new Size(400, 64);
            BtnLevelUp.TabIndex = 4;
            BtnLevelUp.Text = "３．レベルアップトレーニング(3)";
            BtnLevelUp.TextAlign = ContentAlignment.MiddleLeft;
            BtnLevelUp.UseVisualStyleBackColor = true;
            BtnLevelUp.Click += BtnLevelUp_Click;
            // 
            // BtnCancel
            // 
            BtnCancel.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            BtnCancel.Location = new Point(128, 328);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(400, 64);
            BtnCancel.TabIndex = 2;
            BtnCancel.Text = "４．キャンセル(4)";
            BtnCancel.TextAlign = ContentAlignment.MiddleLeft;
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // label1
            // 
            label1.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label1.Location = new Point(128, 56);
            label1.Name = "label1";
            label1.Size = new Size(208, 32);
            label1.TabIndex = 5;
            label1.Text = "コースを選択してください。";
            // 
            // Frmコース選択
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(673, 512);
            Controls.Add(label1);
            Controls.Add(BtnCancel);
            Controls.Add(BtnLevelUp);
            Controls.Add(BtnBasic);
            Controls.Add(BtnTest);
            Name = "Frmコース選択";
            Text = "やってみよう！パソコンデータ入力";
            Load += Frmコース選択_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button BtnTest;
        private Button BtnBasic;
        private Button BtnLevelUp;
        private Button BtnCancel;
        private Label label1;
    }
}
