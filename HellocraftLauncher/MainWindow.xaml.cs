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

namespace HellocraftLauncher
{

    public static LauncherCore Core = LauncherCore.Create();
    LauncherCore core = LauncherCore.Create(
    new LauncherCoreCreationOption(
        javaPath: Config.Instance.JavaPath, // by default it will be the first version finded
        gameRootPath: null, // by defualt it will be ./.minecraft/
        versionLocator: the Version Locator
    ));
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
            MessageBox.Show("game loading","Hellocraft");
        }
    }
}
