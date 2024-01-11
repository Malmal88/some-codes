using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDI_ученики
{
    internal class DataContext
    {
        public static ObservableCollection<Student> Students = new ObservableCollection<Student>();
        public static ObservableCollection<Teacher> Teachers = new ObservableCollection<Teacher>();
        public static ObservableCollection<Class> Classes = new ObservableCollection<Class>();
        public static List<Student> temp=new List<Student>();
        public static int counter = 1;

    }
}
