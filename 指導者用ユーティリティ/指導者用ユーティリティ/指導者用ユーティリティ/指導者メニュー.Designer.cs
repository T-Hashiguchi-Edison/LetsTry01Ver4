namespace 指導者用ユーティリティ
{
    partial class Frm指導者メニュー
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
            BtnMstIko = new Button();
            BtnEnd = new Button();
            BtnUserMst = new Button();
            BtnCondition = new Button();
            BtnReport = new Button();
            LblPostNo = new Label();
            SuspendLayout();
            // 
            // BtnMstIko
            // 
            BtnMstIko.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            BtnMstIko.Location = new Point(28, 20);
            BtnMstIko.Margin = new Padding(4);
            BtnMstIko.Name = "BtnMstIko";
            BtnMstIko.Size = new Size(308, 60);
            BtnMstIko.TabIndex = 0;
            BtnMstIko.Text = "1.マスタ移行(1)";
            BtnMstIko.TextAlign = ContentAlignment.MiddleLeft;
            BtnMstIko.UseVisualStyleBackColor = true;
            BtnMstIko.Click += BtnMstIko_Click;
            // 
            // BtnEnd
            // 
            BtnEnd.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            BtnEnd.Location = new Point(28, 330);
            BtnEnd.Margin = new Padding(4);
            BtnEnd.Name = "BtnEnd";
            BtnEnd.Size = new Size(308, 70);
            BtnEnd.TabIndex = 5;
            BtnEnd.Text = "5.終了(5)";
            BtnEnd.TextAlign = ContentAlignment.MiddleLeft;
            BtnEnd.UseVisualStyleBackColor = true;
            BtnEnd.Click += BtnEnd_Click;
            // 
            // BtnUserMst
            // 
            BtnUserMst.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            BtnUserMst.Location = new Point(28, 90);
            BtnUserMst.Margin = new Padding(4);
            BtnUserMst.Name = "BtnUserMst";
            BtnUserMst.Size = new Size(308, 70);
            BtnUserMst.TabIndex = 1;
            BtnUserMst.Text = "2.ユーザ登録・編集・削除(2)";
            BtnUserMst.TextAlign = ContentAlignment.MiddleLeft;
            BtnUserMst.UseVisualStyleBackColor = true;
            BtnUserMst.Click += BtnUserMst_Click;
            // 
            // BtnCondition
            // 
            BtnCondition.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            BtnCondition.Location = new Point(28, 170);
            BtnCondition.Margin = new Padding(4);
            BtnCondition.Name = "BtnCondition";
            BtnCondition.Size = new Size(308, 70);
            BtnCondition.TabIndex = 2;
            BtnCondition.Text = "3.試行条件の設定(3)";
            BtnCondition.TextAlign = ContentAlignment.MiddleLeft;
            BtnCondition.UseVisualStyleBackColor = true;
            BtnCondition.Click += BtnCondition_Click;
            // 
            // BtnReport
            // 
            BtnReport.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            BtnReport.Location = new Point(28, 250);
            BtnReport.Margin = new Padding(4);
            BtnReport.Name = "BtnReport";
            BtnReport.Size = new Size(308, 70);
            BtnReport.TabIndex = 3;
            BtnReport.Text = "4.解析結果の出力(4)";
            BtnReport.TextAlign = ContentAlignment.MiddleLeft;
            BtnReport.UseVisualStyleBackColor = true;
            BtnReport.Click += BtnReport_Click;
            // 
            // LblPostNo
            // 
            LblPostNo.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblPostNo.ForeColor = Color.FromArgb(255, 128, 128);
            LblPostNo.Location = new Point(8, 410);
            LblPostNo.Margin = new Padding(4, 0, 4, 0);
            LblPostNo.Name = "LblPostNo";
            LblPostNo.Size = new Size(344, 110);
            LblPostNo.TabIndex = 6;
            LblPostNo.Text = "※「アンケートカードと顧客伝票の印刷」についてはVer.3の指導者用ユーティリティにて行ってください。";
            // 
            // Frm指導者メニュー
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(359, 534);
            Controls.Add(LblPostNo);
            Controls.Add(BtnEnd);
            Controls.Add(BtnReport);
            Controls.Add(BtnCondition);
            Controls.Add(BtnUserMst);
            Controls.Add(BtnMstIko);
            Margin = new Padding(4);
            Name = "Frm指導者メニュー";
            Text = "指導者用ユーティリティ";
            Load += Frm指導者メニュー_Load;
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Button BtnMstIko;
        private System.Windows.Forms.Button BtnEnd;
        private System.Windows.Forms.Button BtnUserMst;
        private System.Windows.Forms.Button BtnCondition;
        private System.Windows.Forms.Button BtnReport;
        private System.Windows.Forms.Label LblPostNo;
    }
}

