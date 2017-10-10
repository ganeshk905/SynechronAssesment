using SynechronAssesment.HelperClasses;
using SynechronAssesment.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using static SynechronAssesment.HelperClasses.SplashHelper;

namespace SynechronAssesment
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string Unique = "EasySplashScreen";

        [STAThread]
        public static void Main()
        {

            try
            {
                SplashHelper.SplashScreen = new SplashScreenView();
                SplashHelper.Show();

                System.Windows.Threading.Dispatcher.Run();

            }
            catch (Exception ex)
            {

                throw;
            }



        }
    }
}
