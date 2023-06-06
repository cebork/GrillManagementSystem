using GrillBackend.Models.GrillStuff;
using System.Windows;

namespace GrillFrontend.Views
{
    /// <summary>
    /// Logika interakcji dla klasy GrillDetailsWindow.xaml
    /// </summary>
    public partial class GrillDetailsWindow : Window
    {
        public GrillDetailsWindow(Window parent, Grill grill)
        {
            Owner = parent;
            InitializeComponent();
            DataContext = grill;
            Goscie.ItemsSource = grill.GrillMembers;
            MainWindow.grillLogic.CurrentGrill = grill;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            EditGrillWindow editGrillWindow = new EditGrillWindow(this, MainWindow.grillLogic.CurrentGrill);
            editGrillWindow.ShowDialog();
        }
    }
}
