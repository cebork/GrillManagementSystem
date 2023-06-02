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
            List<GrillMember> members = MainWindow.grillLogic.getAllGrillMembersDistincted();
            foreach (GrillMember member in members)
            {
                Items.Add(new ViewModels.ListBoxItem(member, false));
            }
            //MainWindow.grillLogic.CurrentGrill = grill;
            Goscie.ItemsSource = Items;
            DataContext = grill;
            //Goscie.ItemsSource = grill.GrillMembers;
            //Goscie.ItemsSource = MainWindow.grillLogic.GetGrillList();            
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
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
            //MainWindow.grillLogic.CurrentGrill = grill;
            List<GrillMember> pom = new List<GrillMember>();
            foreach (ViewModels.ListBoxItem item in checkedItems)
            {
                pom.Add((GrillMember)item.Item);
            }
            MainWindow.grillLogic.EditGrill(Name.Text, Description.Text, data1.Value.Date + time1, pom);
            //MessageBox.Show(MainWindow.grillLogic.CurrentGrill.ToString());
            Close();
            Owner.Close();
        }

        private void ButtonNewMember_Click(object sender, RoutedEventArgs e)
        {
            NewMember newMember = new NewMember(this);
            Opacity = 0.4;
            newMember.ShowDialog();
            Items = new ObservableCollection<ViewModels.ListBoxItem>();
            List<GrillMember> members = MainWindow.grillLogic.getAllGrillMembersDistincted();
            foreach (GrillMember member in members)
            {
                Items.Add(new ViewModels.ListBoxItem(member, false));
            }
            //MainWindow.grillLogic.CurrentGrill = grill;
            Goscie.ItemsSource = Items;
            //DataContext = grill;
            Goscie.Items.Refresh();

            Opacity = 1;
        }

        //private void myCheckBox_Loaded(object sender, RoutedEventArgs e)
        //{
        //    CheckBox checkBox = (CheckBox)sender;
        //    GrillMember member = (GrillMember)checkBox.DataContext;

        //    checkBox.IsChecked = MainWindow.grillLogic.CurrentGrill.GrillMembers.Contains(member) ? true : false;
        //}
    }
}
