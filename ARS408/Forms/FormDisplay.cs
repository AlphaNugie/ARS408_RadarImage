﻿using ARS408.Core;
using ARS408.Model;
using CommonLib.Clients;
using CommonLib.Events;
using CommonLib.Function;
using CommonLib.UIControlUtil;
using OPCAutomation;
using SocketHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace ARS408.Forms
{
    public partial class FormDisplay : Form
    {
        #region 私有变量
        private bool finalized = false;
        private readonly Regex pattern = new Regex(BaseConst.Pattern_WrappedStatus, RegexOptions.Compiled);
        private readonly DataService_Sqlite dataService = new DataService_Sqlite();
        private readonly DataService_Radar dataService_Radar = new DataService_Radar();
        private List<ClusterGeneral> list_cluster = null;
        private List<ObjectGeneral> list_object = null;
        //private readonly ushort refresh_interval = 200;
        private Bitmap bitmap = null;
        private Graphics graphic = null;
        private string received = string.Empty, wrapped = string.Empty;
        private Thread thread = null/*, thread_writeitems = null*/;
        private float scale = 1, column_width = 0;
        private readonly float scale_original = 1;
        private int time = 0; //重连次数
        #endregion
        #region 属性
        /// <summary>
        /// 标题栏原始标题
        /// </summary>
        public string Title { get { return this.Radar == null ? "ARS408-21" : this.Radar.Name; } }

        /// <summary>
        /// 帧消息处理类
        /// </summary>
        public DataFrameMessages Infos { get; private set; }

        /// <summary>
        /// 雷达信息对象，假如为null，则代表为单雷达显示模式
        /// </summary>
        public Radar Radar { get; set; }

        #region 连接
        /// <summary>
        /// UDP客户端
        /// </summary>
        public DerivedUdpClient UdpClient { get; set; }

        /// <summary>
        /// 远端IP地址
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// 远端端口
        /// </summary>
        public ushort Port { get; set; }

        /// <summary>
        /// 连接模式
        /// </summary>
        public ConnectionMode ConnectionMode { get; set; }

        /// <summary>
        /// 是否制定本地IP与端口
        /// </summary>
        public bool UsingLocal { get; set; }

        /// <summary>
        /// 本地IP地址
        /// </summary>
        public string IpAddress_Local { get; set; }

        /// <summary>
        /// 本地端口
        /// </summary>
        public int Port_Local { get; set; }
        #endregion

        /// <summary>
        /// 当前的画面比例
        /// </summary>
        public float S
        {
            get { return this.scale; }
            set
            {
                this.scale = value;
                this.PaintAll();
            }
        }

        /// <summary>
        /// 是否在拖拽图片
        /// </summary>
        public bool PictureMoving { get; set; }

        /// <summary>
        /// 是否在显示
        /// </summary>
        public bool IsShown { get; set; }

        private int rcsMinimum = -64;
        private int rcsMaximum = 64;

        /// <summary>
        /// RCS最小值
        /// </summary>
        public int RcsMinimum
        {
            //是否使用公共RCS值范围
            get { return BaseConst.UsePublicRcsRange ? BaseConst.RcsMinimum : this.rcsMinimum; }
            set
            {
                if (BaseConst.UsePublicRcsRange)
                    BaseConst.RcsMinimum = value;
                else
                {
                    this.rcsMinimum = value;
                    //向数据库保存RCS值最小值
                    if (this.Radar != null)
                        this.dataService_Radar.UpdateRadarRcsMinById(this.rcsMinimum, this.Radar.Id);
                }
            }
        }

        /// <summary>
        /// RCS最大值
        /// </summary>
        public int RcsMaximum
        {
            get { return BaseConst.UsePublicRcsRange ? BaseConst.RcsMaximum : this.rcsMaximum; }
            set
            {
                if (BaseConst.UsePublicRcsRange)
                    BaseConst.RcsMaximum = value;
                else
                {
                    this.rcsMaximum = value;
                    //向数据库保存RCS值最小值
                    if (this.Radar != null)
                        this.dataService_Radar.UpdateRadarRcsMaxById(this.rcsMaximum, this.Radar.Id);
                }
            }
        }

        ///// <summary>
        ///// 允许的存在概率最低值
        ///// </summary>
        //public double ProbOfExistMinimum { get; set; }
        #endregion
        #region OPC属性
        /// <summary>
        /// OPC工具
        /// </summary>
        public OpcUtilHelper OpcHelper { get { return this.Radar == null ? null : this.Radar.OpcHelper; } }

        /// <summary>
        /// 雷达对应OPC组
        /// </summary>
        public OPCGroup OpcGroup { get; set; }

        /// <summary>
        /// 所有待添加OPC标签名称
        /// </summary>
        public string[] OpcItemNames { get; set; }

        /// <summary>
        /// OPC标签的服务端句柄
        /// </summary>
        public Array ServerHandlers;
        #endregion

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="radar">雷达信息对象</param>
        public FormDisplay(Radar radar)
        {
            InitializeComponent();
            this.Radar = radar;

            this.Init(this.Radar);
        }

        /// <summary>
        /// 默认构造器
        /// </summary>
        public FormDisplay() : this(null) { }

        /// <summary>
        /// 窗体加载后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormDisplay_Load(object sender, EventArgs e) { }

        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormDisplay_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Finalizing();
        }

        private void Init(Radar radar)
        {
            //this.OpcHelper = radar == null ? null : radar.OpcHelper;
            this.IpAddress = radar == null ? BaseConst.IpAddress : radar.IpAddress;
            this.Port = radar == null ? BaseConst.Port : radar.Port;
            this.ConnectionMode = radar == null ? BaseConst.ConnectionMode : radar.ConnectionMode;
            this.UsingLocal = radar == null ? BaseConst.UsingLocal : radar.UsingLocal;
            this.IpAddress_Local = BaseConst.IpAddress_Local;
            this.Port_Local = radar == null ? BaseConst.Port_Local : radar.PortLocal;
            //this.ProbOfExistMinimum = radar == null ? BaseConst.ProbOfExistMinimum : radar.ProbOfExistMinimum;
            this.rcsMinimum = radar == null ? BaseConst.RcsMinimum : radar.RcsMinimum;
            this.rcsMaximum = radar == null ? BaseConst.RcsMaximum : radar.RcsMaximum;

            //this.thread_writeitems = new Thread(new ThreadStart(this.WriteItemValuesLoop)) { IsBackground = true };
            //this.AddGroupItemsAsync();

            this.column_width = this.tableLayoutPanel_Main.ColumnStyles[0].Width;
            this.Infos = new DataFrameMessages(this, this.Radar);
            this.list_cluster = this.Infos.ListTrigger_Cluster;
            this.list_object = this.Infos.ListTrigger_Object;
            this.Name = this.Title;
            this.Text = this.Title;
            this.S = this.scale_original;

            this.InitControls();
        }

        #region 功能
        /// <summary>
        /// 初始化控件
        /// </summary>
        private void InitControls()
        {
            this.dataGridView_Output.AutoGenerateColumns = false;
            this.dataGridView_Output.SetDoubleBuffered(true);
            this.tabControl_Main.SelectedTab = this.tabPage_vertex; //选中图像页
            this.textBox_IpAddress.Text = this.IpAddress;
            this.numeric_Port.Value = this.Port;

            this.comboBox_ConnMode.DataSource = this.dataService.GetConnModes();
            this.comboBox_ConnMode.SelectedIndexChanged += new System.EventHandler(this.ComboBox_ConnMode_SelectedIndexChanged);
            this.comboBox_ConnMode.SelectedValue = (int)this.ConnectionMode;

            //this.comboBox_ProbMinimum.DataSource = this.dataService.GetAllExistProbs();
            //this.comboBox_ProbMinimum.SelectedIndexChanged += new System.EventHandler(this.ComboBox_ProbMinimum_SelectedIndexChanged);
            //this.comboBox_ProbMinimum.SelectedValue = this.ProbOfExistMinimum;

            this.checkBox_UsingLocal.Checked = this.UsingLocal;
            this.textBox_IpAddress_Local.Text = this.IpAddress_Local;
            this.numeric_Port_Local.Value = this.Port_Local;
            //int min = this.RcsMinimum, max = this.RcsMaximum;
            this.trackBar_RcsMin.Value = this.RcsMinimum;
            this.trackBar_RcsMax.Value = this.RcsMaximum;
            this.timer_UIUpdate.Start();

            this.pictureBox_Dots.MouseWheel += new MouseEventHandler(PictureBox_Dots_MouseWheel);
        }

        public void Finalizing()
        {
            if (this.finalized)
                return;
            this.SocketTcpClient.StopConnection();
            this.SocketTcpServer.Stop();
            this.ThreadControl(false);
            this.Infos.ThreadCheck.Abort();
            //this.thread_writeitems.Abort();
            this.finalized = true;
            BaseConst.IniHelper.WriteData("Detection", "RcsMinimum", this.RcsMinimum.ToString());
            BaseConst.IniHelper.WriteData("Detection", "RcsMaximum", this.RcsMaximum.ToString());
            if (this.Radar != null)
                return;

            BaseConst.IniHelper.WriteData("Connection", "IpAddress", this.IpAddress);
            BaseConst.IniHelper.WriteData("Connection", "Port", this.Port.ToString());
            BaseConst.IniHelper.WriteData("Connection", "ConnectionMode", ((int)this.ConnectionMode).ToString());
            BaseConst.IniHelper.WriteData("Connection", "UsingLocal", this.checkBox_UsingLocal.Checked ? "1" : "0");
            BaseConst.IniHelper.WriteData("Connection", "IpAddressLocal", this.textBox_IpAddress_Local.Text);
            BaseConst.IniHelper.WriteData("Connection", "PortLocal", this.numeric_Port_Local.Value.ToString());
            //BaseConst.IniHelper.WriteData("Detection", "ProbOfExistMinimum", this.ProbOfExistMinimum.ToString());
        }

        /// <summary>
        /// 线程控制
        /// </summary>
        /// <param name="flag"></param>
        private void ThreadControl(bool flag)
        {
            if (flag)
            {
                if (this.thread == null)
                    this.thread = new Thread(new ThreadStart(this.ProcessReceivedData)) { IsBackground = true };
                this.thread.Start();
            }
            else
            {
                if (this.thread != null)
                    this.thread.Abort();
                this.thread = null;
            }
        }

        /// <summary>
        /// 开始或结束接收
        /// </summary>
        /// <param name="flag">假如为true，则开始接收，否则结束接收</param>
        public void StartOrEndReceiving(bool flag)
        {
            int result;
            //if (this.ConnectionMode == ConnectionMode.TCP_CLIENT)
            //    result = flag ? this.Connect() : this.Disconnect();
            //else
            //    this.UdpInitOrClose();
            switch (this.ConnectionMode)
            {
                case ConnectionMode.TCP_CLIENT:
                    result = flag ? this.Connect() : this.Disconnect();
                    break;
                case ConnectionMode.UDP:
                    this.UdpInitOrClose();
                    break;
                case ConnectionMode.TCP_SERVER:
                    this.TcpServerInitOrClose(flag);
                    break;
            }
        }

        /// <summary>
        /// 连接
        /// </summary>
        private int Connect()
        {
            //bool usingTcp = this.ConnectionMode == 1;
            try
            {
                switch (this.ConnectionMode)
                {
                    case ConnectionMode.TCP_CLIENT:
                        //this.SocketTcpClient.Tcpclient.ReceiveBufferSize = 4096;
                        this.SocketTcpClient.ServerIp = this.IpAddress;
                        this.SocketTcpClient.ServerPort = this.Port;
                        this.SocketTcpClient.AssignLocalAddress = this.checkBox_UsingLocal.Checked;
                        this.SocketTcpClient.LocalIp = this.IpAddress_Local;
                        this.SocketTcpClient.LocalPort = this.Port_Local;
                        this.SocketTcpClient.StartConnection();
                        break;
                    case ConnectionMode.UDP:
                        //this.UdpClient.ReceiveRestTime = BaseConst.ReceiveRestTime;
                        if (this.checkBox_UsingLocal.Checked)
                            this.UdpClient.Connect(this.IpAddress, this.Port, this.IpAddress_Local, this.Port_Local);
                        else
                            this.UdpClient.Connect(this.IpAddress, this.Port);
                        break;
                    case ConnectionMode.TCP_SERVER:
                        break;
                }
            }
            catch (Exception)
            {
                this.Text = this.Title + " - 连接失败";
                return 0;
            }
            this.comboBox_ConnMode.Enabled = false;
            this.button_Send.Enabled = true;
            this.button_Disconnect.Enabled = true;
            this.button_Connect.Enabled = false;
            this.Text = this.Title + " - 连接成功";
            if (this.ConnectionMode == ConnectionMode.TCP_CLIENT)
                this.ThreadControl(true);
            this.timer_GraphicRefresh.Enabled = true;
            this.timer_GridRefresh.Enabled = true;
            return 1;
        }

        /// <summary>
        /// 断开连接
        /// </summary>
        private int Disconnect()
        {
            //bool usingTcp = this.ConnectionMode == 1;
            try
            {
                switch (this.ConnectionMode)
                {
                    case ConnectionMode.TCP_CLIENT:
                        this.SocketTcpClient.StopConnection();
                        break;
                    case ConnectionMode.UDP:
                        this.UdpClient.Close();
                        break;
                    case ConnectionMode.TCP_SERVER:
                        break;
                }
            }
            catch (Exception)
            {
                this.Text = this.Title + " - 断开失败";
                return 0;
            }
            this.comboBox_ConnMode.Enabled = true;
            this.button_Send.Enabled = false;
            this.button_Connect.Enabled = true;
            this.button_Disconnect.Enabled = false;
            this.Text = this.Title + " - 断开成功";
            if (this.ConnectionMode == ConnectionMode.TCP_CLIENT)
                this.ThreadControl(false);
            this.timer_GraphicRefresh.Enabled = false;
            this.timer_GridRefresh.Enabled = false;
            return 1;
        }

        /// <summary>
        /// UDP初始化或关闭
        /// </summary>
        private void UdpInitOrClose()
        {
            bool init = this.button_ServerInit.Text.Equals("初始化"); //初始化或结束
            if (init)
            {
                try { this.UdpClient = this.checkBox_UsingLocal.Checked ? new DerivedUdpClient(this.IpAddress_Local, this.Port_Local) : new DerivedUdpClient(); }
                catch (Exception) { return; }
                //this.UdpClient.ReceiveRestTime = BaseConst.ReceiveRestTime;
                this.UdpClient.DataReceived += new DataReceivedEventHandler(this.Client_DataReceived);
                this.UdpClient.ReconnTimerChanged += new ReconnTimerChangedEventHandler(this.ReconnTimerChanged);
            }
            else
            {
                this.UdpClient.DataReceived -= new DataReceivedEventHandler(this.Client_DataReceived);
                this.UdpClient.ReconnTimerChanged -= new ReconnTimerChangedEventHandler(this.ReconnTimerChanged);
                this.UdpClient.Close();
                this.UdpClient = null;
            }
            this.button_ServerInit.Text = init ? "结束" : "初始化";
            this.button_Connect.Enabled = init;
            this.ThreadControl(init);
            this.timer_GraphicRefresh.Enabled = init;
            this.timer_GridRefresh.Enabled = init;
        }

        /// <summary>
        /// TCP监听启动或关闭
        /// </summary>
        /// <param name="init">是否开始监听，为true开始，为false结束</param>
        private void TcpServerInitOrClose(bool init)
        {
            //bool init = this.button_ServerInit.Text.Equals("初始化"); //初始化或结束
            if (init)
            {
                this.SocketTcpServer.ServerIp = this.IpAddress_Local;
                this.SocketTcpServer.ServerPort = this.Port_Local;
                this.SocketTcpServer.Start();
            }
            else
                this.SocketTcpServer.Stop();
            this.button_ServerInit.Text = init ? "结束" : "初始化";
            this.ThreadControl(init);
            this.timer_GraphicRefresh.Enabled = init;
            this.timer_GridRefresh.Enabled = init;
        }

        /// <summary>
        /// 处理单次输入
        /// </summary>
        /// <param name="input"></param>
        private void ProcessUnit(string input)
        {
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            Infos.Filter(input);
            if (this.IsShown)
            {
                this.textBox_Input.SafeInvoke(() => this.textBox_Input.Text = input);
                this.textBox_Info.SafeInvoke(() =>
                {
                    this.textBox_Info.Text = string.Format(@"{0} 至 {1:yyyy-MM-dd HH:mm:ss.fff} ==>
数据列表长度：{2}
集群或目标数量：{3}
实际数量：{4}", time, DateTime.Now, this.Infos.ListTriggerCount, this.Infos.BufferSize, this.Infos.ActualSize);
                });
            }
        }

        /// <summary>
        /// 循环处理数据
        /// </summary>
        private void ProcessReceivedData()
        {
            while (true)
            {
                try
                {
                    bool connected = false;
                    string name = string.Empty;
                    switch (this.ConnectionMode)
                    {
                        case ConnectionMode.TCP_CLIENT:
                            connected = this.SocketTcpClient.IsStart;
                            name = this.SocketTcpClient.Name;
                            break;
                        case ConnectionMode.UDP:
                            connected = this.UdpClient.IsConnected_Socket || this.UdpClient.IsStartListening;
                            name = this.UdpClient.Name;
                            break;
                        case ConnectionMode.TCP_SERVER:
                            connected = this.SocketTcpServer.IsStartListening;
                            name = this.SocketTcpServer.Name;
                            break;
                    }
                    this.SafeInvoke(() => { this.Text = this.Title + " - " + (connected ? name : "连接断开"); });

                    #region 被动接收
                    this.wrapped = this.received;
                    if (BaseFunc.GetWrappedMessage(ref this.wrapped))
                    {
                        this.received = string.Empty;
                        this.ProcessUnit(this.wrapped);
                    }
                    #endregion
                }
                catch (Exception) { }
                Thread.Sleep(BaseConst.RefreshInterval);
            }
        }
        #endregion

        #region 表格与图像
        /// <summary>
        /// 刷新GridView数据源
        /// </summary>
        private void DataGridViewRefresh()
        {
            if (!this.IsShown)
                return;

            try
            {
                dynamic list_new, binding;
                if (this.Infos.CurrentSensorMode == SensorMode.Cluster)
                {
                    list_new = this.list_cluster.ToList();
                    binding = new BindingList<ClusterGeneral>(list_new);
                }
                else
                {
                    list_new = this.list_object.ToList();
                    binding = new BindingList<ObjectGeneral>(list_new);
                }
                this.dataGridView_Output.DataSource = null;
                this.dataGridView_Output.DataSource = binding;
            }
            catch (Exception) { }
        }

        /// <summary>
        /// 放一张背景图
        /// </summary>
        private void PaintInit()
        {
            this.bitmap = new Bitmap(BaseConst.OriginalImage, (int)(BaseConst.OriginalImage.Width * S), (int)(BaseConst.OriginalImage.Height * S));
            this.graphic = Graphics.FromImage(this.bitmap);
            this.pictureBox_Dots.SafeInvoke(() => { this.pictureBox_Dots.Image = this.bitmap; });
        }

        /// <summary>
        /// 画出所有集群
        /// </summary>
        private void PaintVertexes()
        {
            if (this.Infos.CurrentSensorMode == SensorMode.Cluster)
                this.PaintVertexes(this.list_cluster);
            else
                this.PaintVertexes(this.list_object);
        }

        /// <summary>
        /// 画出指定的集群
        /// </summary>
        /// <param name="list">集群列表</param>
        private void PaintVertexes<T>(IEnumerable<T> list)
        {
            if (list == null || list.Count() == 0)
                return;

            List<T> list_new = list.ToList();
            foreach (dynamic dot in list_new)
                if (dot != null/* && dot.DistLong <= 100 && Math.Abs(dot.DistLat) <= 50*/)
                    if (dot is ClusterGeneral)
                        this.graphic.FillEllipse(new SolidBrush(dot.Color), (float)(448 - dot.DistLat * BaseConst.R) * S, (float)(839 - dot.DistLong * BaseConst.R) * S, BaseConst.T, BaseConst.T); //画实心椭圆
                    else if (dot is ObjectGeneral)
                        this.graphic.FillRectangle(new SolidBrush(dot.Color), (float)(448 - dot.DistLat * BaseConst.R) * S, (float)(839 - dot.DistLong * BaseConst.R) * S, BaseConst.T * 2, BaseConst.T * 2); //画实心矩形
        }

        /// <summary>
        /// 绘制所有图像
        /// </summary>
        private void PaintAll()
        {
            if (!this.IsShown)
                return;

            this.PaintInit();
            this.PaintVertexes();
        }

        /// <summary>
        /// 放大或缩小
        /// </summary>
        /// <param name="mode">-1 缩小，1 放大</param>
        /// <param name="layers">操作次数（层数）</param>
        private void Zoom(int mode, uint layers)
        {
            double ratio;
            if (mode == -1)
                ratio = BaseConst.ScrollRatio;
            else if (mode == 1)
                ratio = 1 / BaseConst.ScrollRatio;
            else
                ratio = this.scale_original;
            this.S *= (float)Math.Pow(ratio, layers);
        }

        /// <summary>
        /// 放大或缩小一次
        /// </summary>
        /// <param name="mode">-1 缩小，1 放大</param>
        private void Zoom(int mode)
        {
            this.Zoom(mode, 1);
        }
        #endregion

        #region 事件
        /// <summary>
        /// IP地址改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_IpAddress_TextChanged(object sender, EventArgs e)
        {
            this.IpAddress = this.textBox_IpAddress.Text;
        }

        /// <summary>
        /// 端口号改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Numeric_Port_ValueChanged(object sender, EventArgs e)
        {
            this.Port = (ushort)this.numeric_Port.Value;
        }

        /// <summary>
        /// 连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Connect_Click(object sender, EventArgs e)
        {
            this.Connect();
        }

        /// <summary>
        /// 断开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Disconnect_Click(object sender, EventArgs e)
        {
            this.Disconnect();
        }

        /// <summary>
        /// 初始化按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_ServerInit_Click(object sender, EventArgs e)
        {
            switch (this.ConnectionMode)
            {
                case ConnectionMode.UDP:
                    this.UdpInitOrClose();
                    break;
                case ConnectionMode.TCP_SERVER:
                    this.TcpServerInitOrClose(this.button_ServerInit.Text.Equals("初始化"));
                    break;
            }
        }

        /// <summary>
        /// TCP客户端连接次数改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="time"></param>
        private void ReconnTimerChanged(object sender, int time) { this.time = time; }

        /// <summary>
        /// 数据接收事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void Client_DataReceived(object sender, DataReceivedEventArgs eventArgs)
        {
            this.received += " " + eventArgs.ReceivedInfo_HexString;
            this.Infos.Timer = 0;
        }

        private void SocketTcpClient_OnRecevice(object sender, ReceivedEventArgs e)
        {
            this.received += " " + e.ReceivedHexString;
            this.Infos.Timer = 0;
        }

        private void SocketTcpServer_TcpServerRecevice(Socket temp, ReceivedEventArgs e)
        {
            this.received += " " + e.ReceivedHexString;
            this.Infos.Timer = 0;
        }

        /// <summary>
        /// 刷新控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_GraphicRefresh_Tick(object sender, EventArgs e)
        {
            //this.DataGridViewRefresh();
            this.PaintAll();
        }

        /// <summary>
        /// 刷新控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_GridRefresh_Tick(object sender, EventArgs e)
        {
            this.DataGridViewRefresh();
            //this.PaintAll();
        }

        /// <summary>
        /// 放大
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Zoomin_Click(object sender, EventArgs e)
        {
            //this.S *= 1 / BaseConst.ScrollRatio;
            this.Zoom(1);
        }

        /// <summary>
        /// 缩小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Zoomout_Click(object sender, EventArgs e)
        {
            //this.S *= BaseConst.ScrollRatio;
            this.Zoom(-1);
        }

        /// <summary>
        /// 恢复原尺寸
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Fullsize_Click(object sender, EventArgs e)
        {
            this.S = this.scale_original;
            //this.Zoom(0);
        }

        int mousex = 0, mousey = 0, hscrollv = 0, vscrollv = 0;
        bool occupied = false;

        /// <summary>
        /// 鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_Dots_MouseDown(object sender, MouseEventArgs e)
        {
            //记录鼠标按下时的坐标与滚动轴位置
            mousex = e.X;
            mousey = e.Y;
            hscrollv = this.panel1.HorizontalScroll.Value;
            vscrollv = this.panel1.VerticalScroll.Value;
            this.PictureMoving = true;
            //new Thread(new ThreadStart(this.Moving)) { IsBackground = true }.Start();
        }

        /// <summary>
        /// 鼠标松开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_Dots_MouseUp(object sender, MouseEventArgs e)
        {
            this.PictureMoving = false;
        }

        /// <summary>
        /// 鼠标移动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_Dots_MouseMove(object sender, MouseEventArgs e)
        {
            if (!this.PictureMoving || occupied)
                return;

            occupied = true;
            int deltax = mousex - e.X, deltay = mousey - e.Y; //本次移动距离
            //移动后的位置，假如在范围内，更新滚动条位置
            int resultx = hscrollv + deltax;
            int resulty = vscrollv + deltay;
            if (resultx.Between(this.panel1.HorizontalScroll.Minimum, this.panel1.HorizontalScroll.Maximum))
                this.panel1.HorizontalScroll.Value = resultx;
            if (resulty.Between(this.panel1.VerticalScroll.Minimum, this.panel1.VerticalScroll.Maximum))
                this.panel1.VerticalScroll.Value = resulty;
            occupied = false;
        }

        private void TextBox_IpAddress_Local_TextChanged(object sender, EventArgs e)
        {
            this.IpAddress_Local = this.textBox_IpAddress_Local.Text;
        }

        private void Numeric_Port_Local_ValueChanged(object sender, EventArgs e)
        {
            this.Port_Local = (ushort)this.numeric_Port_Local.Value;
        }

        private void Button_Send_Click(object sender, EventArgs e)
        {
            if (this.ConnectionMode == ConnectionMode.TCP_CLIENT && this.SocketTcpClient.IsConnected_Socket)
                this.SocketTcpClient.SendData(this.textBox_SendContent.Text);
            else if (this.ConnectionMode == ConnectionMode.UDP && this.UdpClient.IsConnected)
                this.UdpClient.SendString(this.textBox_SendContent.Text);
            else if (this.ConnectionMode == ConnectionMode.TCP_SERVER)
                this.SocketTcpServer.ClientSocketList.ForEach(client => this.SocketTcpServer.SendData(client, this.textBox_SendContent.Text));
        }

        private void ComboBox_ConnMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ConnectionMode = (ConnectionMode)int.Parse(this.comboBox_ConnMode.SelectedValue.ToString());
            this.button_ServerInit.Enabled = this.ConnectionMode != ConnectionMode.TCP_CLIENT; //UDP, TCP Server模式下可使用初始化按钮
            this.button_Connect.Enabled = this.ConnectionMode != ConnectionMode.TCP_SERVER && !this.button_ServerInit.Enabled; //非Tcp Server模式连接按钮是否可用取决于初始化按钮
        }

        //private void ComboBox_ProbMinimum_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //this.ProbOfExistMinimum = double.Parse(this.comboBox_ProbMinimum.SelectedValue.ToString());
        //}

        private void Timer_WriteItems_Tick(object sender, EventArgs e)
        {
            //this.WriteItemValues();
        }

        private void Timer_UIUpdate_Tick(object sender, EventArgs e)
        {
            this.trackBar_RcsMax.Value = this.RcsMaximum;
            this.trackBar_RcsMin.Value = this.RcsMinimum;
        }

        private void CheckBox_UsingLocal_CheckedChanged(object sender, EventArgs e)
        {
            this.UsingLocal = this.checkBox_UsingLocal.Checked;
        }

        /// <summary>
        /// 滚轮滑动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_Dots_MouseWheel(object sender, MouseEventArgs e)
        {
            //DELTA为负数代表向下搓，用来放大，反之则代表向上搓，用来缩小
            int times = e.Delta / -120;
            int mode = Math.Sign(times); //放大或缩小
            uint layer = (uint)(times / mode); //操作层数（连续操作若干次）
            this.Zoom(mode, layer);
        }

        /// <summary>
        /// 双击分页栏掩藏左边栏，假如已隐藏则显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControl_Main_DoubleClick(object sender, EventArgs e)
        {
            float current = this.tableLayoutPanel_Main.ColumnStyles[0].Width;
            this.tableLayoutPanel_Main.ColumnStyles[0] = new ColumnStyle(SizeType.Absolute, this.column_width - current);
        }

        private void FormDisplay_Shown(object sender, EventArgs e)
        {
            this.IsShown = true;
        }

        private void TrackBar_RcsMin_ValueChanged(object sender, EventArgs e)
        {
            this.label_RcsMin.Text = (this.RcsMinimum = this.trackBar_RcsMin.Value).ToString();
        }

        private void TrackBar_RcsMax_ValueChanged(object sender, EventArgs e)
        {
            this.label_RcsMax.Text = (this.RcsMaximum = this.trackBar_RcsMax.Value).ToString();
        }
        #endregion
    }
}
