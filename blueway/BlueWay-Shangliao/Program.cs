﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueWay_Shangliao
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginDlg login = new LoginDlg();
            login.ShowDialog();
            
            if(login.DialogResult == DialogResult.OK)
            {
                Application.Run(new Form1());
            }
            else
            {
                return;
            }
        }
    }
}
