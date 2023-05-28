using GrillBackend.Models.GrillStuff;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GrillFrontend.Views
{
    /// <summary>
    /// Logika interakcji dla klasy UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1(Window parentWindow)
        {
            InitializeComponent();


            lista.ItemsSource = MainWindow.grillLogic.GetGrillList();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ButtonDetails_Click(object sender, RoutedEventArgs e)
        {
            Grill selectedGrill = ((FrameworkElement)sender).DataContext as Grill;
            //GrillDetailsWindow grillDetailsWindow = new GrillDetailsWindow(this, selectedGrill);
            //grillDetailsWindow.ShowDialog();


        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            Grill selectedGrill = ((FrameworkElement)sender).DataContext as Grill;
            MainWindow.grillLogic.RemoveGrill(selectedGrill);
            //ListOfGrills listOfGrills = new ListOfGrills(this);
            //listOfGrills.ShowDialog();
        }
    }
}
