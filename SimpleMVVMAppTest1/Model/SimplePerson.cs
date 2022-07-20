using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace SimpleMVVMAppTest1.Model
{
    public class SimplePerson : ObservableObject
    {
        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { SetProperty(ref lastName, value); }
        }

        private string sureName;

        public string SureName
        {
            get { return sureName; }
            set { SetProperty(ref sureName, value); }
        }

        private ObservableCollection<string> childs;

        public ObservableCollection<string> Childs
        {
            get { return childs; }
            set { SetProperty(ref childs, value); }
        }

        public SimplePerson()
        {
            childs = new ObservableCollection<string>();
            lastName = string.Empty;
            sureName = string.Empty;
        }
    }
}
