using ARS408.Core;
using CommonLib.Enums;
using CommonLib.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS408.Model
{
    /// <summary>
    /// 传感器信息基础类
    /// </summary>
    public class BaseMessage
    {
        #region 属性
        /// <summary>
        /// 信息中数据部分长度（字节数）
        /// </summary>
        public byte DataLength { get; set; }

        /// <summary>
        /// 传感器ID（0-7）
        /// </summary>
        public byte SensorId { get; set; }

        /// <summary>
        /// 传感器消息类型（ID_0）
        /// </summary>
        public SensorMessageId_0 MessageId { get; set; }

        /// <summary>
        /// 传感器消息名称
        /// </summary>
        public string MessageName { get; set; }

        /// <summary>
        /// 数据部分byte数组
        /// </summary>
        public byte[] DataArray { get; set; }

        /// <summary>
        /// 数据部分字符串（16进制BCD码）
        /// </summary>
        public string DataString_Hex { get; set; }

        /// <summary>
        /// 数据部分字符串（2进制）
        /// </summary>
        public string DataString_Binary { get; set; }
        #endregion

        /// <summary>
        /// 默认构造器
        /// </summary>
        public BaseMessage() { }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="input"></param>
        public BaseMessage(string input)
        {
            byte[] array = null;
            try { array = HexHelper.HexString2Bytes_Alternate(input); }
            catch (Exception) { return; }
            if (array == null || array.Length < 13)
                return;

            this.DataLength = array[0]; //有效字节数
            int messageid = array[3] * 256 + array[4], messageid_0; //实际的MESSAGE_ID
            this.SensorId = BaseFunc.GetSensorIdByMessageId(messageid, out messageid_0); //从MESSAGE_ID中提取的SENSOR_ID
            this.MessageId = (SensorMessageId_0)messageid_0; //得到MESSAGE_ID_0（数据类型）
            this.MessageName = this.MessageId.GetDescription();
            this.DataArray = array.Skip(5).Take(this.DataLength).ToArray(); //提取有效字节
            this.DataString_Binary = string.Join("", this.DataArray.Select(b => Convert.ToString(b, 2).PadLeft(8, '0')));
        }
    }
}
