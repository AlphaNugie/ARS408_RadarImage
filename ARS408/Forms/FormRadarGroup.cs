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
    public partial class FormRadarGroup : Form
    {
        private readonly DataService_RadarGroup dataService = new DataService_RadarGroup();
        private readonly DataTable shiploaders = (new DataService_Shiploader()).GetAllShiploadersOrderbyName();
        private readonly int first_loader_id = 0;

        /// <summary>
        /// DataGridView的数据源
        /// </summary>
        public DataTable DataTable { get; private set; }

        /// <summary>
        /// 默认构造器
        /// </summary>
        public FormRadarGroup()
        {
            InitializeComponent();
            this.dataGridView_Main.AutoGenerateColumns = false; //不显示数据库中未绑定的列
            this.DataTable = null;
            if (this.shiploaders != null && this.shiploaders.Rows.Count > 0)
                this.first_loader_id = int.Parse(this.shiploaders.Rows[0]["SHIPLOADER_ID"].ToString());
        }

        /// <summary>
        /// 刷新数据源
        /// </summary>
        private void DataSourceRefresh()
        {
            try { this.DataTable = this.dataService.GetAllRadarGroupsOrderbyId(); }
            catch (Exception e)
            {
                string errorMessage = "查询雷达组列表时报错：" + e.Message;
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
        private void FormRadarGroup_Load(object sender, EventArgs e)
        {
            if (this.first_loader_id == 0)
            {
                this.button_Add.Enabled = false;
                this.button_Save.Enabled = false;
                this.button_Delete.Enabled = false;
                MessageBox.Show("未找到装船机信息，请先配置装船机", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.dataGridView_Main.SetDoubleBuffered(true); //启用双缓存

            //绑定装船机
            this.Column_OwnerShiploaderId.DataSource = this.shiploaders;
            this.Column_OwnerShiploaderId.DisplayMember = "SHIPLOADER_NAME";
            this.Column_OwnerShiploaderId.ValueMember = "SHIPLOADER_ID";
            //绑定组类型
            this.Column_GroupType.DataSource = (new DataService_GroupType()).GetAllGroupTypesOrderbyName();
            this.Column_GroupType.DisplayMember = "GROUP_NAME";
            this.Column_GroupType.ValueMember = "GROUP_CODE";
            this.DataSourceRefresh();
        }

        /// <summary>
        /// 新增按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Add_Click(object sender, EventArgs e)
        {
            object[] values = new object[] { 0, string.Empty, this.first_loader_id, 1 };
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

            List<RadarGroup> list = new List<RadarGroup>();
            foreach (DataGridViewRow row in this.dataGridView_Main.Rows)
                if (row.Cells["Column_Id"].Value.ToString().Equals("0") || row.Cells["Column_Changed"].Value.ToString().Equals("1"))
                {
                    RadarGroup group = DataGridViewUtil.ConvertDataGridViewRow2Obect<RadarGroup>(row);
                    if (group.OwnerShiploaderId > 0) list.Add(group);
                    else
                    {
                        MessageBox.Show("所属装船机不得为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

            bool result;
            try { result = this.dataService.SaveRadarGroups(list); }
            catch (Exception ex)
            {
                string errorMessage = "雷达组信息保存时出现问题：" + ex.Message;
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
            try { number = this.dataService.DeleteRadarGroupById(number); }
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
