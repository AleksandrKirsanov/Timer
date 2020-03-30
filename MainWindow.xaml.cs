using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using System.Diagnostics;



namespace Timer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer1 = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 0, 0, 500) };
        Stopwatch stopwatch = new Stopwatch();


        public MainWindow()
        {
            InitializeComponent();

            Hour.Content = Global.Hour;
            Minute.Content = Global.Minute;

            DispatcherTimer timer = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 1) }; // 1 секунда
            timer.Tick += Timer_Tick;
            timer.Start();



        }


        private void Timer_Tick(object sender, EventArgs e) // таймер выводит на форму текущее время
        {
            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;

            Clock.Content = dateTime.ToString().Substring(dateTime.ToString().Length - 9);
        }

        private void HourPlus_Click(object sender, RoutedEventArgs e) // 
        {
            if (Global.Hour < 24)
            {
                Global.Hour = Global.Hour + 1;
            }
            else
            {
                Global.Hour = 0;
            }
            Hour.Content = Global.Hour;



        }




        private void HourMinus_Click(object sender, RoutedEventArgs e)
        {

            if (Global.Hour > 0)
            {
                Global.Hour--;
            }
            else
            {
                Global.Hour = 24;
            }
            Hour.Content = Global.Hour;

        }

        private void MinutePlus_Click(object sender, RoutedEventArgs e)
        {
            if (Global.Minute < 60)
            {
                Global.Minute++;
            }
            else
            {
                Global.Minute = 0;
            }
            Minute.Content = Global.Minute;
        }

        private void MinuteMinus_Click(object sender, RoutedEventArgs e)
        {
            if (Global.Minute > 0)
            {
                Global.Minute--;
            }
            else
            {
                Global.Minute = 60;
            }
            Minute.Content = Global.Minute;

        }



        private void HourPlus_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           TimeInterval.Content = "ffffffffffffffff";
        }
    }
}
