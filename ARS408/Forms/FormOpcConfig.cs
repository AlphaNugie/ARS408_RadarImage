using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ARS408.Core;
using OPCAutomation;
using CommonLib.DataUtil;
using CommonLib.Function;
using CommonLib.UIControlUtil;
using ARS408.Model;
//using ScanOutputDemo.DataUtil;

namespace ARS408.Forms
{
    public partial class FormOpcConfig : Form
    {
        /// <summary>
        /// IP Address
        /// </summary>
        public string IpAddress { get; private set; }

        public SqliteProvider Provider { get; private set; }

        public DataService_Shiploader DataService { get; private set; }

        public OPCServer KepServer { get; private set; }
        public OPCGroups KepGroups { get; private set; }
        public OPCGroup KepGroup { get; private set; }
        public OPCItems KepItems { get; private set; }

        private Array lServerHandlers;
        private readonly DataService_Radar dataService = new DataService_Radar(); //数据库服务类

        public FormOpcConfig()
        {
            InitializeComponent();
            this.Provider = new SqliteProvider();
            this.DataService = new DataService_Shiploader();
            this.InitControls();
            this.DataSourceRefresh();
        }

        private void FormOpcServerTest_Load(object sender, EventArgs e) { }

        private void InitControls()
        {
            this.textBox_OpcServerIp.Text = BaseConst.IniHelper.ReadData("OPC", "ServerIp");
            this.comboBox_OpcServerList.Text = BaseConst.IniHelper.ReadData("OPC", "ServerName");
            this.checkBox_WriteItemValue.Checked = BaseConst.IniHelper.ReadData("OPC", "WriteItemValue").Equals("1");
            DataTable table = this.DataService.GetAllShiploadersOrderbyId();
            this.comboBox_TopicName_WalkingPos.DataSource = table;
            this.comboBox_TopicName_PitchAngle.DataSource = table;
            this.comboBox_TopicName_StretchLength.DataSource = table;
            this.comboBox_TopicName_BucketPitch.DataSource = table;
            this.comboBox_TopicName_BucketYaw.DataSource = table;
            this.comboBox_TopicName_BeltSpeed.DataSource = table;
            this.comboBox_TopicName_Stream.DataSource = table;
        }

