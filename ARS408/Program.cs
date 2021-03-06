﻿using ARS408.Core;
using ARS408.Forms;
using ARS408.Model;
using CommonLib.Enums;
using CommonLib.Function;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARS408
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            BaseFunc.InitConfigs(); //配置初始化
            #region 测试
            //int level = BaseFunc.GetThreatLevelByValue(-999, RadarGroupType.Bucket);
            //int a = 1, b = 2;
            //    goto markb;
            //marka:
            //    a = 3;
            //markb:
            //    b = 4;
            //    int c = 5;
            //IPEndPoint point = (IPEndPoint)null;
            //string temp1 = false.ToString();
            //bool flag1 = bool.Parse(temp1);
            //temp1 = true.ToString();
            //DataFrameMessages info = new DataFrameMessages();
            //List<double> numbers = new List<double>() { 0, 0, 7.2, 7.4, 7.5, 7.6, 7.3, 7.1, 10, 10.2, 4, 3.8, 7.2, 10, 10.1, 10.2, 10.3, 10.2, 7, 10.2, 0, 0, 0, 0, 0 };
            //foreach (var number in numbers)
            //{
            //    info.IterateDistance(number);
            //}

            //List<FalseAlarmProbability> list = "".Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(p => (FalseAlarmProbability)int.Parse(p)).ToList();

            //string t = "";
            //MatchCollection matches = BaseConst.RegWrapped.Matches(t);
            //int i = 1;

            //string testie = string.Format("{0}", (int)Directions.Down);
            //testie = testie;
            //int t = '0' - '0';

            //double x = 1, y = 1, z = 1;
            //int m = 1;
            //double d = Math.Sqrt((Math.Sign(4 - m) == 1 ? 1 : 0) * Math.Pow(x, 2) + (Math.Sign(3 - m) == 1 ? 1 : 0) * Math.Pow(y, 2) + (Math.Sign(2 - m) == 1 ? 1 : 0) * Math.Pow(z, 2));
            ////int level = BaseFunc.GetThreatLevelByValue(-1);
            //int temp = 1;

            //Radar radar = new Radar() { DegreeYoz = -90, DegreeXoy = 0, DegreeXoz = -60, DegreeGeneral = 180 };
            //List<ObjectGeneral> list = new List<ObjectGeneral>() { new ObjectGeneral(null, radar) { DistLong = 2, DistLat = 2, Color = Color.FromArgb(255, 255, 0) }, new ObjectGeneral(null, radar) { DistLong = 5, DistLat = 5, Color = Color.FromArgb(255, 255, 0) }, new ObjectGeneral(null, radar) { DistLong = 3, DistLat = 3, Color = Color.FromArgb(255, 255, 0) }, new ObjectGeneral(null, radar) { DistLong = 1, DistLat = 1, Color = Color.FromArgb(255, 255, 0) } };
            //list.Sort((o1, o2) => o1.DistanceToBorder.CompareTo(o2.DistanceToBorder));
            //////BaseFunc.WriteMessagesToFile<ObjectGeneral>(list, false);
            ////BaseFunc.WriteMessagesToFile<ObjectGeneral>(list, true);
            //return;

            //string base64 = Convert.ToBase64String(File.ReadAllBytes("ars_coor.png")); //将文件转换为base64编码
            //File.WriteAllBytes("ars_coor1.png", Convert.FromBase64String(base64));

            //List<SensorMessage> list = new List<SensorMessage>();
            //list.Add(new ClusterGeneral());
            //list.Add(new ClusterGeneral());
            //list.Add(new ObjectGeneral());
            //list.Add(new ObjectGeneral());
            //int count1 = list.Count(m => m is ClusterGeneral), count2 = list.Count(m => m is ObjectGeneral);
            //List<ClusterGeneral> list = new List<ClusterGeneral>();
            //ClusterGeneral o = new ClusterGeneral();
            //o = (dynamic)o;

            //list.Add((dynamic)o);
            //ClusterGeneral g = Converter.Convert<ClusterGeneral>(o);
            //int temp = 1;

            //string test = "\r\nsometest".TrimEnd('\r', '\n');
            //test = "\r\n".TrimEnd('\r', '\n');

            //string t = Base.StartupPath;
            //byte r, g, b;
            //r = (g = (b = 120));
            //int rgb = ((int)r << 16 | (int)g << 8 | (int)b);

            //List<SensorMessage> messages = new List<SensorMessage>();
            //messages.Add(new ClusterGeneral());
            //messages.Add(new ClusterStatus());
            //foreach (var message in messages)
            //{
            //    Type type = message.GetType();
            //    string temp = message.GetType().ToString();
            //    int t = 1;
            //}

            //char[] cs = "05 00 00 06 00 0D 04 BF 43 10 00 00 00".ToCharArray();
            //byte b = Convert.ToByte("11001101", 2);
            //int msg_0;
            //byte sensor = BaseFunc.GetSensorIdByMessageId(0x721, out msg_0);
            //SensorMessageId_0 messageid = (SensorMessageId_0)msg_0;
            //string message = messageid.GetDescription();

            //int temp = 1;
            #endregion

            //double x = 100, y = 200, h = 20, phi = 75; //本地XY坐标与海拔，大臂航向
            //double rc = 45, hc = 10, lamda = 47.9457; //定位天线距俯仰轴距离，俯仰轴海拔，坝基方向与真北夹角
            //double x_prime = x - Math.Sqrt(Math.Pow(rc, 2) - Math.Pow(hc - h, 2)) * Math.Cos(phi - lamda);
            //double y_prime = y - Math.Sqrt(Math.Pow(rc, 2) - Math.Pow(hc - h, 2)) * Math.Sin(phi - lamda);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string argstring = args == null ? string.Empty : ";" + string.Join(";", args).ToUpper() + ";";
            int temp = 1;
            if (temp == 2)
                argstring = ";SINGLE;";
            Form form = argstring.Contains(";SINGLE;") ? (Form)new FormDisplay() : new FormMain();

            Application.Run(form);
        }
    }
}
