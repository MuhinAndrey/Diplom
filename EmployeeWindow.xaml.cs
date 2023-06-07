using System.Linq;
using System.Windows;


namespace The_bank_system
{//Окно просмотра сотрудников
    public partial class EmployeeWindow : Window
    {
        public EmployeeWindow()
        {
            InitializeComponent();
            //Получение данных из модели бд
            DGridEmployee.ItemsSource = BankEntities.GetContext().Users.ToList();
        }
        //Кнопка "Назад"
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}