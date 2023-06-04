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
{//Окно "Услуги"
    public partial class ServicesWindow : Window
    {
        public ServicesWindow()
        {
            InitializeComponent();
        }
        //Переход на окно регистрации кредитов
        private void Credit_services_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new CreditWindow().ShowDialog();
            ShowDialog();
        }
        //Переход на окно регистрации депозитов
        private void Deposit_services_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new DepositWindow().ShowDialog();
            ShowDialog();
        }
        //Кнопка "Назад"
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}