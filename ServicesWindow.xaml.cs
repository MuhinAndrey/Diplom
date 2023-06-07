using System.Windows;

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