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

namespace The_bank_system
{
    /// <summary>
    /// Логика взаимодействия для AdminOfficeWindow.xaml
    /// </summary>
    public partial class AdminOfficeWindow : Window
    {
        public AdminOfficeWindow()
        {
            InitializeComponent();
        }

        private void Reg_Window_Button_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            Close();
        }

        private void Services_Button_Click(object sender, RoutedEventArgs e)
        {
            ServicesWindow servicesWindow = new ServicesWindow();
            servicesWindow.Show();
            Close();
        }

        private void Clients_Button_Click(object sender, RoutedEventArgs e)
        {
            ClientsWindow clientsWindow = new ClientsWindow();
            clientsWindow.Show();
            Close();
        }

        private void Service_Viewing_Button_Click(object sender, RoutedEventArgs e)
        {
            VievingServicesWindow vievingServicesWindow = new VievingServicesWindow();
            vievingServicesWindow.Show();
            Close();
        }

        private void Reg_Employee_Window_Button_Click(object sender, RoutedEventArgs e)
        {
            EmployeeRegWindow regserviceWindow = new EmployeeRegWindow();
            regserviceWindow.Show();
            Close();
        }

        private void Employee_Button_Click(object sender, RoutedEventArgs e)
        {
            EmployeeWindow employeeWindow = new EmployeeWindow();
            employeeWindow.Show();
            Close();
        }
    }
}