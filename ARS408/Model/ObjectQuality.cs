using CommonLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS408.Model
{
    /// <summary>
    /// 目标重要信息
    /// </summary>
    class ObjectQuality : SensorMessage
    {
        #region 静态属性，过滤器
        /// <summary>
        /// 测量状态过滤器
        /// </summary>
        public static List<MeasState> MeasStateFilter { get; set; }

        /// <summary>
        /// 存在概率过滤器
        /// </summary>
        public static List<ProbOfExist> ProbOfExistFilter { get; set; }
        #endregion

        #region 属性
        /// <summary>
        /// 目标ID（编号）
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
        /// 纵向的相对加速度（x）的标准差，米/平方秒
        /// </summary>
        public SignalValue ArelLongRms { get; set; }

        /// <summary>
        /// 横向的相对加速度（y）的标准差，米/平方秒
        /// </summary>
        public SignalValue ArelLatRms { get; set; }

        /// <summary>
        /// 方位角标准差
        /// </summary>
        public SignalValue_Degree OrientationRms { get; set; }

        /// <summary>
        /// 测量状态，指示目标是否有效
        /// </summary>
        public MeasState MeasState { get; set; }

        /// <summary>
        /// 存在概率
        /// </summary>
        public ProbOfExist ProbOfExist { get; set; }

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
        public ObjectQuality() { }

        /// <summary>
        /// 基础信息初始化
        /// </summary>
        /// <param name="message">基础信息</param>
        public ObjectQuality(BaseMessage message)
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
                this.ArelLongRms = (SignalValue)Convert.ToByte(binary.Substring(28, 5), 2);
                this.ArelLatRms = (SignalValue)Convert.ToByte(binary.Substring(33, 5), 2);
                this.OrientationRms = (SignalValue_Degree)Convert.ToByte(binary.Substring(38, 5), 2);
                this.ProbOfExist = (ProbOfExist)Convert.ToByte(binary.Substring(48, 3), 2);
                this.MeasState = (MeasState)Convert.ToByte(binary.Substring(51, 3), 2);
            }
            catch (Exception) { }
        }
    }

    #region 枚举
    /// <summary>
    /// 方位角的标准差的范围
    /// </summary>
    public enum SignalValue_Degree
    {
        /// <summary>
        /// 小于0.005
        /// </summary>
        [EnumDescription("<0.005")]
        lt0005 = 0x0,

        /// <summary>
        /// 小于0.007
        /// </summary>
        [EnumDescription("<0.007")]
        lt0007 = 0x1,

        /// <summary>
        /// 小于0.010
        /// </summary>
        [EnumDescription("<0.010")]
        lt0010 = 0x2,

        /// <summary>
        /// 小于0.014
        /// </summary>
        [EnumDescription("<0.014")]
        lt0014 = 0x3,

        /// <summary>
        /// 小于0.020
        /// </summary>
        [EnumDescription("<0.020")]
        lt0020 = 0x4,

        /// <summary>
        /// 小于0.029
        /// </summary>
        [EnumDescription("<0.029")]
        lt0029 = 0x5,

        /// <summary>
        /// 小于0.041
        /// </summary>
        [EnumDescription("<0.041")]
        lt0041 = 0x6,

        /// <summary>
        /// 小于0.058
        /// </summary>
        [EnumDescription("<0.058")]
        lt0058 = 0x7,

        /// <summary>
        /// 小于0.082
        /// </summary>
        [EnumDescription("<0.082")]
        lt0082 = 0x8,

        /// <summary>
        /// 小于0.116
        /// </summary>
        [EnumDescription("<0.116")]
        lt0116 = 0x9,

        /// <summary>
        /// 小于0.165
        /// </summary>
        [EnumDescription("<0.165")]
        lt0165 = 0xA,

        /// <summary>
        /// 小于0.234
        /// </summary>
        [EnumDescription("<0.234")]
        lt0234 = 0xB,

        /// <summary>
        /// 小于0.332
        /// </summary>
        [EnumDescription("<0.332")]
        lt0332 = 0xC,

        /// <summary>
        /// 小于0.471
        /// </summary>
        [EnumDescription("<0.471")]
        lt0471 = 0xD,

        /// <summary>
        /// 小于0.669
        /// </summary>
        [EnumDescription("<0.669")]
        lt0669 = 0xE,

        /// <summary>
        /// 小于0.949
        /// </summary>
        [EnumDescription("<0.949")]
        lt0949 = 0xF,

        /// <summary>
        /// 小于1.346
        /// </summary>
        [EnumDescription("<1.346")]
        lt1346 = 0x10,

        /// <summary>
        /// 小于1.909
        /// </summary>
        [EnumDescription("<1.909")]
        lt1909 = 0x11,

        /// <summary>
        /// 小于2.709
        /// </summary>
        [EnumDescription("<2.709")]
        lt2709 = 0x12,

        /// <summary>
        /// 小于3.843
        /// </summary>
        [EnumDescription("<3.843")]
        lt3843 = 0x13,

        /// <summary>
        /// 小于5.451
        /// </summary>
        [EnumDescription("<5.451")]
        lt5451 = 0x14,

        /// <summary>
        /// 小于7.734
        /// </summary>
        [EnumDescription("<7.734")]
        lt7734 = 0x15,

        /// <summary>
        /// 小于10.971
        /// </summary>
        [EnumDescription("<10.971")]
        lt10971 = 0x16,

        /// <summary>
        /// 小于5.565
        /// </summary>
        [EnumDescription("<5.565")]
        lt15565 = 0x17,

        /// <summary>
        /// 小于22.081
        /// </summary>
        [EnumDescription("<22.081")]
        lt22081 = 0x18,

        /// <summary>
        /// 小于31.325
        /// </summary>
        [EnumDescription("<31.325")]
        lt31325 = 0x19,

        /// <summary>
        /// 小于44.439
        /// </summary>
        [EnumDescription("<44.439")]
        lt44439 = 0x1A,

        /// <summary>
        /// 小于63.044
        /// </summary>
        [EnumDescription("<63.044")]
        lt63044 = 0x1B,

        /// <summary>
        /// 小于89.437
        /// </summary>
        [EnumDescription("<89.437")]
        lt89437 = 0x1C,

        /// <summary>
        /// 小于126.881
        /// </summary>
        [EnumDescription("<126.881")]
        lt126881 = 0x1D,

        /// <summary>
        /// 小于180.000
        /// </summary>
        [EnumDescription("<180.000")]
        lt180000 = 0x1E,

        /// <summary>
        /// 无效数值
        /// </summary>
        [EnumDescription("无效数值")]
        Invalid = 0x1F
    }

    /// <summary>
    /// 测量状态，指示目标是否有效
    /// </summary>
    public enum MeasState
    {
        /// <summary>
        /// 被删除，ID消失前的最后一轮数据传输中出现
        /// </summary>
        [EnumDescription("被删除")]
        Deleted = 0,

        /// <summary>
        /// 新出现，ID创建后的第一轮数据传输中出现
        /// </summary>
        [EnumDescription("新出现")]
        New = 1,

        /// <summary>
        /// 已测量，目标的出现被实际测量证实
        /// </summary>
        [EnumDescription("已测量")]
        Measured = 2,

        /// <summary>
        /// 预测的，目标的出现无法被实际测量证实
        /// </summary>
        [EnumDescription("预测的")]
        Predicted = 3,

        /// <summary>
        /// 为合并删除，为与另一个目标合并而被删除
        /// </summary>
        [EnumDescription("为合并删除")]
        DeletedForMerge = 4,

        /// <summary>
        /// 合并为新的，合并后产生的新目标
        /// </summary>
        [EnumDescription("合并为新的")]
        NewFromMerge = 5
    }

    /// <summary>
    /// 存在概率
    /// </summary>
    public enum ProbOfExist
    {
        /// <summary>
        /// 无效
        /// </summary>
        [EnumDescription("无效")]
        [EnumAlias("-1")]
        Invalid = 0,

        /// <summary>
        /// 小于25%
        /// </summary>
        [EnumDescription("<25%")]
        [EnumAlias("0")]
        Lt025 = 1,

        /// <summary>
        /// 小于50%
        /// </summary>
        [EnumDescription("<50%")]
        [EnumAlias("0.25")]
        Lt050 = 2,

        /// <summary>
        /// 小于75%
        /// </summary>
        [EnumDescription("<75%")]
        [EnumAlias("0.5")]
        Lt075 = 3,

        /// <summary>
        /// 小于90%
        /// </summary>
        [EnumDescription("<90%")]
        [EnumAlias("0.75")]
        Lt090 = 4,

        /// <summary>
        /// 小于99%
        /// </summary>
        [EnumDescription("<99%")]
        [EnumAlias("0.9")]
        Lt099 = 5,

        /// <summary>
        /// 小于99.9%
        /// </summary>
        [EnumDescription("<99.9%")]
        [EnumAlias("0.99")]
        Lt999 = 6,

        /// <summary>
        /// 小于等于100%
        /// </summary>
        [EnumDescription("<=100%")]
        [EnumAlias("0.999")]
        Lte100 = 7
    }
    #endregion
}
