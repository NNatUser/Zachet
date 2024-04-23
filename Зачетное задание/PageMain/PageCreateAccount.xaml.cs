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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Зачетное_задание.DB;

namespace Зачетное_задание.PageMain
{
    /// <summary>
    /// Логика взаимодействия для PageCreateAccount.xaml
    /// </summary>
    public partial class PageCreateAccount : Page
    {
        public PageCreateAccount()
        {
            InitializeComponent();
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.GoBack();
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (TBCheckPassword.Password != TBPassword.Text)
            {
                BTNCreate.IsEnabled = false;
                TBCheckPassword.Background = Brushes.LightCoral;
                TBCheckPassword.BorderBrush = Brushes.Red;
            }
            else
            {
                BTNCreate.IsEnabled = true;
                TBCheckPassword.Background = Brushes.LightGreen;
                TBCheckPassword.BorderBrush = Brushes.Green;
            }
        }
        private void BTNCreate_Click(object sender, RoutedEventArgs e)
        {
            if (AppConnect.Model17user.People.Count(x => x.Login == TBLogin.Text) > 0)
            {
                MessageBox.Show("Пользоваетль с таким логином есть!", "Уведомление",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            try
            {
                Person userObj = new Person()
                {
                    Login = TBLogin.Text,
                    Name = TBName.Text,
                    Password = TBPassword.Text,
                    IdRole = 2
                };
                AppConnect.Model17user.People.Add(userObj);
                AppConnect.Model17user.SaveChanges();
                MessageBox.Show("Даные успешно добавленны!", "Уведомление",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Ошибка при добавлкении данных!", "Уведомление",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
