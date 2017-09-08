using KMCCC.Authentication;
using KMCCC.Launcher;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using Version = KMCCC.Launcher.Version;

namespace Launcher
{
    public partial class Form1 : Form
    {
                public Form1()
        {
            InitializeComponent();
            var versions = Program.Core.GetVersions().ToArray();
            var last = Config.LastVersion;
            if (versions.Count(ver => ver.Id == last) > 0)
            {
                Listversions.SelectedItem = versions.First(ver => ver.Id == last);
            }
            else if (versions.Any())
            {
                Listversions.SelectedItem = versions[0];
            }
            Listversions.DataSource = versions;//绑定数据源
            Listversions.DisplayMember = "Id";//设置comboBox显示的为版本Id
        }

        private void ListVersions_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ver = (Version)Listversions.SelectedItem;
            var result = Program.Core.Launch(new LaunchOptions
            {
                Version = ver, //Ver为Versions里你要启动的版本名字
                MaxMemory = 1024, //最大内存，int类型
                Authenticator = new YggdrasilLogin("haocen.minecraft@qq.com", "sz123433900", false),
                Mode = LaunchMode.BmclMode, //启动模式，这个我会在后面解释有哪几种
                Size = new WindowSize { Height = 768, Width = 1280 } //设置窗口大小，可以不要
            });
            Config.LastVersion = ver.Id;
             if (!result.Success)
            {
                switch (result.ErrorType)
                {
                    case ErrorType.NoJAVA:
                    case ErrorType.AuthenticationFailed:
                        break;
                }
            }
            else
            {
                Hide();
            }
        }

    }
}
