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
using GrillBackend;
using GrillBackend.Logic;
using GrillFrontend.Views;

namespace GrillFrontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static GrillLogic grillLogic= new GrillLogic();
        public MainWindow()
        {
            InitializeComponent();
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
            //UserControl1 userControl1 = new UserControl1();
            ListOfGrills listOfGrills = new ListOfGrills(this);
            Opacity = 0.4;
            listOfGrills.ShowDialog();
            Opacity = 1;
        }
    }
}
