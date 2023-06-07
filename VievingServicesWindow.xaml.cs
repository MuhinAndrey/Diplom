using System.Windows;

namespace The_bank_system
{//Окно "Зарегистрированные услуги"
    public partial class VievingServicesWindow : Window
    {
        public VievingServicesWindow()
        {
            InitializeComponent();
        }
        //Переход на окно просмотра зарегистрированных кредитов
        private void Credit_Viewing_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new CreditsViewingWindow().ShowDialog();
            ShowDialog ();
        }
        //Переход на окно просмотра зарегистрированных депозитов
        private void Deposit_Viewing_Click(object sender, RoutedEventArgs e)
        { 
            Hide();
            new DepositViewingWindow().ShowDialog();
            ShowDialog ();
        }
        //Кнопка "Назад"
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
