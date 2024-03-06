using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WPFiftool.ViewModels.CANViewModel
{
    public static class CommError
    {
        private static System.Threading.Timer timer;
        private static UInt16 TimeTick = 100;        //100 ms
        private static UInt16 CntNumber = 0;         //100 ms * 10 = 1s
        private static UInt16 CntErrorNumber = 10;   //100 ms * 10 = 1s  (set 5s to test)
        private static void StartCheckComm()
        {
            new Thread(() =>
            {
                timer = new System.Threading.Timer(CheckCommHandle, null, TimeSpan.FromMilliseconds(TimeTick), TimeSpan.FromMilliseconds(TimeTick));
            }).Start();
        }

        private static void StartControlHandlerCallback(object sender, EventArgs e)
        {
            StartCheckComm();
        }
        private static void StopControlHandlerCallback(object sender, EventArgs e)
        {
            timer.Dispose();
            //timer.Change(Timeout.Infinite, Timeout.Infinite);
        }

        
        private static void CheckCommHandle(object state)
        {
            Console.WriteLine(CntNumber);
            Application.Current.Dispatcher.Invoke(() =>
            {
                CntNumber ++;
                if (CntNumber >= CntErrorNumber)
                {
                    CntNumber = 0;
                    EventCommError(null, null);
                    timer.Dispose();
                }
            });
        }
        private static void RegisterStartButtonEvent()
        {
            MainWindowViewModel.StartControlHandler += StartControlHandlerCallback;
        }

        private static void RegisterStopButtonEvent()
        {
            MainWindowViewModel.StopControlHandler += StopControlHandlerCallback;
        }

        public static void ResetCntCommError()
        {
            CntNumber = 0;
        }

        public static void CommErrorInit()
        {
            ResetCntCommError();
            RegisterStartButtonEvent();
            RegisterStopButtonEvent();
        }

        public static event EventHandler EventCommError = delegate { };

    }
}
