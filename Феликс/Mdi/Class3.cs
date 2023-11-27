using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mdi
{
    public class ComboboxItem
    {
        public string Name { get; set; }
        public object Tag {  get; set; }
                
        public override string ToString()
        {
            return Name;
        }
    }
    
    
}
