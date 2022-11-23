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
    /// Interakční logika pro RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void btnMain_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainWindow.Show();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (tbxPassword.Password.ToString().Equals(tbxRePassword.Password.ToString()))
            {
                User user = new User(tbxUsername.Text.ToString(), tbxEmail.Text.ToString(), tbxPassword.Password.ToString());

                using (AppDbContext context = new AppDbContext())
                {
                    try
                    {
                        context.Users.Add(user);
                        context.SaveChanges();
                        MessageBox.Show("Registration successful.");

                        MainWindow mainWindow = new MainWindow();
                        this.Visibility = Visibility.Hidden;
                        mainWindow.Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else MessageBox.Show("Passwords don't match!");
            
        }
    }
}
