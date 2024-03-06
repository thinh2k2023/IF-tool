using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using WPFiftool.ViewModels.CANViewModel;
using WPFiftool.ViewModels.StateMachineVM;

namespace WPFiftool.ViewModels.ControlOutputVM
{
    public class ControlOuputCommon : Window
    {
        private System.Threading.Timer timer;
        private const UInt16 TimerTickSendData = 250;
        private const UInt16 CANMessageNumber = 11;
        public ControlOuputCommon()
        {
            StateMachine.StateMachineChangedEvent += StateMachineChangedEventHander;
        }
        public static void CANSendAllData()
        {
            if (StateMachine.StateMachineData == StateMachine.StateRun)
            {
                CANRawTXViewModel.SendDigitalOutput();
                CANRawTXViewModel.SendAnalogOutputMXP0();
                CANRawTXViewModel.SendAnalogOutputMXP1();
                CANRawTXViewModel.SendAnalogOutputMXP2();
                CANRawTXViewModel.SendAnalogOutputMXP3();
                CANRawTXViewModel.SendPWMOutputMXP0();
                CANRawTXViewModel.SendPWMOutputMXP1();
                CANRawTXViewModel.SendACOutputMXP0();
                CANRawTXViewModel.SendACOutputMXP1();
                CANRawTXViewModel.SendACOutputMXP2();
                CANRawTXViewModel.SendACOutputMXP3();
            }
        }

        private void TimerTickHandle(object state)
        {
            Dispatcher.Invoke(() =>
            {
                sendDataCycle();
            });
        }
        public void StartSendCycle()
        {
            new Thread(() =>
            {
                timer = new System.Threading.Timer(TimerTickHandle, null, TimeSpan.FromMilliseconds(TimerTickSendData), TimeSpan.FromMilliseconds(TimerTickSendData));
            }).Start();
        }



        public void StopSendCycle()
        {
            Dispatcher.Invoke(() =>
            {
                try
                {
                    if (timer != null)
                    {
                        timer.Dispose();
                    }
                }
                catch
                {

                }

            });
        }

        private UInt16 CntSendData = 0;
        private void sendDataCycle()
        {

            switch (CntSendData)
            {
                case 0:
                    CANRawTXViewModel.SendDigitalOutput();
                    break;
                case 1:
                    CANRawTXViewModel.SendAnalogOutputMXP0();
                    break;
                case 2:
                    CANRawTXViewModel.SendAnalogOutputMXP1();
                    break;
                case 3:
                    CANRawTXViewModel.SendAnalogOutputMXP2();
                    break;
                case 4:
                    CANRawTXViewModel.SendAnalogOutputMXP3();
                    break;
                case 5:
                    CANRawTXViewModel.SendPWMOutputMXP0();
                    break;
                case 6:
                    CANRawTXViewModel.SendPWMOutputMXP1();
                    break;
                case 7:
                    CANRawTXViewModel.SendACOutputMXP0();
                    break;
                case 8:
                    CANRawTXViewModel.SendACOutputMXP1();
                    break;
                case 9:
                    CANRawTXViewModel.SendACOutputMXP2();
                    break;
                case 10:
                    CANRawTXViewModel.SendACOutputMXP3();
                    break;
                default:
                    break;
            }

            CntSendData++;
            if (CntSendData >= CANMessageNumber)
            {
                CntSendData = 0;
            }
        }

        private void StateMachineChangedEventHander(object sender, EventArgs e)
        {
            CANSendAllData();
            if (StateMachine.StateMachineData == StateMachine.StateRun)
            {
                StartSendCycle();
            }
            else
            {
                StopSendCycle();
            }
        }

    }
}
