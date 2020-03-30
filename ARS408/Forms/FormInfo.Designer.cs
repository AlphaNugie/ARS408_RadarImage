namespace ARS408.Forms
{
    partial class FormInfo
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label_RadarCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_DistThres = new System.Windows.Forms.Label();
            this.textBox_Info = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button_Start = new System.Windows.Forms.Button();
            this.button_Stop = new System.Windows.Forms.Button();
            this.textBox_Radar1 = new System.Windows.Forms.TextBox();
            this.textBox_Radar2 = new System.Windows.Forms.TextBox();
            this.textBox_Radar3 = new System.Windows.Forms.TextBox();
            this.textBox_Radar4 = new System.Windows.Forms.TextBox();
            this.textBox_Radar5 = new System.Windows.Forms.TextBox();
            this.textBox_Radar6 = new System.Windows.Forms.TextBox();
            this.textBox_Radar7 = new System.Windows.Forms.TextBox();
            this.textBox_Radar8 = new System.Windows.Forms.TextBox();
            this.textBox_Radar9 = new System.Windows.Forms.TextBox();
            this.textBox_Radar10 = new System.Windows.Forms.TextBox();
            this.textBox_Radar11 = new System.Windows.Forms.TextBox();
            this.textBox_Radar12 = new System.Windows.Forms.TextBox();
            this.textBox_Radar13 = new System.Windows.Forms.TextBox();
            this.textBox_Radar14 = new System.Windows.Forms.TextBox();
            this.textBox_Radar15 = new System.Windows.Forms.TextBox();
            this.textBox_Radar16 = new System.Windows.Forms.TextBox();
            this.textBox_Radar17 = new System.Windows.Forms.TextBox();
            this.textBox_Radar18 = new System.Windows.Forms.TextBox();
            this.textBox_Radar19 = new System.Windows.Forms.TextBox();
            this.textBox_Radar20 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "雷达数量";
            // 
            // label_RadarCount
            // 
            this.label_RadarCount.AutoSize = true;
            this.label_RadarCount.Location = new System.Drawing.Point(129, 9);
            this.label_RadarCount.Name = "label_RadarCount";
            this.label_RadarCount.Size = new System.Drawing.Size(18, 20);
            this.label_RadarCount.TabIndex = 0;
            this.label_RadarCount.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(208, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "距离阈值";
            // 
            // label_DistThres
            // 
            this.label_DistThres.AutoSize = true;
            this.label_DistThres.Location = new System.Drawing.Point(297, 9);
            this.label_DistThres.Name = "label_DistThres";
            this.label_DistThres.Size = new System.Drawing.Size(18, 20);
            this.label_DistThres.TabIndex = 0;
            this.label_DistThres.Text = "0";
            // 
            // textBox_Info
            // 
            this.textBox_Info.Location = new System.Drawing.Point(750, 43);
            this.textBox_Info.Multiline = true;
            this.textBox_Info.Name = "textBox_Info";
            this.textBox_Info.Size = new System.Drawing.Size(240, 390);
            this.textBox_Info.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(366, 1);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(75, 36);
            this.button_Start.TabIndex = 2;
            this.button_Start.Text = "启动";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.Button_Start_Click);
            // 
            // button_Stop
            // 
            this.button_Stop.Enabled = false;
            this.button_Stop.Location = new System.Drawing.Point(447, 1);
            this.button_Stop.Name = "button_Stop";
            this.button_Stop.Size = new System.Drawing.Size(75, 36);
            this.button_Stop.TabIndex = 2;
            this.button_Stop.Text = "停止";
            this.button_Stop.UseVisualStyleBackColor = true;
            this.button_Stop.Click += new System.EventHandler(this.Button_Stop_Click);
            // 
            // textBox_Radar1
            // 
            this.textBox_Radar1.Location = new System.Drawing.Point(12, 43);
            this.textBox_Radar1.Multiline = true;
            this.textBox_Radar1.Name = "textBox_Radar1";
            this.textBox_Radar1.Size = new System.Drawing.Size(240, 93);
            this.textBox_Radar1.TabIndex = 1;
            // 
            // textBox_Radar2
            // 
            this.textBox_Radar2.Location = new System.Drawing.Point(258, 43);
            this.textBox_Radar2.Multiline = true;
            this.textBox_Radar2.Name = "textBox_Radar2";
            this.textBox_Radar2.Size = new System.Drawing.Size(240, 93);
            this.textBox_Radar2.TabIndex = 1;
            // 
            // textBox_Radar3
            // 
            this.textBox_Radar3.Location = new System.Drawing.Point(12, 340);
            this.textBox_Radar3.Multiline = true;
            this.textBox_Radar3.Name = "textBox_Radar3";
            this.textBox_Radar3.Size = new System.Drawing.Size(240, 93);
            this.textBox_Radar3.TabIndex = 1;
            // 
            // textBox_Radar4
            // 
            this.textBox_Radar4.Location = new System.Drawing.Point(12, 142);
            this.textBox_Radar4.Multiline = true;
            this.textBox_Radar4.Name = "textBox_Radar4";
            this.textBox_Radar4.Size = new System.Drawing.Size(240, 93);
            this.textBox_Radar4.TabIndex = 1;
            // 
            // textBox_Radar5
            // 
            this.textBox_Radar5.Location = new System.Drawing.Point(12, 241);
            this.textBox_Radar5.Multiline = true;
            this.textBox_Radar5.Name = "textBox_Radar5";
            this.textBox_Radar5.Size = new System.Drawing.Size(240, 93);
            this.textBox_Radar5.TabIndex = 1;
            // 
            // textBox_Radar6
            // 
            this.textBox_Radar6.Location = new System.Drawing.Point(12, 538);
            this.textBox_Radar6.Multiline = true;
            this.textBox_Radar6.Name = "textBox_Radar6";
            this.textBox_Radar6.Size = new System.Drawing.Size(240, 93);
            this.textBox_Radar6.TabIndex = 1;
            // 
            // textBox_Radar7
            // 
            this.textBox_Radar7.Location = new System.Drawing.Point(258, 142);
            this.textBox_Radar7.Multiline = true;
            this.textBox_Radar7.Name = "textBox_Radar7";
            this.textBox_Radar7.Size = new System.Drawing.Size(240, 93);
            this.textBox_Radar7.TabIndex = 1;
            // 
            // textBox_Radar8
            // 
            this.textBox_Radar8.Location = new System.Drawing.Point(12, 439);
            this.textBox_Radar8.Multiline = true;
            this.textBox_Radar8.Name = "textBox_Radar8";
            this.textBox_Radar8.Size = new System.Drawing.Size(240, 93);
            this.textBox_Radar8.TabIndex = 1;
            // 
            // textBox_Radar9
            // 
            this.textBox_Radar9.Location = new System.Drawing.Point(258, 340);
            this.textBox_Radar9.Multiline = true;
            this.textBox_Radar9.Name = "textBox_Radar9";
            this.textBox_Radar9.Size = new System.Drawing.Size(240, 93);
            this.textBox_Radar9.TabIndex = 1;
            // 
            // textBox_Radar10
            // 
            this.textBox_Radar10.Location = new System.Drawing.Point(258, 439);
            this.textBox_Radar10.Multiline = true;
            this.textBox_Radar10.Name = "textBox_Radar10";
            this.textBox_Radar10.Size = new System.Drawing.Size(240, 93);
            this.textBox_Radar10.TabIndex = 1;
            // 
            // textBox_Radar11
            // 
            this.textBox_Radar11.Location = new System.Drawing.Point(504, 142);
            this.textBox_Radar11.Multiline = true;
            this.textBox_Radar11.Name = "textBox_Radar11";
            this.textBox_Radar11.Size = new System.Drawing.Size(240, 93);
            this.textBox_Radar11.TabIndex = 1;
            // 
            // textBox_Radar12
            // 
            this.textBox_Radar12.Location = new System.Drawing.Point(258, 241);
            this.textBox_Radar12.Multiline = true;
            this.textBox_Radar12.Name = "textBox_Radar12";
            this.textBox_Radar12.Size = new System.Drawing.Size(240, 93);
            this.textBox_Radar12.TabIndex = 1;
            // 
            // textBox_Radar13
            // 
            this.textBox_Radar13.Location = new System.Drawing.Point(258, 538);
            this.textBox_Radar13.Multiline = true;
            this.textBox_Radar13.Name = "textBox_Radar13";
            this.textBox_Radar13.Size = new System.Drawing.Size(240, 93);
            this.textBox_Radar13.TabIndex = 1;
            // 
            // textBox_Radar14
            // 
            this.textBox_Radar14.Location = new System.Drawing.Point(504, 43);
            this.textBox_Radar14.Multiline = true;
            this.textBox_Radar14.Name = "textBox_Radar14";
            this.textBox_Radar14.Size = new System.Drawing.Size(240, 93);
            this.textBox_Radar14.TabIndex = 1;
            // 
            // textBox_Radar15
            // 
            this.textBox_Radar15.Location = new System.Drawing.Point(504, 538);
            this.textBox_Radar15.Multiline = true;
            this.textBox_Radar15.Name = "textBox_Radar15";
            this.textBox_Radar15.Size = new System.Drawing.Size(240, 93);
            this.textBox_Radar15.TabIndex = 1;
            // 
            // textBox_Radar16
            // 
            this.textBox_Radar16.Location = new System.Drawing.Point(504, 340);
            this.textBox_Radar16.Multiline = true;
            this.textBox_Radar16.Name = "textBox_Radar16";
            this.textBox_Radar16.Size = new System.Drawing.Size(240, 93);
            this.textBox_Radar16.TabIndex = 1;
            // 
            // textBox_Radar17
            // 
            this.textBox_Radar17.Location = new System.Drawing.Point(504, 439);
            this.textBox_Radar17.Multiline = true;
            this.textBox_Radar17.Name = "textBox_Radar17";
            this.textBox_Radar17.Size = new System.Drawing.Size(240, 93);
            this.textBox_Radar17.TabIndex = 1;
            // 
            // textBox_Radar18
            // 
            this.textBox_Radar18.Location = new System.Drawing.Point(504, 241);
            this.textBox_Radar18.Multiline = true;
            this.textBox_Radar18.Name = "textBox_Radar18";
            this.textBox_Radar18.Size = new System.Drawing.Size(240, 93);
            this.textBox_Radar18.TabIndex = 1;
            // 
            // textBox_Radar19
            // 
            this.textBox_Radar19.Location = new System.Drawing.Point(750, 439);
            this.textBox_Radar19.Multiline = true;
            this.textBox_Radar19.Name = "textBox_Radar19";
            this.textBox_Radar19.Size = new System.Drawing.Size(240, 93);
            this.textBox_Radar19.TabIndex = 1;
            // 
            // textBox_Radar20
            // 
            this.textBox_Radar20.Location = new System.Drawing.Point(750, 538);
            this.textBox_Radar20.Multiline = true;
            this.textBox_Radar20.Name = "textBox_Radar20";
            this.textBox_Radar20.Size = new System.Drawing.Size(240, 93);
            this.textBox_Radar20.TabIndex = 1;
            // 
            // FormInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 648);
            this.Controls.Add(this.button_Stop);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.textBox_Radar20);
            this.Controls.Add(this.textBox_Radar18);
            this.Controls.Add(this.textBox_Radar12);
            this.Controls.Add(this.textBox_Radar19);
            this.Controls.Add(this.textBox_Radar6);
            this.Controls.Add(this.textBox_Radar17);
            this.Controls.Add(this.textBox_Radar11);
            this.Controls.Add(this.textBox_Radar5);
            this.Controls.Add(this.textBox_Radar16);
            this.Controls.Add(this.textBox_Radar10);
            this.Controls.Add(this.textBox_Radar4);
            this.Controls.Add(this.textBox_Radar15);
            this.Controls.Add(this.textBox_Radar9);
            this.Controls.Add(this.textBox_Radar3);
            this.Controls.Add(this.textBox_Radar14);
            this.Controls.Add(this.textBox_Radar8);
            this.Controls.Add(this.textBox_Radar2);
            this.Controls.Add(this.textBox_Radar13);
            this.Controls.Add(this.textBox_Radar7);
            this.Controls.Add(this.textBox_Radar1);
            this.Controls.Add(this.textBox_Info);
            this.Controls.Add(this.label_DistThres);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_RadarCount);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormInfo";
            this.Text = "信息";
            this.Load += new System.EventHandler(this.FormInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_RadarCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_DistThres;
        private System.Windows.Forms.TextBox textBox_Info;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.Button button_Stop;
        private System.Windows.Forms.TextBox textBox_Radar1;
        private System.Windows.Forms.TextBox textBox_Radar2;
        private System.Windows.Forms.TextBox textBox_Radar3;
        private System.Windows.Forms.TextBox textBox_Radar4;
        private System.Windows.Forms.TextBox textBox_Radar5;
        private System.Windows.Forms.TextBox textBox_Radar6;
        private System.Windows.Forms.TextBox textBox_Radar7;
        private System.Windows.Forms.TextBox textBox_Radar8;
        private System.Windows.Forms.TextBox textBox_Radar9;
        private System.Windows.Forms.TextBox textBox_Radar10;
        private System.Windows.Forms.TextBox textBox_Radar11;
        private System.Windows.Forms.TextBox textBox_Radar12;
        private System.Windows.Forms.TextBox textBox_Radar13;
        private System.Windows.Forms.TextBox textBox_Radar14;
        private System.Windows.Forms.TextBox textBox_Radar15;
        private System.Windows.Forms.TextBox textBox_Radar16;
        private System.Windows.Forms.TextBox textBox_Radar17;
        private System.Windows.Forms.TextBox textBox_Radar18;
        private System.Windows.Forms.TextBox textBox_Radar19;
        private System.Windows.Forms.TextBox textBox_Radar20;
    }
}