namespace ARS408.Forms
{
    partial class FormMonitor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel_Main = new System.Windows.Forms.TableLayoutPanel();
            this.treeView = new System.Windows.Forms.TreeView();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.button_StartOrEnd = new System.Windows.Forms.Button();
            this.button_Info = new System.Windows.Forms.Button();
            this.tableLayoutPanel_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_Main
            // 
            this.tableLayoutPanel_Main.AutoScroll = true;
            this.tableLayoutPanel_Main.ColumnCount = 2;
            this.tableLayoutPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Main.Controls.Add(this.treeView, 0, 0);
            this.tableLayoutPanel_Main.Controls.Add(this.tabControl, 1, 0);
            this.tableLayoutPanel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Main.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_Main.Name = "tableLayoutPanel_Main";
            this.tableLayoutPanel_Main.RowCount = 1;
            this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Main.Size = new System.Drawing.Size(1099, 600);
            this.tableLayoutPanel_Main.TabIndex = 0;
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Location = new System.Drawing.Point(3, 3);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(194, 594);
            this.treeView.TabIndex = 4;
            this.treeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeView_NodeMouseDoubleClick);
            // 
            // tabControl
            // 
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(203, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(893, 594);
            this.tabControl.TabIndex = 5;
            this.tabControl.DoubleClick += new System.EventHandler(this.TabControl_DoubleClick);
            // 
            // button_StartOrEnd
            // 
            this.button_StartOrEnd.Location = new System.Drawing.Point(133, 0);
            this.button_StartOrEnd.Name = "button_StartOrEnd";
            this.button_StartOrEnd.Size = new System.Drawing.Size(75, 23);
            this.button_StartOrEnd.TabIndex = 1;
            this.button_StartOrEnd.Text = "开始";
            this.button_StartOrEnd.UseVisualStyleBackColor = true;
            this.button_StartOrEnd.Click += new System.EventHandler(this.button_StartOrEnd_Click);
            // 
            // button_Info
            // 
            this.button_Info.Location = new System.Drawing.Point(212, 0);
            this.button_Info.Name = "button_Info";
            this.button_Info.Size = new System.Drawing.Size(75, 23);
            this.button_Info.TabIndex = 2;
            this.button_Info.Text = "信息";
            this.button_Info.UseVisualStyleBackColor = true;
            this.button_Info.Click += new System.EventHandler(this.button_Info_Click);
            // 
            // FormMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 600);
            this.Controls.Add(this.button_Info);
            this.Controls.Add(this.button_StartOrEnd);
            this.Controls.Add(this.tableLayoutPanel_Main);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormMonitor";
            this.Text = "图像监测";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMonitor_FormClosing);
            this.Load += new System.EventHandler(this.FormMonitor_Load);
            this.tableLayoutPanel_Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Main;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Button button_StartOrEnd;
        private System.Windows.Forms.Button button_Info;
    }
}