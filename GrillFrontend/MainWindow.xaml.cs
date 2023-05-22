using GrillBackend.Logic;
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

namespace GrillFrontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GrillLogic grillLogic=new GrillLogic();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("grill u kefirka :ooo");
            NewGrillWindow newGrill= new NewGrillWindow(this);
            Opacity = 0.4;
            newGrill.ShowDialog();
            Opacity = 1;
            
        }
    }
}
