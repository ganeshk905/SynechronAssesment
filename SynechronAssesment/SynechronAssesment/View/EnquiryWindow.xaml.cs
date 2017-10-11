using SynechronAssesment.HelperClasses;
using SynechronAssesment.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SynechronAssesment.View
{
    /// <summary>
    /// Interaction logic for EnquiryWindow.xaml
    /// </summary>
    public partial class EnquiryWindow : Window
    {
        public EnquiryWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
            (this.DataContext as MainWindowViewModel).ShowMessageBox += delegate (object sender, EventArgs args)
            {
                MessageBox.Show(((MessageEventArgs)args).Message);
            };
        }
    }
}
