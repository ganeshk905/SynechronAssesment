
using SynechronAssesment.HelperClasses;
using SynechronAssesment.Model;
using SynechronAssesment.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynechronAssesment.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        Business _business;
        private InformationCapture _person;
        public EventHandler ShowMessageBox = delegate { };

        public MainWindowViewModel()
        {
            AddPerson();
            _business = new Business();
            PersonCollection = new ObservableCollection<InformationCapture>(_business.Get());

        }

        EnquiryWindow _view;
        public EnquiryWindow View
        {
            get { return _view; }
            set
            {
                _view = value;
                OnPropertyChanged("View");
            }
        }

        private ObservableCollection<InformationCapture> personCollection;
        public ObservableCollection<InformationCapture> PersonCollection
        {
            get { return personCollection; }
            set
            {
                personCollection = value;
                OnPropertyChanged("PersonCollection");
            }
        }
        public InformationCapture SelectedPerson
        {
            get
            {
                return _person;
            }
            set
            {
                _person = value;
                OnPropertyChanged("SelectedPerson");
            }
        }


        public RelayCommand Add
        {
            get
            {
                return new RelayCommand(AddPerson, true);
            }
        }


        private void AddPerson()
        {
            try
            {
                SelectedPerson = new InformationCapture();
            }
            catch (Exception ex)
            {
                ShowMessageBox(this, new MessageEventArgs()
                {
                    Message = ex.Message
                });
            }
        }

        public RelayCommand Save
        {
            get
            {
                return new RelayCommand(SavePerson, true);
            }
        }

        private void SavePerson()
        {
            try
            {

                _business.Update(SelectedPerson);
                PersonCollection = new ObservableCollection<InformationCapture>(_business.Get());
                ShowMessageBox(this, new MessageEventArgs()
                {
                    Message = "Information Saved Successfully!! \nPlease check your email for more offers"
                });
            }
            catch (Exception ex)
            {
                ShowMessageBox(this, new MessageEventArgs()
                {
                    Message = ex.Message
                });
            }

        }

        public RelayCommand Delete
        {
            get
            {
                return new RelayCommand(DeletePerson, true);
            }
        }

        private void DeletePerson()
        {
            _business.Delete(SelectedPerson);
        }
    }
}
