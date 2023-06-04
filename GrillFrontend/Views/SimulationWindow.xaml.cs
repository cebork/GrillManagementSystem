using GrillBackend.Models.Abstractions;
using GrillBackend.Models.Enums;
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
    /// Logika interakcji dla klasy SimulationWindow.xaml
    /// </summary>
    public partial class SimulationWindow : Window
    {
        public SimulationWindow(Window parentWindow)
        {
            Owner = parentWindow;
            InitializeComponent();
            //List<IGrillable> list = new List<IGrillable>(); 
            //foreach (var item in MainWindow.grillLogic.CurrentGrill.MealsPrepared)
            //{
            //    if(item is IGrillable)
            //    {
            //        list.Add((IGrillable)item);
            //    }
            //}
            //allMealsList.ItemsSource = list;
            allMealsList.ItemsSource = MainWindow.grillLogic.CurrentGrill.MealsPrepared;
            atGrillList.ItemsSource = MainWindow.grillLogic.CurrentGrill.MealsAtGrill;
            readyList.ItemsSource = MainWindow.grillLogic.CurrentGrill.MealsGrilled;

        }

        private void ButtonEndGrill_Click(object sender, RoutedEventArgs e)
        {

            MainWindow.grillLogic.ChangeStatus(Status.Ended);
            Close();
        }

        private void ButtonToGrill_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.grillLogic.PutMealOnGrill((IGrillable)((FrameworkElement)sender).DataContext);
            allMealsList.Items.Refresh();
            atGrillList.Items.Refresh();
        }

        private void ButtonGetFromGrill_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.grillLogic.TakeMealFromGrill((IGrillable)((FrameworkElement)sender).DataContext);
            atGrillList.Items.Refresh();
            readyList.Items.Refresh();

        }

        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
            e.Handled = true;
        }
    }
}
