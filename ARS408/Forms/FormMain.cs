using ARS408.Core;
using CarServer;
using CommonLib.Clients;
using CommonLib.Function;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARS408.Forms
{
    public partial class FormMain : Form
    {
        #region 私有变量
        private FormMonitor first_monitor;
        private DataService_Shiploader DataService_Shiploader = new DataService_Shiploader();
        private string tcp_info_error = string.Empty;
        private string tcp_info_state = string.Empty;
        private string tcp_info_receive = string.Empty;
        private readonly CommonLib.Clients.Object.FileClient file_client = new CommonLib.Clients.Object.FileClient("Logs\\tcp_server_watchdog", "tcp_server_log.txt");
        #endregion

        /// <summary>
        /// 默认构造器
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
            this.Init_Watchdog();
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            //假如勾选自动开始监视，打开监视页面
            if (this.toolStripMenu_AutoMonitor.Checked = BaseConst.IniHelper.ReadData("Main", "AutoMonitor").Equals("1"))
                this.StartMonitor();
        }

        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (TabPage page in this.tabControl_Main.TabPages)
                this.DisposeTabPage(page);
            this.tcpServer_Watchdog.Stop();
            this.timer1.Stop();
        }

        #region 功能
        /// <summary>
        /// Tcp服务端初始化，发送心跳数据
        /// </summary>
        private void Init_Watchdog()
        {
            this.tcpServer_Watchdog.ServerIp = BaseConst.IniHelper.ReadData("Watchdog", "MainServerIp");
            this.tcpServer_Watchdog.ServerPort = int.Parse(BaseConst.IniHelper.ReadData("Watchdog", "MainServerPort"));
            this.tcpServer_Watchdog.IsheartCheck = BaseConst.IniHelper.ReadData("Watchdog", "SendHeartBeat").Equals("1");
            this.tcpServer_Watchdog.HeartbeatPacket = BaseConst.IniHelper.ReadData("Watchdog", "HeartBeatString");
            this.tcpServer_Watchdog.CheckTime = int.Parse(BaseConst.IniHelper.ReadData("Watchdog", "HeartBeatInterval"));
            this.tcpServer_Watchdog.Start();
        }

        /// <summary>
        /// 打开监视页面
        /// </summary>
        private void StartMonitor()
        {
            DataTable table = this.DataService_Shiploader.GetAllShiploadersOrderbyId();
            if (table == null || table.Rows.Count == 0)
                return;

            table.Rows.Cast<DataRow>().ToList().ForEach(row => this.ShowForm(this.first_monitor = new FormMonitor(int.Parse(row["shiploader_id"].ToString())), DockStyle.Fill));
        }

        /// <summary>
        /// 在TabPage页中加载窗体对象，默认不停靠TabPage
        /// </summary>
        /// <param name="form">需在TabPage页中加载或显示的窗体对象</param>
        private void ShowForm(Form form)
        {
            this.ShowForm(form, null);
        }

        /// <summary>
        /// 在TabPage页中加载窗体对象
        /// </summary>
        /// <param name="form">需在TabPage页中加载或显示的窗体对象</param>
        /// <param name="dock">停靠方式，假如为null则不停靠</param>
        private void ShowForm(Form form, DockStyle? dock)
        {
            if (form == null)
            {
                MessageBox.Show("无法显示空窗体", "提示消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //假如Tab页已存在，选中该页面
            foreach (TabPage tabPage in this.tabControl_Main.TabPages)
                if (tabPage.Name == form.Name)
                {
                    this.tabControl_Main.SelectedTab = tabPage;
                    return;
                }

            //在TabControl中显示包含该页面的TabPage
            form.TopLevel = false; //不置顶
            if (dock != null)
                form.Dock = dock.Value; //控件停靠方式
            form.FormBorderStyle = FormBorderStyle.None; //页面无边框
            TabPage page = new TabPage();
            page.Controls.Add(form);
            page.Text = form.Text;
            page.Name = form.Name;
            page.AutoScroll = true;
            this.Invoke(new MethodInvoker(delegate
            {
                this.tabControl_Main.TabPages.Add(page);
                this.tabControl_Main.SelectedTab = page;
                form.Show();
            }));
        }

        /// <summary>
        /// 释放TabPage的资源
        /// </summary>
        /// <param name="page"></param>
        private void DisposeTabPage(TabPage page)
        {
            if (page == null)
                return;
            if (page.Controls.Count > 0)
            {
                Form form = (Form)page.Controls[0];
                if (form != null)
                {
                    form.Close();
                    form.Dispose();
                }
            }

            page.Dispose();
        }
        #endregion

        #region 事件
        /// <summary>
        /// 退出按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenu_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 装船机字典按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenu_Shiploaders_Click(object sender, EventArgs e)
        {
            this.ShowForm(new FormShiploader());
        }

        /// <summary>
        /// 雷达组字典按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenu_RadarGroup_Click(object sender, EventArgs e)
        {
            this.ShowForm(new FormRadarGroup());
        }

        /// <summary>
        /// 雷达字典按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenu_Radar_Click(object sender, EventArgs e)
        {
            this.ShowForm(new FormRadar(), DockStyle.Fill);
        }

        /// <summary>
        /// Tab页双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControl_Main_DoubleClick(object sender, EventArgs e)
        {
            this.DisposeTabPage(this.tabControl_Main.SelectedTab);
        }

        /// <summary>
        /// 监视页面双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenu_Monitor_Click(object sender, EventArgs e)
        {
            this.StartMonitor();
            //DataTable table = this.DataService_Shiploader.GetAllShiploadersOrderbyId();
            //if (table == null || table.Rows.Count == 0)
            //    return;

            //table.Rows.Cast<DataRow>().ToList().ForEach(row => this.ShowForm(new FormMonitor(int.Parse(row["shiploader_id"].ToString())), DockStyle.Fill));
        }

        /// <summary>
        /// 威胁级数按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStrip_ThreatLevels_Click(object sender, EventArgs e)
        {
            this.ShowForm(new FormThreatLevels());
        }

        /// <summary>
        /// OPC配置按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStrip_OpcConfig_Click(object sender, EventArgs e)
        {
            FormOpcConfig form = new FormOpcConfig();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }

        /// <summary>
        /// TcpServer出现错误事件
        /// </summary>
        /// <param name="msg">错误信息</param>
        private void TcpServer_Watchdog_OnErrorMsg(string message)
        {
            try { this.OnTcpInfoCallBack(message, 1); }
            catch (Exception ex)
            {
                FileClient.WriteExceptionInfo(ex, "处理TCP服务端错误信息时出现错误", true);
            }
        }

        private void TcpServer_Watchdog_TcpServerRecevice(Socket socket, string message, byte[] data)
        {
            try { this.MessageReceived(socket, message, data); }
            catch (Exception ex)
            {
                FileClient.WriteExceptionInfo(ex, "处理TCP服务端接收的信息时出现错误", true);
            }
        }

        private void TcpServer_Watchdog_OnStateInfo(string message, SocketHelper.SocketState state)
        {
            try { this.OnTcpInfoCallBack(message, 2); }
            catch (Exception ex)
            {
                FileClient.WriteExceptionInfo(ex, "TCP服务端状态信息出错", true);
            }
        }

        public void OnTcpInfoCallBack(object obj, int index)
        {
            string message = Functions.AddTimeToMessage(obj);
            switch (index)
            {
                case 1:
                    this.tcp_info_error = message;
                    break;
                case 2:
                    this.tcp_info_state = message;
                    break;
            }
            this.file_client.WriteLineToFile(message);
        }

        /// <summary>
        /// 接收数据
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        public void MessageReceived(Socket socket, string message, byte[] data)
        {
            string info, ip = ((IPEndPoint)socket.RemoteEndPoint).Address.ToString();
            int port = ((IPEndPoint)socket.RemoteEndPoint).Port;
            ClientModel clientModel = this.tcpServer_Watchdog.ResolveSocket(ip, port);
            if (clientModel == null)
            {
                info = Functions.AddTimeToMessage("客户端为空，怎么就收到消息了呢？不管咋说，消息是这个：" + message);
                this.tcp_info_receive = info;
                return;
            }
            if (clientModel.ClientType == ClientType.None)
            {
                ClientType clientType = ClientModel.AnalyzeClientType(message);
                clientModel.ClientType = clientType;
            }
            info = Functions.AddTimeToMessage(string.Format("{0}:{1} -> 从类型为{2}的客户端 {3}:{4} 接收到数据：{5}", this.tcpServer_Watchdog.ServerIp, this.tcpServer_Watchdog.ServerPort, clientModel.ClientType.ToString(), ip, port, message));
            this.tcp_info_receive = info;
        }

        /// <summary>
        /// 向客户端发送命令
        /// </summary>
        /// <param name="data"></param>
        private void SendData(object data)
        {
            List<ClientModel> list = this.tcpServer_Watchdog.ClientSocketList;
            if (list == null || list.Count == 0)
                return;

            foreach (ClientModel clientModel in list)
            {
                if (clientModel == null)
                    continue;
                if (clientModel.ClientStyle == ClientStyle.WebSocket)
                    this.tcpServer_Watchdog.SendToWebClient(clientModel, data.ToString());
                else
                    this.tcpServer_Watchdog.SendData(clientModel, data.ToString());
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (this.first_monitor != null)
                this.SendData(this.first_monitor.GetBucketSideDistances());
            this.label_Error.Text = this.tcp_info_error;
            this.label_State.Text = this.tcp_info_state;
            this.label_Receive.Text = this.tcp_info_receive;
        }
        #endregion

        private void toolStripMenu_AutoMonitor_CheckedChanged(object sender, EventArgs e)
        {
            BaseConst.IniHelper.WriteData("Main", "AutoMonitor", this.toolStripMenu_AutoMonitor.Checked ? "1" : "0");
        }
    }
}
