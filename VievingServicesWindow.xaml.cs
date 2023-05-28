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
    /// Логика взаимодействия для VievingServicesWindow.xaml
    /// </summary>
    public partial class VievingServicesWindow : Window
    {
        public VievingServicesWindow()
        {
            InitializeComponent();
        }

        private void Credit_Viewing_Click(object sender, RoutedEventArgs e)
        {
            CreditsViewingWindow creditsViewingWindow = new CreditsViewingWindow();
            creditsViewingWindow.Show();
            Close();
        }

        private void Deposit_Viewing_Click(object sender, RoutedEventArgs e)
        {
            DepositViewingWindow depositViewingWindow = new DepositViewingWindow();
            depositViewingWindow.Show();
            Close();
        }
    }
}
