using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS408.Model
{
    /// <summary>
    /// 集群状态实体类
    /// </summary>
    public class ClusterStatus : SensorMessage
    {
        #region 属性
        /// <summary>
        /// 近距离扫描被检测到的集群数量
        /// </summary>
        public byte NofClustersNear { get; set; }

        /// <summary>
        /// 近距离扫描被检测到的集群数量
        /// </summary>
        public byte NofClustersFar { get; set; }

        /// <summary>
        /// 测量周期基数器 (从传感器启动后开始计数，当超过65535时清零)
        /// </summary>
        public ushort MeasCounter { get; set; }

        /// <summary>
        /// 集群列表，CAN 接口版本
        /// </summary>
        public byte InterfaceVersion { get; set; }

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
        public ClusterStatus() { }

        /// <summary>
        /// 基础信息初始化
        /// </summary>
        /// <param name="message">基础信息</param>
        public ClusterStatus(BaseMessage message)
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
                this.NofClustersNear = Convert.ToByte(binary.Substring(0, 8), 2);
                this.NofClustersFar = Convert.ToByte(binary.Substring(8, 8), 2);
                this.MeasCounter = Convert.ToUInt16(binary.Substring(16, 16), 2);
                this.InterfaceVersion = Convert.ToByte(binary.Substring(32, 4), 2);
            }
            catch (Exception) { }
        }
    }
}
