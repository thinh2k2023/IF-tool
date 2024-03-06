using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using WPFiftool.Models.CAN;
using WPFiftool.Driver;
using System.Threading;
using System.IO.Ports;

namespace WPFiftool.ViewModels.CANViewModel
{
    public static class CANRawRXViewModel
    {



        private static void convertRawDataToPHY()
        {
            //callback function
            CommError.ResetCntCommError();

            string _CANID = USBCanDriver.getCANID;
            byte[] _CANDATA = USBCanDriver.getCANDATA;

            //debug
            Console.WriteLine("Data received: ");
            //Console.WriteLine(_CANID);

            for (int i = 0; i < 8; i++)
            {
                Console.Write(_CANDATA[i] + "\t");
            }

            //check CAN ID & multiplexer
            switch (_CANID)
            {
                case "1024":        //ID:0x400 response message
                    CANRXRawData._ResponseRawData.responselData = (byte)(_CANDATA[0]);
                    EventConvetedData(CANRXRawData._ResponseRawData.responselData, ResponseDataEvent);
                    break;

                case "1280":        //ID:0x500 digital input data message

                    CANRXRawData._DigitalInputRawData.digitalData[0] = (byte)((_CANDATA[1] & 0x01));
                    CANRXRawData._DigitalInputRawData.digitalData[1] = (byte)((_CANDATA[1] & 0x02) >> 1);
                    CANRXRawData._DigitalInputRawData.digitalData[2] = (byte)((_CANDATA[1] & 0x04) >> 2);
                    CANRXRawData._DigitalInputRawData.digitalData[3] = (byte)((_CANDATA[1] & 0x08) >> 3);
                    CANRXRawData._DigitalInputRawData.digitalData[4] = (byte)((_CANDATA[1] & 0x10) >> 4);
                    CANRXRawData._DigitalInputRawData.digitalData[5] = (byte)((_CANDATA[1] & 0x20) >> 5);
                    CANRXRawData._DigitalInputRawData.digitalData[6] = (byte)((_CANDATA[1] & 0x40) >> 6);
                    CANRXRawData._DigitalInputRawData.digitalData[7] = (byte)((_CANDATA[1] & 0x80) >> 7);

                    CANRXRawData._DigitalInputRawData.digitalData[8] = (byte)(_CANDATA[0] & 0x01);
                    CANRXRawData._DigitalInputRawData.digitalData[9] = (byte)((_CANDATA[0] & 0x02) >> 1);
                    CANRXRawData._DigitalInputRawData.digitalData[10] = (byte)((_CANDATA[0] & 0x04) >> 2);
                    CANRXRawData._DigitalInputRawData.digitalData[11] = (byte)((_CANDATA[0] & 0x08) >> 3);
                    CANRXRawData._DigitalInputRawData.digitalData[12] = (byte)((_CANDATA[0] & 0x10) >> 4);
                    CANRXRawData._DigitalInputRawData.digitalData[13] = (byte)((_CANDATA[0] & 0x20) >> 5);
                    CANRXRawData._DigitalInputRawData.digitalData[14] = (byte)((_CANDATA[0] & 0x40) >> 6);
                    CANRXRawData._DigitalInputRawData.digitalData[15] = (byte)((_CANDATA[0] & 0x80) >> 7);
                    EventConvetedData(null, DigitalInputEvent);
                    break;

                case "1281":        //ID:0x501 analog input data message

                    if (((_CANDATA[0] >> 4) & 0x0F) == 0)
                    {
                        CANRXRawData._AnalogInputRawData.analogData[0] = (UInt16)(((_CANDATA[0] << 8) & 0x0F00) + (_CANDATA[1] & 0x00FF));
                        CANRXRawData._AnalogInputRawData.analogData[1] = (UInt16)(((_CANDATA[2] << 4) & 0x0FF0) + ((_CANDATA[3] & 0x00F0) >> 4));
                        CANRXRawData._AnalogInputRawData.analogData[2] = (UInt16)(((_CANDATA[3] << 8) & 0x0F00) + (_CANDATA[4] & 0x00FF));
                        CANRXRawData._AnalogInputRawData.analogData[3] = (UInt16)(((_CANDATA[5] << 4) & 0x0FF0) + ((_CANDATA[6] & 0x00F0) >> 4));
                        CANRXRawData._AnalogInputRawData.analogData[4] = (UInt16)(((_CANDATA[6] << 8) & 0x0F00) + (_CANDATA[7] & 0x00FF));
                        EventConvetedData(null, AnalogInputMXP0Event);
                    }

                    else if (((_CANDATA[0] >> 4) & 0x0F) == 1)
                    {
                        CANRXRawData._AnalogInputRawData.analogData[5] = (UInt16)(((_CANDATA[0] << 8) & 0x0F00) + (_CANDATA[1] & 0x00FF));
                        CANRXRawData._AnalogInputRawData.analogData[6] = (UInt16)(((_CANDATA[2] << 4) & 0x0FF0) + ((_CANDATA[3] & 0x00F0) >> 4));
                        CANRXRawData._AnalogInputRawData.analogData[7] = (UInt16)(((_CANDATA[3] << 8) & 0x0F00) + (_CANDATA[4] & 0x00FF));
                        CANRXRawData._AnalogInputRawData.analogData[8] = (UInt16)(((_CANDATA[5] << 4) & 0x0FF0) + ((_CANDATA[6] & 0x00F0) >> 4));
                        CANRXRawData._AnalogInputRawData.analogData[9] = (UInt16)(((_CANDATA[6] << 8) & 0x0F00) + (_CANDATA[7] & 0x00FF));
                        EventConvetedData(null, AnalogInputMXP1Event);

                    }

                    else if (((_CANDATA[0] >> 4) & 0x0F) == 2)
                    {
                        CANRXRawData._AnalogInputRawData.analogData[10] = (UInt16)(((_CANDATA[0] << 8) & 0x0F00) + (_CANDATA[1] & 0x00FF));
                        CANRXRawData._AnalogInputRawData.analogData[11] = (UInt16)(((_CANDATA[2] << 4) & 0x0FF0) + ((_CANDATA[3] & 0x00F0) >> 4));
                        CANRXRawData._AnalogInputRawData.analogData[12] = (UInt16)(((_CANDATA[3] << 8) & 0x0F00) + (_CANDATA[4] & 0x00FF));
                        CANRXRawData._AnalogInputRawData.analogData[13] = (UInt16)(((_CANDATA[5] << 4) & 0x0FF0) + ((_CANDATA[6] & 0x00F0) >> 4));
                        CANRXRawData._AnalogInputRawData.analogData[14] = (UInt16)(((_CANDATA[6] << 8) & 0x0F00) + (_CANDATA[7] & 0x00FF));
                        EventConvetedData(null, AnalogInputMXP2Event);

                    }

                    else if (((_CANDATA[0] >> 4) & 0x0F) == 3)
                    {
                        CANRXRawData._AnalogInputRawData.analogData[15] = (UInt16)(((_CANDATA[0] << 8) & 0x0F00) + (_CANDATA[1] & 0x00FF));
                        EventConvetedData(null, AnalogInputMXP3Event);
                    }
                    else

                    {
                        //do nothing
                    }

                    break;

                case "1282":        //ID:0x502 pwm input data message



                    break;


                case "1283":        //ID:0x503 ac input data message
                    if (((_CANDATA[0] >> 4) & 0x0F) == 0)
                    {
                        CANRXRawData._ACInputRawData.PeakHighVoltage[0] = (float)((_CANDATA[0] << 8) & 0x0F00) + (_CANDATA[1] & 0x00FF);
                        CANRXRawData._ACInputRawData.PeakLowVoltage[0] = (float)((_CANDATA[2] << 4) & 0x0FF0) + ((_CANDATA[3] & 0x00F0) >> 4);
                        CANRXRawData._ACInputRawData.RMSVoltage[0] = (float)((_CANDATA[3] << 8) & 0x0F00) + (_CANDATA[4] & 0x00FF);
                        CANRXRawData._ACInputRawData.frequency[0] = (float)((_CANDATA[5] << 4) & 0x0FF0) + ((_CANDATA[6] & 0x00F0) >> 4);
                        EventConvetedData(null, ACInputMXP0Event);

                    }
                    else if (((_CANDATA[0] >> 4) & 0x0F) == 1)
                    {
                        CANRXRawData._ACInputRawData.PeakHighVoltage[1] = (float)((_CANDATA[0] << 8) & 0x0F00) + (_CANDATA[1] & 0x00FF);
                        CANRXRawData._ACInputRawData.PeakLowVoltage[1] = (float)((_CANDATA[2] << 4) & 0x0FF0) + ((_CANDATA[3] & 0x00F0) >> 4);
                        CANRXRawData._ACInputRawData.RMSVoltage[1] = (float)((_CANDATA[3] << 8) & 0x0F00) + (_CANDATA[4] & 0x00FF);
                        CANRXRawData._ACInputRawData.frequency[1] = (float)((_CANDATA[5] << 4) & 0x0FF0) + ((_CANDATA[6] & 0x00F0) >> 4);
                        EventConvetedData(null, ACInputMXP1Event);

                    }

                    else if (((_CANDATA[0] >> 4) & 0x0F) == 2)
                    {
                        CANRXRawData._ACInputRawData.PeakHighVoltage[2] = (float)((_CANDATA[0] << 8) & 0x0F00) + (_CANDATA[1] & 0x00FF);
                        CANRXRawData._ACInputRawData.PeakLowVoltage[2] = (float)((_CANDATA[2] << 4) & 0x0FF0) + ((_CANDATA[3] & 0x00F0) >> 4);
                        CANRXRawData._ACInputRawData.RMSVoltage[2] = (float)((_CANDATA[3] << 8) & 0x0F00) + (_CANDATA[4] & 0x00FF);
                        CANRXRawData._ACInputRawData.frequency[2] = (float)((_CANDATA[5] << 4) & 0x0FF0) + ((_CANDATA[6] & 0x00F0) >> 4);
                        EventConvetedData(null, ACInputMXP2Event);

                    }
                    else if (((_CANDATA[0] >> 4) & 0x0F) == 3)
                    {
                        CANRXRawData._ACInputRawData.PeakHighVoltage[3] = (float)((_CANDATA[0] << 8) & 0x0F00) + (_CANDATA[1] & 0x00FF);
                        CANRXRawData._ACInputRawData.PeakLowVoltage[3] = (float)((_CANDATA[2] << 4) & 0x0FF0) + ((_CANDATA[3] & 0x00F0) >> 4);
                        CANRXRawData._ACInputRawData.RMSVoltage[3] = (float)((_CANDATA[3] << 8) & 0x0F00) + (_CANDATA[4] & 0x00FF);
                        CANRXRawData._ACInputRawData.frequency[3] = (float)((_CANDATA[5] << 4) & 0x0FF0) + ((_CANDATA[6] & 0x00F0) >> 4);
                        EventConvetedData(null, ACInputMXP3Event);

                    }
                    else
                    {
                        //do nothing
                    }
                    break;

                default:

                    //do nothing
                    break;
            }
        }


