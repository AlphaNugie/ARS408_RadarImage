using ARS408.Core;
using ARS408.Model;
using CommonLib.Function;
using CommonLib.UIControlUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARS408.Forms
{
    public partial class FormRadar : Form
    {
        private readonly DataService_Radar dataService = new DataService_Radar();
        private readonly DataService_Sqlite dataService_Sqlite = new DataService_Sqlite();
        private readonly DataTable radarGroups = (new DataService_RadarGroup()).GetAllRadarGroupsOrderbyName(), connModes, directions, defenseModes;
        private readonly int first_group_id, first_mode_id, first_direction_id, first_defense_mode_id;

        /// <summary>
        /// DataGridView的数据源
        /// </summary>
        public DataTable DataTable { get; private set; }

        /// <summary>
        /// 默认构造器
        /// </summary>
        public FormRadar()
        {
            InitializeComponent();
            this.connModes = this.dataService_Sqlite.GetConnModes();
            this.directions = this.dataService_Sqlite.GetDirections();
            this.defenseModes = this.dataService_Sqlite.GetDefenseModes();
            this.dataGridView_Main.AutoGenerateColumns = false; //不显示数据库中未绑定的列
            this.DataTable = null;
            if (this.radarGroups != null && this.radarGroups.Rows.Count > 0)
                this.first_group_id = int.Parse(this.radarGroups.Rows[0]["GROUP_ID"].ToString());
            if (this.connModes != null && this.connModes.Rows.Count > 0)
                this.first_mode_id = int.Parse(this.connModes.Rows[0]["MODE_ID"].ToString());
            if (this.directions != null && this.directions.Rows.Count > 0)
                this.first_direction_id = int.Parse(this.directions.Rows[0]["DIRECTION_ID"].ToString());
            if (this.defenseModes != null && this.defenseModes.Rows.Count > 0)
                this.first_defense_mode_id = int.Parse(this.defenseModes.Rows[0]["MODE_ID"].ToString());
        }

        /// <summary>
        /// 刷新数据源
        /// </summary>
        private void DataSourceRefresh()
        {
            try { this.DataTable = this.dataService.GetAllRadarsOrderbyId(); }
            catch (Exception e)
            {
                string errorMessage = "查询雷达列表时报错：" + e.Message;
                MessageBox.Show(errorMessage, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.dataGridView_Main.DataSource = this.DataTable;
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormRadar_Load(object sender, EventArgs e)
        {
            if (this.first_group_id == 0)
            {
                this.button_Add.Enabled = false;
                this.button_Save.Enabled = false;
                this.button_Delete.Enabled = false;
                MessageBox.Show("未找到雷达组信息，请先配置雷达组", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.dataGridView_Main.SetDoubleBuffered(true); //启用双缓存

            //绑定装船机
            this.Column_OwnerGroupId.DataSource = this.radarGroups;
            this.Column_OwnerGroupId.DisplayMember = "GROUP_NAME";
            this.Column_OwnerGroupId.ValueMember = "GROUP_ID";
            this.Column_ConnectionMode.DataSource = this.connModes;
            this.Column_ConnectionMode.DisplayMember = "MODE_NAME";
            this.Column_ConnectionMode.ValueMember = "MODE_ID";
            this.Column_Direction.DataSource = this.directions;
            this.Column_Direction.DisplayMember = "DIRECTION_NAME";
            this.Column_Direction.ValueMember = "DIRECTION_ID";
            this.Column_DefenseMode.DataSource = this.defenseModes;
            this.Column_DefenseMode.DisplayMember = "MODE_NAME";
            this.Column_DefenseMode.ValueMember = "MODE_ID";
            this.DataSourceRefresh();
        }

        /// <summary>
        /// 新增按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Add_Click(object sender, EventArgs e)
        {
            object[] values = new object[] { 0, string.Empty, string.Empty, 20001, this.first_group_id, this.first_mode_id, "0", BaseConst.IpAddress_Local, 20005, 0, 0, 0, 0, this.first_direction_id, this.first_defense_mode_id, 0, BaseConst.RcsMinimum, BaseConst.RcsMaximum, 0, string.Empty };
            ((DataTable)this.dataGridView_Main.DataSource).Rows.Add(values);
            if (this.dataGridView_Main.Rows.Count == 0)
                return;
            this.dataGridView_Main.Rows[this.dataGridView_Main.Rows.Count - 1].Selected = true;
        }

        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Save_Click(object sender, EventArgs e)
        {
            if (this.dataGridView_Main.Rows.Count == 0)
                return;

            List<Radar> list = new List<Radar>();
            foreach (DataGridViewRow row in this.dataGridView_Main.Rows)
                //找到新增或修改行
                if (row.Cells["Column_Id"].Value.ToString().Equals("0") || row.Cells["Column_Changed"].Value.ToString().Equals("1"))
                {
                    Radar radar = DataGridViewUtil.ConvertDataGridViewRow2Obect<Radar>(row, false); //不抛出异常
                    radar.ConnectionMode = (ConnectionMode)int.Parse(row.Cells["Column_ConnectionMode"].Value.ToString()); //连接模式
                    radar.Direction = (Directions)int.Parse(row.Cells["Column_Direction"].Value.ToString()); //单独处理雷达朝向字段
                    if (radar.OwnerGroupId > 0) list.Add(radar);
                    else
                    {
                        MessageBox.Show("所属雷达组不得为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

            bool result;
            try { result = this.dataService.SaveRadars(list); }
            catch (Exception ex)
            {
                string errorMessage = "雷达信息保存时出现问题：" + ex.Message;
                MessageBox.Show(errorMessage, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (result)
            {
                MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DataSourceRefresh();
            }
            else
                MessageBox.Show("保存失败", "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Delete_Click(object sender, EventArgs e)
        {
            if (this.dataGridView_Main.CurrentRow == null)
            {
                MessageBox.Show("未选中任何行", "提示");
                return;
            }
            int number = int.Parse(this.dataGridView_Main.CurrentRow.Cells["Column_Id"].Value.ToString()); //ID
            //假如为新增未保存的行，直接删除
            if (number == 0)
            {
                this.dataGridView_Main.Rows.Remove(this.dataGridView_Main.CurrentRow);
                return;
            }
            try { number = this.dataService.DeleteRadarById(number); }
            catch (Exception ex)
            {
                MessageBox.Show("删除记录时出现问题 " + ex.Message);
                return;
            }
            MessageBox.Show(number > 0 ? "删除成功" : "删除失败");
            if (number > 0)
                this.DataSourceRefresh();
        }

        /// <summary>
        /// DataGridView单元格数据改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_Main_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //取消事件，完成代码处理后再添加事件（代码中改变单元格的值会导致死循环）
                this.dataGridView_Main.CellValueChanged -= new DataGridViewCellEventHandler(this.DataGridView_Main_CellValueChanged);
                this.dataGridView_Main.Rows[e.RowIndex].Cells["Column_Changed"].Value = 1;
                this.dataGridView_Main.CellValueChanged += new DataGridViewCellEventHandler(this.DataGridView_Main_CellValueChanged);
            }
        }
    }
}
