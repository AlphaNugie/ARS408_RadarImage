using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS408.Model
{
    /// <summary>
    /// 雷达组实体类
    /// </summary>
    public class RadarGroup
    {
        /// <summary>
        /// 数据库ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 雷达组名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 所属装船机ID
        /// </summary>
        public int OwnerShiploaderId { get; set; }

        /// <summary>
        /// 雷达组类型，1 臂架，2 溜桶，3 门腿
        /// </summary>
        public int GroupType { get; set; }

        /// <summary>
        /// 默认构造器
        /// </summary>
        public RadarGroup() { }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="id">雷达组ID</param>
        /// <param name="name">雷达组名称</param>
        /// <param name="topicName">TOPIC名称</param>
        public RadarGroup(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