        /// <summary>
        /// 刷新数据源
        /// </summary>
        private void DataSourceRefresh()
        {
            DataTable table = null;
            try { table = this.dataService.GetRadarItemNamesOrderbyId(); }
            catch (Exception e)
            {
                string errorMessage = "查询时出错：" + e.Message;
                MessageBox.Show(errorMessage, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.dataGridView.DataSource = table;
        }

        private void Button_ServerEnum_Click(object sender, EventArgs e)
        {
            this.ServerEnum();
        }

        private void ServerEnum()
        {
            try
            {
                if (this.textBox_OpcServerIp.Text == string.Empty)
                {
                    MessageBox.Show("请输入IP地址！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (this.textBox_OpcServerIp.Text != "localhost" && !RegexMatcher.IsIpAddressValidated(this.textBox_OpcServerIp.Text))//用正则表达式验证IP地址
                {
                    MessageBox.Show("请输入正确格式的IP地址！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                this.comboBox_OpcServerList.Items.Clear();//清空已显示的OPC Server列表
                this.IpAddress = this.textBox_OpcServerIp.Text;
                if (this.KepServer == null)
                    this.KepServer = new OPCServer();
                //object serverList = this.KepServer.GetOPCServers(IpAddress);
                //Array array = (Array)serverList;
                Array array = (Array)(object)this.KepServer.GetOPCServers(IpAddress);
                //假如Server列表为空，退出方法，否则为ListBoxControl添加Item
                if (array.Length == 0)
                    return;
                //for (int i = 1; i <= array.Length; i++)
                //    this.comboBox_OpcServerList.Items.Add((string)array.GetValue(i));
                this.comboBox_OpcServerList.Items.AddRange(array.Cast<string>().ToArray());
                //if (this.comboBox_OpcServerList.Items.Count > 0)
                    this.comboBox_OpcServerList.SelectedIndex = 0;
            }
            //假如获取OPC Server过程中引发COMException，即代表无法连接此IP的OPC Server
            catch (Exception ex)
            {
                MessageBox.Show("无法连接此IP地址的OPC Server！" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Button_Connect_Click(object sender, EventArgs e)
        {
            if (this.KepServer == null)
                this.KepServer = new OPCServer();
            string server = string.IsNullOrWhiteSpace(this.comboBox_OpcServerList.Text) ? this.comboBox_OpcServerList.SelectedText : this.comboBox_OpcServerList.Text;
            string ip = this.textBox_OpcServerIp.Text;
            try
            {
                this.KepServer.Connect(server, ip);
                string message = string.Format("位于{0}的OPC服务{1}连接成功", ip, server);
                MessageBox.Show(message, "提示");
                this.KepGroups = this.KepServer.OPCGroups;
                //this.KepGroup = this.KepGroups.Add("KepGroup");
                //this.KepItems = this.KepGroup.OPCItems;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("位于{0}的OPC服务{1}连接失败：{2}", ip, server, ex.Message));
                //throw;
            }
        }

        private void TextBox_OpcServerIp_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (e.KeyCode == Keys.Enter)
                this.button_ServerEnum.PerformClick();
        }

        /// <summary>
        /// OPC服务端连接配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_ServerSave_Click(object sender, EventArgs e)
        {
            try
            {
                BaseConst.IniHelper.WriteData("OPC", "ServerIp", this.textBox_OpcServerIp.Text);
                BaseConst.IniHelper.WriteData("OPC", "ServerName", string.IsNullOrWhiteSpace(this.comboBox_OpcServerList.Text) ? this.comboBox_OpcServerList.SelectedText : this.comboBox_OpcServerList.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("OPC服务端配置保存出现问题. " + ex.Message, "错误提示");
                return;
            }

            MessageBox.Show("OPC服务端配置保存成功", "提示");
        }

        private void Button_SaveItemInfo_Click(object sender, EventArgs e)
        {
            int result;
            try { result = this.Provider.ExecuteSql(this.GetSqlString()); }
            catch (Exception ex)
            {
                MessageBox.Show("OPC标签保存失败 " + ex.Message, "错误提示");
                return;
            }
            MessageBox.Show(result > 0 ? "保存成功" : "保存失败", "提示");
        }

        /// <summary>
        /// 保存雷达按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_SaveRadar_Click(object sender, EventArgs e)
        {
            if (this.dataGridView.Rows.Count == 0)
                return;

            List<Radar> list = new List<Radar>();
            foreach (DataGridViewRow row in this.dataGridView.Rows)
                if (row.Cells["Column_Changed"].Value.ToString().Equals("1"))
                    list.Add(DataGridViewUtil.ConvertDataGridViewRow2Obect<Radar>(row));

            bool result;
            try { result = this.dataService.SaveRadarItemNames(list); }
            catch (Exception ex)
            {
                string errorMessage = "信息保存时出现问题：" + ex.Message;
                MessageBox.Show(errorMessage, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (result)
            {
                MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DataSourceRefresh();
            }
            else
                MessageBox.Show("保存失败", "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void GetControlsByIndex(int index, out ComboBox comboBox_TopicName, out TextBox textBox_TopicName, out TextBox textBox_ItemName, out TextBox textBox_ItemValue, out Button button_GetValue)
        {
            comboBox_TopicName = null;
            textBox_TopicName = null;
            textBox_ItemName = null;
            textBox_ItemValue = null;
            button_GetValue = null;
            if (index == 1)
            {
                comboBox_TopicName = this.comboBox_TopicName_WalkingPos;
                textBox_TopicName = this.textBox_TopicName_WalkingPos;
                textBox_ItemName = this.textBox_ItemName_WalkingPos;
                textBox_ItemValue = this.textBox_ItemValue_WalkingPos;
                button_GetValue = this.button_GetValue_WalkingPos;
            }
            else if (index == 2)
            {
                comboBox_TopicName = this.comboBox_TopicName_PitchAngle;
                textBox_TopicName = this.textBox_TopicName_PitchAngle;
                textBox_ItemName = this.textBox_ItemName_PitchAngle;
                textBox_ItemValue = this.textBox_ItemValue_PitchAngle;
                button_GetValue = this.button_GetValue_PitchAngle;
            }
            else if (index == 3)
            {
                comboBox_TopicName = this.comboBox_TopicName_StretchLength;
                textBox_TopicName = this.textBox_TopicName_StretchLength;
                textBox_ItemName = this.textBox_ItemName_StretchLength;
                textBox_ItemValue = this.textBox_ItemValue_StretchLength;
                button_GetValue = this.button_GetValue_StretchLength;
            }
            else if (index == 4)
            {
                comboBox_TopicName = this.comboBox_TopicName_BucketPitch;
                textBox_TopicName = this.textBox_TopicName_BucketPitch;
                textBox_ItemName = this.textBox_ItemName_BucketPitch;
                textBox_ItemValue = this.textBox_ItemValue_BucketPitch;
                button_GetValue = this.button_GetValue_BucketPitch;
            }
            else if (index == 5)
            {
                comboBox_TopicName = this.comboBox_TopicName_BucketYaw;
                textBox_TopicName = this.textBox_TopicName_BucketYaw;
                textBox_ItemName = this.textBox_ItemName_BucketYaw;
                textBox_ItemValue = this.textBox_ItemValue_BucketYaw;
                button_GetValue = this.button_GetValue_BucketYaw;
            }
            else if (index == 6)
            {
                comboBox_TopicName = this.comboBox_TopicName_BeltSpeed;
                textBox_TopicName = this.textBox_TopicName_BeltSpeed;
                textBox_ItemName = this.textBox_ItemName_BeltSpeed;
                textBox_ItemValue = this.textBox_ItemValue_BeltSpeed;
                button_GetValue = this.button_GetValue_BeltSpeed;
            }
            else if (index == 7)
            {
                comboBox_TopicName = this.comboBox_TopicName_Stream;
                textBox_TopicName = this.textBox_TopicName_Stream;
                textBox_ItemName = this.textBox_ItemName_Stream;
                textBox_ItemValue = this.textBox_ItemValue_Stream;
                button_GetValue = this.button_GetValue_Stream;
            }
        }

        private string GetSqlString()
        {
            //string topicName = string.IsNullOrWhiteSpace(this.comboBox_TopicName_WalkingPos.Text) ? this.comboBox_TopicName_WalkingPos.SelectedText : this.comboBox_TopicName_WalkingPos.Text;
            DataTable dataTable = this.comboBox_TopicName_WalkingPos.DataSource == null ? null : (DataTable)this.comboBox_TopicName_WalkingPos.DataSource;
            string shiploaderId = (dataTable == null || dataTable.Rows.Count == 0) ? "0" : dataTable.Rows[this.comboBox_TopicName_WalkingPos.SelectedIndex]["shiploader_id"].ToString();
            string topicName_WalkingPos = this.textBox_TopicName_WalkingPos.Text.Trim();
            string topicName_PitchAngle = this.textBox_TopicName_PitchAngle.Text.Trim();
            string topicName_StretchLength = this.textBox_TopicName_StretchLength.Text.Trim();
            string topicName_BucketPitch = this.textBox_TopicName_BucketPitch.Text.Trim();
            string topicName_BucketYaw = this.textBox_TopicName_BucketYaw.Text.Trim();
            string topicName_BeltSpeed = this.textBox_TopicName_BeltSpeed.Text.Trim();
            string topicName_Stream = this.textBox_TopicName_Stream.Text.Trim();
            string itemName_WalkingPos = this.textBox_ItemName_WalkingPos.Text.Trim();
            string itemName_PitchAngle = this.textBox_ItemName_PitchAngle.Text.Trim();
            string itemName_StretchLength = this.textBox_ItemName_StretchLength.Text.Trim();
            string itemName_BucketPitch = this.textBox_ItemName_BucketPitch.Text.Trim();
            string itemName_BucketYaw = this.textBox_ItemName_BucketYaw.Text.Trim();
            string itemName_BeltSpeed = this.textBox_ItemName_BeltSpeed.Text.Trim();
            string itemName_Stream = this.textBox_ItemName_Stream.Text.Trim();
            string serverIp = this.textBox_OpcServerIp.Text;
            string serverName = string.IsNullOrWhiteSpace(this.comboBox_OpcServerList.Text) ? this.comboBox_OpcServerList.SelectedText : this.comboBox_OpcServerList.Text;
            string sqlString = string.Format("update t_base_shiploader_info set opcserver_ip = '{1}', opcserver_name = '{2}', topic_name_walking_pos = '{3}', item_name_walking_pos = '{4}', topic_name_pitch_angle = '{5}', item_name_pitch_angle = '{6}', topic_name_stretch_length = '{7}', item_name_stretch_length = '{8}', topic_name_bucket_pitch = '{9}', item_name_bucket_pitch = '{10}', topic_name_bucket_yaw = '{11}', item_name_bucket_yaw = '{12}', topic_name_belt_speed = '{13}', item_name_belt_speed = '{14}', topic_name_stream = '{15}', item_name_stream = '{16}' where shiploader_id = {0}", shiploaderId, serverIp, serverName, topicName_WalkingPos, itemName_WalkingPos, topicName_PitchAngle, itemName_PitchAngle, topicName_StretchLength, itemName_StretchLength, topicName_BucketPitch, itemName_BucketPitch, topicName_BucketYaw, itemName_BucketYaw, topicName_BeltSpeed, itemName_BeltSpeed, topicName_Stream, itemName_Stream);

            return sqlString;
        }

        private void ItemGetValue(int index)
        {
            if (index <= 0)
                return;

            ComboBox comboBox_TopicName;
            TextBox textBox_TopicName, textBox_ItemName, textBox_ItemValue;
            Button button_GetValue;
            this.GetControlsByIndex(index, out comboBox_TopicName, out textBox_TopicName, out textBox_ItemName, out textBox_ItemValue, out button_GetValue);
            if (textBox_ItemName == null || string.IsNullOrWhiteSpace(textBox_ItemName.Text))
                return;

            #region 添加Item
            try
            {
                if (this.KepServer.ServerState != (int)OPCServerState.OPCRunning)
                {
                    MessageBox.Show("OPC服务未连接");
                    return;
                }

                this.KepGroups.RemoveAll();
                this.KepGroup = this.KepGroups.Add("KepGroup");
                this.KepItems = this.KepGroup.OPCItems;

                string[] items = new string[] { textBox_ItemName.Text.Trim() };
                Array lErrors;
                int count = items.Length;
                string[] strItemIDs = new string[count + 1];
                int[] lClientHandlers = new int[count + 1];

                for (int i = 1; i <= count; i++)
                    lClientHandlers[i] = i;

                //string topic = string.IsNullOrWhiteSpace(comboBox_TopicName.SelectedText) ? comboBox_TopicName.Text : comboBox_TopicName.SelectedText;
                string topic = textBox_TopicName.Text;
                strItemIDs[0] = (string.IsNullOrWhiteSpace(topic) ? string.Empty : "[" + topic + "]") + items[0].ToString();
                for (int i = 1; i <= count; i++)
                    strItemIDs[i] = (string.IsNullOrWhiteSpace(topic) ? string.Empty : "[" + topic + "]") + items[i - 1].ToString();

                Array strit = strItemIDs.ToArray();
                Array lci = lClientHandlers.ToArray();
                this.KepItems.AddItems(items.Length, ref strit, ref lci, out lServerHandlers, out lErrors);
                this.KepGroup.IsSubscribed = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("为OPC Server{0}添加OPC Item时出错：{1}", this.KepServer == null ? " " : this.KepServer.ServerName, this.KepServer == null ? "OPC Server为空" : ex.Message));
                return;
                //throw;
            }
            #endregion

            #region 获取Item的值
            try
            {
                object quality, timestamp;

                Array itemValues = new string[this.KepGroup.OPCItems.Count];
                Array errors;

                if (this.KepGroup.OPCItems.Count > 0)
                    this.KepGroup.SyncRead(1, this.KepGroup.OPCItems.Count, ref lServerHandlers, out itemValues, out errors, out quality, out timestamp);

                if (itemValues.Length > 0)
                    textBox_ItemValue.Text = itemValues.GetValue(1).ToString();
                else
                    MessageBox.Show("未找到该OPC Item的值");
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("获取OPC Item的值时出现错误：{0}", ex.Message));
                //throw;
            }
            #endregion
        }

        private void Button_GetValue1_Click(object sender, EventArgs e)
        {
            this.ItemGetValue(1);
        }

        private void Button_GetValue2_Click(object sender, EventArgs e)
        {
            this.ItemGetValue(2);
        }

        private void Button_GetValue3_Click(object sender, EventArgs e)
        {
            this.ItemGetValue(3);
        }

        private void Button_GetValue4_Click(object sender, EventArgs e)
        {
            this.ItemGetValue(4);
        }

        private void Button_GetValue_BucketYaw_Click(object sender, EventArgs e)
        {
            this.ItemGetValue(5);
        }

        private void Button_GetValue_BeltSpeed_Click(object sender, EventArgs e)
        {
            this.ItemGetValue(6);
        }

        private void Button_GetValue_Stream_Click(object sender, EventArgs e)
        {
            this.ItemGetValue(7);
        }

        private void ComboBox_TopicName_WalkingPos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox_TopicName_WalkingPos.SelectedIndex < 0)
                return;
            DataTable table = this.comboBox_TopicName_WalkingPos.DataSource == null ? null : (DataTable)this.comboBox_TopicName_WalkingPos.DataSource;
            if (table == null || table.Rows.Count == 0)
                return;
            string topicName_WalkingPos, itemName_WalkingPos;
            DataRow row = table.Rows[this.comboBox_TopicName_WalkingPos.SelectedIndex];
            this.textBox_TopicName_WalkingPos.Text = !string.IsNullOrWhiteSpace((topicName_WalkingPos = row["topic_name_walking_pos"].ToString())) ? topicName_WalkingPos : this.comboBox_TopicName_WalkingPos.Text;
            this.textBox_ItemName_WalkingPos.Text = !string.IsNullOrWhiteSpace((itemName_WalkingPos = row["item_name_walking_pos"].ToString())) ? itemName_WalkingPos : this.textBox_ItemName_WalkingPos.Text;
        }

        private void ComboBox_TopicName_PitchAngle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox_TopicName_PitchAngle.SelectedIndex < 0)
                return;
            DataTable table = this.comboBox_TopicName_PitchAngle.DataSource == null ? null : (DataTable)this.comboBox_TopicName_PitchAngle.DataSource;
            if (table == null || table.Rows.Count == 0)
                return;
            string topicName_PitchAngle, itemName_PitchAngle;
            DataRow row = table.Rows[this.comboBox_TopicName_PitchAngle.SelectedIndex];
            this.textBox_TopicName_PitchAngle.Text = !string.IsNullOrWhiteSpace((topicName_PitchAngle = row["topic_name_pitch_angle"].ToString())) ? topicName_PitchAngle : this.comboBox_TopicName_PitchAngle.Text;
            this.textBox_ItemName_PitchAngle.Text = !string.IsNullOrWhiteSpace((itemName_PitchAngle = row["item_name_pitch_angle"].ToString())) ? itemName_PitchAngle : this.textBox_ItemName_PitchAngle.Text;
        }

        private void ComboBox_TopicName_StretchLength_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox_TopicName_StretchLength.SelectedIndex < 0)
                return;
            DataTable table = this.comboBox_TopicName_StretchLength.DataSource == null ? null : (DataTable)this.comboBox_TopicName_StretchLength.DataSource;
            if (table == null || table.Rows.Count == 0)
                return;
            string topicName_StretchLength, itemName_StretchLength;
            DataRow row = table.Rows[this.comboBox_TopicName_StretchLength.SelectedIndex];
            this.textBox_TopicName_StretchLength.Text = !string.IsNullOrWhiteSpace((topicName_StretchLength = row["topic_name_stretch_length"].ToString())) ? topicName_StretchLength : this.comboBox_TopicName_StretchLength.Text;
            this.textBox_ItemName_StretchLength.Text = !string.IsNullOrWhiteSpace((itemName_StretchLength = row["item_name_stretch_length"].ToString())) ? itemName_StretchLength : this.textBox_ItemName_StretchLength.Text;
        }

        private void ComboBox_TopicName_BucketPitch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox_TopicName_BucketPitch.SelectedIndex < 0)
                return;
            DataTable table = this.comboBox_TopicName_BucketPitch.DataSource == null ? null : (DataTable)this.comboBox_TopicName_BucketPitch.DataSource;
            if (table == null || table.Rows.Count == 0)
                return;
            string topicName_BucketPitch, itemName_BucketPitch;
            DataRow row = table.Rows[this.comboBox_TopicName_BucketPitch.SelectedIndex];
            this.textBox_TopicName_BucketPitch.Text = !string.IsNullOrWhiteSpace((topicName_BucketPitch = row["topic_name_bucket_pitch"].ToString())) ? topicName_BucketPitch : this.comboBox_TopicName_BucketPitch.Text;
            this.textBox_ItemName_BucketPitch.Text = !string.IsNullOrWhiteSpace((itemName_BucketPitch = row["item_name_bucket_pitch"].ToString())) ? itemName_BucketPitch : this.textBox_ItemName_BucketPitch.Text;
        }

        private void ComboBox_TopicName_BucketYaw_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox_TopicName_BucketYaw.SelectedIndex < 0)
                return;
            DataTable table = this.comboBox_TopicName_BucketYaw.DataSource == null ? null : (DataTable)this.comboBox_TopicName_BucketYaw.DataSource;
            if (table == null || table.Rows.Count == 0)
                return;
            string topicName_BucketYaw, itemName_BucketYaw;
            DataRow row = table.Rows[this.comboBox_TopicName_BucketYaw.SelectedIndex];
            this.textBox_TopicName_BucketYaw.Text = !string.IsNullOrWhiteSpace((topicName_BucketYaw = row["topic_name_bucket_yaw"].ToString())) ? topicName_BucketYaw : this.comboBox_TopicName_BucketYaw.Text;
            this.textBox_ItemName_BucketYaw.Text = !string.IsNullOrWhiteSpace((itemName_BucketYaw = row["item_name_bucket_yaw"].ToString())) ? itemName_BucketYaw : this.textBox_ItemName_BucketYaw.Text;
        }

        private void ComboBox_TopicName_BeltSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox_TopicName_BeltSpeed.SelectedIndex < 0)
                return;
            DataTable table = this.comboBox_TopicName_BeltSpeed.DataSource == null ? null : (DataTable)this.comboBox_TopicName_BeltSpeed.DataSource;
            if (table == null || table.Rows.Count == 0)
                return;
            string topicName_BeltSpeed, itemName_BeltSpeed;
            DataRow row = table.Rows[this.comboBox_TopicName_BeltSpeed.SelectedIndex];
            this.textBox_TopicName_BeltSpeed.Text = !string.IsNullOrWhiteSpace((topicName_BeltSpeed = row["topic_name_belt_speed"].ToString())) ? topicName_BeltSpeed : this.comboBox_TopicName_BeltSpeed.Text;
            this.textBox_ItemName_BeltSpeed.Text = !string.IsNullOrWhiteSpace((itemName_BeltSpeed = row["item_name_belt_speed"].ToString())) ? itemName_BeltSpeed : this.textBox_ItemName_BeltSpeed.Text;
        }

