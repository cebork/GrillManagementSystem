using GrillBackend.Models.GrillStuff;
using GrillFrontend.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace GrillFrontend
{
    /// <summary>
    /// Logika interakcji dla klasy InvitePeopleWindow.xaml
    /// </summary>
    public partial class InvitePeopleWindow : Window
    {
        public ObservableCollection<ViewModels.ListBoxItem> Items { get; set; }
        public List<GrillMember> TempGrillMembers { get; set; }
        public InvitePeopleWindow(Window parentWindow)
        {
            Owner = parentWindow;
            InitializeComponent();
            Items = new ObservableCollection<ViewModels.ListBoxItem>();
            foreach (GrillMember member in MainWindow.grillLogic.MemberList)
            {
                Items.Add(new ViewModels.ListBoxItem(member, false));
            }
            Goscie.ItemsSource = Items;
            TempGrillMembers = new List<GrillMember>();
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
            if (checkedItems.Count != 0)
            {
                MainWindow.grillLogic.CurrentGrill.GrillMembers.Clear();
                foreach (ViewModels.ListBoxItem item in checkedItems)
                {
                    MainWindow.grillLogic.AddNewMemeberToGrill((GrillMember)item.Item);
                }
                Close();
            }
            else
            {
                MessageBox.Show("Zaproś kogoś :)");
            }
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
