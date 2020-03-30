namespace ARS408.Forms
{
    partial class FormOpcConfig
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_OpcServerIp = new System.Windows.Forms.TextBox();
            this.button_ServerEnum = new System.Windows.Forms.Button();
            this.comboBox_OpcServerList = new System.Windows.Forms.ComboBox();
            this.button_Connect = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_SaveServerInfo = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_TopicName_WalkingPos = new System.Windows.Forms.ComboBox();
            this.comboBox_TopicName_PitchAngle = new System.Windows.Forms.ComboBox();
            this.comboBox_TopicName_StretchLength = new System.Windows.Forms.ComboBox();
            this.textBox_ItemName_WalkingPos = new System.Windows.Forms.TextBox();
            this.textBox_ItemName_PitchAngle = new System.Windows.Forms.TextBox();
            this.textBox_ItemName_StretchLength = new System.Windows.Forms.TextBox();
            this.textBox_ItemValue_WalkingPos = new System.Windows.Forms.TextBox();
            this.textBox_ItemValue_PitchAngle = new System.Windows.Forms.TextBox();
            this.textBox_ItemValue_StretchLength = new System.Windows.Forms.TextBox();
            this.button_GetValue_WalkingPos = new System.Windows.Forms.Button();
            this.button_GetValue_PitchAngle = new System.Windows.Forms.Button();
            this.button_GetValue_StretchLength = new System.Windows.Forms.Button();
            this.label_WalkingPos = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button_SaveItemInfo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_TopicName_BucketPitch = new System.Windows.Forms.ComboBox();
            this.textBox_ItemName_BucketPitch = new System.Windows.Forms.TextBox();
            this.textBox_ItemValue_BucketPitch = new System.Windows.Forms.TextBox();
            this.button_GetValue_BucketPitch = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox_WriteItemValue = new System.Windows.Forms.CheckBox();
            this.textBox_TopicName_Stream = new System.Windows.Forms.TextBox();
            this.textBox_TopicName_BeltSpeed = new System.Windows.Forms.TextBox();
            this.textBox_TopicName_BucketPitch = new System.Windows.Forms.TextBox();
            this.textBox_TopicName_BucketYaw = new System.Windows.Forms.TextBox();
            this.textBox_TopicName_StretchLength = new System.Windows.Forms.TextBox();
            this.textBox_TopicName_PitchAngle = new System.Windows.Forms.TextBox();
            this.textBox_TopicName_WalkingPos = new System.Windows.Forms.TextBox();
            this.button_SaveRadar = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_GetValue_Stream = new System.Windows.Forms.Button();
            this.button_GetValue_BeltSpeed = new System.Windows.Forms.Button();
            this.comboBox_TopicName_BucketYaw = new System.Windows.Forms.ComboBox();
            this.button_GetValue_BucketYaw = new System.Windows.Forms.Button();
            this.comboBox_TopicName_Stream = new System.Windows.Forms.ComboBox();
            this.comboBox_TopicName_BeltSpeed = new System.Windows.Forms.ComboBox();
            this.textBox_ItemValue_Stream = new System.Windows.Forms.TextBox();
            this.textBox_ItemValue_BeltSpeed = new System.Windows.Forms.TextBox();
            this.textBox_ItemName_BucketYaw = new System.Windows.Forms.TextBox();
            this.textBox_ItemValue_BucketYaw = new System.Windows.Forms.TextBox();
            this.textBox_ItemName_Stream = new System.Windows.Forms.TextBox();
            this.textBox_ItemName_BeltSpeed = new System.Windows.Forms.TextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Column_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ItemNameRadarState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ItemNameCollisionState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ItemNameCollisionState2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Changed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP地址";
            // 
            // textBox_OpcServerIp
            // 
            this.textBox_OpcServerIp.Location = new System.Drawing.Point(73, 28);
            this.textBox_OpcServerIp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_OpcServerIp.Name = "textBox_OpcServerIp";
            this.textBox_OpcServerIp.Size = new System.Drawing.Size(165, 27);
            this.textBox_OpcServerIp.TabIndex = 1;
            this.textBox_OpcServerIp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_OpcServerIp_KeyDown);
            // 
            // button_ServerEnum
            // 
            this.button_ServerEnum.Location = new System.Drawing.Point(549, 28);
            this.button_ServerEnum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_ServerEnum.Name = "button_ServerEnum";
            this.button_ServerEnum.Size = new System.Drawing.Size(64, 29);
            this.button_ServerEnum.TabIndex = 2;
            this.button_ServerEnum.Text = "枚举";
            this.button_ServerEnum.UseVisualStyleBackColor = true;
            this.button_ServerEnum.Click += new System.EventHandler(this.Button_ServerEnum_Click);
            // 
            // comboBox_OpcServerList
            // 
            this.comboBox_OpcServerList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_OpcServerList.FormattingEnabled = true;
            this.comboBox_OpcServerList.Location = new System.Drawing.Point(244, 28);
            this.comboBox_OpcServerList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox_OpcServerList.Name = "comboBox_OpcServerList";
            this.comboBox_OpcServerList.Size = new System.Drawing.Size(299, 28);
            this.comboBox_OpcServerList.TabIndex = 3;
            // 
            // button_Connect
            // 
            this.button_Connect.Location = new System.Drawing.Point(619, 28);
            this.button_Connect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(64, 29);
            this.button_Connect.TabIndex = 2;
            this.button_Connect.Text = "连接";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.Button_Connect_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_SaveServerInfo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_OpcServerIp);
            this.groupBox1.Controls.Add(this.button_ServerEnum);
            this.groupBox1.Controls.Add(this.comboBox_OpcServerList);
            this.groupBox1.Controls.Add(this.button_Connect);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(1050, 73);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "OPC服务器";
            // 
            // button_SaveServerInfo
            // 
            this.button_SaveServerInfo.Location = new System.Drawing.Point(689, 28);
            this.button_SaveServerInfo.Name = "button_SaveServerInfo";
            this.button_SaveServerInfo.Size = new System.Drawing.Size(64, 29);
            this.button_SaveServerInfo.TabIndex = 4;
            this.button_SaveServerInfo.Text = "保存";
            this.button_SaveServerInfo.UseVisualStyleBackColor = true;
            this.button_SaveServerInfo.Click += new System.EventHandler(this.Button_ServerSave_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(590, 15);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "标签值";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(421, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "标签名称";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(249, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "Topic名称";
            // 
            // comboBox_TopicName_WalkingPos
            // 
            this.comboBox_TopicName_WalkingPos.DisplayMember = "TOPIC_NAME";
            this.comboBox_TopicName_WalkingPos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_TopicName_WalkingPos.FormattingEnabled = true;
            this.comboBox_TopicName_WalkingPos.Location = new System.Drawing.Point(100, 38);
            this.comboBox_TopicName_WalkingPos.Name = "comboBox_TopicName_WalkingPos";
            this.comboBox_TopicName_WalkingPos.Size = new System.Drawing.Size(122, 28);
            this.comboBox_TopicName_WalkingPos.TabIndex = 19;
            this.comboBox_TopicName_WalkingPos.ValueMember = "SHIPLOADER_ID";
            this.comboBox_TopicName_WalkingPos.SelectedIndexChanged += new System.EventHandler(this.ComboBox_TopicName_WalkingPos_SelectedIndexChanged);
            // 
            // comboBox_TopicName_PitchAngle
            // 
            this.comboBox_TopicName_PitchAngle.DisplayMember = "TOPIC_NAME";
            this.comboBox_TopicName_PitchAngle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_TopicName_PitchAngle.FormattingEnabled = true;
            this.comboBox_TopicName_PitchAngle.Location = new System.Drawing.Point(100, 69);
            this.comboBox_TopicName_PitchAngle.Name = "comboBox_TopicName_PitchAngle";
            this.comboBox_TopicName_PitchAngle.Size = new System.Drawing.Size(122, 28);
            this.comboBox_TopicName_PitchAngle.TabIndex = 19;
            this.comboBox_TopicName_PitchAngle.ValueMember = "SHIPLOADER_ID";
            this.comboBox_TopicName_PitchAngle.SelectedIndexChanged += new System.EventHandler(this.ComboBox_TopicName_PitchAngle_SelectedIndexChanged);
            // 
            // comboBox_TopicName_StretchLength
            // 
            this.comboBox_TopicName_StretchLength.DisplayMember = "TOPIC_NAME";
            this.comboBox_TopicName_StretchLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_TopicName_StretchLength.FormattingEnabled = true;
            this.comboBox_TopicName_StretchLength.Location = new System.Drawing.Point(100, 100);
            this.comboBox_TopicName_StretchLength.Name = "comboBox_TopicName_StretchLength";
            this.comboBox_TopicName_StretchLength.Size = new System.Drawing.Size(122, 28);
            this.comboBox_TopicName_StretchLength.TabIndex = 19;
            this.comboBox_TopicName_StretchLength.ValueMember = "SHIPLOADER_ID";
            this.comboBox_TopicName_StretchLength.SelectedIndexChanged += new System.EventHandler(this.ComboBox_TopicName_StretchLength_SelectedIndexChanged);
            // 
            // textBox_ItemName_WalkingPos
            // 
            this.textBox_ItemName_WalkingPos.Location = new System.Drawing.Point(355, 39);
            this.textBox_ItemName_WalkingPos.Name = "textBox_ItemName_WalkingPos";
            this.textBox_ItemName_WalkingPos.Size = new System.Drawing.Size(197, 27);
            this.textBox_ItemName_WalkingPos.TabIndex = 20;
            // 
            // textBox_ItemName_PitchAngle
            // 
            this.textBox_ItemName_PitchAngle.Location = new System.Drawing.Point(355, 70);
            this.textBox_ItemName_PitchAngle.Name = "textBox_ItemName_PitchAngle";
            this.textBox_ItemName_PitchAngle.Size = new System.Drawing.Size(197, 27);
            this.textBox_ItemName_PitchAngle.TabIndex = 20;
            // 
            // textBox_ItemName_StretchLength
            // 
            this.textBox_ItemName_StretchLength.Location = new System.Drawing.Point(355, 101);
            this.textBox_ItemName_StretchLength.Name = "textBox_ItemName_StretchLength";
            this.textBox_ItemName_StretchLength.Size = new System.Drawing.Size(197, 27);
            this.textBox_ItemName_StretchLength.TabIndex = 20;
            // 
            // textBox_ItemValue_WalkingPos
            // 
            this.textBox_ItemValue_WalkingPos.Enabled = false;
            this.textBox_ItemValue_WalkingPos.Location = new System.Drawing.Point(558, 38);
            this.textBox_ItemValue_WalkingPos.Name = "textBox_ItemValue_WalkingPos";
            this.textBox_ItemValue_WalkingPos.Size = new System.Drawing.Size(125, 27);
            this.textBox_ItemValue_WalkingPos.TabIndex = 21;
            // 
            // textBox_ItemValue_PitchAngle
            // 
            this.textBox_ItemValue_PitchAngle.Enabled = false;
            this.textBox_ItemValue_PitchAngle.Location = new System.Drawing.Point(558, 69);
            this.textBox_ItemValue_PitchAngle.Name = "textBox_ItemValue_PitchAngle";
            this.textBox_ItemValue_PitchAngle.Size = new System.Drawing.Size(125, 27);
            this.textBox_ItemValue_PitchAngle.TabIndex = 21;
            // 
            // textBox_ItemValue_StretchLength
            // 
            this.textBox_ItemValue_StretchLength.Enabled = false;
            this.textBox_ItemValue_StretchLength.Location = new System.Drawing.Point(558, 100);
            this.textBox_ItemValue_StretchLength.Name = "textBox_ItemValue_StretchLength";
            this.textBox_ItemValue_StretchLength.Size = new System.Drawing.Size(125, 27);
            this.textBox_ItemValue_StretchLength.TabIndex = 21;
            // 
            // button_GetValue_WalkingPos
            // 
            this.button_GetValue_WalkingPos.Location = new System.Drawing.Point(689, 38);
            this.button_GetValue_WalkingPos.Name = "button_GetValue_WalkingPos";
            this.button_GetValue_WalkingPos.Size = new System.Drawing.Size(53, 25);
            this.button_GetValue_WalkingPos.TabIndex = 22;
            this.button_GetValue_WalkingPos.Text = "测试";
            this.button_GetValue_WalkingPos.UseVisualStyleBackColor = true;
            this.button_GetValue_WalkingPos.Click += new System.EventHandler(this.Button_GetValue1_Click);
            // 
            // button_GetValue_PitchAngle
            // 
            this.button_GetValue_PitchAngle.Location = new System.Drawing.Point(689, 69);
            this.button_GetValue_PitchAngle.Name = "button_GetValue_PitchAngle";
            this.button_GetValue_PitchAngle.Size = new System.Drawing.Size(53, 25);
            this.button_GetValue_PitchAngle.TabIndex = 22;
            this.button_GetValue_PitchAngle.Text = "测试";
            this.button_GetValue_PitchAngle.UseVisualStyleBackColor = true;
            this.button_GetValue_PitchAngle.Click += new System.EventHandler(this.Button_GetValue2_Click);
            // 
            // button_GetValue_StretchLength
            // 
            this.button_GetValue_StretchLength.Location = new System.Drawing.Point(689, 100);
            this.button_GetValue_StretchLength.Name = "button_GetValue_StretchLength";
            this.button_GetValue_StretchLength.Size = new System.Drawing.Size(53, 25);
            this.button_GetValue_StretchLength.TabIndex = 22;
            this.button_GetValue_StretchLength.Text = "测试";
            this.button_GetValue_StretchLength.UseVisualStyleBackColor = true;
            this.button_GetValue_StretchLength.Click += new System.EventHandler(this.Button_GetValue3_Click);
            // 
            // label_WalkingPos
            // 
            this.label_WalkingPos.AutoSize = true;
            this.label_WalkingPos.Location = new System.Drawing.Point(25, 42);
            this.label_WalkingPos.Name = "label_WalkingPos";
            this.label_WalkingPos.Size = new System.Drawing.Size(69, 20);
            this.label_WalkingPos.TabIndex = 23;
            this.label_WalkingPos.Text = "行走位置";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 20);
            this.label10.TabIndex = 23;
            this.label10.Text = "大臂俯仰";
            // 
            // button_SaveItemInfo
            // 
            this.button_SaveItemInfo.Location = new System.Drawing.Point(472, 264);
            this.button_SaveItemInfo.Name = "button_SaveItemInfo";
            this.button_SaveItemInfo.Size = new System.Drawing.Size(81, 28);
            this.button_SaveItemInfo.TabIndex = 4;
            this.button_SaveItemInfo.Text = "保存大机";
            this.button_SaveItemInfo.UseVisualStyleBackColor = true;
            this.button_SaveItemInfo.Click += new System.EventHandler(this.Button_SaveItemInfo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "伸缩距离";
            // 
            // comboBox_TopicName_BucketPitch
            // 
            this.comboBox_TopicName_BucketPitch.DisplayMember = "TOPIC_NAME";
            this.comboBox_TopicName_BucketPitch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_TopicName_BucketPitch.FormattingEnabled = true;
            this.comboBox_TopicName_BucketPitch.Location = new System.Drawing.Point(100, 131);
            this.comboBox_TopicName_BucketPitch.Name = "comboBox_TopicName_BucketPitch";
            this.comboBox_TopicName_BucketPitch.Size = new System.Drawing.Size(122, 28);
            this.comboBox_TopicName_BucketPitch.TabIndex = 19;
            this.comboBox_TopicName_BucketPitch.ValueMember = "SHIPLOADER_ID";
            this.comboBox_TopicName_BucketPitch.SelectedIndexChanged += new System.EventHandler(this.ComboBox_TopicName_BucketPitch_SelectedIndexChanged);
            // 
            // textBox_ItemName_BucketPitch
            // 
            this.textBox_ItemName_BucketPitch.Location = new System.Drawing.Point(355, 132);
            this.textBox_ItemName_BucketPitch.Name = "textBox_ItemName_BucketPitch";
            this.textBox_ItemName_BucketPitch.Size = new System.Drawing.Size(197, 27);
            this.textBox_ItemName_BucketPitch.TabIndex = 20;
            // 
            // textBox_ItemValue_BucketPitch
            // 
            this.textBox_ItemValue_BucketPitch.Enabled = false;
            this.textBox_ItemValue_BucketPitch.Location = new System.Drawing.Point(558, 131);
            this.textBox_ItemValue_BucketPitch.Name = "textBox_ItemValue_BucketPitch";
            this.textBox_ItemValue_BucketPitch.Size = new System.Drawing.Size(125, 27);
            this.textBox_ItemValue_BucketPitch.TabIndex = 21;
            // 
            // button_GetValue_BucketPitch
            // 
            this.button_GetValue_BucketPitch.Location = new System.Drawing.Point(689, 131);
            this.button_GetValue_BucketPitch.Name = "button_GetValue_BucketPitch";
            this.button_GetValue_BucketPitch.Size = new System.Drawing.Size(53, 25);
            this.button_GetValue_BucketPitch.TabIndex = 22;
            this.button_GetValue_BucketPitch.Text = "测试";
            this.button_GetValue_BucketPitch.UseVisualStyleBackColor = true;
            this.button_GetValue_BucketPitch.Click += new System.EventHandler(this.Button_GetValue4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "溜桶俯仰";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox_WriteItemValue);
            this.groupBox2.Controls.Add(this.textBox_TopicName_Stream);
            this.groupBox2.Controls.Add(this.textBox_TopicName_BeltSpeed);
            this.groupBox2.Controls.Add(this.textBox_TopicName_BucketPitch);
            this.groupBox2.Controls.Add(this.textBox_TopicName_BucketYaw);
            this.groupBox2.Controls.Add(this.textBox_TopicName_StretchLength);
            this.groupBox2.Controls.Add(this.textBox_TopicName_PitchAngle);
            this.groupBox2.Controls.Add(this.textBox_TopicName_WalkingPos);
            this.groupBox2.Controls.Add(this.label_WalkingPos);
            this.groupBox2.Controls.Add(this.button_SaveRadar);
            this.groupBox2.Controls.Add(this.button_SaveItemInfo);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.comboBox_TopicName_WalkingPos);
            this.groupBox2.Controls.Add(this.button_GetValue_Stream);
            this.groupBox2.Controls.Add(this.button_GetValue_BeltSpeed);
            this.groupBox2.Controls.Add(this.comboBox_TopicName_PitchAngle);
            this.groupBox2.Controls.Add(this.comboBox_TopicName_BucketYaw);
            this.groupBox2.Controls.Add(this.button_GetValue_BucketPitch);
            this.groupBox2.Controls.Add(this.button_GetValue_BucketYaw);
            this.groupBox2.Controls.Add(this.comboBox_TopicName_StretchLength);
            this.groupBox2.Controls.Add(this.comboBox_TopicName_Stream);
            this.groupBox2.Controls.Add(this.comboBox_TopicName_BeltSpeed);
            this.groupBox2.Controls.Add(this.button_GetValue_StretchLength);
            this.groupBox2.Controls.Add(this.comboBox_TopicName_BucketPitch);
            this.groupBox2.Controls.Add(this.button_GetValue_PitchAngle);
            this.groupBox2.Controls.Add(this.textBox_ItemName_WalkingPos);
            this.groupBox2.Controls.Add(this.button_GetValue_WalkingPos);
            this.groupBox2.Controls.Add(this.textBox_ItemValue_Stream);
            this.groupBox2.Controls.Add(this.textBox_ItemValue_BeltSpeed);
            this.groupBox2.Controls.Add(this.textBox_ItemName_PitchAngle);
            this.groupBox2.Controls.Add(this.textBox_ItemName_BucketYaw);
            this.groupBox2.Controls.Add(this.textBox_ItemValue_BucketPitch);
            this.groupBox2.Controls.Add(this.textBox_ItemValue_BucketYaw);
            this.groupBox2.Controls.Add(this.textBox_ItemName_Stream);
            this.groupBox2.Controls.Add(this.textBox_ItemName_StretchLength);
            this.groupBox2.Controls.Add(this.textBox_ItemName_BeltSpeed);
            this.groupBox2.Controls.Add(this.textBox_ItemValue_StretchLength);
            this.groupBox2.Controls.Add(this.textBox_ItemName_BucketPitch);
            this.groupBox2.Controls.Add(this.textBox_ItemValue_PitchAngle);
            this.groupBox2.Controls.Add(this.textBox_ItemValue_WalkingPos);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 84);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1050, 306);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "标签配置";
            // 
            // checkBox_WriteItemValue
            // 
            this.checkBox_WriteItemValue.AutoSize = true;
            this.checkBox_WriteItemValue.Location = new System.Drawing.Point(29, 272);
            this.checkBox_WriteItemValue.Name = "checkBox_WriteItemValue";
            this.checkBox_WriteItemValue.Size = new System.Drawing.Size(121, 24);
            this.checkBox_WriteItemValue.TabIndex = 25;
            this.checkBox_WriteItemValue.Text = "是否写入标签";
            this.checkBox_WriteItemValue.UseVisualStyleBackColor = true;
            this.checkBox_WriteItemValue.CheckedChanged += new System.EventHandler(this.CheckBox_WriteItemValue_CheckedChanged);
            // 
            // textBox_TopicName_Stream
            // 
            this.textBox_TopicName_Stream.Location = new System.Drawing.Point(228, 228);
            this.textBox_TopicName_Stream.Name = "textBox_TopicName_Stream";
            this.textBox_TopicName_Stream.Size = new System.Drawing.Size(121, 27);
            this.textBox_TopicName_Stream.TabIndex = 24;
            // 
            // textBox_TopicName_BeltSpeed
            // 
            this.textBox_TopicName_BeltSpeed.Location = new System.Drawing.Point(228, 195);
            this.textBox_TopicName_BeltSpeed.Name = "textBox_TopicName_BeltSpeed";
            this.textBox_TopicName_BeltSpeed.Size = new System.Drawing.Size(121, 27);
            this.textBox_TopicName_BeltSpeed.TabIndex = 24;
            // 
            // textBox_TopicName_BucketPitch
            // 
            this.textBox_TopicName_BucketPitch.Location = new System.Drawing.Point(228, 132);
            this.textBox_TopicName_BucketPitch.Name = "textBox_TopicName_BucketPitch";
            this.textBox_TopicName_BucketPitch.Size = new System.Drawing.Size(121, 27);
            this.textBox_TopicName_BucketPitch.TabIndex = 24;
            // 
            // textBox_TopicName_BucketYaw
            // 
            this.textBox_TopicName_BucketYaw.Location = new System.Drawing.Point(228, 165);
            this.textBox_TopicName_BucketYaw.Name = "textBox_TopicName_BucketYaw";
            this.textBox_TopicName_BucketYaw.Size = new System.Drawing.Size(121, 27);
            this.textBox_TopicName_BucketYaw.TabIndex = 24;
            // 
            // textBox_TopicName_StretchLength
            // 
            this.textBox_TopicName_StretchLength.Location = new System.Drawing.Point(228, 102);
            this.textBox_TopicName_StretchLength.Name = "textBox_TopicName_StretchLength";
            this.textBox_TopicName_StretchLength.Size = new System.Drawing.Size(121, 27);
            this.textBox_TopicName_StretchLength.TabIndex = 24;
            // 
            // textBox_TopicName_PitchAngle
            // 
            this.textBox_TopicName_PitchAngle.Location = new System.Drawing.Point(228, 70);
            this.textBox_TopicName_PitchAngle.Name = "textBox_TopicName_PitchAngle";
            this.textBox_TopicName_PitchAngle.Size = new System.Drawing.Size(121, 27);
            this.textBox_TopicName_PitchAngle.TabIndex = 24;
            // 
            // textBox_TopicName_WalkingPos
            // 
            this.textBox_TopicName_WalkingPos.Location = new System.Drawing.Point(228, 39);
            this.textBox_TopicName_WalkingPos.Name = "textBox_TopicName_WalkingPos";
            this.textBox_TopicName_WalkingPos.Size = new System.Drawing.Size(121, 27);
            this.textBox_TopicName_WalkingPos.TabIndex = 24;
            // 
            // button_SaveRadar
            // 
            this.button_SaveRadar.Location = new System.Drawing.Point(384, 264);
            this.button_SaveRadar.Name = "button_SaveRadar";
            this.button_SaveRadar.Size = new System.Drawing.Size(81, 28);
            this.button_SaveRadar.TabIndex = 4;
            this.button_SaveRadar.Text = "保存雷达";
            this.button_SaveRadar.UseVisualStyleBackColor = true;
            this.button_SaveRadar.Click += new System.EventHandler(this.Button_SaveRadar_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(25, 230);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(69, 20);
            this.label19.TabIndex = 23;
            this.label19.Text = "瞬时流量";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(25, 197);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 20);
            this.label11.TabIndex = 23;
            this.label11.Text = "皮带速度";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 23;
            this.label5.Text = "溜桶回转";
            // 
            // button_GetValue_Stream
            // 
            this.button_GetValue_Stream.Location = new System.Drawing.Point(689, 229);
            this.button_GetValue_Stream.Name = "button_GetValue_Stream";
            this.button_GetValue_Stream.Size = new System.Drawing.Size(53, 25);
            this.button_GetValue_Stream.TabIndex = 22;
            this.button_GetValue_Stream.Text = "测试";
            this.button_GetValue_Stream.UseVisualStyleBackColor = true;
            this.button_GetValue_Stream.Click += new System.EventHandler(this.Button_GetValue_Stream_Click);
            // 
            // button_GetValue_BeltSpeed
            // 
            this.button_GetValue_BeltSpeed.Location = new System.Drawing.Point(689, 194);
            this.button_GetValue_BeltSpeed.Name = "button_GetValue_BeltSpeed";
            this.button_GetValue_BeltSpeed.Size = new System.Drawing.Size(53, 25);
            this.button_GetValue_BeltSpeed.TabIndex = 22;
            this.button_GetValue_BeltSpeed.Text = "测试";
            this.button_GetValue_BeltSpeed.UseVisualStyleBackColor = true;
            this.button_GetValue_BeltSpeed.Click += new System.EventHandler(this.Button_GetValue_BeltSpeed_Click);
            // 
            // comboBox_TopicName_BucketYaw
            // 
            this.comboBox_TopicName_BucketYaw.DisplayMember = "TOPIC_NAME";
            this.comboBox_TopicName_BucketYaw.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_TopicName_BucketYaw.FormattingEnabled = true;
            this.comboBox_TopicName_BucketYaw.Location = new System.Drawing.Point(100, 163);
            this.comboBox_TopicName_BucketYaw.Name = "comboBox_TopicName_BucketYaw";
            this.comboBox_TopicName_BucketYaw.Size = new System.Drawing.Size(122, 28);
            this.comboBox_TopicName_BucketYaw.TabIndex = 19;
            this.comboBox_TopicName_BucketYaw.ValueMember = "SHIPLOADER_ID";
            this.comboBox_TopicName_BucketYaw.SelectedIndexChanged += new System.EventHandler(this.ComboBox_TopicName_BucketYaw_SelectedIndexChanged);
            // 
            // button_GetValue_BucketYaw
            // 
            this.button_GetValue_BucketYaw.Location = new System.Drawing.Point(689, 163);
            this.button_GetValue_BucketYaw.Name = "button_GetValue_BucketYaw";
            this.button_GetValue_BucketYaw.Size = new System.Drawing.Size(53, 25);
            this.button_GetValue_BucketYaw.TabIndex = 22;
            this.button_GetValue_BucketYaw.Text = "测试";
            this.button_GetValue_BucketYaw.UseVisualStyleBackColor = true;
            this.button_GetValue_BucketYaw.Click += new System.EventHandler(this.Button_GetValue_BucketYaw_Click);
            // 
            // comboBox_TopicName_Stream
            // 
            this.comboBox_TopicName_Stream.DisplayMember = "TOPIC_NAME";
            this.comboBox_TopicName_Stream.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_TopicName_Stream.FormattingEnabled = true;
            this.comboBox_TopicName_Stream.Location = new System.Drawing.Point(100, 227);
            this.comboBox_TopicName_Stream.Name = "comboBox_TopicName_Stream";
            this.comboBox_TopicName_Stream.Size = new System.Drawing.Size(122, 28);
            this.comboBox_TopicName_Stream.TabIndex = 19;
            this.comboBox_TopicName_Stream.ValueMember = "SHIPLOADER_ID";
            this.comboBox_TopicName_Stream.SelectedIndexChanged += new System.EventHandler(this.ComboBox_TopicName_Stream_SelectedIndexChanged);
            // 
            // comboBox_TopicName_BeltSpeed
            // 
            this.comboBox_TopicName_BeltSpeed.DisplayMember = "TOPIC_NAME";
            this.comboBox_TopicName_BeltSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_TopicName_BeltSpeed.FormattingEnabled = true;
            this.comboBox_TopicName_BeltSpeed.Location = new System.Drawing.Point(100, 194);
            this.comboBox_TopicName_BeltSpeed.Name = "comboBox_TopicName_BeltSpeed";
            this.comboBox_TopicName_BeltSpeed.Size = new System.Drawing.Size(122, 28);
            this.comboBox_TopicName_BeltSpeed.TabIndex = 19;
            this.comboBox_TopicName_BeltSpeed.ValueMember = "SHIPLOADER_ID";
            this.comboBox_TopicName_BeltSpeed.SelectedIndexChanged += new System.EventHandler(this.ComboBox_TopicName_BeltSpeed_SelectedIndexChanged);
            // 
            // textBox_ItemValue_Stream
            // 
            this.textBox_ItemValue_Stream.Enabled = false;
            this.textBox_ItemValue_Stream.Location = new System.Drawing.Point(558, 227);
            this.textBox_ItemValue_Stream.Name = "textBox_ItemValue_Stream";
            this.textBox_ItemValue_Stream.Size = new System.Drawing.Size(125, 27);
            this.textBox_ItemValue_Stream.TabIndex = 21;
            // 
            // textBox_ItemValue_BeltSpeed
            // 
            this.textBox_ItemValue_BeltSpeed.Enabled = false;
            this.textBox_ItemValue_BeltSpeed.Location = new System.Drawing.Point(558, 194);
            this.textBox_ItemValue_BeltSpeed.Name = "textBox_ItemValue_BeltSpeed";
            this.textBox_ItemValue_BeltSpeed.Size = new System.Drawing.Size(125, 27);
            this.textBox_ItemValue_BeltSpeed.TabIndex = 21;
            // 
            // textBox_ItemName_BucketYaw
            // 
            this.textBox_ItemName_BucketYaw.Location = new System.Drawing.Point(355, 164);
            this.textBox_ItemName_BucketYaw.Name = "textBox_ItemName_BucketYaw";
            this.textBox_ItemName_BucketYaw.Size = new System.Drawing.Size(197, 27);
            this.textBox_ItemName_BucketYaw.TabIndex = 20;
            // 
            // textBox_ItemValue_BucketYaw
            // 
            this.textBox_ItemValue_BucketYaw.Enabled = false;
            this.textBox_ItemValue_BucketYaw.Location = new System.Drawing.Point(558, 163);
            this.textBox_ItemValue_BucketYaw.Name = "textBox_ItemValue_BucketYaw";
            this.textBox_ItemValue_BucketYaw.Size = new System.Drawing.Size(125, 27);
            this.textBox_ItemValue_BucketYaw.TabIndex = 21;
            // 
            // textBox_ItemName_Stream
            // 
            this.textBox_ItemName_Stream.Location = new System.Drawing.Point(355, 228);
            this.textBox_ItemName_Stream.Name = "textBox_ItemName_Stream";
            this.textBox_ItemName_Stream.Size = new System.Drawing.Size(197, 27);
            this.textBox_ItemName_Stream.TabIndex = 20;
            // 
            // textBox_ItemName_BeltSpeed
            // 
            this.textBox_ItemName_BeltSpeed.Location = new System.Drawing.Point(355, 195);
            this.textBox_ItemName_BeltSpeed.Name = "textBox_ItemName_BeltSpeed";
            this.textBox_ItemName_BeltSpeed.Size = new System.Drawing.Size(197, 27);
            this.textBox_ItemName_BeltSpeed.TabIndex = 20;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Id,
            this.Column_Name,
            this.Column_Address,
            this.Column_ItemNameRadarState,
            this.Column_ItemNameCollisionState,
            this.Column_ItemNameCollisionState2,
            this.Column_Changed});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(3, 396);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 27;
            this.dataGridView.Size = new System.Drawing.Size(1050, 346);
            this.dataGridView.TabIndex = 25;
            this.dataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellValueChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 312F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 158F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1056, 745);
            this.tableLayoutPanel1.TabIndex = 26;
            // 
            // Column_Id
            // 
            this.Column_Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column_Id.DataPropertyName = "RADAR_ID";
            this.Column_Id.HeaderText = "ID";
            this.Column_Id.MinimumWidth = 6;
            this.Column_Id.Name = "Column_Id";
            this.Column_Id.ReadOnly = true;
            this.Column_Id.Width = 53;
            // 
            // Column_Name
            // 
            this.Column_Name.DataPropertyName = "RADAR_NAME";
            this.Column_Name.HeaderText = "雷达名称";
            this.Column_Name.MinimumWidth = 6;
            this.Column_Name.Name = "Column_Name";
            this.Column_Name.ReadOnly = true;
            this.Column_Name.Width = 125;
            // 
            // Column_Address
            // 
            this.Column_Address.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column_Address.DataPropertyName = "ADDRESS";
            this.Column_Address.HeaderText = "地址";
            this.Column_Address.MinimumWidth = 6;
            this.Column_Address.Name = "Column_Address";
            this.Column_Address.ReadOnly = true;
            this.Column_Address.Width = 68;
            // 
            // Column_ItemNameRadarState
            // 
            this.Column_ItemNameRadarState.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column_ItemNameRadarState.DataPropertyName = "ITEM_NAME_RADAR_STATE";
            this.Column_ItemNameRadarState.HeaderText = "状态标签";
            this.Column_ItemNameRadarState.MinimumWidth = 6;
            this.Column_ItemNameRadarState.Name = "Column_ItemNameRadarState";
            this.Column_ItemNameRadarState.Width = 98;
            // 
            // Column_ItemNameCollisionState
            // 
            this.Column_ItemNameCollisionState.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column_ItemNameCollisionState.DataPropertyName = "ITEM_NAME_COLLISION_STATE";
            this.Column_ItemNameCollisionState.HeaderText = "碰撞标签1";
            this.Column_ItemNameCollisionState.MinimumWidth = 6;
            this.Column_ItemNameCollisionState.Name = "Column_ItemNameCollisionState";
            this.Column_ItemNameCollisionState.Width = 107;
            // 
            // Column_ItemNameCollisionState2
            // 
            this.Column_ItemNameCollisionState2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column_ItemNameCollisionState2.DataPropertyName = "ITEM_NAME_COLLISION_STATE_2";
            this.Column_ItemNameCollisionState2.HeaderText = "碰撞标签2";
            this.Column_ItemNameCollisionState2.MinimumWidth = 6;
            this.Column_ItemNameCollisionState2.Name = "Column_ItemNameCollisionState2";
            this.Column_ItemNameCollisionState2.Width = 107;
            // 
            // Column_Changed
            // 
            this.Column_Changed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column_Changed.DataPropertyName = "CHANGED";
            this.Column_Changed.HeaderText = "是否改变";
            this.Column_Changed.MinimumWidth = 6;
            this.Column_Changed.Name = "Column_Changed";
            this.Column_Changed.Visible = false;
            this.Column_Changed.Width = 98;
            // 
            // FormOpcConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 745);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormOpcConfig";
            this.Text = "OPCServerTest";
            this.Load += new System.EventHandler(this.FormOpcServerTest_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_OpcServerIp;
        private System.Windows.Forms.Button button_ServerEnum;
        private System.Windows.Forms.ComboBox comboBox_OpcServerList;
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_SaveServerInfo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_TopicName_WalkingPos;
        private System.Windows.Forms.ComboBox comboBox_TopicName_PitchAngle;
        private System.Windows.Forms.ComboBox comboBox_TopicName_StretchLength;
        private System.Windows.Forms.TextBox textBox_ItemName_WalkingPos;
        private System.Windows.Forms.TextBox textBox_ItemName_PitchAngle;
        private System.Windows.Forms.TextBox textBox_ItemName_StretchLength;
        private System.Windows.Forms.TextBox textBox_ItemValue_WalkingPos;
        private System.Windows.Forms.TextBox textBox_ItemValue_PitchAngle;
        private System.Windows.Forms.TextBox textBox_ItemValue_StretchLength;
        private System.Windows.Forms.Button button_GetValue_WalkingPos;
        private System.Windows.Forms.Button button_GetValue_PitchAngle;
        private System.Windows.Forms.Button button_GetValue_StretchLength;
        private System.Windows.Forms.Label label_WalkingPos;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button_SaveItemInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_TopicName_BucketPitch;
        private System.Windows.Forms.TextBox textBox_ItemName_BucketPitch;
        private System.Windows.Forms.TextBox textBox_ItemValue_BucketPitch;
        private System.Windows.Forms.Button button_GetValue_BucketPitch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_TopicName_BucketPitch;
        private System.Windows.Forms.TextBox textBox_TopicName_StretchLength;
        private System.Windows.Forms.TextBox textBox_TopicName_PitchAngle;
        private System.Windows.Forms.TextBox textBox_TopicName_WalkingPos;
        private System.Windows.Forms.TextBox textBox_TopicName_BeltSpeed;
        private System.Windows.Forms.TextBox textBox_TopicName_BucketYaw;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_GetValue_BeltSpeed;
        private System.Windows.Forms.ComboBox comboBox_TopicName_BucketYaw;
        private System.Windows.Forms.Button button_GetValue_BucketYaw;
        private System.Windows.Forms.ComboBox comboBox_TopicName_BeltSpeed;
        private System.Windows.Forms.TextBox textBox_ItemValue_BeltSpeed;
        private System.Windows.Forms.TextBox textBox_ItemName_BucketYaw;
        private System.Windows.Forms.TextBox textBox_ItemValue_BucketYaw;
        private System.Windows.Forms.TextBox textBox_ItemName_BeltSpeed;
        private System.Windows.Forms.TextBox textBox_TopicName_Stream;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button button_GetValue_Stream;
        private System.Windows.Forms.ComboBox comboBox_TopicName_Stream;
        private System.Windows.Forms.TextBox textBox_ItemValue_Stream;
        private System.Windows.Forms.TextBox textBox_ItemName_Stream;
        private System.Windows.Forms.CheckBox checkBox_WriteItemValue;
        private System.Windows.Forms.Button button_SaveRadar;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ItemNameRadarState;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ItemNameCollisionState;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ItemNameCollisionState2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Changed;
    }
}