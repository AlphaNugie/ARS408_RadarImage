namespace ARS408.Forms
{
    partial class FormThreatLevels
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
            this.button_Save = new System.Windows.Forms.Button();
            this.dataGridView_Main = new System.Windows.Forms.DataGridView();
            this.Column_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Changed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Main)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(12, 12);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(74, 30);
            this.button_Save.TabIndex = 16;
            this.button_Save.Text = "保存";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // dataGridView_Main
            // 
            this.dataGridView_Main.AllowUserToAddRows = false;
            this.dataGridView_Main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Id,
            this.Column_Name,
            this.Column_Changed});
            this.dataGridView_Main.Location = new System.Drawing.Point(12, 48);
            this.dataGridView_Main.Name = "dataGridView_Main";
            this.dataGridView_Main.RowHeadersWidth = 51;
            this.dataGridView_Main.RowTemplate.Height = 27;
            this.dataGridView_Main.Size = new System.Drawing.Size(1139, 614);
            this.dataGridView_Main.TabIndex = 18;
            this.dataGridView_Main.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_Main_CellValueChanged);
            // 
            // Column_Id
            // 
            this.Column_Id.DataPropertyName = "LEVEL_NUM";
            this.Column_Id.HeaderText = "报警级数";
            this.Column_Id.MinimumWidth = 100;
            this.Column_Id.Name = "Column_Id";
            this.Column_Id.ReadOnly = true;
            this.Column_Id.Width = 125;
            // 
            // Column_Name
            // 
            this.Column_Name.DataPropertyName = "LEVEL_VALUE";
            this.Column_Name.HeaderText = "报警数值";
            this.Column_Name.MinimumWidth = 150;
            this.Column_Name.Name = "Column_Name";
            this.Column_Name.Width = 150;
            // 
            // Column_Changed
            // 
            this.Column_Changed.DataPropertyName = "CHANGED";
            this.Column_Changed.HeaderText = "是否改变";
            this.Column_Changed.MinimumWidth = 6;
            this.Column_Changed.Name = "Column_Changed";
            this.Column_Changed.Visible = false;
            this.Column_Changed.Width = 125;
            // 
            // FormThreatLevels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 674);
            this.Controls.Add(this.dataGridView_Main);
            this.Controls.Add(this.button_Save);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormThreatLevels";
            this.Text = "威胁级数";
            this.Load += new System.EventHandler(this.FormThreatLevels_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Main)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.DataGridView dataGridView_Main;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Changed;
    }
}