using System.Linq;
using System.Windows;

namespace The_bank_system
{//Окно просмотра кредитов
    public partial class CreditsViewingWindow : Window
    {
        public CreditsViewingWindow()
        {
            InitializeComponent();
            //Получение данных из модели БД
            DGridCredits.ItemsSource = BankEntities.GetContext().Credits.ToList();
        }

        //Кнопка "Назад"
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
