using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using GrillFrontend.Views;

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

            if (Name.Text != null && Date.SelectedDate.HasValue && Time.Value.HasValue)
            {
                if (Date.SelectedDate.Value + Time.Value.Value.TimeOfDay >= DateTime.Now)
                {
                    Grill grill = new Grill(Name.Text, Date.SelectedDate.Value + Time.Value.Value.TimeOfDay, Description.Text);
                    MainWindow.grillLogic.AddNewGrill(grill);
                    MainWindow.grillLogic.CurrentGrill = grill;
                    InvitePeopleWindow invitePeopleWindow = new InvitePeopleWindow(this);
                    invitePeopleWindow.ShowDialog();
                    Close();
                }
                else
                    MessageBox.Show("Grill nie może odbyć się w przyszłości");
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
