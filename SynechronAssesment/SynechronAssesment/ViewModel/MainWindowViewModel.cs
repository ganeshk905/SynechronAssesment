
using SynechronAssesment.HelperClasses;
using SynechronAssesment.Model;
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
        private Person _person;
        public EventHandler ShowMessageBox = delegate { };
        public MainWindowViewModel()
        {
            _business = new Business();
            PersonCollection = new ObservableCollection<Person>(_business.Get());
        }

        private ObservableCollection<Person> personCollection;
        public ObservableCollection<Person> PersonCollection
        {
            get { return personCollection; }
            set
            {
                personCollection = value;
                OnPropertyChanged("PersonCollection");
            }
        }
        public Person SelectedPerson
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
                SelectedPerson = new Person();
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
                PersonCollection = new ObservableCollection<Person>(_business.Get());
                ShowMessageBox(this, new MessageEventArgs()
                {
                    Message = "Changes are saved !"
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
