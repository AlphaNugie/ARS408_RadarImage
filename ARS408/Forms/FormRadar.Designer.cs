namespace ARS408.Forms
{
    partial class FormRadar
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
            this.tableLayoutPanel_Main = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel_Buttons = new System.Windows.Forms.FlowLayoutPanel();
            this.Column_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_IpAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Port = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_OwnerGroupId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column_ConnectionMode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column_UsingLocal = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column_IpAddressLocal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_PortLocal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_DegreeYoz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_DegreeXoy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_DegreeXoz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_DegreeGeneral = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Direction = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column_DefenseMode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column_Offset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_RcsMinimum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_RcsMaximum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_RadarHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Changed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Main)).BeginInit();
            this.tableLayoutPanel_Main.SuspendLayout();
            this.flowLayoutPanel_Buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(3, 3);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(74, 30);
            this.button_Add.TabIndex = 14;
            this.button_Add.Text = "新增";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.Button_Add_Click);
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(83, 3);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(74, 30);
            this.button_Save.TabIndex = 15;
            this.button_Save.Text = "保存";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // button_Delete
            // 
            this.button_Delete.Location = new System.Drawing.Point(163, 3);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(74, 30);
            this.button_Delete.TabIndex = 16;
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
            this.Column_IpAddress,
            this.Column_Port,
            this.Column_OwnerGroupId,
            this.Column_ConnectionMode,
            this.Column_UsingLocal,
            this.Column_IpAddressLocal,
            this.Column_PortLocal,
            this.Column_DegreeYoz,
            this.Column_DegreeXoy,
            this.Column_DegreeXoz,
            this.Column_DegreeGeneral,
            this.Column_Direction,
            this.Column_DefenseMode,
            this.Column_Offset,
            this.Column_RcsMinimum,
            this.Column_RcsMaximum,
            this.Column_RadarHeight,
            this.Column_Remark,
            this.Column_Changed});
            this.dataGridView_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Main.Location = new System.Drawing.Point(3, 44);
            this.dataGridView_Main.Name = "dataGridView_Main";
            this.dataGridView_Main.RowHeadersWidth = 51;
            this.dataGridView_Main.RowTemplate.Height = 27;
            this.dataGridView_Main.Size = new System.Drawing.Size(1157, 627);
            this.dataGridView_Main.TabIndex = 17;
            this.dataGridView_Main.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_Main_CellValueChanged);
            // 
            // tableLayoutPanel_Main
            // 
            this.tableLayoutPanel_Main.ColumnCount = 1;
            this.tableLayoutPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Main.Controls.Add(this.dataGridView_Main, 0, 1);
            this.tableLayoutPanel_Main.Controls.Add(this.flowLayoutPanel_Buttons, 0, 0);
            this.tableLayoutPanel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Main.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_Main.Name = "tableLayoutPanel_Main";
            this.tableLayoutPanel_Main.RowCount = 2;
            this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Main.Size = new System.Drawing.Size(1163, 674);
            this.tableLayoutPanel_Main.TabIndex = 18;
            // 
            // flowLayoutPanel_Buttons
            // 
            this.flowLayoutPanel_Buttons.Controls.Add(this.button_Add);
            this.flowLayoutPanel_Buttons.Controls.Add(this.button_Save);
            this.flowLayoutPanel_Buttons.Controls.Add(this.button_Delete);
            this.flowLayoutPanel_Buttons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel_Buttons.Location = new System.Drawing.Point(2, 2);
            this.flowLayoutPanel_Buttons.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel_Buttons.Name = "flowLayoutPanel_Buttons";
            this.flowLayoutPanel_Buttons.Size = new System.Drawing.Size(1159, 37);
            this.flowLayoutPanel_Buttons.TabIndex = 18;
            // 
            // Column_Id
            // 
            this.Column_Id.DataPropertyName = "RADAR_ID";
            this.Column_Id.HeaderText = "ID";
            this.Column_Id.MinimumWidth = 6;
            this.Column_Id.Name = "Column_Id";
            this.Column_Id.Visible = false;
            this.Column_Id.Width = 125;
            // 
            // Column_Name
            // 
            this.Column_Name.DataPropertyName = "RADAR_NAME";
            this.Column_Name.HeaderText = "雷达名称";
            this.Column_Name.MinimumWidth = 125;
            this.Column_Name.Name = "Column_Name";
            this.Column_Name.Width = 125;
            // 
            // Column_IpAddress
            // 
            this.Column_IpAddress.DataPropertyName = "IP_ADDRESS";
            this.Column_IpAddress.HeaderText = "模块IP";
            this.Column_IpAddress.MinimumWidth = 125;
            this.Column_IpAddress.Name = "Column_IpAddress";
            this.Column_IpAddress.Width = 125;
            // 
            // Column_Port
            // 
            this.Column_Port.DataPropertyName = "PORT";
            this.Column_Port.HeaderText = "端口";
            this.Column_Port.MinimumWidth = 70;
            this.Column_Port.Name = "Column_Port";
            this.Column_Port.Width = 70;
            // 
            // Column_OwnerGroupId
            // 
            this.Column_OwnerGroupId.DataPropertyName = "OWNER_GROUP_ID";
            this.Column_OwnerGroupId.HeaderText = "雷达组";
            this.Column_OwnerGroupId.MinimumWidth = 90;
            this.Column_OwnerGroupId.Name = "Column_OwnerGroupId";
            this.Column_OwnerGroupId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column_OwnerGroupId.Width = 90;
            // 
            // Column_ConnectionMode
            // 
            this.Column_ConnectionMode.DataPropertyName = "CONN_MODE_ID";
            this.Column_ConnectionMode.HeaderText = "模式";
            this.Column_ConnectionMode.MinimumWidth = 75;
            this.Column_ConnectionMode.Name = "Column_ConnectionMode";
            this.Column_ConnectionMode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column_ConnectionMode.Width = 75;
            // 
            // Column_UsingLocal
            // 
            this.Column_UsingLocal.DataPropertyName = "USING_LOCAL";
            this.Column_UsingLocal.FalseValue = "0";
            this.Column_UsingLocal.HeaderText = "本地";
            this.Column_UsingLocal.MinimumWidth = 70;
            this.Column_UsingLocal.Name = "Column_UsingLocal";
            this.Column_UsingLocal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column_UsingLocal.TrueValue = "1";
            this.Column_UsingLocal.Width = 70;
            // 
            // Column_IpAddressLocal
            // 
            this.Column_IpAddressLocal.DataPropertyName = "IP_ADDRESS_LOCAL";
            this.Column_IpAddressLocal.HeaderText = "本地IP";
            this.Column_IpAddressLocal.MinimumWidth = 125;
            this.Column_IpAddressLocal.Name = "Column_IpAddressLocal";
            this.Column_IpAddressLocal.Visible = false;
            this.Column_IpAddressLocal.Width = 125;
            // 
            // Column_PortLocal
            // 
            this.Column_PortLocal.DataPropertyName = "PORT_LOCAL";
            this.Column_PortLocal.HeaderText = "本地端口";
            this.Column_PortLocal.MinimumWidth = 100;
            this.Column_PortLocal.Name = "Column_PortLocal";
            this.Column_PortLocal.Width = 125;
            // 
            // Column_DegreeYoz
            // 
            this.Column_DegreeYoz.DataPropertyName = "DEGREE_YOZ";
            this.Column_DegreeYoz.HeaderText = "YOZ";
            this.Column_DegreeYoz.MinimumWidth = 55;
            this.Column_DegreeYoz.Name = "Column_DegreeYoz";
            this.Column_DegreeYoz.Width = 55;
            // 
            // Column_DegreeXoy
            // 
            this.Column_DegreeXoy.DataPropertyName = "DEGREE_XOY";
            this.Column_DegreeXoy.HeaderText = "XOY";
            this.Column_DegreeXoy.MinimumWidth = 55;
            this.Column_DegreeXoy.Name = "Column_DegreeXoy";
            this.Column_DegreeXoy.Width = 55;
            // 
            // Column_DegreeXoz
            // 
            this.Column_DegreeXoz.DataPropertyName = "DEGREE_XOZ";
            this.Column_DegreeXoz.HeaderText = "XOZ";
            this.Column_DegreeXoz.MinimumWidth = 55;
            this.Column_DegreeXoz.Name = "Column_DegreeXoz";
            this.Column_DegreeXoz.Width = 55;
            // 
            // Column_DegreeGeneral
            // 
            this.Column_DegreeGeneral.DataPropertyName = "DEGREE_GENERAL";
            this.Column_DegreeGeneral.HeaderText = "偏转";
            this.Column_DegreeGeneral.MinimumWidth = 70;
            this.Column_DegreeGeneral.Name = "Column_DegreeGeneral";
            this.Column_DegreeGeneral.Width = 70;
            // 
            // Column_Direction
            // 
            this.Column_Direction.DataPropertyName = "DIRECTION_ID";
            this.Column_Direction.HeaderText = "朝向";
            this.Column_Direction.MinimumWidth = 70;
            this.Column_Direction.Name = "Column_Direction";
            this.Column_Direction.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column_Direction.Width = 70;
            // 
            // Column_DefenseMode
            // 
            this.Column_DefenseMode.DataPropertyName = "DEFENSE_MODE_ID";
            this.Column_DefenseMode.HeaderText = "防御";
            this.Column_DefenseMode.MinimumWidth = 70;
            this.Column_DefenseMode.Name = "Column_DefenseMode";
            this.Column_DefenseMode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column_DefenseMode.Width = 70;
            // 
            // Column_Offset
            // 
            this.Column_Offset.DataPropertyName = "OFFSET";
            this.Column_Offset.HeaderText = "校正";
            this.Column_Offset.MinimumWidth = 70;
            this.Column_Offset.Name = "Column_Offset";
            this.Column_Offset.Width = 70;
            // 
            // Column_RcsMinimum
            // 
            this.Column_RcsMinimum.DataPropertyName = "RCS_MIN";
            this.Column_RcsMinimum.HeaderText = "RCS小";
            this.Column_RcsMinimum.MinimumWidth = 80;
            this.Column_RcsMinimum.Name = "Column_RcsMinimum";
            this.Column_RcsMinimum.Width = 80;
            // 
            // Column_RcsMaximum
            // 
            this.Column_RcsMaximum.DataPropertyName = "RCS_MAX";
            this.Column_RcsMaximum.HeaderText = "RCS大";
            this.Column_RcsMaximum.MinimumWidth = 80;
            this.Column_RcsMaximum.Name = "Column_RcsMaximum";
            this.Column_RcsMaximum.Width = 80;
            // 
            // Column_RadarHeight
            // 
            this.Column_RadarHeight.DataPropertyName = "RADAR_HEIGHT";
            this.Column_RadarHeight.HeaderText = "高度";
            this.Column_RadarHeight.MinimumWidth = 70;
            this.Column_RadarHeight.Name = "Column_RadarHeight";
            this.Column_RadarHeight.Width = 70;
            // 
            // Column_Remark
            // 
            this.Column_Remark.DataPropertyName = "REMARK";
            this.Column_Remark.HeaderText = "备注";
            this.Column_Remark.MinimumWidth = 145;
            this.Column_Remark.Name = "Column_Remark";
            this.Column_Remark.Width = 145;
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
            // FormRadar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 674);
            this.Controls.Add(this.tableLayoutPanel_Main);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormRadar";
            this.Text = "雷达字典";
            this.Load += new System.EventHandler(this.FormRadar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Main)).EndInit();
            this.tableLayoutPanel_Main.ResumeLayout(false);
            this.flowLayoutPanel_Buttons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.DataGridView dataGridView_Main;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Main;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_Buttons;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_IpAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Port;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column_OwnerGroupId;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column_ConnectionMode;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column_UsingLocal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_IpAddressLocal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_PortLocal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_DegreeYoz;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_DegreeXoy;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_DegreeXoz;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_DegreeGeneral;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column_Direction;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column_DefenseMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Offset;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_RcsMinimum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_RcsMaximum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_RadarHeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Changed;
    }
}