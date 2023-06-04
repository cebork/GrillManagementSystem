using GrillBackend.Exceptions;
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
            try
            {
                MainWindow.grillLogic.ChangeStack((IGrillable)((FrameworkElement)sender).DataContext, MainWindow.grillLogic.CurrentGrill.MealsAtGrill);
                allMealsList.Items.Refresh();
                atGrillList.Items.Refresh();
            }
            catch (NoFoodException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonGetFromGrill_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow.grillLogic.ChangeStack((IGrillable)((FrameworkElement)sender).DataContext, MainWindow.grillLogic.CurrentGrill.MealsGrilled);
                atGrillList.Items.Refresh();
                readyList.Items.Refresh();
            }
            catch (NoFoodException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
            e.Handled = true;
        }

        private void ButtonFeedAll_Click(object sender, RoutedEventArgs e)
        {
            string eated = "";
            MainWindow.grillLogic.FeedEveryoneWithGrillable(
                new GrillBackend.Logic.GrillLogic.MealGrillMemberFeededDelegate((meal, grillMember) =>
                {
                    readyList.Items.Refresh();
                    eated += grillMember.Name + " " + grillMember.Surname + " zjadł " + meal.Name + "\n";
                    
                }),
                new GrillBackend.Logic.GrillLogic.MealGrillMemberNotFeededDelegate(grillMember =>
                {
                    eated += grillMember.Name + " " + grillMember.Surname + " nic nie zjadł bo siem skomczyło :(\n";
                })
            );
            MessageBox.Show(eated);
        }
    }
}
