using ARS408.Core;
using CommonLib.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS408.Model
{
    /// <summary>
    /// 集群基本信息实体类
    /// </summary>
    public class ClusterGeneral : SensorMessage
    {
        private BaseMessage _base = new BaseMessage();
        private DynProp prop = new DynProp();
        private double rcs = 0, dist_long = 0, dist_lat = 0, distance_border = 0;
        private int threat_level = 0;

        /// <summary>
        /// 根据距检测区的最短距离排序
        /// </summary>
        public static Comparison<ClusterGeneral> Comparison = (a, b) => a.DistanceToBorder.CompareTo(b.DistanceToBorder);

        #region 属性
        /// <summary>
        /// 集群ID（编号）
        /// </summary>
        public byte Id { get; set; }

        /// <summary>
        /// 纵向（x）坐标，米
        /// </summary>
        public double DistLong
        {
            get { return this.dist_long; }
            set
            {
                this.dist_long = value;
                this.CalculateConvertedCoors();
            }
        }

        /// <summary>
        /// 横向（y）坐标，米
        /// </summary>
        public double DistLat
        {
            get { return this.dist_lat; }
            set
            {
                this.dist_lat = value;
                this.CalculateConvertedCoors();
            }
        }

        /// <summary>
        /// 纵向的相对速度（x），米/秒
        /// </summary>
        public double VrelLong { get; set; }

        /// <summary>
        /// 横向的相对速度（y），米/秒
        /// </summary>
        public double VrelLat { get; set; }

        /// <summary>
        /// 修改后坐标
        /// </summary>
        public ModifiedCoordinates ModiCoors { get; set; }

        /// <summary>
        /// 集群的动态属性，指示是否在移动
        /// </summary>
        public DynProp DynProp
        {
            get { return this.prop; }
            set
            {
                this.prop = value;
                this.DynPropString = this.prop.GetDescription();
                this.Color = BaseFunc.GetColorByDynProp(this.prop, this.Color);
            }
        }

        /// <summary>
        /// 集群动态属性的描述
        /// </summary>
        public string DynPropString { get; set; }

        /// <summary>
        /// 集群动态属性所对应的颜色
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// 雷达散射截面(Radar Crossing Section)，单位 dBm2（分贝，转换为平米：10^(0.1*dB)，例如，-10分贝为0.1平方米）
        /// </summary>
        public double RCS
        {
            get { return this.rcs; }
            set
            {
                this.rcs = value;
                this.RCS_M2 = Math.Pow(10, 0.1 * this.rcs);
                this.Color = BaseFunc.GetColorByRcs(this.rcs, this.Color);
            }
        }

        /// <summary>
        /// 雷达散射截面(Radar Crossing Section)，单位 m2（平方米）
        /// </summary>
        public double RCS_M2 { get; set; }

        /// <summary>
        /// 集群的虚警概率（错误报警）
        /// </summary>
        public FalseAlarmProbability Pdh0 { get; set; }

        /// <summary>
        /// 多普勒（径向速度）不确定的状态
        /// </summary>
        public AmbigState AmbigState { get; set; }

        /// <summary>
        /// 集群的有效状态
        /// </summary>
        public InvalidState InvalidState { get; set; }

        /// <summary>
        /// 基础信息
        /// </summary>
        public BaseMessage Base
        {
            get { return this._base; }
            set
            {
                this._base = value;
                if (this._base != null)
                    this.DataConvert(this._base.DataString_Binary);
            }
        }

        /// <summary>
        /// 对应雷达信息
        /// </summary>
        public Radar Radar { get; set; }

        /// <summary>
        /// 距检测边界的距离，与检测方式（点线面）与雷达朝向（海北陆南）有关
        /// </summary>
        public double DistanceToBorder
        {
            get { return this.distance_border; }
            set
            {
                this.distance_border = value;
                this.ThreatLevel = BaseFunc.GetThreatLevelByValue(this.distance_border);
            }
        }

        /// <summary>
        /// 报警级数
        /// </summary>
        public int ThreatLevel
        {
            get { return this.threat_level; }
            set
            {
                this.threat_level = value;
                this.ThreatLevelBinary = Convert.ToString(this.threat_level, 2).PadLeft(2, '0');
            }
        }

        public string ThreatLevelBinary { get; set; }
        #endregion

        /// <summary>
        /// 基础信息初始化
        /// </summary>
        /// <param name="message">基础信息</param>
        /// <param name="radar">雷达信息</param>
        public ClusterGeneral(BaseMessage message, Radar radar)
        {
            this.Color = Color.FromArgb(255, 255, 255);
            this.ModiCoors = new ModifiedCoordinates();
            this.Radar = radar;
            this.Base = message;
        }

        /// <summary>
        /// 基础信息初始化
        /// </summary>
        /// <param name="message">基础信息</param>
        public ClusterGeneral(BaseMessage message) : this(message, null) { }

        /// <summary>
        /// 默认构造器
        /// </summary>
        public ClusterGeneral() : this(null, null) { }

        /// <summary>
        /// 转换2进制数据
        /// </summary>
        /// <param name="binary"></param>
        private void DataConvert(string binary)
        {
            try
            {
                this.Id = Convert.ToByte(binary.Substring(0, 8), 2);
                this.DistLong = Math.Round(0.2 * Convert.ToUInt16(binary.Substring(8, 13), 2) - 500, 1);
                this.DistLat = Math.Round(0.2 * Convert.ToUInt16(binary.Substring(22, 10), 2) - 102.3, 1);
                this.VrelLong = Math.Round(0.25 * Convert.ToUInt16(binary.Substring(32, 10), 2) - 128, 2);
                this.VrelLat = Math.Round(0.25 * Convert.ToUInt16(binary.Substring(42, 9), 2) - 64, 2);
                //this.CalculateConvertedCoors();
                this.DynProp = (DynProp)Convert.ToByte(binary.Substring(53, 3), 2);
                this.RCS = 0.5 * Convert.ToUInt16(binary.Substring(56, 8), 2) - 64;
            }
            catch (Exception) { }
        }

        /// <summary>
        /// 计算转换后坐标
        /// </summary>
        public void CalculateConvertedCoors()
        {
            if (this.Radar != null)
            {
                this.ModiCoors.X = this.Radar.XmodifiedRatios.Xratio * this.DistLong + this.Radar.XmodifiedRatios.Yratio * this.DistLat;
                this.ModiCoors.Y = this.Radar.YmodifiedRatios.Xratio * this.DistLong + this.Radar.YmodifiedRatios.Yratio * this.DistLat;
                this.ModiCoors.Z = this.Radar.ZmodifiedRatios.Xratio * this.DistLong + this.Radar.ZmodifiedRatios.Yratio * this.DistLat;
                bool northsouth = this.Radar.Direction == 2 || this.Radar.Direction == 4; //是否朝向北或南
                double x = northsouth ? this.ModiCoors.X : this.ModiCoors.Y, y = northsouth ? this.ModiCoors.Y : this.ModiCoors.X, z = this.ModiCoors.Z;
                int m = this.Radar.DefenseMode; //防御模式：1 点，2 线，3 面
                //d = (a*x^2+b*z^2+c*y^2)^0.5，其中a, b, c由4-m, 3-m, 2-m的值决定，假如大于0则为1，小于等于0为0（公式形如Math.Sign(4 - m) == 1 ? 1 : 0）
                //含义：面模式，a=1,b=c=0；线模式，a=b=1,c=0；点模式，a=b=c=1
                //this.DistanceToBorder = Math.Sqrt((Math.Sign(4 - m) == 1 ? 1 : 0) * Math.Pow(x, 2) + (Math.Sign(3 - m) == 1 ? 1 : 0) * Math.Pow(y, 2) + (Math.Sign(2 - m) == 1 ? 1 : 0) * Math.Pow(z, 2));
                this.DistanceToBorder = Math.Sqrt((Math.Sign(4 - m) == 1 ? 1 : 0) * Math.Pow(x, 2) + (Math.Sign(3 - m) == 1 ? 1 : 0) * Math.Pow(z, 2) + (Math.Sign(2 - m) == 1 ? 1 : 0) * Math.Pow(y, 2));
                if (m == 3)
                    this.DistanceToBorder *= Math.Sign(x);
            }
        }

        /// <summary>
        /// 获取定制信息
        /// </summary>
        /// <returns></returns>
        public string GetCustomInfo()
        {
            return !BaseConst.AddingCustomInfo ? string.Empty : string.Format(" {0} {1} {2} {3} {4}", this.Id, this.VrelLong, this.VrelLat, (byte)this.DynProp, this.RCS);
        }
    }

    /// <summary>
    /// 修改后坐标
    /// </summary>
    public class ModifiedCoordinates
    {
        public double X, Y, Z;
    }

    #region 枚举
    /// <summary>
    /// 集群的动态属性
    /// </summary>
    public enum DynProp
    {
        /// <summary>
        /// 移动中
        /// </summary>
        [EnumDescription("移动中")]
        Moving = 0x0,

        /// <summary>
        /// 静止
        /// </summary>
        [EnumDescription("静止")]
        Stationary = 0x1,

        /// <summary>
        /// 迎面而来
        /// </summary>
        [EnumDescription("迎面而来")]
        Oncoming = 0x2,

        /// <summary>
        /// 备选的静止点（疑似静止？）
        /// </summary>
        [EnumDescription("备选静止")]
        StationaryCandidate = 0x3,

        /// <summary>
        /// 未知
        /// </summary>
        [EnumDescription("未知")]
        Unknown = 0x4,

        /// <summary>
        /// 
        /// </summary>
        [EnumDescription("Crossing Stationary")]
        CrossingStationary = 0x5,

        /// <summary>
        /// 
        /// </summary>
        [EnumDescription("Crossing Moving")]
        CrossingMoving = 0x6,

        /// <summary>
        /// 停止（移动转静止？）
        /// </summary>
        [EnumDescription("停止")]
        Stopped = 0x7
    }
    #endregion
}
