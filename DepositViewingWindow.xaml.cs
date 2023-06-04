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
{//Окно просмотра зарегистрированных депозитов
    public partial class DepositViewingWindow : Window
    {
        public DepositViewingWindow()
        {
            InitializeComponent();
            //Получение данных из модели БД
            DGridDeposit.ItemsSource = BankEntities.GetContext().Deposits.ToList();
        }
        //Кнопка "Назад"
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
