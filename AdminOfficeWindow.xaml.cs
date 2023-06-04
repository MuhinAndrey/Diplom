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

namespace The_bank_system
{//Окно "Кабинет администратора"
    public partial class AdminOfficeWindow : Window
    {
        public AdminOfficeWindow()
        {
            InitializeComponent();
        }

        //Открытие окна "Регистрация клиента"
        private void Reg_Window_Button_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new RegistrationWindow().ShowDialog();
            ShowDialog();
        }

        //Открытие окна "Предоставление услуг"
        private void Services_Button_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new ServicesWindow().ShowDialog();
            ShowDialog();
        }

        //Открытие окна "Клиенты"
        private void Clients_Button_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new ClientsWindow().ShowDialog();
            ShowDialog();
        }

        //Открытие окна "Зарегистрированые услуги"
        private void Service_Viewing_Button_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new VievingServicesWindow().ShowDialog();
            ShowDialog();
        }

        //Открытие окна "Регистрация сотрудника"
        private void Reg_Employee_Window_Button_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new EmployeeRegWindow().ShowDialog();
            ShowDialog();
        }

        //Открытие окна "Сотрудники"
        private void Employee_Button_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new EmployeeWindow().ShowDialog();
            ShowDialog();
        }
    }
}