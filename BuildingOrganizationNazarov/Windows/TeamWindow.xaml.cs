﻿using System;
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
using BuildingOrganizationNazarov.EF;
namespace BuildingOrganizationNazarov.Windows
{
    /// <summary>
    /// Логика взаимодействия для TeamWindow.xaml
    /// </summary>
    public partial class TeamWindow : Window
    {
        public TeamWindow()
        {
            InitializeComponent();
            LV_Team.ItemsSource = AppData.Context.TeamEmployee.ToList();
        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {

            EmployeeWindow employeeWindow = new EmployeeWindow();
            employeeWindow.Show();
            this.Close();

        }
    }
}
