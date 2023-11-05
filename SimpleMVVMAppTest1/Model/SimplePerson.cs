using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// migrated using Microsoft.Toolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SimpleMVVMAppTest1.Model
{
    public partial class SimplePerson : ObservableObject
    {
        [ObservableProperty]  // spares the getter setter
        private string lastName = string.Empty;

        //public string LastName
        //{
        //    get { return lastName; }
        //    set { SetProperty(ref lastName, value); }
        //}

        [ObservableProperty]
        private string sureName = string.Empty;

        //public string SureName
        //{
        //    get { return sureName; }
        //    set { SetProperty(ref sureName, value); }
        //}

        [ObservableProperty]
        private ObservableCollection<string> childs = new(); // new ObservableCollection<string>();

        //public ObservableCollection<string> Childs
        //{
        //    get { return childs; }
        //    set { SetProperty(ref childs, value); }
        //}

        //public SimplePerson()
        //{
        //    childs = new ObservableCollection<string>();
        //    lastName = string.Empty;
        //    sureName = string.Empty;
        //}
    }
}
