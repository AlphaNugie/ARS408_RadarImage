using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS408.Model
{
    /// <summary>
    /// 雷达实体类
    /// </summary>
    public class Radar
    {
        private double degree_xoy, degree_yoz, degree_xoz, degree_general;
        private double sinphi, cosphi, sintheta, costheta, sinlamda, coslamda, sing, cosg;

        #region 属性
        /// <summary>
        /// OPC工具
        /// </summary>
        public OpcUtilHelper OpcHelper { get; set; }

        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 雷达名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// 端口
        /// </summary>
        public ushort Port { get; set; }

        /// <summary>
        /// IP地址+端口
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 连接模式，1 TCP，2 UDP
        /// </summary>
        public int ConnectionMode { get; set; }

        /// <summary>
        /// 是否使用本地IP与端口
        /// </summary>
        public bool UsingLocal { get; set; }

        /// <summary>
        /// 本地IP
        /// </summary>
        public string IpAddressLocal { get; set; }

        /// <summary>
        /// 本地端口
        /// </summary>
        public int PortLocal { get; set; }

        /// <summary>
        /// 所属雷达组
        /// </summary>
        public int OwnerGroupId { get; set; }

        /// <summary>
        /// XOY平面内旋转角度
        /// </summary>
        public double DegreeXoy
        {
            get { return this.degree_xoy; }
            set
            {
                this.degree_xoy = value;
                this.sinphi = Math.Sin(this.degree_xoy * Math.PI / 180);
                this.cosphi = Math.Cos(this.degree_xoy * Math.PI / 180);
                this.UpdateRatios();
            }
        }

        /// <summary>
        /// YOZ平面内旋转角度
        /// </summary>
        public double DegreeYoz
        {
            get { return this.degree_yoz; }
            set
            {
                this.degree_yoz = value;
                this.sintheta = Math.Sin(this.degree_yoz * Math.PI / 180);
                this.costheta = Math.Cos(this.degree_yoz * Math.PI / 180);
                this.UpdateRatios();
            }
        }

        /// <summary>
        /// XOZ平面内旋转角度
        /// </summary>
        public double DegreeXoz
        {
            get { return this.degree_xoz; }
            set
            {
                this.degree_xoz = value;
                this.sinlamda = Math.Sin(this.degree_xoz * Math.PI / 180);
                this.coslamda = Math.Cos(this.degree_xoz * Math.PI / 180);
                this.UpdateRatios();
            }
        }

        /// <summary>
        /// 垂直于地面的轴的整体旋转角度，面向正南为0，面向海（东）为90，面向北为180，面向陆地（西）为270（或-90）
        /// </summary>
        public double DegreeGeneral
        {
            get { return this.degree_general; }
            set
            {
                this.degree_general = value;
                this.sing = Math.Sin(this.degree_general * Math.PI / 180);
                this.cosg = Math.Cos(this.degree_general * Math.PI / 180);
                this.UpdateRatios();
            }
        }

        /// <summary>
        /// 修改后的X坐标的原XY坐标参数
        /// </summary>
        public CoordinateRatios XmodifiedRatios { get; set; }

        /// <summary>
        /// 修改后的Y坐标的原XY坐标参数
        /// </summary>
        public CoordinateRatios YmodifiedRatios { get; set; }

        /// <summary>
        /// 修改后的Z坐标的原XY坐标参数
        /// </summary>
        public CoordinateRatios ZmodifiedRatios { get; set; }

        /// <summary>
        /// 方向：1234，海北陆南
        /// </summary>
        public int Direction { get; set; }
        
        /// <summary>
        /// 防御模式：1 点，2 线，3 面
        /// </summary>
        public int DefenseMode { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 雷达状态标签
        /// </summary>
        public string ItemNameRadarState { get; set; }

        /// <summary>
        /// 雷达碰撞状态标签1
        /// </summary>
        public string ItemNameCollisionState { get; set; }

        /// <summary>
        /// 雷达碰撞状态标签2
        /// </summary>
        public string ItemNameCollisionState2 { get; set; }
        #endregion

        /// <summary>
        /// 默认构造器
        /// </summary>
        public Radar() { }

        /// <summary>
        /// 更新修改后XYZ坐标的系数
        /// </summary>
        public void UpdateRatios()
        {
            //this.XmodifiedRatios = new CoordinateRatios() { Xratio = this.cosphi * coslamda, Yratio = 0 - sintheta * sinlamda - costheta * sinphi * coslamda };
            //this.YmodifiedRatios = new CoordinateRatios() { Xratio = sinphi, Yratio = costheta * cosphi };
            this.XmodifiedRatios = new CoordinateRatios() { Xratio = cosphi * coslamda * cosg - sinphi * sing, Yratio = 0 - sintheta * sinlamda * cosg - costheta * sinphi * coslamda * cosg - costheta * cosphi * sing };
            this.YmodifiedRatios = new CoordinateRatios() { Xratio = cosphi * coslamda * sing + sinphi * cosg, Yratio = costheta * cosphi * cosg - costheta * sinphi * coslamda * sing - sintheta * sinlamda * sing };
            this.ZmodifiedRatios = new CoordinateRatios() { Xratio = cosphi * sinlamda, Yratio = sintheta * coslamda - costheta * sinphi * sinlamda };

        }
    }

    /// <summary>
    /// 修改后的坐标中原XY坐标的系数
    /// </summary>
    public class CoordinateRatios
    {
        /// <summary>
        /// 原X坐标的系数
        /// </summary>
        public double Xratio;

        /// <summary>
        /// 原Y坐标的系数
        /// </summary>
        public double Yratio;
    }
}
