using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS408.Model
{
    /// <summary>
    /// 雷达状态信息
    /// </summary>
    public class RadarState : SensorMessage
    {
        private BaseMessage _base = new BaseMessage();

        #region 属性
        /// <summary>
        /// 是否在工作
        /// </summary>
        public int Working { get; set; }

        /// <summary>
        /// 在启动的时候读取配置参数的状态，0 失败，1 成功
        /// </summary>
        public byte MemoryReadStatus { get; set; }

        /// <summary>
        /// 存储配置参数的状态（初始值为0x0，在一个参数被设置并成功之后设置为0x1）
        /// </summary>
        public byte MemoryWriteStatus { get; set; }

        /// <summary>
        /// 当前对远距离检测设置的最大检测距离
        /// </summary>
        public ushort MaxDistance { get; set; }

        /// <summary>
        /// 持续性错误，检测到重启后依然存在的错误，0 无错误，1 错误发生
        /// </summary>
        public byte PersistentError { get; set; }

        /// <summary>
        /// 是否存在与另一台传感器的干扰，0 无干扰，1 干扰发生
        /// </summary>
        public byte Interference { get; set; }

        /// <summary>
        /// 温度错误，当低于或高于指定温度范围时发生，0 无错误，1 错误发生
        /// </summary>
        public byte TemperatureError { get; set; }

        /// <summary>
        /// 暂时性错误，检测到可能在重启后可能消失的错误，0 无错误，1 错误发生
        /// </summary>
        public byte TemporaryError { get; set; }

        /// <summary>
        /// 电压错误，当低于或高于指定电压范围5秒后发生，0 无错误，1 错误发生
        /// </summary>
        public byte VoltageError { get; set; }

        /// <summary>
        /// 传感器ID（0-7）
        /// </summary>
        public byte SensorId { get; set; }

        /// <summary>
        /// 当前目标存储列表的配置，0 无排序，1 范围排序，2 RCS排序
        /// </summary>
        public byte SortIndex { get; set; }

        /// <summary>
        /// 雷达功率，0 Standard，1 -3dB Tx gain，2 -6dB Tx gain，3 -9dB Tx gain
        /// </summary>
        public byte RadarPower { get; set; }

        /// <summary>
        /// 是否发送继电器控制信息，0 未发送，1 发送
        /// </summary>
        public byte ControlRelay { get; set; }

        /// <summary>
        /// 当前选择的输出类型，0 无类型，1 目标，2 集群
        /// </summary>
        public byte OutputType { get; set; }

        /// <summary>
        /// 是否发送目标或集群的质量信息，0 未发送，1 发送
        /// </summary>
        public byte SendQuality { get; set; }

        /// <summary>
        /// 是否发送目标的扩展信息，0 未发送，1 发送
        /// </summary>
        public byte SendExtendedInfo { get; set; }

        /// <summary>
        /// 显示速度和偏航角速度的输入标记的状态，0 输入成功，1 缺少速度，2 缺少偏航角，3 速度与偏航角均缺少
        /// </summary>
        public byte MotionRxState { get; set; }

        /// <summary>
        /// 是否激活传感器高灵敏度模式，0 标准模式，1 高灵敏度模式
        /// </summary>
        public byte RcsThreshold { get; set; }

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
        #endregion

        /// <summary>
        /// 默认构造器
        /// </summary>
        public RadarState() : this(null) { }

        /// <summary>
        /// 基础信息初始化
        /// </summary>
        /// <param name="message">基础信息</param>
        public RadarState(BaseMessage message)
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
                this.MemoryWriteStatus =
                    Convert.ToByte(binary.Substring(0, 1), 2);
                this.MemoryReadStatus = Convert.ToByte(binary.Substring(1, 1), 2);
                this.MaxDistance = Convert.ToUInt16(binary.Substring(8, 10), 2);
                this.PersistentError = Convert.ToByte(binary.Substring(18, 1), 2);
                this.Interference = Convert.ToByte(binary.Substring(19, 1), 2);
                this.TemperatureError = Convert.ToByte(binary.Substring(20, 1), 2);
                this.TemporaryError = Convert.ToByte(binary.Substring(21, 1), 2);
                this.VoltageError = Convert.ToByte(binary.Substring(22, 1), 2);
                this.RadarPower = Convert.ToByte(binary.Substring(30, 3), 2);
                this.SortIndex = Convert.ToByte(binary.Substring(33, 3), 2);
                this.SensorId = Convert.ToByte(binary.Substring(37, 3), 2);
                this.MotionRxState = Convert.ToByte(binary.Substring(40, 2), 2);
                this.SendExtendedInfo = Convert.ToByte(binary.Substring(42, 1), 2);
                this.SendQuality = Convert.ToByte(binary.Substring(43, 1), 2);
                this.OutputType = Convert.ToByte(binary.Substring(44, 2), 2);
                this.ControlRelay = Convert.ToByte(binary.Substring(46, 1), 2);
                this.RcsThreshold = Convert.ToByte(binary.Substring(59, 3), 2);
            }
            catch (Exception) { }
        }
    }
}
