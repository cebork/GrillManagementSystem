using System;
using System.Collections;
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
using System.Windows.Shapes;
using GrillBackend.Models.GrillStuff;

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
