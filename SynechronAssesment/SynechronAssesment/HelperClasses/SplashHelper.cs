using SynechronAssesment.View;
using SynechronAssesment.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace SynechronAssesment.HelperClasses
{
    internal class SplashHelper
    {
        public static SplashScreenView SplashScreen { get; set; }

        public static void Show()
        {
            if (SplashScreen != null)
                SplashScreen.Show();
        }

        public static void Hide()
        {
            if (SplashScreen == null) return;

            if (!SplashScreen.Dispatcher.CheckAccess())
            {
                Thread thread = new Thread(
                    new System.Threading.ThreadStart(
                        delegate ()
                        {
                            SplashScreen.Dispatcher.Invoke(
                                DispatcherPriority.Normal,
                                new Action(delegate ()
                                {
                                    Thread.Sleep(2000);
                                    SplashScreen.Hide();
                                }
                            ));
                        }
                ));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
            else
                SplashScreen.Hide();
        }

        public static void ShowText(string text)
        {
            if (SplashScreen == null) return;

            if (!SplashScreen.Dispatcher.CheckAccess())
            {
                Thread thread = new Thread(
                    new System.Threading.ThreadStart(
                        delegate ()
                        {
                            SplashScreen.Dispatcher.Invoke(
                                DispatcherPriority.Normal,

                                new Action(delegate ()
                                {
                                    ((SplashScreenVM)SplashScreen.DataContext).SplashScreenOffersText = text;
                                }
                            ));
                            SplashScreen.Dispatcher.Invoke(DispatcherPriority.ApplicationIdle, new Action(() => { }));
                        }
                ));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
            else
                ((SplashScreenVM)SplashScreen.DataContext).SplashScreenOffersText = text;
        }

    }
}
