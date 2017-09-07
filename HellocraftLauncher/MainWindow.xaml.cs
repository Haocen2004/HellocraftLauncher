using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using KMCCC.Launcher;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static KMCCC.Launcher.Reporter;
using KMCCC.Authentication;


namespace HellocraftLauncher
{
    public static LauncherCore Core = LauncherCore.Create();
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            Reporter.SetClientName("Hellocraft Launcher v0.1 beta");
            Reporter.SetReportLevel(ReportLevel.Full);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var versions = Program.Core.GetVersions().ToArray();
            var ver = (KMCCC.Launcher.Version)comboBox1.SelectedItem;
            var result = Program.Core.Launch(new LaunchOptions
            {
                Version = ver, //Ver为Versions里你要启动的版本名字
                MaxMemory = 1024, //最大内存，int类型
                Authenticator = new YggdrasilLogin("haocen.minecraft@qq.com", "sz123433900", false),
                Mode = LaunchMode.MCLauncher, //启动模式，这个我会在后面解释有哪几种
                Size = new WindowSize { Height = 768, Width = 1280 } //设置窗口大小，可以不要
            });

            MessageBox.Show("game loading","Hellocraft");
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
