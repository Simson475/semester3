using Caliburn.Micro;
using MVVMWPCaliburnMicroV2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVVMWPCaliburnMicroV2.ViewModels
{
    class ShellViewModel : Conductor<object>
    {
        private string _FirstName = "Tim";
        private string _LastName;
        private BindableCollection<PersonModel> _People = new BindableCollection<PersonModel>();
        private PersonModel _selectedPerson;

        public ShellViewModel()
        {
            People.Add(new PersonModel { FirstName = "Simon", LastName = "Nielsen" });
            People.Add(new PersonModel { FirstName = "Bill", LastName = "Cosby" });
            People.Add(new PersonModel { FirstName = "Charlie", LastName = "Sheen" });
            People.Add(new PersonModel { FirstName = "Vladimir", LastName = "Putin" });

            foreach (var item in Machines)
            {
                Tabs.Add(new MachineViewModel(item));
            }

        }

        public List<string> Machines { get; set; } = new List<string>() { "OKU", "OKR" };
        public List<IMainScreenTabItem> Tabs { get; set; } = new List<IMainScreenTabItem>();

        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                _FirstName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public string LastName
        {
            get { return _LastName; }
            set
            {
                _LastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);

            }
        }

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        public BindableCollection<PersonModel> People
        {
            get { return _People; }
            set { _People = value; }
        }

        public PersonModel SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
                NotifyOfPropertyChange(() => SelectedPerson);
            }
        }

        public bool CanClearText(string firstName, string lastName)
        {
            return !String.IsNullOrWhiteSpace(firstName) || !String.IsNullOrWhiteSpace(lastName);
        }
        public void ClearText(string firstName, string lastName)
        {
            FirstName = "";
            LastName = "";
        }

        public void LoadPageOne()
        {
            ActivateItemAsync(new FirstChildViewModel());
        }

        public void LoadPageTwo()
        {
            ActivateItemAsync(new SecondChildViewModel());
        }
    }
    public interface IMainScreenTabItem : IScreen
    {

    }
}
