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
using GrillBackend;
using GrillBackend.Logic;
using GrillBackend.Models;
using GrillBackend.Models.GrillStuff;
using GrillFrontend.Views;

namespace GrillFrontend
{
    /// <summary>
    /// Logika interakcji dla klasy NewGrillWindow.xaml
    /// </summary>
    public partial class NewGrillWindow : Window
    {
        //public ObservableCollection<ViewModels.ListBoxItem> Items { get; set; }
        //public delegate void ButtonClickHandler(object sender, RoutedEventArgs e);
        //public event ButtonClickHandler onButtonClicked;
        public NewGrillWindow(Window parentWindow)
        {
            Owner = parentWindow;
            InitializeComponent();
            //MainWindow.grillLogic.CurrentGrill = grill;
            //Items = new ObservableCollection<ViewModels.ListBoxItem>();
            //List<GrillMember> members = MainWindow.grillLogic.getAllGrillMembersDistincted();
            //foreach (GrillMember member in members)
            //{
            //    Items.Add(new ViewModels.ListBoxItem(member, false));
            //}

            //Goscie.ItemsSource = Items;
            //onButtonClicked += ButtonOK_Click;
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {

            if (Name.Text != null && Date.SelectedDate.HasValue && Time.Value.HasValue)
            {
                //List<ViewModels.ListBoxItem> checkedItems = new List<ViewModels.ListBoxItem>();
                Grill grill = new Grill(Name.Text, Date.SelectedDate.Value + Time.Value.Value.TimeOfDay, Description.Text);
                MainWindow.grillLogic.AddNewGrill(grill);
                //foreach (ViewModels.ListBoxItem item in Items)
                //{
                //    if (item.IsSelected)
                //    {
                //        checkedItems.Add(item);
                //    }
                //}
                //MainWindow.grillLogic.CurrentGrill = grill;
                //foreach (ViewModels.ListBoxItem item in checkedItems)
                //{
                //    MainWindow.grillLogic.AddNewMemeberToGrill((GrillMember)item.Item);
                //}
                
                InvitePeopleWindow invitePeopleWindow = new InvitePeopleWindow(this, grill);
                invitePeopleWindow.ShowDialog();
                Close();
            }
            else
                MessageBox.Show("Wprowadź wymagane dane");
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //private void ButtonNewMember_Click(object sender, RoutedEventArgs e)
        //{
        //    NewMember newMember = new NewMember(this);
        //    Opacity = 0.4;
        //    newMember.ShowDialog();
        //    Opacity = 1;
        //}
    }
}
