using GrillBackend.Models.GrillStuff;
using System;
using System.Windows;

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
