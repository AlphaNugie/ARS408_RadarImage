using CommonLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS408.Model
{
    /// <summary>
    /// 集群重要信息
    /// </summary>
    public class ClusterQuality : SensorMessage
    {
        #region 静态属性，过滤器
        /// <summary>
        /// 错误警报概率过滤器
        /// </summary>
        public static List<FalseAlarmProbability> FalseAlarmFilter { get; set; }

        /// <summary>
        /// 径向速度不确定性过滤器
        /// </summary>
        public static List<AmbigState> AmbigStateFilter { get; set; }

        /// <summary>
        /// 有效性(有效/高概率多目标)
        /// </summary>
        public static List<InvalidState> InvalidStateFilter { get; set; }
        #endregion

        #region 属性
        /// <summary>
        /// 集群ID（编号）
        /// </summary>
        public byte Id { get; set; }

        /// <summary>
        /// 纵向（x）坐标的标准差，米
        /// </summary>
        public SignalValue DistLongRms { get; set; }

        /// <summary>
        /// 横向（y）坐标的标准差，米
        /// </summary>
        public SignalValue DistLatRms { get; set; }

        /// <summary>
        /// 纵向的相对速度（x）的标准差，米/秒
        /// </summary>
        public SignalValue VrelLongRms { get; set; }

        /// <summary>
        /// 横向的相对速度（y）的标准差，米/秒
        /// </summary>
        public SignalValue VrelLatRms { get; set; }

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

        private BaseMessage _base = new BaseMessage();

        /// <summary>
        /// 基础信息
        /// </summary>
        public BaseMessage Base
        {
            get { return this._base; }
            set
            {
                this._base = value;
                this.DataConvert(this._base.DataString_Binary);
            }
        }
        #endregion

        /// <summary>
        /// 默认构造器
        /// </summary>
        public ClusterQuality() { }

        /// <summary>
        /// 基础信息初始化
        /// </summary>
        /// <param name="message">基础信息</param>
        public ClusterQuality(BaseMessage message)
        {
            this.Base = message;
        }

        /// <summary>
        /// 转换2进制数据
        /// </summary>
        /// <param name="binary"></param>
        private void DataConvert(string binary)
        {
            try
            {
                this.Id = Convert.ToByte(binary.Substring(0, 8), 2);
                this.DistLongRms = (SignalValue)Convert.ToByte(binary.Substring(8, 5), 2);
                this.DistLatRms = (SignalValue)Convert.ToByte(binary.Substring(13, 5), 2);
                this.VrelLongRms = (SignalValue)Convert.ToByte(binary.Substring(18, 5), 2);
                this.VrelLatRms = (SignalValue)Convert.ToByte(binary.Substring(23, 5), 2);
                this.Pdh0 = (FalseAlarmProbability)Convert.ToByte(binary.Substring(29, 3), 2);
                this.InvalidState = (InvalidState)Convert.ToByte(binary.Substring(32, 5), 2);
                this.AmbigState = (AmbigState)Convert.ToByte(binary.Substring(37, 3), 2);
            }
            catch (Exception) { }
        }
    }

    #region 枚举
    /// <summary>
    /// 纵向与横向高度、相对速度、相对加速度的标准差的范围
    /// </summary>
    public enum SignalValue
    {
        /// <summary>
        /// 小于0.005
        /// </summary>
        [EnumDescription("<0.005")]
        lt0005 = 0x0,

        /// <summary>
        /// 小于0.006
        /// </summary>
        [EnumDescription("<0.006")]
        lt0006 = 0x1,

        /// <summary>
        /// 小于0.008
        /// </summary>
        [EnumDescription("<0.008")]
        lt0008 = 0x2,

        /// <summary>
        /// 小于0.011
        /// </summary>
        [EnumDescription("<0.011")]
        lt0011 = 0x3,

        /// <summary>
        /// 小于0.014
        /// </summary>
        [EnumDescription("<0.014")]
        lt0014 = 0x4,

        /// <summary>
        /// 小于0.018
        /// </summary>
        [EnumDescription("<0.018")]
        lt0018 = 0x5,

        /// <summary>
        /// 小于0.023
        /// </summary>
        [EnumDescription("<0.023")]
        lt0023 = 0x6,

        /// <summary>
        /// 小于0.029
        /// </summary>
        [EnumDescription("<0.029")]
        lt0029 = 0x7,

        /// <summary>
        /// 小于0.038
        /// </summary>
        [EnumDescription("<0.038")]
        lt0038 = 0x8,

        /// <summary>
        /// 小于0.049
        /// </summary>
        [EnumDescription("<0.049")]
        lt0049 = 0x9,

        /// <summary>
        /// 小于0.063
        /// </summary>
        [EnumDescription("<0.063")]
        lt0063 = 0xA,

        /// <summary>
        /// 小于0.081
        /// </summary>
        [EnumDescription("<0.081")]
        lt0081 = 0xB,

        /// <summary>
        /// 小于0.105
        /// </summary>
        [EnumDescription("<0.105")]
        lt0105 = 0xC,

        /// <summary>
        /// 小于0.135
        /// </summary>
        [EnumDescription("<0.135")]
        lt0135 = 0xD,

        /// <summary>
        /// 小于0.174
        /// </summary>
        [EnumDescription("<0.174")]
        lt0174 = 0xE,

        /// <summary>
        /// 小于0.224
        /// </summary>
        [EnumDescription("<0.224")]
        lt0224 = 0xF,

        /// <summary>
        /// 小于0.288
        /// </summary>
        [EnumDescription("<0.288")]
        lt0288 = 0x10,

        /// <summary>
        /// 小于0.371
        /// </summary>
        [EnumDescription("<0.371")]
        lt0371 = 0x11,

        /// <summary>
        /// 小于0.478
        /// </summary>
        [EnumDescription("<0.478")]
        lt0478 = 0x12,

        /// <summary>
        /// 小于0.616
        /// </summary>
        [EnumDescription("<0.616")]
        lt0616 = 0x13,

        /// <summary>
        /// 小于0.794
        /// </summary>
        [EnumDescription("<0.794")]
        lt0794 = 0x14,

        /// <summary>
        /// 小于1.023
        /// </summary>
        [EnumDescription("<1.023")]
        lt1023 = 0x15,

        /// <summary>
        /// 小于1.317
        /// </summary>
        [EnumDescription("<1.317")]
        lt1317 = 0x16,

        /// <summary>
        /// 小于1.697
        /// </summary>
        [EnumDescription("<1.697")]
        lt1697 = 0x17,

        /// <summary>
        /// 小于2.187
        /// </summary>
        [EnumDescription("<2.187")]
        lt2187 = 0x18,

        /// <summary>
        /// 小于2.817
        /// </summary>
        [EnumDescription("<2.817")]
        lt2817 = 0x19,

        /// <summary>
        /// 小于3.630
        /// </summary>
        [EnumDescription("<3.630")]
        lt3630 = 0x1A,

        /// <summary>
        /// 小于4.676
        /// </summary>
        [EnumDescription("<4.676")]
        lt4676 = 0x1B,

        /// <summary>
        /// 小于6.025
        /// </summary>
        [EnumDescription("<6.025")]
        lt6025 = 0x1C,

        /// <summary>
        /// 小于7.762
        /// </summary>
        [EnumDescription("<7.762")]
        lt7762 = 0x1D,

        /// <summary>
        /// 小于10.000
        /// </summary>
        [EnumDescription("<10.000")]
        lt10000 = 0x1E,

        /// <summary>
        /// 无效数值
        /// </summary>
        [EnumDescription("无效数值")]
        Invalid = 0x1F
    }

    /// <summary>
    /// 集群虚警概率的范围
    /// </summary>
    public enum FalseAlarmProbability
    {
        /// <summary>
        /// 无效数值
        /// </summary>
        [EnumDescription("无错报")]
        Invalid = 0x0,

        /// <summary>
        /// 小于25%
        /// </summary>
        [EnumDescription("<25%")]
        lt25 = 0x1,

        /// <summary>
        /// 小于50%
        /// </summary>
        [EnumDescription("<50%")]
        lt50 = 0x2,

        /// <summary>
        /// 小于75%
        /// </summary>
        [EnumDescription("<75%")]
        lt75 = 0x3,

        /// <summary>
        /// 小于90%
        /// </summary>
        [EnumDescription("<90%")]
        lt90 = 0x4,

        /// <summary>
        /// 小于99%
        /// </summary>
        [EnumDescription("<99%")]
        lt99 = 0x5,

        /// <summary>
        /// 小于99.9%
        /// </summary>
        [EnumDescription("<99.9%")]
        lt999 = 0x6,

        /// <summary>
        /// 小于等于100%
        /// </summary>
        [EnumDescription("<=100%")]
        lte100 = 0x7
    }

    /// <summary>
    /// 不确定状态的类型
    /// </summary>
    public enum AmbigState
    {

        /// <summary>
        /// 无效值
        /// </summary>
        [EnumDescription("无效值")]
        Invalid = 0x0,

        /// <summary>
        /// 模糊（因为黑暗、模糊等含糊的状态使集群不清晰）
        /// </summary>
        [EnumDescription("模糊")]
        Ambiguous = 0x1,

        /// <summary>
        /// 意义不明
        /// </summary>
        [EnumDescription("Staggered Ramp")]
        StaggeredRamp = 0x2,

        /// <summary>
        /// 清晰（一切都很清晰，模糊处已解决）
        /// </summary>
        [EnumDescription("清晰")]
        Unambiguous = 0x3,

        /// <summary>
        /// 可能的静止点（模糊处已解决，可能有静止的物体）
        /// </summary>
        [EnumDescription("可能的静止点")]
        StationaryCandidates = 0x4
    }

    /// <summary>
    /// 集群的有效状态
    /// </summary>
    public enum InvalidState
    {
        /// <summary>
        /// 有效
        /// </summary>
        [EnumDescription("有效")]
        Valid = 0x0,

        /// <summary>
        /// Invalid due to low RCS（无效，低RCS）
        /// </summary>
        [EnumDescription("无效，低RCS")]
        Invalid_LowRCS = 0x1,

        /// <summary>
        /// Invalid due to near-field artefact（无效，近距离干扰）
        /// </summary>
        [EnumDescription("无效，近距离干扰")]
        Invalid_NearFieldArtefact = 0x2,

        /// <summary>
        /// Invalid far range Cluster because not confirmed in near range（远距离集群无效，由于近距离集群无法确定）
        /// </summary>
        [EnumDescription("远距离集群无效，由于近距离集群无法确定")]
        InvalidFarRangeCluster = 0x3,

        /// <summary>
        /// Valid Cluster with low RCS（有效集群，低RCS）
        /// </summary>
        [EnumDescription("有效集群，低RCS")]
        ValidCluster_LowRCS = 0x4,

        /// <summary>
        /// 预留
        /// </summary>
        [EnumDescription("预留")]
        Reserved1 = 0x5,

        /// <summary>
        /// Invalid Cluster due to high mirror probability（无效集群，高反射概率导致）
        /// </summary>
        [EnumDescription("无效集群，高反射概率导致")]
        InvalidCluster_HighMirrorP = 0x6,

        /// <summary>
        /// Invalid because outside sensor field of view（无效，由于处在传感器视野外部）
        /// </summary>
        [EnumDescription("无效，由于处在传感器视野外部")]
        Invalid_OutsideSensorFov = 0x7,

        /// <summary>
        /// Valid Cluster with azimuth correction due to elevation（有效集群，方位角修正后）
        /// </summary>
        [EnumDescription("有效集群，方位角修正后")]
        ValidCluster_AzimuthCorrection = 0x8,

        /// <summary>
        /// Valid Cluster with high child probability
        /// </summary>
        [EnumDescription("Valid Cluster with high child probability")]
        ValidCluster_HighChildP = 0x9,

        /// <summary>
        /// Valid Cluster with high probability of being a 50 deg artefact（有效集群，很可能存在一个50°的假象）
        /// </summary>
        [EnumDescription("有效集群，很可能存在一个50°的假象")]
        ValidCluster_50DegArtefact = 0xa,

        /// <summary>
        /// Valid Cluster but no local maximum（有效集群，但没有本地最大值）
        /// </summary>
        [EnumDescription("有效集群，但没有本地最大值")]
        ValidCluster_NoLocalMaximum = 0xb,

        /// <summary>
        /// Valid Cluster with high artefact probability（有效集群，有高概率产生假象）
        /// </summary>
        [EnumDescription("有效集群，有高概率产生假象")]
        ValidCluster_HighArtefactP = 0xc,

        /// <summary>
        /// 预留
        /// </summary>
        [EnumDescription("预留")]
        Reserved2 = 0xd,

        /// <summary>
        /// Invalid Cluster because it is a harmonics（无效集群，只是谐波）
        /// </summary>
        [EnumDescription("无效集群，只是谐波")]
        InvalidCluster_Harmonics = 0xe,

        /// <summary>
        /// Valid Cluster above 95 m in near range（有效集群，近距离超过95米）
        /// </summary>
        [EnumDescription("有效集群，近距离超过95米")]
        ValidCluster_95mNearRange = 0xf,

        /// <summary>
        /// Valid Cluster with high multi-target probability（无效集群，较高概率有多目标）
        /// </summary>
        [EnumDescription("无效集群，较高概率有多目标")]
        ValidCluster_HighMultiTargetP = 0x10,

        /// <summary>
        /// Valid Cluster with suspicious angle（有效集群，有可疑角度）
        /// </summary>
        [EnumDescription("有效集群，有可疑角度")]
        ValidCluster_SuspiciousAngle = 0x11
    }
    #endregion
}
