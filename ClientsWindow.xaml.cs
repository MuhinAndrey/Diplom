using System.Linq;
using System.Windows;

namespace The_bank_system
{//Окно просмотра зарегистрированных клиентов
    public partial class ClientsWindow : Window
    {
        public ClientsWindow()
        {
            InitializeComponent();
            //Получение данных из модели БД
            DGridClients.ItemsSource = BankEntities.GetContext().Clients.ToList();
        }
        //Кнопка "Назад"
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
