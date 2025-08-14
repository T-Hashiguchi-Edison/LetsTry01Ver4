namespace パソコンデータ入力
{
    partial class Frmユーザ選択
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
            DgvUserMst = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            NameKnj = new DataGridViewTextBoxColumn();
            NameKana = new DataGridViewTextBoxColumn();
            氏 = new DataGridViewTextBoxColumn();
            名 = new DataGridViewTextBoxColumn();
            BtnNext = new Button();
            BtnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)DgvUserMst).BeginInit();
            SuspendLayout();
            // 
            // DgvUserMst
            // 
            DgvUserMst.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvUserMst.Columns.AddRange(new DataGridViewColumn[] { ID, NameKnj, NameKana, 氏, 名 });
            DgvUserMst.Location = new Point(24, 24);
            DgvUserMst.MultiSelect = false;
            DgvUserMst.Name = "DgvUserMst";
            DgvUserMst.ReadOnly = true;
            DgvUserMst.RowHeadersVisible = false;
            DgvUserMst.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvUserMst.Size = new Size(624, 464);
            DgvUserMst.TabIndex = 0;
            DgvUserMst.CellClick += DgvUserMst_CellClick;
            DgvUserMst.CellDoubleClick += DgvUserMst_CellDoubleClick;
            DgvUserMst.KeyDown += DgvUserMst_KeyDown;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Visible = false;
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
            NameKana.Name = "NameKana";
            NameKana.ReadOnly = true;
            NameKana.Width = 300;
            // 
            // 氏
            // 
            氏.HeaderText = "氏";
            氏.Name = "氏";
            氏.ReadOnly = true;
            氏.Visible = false;
            // 
            // 名
            // 
            名.HeaderText = "名";
            名.Name = "名";
            名.ReadOnly = true;
            名.Visible = false;
            // 
            // BtnNext
            // 
            BtnNext.Location = new Point(244, 496);
            BtnNext.Name = "BtnNext";
            BtnNext.Size = new Size(184, 32);
            BtnNext.TabIndex = 1;
            BtnNext.Text = "次へ";
            BtnNext.UseVisualStyleBackColor = true;
            BtnNext.Click += BtnNext_Click;
            // 
            // BtnCancel
            // 
            BtnCancel.Location = new Point(472, 536);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(184, 32);
            BtnCancel.TabIndex = 2;
            BtnCancel.Text = "閉じる";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // Frmユーザ選択
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(673, 571);
            Controls.Add(BtnCancel);
            Controls.Add(BtnNext);
            Controls.Add(DgvUserMst);
            Name = "Frmユーザ選択";
            Text = "やってみよう！パソコンデータ入力";
            Load += Frmユーザ選択_Load;
            ((System.ComponentModel.ISupportInitialize)DgvUserMst).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DgvUserMst;
        private Button BtnNext;
        private Button BtnCancel;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn NameKnj;
        private DataGridViewTextBoxColumn NameKana;
        private DataGridViewTextBoxColumn 氏;
        private DataGridViewTextBoxColumn 名;
    }
}