        private void ComboBox_TopicName_Stream_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox_TopicName_Stream.SelectedIndex < 0)
                return;
            DataTable table = this.comboBox_TopicName_Stream.DataSource == null ? null : (DataTable)this.comboBox_TopicName_Stream.DataSource;
            if (table == null || table.Rows.Count == 0)
                return;
            string topicName_Stream, itemName_Stream;
            DataRow row = table.Rows[this.comboBox_TopicName_Stream.SelectedIndex];
            this.textBox_TopicName_Stream.Text = !string.IsNullOrWhiteSpace((topicName_Stream = row["topic_name_stream"].ToString())) ? topicName_Stream : this.comboBox_TopicName_Stream.Text;
            this.textBox_ItemName_Stream.Text = !string.IsNullOrWhiteSpace((itemName_Stream = row["item_name_stream"].ToString())) ? itemName_Stream : this.textBox_ItemName_Stream.Text;
        }

        private void CheckBox_WriteItemValue_CheckedChanged(object sender, EventArgs e)
        {
            BaseConst.IniHelper.WriteData("OPC", "WriteItemValue", this.checkBox_WriteItemValue.Checked ? "1" : "0");
        }

        private void DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //取消事件，完成代码处理后再添加事件（代码中改变单元格的值会导致死循环）
                this.dataGridView.CellValueChanged -= new DataGridViewCellEventHandler(this.DataGridView_CellValueChanged);
                this.dataGridView.Rows[e.RowIndex].Cells["Column_Changed"].Value = 1;
                this.dataGridView.CellValueChanged += new DataGridViewCellEventHandler(this.DataGridView_CellValueChanged);
            }
        }
    }
}
