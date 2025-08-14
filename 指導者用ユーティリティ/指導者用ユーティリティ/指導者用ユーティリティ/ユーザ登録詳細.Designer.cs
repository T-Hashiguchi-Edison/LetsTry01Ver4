namespace 指導者用ユーティリティ
{
    partial class Frmユーザ登録詳細
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
            LblKana = new Label();
            BtnOk = new Button();
            LblComment1 = new Label();
            BtnCancel = new Button();
            LblKanji = new Label();
            LblSei = new Label();
            LblMei = new Label();
            LblComment2 = new Label();
            TxtShiKana = new TextBox();
            TxtMeiKanji = new TextBox();
            TxtMeiKana = new TextBox();
            TxtShiKanji = new TextBox();
            SuspendLayout();
            // 
            // LblKana
            // 
            LblKana.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblKana.Location = new Point(19, 36);
            LblKana.Margin = new Padding(4, 0, 4, 0);
            LblKana.Name = "LblKana";
            LblKana.Size = new Size(159, 40);
            LblKana.TabIndex = 3;
            LblKana.Text = "フリガナ(F)";
            LblKana.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // BtnOk
            // 
            BtnOk.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            BtnOk.Location = new Point(168, 290);
            BtnOk.Margin = new Padding(4, 4, 4, 4);
            BtnOk.Name = "BtnOk";
            BtnOk.Size = new Size(149, 40);
            BtnOk.TabIndex = 4;
            BtnOk.Text = "OK";
            BtnOk.UseVisualStyleBackColor = true;
            BtnOk.Click += BtnOk_Click;
            // 
            // LblComment1
            // 
            LblComment1.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblComment1.Location = new Point(103, 190);
            LblComment1.Margin = new Padding(4, 0, 4, 0);
            LblComment1.Name = "LblComment1";
            LblComment1.Size = new Size(541, 40);
            LblComment1.TabIndex = 4;
            LblComment1.Text = "フリガナは全角カタカナで入力してください。";
            LblComment1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // BtnCancel
            // 
            BtnCancel.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            BtnCancel.Location = new Point(355, 290);
            BtnCancel.Margin = new Padding(4, 4, 4, 4);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(149, 40);
            BtnCancel.TabIndex = 5;
            BtnCancel.Text = "キャンセル";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // LblKanji
            // 
            LblKanji.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblKanji.Location = new Point(19, 96);
            LblKanji.Margin = new Padding(4, 0, 4, 0);
            LblKanji.Name = "LblKanji";
            LblKanji.Size = new Size(159, 40);
            LblKanji.TabIndex = 3;
            LblKanji.Text = "氏名(N)";
            LblKanji.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblSei
            // 
            LblSei.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblSei.Location = new Point(131, 96);
            LblSei.Margin = new Padding(4, 0, 4, 0);
            LblSei.Name = "LblSei";
            LblSei.Size = new Size(47, 40);
            LblSei.TabIndex = 3;
            LblSei.Text = "姓";
            LblSei.TextAlign = ContentAlignment.MiddleRight;
            // 
            // LblMei
            // 
            LblMei.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblMei.Location = new Point(383, 96);
            LblMei.Margin = new Padding(4, 0, 4, 0);
            LblMei.Name = "LblMei";
            LblMei.Size = new Size(47, 40);
            LblMei.TabIndex = 3;
            LblMei.Text = "名";
            LblMei.TextAlign = ContentAlignment.MiddleRight;
            // 
            // LblComment2
            // 
            LblComment2.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblComment2.Location = new Point(103, 230);
            LblComment2.Margin = new Padding(4, 0, 4, 0);
            LblComment2.Name = "LblComment2";
            LblComment2.Size = new Size(541, 40);
            LblComment2.TabIndex = 4;
            LblComment2.Text = "氏名は全角文字で入力してください";
            LblComment2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // TxtShiKana
            // 
            TxtShiKana.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            TxtShiKana.ImeMode = ImeMode.On;
            TxtShiKana.Location = new Point(177, 40);
            TxtShiKana.Margin = new Padding(4, 4, 4, 4);
            TxtShiKana.MaxLength = 30;
            TxtShiKana.Name = "TxtShiKana";
            TxtShiKana.Size = new Size(205, 26);
            TxtShiKana.TabIndex = 0;
            // 
            // TxtMeiKanji
            // 
            TxtMeiKanji.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            TxtMeiKanji.ImeMode = ImeMode.On;
            TxtMeiKanji.Location = new Point(429, 100);
            TxtMeiKanji.Margin = new Padding(4, 4, 4, 4);
            TxtMeiKanji.MaxLength = 30;
            TxtMeiKanji.Name = "TxtMeiKanji";
            TxtMeiKanji.Size = new Size(205, 26);
            TxtMeiKanji.TabIndex = 3;
            // 
            // TxtMeiKana
            // 
            TxtMeiKana.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            TxtMeiKana.ImeMode = ImeMode.On;
            TxtMeiKana.Location = new Point(429, 40);
            TxtMeiKana.Margin = new Padding(4, 4, 4, 4);
            TxtMeiKana.MaxLength = 30;
            TxtMeiKana.Name = "TxtMeiKana";
            TxtMeiKana.Size = new Size(205, 26);
            TxtMeiKana.TabIndex = 1;
            // 
            // TxtShiKanji
            // 
            TxtShiKanji.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            TxtShiKanji.ImeMode = ImeMode.On;
            TxtShiKanji.Location = new Point(177, 100);
            TxtShiKanji.Margin = new Padding(4, 4, 4, 4);
            TxtShiKanji.MaxLength = 30;
            TxtShiKanji.Name = "TxtShiKanji";
            TxtShiKanji.Size = new Size(205, 26);
            TxtShiKanji.TabIndex = 2;
            // 
            // Frmユーザ登録詳細
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(656, 368);
            Controls.Add(TxtShiKanji);
            Controls.Add(TxtMeiKana);
            Controls.Add(TxtMeiKanji);
            Controls.Add(TxtShiKana);
            Controls.Add(BtnCancel);
            Controls.Add(BtnOk);
            Controls.Add(LblComment2);
            Controls.Add(LblComment1);
            Controls.Add(LblMei);
            Controls.Add(LblSei);
            Controls.Add(LblKanji);
            Controls.Add(LblKana);
            Margin = new Padding(4, 4, 4, 4);
            Name = "Frmユーザ登録詳細";
            Text = "ユーザ登録名の入力";
            Load += Frmユーザ登録詳細_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LblKana;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Label LblComment1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Label LblKanji;
        private System.Windows.Forms.Label LblSei;
        private System.Windows.Forms.Label LblMei;
        private System.Windows.Forms.Label LblComment2;
        private System.Windows.Forms.TextBox TxtShiKana;
        private System.Windows.Forms.TextBox TxtMeiKanji;
        private System.Windows.Forms.TextBox TxtMeiKana;
        private System.Windows.Forms.TextBox TxtShiKanji;
    }
}

