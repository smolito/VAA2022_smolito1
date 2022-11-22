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
    /// Interakční logika pro ViewWindow.xaml
    /// </summary>
    public partial class ViewWindow : Window
    {
        public ViewWindow()
        {
            InitializeComponent();
        }

        private void btnMain_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainWindow.Show();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            ViewScheduleWindow viewScheduleWindow = new ViewScheduleWindow();
            this.Visibility = Visibility.Hidden;

            viewScheduleWindow.lblUserName.Content = viewScheduleWindow.lblUserName.Content.ToString() + this.tbxUsername.Text;
            viewScheduleWindow.Show();
        }
    }
}
