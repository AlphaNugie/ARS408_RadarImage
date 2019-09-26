using ARS408.Core;
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
    public partial class FormMain : Form
    {
        private DataService_Shiploader DataService_Shiploader = new DataService_Shiploader();

        /// <summary>
        /// 默认构造器
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 退出按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenu_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 装船机字典按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenu_Shiploaders_Click(object sender, EventArgs e)
        {
            this.ShowForm(new FormShiploader());
        }

        private void ToolStripMenu_RadarGroup_Click(object sender, EventArgs e)
        {
            this.ShowForm(new FormRadarGroup());
        }

        private void ToolStripMenu_Radar_Click(object sender, EventArgs e)
        {
            this.ShowForm(new FormRadar(), DockStyle.Fill);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (TabPage page in this.tabControl_Main.TabPages)
                this.DisposeTabPage(page);
        }

        /// <summary>
        /// 在TabPage页中加载窗体对象，默认不停靠TabPage
        /// </summary>
        /// <param name="form">需在TabPage页中加载或显示的窗体对象</param>
        private void ShowForm(Form form)
        {
            this.ShowForm(form, null);
        }

        /// <summary>
        /// 在TabPage页中加载窗体对象
        /// </summary>
        /// <param name="form">需在TabPage页中加载或显示的窗体对象</param>
        /// <param name="dock">停靠方式，假如为null则不停靠</param>
        private void ShowForm(Form form, DockStyle? dock)
        {
            if (form == null)
            {
                MessageBox.Show("无法显示空窗体", "提示消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //假如Tab页已存在，选中该页面
            foreach (TabPage tabPage in this.tabControl_Main.TabPages)
                if (tabPage.Name == form.Name)
                {
                    this.tabControl_Main.SelectedTab = tabPage;
                    return;
                }

            //在TabControl中显示包含该页面的TabPage
            form.TopLevel = false; //不置顶
            if (dock != null)
                form.Dock = dock.Value; //控件停靠方式
            form.FormBorderStyle = FormBorderStyle.None; //页面无边框
            TabPage page = new TabPage();
            page.Controls.Add(form);
            page.Text = form.Text;
            page.Name = form.Name;
            page.AutoScroll = true;
            this.Invoke(new MethodInvoker(delegate
            {
                this.tabControl_Main.TabPages.Add(page);
                this.tabControl_Main.SelectedTab = page;
                form.Show();
            }));
        }

        /// <summary>
        /// 释放TabPage的资源
        /// </summary>
        /// <param name="page"></param>
        private void DisposeTabPage(TabPage page)
        {
            if (page == null)
                return;
            if (page.Controls.Count > 0)
            {
                Form form = (Form)page.Controls[0];
                if (form != null)
                {
                    form.Close();
                    form.Dispose();
                }
            }

            page.Dispose();
        }

        private void TabControl_Main_DoubleClick(object sender, EventArgs e)
        {
            this.DisposeTabPage(this.tabControl_Main.SelectedTab);
        }

        private void ToolStripMenu_Monitor_Click(object sender, EventArgs e)
        {
            DataTable table = this.DataService_Shiploader.GetAllShiploadersOrderbyId();
            if (table == null || table.Rows.Count == 0)
                return;

            table.Rows.Cast<DataRow>().ToList().ForEach(row => this.ShowForm(new FormMonitor(int.Parse(row["shiploader_id"].ToString())), DockStyle.Fill));
            //this.ShowForm(new FormMonitor(), DockStyle.Fill);
        }

        private void ToolStrip_ThreatLevels_Click(object sender, EventArgs e)
        {
            this.ShowForm(new FormThreatLevels());
        }

        private void ToolStrip_OpcConfig_Click(object sender, EventArgs e)
        {
            FormOpcConfig form = new FormOpcConfig();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }
    }
}
