using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrillFrontend.ViewModels
{
    public class ListBoxItem
    {
        public object Item { get; set; }
        public bool IsSelected { get; set; }
        public ListBoxItem() { }

        public ListBoxItem(object item, bool isSelected)
        {
            Item = item;
            IsSelected = isSelected;
        }
    }
}
