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

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Avto();
        }// Таймер задержки автозаполнения

        private void Timer_Tick(object sender, EventArgs e) // таймер выводит на форму текущее время
        {
            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;

            Clock.Content = dateTime.ToString().Substring(dateTime.ToString().Length - 9);
        }

        public MainWindow() // Конструктор 
        {
            InitializeComponent();

            //Hour.Content = Global.Hour;
            //Minute.Content = Global.Minute;
            //Second.Content = Global.Second;
            DispatcherTimer timer1 = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 0, 0, 200) }; // таймер для автозаполнения формы
            timer1.Tick += Timer1_Tick;
            timer1.Start();
            DispatcherTimer timer = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 1) }; //Таймер для часов -  1 секунда 
            timer.Tick += Timer_Tick;
            timer.Start();
            DispatcherTimer dispatcherTimer = new DispatcherTimer(); // таймер для выполнения задания 
            RadioTimeOff.IsChecked = true;
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);// В скобках интервал в секундах


        }

        private void DispatcherTimer_Tick(object sender, EventArgs e) // Обработчик события таймера задания
        {
            throw new NotImplementedException();
        }


        #region Кнопки установки времени

        private void HourPlus_Click(object sender, RoutedEventArgs e) // 
        {

            HourPl();


        }

        private void HourMinus_Click(object sender, RoutedEventArgs e)
        {

            HourMin();

        }


        private void MinutePlus_Click(object sender, RoutedEventArgs e)
        {
            MinutePl();
        }


        private void MinuteMinus_Click(object sender, RoutedEventArgs e)
        {

            MinuteMin();
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


        private void SecondPlus_Click(object sender, RoutedEventArgs e)
        {
            SecondPl();
        }

        private void SecondPlus_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Avtozapolnenie = "SecondPl";
        }

        private void SecondPlus_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Avtozapolnenie = "No";
        }

        private void SecondMinus_Click(object sender, RoutedEventArgs e)
        {
            SecondMin();
        }

        private void SecondMinus_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Avtozapolnenie = "SecondMin";
        }

        private void SecondMinus_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Avtozapolnenie = "No";

        }

        #endregion

        #region Radiobutton

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

            Global.Mode = RadioTimeOff.Name;
            TimeInterval.Content = Global.Mode;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            Global.Mode = RadioInterwalOff.Name;
            TimeInterval.Content = Global.Mode;
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            Global.Mode = RadioTimeSleep.Name;
            TimeInterval.Content = Global.Mode;
        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            Global.Mode = RadioIntervalSleep.Name;
            TimeInterval.Content = Global.Mode;
        }

        private void RadioButton_Checked_4(object sender, RoutedEventArgs e)
        {
            Global.Mode = RadioTimeSignal.Name;
            TimeInterval.Content = Global.Mode;
        }

        private void RadioButton_Checked_5(object sender, RoutedEventArgs e)
        {
            Global.Mode = RadioIntervalSignal.Name;
            TimeInterval.Content = Global.Mode;
        }

        #endregion

        #region Методы

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

        void SecondPl()
        {
            if (Global.Second < 59)
            {
                Global.Second++;
            }
            else
            {
                Global.Second = 0;
            }
            Second.Content = Global.Second;
        }

        void SecondMin()
        {
            if (Global.Second > 0)
            {
                Global.Second--;
            }
            else
            {
                Global.Second = 59;
            }
            Second.Content = Global.Second;
        }

        void Avto() // Метод для заполнения значений часов, минут и секунд 
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
                case "SecondPl":
                    SecondPl();
                    break;
                case "SecondMin":
                    SecondMin();
                    break;
                default:
                    break;
            }
        }

        int IntervalTimer() // метод возвращает величину установленного интервала времени в милисекундах.
        {
            int interval = 0;
            int.TryParse(Second.Content.ToString(), out int rezultSecond);
            interval = interval + rezultSecond;
            int.TryParse(Minute.Content.ToString(), out int rezultMinute);
            interval = interval + rezultMinute * 60;
            int.TryParse(Hour.Content.ToString(), out int rezultHour);
            interval = interval + rezultHour * 3600;
            interval = interval * 1000;

            return interval;
        }

        #endregion

        #region кнопки Start  и Stop
        private void START_Click(object sender, RoutedEventArgs e)
        {
            int interval = 0;
            int.TryParse(Hour.Content.ToString(), out int HourTimer);
            int.TryParse(Minute.Content.ToString(), out int MinuteTimer);
            int.TryParse(Second.Content.ToString(), out int SecondTimer);


            DateTime CurrenTime = DateTime.Now;
            if (CurrenTime.Hour <= HourTimer)
            {
                interval = interval + ((HourTimer - CurrenTime.Hour) * 3600);
            }
            else
            {
                interval = interval + (HourTimer + (24 - CurrenTime.Hour)) * 3600;
            }
            TimeInterval.Content = interval.ToString();
        }
        private void STOP_Click(object sender, RoutedEventArgs e)
        {

        }


        #endregion

    }

}
