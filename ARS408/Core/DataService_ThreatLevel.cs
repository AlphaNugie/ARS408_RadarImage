using CommonLib.DataUtil;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS408.Core
{
    public class DataService_ThreatLevel
    {
        private SqliteProvider provider = new SqliteProvider();

        /// <summary>
        /// 获取所有报警级数
        /// </summary>
        /// <returns></returns>
        public DataTable GetThreatLevels()
        {
            string sqlString = "select t.*, 0 changed from t_base_threatlevels t order by t.level_num";
            return this.provider.Query(sqlString);
        }

        /// <summary>
        /// 获取SQL字符串
        /// </summary>
        /// <param name="level">对象</param>
        /// <returns></returns>
        private string GetThreatLevelSqlString(ThreatLevel level)
        {
            string sql = string.Empty;
            if (level != null)
                sql = string.Format(level.Id <= 0 ? "insert into t_base_threatlevels (level_num, level_value) values ({0}, {1})" : "update t_base_threatlevels set level_value = {1} where level_num = {0}", level.Id, level.Name);
            return sql;
        }

        /// <summary>
        /// 保存信息
        /// </summary>
        /// <param name="level">对象</param>
        /// <returns></returns>
        public int SaveThreatLevel(ThreatLevel level)
        {
            return this.provider.ExecuteSql(this.GetThreatLevelSqlString(level));
        }

        /// <summary>
        /// 批量保存信息
        /// </summary>
        /// <param name="levels">多个对象</param>
        /// <returns></returns>
        public bool SaveThreatLevels(IEnumerable<ThreatLevel> levels)
        {
            string[] sqls = levels == null ? null : levels.Select(level => this.GetThreatLevelSqlString(level)).ToArray();
            return this.provider.ExecuteSqlTrans(sqls);
        }
    }

    /// <summary>
    /// 报警级数实体类
    /// </summary>
    public class ThreatLevel
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
        /// 默认构造器
        /// </summary>
        public ThreatLevel() { }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="id">装船机ID</param>
        /// <param name="name">装船机名称</param>
        /// <param name="topicName">TOPIC名称</param>
        public ThreatLevel(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
