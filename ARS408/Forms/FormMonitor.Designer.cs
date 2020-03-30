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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button_StartOrEnd = new System.Windows.Forms.Button();
            this.button_Info = new System.Windows.Forms.Button();
            this.treeView_Main = new System.Windows.Forms.TreeView();
            this.tabControl_Main = new System.Windows.Forms.TabControl();
            this.label_opc = new System.Windows.Forms.Label();
            this.tableLayoutPanel_Main.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_Main
            // 
            this.tableLayoutPanel_Main.AutoScroll = true;
            this.tableLayoutPanel_Main.ColumnCount = 2;
            this.tableLayoutPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Main.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel_Main.Controls.Add(this.treeView_Main, 0, 1);
            this.tableLayoutPanel_Main.Controls.Add(this.tabControl_Main, 1, 1);
            this.tableLayoutPanel_Main.Controls.Add(this.label_opc, 1, 0);
            this.tableLayoutPanel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Main.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_Main.Name = "tableLayoutPanel_Main";
            this.tableLayoutPanel_Main.RowCount = 2;
            this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Main.Size = new System.Drawing.Size(1099, 600);
            this.tableLayoutPanel_Main.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.button_StartOrEnd);
            this.flowLayoutPanel1.Controls.Add(this.button_Info);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1, 1);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(198, 34);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // button_StartOrEnd
            // 
            this.button_StartOrEnd.Location = new System.Drawing.Point(3, 3);
            this.button_StartOrEnd.Name = "button_StartOrEnd";
            this.button_StartOrEnd.Size = new System.Drawing.Size(75, 27);
            this.button_StartOrEnd.TabIndex = 1;
            this.button_StartOrEnd.Text = "开始";
            this.button_StartOrEnd.UseVisualStyleBackColor = true;
            this.button_StartOrEnd.Click += new System.EventHandler(this.Button_StartOrEnd_Click);
            // 
            // button_Info
            // 
            this.button_Info.Location = new System.Drawing.Point(84, 3);
            this.button_Info.Name = "button_Info";
            this.button_Info.Size = new System.Drawing.Size(75, 27);
            this.button_Info.TabIndex = 2;
            this.button_Info.Text = "信息";
            this.button_Info.UseVisualStyleBackColor = true;
            this.button_Info.Click += new System.EventHandler(this.Button_Info_Click);
            // 
            // treeView_Main
            // 
            this.treeView_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_Main.Location = new System.Drawing.Point(3, 39);
            this.treeView_Main.Name = "treeView_Main";
            this.treeView_Main.Size = new System.Drawing.Size(194, 558);
            this.treeView_Main.TabIndex = 4;
            this.treeView_Main.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeView_NodeMouseDoubleClick);
            // 
            // tabControl_Main
            // 
            this.tabControl_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_Main.Location = new System.Drawing.Point(203, 39);
            this.tabControl_Main.Name = "tabControl_Main";
            this.tabControl_Main.SelectedIndex = 0;
            this.tabControl_Main.Size = new System.Drawing.Size(893, 558);
            this.tabControl_Main.TabIndex = 5;
            this.tabControl_Main.DoubleClick += new System.EventHandler(this.TabControl_DoubleClick);
            // 
            // label_opc
            // 
            this.label_opc.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_opc.AutoSize = true;
            this.label_opc.Location = new System.Drawing.Point(203, 8);
            this.label_opc.Name = "label_opc";
            this.label_opc.Size = new System.Drawing.Size(72, 20);
            this.label_opc.TabIndex = 6;
            this.label_opc.Text = "opc_info";
            // 
            // FormMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1099, 600);
            this.Controls.Add(this.tableLayoutPanel_Main);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormMonitor";
            this.Text = "图像监测";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMonitor_FormClosing);
            this.Load += new System.EventHandler(this.FormMonitor_Load);
            this.tableLayoutPanel_Main.ResumeLayout(false);
            this.tableLayoutPanel_Main.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Main;
        private System.Windows.Forms.TreeView treeView_Main;
        private System.Windows.Forms.TabControl tabControl_Main;
        private System.Windows.Forms.Button button_StartOrEnd;
        private System.Windows.Forms.Button button_Info;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label_opc;
    }
}