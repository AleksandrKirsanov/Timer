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



namespace Timer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();

         DispatcherTimer   timer = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 1) }; // 1 секунда
            timer.Tick += Timer_Tick;
            timer.Start();



        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;
            
            Clock.Content = dateTime.ToString().Substring(dateTime.ToString().Length - 9);
        }
    }
}
