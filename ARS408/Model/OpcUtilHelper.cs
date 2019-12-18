using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonLib.Clients;
using CommonLib.Function;
using OPCAutomation;
using ARS408.Core;

namespace ARS408.Model
{
    public class OpcUtilHelper
    {
        /// <summary>
        /// OPC重连线程
        /// </summary>
        public Thread Thread_Reconn { get; private set; }

        /// <summary>
        /// 读取OPC数据线程
        /// </summary>
        public Thread Thread_ReadItemValues { get; private set; }

        /// <summary>
        /// OPC标签的服务端句柄
        /// </summary>
        public Array ServerHandlers;

        /// <summary>
        /// OPC服务端
        /// </summary>
        public OPCServer OpcServer { get; set; }

        /// <summary>
        /// OPC组
        /// </summary>
        public OPCGroup OpcGroup { get; set; }

        /// <summary>
        /// 所有待添加OPC标签名称
        /// </summary>
        public string[] OpcItemNames { get; set; }

        /// <summary>
        /// 行走位置
        /// </summary>
        public double WalkingPosition { get; set; }

        /// <summary>
        /// 大臂俯仰角（°）
        /// </summary>
        public double PitchAngle { get; set; }

        /// <summary>
        /// 大臂伸缩长度
        /// </summary>
        public double StretchLength { get; set; }

        /// <summary>
        /// 溜桶俯仰
        /// </summary>
        public double BucketPitch { get; set; }

        /// <summary>
        /// 溜桶回转
        /// </summary>
        public double BucketYaw { get; set; }

        /// <summary>
        /// 皮带速度
        /// </summary>
        public double BeltSpeed { get; set; }

        /// <summary>
        /// 瞬时流量
        /// </summary>
        public double Stream { get; set; }

        /// <summary>
        /// 行走位置单位对应的系数（例如，毫米为1，厘米为10）
        /// </summary>
        public int UnitRatio { get; set; }

        /// <summary>
        /// 读标签值的间隔（毫秒）
        /// </summary>
        public int ReadInterval { get; set; }

        ///// <summary>
        ///// 是否写入报警标签
        ///// </summary>
        //public bool WriteItemValue { get; set; }

        /// <summary>
        /// 装船机信息
        /// </summary>
        public Shiploader Shiploader { get; set; }

