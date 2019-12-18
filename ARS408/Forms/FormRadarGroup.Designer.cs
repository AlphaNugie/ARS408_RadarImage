namespace ARS408.Forms
{
    partial class FormRadarGroup
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
            this.button_Add = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_Delete = new System.Windows.Forms.Button();
            this.dataGridView_Main = new System.Windows.Forms.DataGridView();
            this.Column_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_OwnerShiploaderId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column_GroupType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column_Changed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Main)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(12, 12);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(74, 30);
            this.button_Add.TabIndex = 11;
            this.button_Add.Text = "新增";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.Button_Add_Click);
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(92, 12);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(74, 30);
            this.button_Save.TabIndex = 12;
            this.button_Save.Text = "保存";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // button_Delete
            // 
            this.button_Delete.Location = new System.Drawing.Point(172, 12);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(74, 30);
            this.button_Delete.TabIndex = 13;
            this.button_Delete.Text = "删除";
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.Button_Delete_Click);
            // 
            // dataGridView_Main
            // 
            this.dataGridView_Main.AllowUserToAddRows = false;
            this.dataGridView_Main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Id,
            this.Column_Name,
            this.Column_OwnerShiploaderId,
            this.Column_GroupType,
            this.Column_Changed});
            this.dataGridView_Main.Location = new System.Drawing.Point(12, 48);
            this.dataGridView_Main.Name = "dataGridView_Main";
            this.dataGridView_Main.RowHeadersWidth = 51;
            this.dataGridView_Main.RowTemplate.Height = 27;
            this.dataGridView_Main.Size = new System.Drawing.Size(1149, 603);
            this.dataGridView_Main.TabIndex = 14;
            this.dataGridView_Main.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_Main_CellValueChanged);
            // 
            // Column_Id
            // 
            this.Column_Id.DataPropertyName = "GROUP_ID";
            this.Column_Id.HeaderText = "ID";
            this.Column_Id.MinimumWidth = 125;
            this.Column_Id.Name = "Column_Id";
            this.Column_Id.Visible = false;
            this.Column_Id.Width = 125;
            // 
            // Column_Name
            // 
            this.Column_Name.DataPropertyName = "GROUP_NAME";
            this.Column_Name.HeaderText = "雷达组名称";
            this.Column_Name.MinimumWidth = 125;
            this.Column_Name.Name = "Column_Name";
            this.Column_Name.Width = 125;
            // 
            // Column_OwnerShiploaderId
            // 
            this.Column_OwnerShiploaderId.DataPropertyName = "OWNER_SHIPLOADER_ID";
            this.Column_OwnerShiploaderId.HeaderText = "所属大机";
            this.Column_OwnerShiploaderId.MinimumWidth = 135;
            this.Column_OwnerShiploaderId.Name = "Column_OwnerShiploaderId";
            this.Column_OwnerShiploaderId.Width = 135;
            // 
            // Column_GroupType
            // 
            this.Column_GroupType.DataPropertyName = "GROUP_TYPE";
            this.Column_GroupType.HeaderText = "组类型";
            this.Column_GroupType.MinimumWidth = 135;
            this.Column_GroupType.Name = "Column_GroupType";
            this.Column_GroupType.Width = 135;
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
            // FormRadarGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 663);
            this.Controls.Add(this.dataGridView_Main);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.button_Delete);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormRadarGroup";
            this.Text = "雷达组字典";
            this.Load += new System.EventHandler(this.FormRadarGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Main)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.DataGridView dataGridView_Main;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Name;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column_OwnerShiploaderId;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column_GroupType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Changed;
    }
}