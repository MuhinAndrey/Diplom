using System.Linq;
using System.Windows;

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
