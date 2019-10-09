using CommonLib.DataUtil;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS408.Core
{
    public class DataService_Sqlite
    {
        private SqliteProvider provider = new SqliteProvider();

        /// <summary>
        /// 获取所有装船机、雷达组、雷达中每一项的本层id、名称与上层id
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllLevels()
        {
            return this.GetAllLevels(0);
        }

        /// <summary>
        /// 根据装船机ID获取装船机、雷达组、雷达中每一项的本层id、名称、上层id，假如装船机ID为0，则查询所有
        /// </summary>
        /// <param name="shiploader_id">装船机ID，为0则查询所有</param>
        /// <returns></returns>
        public DataTable GetAllLevels(int shiploader_id)
        {
            string sqlString = string.Format(@"
select * from (
  select 'loader_' || s.shiploader_id id, s.shiploader_name name, 'ROOT' parent_id, s.shiploader_id from t_base_shiploader_info s
   union all
  select 'group_' || g.group_id id, g.group_name name, 'loader_' || g.owner_shiploader_id parent_id, s.shiploader_id from t_base_radargroup_info g left join t_base_shiploader_info s on g.owner_shiploader_id = s.shiploader_id
   union all
  --select 'radar_' || r.radar_id id, r.ip_address||':'||r.port name, 'group_' || r.owner_group_id parent_id from t_base_radar_info r order by name
  select 'radar_' || r.radar_id id, r.radar_name name, 'group_' || r.owner_group_id parent_id, s.shiploader_id from t_base_radar_info r left join t_base_radargroup_info g on r.owner_group_id = g.group_id left join t_base_shiploader_info s on g.owner_shiploader_id = s.shiploader_id order by name)
where {0} = 0 or shiploader_id = {0}
", shiploader_id);
            return this.provider.Query(sqlString);
        }

        /// <summary>
        /// 获取所有连接模式
        /// </summary>
        /// <returns></returns>
        public DataTable GetConnModes()
        {
            string sqlString = "select * from t_base_conn_mode order by mode_id";
            return this.provider.Query(sqlString);
        }

        /// <summary>
        /// 获取所有方向：1234，海北陆南
        /// </summary>
        /// <returns></returns>
        public DataTable GetDirections()
        {
            string sqlString = "select * from t_base_directions order by direction_id";
            return this.provider.Query(sqlString);
        }

        /// <summary>
        /// 获取所有防御模式：1 点，2 线，3 面
        /// </summary>
        /// <returns></returns>
        public DataTable GetDefenseModes()
        {
            string sqlString = "select * from t_base_defense_mode order by mode_id";
            return this.provider.Query(sqlString);
        }

        /// <summary>
        /// 获取所有存在概率，value为概率最小值，name为概率范围名称
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllExistProbs()
        {
            string sqlString = "select value, name from t_list_exist_prob order by value";
            return this.provider.Query(sqlString);
        }
    }
}
