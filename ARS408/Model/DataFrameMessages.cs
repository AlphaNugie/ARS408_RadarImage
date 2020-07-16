using ARS408.Core;
using ARS408.Forms;
using CommonLib.Extensions;
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
        #region 私有成员
        private readonly Regex pattern = new Regex(BaseConst.Pattern_SensorMessage, RegexOptions.Compiled);
        private ClusterGeneral cluster_most_threat;
        private ObjectGeneral object_most_threat;
        //private double obs_dist, obs_dist_former;
        private int _count = 0, limit_factor = 1;
        private double _current, _new, _assumed, _diff, _diff1;
        //private readonly double inner = -2.1, outer = 1.3; //黄标线内侧外侧距离
        #endregion

        #region 属性
        /// <summary>
        /// 父窗体
        /// </summary>
        public FormDisplay ParentForm { get; set; }

        /// <summary>
        /// 雷达信息对象
        /// </summary>
        public Radar Radar { get; set; }

        /// <summary>
        /// 是否是岸基雷达
        /// </summary>
        public bool IsShore { get; private set; }

        /// <summary>
        /// 雷达目标点的过滤条件
        /// </summary>
        private List<bool> Flags { get; set; }

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
        /// 接收目标实际数量
        /// </summary>
        public int ActualSize { get; set; }

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
        /// 最具有威胁的集群点
        /// </summary>
        public ClusterGeneral ClusterMostThreat
        {
            get { return this.cluster_most_threat; }
            set
            {
                this.cluster_most_threat = value;
                this.CurrentDistance = this.cluster_most_threat != null ? Math.Round(this.cluster_most_threat.DistanceToBorder, 4) : 0;
            }
        }

        /// <summary>
        /// 下方离溜桶最近的集群点
        /// </summary>
        public ClusterGeneral ClusterHighest { get; set; }

        /// <summary>
        /// 最具有威胁的目标点
        /// </summary>
        public ObjectGeneral ObjectMostThreat
        {
            get { return this.object_most_threat; }
            set
            {
                this.object_most_threat = value;
                this.CurrentDistance = this.object_most_threat != null ? Math.Round(this.object_most_threat.DistanceToBorder, 4) : 0;
            }
        }

        /// <summary>
        /// 下方离溜桶最近的目标点
        /// </summary>
        public ObjectGeneral ObjectHighest { get; set; }

        /// <summary>
        /// 当前障碍物距离，保留4位小数
        /// </summary>
        public double CurrentDistance
        {
            get { return this._current; }
            set
            {
                this.IterateDistance(value);
                this.ThreatLevel = BaseFunc.GetThreatLevelByValue(this._current, this.Radar != null ? this.Radar.GroupType : RadarGroupType.Bucket);
            }
        }

        private int threat_level = 0;
        /// <summary>
        /// 报警级数
        /// </summary>
        public int ThreatLevel
        {
            get { return this.threat_level; }
            set
            {
                this.threat_level = value;
                this.ThreatLevelBinary = Convert.ToString(this.threat_level.Between(1, 2) ? 3 - this.threat_level : this.threat_level, 2).PadLeft(2, '0');
                if (this.Radar != null)
                {
                    this.Radar.CurrentDistance = this._current;
                    this.Radar.ThreatLevelBinary = this.ThreatLevelBinary;
                }
            }
        }

        public string ThreatLevelBinary { get; set; }
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
            this.Flags = new List<bool>() { false, false, false, false, false, false, false, true, true };
            this.RadarState = new RadarState();
            if (this.Radar != null)
            {
                this.Radar.RadarState = this.RadarState;
                this.limit_factor = this.Radar.GroupType == RadarGroupType.Feet ? 10 : 1;
            }
            this.CurrentSensorMode = SensorMode.Cluster;
            this.ThreatLevelBinary = "00";
            this.ListBuffer_Cluster = new List<ClusterGeneral>();
            this.ListBuffer_Cluster_Other = new List<ClusterGeneral>();
            this.ListTrigger_Cluster = new List<ClusterGeneral>();
            this.ListBuffer_Object = new List<ObjectGeneral>();
            this.ListBuffer_Object_Other = new List<ObjectGeneral>();
            this.ListTrigger_Object = new List<ObjectGeneral>();
            //this.ThreatLevelArray = new char[] { '0', '0' };
            this.ThreadCheck = new Thread(new ThreadStart(this.CheckIfRadarsWorking)) { IsBackground = true };

            if (this.Radar != null)
            {
                this.IsShore = this.Radar.GroupType == RadarGroupType.Shore; //是否为岸基雷达
                this.Flags[4] = this.Radar.GroupType == RadarGroupType.Arm && this.Radar.Name.Contains("陆"); //是否为大臂陆侧雷达
                this.Flags[6] = this.Radar.GroupType == RadarGroupType.Feet; //是否为门腿雷达
                ////根据雷达所在位置给黄标线距离加上符号，用于门腿雷达坐标过滤黄标线之外的点
                //string name = this.Radar.Name;
                //int r = (name.Contains("海") && name.Contains("南")) || (name.Contains("陆") && name.Contains("北")) ? 1 : -1;
                //this.outer *= r;
                //this.inner *= r;
            }
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
                        this.ActualSize++;
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
                        this.ActualSize++;
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
            double x = g.ModiCoors.X, y = g.ModiCoors.Y, z = g.ModiCoors.Z, lon = g.DistLong, lat = g.DistLat;
            double rcs = g.RCS, below = 0 - BaseConst.BucketHeight - z;
            dynamic list;

            #region 目标点的过滤
            Flags[2] = this.ParentForm != null && !rcs.Between(this.ParentForm.RcsMinimum, this.ParentForm.RcsMaximum); //RCS值是否不在范围内
            if (this.Radar != null)
            {
                Flags[1] = (this.Radar.GroupType == RadarGroupType.Bucket && g.DistanceToBorder < 0) || (BaseConst.BorderDistThres > 0 && g.DistanceToBorder > BaseConst.BorderDistThres); //距边界距离是否小于0（溜桶雷达）或超出阈值
                Flags[3] = this.Radar.GroupType == RadarGroupType.Bucket && !z.Between(0 - BaseConst.BucketHeight, BaseConst.BucketUpLimit); //溜桶雷达Z方向坐标是否低于大铲最低点，或高于检测高度上限
                Flags[5] = below.Between(0, BaseConst.ObsBelowThres) && g.DistanceToBorder < BaseConst.ObsBelowFrontier; //障碍物在溜桶下方的距离在阈值(ObsBelowThres)内，且距边界距离不超过1米(ObsBelowFrontier)
                Flags[7] = !this.Radar.RadarCoorsLimited || (lon.Between(this.Radar.RadarxMin, this.Radar.RadarxMax) && lat.Between(this.Radar.RadaryMin, this.Radar.RadaryMax)); //雷达坐标系坐标的限制
                Flags[8] = !this.Radar.ClaimerCoorsLimited || (x.Between(this.Radar.ClaimerxMin, this.Radar.ClaimerxMax) && y.Between(this.Radar.ClaimeryMin, this.Radar.ClaimeryMax) && z.Between(this.Radar.ClaimerzMin, this.Radar.ClaimerzMax)); //单机坐标系坐标的限制
            }
            //TODO (所有雷达)过滤条件Lv1：RCS值、坐标在限定范围内 / RCS值在范围内
            bool save2list = !Flags[2] && Flags[7] && Flags[8], save2other = false;
            //非岸基雷达额外判断
            if (!this.IsShore)
            {
                //TODO (非溜桶下方)过滤条件Lv2：距边界范围在阈值内，溜桶雷达Z方向坐标不低于大铲最低点
                save2list = save2list && !(Flags[1] || Flags[3]);
                //TODO (溜桶下方)过滤条件Lv2：RCS值在范围内，障碍物在溜桶下方的距离在阈值内、且距边界距离不超过1米
                if (!save2list)
                    save2other = !Flags[2] && Flags[5];
            }
            #region 旧判断逻辑
            //if (this.IsShore)
            //    save2list = !Flags[2] && z.Between(-1, 1) && x.Between(-5, 5);
            //else
            //{
            //    //非岸基输出结果过滤条件1：距边界范围在阈值内，RCS值在范围内，溜桶雷达Z方向坐标不低于大铲最低点
            //    if (!(Flags[1] || Flags[2] || Flags[3]))
            //    {
            //        //非大臂陆侧
            //        if (!Flags[4])
            //            //非门腿雷达直接返回true，门腿雷达判断：横向距离在黄标线范围内,高度高于地面0.1米以上
            //            save2list = !Flags[6] ? true : lat.Between(this.outer, this.inner) && z > BaseConst.FeetFilterHeight - this.Radar.RadarHeight;
            //        else
            //            //大臂陆侧过滤条件：横向坐标在5~10，纵向坐标在5~10之间
            //            save2list = lat.Between(0, 5) && lon.Between(5, 10);
            //    }
            //    //溜桶下方障碍物过滤条件：RCS值在范围内，障碍物在溜桶下方的距离在阈值内、且距边界距离不超过1米
            //    else
            //        save2other = !(Flags[2]) && Flags[5];
            //}
            #endregion
            #endregion

            //TODO 溜桶下方物体检测：另外添加2个ListBuffer，分别对应cluster和object，添加点，DataPushFinalize时一起压入ListTrigger
            if (save2list)
                (list = general is ClusterGeneral ? (dynamic)this.ListBuffer_Cluster : (dynamic)this.ListBuffer_Object).Add(general);
            else if (save2other)
                (list = general is ClusterGeneral ? (dynamic)this.ListBuffer_Cluster_Other : (dynamic)this.ListBuffer_Object_Other).Add(general);
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
                    if (BaseConst.ClusterFilterEnabled && ((ClusterQuality.FalseAlarmFilter.Count > 0 && !ClusterQuality.FalseAlarmFilter.Contains(general.Pdh0)) ||
                        (ClusterQuality.AmbigStateFilter.Count > 0 && !ClusterQuality.AmbigStateFilter.Contains(general.AmbigState)) ||
                        (ClusterQuality.InvalidStateFilter.Count > 0 && !ClusterQuality.InvalidStateFilter.Contains(general.InvalidState))))
                        list.Remove(general);
                }
                else
                {
                    ObjectQuality quality = (dynamic)q;
                    //在普通缓冲区查找ID，找不到则在其它缓冲区查找，还找不到则跳出
                    List<ObjectGeneral> list = this.ListBuffer_Object;
                    ObjectGeneral general = list.Find(c => c.Id == quality.Id);
                    if (general == null)
                    {
                        list = this.ListBuffer_Object_Other;
                        general = list.Find(c => c.Id == quality.Id);
                    }
                    if (general == null)
                        return;

                    general.MeasState = quality.MeasState;
                    general.ProbOfExist = quality.ProbOfExist;
                    //TODO 目标模式输出结果过滤条件2：（假如过滤器启用）判断存在概率的可能最小值是否小于允许的最低值
                    if (BaseConst.ObjectFilterEnabled && ((ObjectQuality.MeasStateFilter.Count > 0 && !ObjectQuality.MeasStateFilter.Contains(general.MeasState)) ||
                        (ObjectQuality.ProbOfExistFilter.Count > 0 && !ObjectQuality.ProbOfExistFilter.Contains(general.ProbOfExist))))
                        list.Remove(general);
                    ////目标模式输出结果过滤条件2：（假如过滤器启用）判断存在概率的可能最小值是否小于允许的最低值
                    //if (BaseConst.ClusterFilterEnabled && general.ProbOfExistMinimum < this.ParentForm.ProbOfExistMinimum)
                    //    this.ListBuffer_Object.Remove(general);
                }
            }
            catch (Exception) { }
        }

        /// <summary>
        /// 结束一个阶段的数据压入，将缓冲区数据汇入正式数据
        /// </summary>
        public void DataPushFinalize()
        {
            //假如应获取的集群/目标数量不为0但实际未收到，则退出（收到了空的帧）
            if (this.BufferSize != 0 && this.ActualSize == 0)
                return;
            bool is_cluster_mode = this.CurrentSensorMode == SensorMode.Cluster;
            if (is_cluster_mode)
            {
                //不要添加this.ListBuffer_Cluster与ListBuffer_Cluster_Other数量是否均为0的判断，否则当不存在目标时无法及时反映在数据上
                if (this.Radar != null/* && (this.ListBuffer_Cluster.Count != 0 || this.ListBuffer_Cluster_Other.Count != 0)*/)
                {
                    this.ListBuffer_Cluster.Sort((a, b) => a.DistanceToBorder.CompareTo(b.DistanceToBorder)); //根据距检测区的最短距离排序
                    this.ListBuffer_Cluster_Other.Sort((a, b) => a.ModiCoors.Z.CompareTo(b.ModiCoors.Z)); //根据Z轴坐标排序
                    //this.ClustersAtThreat = this.ListBuffer_Cluster.Where(c => c.ThreatLevel > 0).ToList(); //找出威胁级数大于0的点，按距检测区的最短距离排序
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
                    //this.ObjectsAtThreat = this.ListBuffer_Object.Where(o => o.ThreatLevel > 0).ToList();
                    this.ObjectMostThreat = this.ListBuffer_Object.Count() > 0 ? this.ListBuffer_Object.First() : null;
                    this.ObjectHighest = this.ListBuffer_Object_Other.Count() > 0 ? this.ListBuffer_Object_Other.Last() : null; //找出Z轴坐标最大的点（最高的点）
                }
                this.ListTrigger_Object.Clear();
                this.ListTrigger_Object.AddRange(this.ListBuffer_Object);
                this.ListTrigger_Object.AddRange(this.ListBuffer_Object_Other);
                this.ListBuffer_Object.Clear();
                this.ListBuffer_Object_Other.Clear();
            }
            this.ActualSize = 0;
        }

        /// <summary>
        /// 用新值来迭代距障碍物的距离
        /// </summary>
        /// <param name="value">新的距离值</param>
        public void IterateDistance(double value)
        {
            _new = value; //新值
            _diff = Math.Abs(_new - _current); //新值与当前值的差
            _diff1 = Math.Abs(_new - _assumed); //新值与假定值的差
            //假如未启用迭代 / 当前值为0 / 新值与当前值的差不超过距离限定值：计数置0，用新值取代现有值
            if (!BaseConst.IterationEnabled || _diff <= BaseConst.IteDistLimit * this.limit_factor)
            {
                _count = 0;
                _current = _new;
            }
            //假如新值与当前值的差超过距离限定值，计数刷新，用新值取代假定值
            else
            {
                //假如新值与假定值的差未超过距离限定值，计数+1（否则置0）
                _count = _diff1 <= BaseConst.IteDistLimit * this.limit_factor ? _count + 1 : 0;
                _assumed = _new;
                //假如计数超过计数限定值，则用新值取代现有值
                if (_count > BaseConst.IteCountLimit)
                {
                    _current = _new;
                    _count = 0;
                }
            }
        }
    }
}
