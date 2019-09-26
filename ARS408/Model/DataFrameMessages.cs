﻿using ARS408.Core;
using ARS408.Forms;
using CommonLib.Function;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARS408.Model
{
    /// <summary>
    /// 帧消息处理类
    /// </summary>
    public class DataFrameMessages
    {
        private readonly Regex pattern = new Regex(BaseConst.Pattern_SensorMessage, RegexOptions.Compiled);

        #region 属性
        /// <summary>
        /// 父窗体
        /// </summary>
        public FormDisplay ParentForm { get; set; }

        /// <summary>
        /// 处理后的信息
        /// </summary>
        public string[] Messages { get; set; }

        /// <summary>
        /// 雷达状态信息
        /// </summary>
        public RadarState RadarState { get; set; }

        /// <summary>
        /// 当前检测模式
        /// </summary>
        public SensorMode CurrentSensorMode { get; set; }

        /// <summary>
        /// 接收缓冲区大小（达到此大小则放入正式数据）
        /// </summary>
        public int BufferSize { get; set; }

        /// <summary>
        /// 集群接收缓冲区（存放临时数据，直到接收完一组数据再放入正式数据）
        /// </summary>
        public List<ClusterGeneral> ListBuffer_Cluster { get; set; }

        /// <summary>
        /// 集群正式数据
        /// </summary>
        public List<ClusterGeneral> ListTrigger_Cluster { get; set; }

        /// <summary>
        /// 目标接收缓冲区（存放临时数据，直到接收完一组数据再放入正式数据）
        /// </summary>
        public List<ObjectGeneral> ListBuffer_Object { get; set; }

        /// <summary>
        /// 目标正式数据
        /// </summary>
        public List<ObjectGeneral> ListTrigger_Object { get; set; }

        /// <summary>
        /// 雷达信息对象
        /// </summary>
        public Radar Radar { get; set; }

        public List<ClusterGeneral> ClustersAtThreat { get; set; }
        public ClusterGeneral ClusterMostThreat { get; set; }

        public List<ObjectGeneral> ObjectsAtThreat { get; set; }
        public ObjectGeneral ObjectMostThreat { get; set; }
        public char[] CurrentThreatLevels
        {
            get
            {
                char[] array = new char[] { '0', '0' };
                if (this.CurrentSensorMode == SensorMode.Cluster && this.ClusterMostThreat != null)
                    array = this.ClusterMostThreat.ThreatLevelBinary.ToCharArray();
                else if (this.CurrentSensorMode == SensorMode.Object && this.ObjectMostThreat != null)
                    array = this.ObjectMostThreat.ThreatLevelBinary.ToCharArray();
                return array;
            }
        }
            //return this.ObjectMostThreat == null ? new char[] { '0', '0' } : this.ObjectMostThreat.ThreatLevelBinary.ToCharArray(); } }
        #endregion

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="form">父窗体</param>
        public DataFrameMessages(FormDisplay form) : this(form, null) { }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="form">父窗体</param>
        /// <param name="radar">雷达信息对象</param>
        public DataFrameMessages(FormDisplay form, Radar radar)
        {
            this.ParentForm = form;
            this.Radar = radar;
            this.RadarState = new RadarState();
            this.CurrentSensorMode = SensorMode.Cluster;
            this.ListBuffer_Cluster = new List<ClusterGeneral>();
            this.ListTrigger_Cluster = new List<ClusterGeneral>();
            this.ListBuffer_Object = new List<ObjectGeneral>();
            this.ListTrigger_Object = new List<ObjectGeneral>();
            this.ThreadCheck = new Thread(new ThreadStart(this.CheckIfRadarsWorking)) { IsBackground = true };
            this.ThreadCheck.Start();
        }

        /// <summary>
        /// 默认构造器
        /// </summary>
        public DataFrameMessages() : this(null) { }

        private int timer = 0;
        public int Timer
        {
            get { return this.timer; }
            set
            {
                this.timer = value;
                this.RadarState.Working = this.timer < 5 ? 1 : 0;
                //this.RadarState.Working = 1 - (this.timer / 5); //小于5时为1，大于等于5时为0
            }
        }

        public Thread ThreadCheck;
        public void CheckIfRadarsWorking()
        {
            int interval = 1;
            while (true)
            {
                Thread.Sleep(interval * 1000);
                this.Timer += interval;
            }
        }

        /// <summary>
        /// 处理输入信息
        /// </summary>
        /// <param name="input">输入的信息</param>
        public void Filter(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return;

            #region 方法1 旧正则提取方法（注释）
            //this.Messages = RegexMatcher.FindMatches(input, BaseConst.Pattern_SensorMessage);
            //if (this.Messages == null || this.Messages.Length == 0)
            //    return;
            //foreach (var m in this.Messages)
            //{
            //    BaseMessage message = new BaseMessage(m);
            //    dynamic obj;
            //    switch (message.MessageId)
            //    {
            //        case SensorMessageId_0.Cluster_0_Status_Out:
            //            obj = new ClusterStatus(message);
            //            this.DataPushFinalize();
            //            this.BufferSize = obj.NofClustersNear + obj.NofClustersFar;
            //            break;
            //        case SensorMessageId_0.Cluster_1_General_Out:
            //            obj = new ClusterGeneral(message);
            //            this.DataPush(obj);
            //            //this.List_ClusterGeneral.Add(obj);
            //            break;
            //        case SensorMessageId_0.Cluster_2_Quality_Out:
            //            obj = new ClusterQuality(message);
            //            break;
            //        default:
            //            continue;
            //    }
            //    //this.List_SensorInfos.Add(obj);
            //}
            #endregion

            #region 方法2 逐字符分解（注释）
            //this.Messages = this.GatherMessages(input); //方法2 逐字符分解
            #endregion

            #region 方法3 新正则提取
            MatchCollection col = pattern.Matches(input);
            if (col == null || col.Count == 0)
                return;
            foreach (Match match in col)
            {
                BaseMessage message = new BaseMessage(match.Value);
                dynamic obj;
                switch (message.MessageId)
                {
                    case SensorMessageId_0.RadarState_Out:
                        //obj = new RadarState(message);
                        this.RadarState.Base = message;
                        //this.Timer = 0;
                        //this.RadarState.Working = true;
                        break;
                    case SensorMessageId_0.Cluster_0_Status_Out:
                        obj = new ClusterStatus(message);
                        this.DataPushFinalize();
                        this.CurrentSensorMode = SensorMode.Cluster;
                        this.BufferSize = obj.NofClustersNear + obj.NofClustersFar;
                        break;
                    case SensorMessageId_0.Cluster_1_General_Out:
                        obj = new ClusterGeneral(message, this.Radar);
                        this.DataPush<ClusterGeneral>(obj);
                        break;
                    case SensorMessageId_0.Cluster_2_Quality_Out:
                        obj = new ClusterQuality(message);
                        this.DataQualityUpdate<ClusterQuality>(obj);
                        break;
                    case SensorMessageId_0.Obj_0_Status_Out:
                        obj = new ObjectStatus(message);
                        this.DataPushFinalize();
                        this.CurrentSensorMode = SensorMode.Object;
                        this.BufferSize = obj.NofObjects;
                        break;
                    case SensorMessageId_0.Obj_1_General_Out:
                        obj = new ObjectGeneral(message, this.Radar);
                        this.DataPush<ObjectGeneral>(obj);
                        break;
                    case SensorMessageId_0.Obj_2_Quality_Out:
                        obj = new ObjectQuality(message);
                        this.DataQualityUpdate<ObjectQuality>(obj);
                        break;
                    default:
                        continue;
                }
            }
            #endregion
        }

        public int ListBufferCount { get { return this.CurrentSensorMode == SensorMode.Cluster ? this.ListBuffer_Cluster.Count : this.ListBuffer_Object.Count; } }
        public int ListTriggerCount { get { return this.CurrentSensorMode == SensorMode.Cluster ? this.ListTrigger_Cluster.Count : this.ListTrigger_Object.Count; } }


        /// <summary>
        /// 将一般信息压入缓冲区
        /// </summary>
        /// <typeparam name="T">集群或目标一般信息类</typeparam>
        /// <param name="general">一般信息对象</param>
        public void DataPush<T>(T general)
        {
            dynamic g = (dynamic)general;
            //假如列表元素饱和
            //或距边界范围超出阈值
            //或RCS值不在范围内
            //则忽略
            if (this.ListBufferCount >= this.BufferSize || (BaseConst.BorderDistThres > 0 && g.DistanceToBorder > BaseConst.BorderDistThres) || (this.ParentForm != null && (g.RCS < this.ParentForm.RcsMinimum || g.RCS > this.ParentForm.RcsMaximum)))
                return;
            dynamic list = general is ClusterGeneral ? (dynamic)this.ListBuffer_Cluster : (dynamic)this.ListBuffer_Object;
            list.Add(general);
        }

        public void DataQualityUpdate<T>(T q)
        {
            try
            {
                if (q is ClusterQuality)
                {
                    ClusterQuality quality = (dynamic)q;
                    ClusterGeneral general = this.ListBuffer_Cluster.Find(c => c.Id == quality.Id);
                    general.Pdh0 = quality.Pdh0;
                    general.InvalidState = quality.InvalidState;
                    general.AmbigState = quality.AmbigState;
                }
                else
                {
                    ObjectQuality quality = (dynamic)q;
                    ObjectGeneral general = this.ListBuffer_Object.Find(c => c.Id == quality.Id);
                    general.MeasState = quality.MeasState;
                    general.ProbOfExist = quality.ProbOfExist;
                }
            }
            catch (Exception) { }
        }

        /// <summary>
        /// 结束一个阶段的数据压入，将缓冲区数据汇入正式数据
        /// </summary>
        public void DataPushFinalize()
        {
            if (this.BufferSize == 0 || this.ListBufferCount == 0)
                return;

            bool is_cluster_mode = this.CurrentSensorMode == SensorMode.Cluster;
            //dynamic buffer = is_cluster_mode ? (dynamic)this.ListBuffer_Cluster : (dynamic)this.ListBuffer_Object;
            //dynamic comparison = is_cluster_mode ? ClusterGeneral.Comparison : ObjectGeneral.Comparison;
            //buffer.Sort(comparison);
            if (is_cluster_mode)
            {
                this.ListBuffer_Cluster.Sort((a, b) => a.DistanceToBorder.CompareTo(b.DistanceToBorder)); //根据距检测区的最短距离排序
                this.ClustersAtThreat = this.ListBuffer_Cluster.Where(c => c.ThreatLevel > 0).ToList(); //找出威胁级数大于0的点，按距检测区的最短距离排序
                this.ClusterMostThreat = this.ListBuffer_Cluster.Count() > 0 ? this.ListBuffer_Cluster.First() : null; //找出距离最小的点
                this.ListTrigger_Cluster.Clear();
                this.ListTrigger_Cluster.AddRange(this.ListBuffer_Cluster);
                this.ListBuffer_Cluster.Clear();
            }
            else
            {
                this.ListBuffer_Object.Sort((a, b) => a.DistanceToBorder.CompareTo(b.DistanceToBorder)); //根据距检测区的最短距离排序
                this.ObjectsAtThreat = this.ListBuffer_Object.Where(o => o.ThreatLevel > 0).ToList();
                this.ObjectMostThreat = this.ListBuffer_Object.Count() > 0 ? this.ListBuffer_Object.First() : null;
                this.ListTrigger_Object.Clear();
                this.ListTrigger_Object.AddRange(this.ListBuffer_Object);
                this.ListBuffer_Object.Clear();
            }
            //if (is_cluster_mode)
            //{
            //    //trigger = (dynamic)this.ListTrigger_Cluster;
            //    //IEnumerable<ClusterGeneral> list = this.ListBuffer_Cluster.OrderBy(c => c.DistanceToBorder);
            //    //buffer = (dynamic)list;
            //    //this.ClustersAtThreat = this.ListBuffer_Cluster.Where(c => c.ThreatLevel > 0).ToList(); //找出威胁级数大于0的点，按距检测区的最短距离排序
            //    //this.ClusterMostThreat = list.Count() > 0 ? list.First() : null; //找出距离最小的点
            //}
            //else
            //{
            //    //trigger = (dynamic)this.ListTrigger_Object;
            //    //IEnumerable<ObjectGeneral> list = this.ListBuffer_Object.OrderBy(o => o.DistanceToBorder);
            //    //buffer = (dynamic)list;
            //    //this.ObjectsAtThreat = this.ListBuffer_Object.Where(o => o.ThreatLevel > 0).ToList();
            //    //this.ObjectMostThreat = list.Count() > 0 ? list.First() : null;
            //}
            //dynamic trigger = is_cluster_mode ? (dynamic)this.ListTrigger_Cluster : (dynamic)this.ListTrigger_Object,
            ////buffer按距检测区的最短距离排序
            //buffer = is_cluster_mode ? (dynamic)this.ListBuffer_Cluster.OrderBy(c => c.DistanceToBorder) : (dynamic)this.ListBuffer_Object.OrderBy(o => o.DistanceToBorder);
            //trigger.Clear();
            //trigger.AddRange(buffer);
            //if (is_cluster_mode)
            //    this.ListBuffer_Cluster.Clear();
            //else
            //    this.ListBuffer_Object.Clear();
            //buffer.Clear();
            this.BufferSize = 0;
        }
    }

    /// <summary>
    /// 传感器模式
    /// </summary>
    public enum SensorMode
    {
        /// <summary>
        /// 集群模式
        /// </summary>
        Cluster = 0,

        /// <summary>
        /// 目标模式
        /// </summary>
        Object = 1
    }
}