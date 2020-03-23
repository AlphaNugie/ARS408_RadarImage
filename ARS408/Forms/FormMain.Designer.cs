namespace ARS408.Forms
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenu_Monitor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenu_AutoMonitor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenu_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.字典ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenu_Shiploaders = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenu_RadarGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenu_Radar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_ThreatLevels = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_OpcConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_CoorsLimitConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl_Main = new System.Windows.Forms.TabControl();
            this.tcpServer_Watchdog = new SocketHelper.SocketTcpServer(this.components);
            this.label_Receive = new System.Windows.Forms.Label();
            this.label_State = new System.Windows.Forms.Label();
            this.label_Error = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.字典ToolStripMenuItem,
            this.设置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(1343, 32);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenu_Monitor,
            this.toolStripSeparator1,
            this.toolStripMenu_AutoMonitor,
            this.toolStripMenu_Exit});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // toolStripMenu_Monitor
            // 
            this.toolStripMenu_Monitor.Name = "toolStripMenu_Monitor";
            this.toolStripMenu_Monitor.Size = new System.Drawing.Size(182, 26);
            this.toolStripMenu_Monitor.Text = "打开监视页面";
            this.toolStripMenu_Monitor.Click += new System.EventHandler(this.ToolStripMenu_Monitor_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(179, 6);
            // 
            // toolStripMenu_AutoMonitor
            // 
            this.toolStripMenu_AutoMonitor.CheckOnClick = true;
            this.toolStripMenu_AutoMonitor.Name = "toolStripMenu_AutoMonitor";
            this.toolStripMenu_AutoMonitor.Size = new System.Drawing.Size(182, 26);
            this.toolStripMenu_AutoMonitor.Text = "自动开始监视";
            this.toolStripMenu_AutoMonitor.CheckedChanged += new System.EventHandler(this.toolStripMenu_AutoMonitor_CheckedChanged);
            // 
            // toolStripMenu_Exit
            // 
            this.toolStripMenu_Exit.Name = "toolStripMenu_Exit";
            this.toolStripMenu_Exit.Size = new System.Drawing.Size(182, 26);
            this.toolStripMenu_Exit.Text = "退出";
            this.toolStripMenu_Exit.Click += new System.EventHandler(this.ToolStripMenu_Exit_Click);
            // 
            // 字典ToolStripMenuItem
            // 
            this.字典ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenu_Shiploaders,
            this.toolStripMenu_RadarGroup,
            this.toolStripMenu_Radar,
            this.toolStrip_ThreatLevels});
            this.字典ToolStripMenuItem.Name = "字典ToolStripMenuItem";
            this.字典ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.字典ToolStripMenuItem.Text = "字典";
            // 
            // toolStripMenu_Shiploaders
            // 
            this.toolStripMenu_Shiploaders.Name = "toolStripMenu_Shiploaders";
            this.toolStripMenu_Shiploaders.Size = new System.Drawing.Size(152, 26);
            this.toolStripMenu_Shiploaders.Text = "大机";
            this.toolStripMenu_Shiploaders.Click += new System.EventHandler(this.ToolStripMenu_Shiploaders_Click);
            // 
            // toolStripMenu_RadarGroup
            // 
            this.toolStripMenu_RadarGroup.Name = "toolStripMenu_RadarGroup";
            this.toolStripMenu_RadarGroup.Size = new System.Drawing.Size(152, 26);
            this.toolStripMenu_RadarGroup.Text = "雷达组";
            this.toolStripMenu_RadarGroup.Click += new System.EventHandler(this.ToolStripMenu_RadarGroup_Click);
            // 
            // toolStripMenu_Radar
            // 
            this.toolStripMenu_Radar.Name = "toolStripMenu_Radar";
            this.toolStripMenu_Radar.Size = new System.Drawing.Size(152, 26);
            this.toolStripMenu_Radar.Text = "雷达";
            this.toolStripMenu_Radar.Click += new System.EventHandler(this.ToolStripMenu_Radar_Click);
            // 
            // toolStrip_ThreatLevels
            // 
            this.toolStrip_ThreatLevels.Name = "toolStrip_ThreatLevels";
            this.toolStrip_ThreatLevels.Size = new System.Drawing.Size(152, 26);
            this.toolStrip_ThreatLevels.Text = "威胁级数";
            this.toolStrip_ThreatLevels.Click += new System.EventHandler(this.ToolStrip_ThreatLevels_Click);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_OpcConfig,
            this.toolStrip_CoorsLimitConfig});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // toolStrip_OpcConfig
            // 
            this.toolStrip_OpcConfig.Name = "toolStrip_OpcConfig";
            this.toolStrip_OpcConfig.Size = new System.Drawing.Size(224, 26);
            this.toolStrip_OpcConfig.Text = "OPC配置";
            this.toolStrip_OpcConfig.Click += new System.EventHandler(this.ToolStrip_OpcConfig_Click);
            // 
            // toolStrip_CoorsLimitConfig
            // 
            this.toolStrip_CoorsLimitConfig.Name = "toolStrip_CoorsLimitConfig";
            this.toolStrip_CoorsLimitConfig.Size = new System.Drawing.Size(224, 26);
            this.toolStrip_CoorsLimitConfig.Text = "坐标限制";
            this.toolStrip_CoorsLimitConfig.Click += new System.EventHandler(this.ToolStrip_CoorsLimitConfig_Click);
            // 
            // tabControl_Main
            // 
            this.tabControl_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_Main.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl_Main.Location = new System.Drawing.Point(0, 32);
            this.tabControl_Main.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl_Main.Name = "tabControl_Main";
            this.tabControl_Main.SelectedIndex = 0;
            this.tabControl_Main.Size = new System.Drawing.Size(1343, 714);
            this.tabControl_Main.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl_Main.TabIndex = 1;
            this.tabControl_Main.DoubleClick += new System.EventHandler(this.TabControl_Main_DoubleClick);
            // 
            // tcpServer_Watchdog
            // 
            this.tcpServer_Watchdog.CheckTime = 1000;
            this.tcpServer_Watchdog.HeartBeatCheck = null;
            this.tcpServer_Watchdog.HeartBeatPacket = "X";
            this.tcpServer_Watchdog.IsHeartCheck = true;
            this.tcpServer_Watchdog.IsStartListening = false;
            this.tcpServer_Watchdog.LocalEndPoint = null;
            this.tcpServer_Watchdog.RemoteEndPoint = null;
            this.tcpServer_Watchdog.ServerIp = "127.0.0.1";
            this.tcpServer_Watchdog.ServerPort = 5001;
            this.tcpServer_Watchdog.ServerSocket = null;
            this.tcpServer_Watchdog.StartSockst = null;
            this.tcpServer_Watchdog.TcpServerRecevice += new SocketHelper.SocketTcpServer.ReceviceEventHandler(this.TcpServer_Watchdog_TcpServerRecevice);
            this.tcpServer_Watchdog.OnErrorMsg += new SocketHelper.SocketTcpServer.ErrorMsgEventHandler(this.TcpServer_Watchdog_OnErrorMsg);
            this.tcpServer_Watchdog.OnStateInfo += new SocketHelper.SocketTcpServer.StateInfoEventHandler(this.TcpServer_Watchdog_OnStateInfo);
            // 
            // label_Receive
            // 
            this.label_Receive.AutoSize = true;
            this.label_Receive.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label_Receive.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Receive.Location = new System.Drawing.Point(0, 686);
            this.label_Receive.Name = "label_Receive";
            this.label_Receive.Size = new System.Drawing.Size(108, 20);
            this.label_Receive.TabIndex = 6;
            this.label_Receive.Text = "label_Receive";
            this.label_Receive.Visible = false;
            // 
            // label_State
            // 
            this.label_State.AutoSize = true;
            this.label_State.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label_State.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_State.Location = new System.Drawing.Point(0, 706);
            this.label_State.Name = "label_State";
            this.label_State.Size = new System.Drawing.Size(89, 20);
            this.label_State.TabIndex = 5;
            this.label_State.Text = "label_State";
            // 
            // label_Error
            // 
            this.label_Error.AutoSize = true;
            this.label_Error.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label_Error.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Error.Location = new System.Drawing.Point(0, 726);
            this.label_Error.Name = "label_Error";
            this.label_Error.Size = new System.Drawing.Size(87, 20);
            this.label_Error.TabIndex = 4;
            this.label_Error.Text = "label_Error";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1343, 746);
            this.Controls.Add(this.label_Receive);
            this.Controls.Add(this.label_State);
            this.Controls.Add(this.label_Error);
            this.Controls.Add(this.tabControl_Main);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormMain";
            this.Text = "毫米波雷达";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenu_Monitor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenu_Exit;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 字典ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenu_Shiploaders;
        private System.Windows.Forms.TabControl tabControl_Main;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenu_RadarGroup;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenu_Radar;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_ThreatLevels;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_OpcConfig;
        private SocketHelper.SocketTcpServer tcpServer_Watchdog;
        private System.Windows.Forms.Label label_Receive;
        private System.Windows.Forms.Label label_State;
        private System.Windows.Forms.Label label_Error;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenu_AutoMonitor;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_CoorsLimitConfig;
    }
}