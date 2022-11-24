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

namespace WpfApp1
{
    /// <summary>
    /// Interakční logika pro LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnMain_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainWindow.Show();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = tbxEmail.Text;
            string password = tbxPassword.Password.ToString();

            using (AppDbContext context = new AppDbContext())
            {
                try
                {
                    User user = context.Users.Where(u => u.Email == email && u.Password == password).FirstOrDefault();
                    if (user != null)
                    {
                        LoggedUser.Id = user.Id;
                        LoggedUser.Username = user.Username;
                        LoggedUser.Email = user.Email;
                        LoggedUser.Password = user.Password;
                        //MessageBox.Show("logged in as: " + user.Username);

                        MainWindow mainWindow = new MainWindow();
                        this.Visibility = Visibility.Hidden;
                        mainWindow.Show();

                    } else
                    {
                        MessageBox.Show("wrong password or email");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
