using CommonLib.DataUtil;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS408.Core
{
    /// <summary>
    /// 装船机信息SQLITE操作类
    /// </summary>
    public class DataService_Shiploader
    {
        private readonly SqliteProvider provider = new SqliteProvider();

        /// <summary>
        /// 获取所有装船机，按ID排序
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllShiploadersOrderbyId()
        {
            return this.GetAllShiploaders("shiploader_id");
            //string sql = "select t.*, 0 changed from t_base_shiploader_info t order by t.shiploader_id";
            //return this.provider.Query(sql);
        }

        /// <summary>
        /// 获取所有装船机，按名称排序
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllShiploadersOrderbyName()
        {
            return this.GetAllShiploaders("shiploader_name");
        }

        /// <summary>
        /// 获取所有装船机，并按特定字段排序
        /// </summary>
        /// <param name="orderby">排序字段，假如为空则不排序</param>
        /// <returns></returns>
        public DataTable GetAllShiploaders(string orderby)
        {
            return this.GetShiploaders(0, orderby);
            //string sql = "select t.*, 0 changed from t_base_shiploader_info t " + (string.IsNullOrWhiteSpace(orderby) ? string.Empty : "order by t." + orderby);
            //return this.provider.Query(sql);
        }

        /// <summary>
        /// 根据装船机ID获取所有装船机，不排序
        /// </summary>
        /// <param name="shiploader_id">装船机ID，假如为0则查询所有</param>
        /// <returns></returns>
        public DataTable GetShiploader(int shiploader_id)
        {
            return this.GetShiploaders(shiploader_id, null);
        }

        /// <summary>
        /// 根据装船机ID获取所有装船机，并按特定字段排序
        /// </summary>
        /// <param name="shiploader_id">装船机ID，假如为0则查询所有</param>
        /// <param name="orderby">排序字段，假如为空则不排序</param>
        /// <returns></returns>
        public DataTable GetShiploaders(int shiploader_id, string orderby)
        {
            //string sql = "select t.*, 0 changed from t_base_shiploader_info t " + (string.IsNullOrWhiteSpace(orderby) ? string.Empty : "order by t." + orderby);
            string sql = string.Format("select t.*, 0 changed from t_base_shiploader_info t where {0} = 0 or t.shiploader_id = {0} {1}", shiploader_id, string.IsNullOrWhiteSpace(orderby) ? string.Empty : "order by t." + orderby);
            return this.provider.Query(sql);
        }

        /// <summary>
        /// 根据ID删除装船机
        /// </summary>
        /// <param name="id">装船机ID</param>
        /// <returns></returns>
        public int DeleteShiploaderById(int id)
        {
            string sql = string.Format("delete from t_base_shiploader_info where shiploader_id = {0}", id);
            return this.provider.ExecuteSql(sql);
        }

        /// <summary>
        /// 获取装船机SQL字符串
        /// </summary>
        /// <param name="loader">装船机对象</param>
        /// <returns></returns>
        private string GetShiploaderSqlString(Shiploader loader)
        {
            string sql = string.Empty;
            if (loader != null)
                sql = string.Format(loader.Id <= 0 ? "insert into t_base_shiploader_info (shiploader_name, topic_name) values ('{0}', '{1}')" : "update t_base_shiploader_info set shiploader_name = '{0}', topic_name = '{1}' where shiploader_id = {2}", loader.Name, loader.TopicName, loader.Id);
            return sql;
        }

        /// <summary>
        /// 保存装船机信息
        /// </summary>
        /// <param name="loader">装船机对象</param>
        /// <returns></returns>
        public int SaveShiploader(Shiploader loader)
        {
            return this.provider.ExecuteSql(this.GetShiploaderSqlString(loader));
        }

        /// <summary>
        /// 批量保存装船机信息
        /// </summary>
        /// <param name="loaders">多个装船机对象</param>
        /// <returns></returns>
        public bool SaveShiploaders(IEnumerable<Shiploader> loaders)
        {
            string[] sqls = loaders == null ? null : loaders.Select(loader => this.GetShiploaderSqlString(loader)).ToArray();
            return this.provider.ExecuteSqlTrans(sqls);
        }
    }

    /// <summary>
    /// 装船机实体类
    /// </summary>
    public class Shiploader
    {
        /// <summary>
        /// 数据库ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 装船机名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// OPC服务IP
        /// </summary>
        public string OpcServerIp { get; set; }

        /// <summary>
        /// OPC服务名称
        /// </summary>
        public string OpcServerName { get; set; }

        /// <summary>
        /// TOPIC名称
        /// </summary>
        public string TopicName { get; set; }

        /// <summary>
        /// TOPIC名称：行走位置
        /// </summary>
        public string TopicNameWalkingPos { get; set; }

        /// <summary>
        /// TOPIC名称：臂架俯仰角
        /// </summary>
        public string TopicNamePitchAngle { get; set; }

        /// <summary>
        /// TOPIC名称：臂架伸缩长度
        /// </summary>
        public string TopicNameStretchLength { get; set; }

        /// <summary>
        /// TOPIC名称：溜桶俯仰角
        /// </summary>
        public string TopicNameBucketPitch { get; set; }

        /// <summary>
        /// TOPIC名称：溜桶回转角
        /// </summary>
        public string TopicNameBucketYaw { get; set; }

        /// <summary>
        /// TOPIC名称：皮带速度
        /// </summary>
        public string TopicNameBeltSpeed { get; set; }

        /// <summary>
        /// TOPIC名称：瞬时流量
        /// </summary>
        public string TopicNameStream { get; set; }

        /// <summary>
        /// 标签名称：行走位置
        /// </summary>
        public string ItemNameWalkingPos { get; set; }

        /// <summary>
        /// 标签名称：臂架俯仰角
        /// </summary>
        public string ItemNamePitchAngle { get; set; }

        /// <summary>
        /// 标签名称：臂架伸缩长度
        /// </summary>
        public string ItemNameStretchLength { get; set; }

        /// <summary>
        /// 标签名称：溜桶俯仰角
        /// </summary>
        public string ItemNameBucketPitch { get; set; }

        /// <summary>
        /// 标签名称：溜桶回转角
        /// </summary>
        public string ItemNameBucketYaw { get; set; }

        /// <summary>
        /// 标签名称：皮带速度
        /// </summary>
        public string ItemNameBeltSpeed { get; set; }

        /// <summary>
        /// 标签名称：瞬时流量
        /// </summary>
        public string ItemNameStream { get; set; }

        /// <summary>
        /// 默认构造器
        /// </summary>
        public Shiploader() { }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="id">装船机ID</param>
        /// <param name="name">装船机名称</param>
        /// <param name="topicName">TOPIC名称</param>
        public Shiploader(int id, string name, string topicName)
        {
            this.Id = id;
            this.Name = name;
            this.TopicName = topicName;
        }
    }
}
