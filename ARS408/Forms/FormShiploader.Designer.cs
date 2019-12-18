namespace ARS408.Forms
{
    partial class FormShiploader
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
            this.Column_TopicName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_OpcServerIp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_OpcServerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Changed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Main)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(12, 12);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(74, 30);
            this.button_Add.TabIndex = 8;
            this.button_Add.Text = "新增";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.Button_Add_Click);
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(92, 12);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(74, 30);
            this.button_Save.TabIndex = 9;
            this.button_Save.Text = "保存";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // button_Delete
            // 
            this.button_Delete.Location = new System.Drawing.Point(172, 12);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(74, 30);
            this.button_Delete.TabIndex = 10;
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
            this.Column_TopicName,
            this.Column_OpcServerIp,
            this.Column_OpcServerName,
            this.Column_Changed});
            this.dataGridView_Main.Location = new System.Drawing.Point(12, 48);
            this.dataGridView_Main.Name = "dataGridView_Main";
            this.dataGridView_Main.RowHeadersWidth = 51;
            this.dataGridView_Main.RowTemplate.Height = 27;
            this.dataGridView_Main.Size = new System.Drawing.Size(1149, 603);
            this.dataGridView_Main.TabIndex = 11;
            this.dataGridView_Main.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_Main_CellValueChanged);
            // 
            // Column_Id
            // 
            this.Column_Id.DataPropertyName = "SHIPLOADER_ID";
            this.Column_Id.HeaderText = "ID";
            this.Column_Id.MinimumWidth = 6;
            this.Column_Id.Name = "Column_Id";
            this.Column_Id.Visible = false;
            this.Column_Id.Width = 125;
            // 
            // Column_Name
            // 
            this.Column_Name.DataPropertyName = "SHIPLOADER_NAME";
            this.Column_Name.HeaderText = "大机名称";
            this.Column_Name.MinimumWidth = 125;
            this.Column_Name.Name = "Column_Name";
            this.Column_Name.Width = 125;
            // 
            // Column_TopicName
            // 
            this.Column_TopicName.DataPropertyName = "TOPIC_NAME";
            this.Column_TopicName.HeaderText = "Topic名称";
            this.Column_TopicName.MinimumWidth = 125;
            this.Column_TopicName.Name = "Column_TopicName";
            this.Column_TopicName.Width = 125;
            // 
            // Column_OpcServerIp
            // 
            this.Column_OpcServerIp.DataPropertyName = "OPCSERVER_IP";
            this.Column_OpcServerIp.HeaderText = "OPC服务IP";
            this.Column_OpcServerIp.MinimumWidth = 125;
            this.Column_OpcServerIp.Name = "Column_OpcServerIp";
            this.Column_OpcServerIp.ReadOnly = true;
            this.Column_OpcServerIp.Width = 125;
            // 
            // Column_OpcServerName
            // 
            this.Column_OpcServerName.DataPropertyName = "OPCSERVER_NAME";
            this.Column_OpcServerName.HeaderText = "OPC服务名称";
            this.Column_OpcServerName.MinimumWidth = 135;
            this.Column_OpcServerName.Name = "Column_OpcServerName";
            this.Column_OpcServerName.ReadOnly = true;
            this.Column_OpcServerName.Width = 135;
            // 
            // Column_Changed
            // 
            this.Column_Changed.DataPropertyName = "CHANGED";
            this.Column_Changed.HeaderText = "是否改变";
            this.Column_Changed.MinimumWidth = 125;
            this.Column_Changed.Name = "Column_Changed";
            this.Column_Changed.Visible = false;
            this.Column_Changed.Width = 125;
            // 
            // FormShiploader
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
            this.Name = "FormShiploader";
            this.Text = "大机字典";
            this.Load += new System.EventHandler(this.FormShiploader_Load);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_TopicName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_OpcServerIp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_OpcServerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Changed;
    }
}