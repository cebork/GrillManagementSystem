using GrillBackend.Models.GrillStuff;
using System;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace GrillFrontend.Views
{
    /// <summary>
    /// Logika interakcji dla klasy EditGrillWindow.xaml
    /// </summary>
    public partial class EditGrillWindow : Window
    {
        public ObservableCollection<ViewModels.ListBoxItem> Items { get; set; }
        public EditGrillWindow(Window parent, Grill grill)
        {
            Owner = parent;
            InitializeComponent();
            Items = new ObservableCollection<ViewModels.ListBoxItem>();
            foreach (GrillMember member in MainWindow.grillLogic.MemberList)
            {
                if (MainWindow.grillLogic.CurrentGrill.GrillMembers.Contains(member))
                {
                    Items.Add(new ViewModels.ListBoxItem(member, true));
                }
                else
                {
                    Items.Add(new ViewModels.ListBoxItem(member, false));
                }
            }
            Goscie.ItemsSource = Items;
            DataContext = grill;        
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            DateTime? data1 = (Date.SelectedDate.HasValue ? Date.SelectedDate.Value : MainWindow.grillLogic.CurrentGrill.DateOfGrillStart);
            TimeSpan time1 = (Time.Value.HasValue ? Time.Value.Value.TimeOfDay : MainWindow.grillLogic.CurrentGrill.DateOfGrillStart.Value.TimeOfDay);
            List<ViewModels.ListBoxItem> checkedItems = new List<ViewModels.ListBoxItem>();
            foreach (ViewModels.ListBoxItem item in Items)
            {
                if (item.IsSelected)
                {
                    checkedItems.Add(item);
                }
            }
            List<GrillMember> pom = new List<GrillMember>();
            foreach (ViewModels.ListBoxItem item in checkedItems)
            {
                pom.Add((GrillMember)item.Item);
            }
            MainWindow.grillLogic.EditGrill(Name.Text, Description.Text, data1.Value.Date + time1, pom);
            Close();
            Owner.Close();
        }

        private void ButtonNewMember_Click(object sender, RoutedEventArgs e)
        {
            NewMember newMember = new NewMember(this);
            Opacity = 0.4;
            newMember.ShowDialog();
            foreach (ViewModels.ListBoxItem item in Items)
            {
                if (item.IsSelected)
                {
                    MainWindow.grillLogic.CurrentGrill.GrillMembers.Add((GrillMember)item.Item);
                }
            }
            Items.Clear();

            foreach (GrillMember member in MainWindow.grillLogic.MemberList)
            {
                if (MainWindow.grillLogic.CurrentGrill.GrillMembers.Contains(member))
                {
                    Items.Add(new ViewModels.ListBoxItem(member, true));
                }
                else
                {
                    Items.Add(new ViewModels.ListBoxItem(member, false));
                }
            }
            Goscie.ItemsSource = Items;
            Goscie.Items.Refresh();
            Opacity = 1;
        }
    }
}
