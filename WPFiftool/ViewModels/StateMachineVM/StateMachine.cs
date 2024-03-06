using DocumentFormat.OpenXml.Office2013.PowerPoint.Roaming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFiftool.Command;
using WPFiftool.Models.CAN;
using WPFiftool.ViewModels.CANViewModel;
using WPFiftool.ViewModels.LogViewModel;

namespace WPFiftool.ViewModels.StateMachineVM
{
    public static class StateMachine
    {

        private static byte _StateMachineData = StateInit;


        private static void ResponseDataEvent(object sender, EventArgs e)
        {
            if(e == CANRawRXViewModel.ResponseDataEvent)
            {
                if((byte)sender == 0x01)
                {
                    _StateMachineData = StateRun;
                    Console.WriteLine("change state to run");
                    StateMachineChangedEvent(_StateMachineData, null);
                }
                else if((byte)sender == 0xFF)
                {
                    _StateMachineData = StateWait;
                    Console.WriteLine("change state to wait");
                    StateMachineChangedEvent(_StateMachineData, null);
                }
            }  
            else
            {
                //do nothing
            }    
        }

        private static void StartControlHandlerCallBack(object sender, EventArgs e) 
        {
            CANTXModel._RequestMessage.requestMessageData = 0x01;
            CANRawTXViewModel.SendRequestMessage();
            //StateMachineData = StateRun;        //release will be remove because we have to wait response -> run
        }

        private static void StopControlHandlerCallBack(object sender, EventArgs e)
        {
            StateMachine.StateMachineData = StateMachine.StateWait;
            CANTXModel._RequestMessage.requestMessageData = 0xFF;
            CANRawTXViewModel.SendRequestMessage();
        }

        private static void CommErrorEventHandleCallBack(object sender, EventArgs e)
        {
            StateMachine.StateMachineData = StateMachine.StateWait;
            CANTXModel._RequestMessage.requestMessageData = 0xFF;
            CANRawTXViewModel.SendRequestMessage();
        }


        public static void StateMachineInit()
        {
            CANRawRXViewModel.EventConvetedData += ResponseDataEvent;
            CommError.EventCommError += CommErrorEventHandleCallBack;

            MainWindowViewModel.StartControlHandler += StartControlHandlerCallBack; //start button click event
            MainWindowViewModel.StopControlHandler += StopControlHandlerCallBack;
        }

        public readonly static byte StateInit = 0;
        public readonly static byte StateWait = 1;
        public readonly static byte StateRun = 2;

        public static event EventHandler StateMachineChangedEvent = delegate { };

        public static byte StateMachineData
        {
            get
            {
                return _StateMachineData;
            }

            set
            {
                _StateMachineData = value;
                StateMachineChangedEvent(_StateMachineData, null);
            }
        }
    }
}
