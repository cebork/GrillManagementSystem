using GrillBackend.Exceptions;
using GrillBackend.Models.Abstractions;
using GrillBackend.Models.Enums;
using GrillBackend.Models.GrillStuff;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

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
            Title = MainWindow.grillLogic.CurrentGrill.Name;
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
            selectMember.ItemsSource = MainWindow.grillLogic.CurrentGrill.GrillMembers;
            selectMeal.ItemsSource = MainWindow.grillLogic.CurrentGrill.MealsPrepared;
            Closing += SimulationWindow_Closing;
            closeButton.Click += ButtonEndGrill_Click;

            MainWindow.grillLogic.MealGrillMemberDrinked += (meal, grillMember)
                => MessageBox.Show(grillMember.Name + " " + grillMember.Surname + " wypił/a " + meal.Name);

            MainWindow.grillLogic.MealGrillMemberEatGrilled += (meal, grillMember)
                => MessageBox.Show(grillMember.Name + " " + grillMember.Surname + " zjadł/a z grilla " + meal.Name);

            MainWindow.grillLogic.MealGrillMemberEatNotGrilled += (meal, grillMember)
                => MessageBox.Show(grillMember.Name + " " + grillMember.Surname + " zjadł/a " + meal.Name);
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
                MainWindow.grillLogic.ChangeStack((IGrillable)((FrameworkElement)sender).DataContext, MainWindow.grillLogic.CurrentGrill.MealsAtGrill, true);
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
                MainWindow.grillLogic.ChangeStack((IGrillable)((FrameworkElement)sender).DataContext, MainWindow.grillLogic.CurrentGrill.MealsGrilled, false);
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
                    eated += grillMember.Name + " " + grillMember.Surname + " zjadł/a " + meal.Name + "\n";

                }),
                new GrillBackend.Logic.GrillLogic.MealGrillMemberNotFeededDelegate(grillMember =>
                {
                    eated += grillMember.Name + " " + grillMember.Surname + " nic nie zjadł/a bo siem skomczyło :(\n";
                })
            );
            MessageBox.Show(eated);
        }

        private void ButtonServeDrinkAll_Click(object sender, RoutedEventArgs e)
        {
            string drinked = "";
            MainWindow.grillLogic.ServeDrinkAll(
                new GrillBackend.Logic.GrillLogic.MealGrillMemberFeededDelegate((meal, grillMember) =>
                {
                    allMealsList.Items.Refresh();
                    drinked += grillMember.Name + " " + grillMember.Surname + " wypił/a " + meal.Name + "\n";

                }),
                new GrillBackend.Logic.GrillLogic.MealGrillMemberNotFeededDelegate(grillMember =>
                {
                    drinked += grillMember.Name + " " + grillMember.Surname + " nic nie wypił/a bo siem skomczyło :(\n";
                })
            );
            MessageBox.Show(drinked);

        }

        private void ButtonAddFood_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.grillLogic.BuySomeMeals();
            allMealsList.Items.Refresh();
        }

        private void ButtonServeToSelectMember_Click(object sender, RoutedEventArgs e)
        {
            GrillMember grillMember = (GrillMember)selectMember.SelectedValue;
            Meal meal = (Meal)selectMeal.SelectedValue;
            allMealsList.Items.Refresh();
            readyList.Items.Refresh();
            try
            {
                MainWindow.grillLogic.GiveMealToChosenOne(meal, grillMember);
            }
            catch(NoFoodException ex)
            {
                MessageBox.Show(ex.Message);
            }
            //TODO do porawki odświezenie
            selectMeal.ItemsSource = MainWindow.grillLogic.CurrentGrill.MealsPrepared;
            selectMeal.Items.Refresh();
            

        }

        private void SimulationWindow_Closing(object sender, CancelEventArgs e)
        {
            MainWindow.grillLogic.ChangeStatus(Status.Ended);
        }
    }
}
