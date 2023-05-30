using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GrillBackend.Models.GrillStuff;
using GrillFrontend.ViewModels;

namespace GrillFrontend
{
    /// <summary>
    /// Logika interakcji dla klasy InvitePeopleWindow.xaml
    /// </summary>
    public partial class InvitePeopleWindow : Window
    {
        public ObservableCollection<ViewModels.ListBoxItem> Items { get; set; }

        public InvitePeopleWindow(Window parentWindow,Grill grill)
        {
            Owner = parentWindow;
            InitializeComponent();
            MainWindow.grillLogic.CurrentGrill= grill;
            Items = new ObservableCollection<ViewModels.ListBoxItem>();
            List<GrillMember> members = MainWindow.grillLogic.getAllGrillMembersDistincted();
            foreach (GrillMember member in members)
            {
                Items.Add(new ViewModels.ListBoxItem(member,false));
            }
            
            Goscie.ItemsSource = Items;
        }

        private void ButtonInvite_Click(object sender, RoutedEventArgs e)
        {
            List<ViewModels.ListBoxItem> checkedItems = new List<ViewModels.ListBoxItem>();

            foreach (ViewModels.ListBoxItem item in Items)
            {
                if (item.IsSelected)
                {
                    checkedItems.Add(item);
                }
            }

            foreach (ViewModels.ListBoxItem item in checkedItems)
            {
                MainWindow.grillLogic.AddNewMemeberToGrill((GrillMember)item.Item);
            }

            Close();
        }
    }
}
