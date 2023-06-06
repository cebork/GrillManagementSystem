using System.Windows;

namespace GrillFrontend.Views
{
    /// <summary>
    /// Logika interakcji dla klasy ListOfMembers.xaml
    /// </summary>
    public partial class ListOfMembers : Window
    {
        public ListOfMembers(Window parentWindow)
        {
            Owner = parentWindow;
            InitializeComponent();
            members.ItemsSource = MainWindow.grillLogic.MemberList;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
