using GrillBackend.Exceptions;
using GrillBackend.Models.GrillStuff;
using System.Windows;

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
            try
            {
                MainWindow.grillLogic.AddNewMember(new GrillMember(Name.Text, Surname.Text, Email.Text));
                Close();
            }
            catch (WrongInputsException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (GrillMemberAlreadyExistsException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
