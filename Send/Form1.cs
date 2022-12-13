using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Send
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Start();// запуск таймеров
            timer2.Start();
           // timer3.Start();
            SetAutoRun(true, Assembly.GetExecutingAssembly().Location);
        }

        private void timer1_Tick(object sender, EventArgs e) // таймер запуска автонажатий раз в 15 мин
        {
            SendKeys.Send("f");
            SendKeys.Send("F");
        }
        private bool SetAutoRun(bool autoran,string path) // автозапуск программы 
        {
            const string name = "systems";
            string ExePath = path;
            RegistryKey reg;
            reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
            try
            {
                if (autoran)
                {
                    reg.SetValue(name, ExePath);
                }
                else
                {
                    reg.DeleteValue(name);
                }
                reg.Flush();
                reg.Close();
            }
            catch (Exception) { return false; }
            return true;
               
        }

        private void timer2_Tick(object sender, EventArgs e) // таймер запуска автонажатий раз в 10 мин
        {
            SendKeys.Send("А");
            SendKeys.Send("а");
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            Process[] localByName = Process.GetProcesses();
            foreach (Process pr in localByName)
            {
                if (pr.ProcessName == "browser.exe")
                {
                    pr.Kill();
                }
                if (pr.ProcessName == "browser")
                {
                    pr.Kill();
                }
                //if (pr.ProcessName == "cmd")
                //{
                //    pr.Kill();
                //}
            }
        } // убиваю процесс
    }
}
