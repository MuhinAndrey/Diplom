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
