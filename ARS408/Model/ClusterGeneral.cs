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
        private FalseAlarmProbability pdh = new FalseAlarmProbability();
        private AmbigState ambig_state = new AmbigState();
        private InvalidState invalid_state = new InvalidState();
        private double rcs = 0, dist_long = 0, dist_lat = 0, distance_border = 0;

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
        /// 是否处于雷达坐标限制范围内
        /// </summary>
        public bool WithinRadarLimits { get; set; }

        /// <summary>
        /// 是否处于单机坐标限制范围内
        /// </summary>
        public bool WithinClaimerLimits { get; set; }

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
        public FalseAlarmProbability Pdh0
        {
            get { return this.pdh; }
            set
            {
                this.pdh = value;
                this.PdhString = this.pdh.GetDescription();
            }
        }

        /// <summary>
        /// 错报概率字符串
        /// </summary>
        public string PdhString { get; set; }

        /// <summary>
        /// 多普勒（径向速度）不确定的状态
        /// </summary>
        public AmbigState AmbigState
        {
            get { return this.ambig_state; }
            set
            {
                this.ambig_state = value;
                this.AmbigStateString = this.ambig_state.GetDescription();
            }
        }

        /// <summary>
        /// 径向速度不确定的状态字符串
        /// </summary>
        public string AmbigStateString { get; set; }

        /// <summary>
        /// 集群的有效状态
        /// </summary>
        public InvalidState InvalidState
        {
            get { return this.invalid_state; }
            set
            {
                this.invalid_state = value;
                this.InvalidStateString = this.invalid_state.GetDescription();
            }
        }

        /// <summary>
        /// 有效状态字符串
        /// </summary>
        public string InvalidStateString { get; set; }

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
            set { this.distance_border = value; }
        }
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
                Directions dir = this.Radar.Direction;
                this.ModiCoors.X = this.Radar.XmodifiedRatios.Xratio * this.DistLong + this.Radar.XmodifiedRatios.Yratio * this.DistLat;
                this.ModiCoors.Y = this.Radar.YmodifiedRatios.Xratio * this.DistLong + this.Radar.YmodifiedRatios.Yratio * this.DistLat;
                this.ModiCoors.Z = this.Radar.ZmodifiedRatios.Xratio * this.DistLong + this.Radar.ZmodifiedRatios.Yratio * this.DistLat;
                bool northsouth = dir == Directions.North || dir == Directions.South; //是否朝向北或南
                double x = northsouth ? this.ModiCoors.X : this.ModiCoors.Y, y = northsouth ? this.ModiCoors.Y : this.ModiCoors.X, z = this.ModiCoors.Z; //根据方向调换X/Y的值
                int m = this.Radar.DefenseMode; //防御模式：1 点，2 线，3 面
                //d = (a*x^2+b*z^2+c*y^2)^0.5，其中a, b, c由4-m, 3-m, 2-m的值决定，假如大于0则为1，小于等于0为0（公式形如Math.Sign(4 - m) == 1 ? 1 : 0）
                //含义：面模式，a=1,b=c=0；线模式，a=b=1,c=0；点模式，a=b=c=1
                //假如方向为上下，则只计算竖直方向Z坐标的值
                this.DistanceToBorder = (dir == Directions.Up || dir == Directions.Down) ? z : Math.Sqrt((Math.Sign(4 - m) == 1 ? 1 : 0) * Math.Pow(x, 2) + (Math.Sign(3 - m) == 1 ? 1 : 0) * Math.Pow(z, 2) + (Math.Sign(2 - m) == 1 ? 1 : 0) * Math.Pow(y, 2));
                this.DistanceToBorder = (dir == Directions.Down ? -1 : 1) * this.DistanceToBorder + this.Radar.Offset; //当方向向下时，在距离前乘以一个值为-1的系数（向下指时Z坐标均为负数）
                //假如防御模式为面，再添加处理步骤：乘以x的符号，效果为使边界距离带符号；假如面向北或陆，则再乘以-1（所面向方向坐标均为负数）
                if (m == 3 && dir != Directions.Up && dir != Directions.Down)
                    this.DistanceToBorder *= Math.Sign(x) * (dir == Directions.North || dir == Directions.Land ? -1 : 1);
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
}
