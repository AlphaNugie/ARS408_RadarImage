namespace ARS408.Forms
{
    partial class FormDisplay
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDisplay));
            this.textBox_Input = new System.Windows.Forms.TextBox();
            this.dataGridView_Output = new System.Windows.Forms.DataGridView();
            this.textBox_Info = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl_Main = new System.Windows.Forms.TabControl();
            this.tabPage_form = new System.Windows.Forms.TabPage();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tabPage_vertex = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel_Picture = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button_Zoomout = new System.Windows.Forms.Button();
            this.button_Zoomin = new System.Windows.Forms.Button();
            this.button_Fullsize = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox_Dots = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel_Main = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel_Sub = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.numeric_Port = new System.Windows.Forms.NumericUpDown();
            this.textBox_IpAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Connect = new System.Windows.Forms.Button();
            this.button_Disconnect = new System.Windows.Forms.Button();
            this.comboBox_TcpOrUdp = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label_RcsMax = new System.Windows.Forms.Label();
            this.label_RcsMin = new System.Windows.Forms.Label();
            this.numeric_Port_Local = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_IpAddress_Local = new System.Windows.Forms.TextBox();
            this.checkBox_UsingLocal = new System.Windows.Forms.CheckBox();
            this.textBox_SendContent = new System.Windows.Forms.TextBox();
            this.button_Send = new System.Windows.Forms.Button();
            this.button_UdpInit = new System.Windows.Forms.Button();
            this.trackBar_RcsMin = new System.Windows.Forms.TrackBar();
            this.trackBar_RcsMax = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_ProbMinimum = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label_opc = new System.Windows.Forms.Label();
            this.timer_GraphicRefresh = new System.Windows.Forms.Timer(this.components);
            this.timer_GridRefresh = new System.Windows.Forms.Timer(this.components);
            this.timer_WriteItems = new System.Windows.Forms.Timer(this.components);
            this.timer_UIUpdate = new System.Windows.Forms.Timer(this.components);
            this.SocketTcpClient = new SocketHelper.SocketTcpClient(this.components);
            this.Column_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_DistLong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_DistLat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_VrelLong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_VrelLat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_DynProp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Rcs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_RCSM2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Pdh0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_AmbigState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_InvalidState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_MeasState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ProbOfExist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Output)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl_Main.SuspendLayout();
            this.tabPage_form.SuspendLayout();
            this.tabPage_vertex.SuspendLayout();
            this.tableLayoutPanel_Picture.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Dots)).BeginInit();
            this.tableLayoutPanel_Main.SuspendLayout();
            this.tableLayoutPanel_Sub.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Port)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Port_Local)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_RcsMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_RcsMax)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_Input
            // 
            this.textBox_Input.AllowDrop = true;
            this.textBox_Input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Input.Location = new System.Drawing.Point(3, 351);
            this.textBox_Input.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_Input.Multiline = true;
            this.textBox_Input.Name = "textBox_Input";
            this.textBox_Input.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Input.Size = new System.Drawing.Size(379, 382);
            this.textBox_Input.TabIndex = 1;
            // 
            // dataGridView_Output
            // 
            this.dataGridView_Output.AllowUserToAddRows = false;
            this.dataGridView_Output.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Output.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Id,
            this.Column_DistLong,
            this.Column_DistLat,
            this.Column_VrelLong,
            this.Column_VrelLat,
            this.Column_DynProp,
            this.Column_Rcs,
            this.Column_RCSM2,
            this.Column_Pdh0,
            this.Column_AmbigState,
            this.Column_InvalidState,
            this.Column_MeasState,
            this.Column_ProbOfExist});
            this.dataGridView_Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Output.Location = new System.Drawing.Point(2, 2);
            this.dataGridView_Output.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView_Output.Name = "dataGridView_Output";
            this.dataGridView_Output.RowHeadersWidth = 51;
            this.dataGridView_Output.RowTemplate.Height = 27;
            this.dataGridView_Output.Size = new System.Drawing.Size(1052, 702);
            this.dataGridView_Output.TabIndex = 2;
            // 
            // textBox_Info
            // 
            this.textBox_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Info.Location = new System.Drawing.Point(3, 264);
            this.textBox_Info.Multiline = true;
            this.textBox_Info.Name = "textBox_Info";
            this.textBox_Info.Size = new System.Drawing.Size(379, 80);
            this.textBox_Info.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1137, 723);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.62319F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 76.37681F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(366, 274);
            this.tableLayoutPanel1.TabIndex = 4;
            this.tableLayoutPanel1.Visible = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.75853F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.24147F));
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(360, 58);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tabControl_Main
            // 
            this.tabControl_Main.Controls.Add(this.tabPage_form);
            this.tabControl_Main.Controls.Add(this.tabPage_vertex);
            this.tabControl_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_Main.Location = new System.Drawing.Point(393, 2);
            this.tabControl_Main.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl_Main.Name = "tabControl_Main";
            this.tabControl_Main.SelectedIndex = 0;
            this.tabControl_Main.Size = new System.Drawing.Size(1064, 739);
            this.tabControl_Main.TabIndex = 1;
            this.tabControl_Main.DoubleClick += new System.EventHandler(this.TabControl_Main_DoubleClick);
            // 
            // tabPage_form
            // 
            this.tabPage_form.AutoScroll = true;
            this.tabPage_form.Controls.Add(this.splitter1);
            this.tabPage_form.Controls.Add(this.dataGridView_Output);
            this.tabPage_form.Location = new System.Drawing.Point(4, 29);
            this.tabPage_form.Name = "tabPage_form";
            this.tabPage_form.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage_form.Size = new System.Drawing.Size(1056, 706);
            this.tabPage_form.TabIndex = 0;
            this.tabPage_form.Text = "列表";
            this.tabPage_form.UseVisualStyleBackColor = true;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(2, 2);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 702);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // tabPage_vertex
            // 
            this.tabPage_vertex.AutoScroll = true;
            this.tabPage_vertex.Controls.Add(this.tableLayoutPanel_Picture);
            this.tabPage_vertex.Location = new System.Drawing.Point(4, 29);
            this.tabPage_vertex.Name = "tabPage_vertex";
            this.tabPage_vertex.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage_vertex.Size = new System.Drawing.Size(1056, 706);
            this.tabPage_vertex.TabIndex = 1;
            this.tabPage_vertex.Text = "图形";
            this.tabPage_vertex.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel_Picture
            // 
            this.tableLayoutPanel_Picture.AutoScroll = true;
            this.tableLayoutPanel_Picture.ColumnCount = 2;
            this.tableLayoutPanel_Picture.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Picture.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel_Picture.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel_Picture.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel_Picture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Picture.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel_Picture.Name = "tableLayoutPanel_Picture";
            this.tableLayoutPanel_Picture.RowCount = 1;
            this.tableLayoutPanel_Picture.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Picture.Size = new System.Drawing.Size(1052, 702);
            this.tableLayoutPanel_Picture.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.button_Zoomout);
            this.flowLayoutPanel1.Controls.Add(this.button_Zoomin);
            this.flowLayoutPanel1.Controls.Add(this.button_Fullsize);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(991, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(58, 696);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // button_Zoomout
            // 
            this.button_Zoomout.Location = new System.Drawing.Point(3, 659);
            this.button_Zoomout.Name = "button_Zoomout";
            this.button_Zoomout.Size = new System.Drawing.Size(50, 34);
            this.button_Zoomout.TabIndex = 1;
            this.button_Zoomout.Text = "-";
            this.button_Zoomout.UseVisualStyleBackColor = true;
            this.button_Zoomout.Click += new System.EventHandler(this.Button_Zoomout_Click);
            // 
            // button_Zoomin
            // 
            this.button_Zoomin.Location = new System.Drawing.Point(3, 619);
            this.button_Zoomin.Name = "button_Zoomin";
            this.button_Zoomin.Size = new System.Drawing.Size(50, 34);
            this.button_Zoomin.TabIndex = 1;
            this.button_Zoomin.Text = "+";
            this.button_Zoomin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Zoomin.UseCompatibleTextRendering = true;
            this.button_Zoomin.UseVisualStyleBackColor = false;
            this.button_Zoomin.Click += new System.EventHandler(this.Button_Zoomin_Click);
            // 
            // button_Fullsize
            // 
            this.button_Fullsize.BackColor = System.Drawing.Color.Transparent;
            this.button_Fullsize.Location = new System.Drawing.Point(3, 579);
            this.button_Fullsize.Name = "button_Fullsize";
            this.button_Fullsize.Size = new System.Drawing.Size(50, 34);
            this.button_Fullsize.TabIndex = 2;
            this.button_Fullsize.Text = "O";
            this.button_Fullsize.UseVisualStyleBackColor = false;
            this.button_Fullsize.Click += new System.EventHandler(this.Button_Fullsize_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox_Dots);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(982, 696);
            this.panel1.TabIndex = 3;
            // 
            // pictureBox_Dots
            // 
            this.pictureBox_Dots.Location = new System.Drawing.Point(3, 3);
            this.pictureBox_Dots.Name = "pictureBox_Dots";
            this.pictureBox_Dots.Size = new System.Drawing.Size(900, 600);
            this.pictureBox_Dots.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_Dots.TabIndex = 0;
            this.pictureBox_Dots.TabStop = false;
            this.pictureBox_Dots.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox_Dots_MouseDown);
            this.pictureBox_Dots.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox_Dots_MouseMove);
            this.pictureBox_Dots.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBox_Dots_MouseUp);
            // 
            // tableLayoutPanel_Main
            // 
            this.tableLayoutPanel_Main.AutoScroll = true;
            this.tableLayoutPanel_Main.ColumnCount = 2;
            this.tableLayoutPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 391F));
            this.tableLayoutPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Main.Controls.Add(this.tableLayoutPanel_Sub, 0, 0);
            this.tableLayoutPanel_Main.Controls.Add(this.tabControl_Main, 1, 0);
            this.tableLayoutPanel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Main.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_Main.Name = "tableLayoutPanel_Main";
            this.tableLayoutPanel_Main.RowCount = 1;
            this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Main.Size = new System.Drawing.Size(1459, 743);
            this.tableLayoutPanel_Main.TabIndex = 5;
            // 
            // tableLayoutPanel_Sub
            // 
            this.tableLayoutPanel_Sub.ColumnCount = 1;
            this.tableLayoutPanel_Sub.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Sub.Controls.Add(this.textBox_Input, 0, 4);
            this.tableLayoutPanel_Sub.Controls.Add(this.textBox_Info, 0, 3);
            this.tableLayoutPanel_Sub.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel_Sub.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel_Sub.Controls.Add(this.label_opc, 0, 1);
            this.tableLayoutPanel_Sub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Sub.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel_Sub.Name = "tableLayoutPanel_Sub";
            this.tableLayoutPanel_Sub.RowCount = 5;
            this.tableLayoutPanel_Sub.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel_Sub.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel_Sub.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 162F));
            this.tableLayoutPanel_Sub.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.07692F));
            this.tableLayoutPanel_Sub.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.92308F));
            this.tableLayoutPanel_Sub.Size = new System.Drawing.Size(385, 737);
            this.tableLayoutPanel_Sub.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.numeric_Port, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.textBox_IpAddress, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.button_Connect, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.button_Disconnect, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.comboBox_TcpOrUdp, 2, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(379, 69);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // numeric_Port
            // 
            this.numeric_Port.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numeric_Port.Location = new System.Drawing.Point(63, 39);
            this.numeric_Port.Margin = new System.Windows.Forms.Padding(3, 4, 3, 2);
            this.numeric_Port.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numeric_Port.Name = "numeric_Port";
            this.numeric_Port.Size = new System.Drawing.Size(114, 27);
            this.numeric_Port.TabIndex = 6;
            this.numeric_Port.ValueChanged += new System.EventHandler(this.Numeric_Port_ValueChanged);
            // 
            // textBox_IpAddress
            // 
            this.textBox_IpAddress.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_IpAddress.Location = new System.Drawing.Point(63, 4);
            this.textBox_IpAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 2);
            this.textBox_IpAddress.Name = "textBox_IpAddress";
            this.textBox_IpAddress.Size = new System.Drawing.Size(114, 27);
            this.textBox_IpAddress.TabIndex = 1;
            this.textBox_IpAddress.TextChanged += new System.EventHandler(this.TextBox_IpAddress_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "IP";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "端口";
            // 
            // button_Connect
            // 
            this.button_Connect.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_Connect.BackColor = System.Drawing.Color.LimeGreen;
            this.button_Connect.Location = new System.Drawing.Point(262, 0);
            this.button_Connect.Margin = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(94, 30);
            this.button_Connect.TabIndex = 8;
            this.button_Connect.Text = "连接";
            this.button_Connect.UseVisualStyleBackColor = false;
            this.button_Connect.Click += new System.EventHandler(this.Button_Connect_Click);
            // 
            // button_Disconnect
            // 
            this.button_Disconnect.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_Disconnect.BackColor = System.Drawing.Color.Tomato;
            this.button_Disconnect.Enabled = false;
            this.button_Disconnect.Location = new System.Drawing.Point(262, 34);
            this.button_Disconnect.Margin = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.button_Disconnect.Name = "button_Disconnect";
            this.button_Disconnect.Size = new System.Drawing.Size(94, 30);
            this.button_Disconnect.TabIndex = 9;
            this.button_Disconnect.Text = "断开";
            this.button_Disconnect.UseVisualStyleBackColor = false;
            this.button_Disconnect.Click += new System.EventHandler(this.Button_Disconnect_Click);
            // 
            // comboBox_TcpOrUdp
            // 
            this.comboBox_TcpOrUdp.DisplayMember = "MODE_NAME";
            this.comboBox_TcpOrUdp.FormattingEnabled = true;
            this.comboBox_TcpOrUdp.Items.AddRange(new object[] {
            "TCP",
            "UDP"});
            this.comboBox_TcpOrUdp.Location = new System.Drawing.Point(183, 37);
            this.comboBox_TcpOrUdp.Name = "comboBox_TcpOrUdp";
            this.comboBox_TcpOrUdp.Size = new System.Drawing.Size(72, 28);
            this.comboBox_TcpOrUdp.TabIndex = 11;
            this.comboBox_TcpOrUdp.Text = "TCP";
            this.comboBox_TcpOrUdp.ValueMember = "MODE_ID";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 5;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 129F));
            this.tableLayoutPanel4.Controls.Add(this.label_RcsMax, 4, 3);
            this.tableLayoutPanel4.Controls.Add(this.label_RcsMin, 4, 2);
            this.tableLayoutPanel4.Controls.Add(this.numeric_Port_Local, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.textBox_IpAddress_Local, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.checkBox_UsingLocal, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.textBox_SendContent, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.button_Send, 4, 1);
            this.tableLayoutPanel4.Controls.Add(this.button_UdpInit, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.trackBar_RcsMin, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.trackBar_RcsMax, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.label4, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.label6, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.comboBox_ProbMinimum, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.label3, 3, 4);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 102);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 5;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(379, 156);
            this.tableLayoutPanel4.TabIndex = 5;
            // 
            // label_RcsMax
            // 
            this.label_RcsMax.AutoSize = true;
            this.label_RcsMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_RcsMax.Location = new System.Drawing.Point(314, 101);
            this.label_RcsMax.Margin = new System.Windows.Forms.Padding(5);
            this.label_RcsMax.Name = "label_RcsMax";
            this.label_RcsMax.Size = new System.Drawing.Size(119, 20);
            this.label_RcsMax.TabIndex = 18;
            this.label_RcsMax.Text = "0";
            this.label_RcsMax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_RcsMin
            // 
            this.label_RcsMin.AutoSize = true;
            this.label_RcsMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_RcsMin.Location = new System.Drawing.Point(314, 71);
            this.label_RcsMin.Margin = new System.Windows.Forms.Padding(5);
            this.label_RcsMin.Name = "label_RcsMin";
            this.label_RcsMin.Size = new System.Drawing.Size(119, 20);
            this.label_RcsMin.TabIndex = 17;
            this.label_RcsMin.Text = "0";
            this.label_RcsMin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numeric_Port_Local
            // 
            this.numeric_Port_Local.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numeric_Port_Local.Location = new System.Drawing.Point(231, 4);
            this.numeric_Port_Local.Margin = new System.Windows.Forms.Padding(3, 4, 3, 2);
            this.numeric_Port_Local.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numeric_Port_Local.Name = "numeric_Port_Local";
            this.numeric_Port_Local.Size = new System.Drawing.Size(75, 27);
            this.numeric_Port_Local.TabIndex = 10;
            this.numeric_Port_Local.Value = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numeric_Port_Local.ValueChanged += new System.EventHandler(this.Numeric_Port_Local_ValueChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(183, 6);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "端口";
            // 
            // textBox_IpAddress_Local
            // 
            this.textBox_IpAddress_Local.Location = new System.Drawing.Point(63, 4);
            this.textBox_IpAddress_Local.Margin = new System.Windows.Forms.Padding(3, 4, 3, 2);
            this.textBox_IpAddress_Local.Name = "textBox_IpAddress_Local";
            this.textBox_IpAddress_Local.Size = new System.Drawing.Size(114, 27);
            this.textBox_IpAddress_Local.TabIndex = 8;
            this.textBox_IpAddress_Local.TextChanged += new System.EventHandler(this.TextBox_IpAddress_Local_TextChanged);
            // 
            // checkBox_UsingLocal
            // 
            this.checkBox_UsingLocal.AutoSize = true;
            this.checkBox_UsingLocal.Dock = System.Windows.Forms.DockStyle.Right;
            this.checkBox_UsingLocal.Font = new System.Drawing.Font("微软雅黑", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_UsingLocal.Location = new System.Drawing.Point(3, 3);
            this.checkBox_UsingLocal.Name = "checkBox_UsingLocal";
            this.checkBox_UsingLocal.Size = new System.Drawing.Size(54, 27);
            this.checkBox_UsingLocal.TabIndex = 9;
            this.checkBox_UsingLocal.Text = "本地";
            this.checkBox_UsingLocal.UseVisualStyleBackColor = true;
            this.checkBox_UsingLocal.CheckedChanged += new System.EventHandler(this.CheckBox_UsingLocal_CheckedChanged);
            // 
            // textBox_SendContent
            // 
            this.tableLayoutPanel4.SetColumnSpan(this.textBox_SendContent, 4);
            this.textBox_SendContent.Location = new System.Drawing.Point(3, 37);
            this.textBox_SendContent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 2);
            this.textBox_SendContent.Name = "textBox_SendContent";
            this.textBox_SendContent.Size = new System.Drawing.Size(303, 27);
            this.textBox_SendContent.TabIndex = 11;
            // 
            // button_Send
            // 
            this.button_Send.Location = new System.Drawing.Point(312, 36);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(67, 27);
            this.button_Send.TabIndex = 12;
            this.button_Send.Text = "发送";
            this.button_Send.UseVisualStyleBackColor = true;
            this.button_Send.Click += new System.EventHandler(this.Button_Send_Click);
            // 
            // button_UdpInit
            // 
            this.button_UdpInit.Enabled = false;
            this.button_UdpInit.Location = new System.Drawing.Point(312, 3);
            this.button_UdpInit.Name = "button_UdpInit";
            this.button_UdpInit.Size = new System.Drawing.Size(67, 27);
            this.button_UdpInit.TabIndex = 13;
            this.button_UdpInit.Text = "初始化";
            this.button_UdpInit.UseVisualStyleBackColor = true;
            this.button_UdpInit.Click += new System.EventHandler(this.Button_UdpInit_Click);
            // 
            // trackBar_RcsMin
            // 
            this.tableLayoutPanel4.SetColumnSpan(this.trackBar_RcsMin, 3);
            this.trackBar_RcsMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar_RcsMin.Location = new System.Drawing.Point(3, 69);
            this.trackBar_RcsMin.Maximum = 64;
            this.trackBar_RcsMin.Minimum = -64;
            this.trackBar_RcsMin.Name = "trackBar_RcsMin";
            this.trackBar_RcsMin.Size = new System.Drawing.Size(222, 24);
            this.trackBar_RcsMin.TabIndex = 14;
            this.trackBar_RcsMin.TickFrequency = 10;
            this.trackBar_RcsMin.ValueChanged += new System.EventHandler(this.TrackBar_ValueChanged);
            // 
            // trackBar_RcsMax
            // 
            this.tableLayoutPanel4.SetColumnSpan(this.trackBar_RcsMax, 3);
            this.trackBar_RcsMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar_RcsMax.Location = new System.Drawing.Point(3, 99);
            this.trackBar_RcsMax.Maximum = 64;
            this.trackBar_RcsMax.Minimum = -64;
            this.trackBar_RcsMax.Name = "trackBar_RcsMax";
            this.trackBar_RcsMax.Size = new System.Drawing.Size(222, 24);
            this.trackBar_RcsMax.TabIndex = 15;
            this.trackBar_RcsMax.TickFrequency = 10;
            this.trackBar_RcsMax.ValueChanged += new System.EventHandler(this.TrackBar_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(233, 71);
            this.label4.Margin = new System.Windows.Forms.Padding(5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "最小RCS";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(233, 101);
            this.label6.Margin = new System.Windows.Forms.Padding(5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "最大RCS";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox_ProbMinimum
            // 
            this.tableLayoutPanel4.SetColumnSpan(this.comboBox_ProbMinimum, 3);
            this.comboBox_ProbMinimum.DisplayMember = "NAME";
            this.comboBox_ProbMinimum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ProbMinimum.FormattingEnabled = true;
            this.comboBox_ProbMinimum.Location = new System.Drawing.Point(3, 129);
            this.comboBox_ProbMinimum.Name = "comboBox_ProbMinimum";
            this.comboBox_ProbMinimum.Size = new System.Drawing.Size(222, 28);
            this.comboBox_ProbMinimum.TabIndex = 19;
            this.comboBox_ProbMinimum.ValueMember = "VALUE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(233, 131);
            this.label3.Margin = new System.Windows.Forms.Padding(5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "最低概率";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_opc
            // 
            this.label_opc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_opc.AutoSize = true;
            this.label_opc.Location = new System.Drawing.Point(3, 79);
            this.label_opc.Name = "label_opc";
            this.label_opc.Size = new System.Drawing.Size(379, 20);
            this.label_opc.TabIndex = 6;
            this.label_opc.Text = "opc_info";
            // 
            // timer_GraphicRefresh
            // 
            this.timer_GraphicRefresh.Interval = 50;
            this.timer_GraphicRefresh.Tick += new System.EventHandler(this.Timer_GraphicRefresh_Tick);
            // 
            // timer_GridRefresh
            // 
            this.timer_GridRefresh.Interval = 50;
            this.timer_GridRefresh.Tick += new System.EventHandler(this.Timer_GridRefresh_Tick);
            // 
            // timer_WriteItems
            // 
            this.timer_WriteItems.Interval = 500;
            this.timer_WriteItems.Tick += new System.EventHandler(this.Timer_WriteItems_Tick);
            // 
            // timer_UIUpdate
            // 
            this.timer_UIUpdate.Interval = 1000;
            this.timer_UIUpdate.Tick += new System.EventHandler(this.Timer_UIUpdate_Tick);
            // 
            // SocketTcpClient
            // 
            this.SocketTcpClient.IsReconnection = true;
            this.SocketTcpClient.IsStart = false;
            this.SocketTcpClient.IsStartTcpThreading = false;
            this.SocketTcpClient.LocalEndPoint = null;
            this.SocketTcpClient.ReceiveBufferSize = 2048;
            this.SocketTcpClient.ReConnectedCount = 0;
            this.SocketTcpClient.ReConnectionTime = 3000;
            this.SocketTcpClient.ServerIp = null;
            this.SocketTcpClient.ServerPort = 0;
            this.SocketTcpClient.TcpClient = null;
            this.SocketTcpClient.TcpThread = null;
            this.SocketTcpClient.OnRecevice += new SocketHelper.SocketTcpClient.ReceviceEventHandler(this.SocketTcpClient_OnRecevice);
            // 
            // Column_Id
            // 
            this.Column_Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_Id.DataPropertyName = "Id";
            this.Column_Id.HeaderText = "ID";
            this.Column_Id.MinimumWidth = 80;
            this.Column_Id.Name = "Column_Id";
            this.Column_Id.ReadOnly = true;
            this.Column_Id.Width = 80;
            // 
            // Column_DistLong
            // 
            this.Column_DistLong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_DistLong.DataPropertyName = "DistLong";
            this.Column_DistLong.HeaderText = "纵向";
            this.Column_DistLong.MinimumWidth = 65;
            this.Column_DistLong.Name = "Column_DistLong";
            this.Column_DistLong.ReadOnly = true;
            this.Column_DistLong.ToolTipText = "纵向(x,m)";
            this.Column_DistLong.Width = 68;
            // 
            // Column_DistLat
            // 
            this.Column_DistLat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_DistLat.DataPropertyName = "DistLat";
            this.Column_DistLat.HeaderText = "横向";
            this.Column_DistLat.MinimumWidth = 65;
            this.Column_DistLat.Name = "Column_DistLat";
            this.Column_DistLat.ReadOnly = true;
            this.Column_DistLat.ToolTipText = "横向(y,m)";
            this.Column_DistLat.Width = 68;
            // 
            // Column_VrelLong
            // 
            this.Column_VrelLong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_VrelLong.DataPropertyName = "VrelLong";
            this.Column_VrelLong.HeaderText = "纵向速度";
            this.Column_VrelLong.MinimumWidth = 90;
            this.Column_VrelLong.Name = "Column_VrelLong";
            this.Column_VrelLong.ReadOnly = true;
            this.Column_VrelLong.ToolTipText = "纵向速度(x,m/s)";
            this.Column_VrelLong.Width = 98;
            // 
            // Column_VrelLat
            // 
            this.Column_VrelLat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_VrelLat.DataPropertyName = "VrelLat";
            this.Column_VrelLat.HeaderText = "横向速度";
            this.Column_VrelLat.MinimumWidth = 90;
            this.Column_VrelLat.Name = "Column_VrelLat";
            this.Column_VrelLat.ReadOnly = true;
            this.Column_VrelLat.ToolTipText = "横向速度(y,m/s)";
            this.Column_VrelLat.Width = 98;
            // 
            // Column_DynProp
            // 
            this.Column_DynProp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_DynProp.DataPropertyName = "DynPropString";
            this.Column_DynProp.HeaderText = "动态属性";
            this.Column_DynProp.MinimumWidth = 90;
            this.Column_DynProp.Name = "Column_DynProp";
            this.Column_DynProp.ReadOnly = true;
            this.Column_DynProp.Width = 98;
            // 
            // Column_Rcs
            // 
            this.Column_Rcs.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_Rcs.DataPropertyName = "RCS";
            this.Column_Rcs.HeaderText = "RCS";
            this.Column_Rcs.MinimumWidth = 60;
            this.Column_Rcs.Name = "Column_Rcs";
            this.Column_Rcs.ReadOnly = true;
            this.Column_Rcs.ToolTipText = "雷达散射截面(dbm2)";
            this.Column_Rcs.Width = 67;
            // 
            // Column_RCSM2
            // 
            this.Column_RCSM2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_RCSM2.DataPropertyName = "RCS_M2";
            this.Column_RCSM2.HeaderText = "RCS";
            this.Column_RCSM2.MinimumWidth = 100;
            this.Column_RCSM2.Name = "Column_RCSM2";
            this.Column_RCSM2.ReadOnly = true;
            this.Column_RCSM2.ToolTipText = "雷达散射截面(m2)";
            this.Column_RCSM2.Visible = false;
            // 
            // Column_Pdh0
            // 
            this.Column_Pdh0.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_Pdh0.DataPropertyName = "PdhString";
            this.Column_Pdh0.HeaderText = "错报";
            this.Column_Pdh0.MinimumWidth = 80;
            this.Column_Pdh0.Name = "Column_Pdh0";
            this.Column_Pdh0.ReadOnly = true;
            this.Column_Pdh0.Width = 80;
            // 
            // Column_AmbigState
            // 
            this.Column_AmbigState.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_AmbigState.DataPropertyName = "AmbigStateString";
            this.Column_AmbigState.HeaderText = "不确定性";
            this.Column_AmbigState.MinimumWidth = 80;
            this.Column_AmbigState.Name = "Column_AmbigState";
            this.Column_AmbigState.ReadOnly = true;
            this.Column_AmbigState.Width = 98;
            // 
            // Column_InvalidState
            // 
            this.Column_InvalidState.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_InvalidState.DataPropertyName = "InvalidStateString";
            this.Column_InvalidState.HeaderText = "不可用";
            this.Column_InvalidState.MinimumWidth = 80;
            this.Column_InvalidState.Name = "Column_InvalidState";
            this.Column_InvalidState.ReadOnly = true;
            this.Column_InvalidState.Width = 83;
            // 
            // Column_MeasState
            // 
            this.Column_MeasState.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_MeasState.DataPropertyName = "MeasStateString";
            this.Column_MeasState.HeaderText = "测量状态";
            this.Column_MeasState.MinimumWidth = 100;
            this.Column_MeasState.Name = "Column_MeasState";
            // 
            // Column_ProbOfExist
            // 
            this.Column_ProbOfExist.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_ProbOfExist.DataPropertyName = "ProbOfExistString";
            this.Column_ProbOfExist.HeaderText = "存在概率";
            this.Column_ProbOfExist.MinimumWidth = 100;
            this.Column_ProbOfExist.Name = "Column_ProbOfExist";
            // 
            // FormDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1459, 743);
            this.Controls.Add(this.tableLayoutPanel_Main);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormDisplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ARS408-21";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDisplay_FormClosing);
            this.Load += new System.EventHandler(this.FormDisplay_Load);
            this.Shown += new System.EventHandler(this.FormDisplay_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Output)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl_Main.ResumeLayout(false);
            this.tabPage_form.ResumeLayout(false);
            this.tabPage_vertex.ResumeLayout(false);
            this.tableLayoutPanel_Picture.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Dots)).EndInit();
            this.tableLayoutPanel_Main.ResumeLayout(false);
            this.tableLayoutPanel_Sub.ResumeLayout(false);
            this.tableLayoutPanel_Sub.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Port)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Port_Local)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_RcsMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_RcsMax)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Input;
        private System.Windows.Forms.DataGridView dataGridView_Output;
        private System.Windows.Forms.TextBox textBox_Info;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TabControl tabControl_Main;
        private System.Windows.Forms.TabPage tabPage_form;
        private System.Windows.Forms.TabPage tabPage_vertex;
        private System.Windows.Forms.PictureBox pictureBox_Dots;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Main;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Sub;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox textBox_IpAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.Button button_Disconnect;
        private System.Windows.Forms.NumericUpDown numeric_Port;
        private System.Windows.Forms.Timer timer_GraphicRefresh;
        private System.Windows.Forms.Button button_Zoomout;
        private System.Windows.Forms.Button button_Zoomin;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Picture;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_Fullsize;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Timer timer_GridRefresh;
        private System.Windows.Forms.ComboBox comboBox_TcpOrUdp;
        private System.Windows.Forms.NumericUpDown numeric_Port_Local;
        private System.Windows.Forms.TextBox textBox_IpAddress_Local;
        private System.Windows.Forms.CheckBox checkBox_UsingLocal;
        private System.Windows.Forms.TextBox textBox_SendContent;
        private System.Windows.Forms.Button button_Send;
        private System.Windows.Forms.Button button_UdpInit;
        private System.Windows.Forms.Label label_opc;
        private System.Windows.Forms.Timer timer_WriteItems;
        private System.Windows.Forms.TrackBar trackBar_RcsMin;
        private System.Windows.Forms.TrackBar trackBar_RcsMax;
        private System.Windows.Forms.Label label_RcsMax;
        private System.Windows.Forms.Label label_RcsMin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_ProbMinimum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer_UIUpdate;
        private SocketHelper.SocketTcpClient SocketTcpClient;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_DistLong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_DistLat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_VrelLong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_VrelLat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_DynProp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Rcs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_RCSM2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Pdh0;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_AmbigState;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_InvalidState;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_MeasState;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ProbOfExist;
    }
}

