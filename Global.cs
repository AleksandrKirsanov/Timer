using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer
{
   abstract class Global // Абстрактный класс глобальных переменных
    {

         
     static DateTime  dateSet = DateTime.Now; //  Часы при срабатывании по часам
        static public int Hour = dateSet.Hour;//  Минуты при срабатывании по часам
        static public int Minute = dateSet.Minute;// Минуты при срабатывании по таймеру
        static public int HourInterval = 0;// Часы при срабатывании по таймеру


    }
}
