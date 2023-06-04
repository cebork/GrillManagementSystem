﻿using GrillFrontend.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
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
using System.Xml.Linq;
using GrillBackend.Models.GrillStuff;
using GrillBackend.Models.Enums;
using System.Configuration;
using Microsoft.VisualBasic;
using GrillBackend.Logic;

namespace GrillFrontend
{
    /// <summary>
    /// Logika interakcji dla klasy ListOfGrills.xaml
    /// </summary>
    public partial class ListOfGrills : Window
    {
        public ListOfGrills(Window parentWindow)
        {
            Owner = parentWindow;
            InitializeComponent();
            lista.ItemsSource = MainWindow.grillLogic.grillList;
            
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonDetails_Click(object sender, RoutedEventArgs e)
        {
            Grill selectedGrill = ((FrameworkElement)sender).DataContext as Grill; // wyciaganie elementu z data gridu : D
            GrillDetailsWindow grillDetailsWindow = new GrillDetailsWindow(this, selectedGrill);
            grillDetailsWindow.ShowDialog();
            lista.Items.Refresh();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            Grill selectedGrill = ((FrameworkElement)sender).DataContext as Grill;
            MainWindow.grillLogic.RemoveGrill(selectedGrill);
            lista.Items.Refresh();
        }

        private void ButtonSimulation_Click(object sender, RoutedEventArgs e)
        {
            SimulationWindow simulationWindow = new SimulationWindow(this);
            MainWindow.grillLogic.CurrentGrill = ((FrameworkElement)sender).DataContext as Grill;
            //MainWindow.grillLogic.CurrentGrill.CreateRandomMealsList();
            MainWindow.grillLogic.ChangeStatus(Status.in_progress);
            simulationWindow.ShowDialog();
            lista.Items.Refresh();
        }
    }

}
