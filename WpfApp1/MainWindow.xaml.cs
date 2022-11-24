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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (LoggedUser.Username != null)
            {
                tbLoggedIn.Text = "logged in as: " + LoggedUser.Username;
                btnLogout.Visibility = Visibility.Visible;
            }
            else
            {
                btnForm.Visibility = Visibility.Collapsed;
                btnLogout.Visibility = Visibility.Collapsed;
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            this.Visibility = Visibility.Hidden;
            loginWindow.Show();
        }

        private void btnForm_Click(object sender, RoutedEventArgs e)
        {
            FormWindow formWindow = new FormWindow();
            this.Visibility = Visibility.Hidden;
            formWindow.Show();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            this.Visibility = Visibility.Hidden;
            registerWindow.Show();
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            ViewScheduleWindow viewScheduleWindow = new ViewScheduleWindow(tbSearchField.Text);
            this.Visibility = Visibility.Hidden;

            viewScheduleWindow.lblUserName.Content = viewScheduleWindow.lblUserName.Content.ToString() + viewScheduleWindow.searchUsername;
            viewScheduleWindow.Show();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoggedUser.Id = 0;
            LoggedUser.Username = null;
            LoggedUser.Password = null;
            LoggedUser.Email = null;

            MainWindow mainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainWindow.Show();
        }
    }
}
