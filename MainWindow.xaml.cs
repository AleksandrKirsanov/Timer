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

        string Avtozapolnenie = "No"; //Переменная для управления заполнением 


        public MainWindow() // Конструктор 
        {
            InitializeComponent();

            Hour.Content = Global.Hour;
            Minute.Content = Global.Minute;

            DispatcherTimer timer1 = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 0, 0, 500) }; // Половина секунды
            timer1.Tick += Timer1_Tick;
            timer1.Start();
            DispatcherTimer timer = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 1) }; // 1 секунда
            timer.Tick += Timer_Tick;
            timer.Start();

            Radio0.IsChecked = true;

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            switch (Avtozapolnenie)
            {
                case "HourPl":
                    HourPl();
                    break;
                case "HourMin":
                    HourMin();
                    break;
                case "MinutePl":
                    MinutePl();
                    break;
                case "MinuteMin":
                    MinuteMin();
                    break;
                default:
                    break;
            }
        }// Таймер задержки автозаполнения

        private void Timer_Tick(object sender, EventArgs e) // таймер выводит на форму текущее время
        {
            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;

            Clock.Content = dateTime.ToString().Substring(dateTime.ToString().Length - 9);
        }

        #region Кнопки

        private void HourPlus_Click(object sender, RoutedEventArgs e) // 
        {

            HourPl();


        }
        void HourPl()
        {
            if (Global.Hour < 23)
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

            HourMin();

        }

        void HourMin()
        {
            if (Global.Hour > 0)
            {
                Global.Hour--;
            }
            else
            {
                Global.Hour = 23;
            }
            Hour.Content = Global.Hour;

        }

        private void MinutePlus_Click(object sender, RoutedEventArgs e)
        {
            MinutePl();
        }

        void MinutePl()
        {
            if (Global.Minute < 59)
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

            MinuteMin();
        }

        void MinuteMin()
        {
            if (Global.Minute > 0)
            {
                Global.Minute--;
            }
            else
            {
                Global.Minute = 59;
            }
            Minute.Content = Global.Minute;
        }

        private void HourPlus_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {


            Avtozapolnenie = "HourPl";



        }

        private void HourPlus_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Avtozapolnenie = "No";

        }

        private void HourMinus_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Avtozapolnenie = "HourMin";
        }

        private void HourMinus_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Avtozapolnenie = "No";
        }

        private void MinutePlus_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Avtozapolnenie = "MinutePl";
        }

        private void MinutePlus_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Avtozapolnenie = "No";

        }

        private void MinuteMinus_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Avtozapolnenie = "MinuteMin";
        }

        private void MinuteMinus_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Avtozapolnenie = "No";
        }
        #endregion

        #region Radiobutton
        private void START_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            TimeInterval.Content = "Выключение по  времени";
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            TimeInterval.Content = "Выключение по интервалу";
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            TimeInterval.Content = "3333333333333";
        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            TimeInterval.Content = "4444444444444";
        }

        private void RadioButton_Checked_4(object sender, RoutedEventArgs e)
        {
            TimeInterval.Content = "55555555555555555555";
        }

        private void RadioButton_Checked_5(object sender, RoutedEventArgs e)
        {
            TimeInterval.Content = "6666666666666666666666";
        }
        #endregion
    }

}