        public static event EventHandler EventConvetedData = delegate { };


        //event argument
        public static EventArgs ResponseDataEvent = new EventArgs();

        public static EventArgs DigitalInputEvent = new EventArgs();

        public static EventArgs AnalogInputMXP0Event = new EventArgs();
        public static EventArgs AnalogInputMXP1Event = new EventArgs();
        public static EventArgs AnalogInputMXP2Event = new EventArgs();
        public static EventArgs AnalogInputMXP3Event = new EventArgs();


        public static EventArgs ACInputMXP0Event = new EventArgs();
        public static EventArgs ACInputMXP1Event = new EventArgs();
        public static EventArgs ACInputMXP2Event = new EventArgs();
        public static EventArgs ACInputMXP3Event = new EventArgs();


        public static EventArgs PWMInputMXP0Event = new EventArgs();
        public static EventArgs PWMInputMXP1Event = new EventArgs();


        //register can rx data received event
        public static void RegisterCANRXEvent()
        {
            USBCanDriver.dataUpdatedEvent += ReceivedEventCallback;      //register event
        }

        //received event => convert to physical 
        public static void ReceivedEventCallback(object sender, EventArgs e)
        {
                Application.Current.Dispatcher.Invoke(() =>
            {
                convertRawDataToPHY();
                Console.WriteLine("start convert");
            });
        }
    }

}
