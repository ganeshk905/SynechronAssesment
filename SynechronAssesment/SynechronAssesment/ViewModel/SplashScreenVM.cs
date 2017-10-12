using SynechronAssesment.HelperClasses;
using SynechronAssesment.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace SynechronAssesment.ViewModel
{
    class SplashScreenVM : ViewModelBase, INotifyPropertyChanged
    {
        private string splashScreenOffersText = "Initializing...Banking App";
        List<string> ListOffers = new List<string> { "Get More ROI", "New Saving Scheme", "Get Better Future using SIP", "Pension Scheme Launced","Easy Home Loans" ,"Morgage Facility Avialable" ,"High Interest Paid" };


        public string SplashScreenOffersText
        {
            get { return splashScreenOffersText; }
            set
            {
                splashScreenOffersText = value;
                OnPropertyChanged("SplashScreenOffersText");
            }
        }


        public string GetRandomOffersFromCollection()
        {
            Random rnd = new Random();

            int r = rnd.Next(ListOffers.Count);
            string OfferStr = (string)ListOffers[r];
            // ListOffers.Remove(OfferStr);
            return OfferStr;
        }


        public IList<string> AddOffersinList()
        {

            return ListOffers;
        }

        public SplashScreenVM(SplashScreenView view)
        {
            _view = view;
        }

        public SplashScreenVM()
        {

        }
        private void TimerTick(object sender, EventArgs e)
        {
            SplashScreenOffersText = GetRandomOffersFromCollection();
            Thread.Sleep(2000);
        }
        private void showText(string txt)
        {
            SplashScreenOffersText = txt;
            //   BeginStoryboard(Showboard);
        }
        private void hideText()
        {
            //  BeginStoryboard(Hideboard);
        }

        SplashScreenView _view;
        public SplashScreenView View
        {
            get { return _view; }
            set
            {
                _view = value;
                OnPropertyChanged("View");
            }
        }

        public RelayCommand ShowMoreCommand
        {
            get
            {
                return new RelayCommand(ShowEnquiry, true);
            }
        }

        private void ShowEnquiry()
        {

            MainWindowViewModel oMV = new MainWindowViewModel();

            EnquiryWindow oEnquiryWindow = new EnquiryWindow();
            oEnquiryWindow.DataContext = oMV;
            oEnquiryWindow.ShowDialog();

            //_view.Close();
        }
    }


}
