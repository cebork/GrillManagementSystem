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

namespace GrillFrontend
{
    /// <summary>
    /// Logika interakcji dla klasy InvitePeopleWindow.xaml
    /// </summary>
    public partial class InvitePeopleWindow : Window
    {
        public InvitePeopleWindow(Window parentWindow)
        {
            Owner = parentWindow;
            InitializeComponent();
            Goscie.ItemsSource = MainWindow.grillLogic.GetGrillList();//zmienic na dostepne osob!!!!!!!!!
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            //parent.ShowDialog();
            Close();
        }
    }
}
