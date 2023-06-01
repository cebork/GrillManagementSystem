using System;
using System.Collections.Generic;
using System.Data;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace GrillFrontend.Views
{
    /// <summary>
    /// Logika interakcji dla klasy NewMember.xaml
    /// </summary>
    public partial class NewMember : Window
    {
        public NewMember(Window parentWindow)
        {
            Owner = parentWindow;
            InitializeComponent();
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text != null && Surname.Text != null && Email.Text != null)
            {
                
                MainWindow.grillLogic.AddNewMemeberToGrill(new GrillMember(Name.Text, Surname.Text, Email.Text));
                MessageBox.Show(MainWindow.grillLogic.CurrentGrill.ToString());
                Close();
            }
            else
                MessageBox.Show("Wprowadź wymagane dane");
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
