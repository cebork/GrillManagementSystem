using GrillFrontend.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
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


            lista.ItemsSource = MainWindow.grillLogic.GetGrillList();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ButtonDetails_Click(object sender, RoutedEventArgs e)
        {
            //lista.SelectedItem();
            GrillDetailsWindow grillDetailsWindow = new GrillDetailsWindow(this);
            grillDetailsWindow.ShowDialog();
            //Close();

        }
    }

}
