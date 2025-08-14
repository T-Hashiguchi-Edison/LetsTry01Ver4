namespace 指導者用ユーティリティ
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
            BtnNext = new Button();
            BtnCancel = new Button();
            BtnComparison = new Button();
            LblComment1 = new Label();
            LblComment2 = new Label();
            LblListTitle = new Label();
            LblCnt2 = new Label();
            LblCnt = new Label();
            ((System.ComponentModel.ISupportInitialize)DgvUserMst).BeginInit();
            SuspendLayout();
            // 
            // DgvUserMst
            // 
            DgvUserMst.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvUserMst.Columns.AddRange(new DataGridViewColumn[] { ID, NameKnj, NameKana });
            DgvUserMst.Location = new Point(24, 88);
            DgvUserMst.MultiSelect = false;
            DgvUserMst.Name = "DgvUserMst";
            DgvUserMst.ReadOnly = true;
            DgvUserMst.RowHeadersVisible = false;
            DgvUserMst.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvUserMst.Size = new Size(624, 440);
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
            // BtnNext
            // 
            BtnNext.Location = new Point(280, 536);
            BtnNext.Name = "BtnNext";
            BtnNext.Size = new Size(184, 32);
            BtnNext.TabIndex = 2;
            BtnNext.Text = "次へ(N)";
            BtnNext.UseVisualStyleBackColor = true;
            BtnNext.Click += BtnNext_Click;
            // 
            // BtnCancel
            // 
            BtnCancel.Location = new Point(472, 536);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(184, 32);
            BtnCancel.TabIndex = 3;
            BtnCancel.Text = "閉じる";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // BtnComparison
            // 
            BtnComparison.Location = new Point(8, 536);
            BtnComparison.Name = "BtnComparison";
            BtnComparison.Size = new Size(184, 32);
            BtnComparison.TabIndex = 1;
            BtnComparison.Text = "ユーザー比較(C)";
            BtnComparison.UseVisualStyleBackColor = true;
            BtnComparison.Click += BtnComparison_Click;
            // 
            // LblComment1
            // 
            LblComment1.Font = new Font("ＭＳ Ｐゴシック", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblComment1.Location = new Point(24, 0);
            LblComment1.Margin = new Padding(4, 0, 4, 0);
            LblComment1.Name = "LblComment1";
            LblComment1.Size = new Size(541, 24);
            LblComment1.TabIndex = 4;
            LblComment1.Text = "ユーザー名リストからユーザーを選択して、[次へ]ボタンを押してください。";
            LblComment1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblComment2
            // 
            LblComment2.Font = new Font("ＭＳ Ｐゴシック", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblComment2.Location = new Point(24, 24);
            LblComment2.Margin = new Padding(4, 0, 4, 0);
            LblComment2.Name = "LblComment2";
            LblComment2.Size = new Size(541, 24);
            LblComment2.TabIndex = 5;
            LblComment2.Text = "ユーザーが見つからない場合は責任者を呼んでください。";
            LblComment2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblListTitle
            // 
            LblListTitle.Font = new Font("ＭＳ Ｐゴシック", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblListTitle.Location = new Point(24, 64);
            LblListTitle.Margin = new Padding(4, 0, 4, 0);
            LblListTitle.Name = "LblListTitle";
            LblListTitle.Size = new Size(541, 24);
            LblListTitle.TabIndex = 6;
            LblListTitle.Text = "ユーザー名リスト(L)";
            LblListTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblCnt2
            // 
            LblCnt2.Font = new Font("ＭＳ Ｐゴシック", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblCnt2.Location = new Point(624, 64);
            LblCnt2.Margin = new Padding(4, 0, 4, 0);
            LblCnt2.Name = "LblCnt2";
            LblCnt2.Size = new Size(29, 24);
            LblCnt2.TabIndex = 8;
            LblCnt2.Text = "件";
            LblCnt2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblCnt
            // 
            LblCnt.Font = new Font("ＭＳ Ｐゴシック", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            LblCnt.Location = new Point(568, 64);
            LblCnt.Margin = new Padding(4, 0, 4, 0);
            LblCnt.Name = "LblCnt";
            LblCnt.Size = new Size(56, 24);
            LblCnt.TabIndex = 7;
            LblCnt.Text = "99,999";
            LblCnt.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Frmユーザ選択
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(673, 570);
            Controls.Add(LblListTitle);
            Controls.Add(LblCnt);
            Controls.Add(LblCnt2);
            Controls.Add(LblComment2);
            Controls.Add(LblComment1);
            Controls.Add(BtnCancel);
            Controls.Add(BtnComparison);
            Controls.Add(BtnNext);
            Controls.Add(DgvUserMst);
            Name = "Frmユーザ選択";
            Text = "解析結果の出力[ユーザー名選択]";
            Load += Frmユーザ選択_Load;
            ((System.ComponentModel.ISupportInitialize)DgvUserMst).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DgvUserMst;
        private Button BtnNext;
        private Button BtnCancel;
        private Button BtnComparison;
        private Label LblComment1;
        private Label LblComment2;
        private Label LblListTitle;
        private Label LblCnt2;
        private Label LblCnt;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn NameKnj;
        private DataGridViewTextBoxColumn NameKana;
    }
}
