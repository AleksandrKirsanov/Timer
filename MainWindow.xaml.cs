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
using WMPLib;



namespace Timer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    delegate void Scenario();

    public partial class MainWindow : Window
    {



        string Avtozapolnenie = "No"; //Переменная для управления заполнением 
        int IntervalZadanija = 0; // Остаток времени до выполнения задания
        bool StartStop = false;

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Avto();
        }// Таймер задержки автозаполнения

        private void Timer_Tick(object sender, EventArgs e) // таймер выводит на форму текущее время
        {
            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;

            Clock.Content = dateTime.ToString().Substring(dateTime.ToString().Length - 9);

            if (StartStop && IntervalZadanija == 0)
            {
                // Здесь выполнение задания
                SleepKomp();
                TimeInterval.Content = "Сработало!!!!";
            }
            else if (StartStop && IntervalZadanija > 0)
            {
                IntervalZadanija--;
            }

        }


        public MainWindow() // Конструктор 
        {
            InitializeComponent();

            Hour.Content = Global.Hour;
            Minute.Content = Global.Minute;
            Second.Content = Global.Second;
            DispatcherTimer timer1 = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 0, 0, 250) }; // таймер для автозаполнения формы
            timer1.Tick += Timer1_Tick;
            timer1.Start();
            DispatcherTimer timer = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 1) }; //Таймер для часов -  1 секунда 
            timer.Tick += Timer_Tick;
            timer.Start();
            RadioTimeOff.IsChecked = true;



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

        int IntervalTimerInternal() // метод возвращает величину установленного интервала времени в секундах.
        {
            int interval = 0;
            int.TryParse(Second.Content.ToString(), out int rezultSecond);
            interval = interval + rezultSecond;
            int.TryParse(Minute.Content.ToString(), out int rezultMinute);
            interval = interval + rezultMinute * 60;
            int.TryParse(Hour.Content.ToString(), out int rezultHour);
            interval = interval + rezultHour * 3600;


            return interval;
        }

        int IntervalTimerTime()// Метод возвращает величину интервала установленного по времени в секундах
        {
            int interval = 0;
            int IntervalDate = 0;
            int intervalTimer = 0;
            int.TryParse(Hour.Content.ToString(), out int HourTimer);
            int.TryParse(Minute.Content.ToString(), out int MinuteTimer);
            int.TryParse(Second.Content.ToString(), out int SecondTimer);
            // Подсчитаем интервал времени с начала суток в секундах, выставленный в задании
            intervalTimer = intervalTimer + SecondTimer + MinuteTimer * 60 + HourTimer * 3600;
            //Подсчитаем количество секунд, прошедших с начала текущих суток
            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;
            IntervalDate = IntervalDate + dateTime.Second + dateTime.Minute * 60 + dateTime.Hour * 3600;

            if (intervalTimer >= IntervalDate)
            {
                interval = intervalTimer - IntervalDate;
            }
            else
            {
                interval = 86400 - IntervalDate + intervalTimer;
            }

            return interval;

        }

        void scenario() // метод реализации сценария выполнения задания НЕ ЗАКОНЧЕН!!!
        {
            switch (Global.Mode)
            {
                case "RadioTimeOff":
                    break;
                case "RadioInterwalOff":
                    break;
                case "RadioTimeSleep":
                    break;
                case "RadioIntervalSleep":
                    break;
                case "RadioTimeSignal":
                    break;
                case "RadioIntervalSignal":
                    break;
                default:
                    break;
            }
        }

        void StopKomp() // Метод запускает командную строку для выключения компа
        {
            StartStop = false;
            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd.exe",
                // WindowStyle = ProcessWindowStyle.Hidden,
                // Arguments = "/c shutdown -s -f -t 00"

            });

        }

        void SleepKomp() // Метод запускает командную строку для перевода компа в спящий режим
        {
            StartStop = false;
            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd.exe",
                // WindowStyle = ProcessWindowStyle.Hidden,
                // Arguments = "/c rundll32 powrprof.dll,SetSuspendState 0,1,0"



            });

        }

         bool Mp3Play() // Метод проигрывает звук
        {
            WindowsMediaPlayer player = new WindowsMediaPlayer();
            player.URL = @"C:\Users\2013g\source\repos\AleksandrKirsanov\Timer\Resources\Sound_06407.mp3";
           

            return true;
        }


        #endregion



        #region кнопки Start  и Stop
        private void START_Click(object sender, RoutedEventArgs e)// Обработчик кнопки Start обращается к методам вычисления интервала и запускает выполнение задания
        {
            if (StartStop)
            {
                MessageBox.Show("Задание уже запущено");
            }
            else
            {
                switch (Global.Mode)
                {
                    case "RadioTimeOff":
                        IntervalZadanija = IntervalTimerTime();
                        break;
                    case "RadioInterwalOff":
                        IntervalZadanija = IntervalTimerInternal();
                        break;
                    case "RadioTimeSleep":
                        IntervalZadanija = IntervalTimerTime();
                        break;
                    case "RadioIntervalSleep":
                        IntervalZadanija = IntervalTimerInternal();
                        break;
                    case "RadioTimeSignal":
                        IntervalZadanija = IntervalTimerTime();
                        break;
                    case "RadioIntervalSignal":
                        IntervalZadanija = IntervalTimerInternal();
                        break;
                    default:
                        break;
                }

                //  StartStop = true; // флаг разрешения задания
                Mp3Play();
            }



        }

        private void STOP_Click(object sender, RoutedEventArgs e)
        {

        }


        #endregion

    }

}
