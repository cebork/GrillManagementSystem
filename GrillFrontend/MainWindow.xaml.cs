using GrillBackend.Logic;
using GrillFrontend.Views;
using System.Windows;

namespace GrillFrontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static GrillLogic grillLogic = new GrillLogic();
        public MainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            grillLogic.GetAllGrillMembersDistincted();
        }

        private void ButtonNewGrill_Click(object sender, RoutedEventArgs e)
        {
            NewGrillWindow newGrillWindow = new NewGrillWindow(this);
            Opacity = 0.4;
            newGrillWindow.ShowDialog();
            Opacity = 1;
        }

        private void ButtonGrillList_Click(object sender, RoutedEventArgs e)
        {
            ListOfGrills listOfGrills = new ListOfGrills(this);
            Opacity = 0.4;
            listOfGrills.ShowDialog();
            Opacity = 1;
        }

        private void ButtonMembersList_Click(object sender, RoutedEventArgs e)
        {
            ListOfMembers listOfMembers = new ListOfMembers(this);
            Opacity = 0.4;
            listOfMembers.ShowDialog();
            Opacity = 1;
        }

    }
}
