using ARS408.Model;
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
    /// 雷达组信息SQLITE操作类
    /// </summary>
    public class DataService_RadarGroup
    {
        private readonly SqliteProvider provider = new SqliteProvider();

        /// <summary>
        /// 获取所有雷达组，按ID排序
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllRadarGroupsOrderbyId()
        {
            return this.GetAllRadarGroups("group_id");
        }

        /// <summary>
        /// 获取所有雷达组，按名称排序
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllRadarGroupsOrderbyName()
        {
            return this.GetAllRadarGroups("group_name");
        }

        /// <summary>
        /// 获取所有雷达组，并按特定字段排序
        /// </summary>
        /// <param name="orderby">排序字段，假如为空则不排序</param>
        /// <returns></returns>
        public DataTable GetAllRadarGroups(string orderby)
        {
            string sql = "select t.*, 0 changed from t_base_radargroup_info t " + (string.IsNullOrWhiteSpace(orderby) ? string.Empty : "order by t." + orderby);
            return this.provider.Query(sql);
        }

        /// <summary>
        /// 根据ID删除雷达组
        /// </summary>
        /// <param name="id">雷达组ID</param>
        /// <returns></returns>
        public int DeleteRadarGroupById(int id)
        {
            string sql = string.Format("delete from t_base_radargroup_info where group_id = {0}", id);
            return this.provider.ExecuteSql(sql);
        }

        /// <summary>
        /// 获取雷达组SQL字符串
        /// </summary>
        /// <param name="group">雷达组对象</param>
        /// <returns></returns>
        private string GetRadarGroupSqlString(RadarGroup group)
        {
            string sql = string.Empty;
            if (group != null)
                sql = string.Format(group.Id <= 0 ? "insert into t_base_radargroup_info (group_name, owner_shiploader_id, group_type) values ('{0}', {1}, {2})" : "update t_base_radargroup_info set group_name = '{0}', owner_shiploader_id = {1}, group_type = {2} where group_id = {3}", group.Name, group.OwnerShiploaderId, group.GroupType, group.Id);
            return sql;
        }

        /// <summary>
        /// 保存雷达组信息
        /// </summary>
        /// <param name="loader">雷达组对象</param>
        /// <returns></returns>
        public int SaveRadarGroup(RadarGroup group)
        {
            return this.provider.ExecuteSql(this.GetRadarGroupSqlString(group));
        }

        /// <summary>
        /// 批量保存雷达组信息
        /// </summary>
        /// <param name="groups">多个雷达组对象</param>
        /// <returns></returns>
        public bool SaveRadarGroups(IEnumerable<RadarGroup> groups)
        {
            string[] sqls = groups == null ? null : groups.Select(group => this.GetRadarGroupSqlString(group)).ToArray();
            return this.provider.ExecuteSqlTrans(sqls);
        }
    }

    ///// <summary>
    ///// 雷达组实体类
    ///// </summary>
    //public class RadarGroup
    //{
    //    /// <summary>
    //    /// 数据库ID
    //    /// </summary>
    //    public int Id { get; set; }

    //    /// <summary>
    //    /// 雷达组名称
    //    /// </summary>
    //    public string Name { get; set; }

    //    /// <summary>
    //    /// 所属装船机ID
    //    /// </summary>
    //    public int OwnerShiploaderId { get; set; }

    //    /// <summary>
    //    /// 雷达组类型，1 臂架，2 溜桶，3 脚位
    //    /// </summary>
    //    public int GroupType { get; set; }

    //    /// <summary>
    //    /// 默认构造器
    //    /// </summary>
    //    public RadarGroup() { }

    //    /// <summary>
    //    /// 构造器
    //    /// </summary>
    //    /// <param name="id">雷达组ID</param>
    //    /// <param name="name">雷达组名称</param>
    //    /// <param name="topicName">TOPIC名称</param>
    //    public RadarGroup(int id, string name)
    //    {
    //        this.Id = id;
    //        this.Name = name;
    //    }
    //}
}
