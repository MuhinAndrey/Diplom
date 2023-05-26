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
{
    /// <summary>
    /// Логика взаимодействия для EmployeeRegWindow.xaml
    /// </summary>
    public partial class EmployeeRegWindow : Window
    {
        public EmployeeRegWindow()
        {
            InitializeComponent();
        }

        private void Reg_Employee_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Регистрация прошла успешно!");



        }
    }
}
