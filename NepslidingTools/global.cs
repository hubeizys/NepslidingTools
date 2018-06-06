using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace NepslidingTools
{

    public delegate void RecvProcessFunc(string a);
    class global
    {
        public static DateTime startTime = new DateTime();
        public static string CurActive = "main";
        public static string MachineID = "";
        public static string power = "0";
        public static string workid = "";
        public static void AsynCall(ParameterizedThreadStart funca, object param)
        {
            //var ass = param;
            Thread a = new Thread(funca);
            a.Start(param);
        }

    }
}