        /// <summary>
        /// 最新错误信息
        /// </summary>
        public string LastErrorMessage { get; set; }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="opcServer">OPC服务端</param>
        public OpcUtilHelper(Shiploader shiploader)
        {
            this.Shiploader = shiploader;
            this.UnitRatio = int.Parse(BaseConst.IniHelper.ReadData("OPC", "PositionUnitRatio"));
            this.ReadInterval = int.Parse(BaseConst.IniHelper.ReadData("OPC", "ReadInterval"));
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        public void Init()
        {
            if (this.Shiploader == null)
                this.LastErrorMessage = "装船机信息为空，OPC服务无法初始化";
            else if (string.IsNullOrWhiteSpace(this.Shiploader.OpcServerName))
                this.LastErrorMessage = "OPC服务端的名称为空";

            if (!string.IsNullOrWhiteSpace(this.LastErrorMessage))
                return;

            try
            {
                if (this.OpcServer == null)
                    this.OpcServer = new OPCServer();
                this.OpcServer.Connect(this.Shiploader.OpcServerName, this.Shiploader.OpcServerIp);
                this.AddGroupItems();
            }
            catch (Exception ex) { this.LastErrorMessage = "OPC connection failed. " + ex.Message; }
            
            this.ThreadControl(true);
        }

        /// <summary>
        /// 控制线程的初始或停止
        /// </summary>
        /// <param name="flag">true启动，false停止</param>
        private void ThreadControl(bool flag)
        {
            if (flag)
            {
                if (this.Thread_Reconn == null)
                    this.Thread_Reconn = new Thread(new ThreadStart(this.Reconn_Recursive)) { IsBackground = true };
                if (this.Thread_ReadItemValues == null)
                    this.Thread_ReadItemValues = new Thread(new ThreadStart(this.ReadItemValues_Recursive)) { IsBackground = true };

                this.Thread_Reconn.Start();
                this.Thread_ReadItemValues.Start();
                return;
            }

            if (this.Thread_ReadItemValues != null)
                this.Thread_ReadItemValues.Abort();
            if (this.Thread_Reconn != null)
                this.Thread_Reconn.Abort();
        }

        /// <summary>
        /// 结束任务
        /// </summary>
        public void Epilogue()
        {
            this.ThreadControl(false);
            this.OpcServer.Disconnect();
        }

        private string GetFullItemName(string topicName, string itemName)
        {
            return (string.IsNullOrWhiteSpace(topicName) ? string.Empty : "[" + topicName + "]") + itemName;
        }

        /// <summary>
        /// 添加OPC组与标签
        /// </summary>
        /// <returns></returns>
        public bool AddGroupItems()
        {
            bool result = false;
            try
            {
                this.OpcServer.OPCGroups.RemoveAll();
                this.OpcGroup = this.OpcServer.OPCGroups.Add("Group_Shiploader_" + this.Shiploader.Id);

                List<string> list = new List<string>
                {
                    this.GetFullItemName(this.Shiploader.TopicNameWalkingPos, this.Shiploader.ItemNameWalkingPos),
                    this.GetFullItemName(this.Shiploader.TopicNamePitchAngle, this.Shiploader.ItemNamePitchAngle),
                    this.GetFullItemName(this.Shiploader.TopicNameStretchLength, this.Shiploader.ItemNameStretchLength),
                    this.GetFullItemName(this.Shiploader.TopicNameBucketPitch, this.Shiploader.ItemNameBucketPitch),
                    this.GetFullItemName(this.Shiploader.TopicNameBucketYaw, this.Shiploader.ItemNameBucketYaw),
                    this.GetFullItemName(this.Shiploader.TopicNameBeltSpeed, this.Shiploader.ItemNameBeltSpeed),
                    this.GetFullItemName(this.Shiploader.TopicNameStream, this.Shiploader.ItemNameStream)
                };

                this.OpcItemNames = list.ToArray();

                int count = this.OpcItemNames.Length;
                string[] itemIds = new string[count + 1];
                int[] clientHandlers = new int[count + 1];

                for (int i = 1; i <= count; i++)
                {
                    clientHandlers[i] = i;
                    itemIds[i] = this.OpcItemNames[i - 1];
                }

                Array errors, strit = itemIds.ToArray(), lci = clientHandlers.ToArray();
                this.OpcGroup.OPCItems.AddItems(count, ref strit, ref lci, out ServerHandlers, out errors);
                this.OpcGroup.IsSubscribed = true;
                this.OpcGroup.UpdateRate = 30;
            }
            catch (Exception e)
            {
                this.LastErrorMessage = "添加OPC组与标签时出现问题. " + e.Message;
                FileClient.WriteExceptionInfo(e, this.LastErrorMessage, false);
                return result;
            }
            return !result;
        }

        /// <summary>
        /// 循环连接OPC
        /// </summary>
        private void Reconn_Recursive()
        {
            while (true)
            {
                Thread.Sleep(5000);
                this.Reconn();
            }
        }

        /// <summary>
        /// 判断是否重新连接OPC
        /// </summary>
        private void Reconn()
        {
            try
            {
                if (this.OpcServer.ServerState != (int)OPCServerState.OPCRunning)
                    this.ReconnDetail();
            }
            //假如捕捉到COMException
            catch (COMException)
            {
                try { this.ReconnDetail(); }
                catch { }
            }
            catch (Exception) { }
        }

        /// <summary>
        /// 重新连接OPC
        /// </summary>
        private void ReconnDetail()
        {
            this.OpcServer = new OPCServer();
            string info = string.Format("Opc server {0} at {1} has failed, trying reconnecting", this.Shiploader.OpcServerName, this.Shiploader.OpcServerIp);
            FileClient.WriteLogsToFile(new string[] { info }, "opc", "opc_server");
            try
            {
                this.OpcServer.Connect(this.Shiploader.OpcServerName, this.Shiploader.OpcServerIp);
                this.AddGroupItems();
                info = string.Format("Reconnecting opc server {0} at {1} succeeded.", this.Shiploader.OpcServerName, this.Shiploader.OpcServerIp);
            }
            catch (Exception e)
            {
                info = string.Format("Reconnecting opc server {0} at {1} failed. {2}", this.Shiploader.OpcServerName, this.Shiploader.OpcServerIp, e.Message);
                //throw;
            }
            FileClient.WriteLogsToFile(new string[] { info }, "opc", "opc_server");
        }

        /// <summary>
        /// 循环读取OPC项的值
        /// </summary>
        private void ReadItemValues_Recursive()
        {
            if (this.ReadInterval <= 0)
                return;

            while (true)
            {
                Thread.Sleep(this.ReadInterval);
                try
                {
                    this.ReadItemValues();
                    try { this.UnitRatio = int.Parse(BaseConst.IniHelper.ReadData("OPC", "PositionUnitRatio")); }
                    catch (Exception) { }
                }
                catch (Exception e) { FileClient.WriteExceptionInfo(e, "循环更新OPC项的值时出现问题", true); }
            }
        }

        /// <summary>
        /// 读取OPC项的值
        /// </summary>
        private void ReadItemValues()
        {
            try
            {
                //假如未添加任何OPC项
                if (this.OpcGroup.OPCItems.Count <= 0)
                    return;

                object quality, timestamp;

                Array itemValues = new string[this.OpcGroup.OPCItems.Count];
                Array errors;
                this.OpcGroup.SyncRead(2, this.OpcGroup.OPCItems.Count, ref this.ServerHandlers, out itemValues, out errors, out quality, out timestamp);

                if (itemValues.Length == 0)
                {
                    string info = string.Format("未找到任何OPC项的值. shiploader_id: {0}, ip_address: {1}", this.Shiploader.Id, this.Shiploader.OpcServerIp);
                    FileClient.WriteFailureInfo(info);
                    //this.ArmPosition = 0xFFFFFFFF;
                    return;
                }
                this.WalkingPosition = double.Parse(itemValues.GetValue(1).ToString());
                this.PitchAngle = double.Parse(itemValues.GetValue(2).ToString());
                this.StretchLength = double.Parse(itemValues.GetValue(3).ToString());
                this.BucketPitch = double.Parse(itemValues.GetValue(4).ToString());
                this.BucketYaw = double.Parse(itemValues.GetValue(5).ToString());
                this.BeltSpeed = double.Parse(itemValues.GetValue(6).ToString());
                this.Stream = double.Parse(itemValues.GetValue(7).ToString());
            }
            catch (Exception ex)
            {
                string info = string.Format("获取OPC项的值时出现问题. {0}. shiploader_id: {1}, ip_address: {2}", ex.Message, this.Shiploader.Id, this.Shiploader.OpcServerIp);
                this.LastErrorMessage = info;
                FileClient.WriteExceptionInfo(ex, info, false);
            }
        }
    }
}
