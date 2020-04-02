using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer
{
   abstract class Global // Абстрактный класс глобальных переменных
    {

         
     static public DateTime  dateSet = DateTime.Now; //  
        static public int Hour = dateSet.Hour;//  
        static public int Minute = dateSet.Minute;// 
        static public int Second = dateSet.Second;
        static public string Mode = "";


    }
}
