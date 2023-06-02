using GrillBackend.Models.GrillStuff;
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

namespace GrillFrontend.Views
{
    /// <summary>
    /// Logika interakcji dla klasy ListOfMembers.xaml
    /// </summary>
    public partial class ListOfMembers : Window
    {
        public ListOfMembers(Window parentWindow)
        {
            Owner = parentWindow;
            InitializeComponent();
            members.ItemsSource = MainWindow.grillLogic.MemberList;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
