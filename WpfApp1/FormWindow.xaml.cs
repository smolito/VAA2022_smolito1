using Microsoft.IdentityModel.Tokens;
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
    public partial class FormWindow : Window
    {
        public FormWindow()
        {
            InitializeComponent();
            fillEndingTimeComboBox();
            fillStartingTimeComboBox();
        }

        private void btnMain_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainWindow.Show();
        }

        private void fillStartingTimeComboBox()
        {
            cbxStart.Items.Add("00:00");
            cbxStart.Items.Add("01:00");
            cbxStart.Items.Add("02:00");
            cbxStart.Items.Add("03:00");
            cbxStart.Items.Add("04:00");
            cbxStart.Items.Add("05:00");
            cbxStart.Items.Add("06:00");
            cbxStart.Items.Add("07:00");
            cbxStart.Items.Add("08:00");
            cbxStart.Items.Add("09:00");
            cbxStart.Items.Add("10:00");
            cbxStart.Items.Add("11:00");
            cbxStart.Items.Add("12:00");
            cbxStart.Items.Add("13:00");
            cbxStart.Items.Add("14:00");
            cbxStart.Items.Add("15:00");
            cbxStart.Items.Add("16:00");
            cbxStart.Items.Add("17:00");
            cbxStart.Items.Add("18:00");
            cbxStart.Items.Add("19:00");
            cbxStart.Items.Add("20:00");
            cbxStart.Items.Add("21:00");
            cbxStart.Items.Add("22:00");
            cbxStart.Items.Add("23:00");
        }

        private void fillEndingTimeComboBox()
        {
            cbxEnd.Items.Add("00:00");
            cbxEnd.Items.Add("01:00");
            cbxEnd.Items.Add("02:00");
            cbxEnd.Items.Add("03:00");
            cbxEnd.Items.Add("04:00");
            cbxEnd.Items.Add("05:00");
            cbxEnd.Items.Add("06:00");
            cbxEnd.Items.Add("07:00");
            cbxEnd.Items.Add("08:00");
            cbxEnd.Items.Add("09:00");
            cbxEnd.Items.Add("10:00");
            cbxEnd.Items.Add("11:00");
            cbxEnd.Items.Add("12:00");
            cbxEnd.Items.Add("13:00");
            cbxEnd.Items.Add("14:00");
            cbxEnd.Items.Add("15:00");
            cbxEnd.Items.Add("16:00");
            cbxEnd.Items.Add("17:00");
            cbxEnd.Items.Add("18:00");
            cbxEnd.Items.Add("19:00");
            cbxEnd.Items.Add("20:00");
            cbxEnd.Items.Add("21:00");
            cbxEnd.Items.Add("22:00");
            cbxEnd.Items.Add("23:00");
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string? date = clndCalendar.SelectedDate.ToString();
            if (clndCalendar.SelectedDate.HasValue)
            {
                string[] onlyDate = date.Split(' ');
                date = onlyDate[0];
                //MessageBox.Show("calendar selected date: " + date);
            } else
            {
                MessageBox.Show("choose date, please");
            }

            if (!(cbxStart.Text.IsNullOrEmpty() || cbxEnd.Text.IsNullOrEmpty()))
            {
                Schedule schedule = new Schedule(date, cbxStart.Text, cbxEnd.Text);
                
                using (AppDbContext context = new AppDbContext())
                {
                    try
                    {
                        Schedule checkExistingSchedule = context.Schedules.Where(sched => (sched.UserId == LoggedUser.Id) && (sched.Date == date)).FirstOrDefault();
                        if(checkExistingSchedule == null)
                        {
                            //MessageBox.Show("checkExisting date: " + checkExistingSchedule.Date + "schedule being submitted: " + schedule.Date);
                            context.Schedules.Add(schedule);
                            context.SaveChanges();
                            MessageBox.Show("schedule created");

                            cbxStart.Text = null;
                            cbxEnd.Text = null;
                        } else
                        {
                            MessageBox.Show("you already have a planned schedule for this day");
                        }

                    } catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            } else
            {
                MessageBox.Show("choose both starting and ending times, please");
            }



        }
    }
}
