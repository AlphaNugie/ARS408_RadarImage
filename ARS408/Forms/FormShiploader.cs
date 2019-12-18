using ARS408.Core;
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
    public partial class FormShiploader : Form
    {
        private readonly DataService_Shiploader dataService = new DataService_Shiploader(); //数据库服务类

        /// <summary>
        /// DataGridView的数据源
        /// </summary>
        public DataTable DataTable { get; private set; }

        /// <summary>
        /// 默认构造器
        /// </summary>
        public FormShiploader()
        {
            InitializeComponent();
            this.dataGridView_Main.AutoGenerateColumns = false; //不显示数据库中未绑定的列
            this.DataTable = null;
        }

        /// <summary>
        /// 刷新数据源
        /// </summary>
        private void DataSourceRefresh()
        {
            try { this.DataTable = this.dataService.GetAllShiploadersOrderbyId(); }
            catch (Exception e)
            {
                string errorMessage = "查询装船机列表时报错：" + e.Message;
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
        private void FormShiploader_Load(object sender, EventArgs e)
        {
            this.dataGridView_Main.SetDoubleBuffered(true); //启用双缓存
            this.DataSourceRefresh();
        }

        /// <summary>
        /// 新增按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Add_Click(object sender, EventArgs e)
        {
            object[] values = new object[] { 0, string.Empty, string.Empty, string.Empty, string.Empty };
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

            List<Shiploader> list = new List<Shiploader>();
            foreach (DataGridViewRow row in this.dataGridView_Main.Rows)
                if (row.Cells["Column_Id"].Value.ToString().Equals("0") || row.Cells["Column_Changed"].Value.ToString().Equals("1"))
                    list.Add(DataGridViewUtil.ConvertDataGridViewRow2Obect<Shiploader>(row));

            bool result;
            try { result = this.dataService.SaveShiploaders(list); }
            catch (Exception ex)
            {
                string errorMessage = "装船机信息保存时出现问题：" + ex.Message;
                MessageBox.Show(errorMessage, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //假如返回true或没有修改行
            if (result || list.Count == 0)
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
            try { number = this.dataService.DeleteShiploaderById(number); }
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
