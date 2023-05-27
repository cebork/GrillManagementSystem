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
using System.Windows.Shapes;
using GrillBackend;
using GrillBackend.Logic;
using GrillBackend.Models;
using GrillBackend.Models.GrillStuff;

namespace GrillFrontend
{
    /// <summary>
    /// Logika interakcji dla klasy NewGrillWindow.xaml
    /// </summary>
    public partial class NewGrillWindow : Window
    {
        public NewGrillWindow(Window parentWindow)
        {
            Owner = parentWindow;
            InitializeComponent();
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            Grill grill = new Grill(Name.Text, DateTime.Now);
            MainWindow.grillLogic.AddNewGrill(grill);
            MessageBox.Show(grill.ToString());
            Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
