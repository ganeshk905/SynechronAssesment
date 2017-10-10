using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SynechronAssesment
{
    /// <summary>
    /// Interaction logic for OfferTextControl.xaml
    /// </summary>
    public partial class OfferTextControl : UserControl
    {
        ViewModel.SplashScreenVM ssvm = new ViewModel.SplashScreenVM();
        BackgroundWorker _backgroundWorker;
        private delegate void ShowDelegate(string txt);
        private delegate void HideDelegate();
        ShowDelegate showDelegate;
        HideDelegate hideDelegate;
        //our delegate used for updating the UI
        DispatcherTimer _timer;
        Storyboard Showboard;
        public OfferTextControl()
        {
            InitializeComponent();
            this.DataContext = ssvm;
            showDelegate = new ShowDelegate(this.showText);
            Showboard = this.Resources["showStoryBoard"] as Storyboard;
            _timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(5000) };
            _timer.Tick += new EventHandler(TimerTick);
            _timer.Start();
        }


        private void showText(string txt)
        {
            ssvm.SplashScreenOffersText = txt;
            BeginStoryboard(Showboard);

        }
        private void TimerTick(object sender, EventArgs e)
        {
            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.DoWork += backgroundWorker_DoWork;
            if (!_backgroundWorker.IsBusy)
                _backgroundWorker.RunWorkerAsync(ssvm.AddOffersinList().ToList());

        }

        private Object thisLock = new Object();
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            List<string> list = (List<string>)e.Argument;
            Parallel.ForEach(list, item =>
            {
                lock (thisLock)
                {

                    Dispatcher.Invoke(new Action(() => { showDelegate(item.ToString()); }));
                    Thread.Sleep(2000);
                }

            }
           );

        }
    }
}
