using ARS408.Core;
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
        /// 集群接收缓冲区（其它）（存放临时数据，直到接收完一组数据再放入正式数据）
        /// </summary>
        public List<ClusterGeneral> ListBuffer_Cluster_Other { get; set; }

        /// <summary>
        /// 集群正式数据
        /// </summary>
        public List<ClusterGeneral> ListTrigger_Cluster { get; set; }

        /// <summary>
        /// 目标接收缓冲区（存放临时数据，直到接收完一组数据再放入正式数据）
        /// </summary>
        public List<ObjectGeneral> ListBuffer_Object { get; set; }

        /// <summary>
        /// 目标接收缓冲区（其它）（存放临时数据，直到接收完一组数据再放入正式数据）
        /// </summary>
        public List<ObjectGeneral> ListBuffer_Object_Other { get; set; }

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
        public ClusterGeneral ClusterHighest { get; set; }

        public List<ObjectGeneral> ObjectsAtThreat { get; set; }
        public ObjectGeneral ObjectMostThreat { get; set; }
        public ObjectGeneral ObjectHighest { get; set; }
        public double ObstacleDistance
        {
            get { return this.CurrentSensorMode == SensorMode.Object ? (this.ObjectMostThreat != null ? this.ObjectMostThreat.DistanceToBorder : 0) : (this.ClusterMostThreat != null ? this.ClusterMostThreat.DistanceToBorder : 0); }
        }
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
            this.ListBuffer_Cluster_Other = new List<ClusterGeneral>();
            this.ListTrigger_Cluster = new List<ClusterGeneral>();
            this.ListBuffer_Object = new List<ObjectGeneral>();
            this.ListBuffer_Object_Other = new List<ObjectGeneral>();
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
                        this.RadarState.Base = message;
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

        /// <summary>
        /// 缓冲区数据长度
        /// </summary>
        public int ListBufferCount { get { return this.CurrentSensorMode == SensorMode.Cluster ? this.ListBuffer_Cluster.Count + this.ListBuffer_Cluster_Other.Count : this.ListBuffer_Object.Count + this.ListBuffer_Object_Other.Count; } }

        /// <summary>
        /// 正式数据长度
        /// </summary>
        public int ListTriggerCount { get { return this.CurrentSensorMode == SensorMode.Cluster ? this.ListTrigger_Cluster.Count : this.ListTrigger_Object.Count; } }

        /// <summary>
        /// 将一般信息压入缓冲区
        /// </summary>
        /// <typeparam name="T">集群或目标一般信息类</typeparam>
        /// <param name="general">一般信息对象</param>
        public void DataPush<T>(T general)
        {
            dynamic g = (dynamic)general;
            double x = g.ModiCoors.X, z = g.ModiCoors.Z, lon = g.DistLong, lat = g.DistLat;
            double rcs = g.RCS, below = 0 - BaseConst.BucketHeight - z;
            //TODO 溜桶下方物体检测：另外添加2个ListBuffer，分别对应cluster和object，添加溜桶下方2米之内、水平距离离雷达不超过1米的点，DataPushFinalize时一起压入ListTrigger

            bool is_shore = false;
            List<bool> flags = new List<bool>() { false, false, false, false, false, false };
            flags[2] = this.ParentForm != null && !rcs.Between(this.ParentForm.RcsMinimum, this.ParentForm.RcsMaximum); //RCS值是否不在范围内
            if (this.Radar != null)
            {
                is_shore = this.Radar != null && this.Radar.GroupType == RadarGroupType.Shore;
                //flags[0] = this.ListBufferCount >= this.BufferSize; //缓冲区是否已满
                flags[1] = BaseConst.BorderDistThres > 0 && g.DistanceToBorder > BaseConst.BorderDistThres; //距边界距离是否超出阈值
                flags[3] = this.Radar != null && this.Radar.GroupType == RadarGroupType.Bucket && z < (0 - BaseConst.BucketHeight); //溜桶雷达Z方向坐标是否低于大铲最低点
                flags[4] = this.Radar != null && this.Radar.GroupType == RadarGroupType.Arm && this.Radar.Name.Contains("陆"); //是否为大臂陆侧雷达
                flags[5] = below.Between(0, BaseConst.ObsBelowThres) && g.DistanceToBorder < BaseConst.ObsBelowFrontier; //障碍物在溜桶下方的距离在阈值(ObsBelowThres)内，且距边界距离不超过1米(ObsBelowFrontier)
            }
            dynamic list;
            //TODO 岸基雷达过滤方式：缓冲区未满，RCS值在范围内，有效区域为Z轴（竖直）方向±1米，X轴（南北）方向±5米
            if (is_shore)
            {
                if (!(flags[0] || flags[2]) && z.Between(-1, 1) && x.Between(-5, 5))
                    (list = general is ClusterGeneral ? (dynamic)this.ListBuffer_Cluster : (dynamic)this.ListBuffer_Object).Add(general);
            }
            else
            {
                //TODO 非岸基输出结果过滤条件1：缓冲区未满，距边界范围在阈值内，RCS值在范围内，溜桶雷达Z方向坐标不低于大铲最低点
                if (!(flags[0] || flags[1] || flags[2] || flags[3]))
                {
                    //TODO 大臂陆侧过滤条件：或者不是大臂陆侧雷达，或者横向坐标在5~10，纵向坐标在5~10之间
                    if (!flags[4] || (flags[4] && lat.Between(0, 5) && lon.Between(5, 10)))
                        (list = general is ClusterGeneral ? (dynamic)this.ListBuffer_Cluster : (dynamic)this.ListBuffer_Object).Add(general);
                }
                //TODO 溜桶下方障碍物过滤条件：缓冲区未满，RCS值在范围内，障碍物在溜桶下方的距离在阈值内、且距边界距离不超过1米
                else if (!(flags[0] || flags[2]) && flags[5])
                    (list = general is ClusterGeneral ? (dynamic)this.ListBuffer_Cluster_Other : (dynamic)this.ListBuffer_Object_Other).Add(general);
            }
        }

        public void DataQualityUpdate<T>(T q)
        {
            try
            {
                if (q is ClusterQuality)
                {
                    ClusterQuality quality = (dynamic)q;
                    //在普通缓冲区查找ID，找不到则在其它缓冲区查找，还找不到则跳出
                    List<ClusterGeneral> list = this.ListBuffer_Cluster;
                    ClusterGeneral general = list.Find(c => c.Id == quality.Id);
                    if (general == null)
                    {
                        list = this.ListBuffer_Cluster_Other;
                        general = list.Find(c => c.Id == quality.Id);
                    }
                    if (general == null)
                        return;

                    general.Pdh0 = quality.Pdh0;
                    general.InvalidState = quality.InvalidState;
                    general.AmbigState = quality.AmbigState;
                    //TODO 集群模式输出结果过滤条件2：（过滤器启用、过滤器不为空）不在集群/不确定性/有效性过滤器内
                    if (BaseConst.FilterEnabled && ((ClusterQuality.FalseAlarmFilter.Count > 0 && !ClusterQuality.FalseAlarmFilter.Contains(general.Pdh0)) ||
                        (ClusterQuality.AmbigStateFilter.Count > 0 && !ClusterQuality.AmbigStateFilter.Contains(general.AmbigState)) ||
                        (ClusterQuality.InvalidStateFilter.Count > 0 && !ClusterQuality.InvalidStateFilter.Contains(general.InvalidState))))
                        list.Remove(general);
                }
                else
                {
                    ObjectQuality quality = (dynamic)q;
                    ObjectGeneral general = this.ListBuffer_Object.Find(c => c.Id == quality.Id);
                    if (general == null)
                        general = this.ListBuffer_Object_Other.Find(c => c.Id == quality.Id);
                    general.MeasState = quality.MeasState;
                    general.ProbOfExist = quality.ProbOfExist;
                    //TODO 目标模式输出结果过滤条件2
                    //（假如过滤器启用）判断存在概率的可能最小值是否小于允许的最低值
                    if (BaseConst.FilterEnabled && general.ProbOfExistMinimum < this.ParentForm.ProbOfExistMinimum)
                        this.ListBuffer_Object.Remove(general);
                }
            }
            catch (Exception) { }
        }

        /// <summary>
        /// 结束一个阶段的数据压入，将缓冲区数据汇入正式数据
        /// </summary>
        public void DataPushFinalize()
        {
            bool is_cluster_mode = this.CurrentSensorMode == SensorMode.Cluster;
            if (is_cluster_mode)
            {
                //不要添加this.ListBuffer_Cluster与ListBuffer_Cluster_Other数量是否均为0的判断，否则当不存在目标时无法及时反映在数据上
                if (this.Radar != null/* && (this.ListBuffer_Cluster.Count != 0 || this.ListBuffer_Cluster_Other.Count != 0)*/)
                {
                    this.ListBuffer_Cluster.Sort((a, b) => a.DistanceToBorder.CompareTo(b.DistanceToBorder)); //根据距检测区的最短距离排序
                    this.ListBuffer_Cluster_Other.Sort((a, b) => a.ModiCoors.Z.CompareTo(b.ModiCoors.Z)); //根据Z轴坐标排序
                    this.ClustersAtThreat = this.ListBuffer_Cluster.Where(c => c.ThreatLevel > 0).ToList(); //找出威胁级数大于0的点，按距检测区的最短距离排序
                    this.ClusterMostThreat = this.ListBuffer_Cluster.Count() > 0 ? this.ListBuffer_Cluster.First() : null; //找出距离最小的点
                    this.ClusterHighest = this.ListBuffer_Cluster_Other.Count() > 0 ? this.ListBuffer_Cluster_Other.Last() : null; //找出Z轴坐标最大的点（最高的点）
                }
                this.ListTrigger_Cluster.Clear();
                this.ListTrigger_Cluster.AddRange(this.ListBuffer_Cluster);
                this.ListTrigger_Cluster.AddRange(this.ListBuffer_Cluster_Other);
                this.ListBuffer_Cluster.Clear();
                this.ListBuffer_Cluster_Other.Clear();
            }
            else
            {
                //不要添加this.ListBuffer_Cluster与ListBuffer_Cluster_Other数量是否均为0的判断，否则当不存在目标时无法及时反映在数据上
                if (this.Radar != null/* && (this.ListBuffer_Object.Count != 0 || this.ListBuffer_Object_Other.Count != 0)*/)
                {
                    this.ListBuffer_Object.Sort((a, b) => a.DistanceToBorder.CompareTo(b.DistanceToBorder)); //根据距检测区的最短距离排序
                    this.ListBuffer_Object_Other.Sort((a, b) => a.ModiCoors.Z.CompareTo(b.ModiCoors.Z)); //根据Z轴坐标排序
                    this.ObjectsAtThreat = this.ListBuffer_Object.Where(o => o.ThreatLevel > 0).ToList();
                    this.ObjectMostThreat = this.ListBuffer_Object.Count() > 0 ? this.ListBuffer_Object.First() : null;
                    this.ObjectHighest = this.ListBuffer_Object_Other.Count() > 0 ? this.ListBuffer_Object_Other.Last() : null; //找出Z轴坐标最大的点（最高的点）
                }
                this.ListTrigger_Object.Clear();
                this.ListTrigger_Object.AddRange(this.ListBuffer_Object);
                this.ListTrigger_Object.AddRange(this.ListBuffer_Object_Other);
                this.ListBuffer_Object.Clear();
                this.ListBuffer_Object_Other.Clear();
            }
            this.BufferSize = 0;
        }
    }
}
