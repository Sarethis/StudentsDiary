namespace StudentsDiary
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvDiary = new System.Windows.Forms.DataGridView();
            this.btRefresh = new System.Windows.Forms.Button();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.btnSerializeToDifferentDataBase = new System.Windows.Forms.Button();
            this.ckbJSON = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiary)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.LawnGreen;
            this.btnAdd.Location = new System.Drawing.Point(12, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add Student";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.Gold;
            this.btnEdit.Location = new System.Drawing.Point(93, 12);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Tomato;
            this.btnDelete.Location = new System.Drawing.Point(174, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvDiary
            // 
            this.dgvDiary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDiary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDiary.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvDiary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiary.Location = new System.Drawing.Point(12, 41);
            this.dgvDiary.Name = "dgvDiary";
            this.dgvDiary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDiary.Size = new System.Drawing.Size(1005, 463);
            this.dgvDiary.TabIndex = 4;
            // 
            // btRefresh
            // 
            this.btRefresh.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btRefresh.Location = new System.Drawing.Point(255, 12);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(75, 23);
            this.btRefresh.TabIndex = 5;
            this.btRefresh.Text = "Refresh";
            this.btRefresh.UseVisualStyleBackColor = false;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // cmbGroup
            // 
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Location = new System.Drawing.Point(336, 12);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(121, 21);
            this.cmbGroup.TabIndex = 6;
            // 
            // btnSerializeToDifferentDataBase
            // 
            this.btnSerializeToDifferentDataBase.BackColor = System.Drawing.Color.Olive;
            this.btnSerializeToDifferentDataBase.Location = new System.Drawing.Point(850, 12);
            this.btnSerializeToDifferentDataBase.Name = "btnSerializeToDifferentDataBase";
            this.btnSerializeToDifferentDataBase.Size = new System.Drawing.Size(167, 23);
            this.btnSerializeToDifferentDataBase.TabIndex = 7;
            this.btnSerializeToDifferentDataBase.Text = "Seriazlize to second DataBase";
            this.btnSerializeToDifferentDataBase.UseVisualStyleBackColor = false;
            this.btnSerializeToDifferentDataBase.Click += new System.EventHandler(this.btnSerializeToDifferentDataBase_Click);
            // 
            // ckbJSON
            // 
            this.ckbJSON.AutoSize = true;
            this.ckbJSON.Location = new System.Drawing.Point(760, 16);
            this.ckbJSON.Name = "ckbJSON";
            this.ckbJSON.Size = new System.Drawing.Size(84, 17);
            this.ckbJSON.TabIndex = 8;
            this.ckbJSON.Text = "Using JSON";
            this.ckbJSON.UseVisualStyleBackColor = true;
            this.ckbJSON.CheckedChanged += new System.EventHandler(this.ckbJSON_CheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 516);
            this.Controls.Add(this.ckbJSON);
            this.Controls.Add(this.btnSerializeToDifferentDataBase);
            this.Controls.Add(this.cmbGroup);
            this.Controls.Add(this.btRefresh);
            this.Controls.Add(this.dgvDiary);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Students Diary";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        // Dev variables

        // End Dev variables

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvDiary;
        private System.Windows.Forms.Button btRefresh;
        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.Button btnSerializeToDifferentDataBase;
        private System.Windows.Forms.CheckBox ckbJSON;
    }
}

