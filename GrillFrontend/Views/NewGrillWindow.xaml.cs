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
        public delegate void ButtonClickHandler(object sender, RoutedEventArgs e);
        public event ButtonClickHandler onButtonClicked;
        //Opacity = 0.4;
        public NewGrillWindow(Window parentWindow)
        {
            Owner = parentWindow;
            InitializeComponent();

            //onButtonClicked += ButtonOK_Click;
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text != null && Date.SelectedDate.HasValue && Time.Value.HasValue)
            {
                Grill grill = new Grill(Name.Text, Date.SelectedDate.Value + Time.Value.Value.TimeOfDay, Description.Text);
                MainWindow.grillLogic.AddNewGrill(grill);
                InvitePeopleWindow invitePeopleWindow = new InvitePeopleWindow(Owner, grill);
                Close();
                invitePeopleWindow.ShowDialog();
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
