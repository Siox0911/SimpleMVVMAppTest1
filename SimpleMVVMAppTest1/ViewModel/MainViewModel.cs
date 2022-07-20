using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Windows.Input;
using System.Collections;

namespace SimpleMVVMAppTest1.ViewModel
{
    public class MainViewModel : ObservableRecipient
    {
        private Model.SimplePerson person;

        public Model.SimplePerson Person
        {
            get { return person; }
            set { SetProperty(ref person, value); }
        }

        public ICommand ClearName { get; }
        public ICommand DeleteChildName { get; }
        public ICommand ResetData { get; }

        public MainViewModel()
        {
            person = new Model.SimplePerson();
            ClearName = new RelayCommand(ClearNameOfPerson);
            DeleteChildName = new RelayCommand<IList>(DeleteNameOfChildFromList);
            ResetData = new RelayCommand(GenerateSampleData);

            GenerateSampleData();
        }

        private void GenerateSampleData()
        {
            Person.SureName = "Otto";
            Person.LastName = "Bismark";
            Person.Childs = new System.Collections.ObjectModel.ObservableCollection<string> { "Wilhelm", "Marie", "Herbert" };
        }

        private void DeleteNameOfChildFromList(IList? obj)
        {
            if (obj != null)
            {
                //ist etwas tricky
                var copyOfSelectedItems = ((IList<object>)obj).ToList();

                foreach (string item in copyOfSelectedItems)
                {
                    Person.Childs.Remove(item);
                }
            }
        }

        private void ClearNameOfPerson()
        {
            Person.LastName = String.Empty;
            Person.SureName = String.Empty;
        }
    }
}
