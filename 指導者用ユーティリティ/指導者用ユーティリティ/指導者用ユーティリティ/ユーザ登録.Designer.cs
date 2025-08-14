namespace 指導者用ユーティリティ
{
    partial class Frmユーザ登録
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
            LblMstCnt = new Label();
            BtnIns = new Button();
            LblKensu = new Label();
            BtnUpd = new Button();
            BtnCancel = new Button();
            BtnDel = new Button();
            DgvUserMst = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            NameKnj = new DataGridViewTextBoxColumn();
            NameKana = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)DgvUserMst).BeginInit();
            SuspendLayout();
            // 
            // LblMstCnt
            // 
            LblMstCnt.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblMstCnt.Location = new Point(756, 0);
            LblMstCnt.Margin = new Padding(4, 0, 4, 0);
            LblMstCnt.Name = "LblMstCnt";
            LblMstCnt.Size = new Size(93, 40);
            LblMstCnt.TabIndex = 5;
            LblMstCnt.Text = "0";
            LblMstCnt.TextAlign = ContentAlignment.MiddleRight;
            // 
            // BtnIns
            // 
            BtnIns.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            BtnIns.Location = new Point(28, 530);
            BtnIns.Margin = new Padding(4);
            BtnIns.Name = "BtnIns";
            BtnIns.Size = new Size(215, 40);
            BtnIns.TabIndex = 1;
            BtnIns.Text = "新規作成(N)";
            BtnIns.UseVisualStyleBackColor = true;
            BtnIns.Click += BtnIns_Click;
            // 
            // LblKensu
            // 
            LblKensu.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblKensu.Location = new Point(849, 0);
            LblKensu.Margin = new Padding(4, 0, 4, 0);
            LblKensu.Name = "LblKensu";
            LblKensu.Size = new Size(37, 40);
            LblKensu.TabIndex = 6;
            LblKensu.Text = "件";
            LblKensu.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // BtnUpd
            // 
            BtnUpd.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            BtnUpd.Location = new Point(261, 530);
            BtnUpd.Margin = new Padding(4);
            BtnUpd.Name = "BtnUpd";
            BtnUpd.Size = new Size(215, 40);
            BtnUpd.TabIndex = 2;
            BtnUpd.Text = "編集(E)";
            BtnUpd.UseVisualStyleBackColor = true;
            BtnUpd.Click += BtnUpd_Click;
            // 
            // BtnCancel
            // 
            BtnCancel.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            BtnCancel.Location = new Point(747, 570);
            BtnCancel.Margin = new Padding(4);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(112, 40);
            BtnCancel.TabIndex = 4;
            BtnCancel.Text = "終了";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // BtnDel
            // 
            BtnDel.Font = new Font("ＭＳ Ｐゴシック", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            BtnDel.Location = new Point(495, 530);
            BtnDel.Margin = new Padding(4);
            BtnDel.Name = "BtnDel";
            BtnDel.Size = new Size(215, 40);
            BtnDel.TabIndex = 3;
            BtnDel.Text = "削除(D)";
            BtnDel.UseVisualStyleBackColor = true;
            BtnDel.Click += BtnDel_Click;
            // 
            // DgvUserMst
            // 
            DgvUserMst.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvUserMst.Columns.AddRange(new DataGridViewColumn[] { ID, NameKnj, NameKana });
            DgvUserMst.Location = new Point(28, 30);
            DgvUserMst.Margin = new Padding(4);
            DgvUserMst.MultiSelect = false;
            DgvUserMst.Name = "DgvUserMst";
            DgvUserMst.ReadOnly = true;
            DgvUserMst.RowHeadersVisible = false;
            DgvUserMst.RowHeadersWidth = 100;
            DgvUserMst.RowTemplate.Height = 21;
            DgvUserMst.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvUserMst.Size = new Size(849, 490);
            DgvUserMst.TabIndex = 0;
            DgvUserMst.CellClick += DgvUserMst_CellClick;
            DgvUserMst.CellDoubleClick += DgvUserMst_CellDoubleClick;
            DgvUserMst.KeyDown += DgvUserMst_KeyDown;
            // 
            // ID
            // 
            ID.HeaderText = "ユーザNO";
            ID.MaxInputLength = 5;
            ID.Name = "ID";
            ID.ReadOnly = true;
            // 
            // NameKnj
            // 
            NameKnj.HeaderText = "氏名";
            NameKnj.MaxInputLength = 100;
            NameKnj.Name = "NameKnj";
            NameKnj.ReadOnly = true;
            NameKnj.Width = 300;
            // 
            // NameKana
            // 
            NameKana.HeaderText = "フリガナ";
            NameKana.MaxInputLength = 100;
            NameKana.Name = "NameKana";
            NameKana.ReadOnly = true;
            NameKana.Width = 300;
            // 
            // Frmユーザ登録
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(905, 616);
            Controls.Add(DgvUserMst);
            Controls.Add(BtnCancel);
            Controls.Add(BtnDel);
            Controls.Add(BtnUpd);
            Controls.Add(BtnIns);
            Controls.Add(LblKensu);
            Controls.Add(LblMstCnt);
            Margin = new Padding(4);
            Name = "Frmユーザ登録";
            Text = "ユーザ登録・編集・削除";
            Load += Frmユーザ登録_Load;
            ((System.ComponentModel.ISupportInitialize)DgvUserMst).EndInit();
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label LblMstCnt;
        private System.Windows.Forms.Button BtnIns;
        private System.Windows.Forms.Label LblKensu;
        private System.Windows.Forms.Button BtnUpd;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnDel;
        private System.Windows.Forms.DataGridView DgvUserMst;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameKnj;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameKana;
    }
}

