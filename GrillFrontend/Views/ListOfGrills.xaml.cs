using GrillBackend.Models.GrillStuff;
using GrillFrontend.Views;
using System.Windows;

namespace GrillFrontend
{
    /// <summary>
    /// Logika interakcji dla klasy ListOfGrills.xaml
    /// </summary>
    public partial class ListOfGrills : Window
    {
        public ListOfGrills(Window parentWindow)
        {
            Owner = parentWindow;
            InitializeComponent();
            lista.ItemsSource = MainWindow.grillLogic.grillList;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonDetails_Click(object sender, RoutedEventArgs e)
        {
            Grill selectedGrill = ((FrameworkElement)sender).DataContext as Grill;
            GrillDetailsWindow grillDetailsWindow = new GrillDetailsWindow(this, selectedGrill);
            grillDetailsWindow.ShowDialog();
            lista.Items.Refresh();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            Grill selectedGrill = ((FrameworkElement)sender).DataContext as Grill;
            MainWindow.grillLogic.RemoveGrill(selectedGrill);
            lista.Items.Refresh();
        }

        private void ButtonSimulation_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.grillLogic.CurrentGrill = ((FrameworkElement)sender).DataContext as Grill;
            SimulationWindow simulationWindow = new SimulationWindow(this);
            simulationWindow.ShowDialog();
            lista.Items.Refresh();
        }
    }

}
