using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// migrated using Microsoft.Toolkit.Mvvm.ComponentModel;
// using Microsoft.Toolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using System.Collections;
using CommunityToolkit.Mvvm.Messaging;
using SimpleMVVMAppTest1.Model;

namespace SimpleMVVMAppTest1.ViewModel
{
    public sealed record RelayPerson(SimplePerson Person); // "stiller Briefkasten" central record/data that's exchanged by the CommunityToolkit's mechanisms

    // migrated to partial class
    // public class MainViewModel : ObservableRecipient
    public partial class MainViewModel : ObservableRecipient
    {
        [ObservableProperty]  // class may not have a ctor that's why person initialized here
        // private Model.SimplePerson person = new SimplePerson { SureName = "Otto", LastName = "Bismarck", Childs = { "Wilhelm", "Marie", "Herbert" }  };
        private Model.SimplePerson person = new() { SureName = "Otto", LastName = "Bismarck", Childs = { "Wilhelm", "Marie", "Herbert" } };

        [RelayCommand]
        private void GenerateSampleData() // method name must by appended "Command" in XAML
        {
            Person.SureName = "Otto";
            Person.LastName = "Bismark";
            Person.Childs = new System.Collections.ObjectModel.ObservableCollection<string> { "Wilhelm", "Marie", "Herbert" };
            WeakReferenceMessenger.Default.Send(new RelayPerson(Person)); // ~NotifyPropertyChanged
        }

        [RelayCommand]
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
            WeakReferenceMessenger.Default.Send(new RelayPerson(Person));
        }

        [RelayCommand]
        private void ClearNameOfPerson()
        {
            Person.LastName = String.Empty;
            Person.SureName = String.Empty;
            WeakReferenceMessenger.Default.Send(new RelayPerson(Person));
        }
    }
}
