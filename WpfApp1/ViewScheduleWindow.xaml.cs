using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
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
    /// Interakční logika pro ViewScheduleWindow.xaml
    /// </summary>
    public partial class ViewScheduleWindow : Window
    {

        public ViewScheduleWindow(string username)
        {
            InitializeComponent();
            this.searchUsername = username;

            if (LoggedUser.Username != this.searchUsername)
            {
                btnDelete.Visibility = Visibility.Collapsed;
            }

            using (AppDbContext context = new AppDbContext())
            {
                try
                {
                    User user = context.Users.Where(x => x.Username == searchUsername).FirstOrDefault();
                    schedules = context.Schedules.Where(sch => sch.UserId == user.Id).ToList();
                    schedulesList.ItemsSource = schedules;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        List<Schedule> schedules { get; set; }
        //private int usernameid { get; set; }
        public string searchUsername { get; set; }


        private void btnMain_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainWindow.Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //není součástí hodnocení
        }
    }
}
