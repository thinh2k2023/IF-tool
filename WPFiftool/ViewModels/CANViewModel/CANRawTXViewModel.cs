using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using WPFiftool.Models.CAN;
using WPFiftool.Driver;
using WPFiftool.ViewModels.StateMachineVM;

namespace WPFiftool.ViewModels.CANViewModel
{
    public class CANRawTXViewModel : Window
    {
        /// <summary>
        /// constructor
        /// </summary>
        public CANRawTXViewModel()
        {

        }
        private static void RequestMessageConvert()
        {
            CANTXModel._DataCANTXMSG[0u] = (byte)(CANTXModel._RequestMessage.requestMessageData);
            CANTXModel._DataCANTXMSG[1u] = 0;
            CANTXModel._DataCANTXMSG[2u] = 0;
            CANTXModel._DataCANTXMSG[3u] = 0;
            CANTXModel._DataCANTXMSG[4u] = 0;
            CANTXModel._DataCANTXMSG[5u] = 0;
            CANTXModel._DataCANTXMSG[6u] = 0;
            CANTXModel._DataCANTXMSG[7u] = 0;
        }

        /// <summary>
        /// Digital output
        /// </summary>
        private static void DigitalOutputRawConvert()
        {
            CANTXModel._DataCANTXMSG[0] = (byte)(((CANTXModel._DigitalOutputTXRawData.digitalOutputData[15] << 7) & 0x80)
                    + ((CANTXModel._DigitalOutputTXRawData.digitalOutputData[14] << 6) & 0x40)
                    + ((CANTXModel._DigitalOutputTXRawData.digitalOutputData[13] << 5) & 0x20)
                    + ((CANTXModel._DigitalOutputTXRawData.digitalOutputData[12] << 4) & 0x10)
                    + ((CANTXModel._DigitalOutputTXRawData.digitalOutputData[11] << 3) & 0x08)
                    + ((CANTXModel._DigitalOutputTXRawData.digitalOutputData[10] << 2) & 0x04)
                    + ((CANTXModel._DigitalOutputTXRawData.digitalOutputData[9] << 1) & 0x02)
                    + (CANTXModel._DigitalOutputTXRawData.digitalOutputData[8] & 0x01));

            CANTXModel._DataCANTXMSG[1] = (byte)(((CANTXModel._DigitalOutputTXRawData.digitalOutputData[7] << 7) & 0x80)
                    + ((CANTXModel._DigitalOutputTXRawData.digitalOutputData[6] << 6) & 0x40)
                    + ((CANTXModel._DigitalOutputTXRawData.digitalOutputData[5] << 5) & 0x20)
                    + ((CANTXModel._DigitalOutputTXRawData.digitalOutputData[4] << 4) & 0x10)
                    + ((CANTXModel._DigitalOutputTXRawData.digitalOutputData[3] << 3) & 0x08)
                    + ((CANTXModel._DigitalOutputTXRawData.digitalOutputData[2] << 2) & 0x04)
                    + ((CANTXModel._DigitalOutputTXRawData.digitalOutputData[1] << 1) & 0x02)
                    + (CANTXModel._DigitalOutputTXRawData.digitalOutputData[0] & 0x01));

            CANTXModel._DataCANTXMSG[2u] = 0;
            CANTXModel._DataCANTXMSG[3u] = 0;
            CANTXModel._DataCANTXMSG[4u] = 0;
            CANTXModel._DataCANTXMSG[5u] = 0;
            CANTXModel._DataCANTXMSG[6u] = 0;
            CANTXModel._DataCANTXMSG[7u] = 0;
        }

        /// <summary>
        /// Analog output
        /// </summary>
        private static void AnalogOutputRawConvertMXP0()
        {
            CANTXModel._DataCANTXMSG[0u] = (byte)((0 << 4) + (CANTXModel._AnalogOutputTXRawData.analogOutputData[0] >> 8) & 0x000F);
            CANTXModel._DataCANTXMSG[1u] = (byte)(CANTXModel._AnalogOutputTXRawData.analogOutputData[0] & 0x00FF);
            CANTXModel._DataCANTXMSG[2u] = (byte)((CANTXModel._AnalogOutputTXRawData.analogOutputData[1] >> 4) & 0x00FF);
            CANTXModel._DataCANTXMSG[3u] = (byte)(((CANTXModel._AnalogOutputTXRawData.analogOutputData[1] << 4) & 0x00F0) + ((CANTXModel._AnalogOutputTXRawData.analogOutputData[2] >> 8) & 0x000F));
            CANTXModel._DataCANTXMSG[4u] = (byte)(CANTXModel._AnalogOutputTXRawData.analogOutputData[2] & 0x00FF);
            CANTXModel._DataCANTXMSG[5u] = (byte)((CANTXModel._AnalogOutputTXRawData.analogOutputData[3] >> 4) & 0x00FF);
            CANTXModel._DataCANTXMSG[6u] = (byte)(((CANTXModel._AnalogOutputTXRawData.analogOutputData[3] << 4) & 0x00F0) + ((CANTXModel._AnalogOutputTXRawData.analogOutputData[4] >> 8) & 0x000F));
            CANTXModel._DataCANTXMSG[7u] = (byte)(CANTXModel._AnalogOutputTXRawData.analogOutputData[4] & 0x00FF);

        }

        private static void AnalogOutputRawConvertMXP1()
        {
            CANTXModel._DataCANTXMSG[0u] = (byte)((1 << 4) + ((CANTXModel._AnalogOutputTXRawData.analogOutputData[5] >> 8) & 0x000F));
            CANTXModel._DataCANTXMSG[1u] = (byte)(CANTXModel._AnalogOutputTXRawData.analogOutputData[5] & 0x00FF);
            CANTXModel._DataCANTXMSG[2u] = (byte)((CANTXModel._AnalogOutputTXRawData.analogOutputData[6] >> 4) & 0x00FF);
            CANTXModel._DataCANTXMSG[3u] = (byte)(((CANTXModel._AnalogOutputTXRawData.analogOutputData[6] << 4) & 0x00F0) + ((CANTXModel._AnalogOutputTXRawData.analogOutputData[7] >> 8) & 0x000F));
            CANTXModel._DataCANTXMSG[4u] = (byte)(CANTXModel._AnalogOutputTXRawData.analogOutputData[7] & 0x00FF);
            CANTXModel._DataCANTXMSG[5u] = (byte)((CANTXModel._AnalogOutputTXRawData.analogOutputData[8] >> 4) & 0x00FF);
            CANTXModel._DataCANTXMSG[6u] = (byte)(((CANTXModel._AnalogOutputTXRawData.analogOutputData[8] << 4) & 0x00F0) + ((CANTXModel._AnalogOutputTXRawData.analogOutputData[9] >> 8) & 0x000F));
            CANTXModel._DataCANTXMSG[7u] = (byte)(CANTXModel._AnalogOutputTXRawData.analogOutputData[9] & 0x00FF);
        }


        private static void AnalogOutputRawConvertMXP2()
        {
            CANTXModel._DataCANTXMSG[0u] = (byte)((2 << 4) + ((CANTXModel._AnalogOutputTXRawData.analogOutputData[10] >> 8) & 0x000F));
            CANTXModel._DataCANTXMSG[1u] = (byte)(CANTXModel._AnalogOutputTXRawData.analogOutputData[10] & 0x00FF);
            CANTXModel._DataCANTXMSG[2u] = (byte)((CANTXModel._AnalogOutputTXRawData.analogOutputData[11] >> 4) & 0x00FF);
            CANTXModel._DataCANTXMSG[3u] = (byte)(((CANTXModel._AnalogOutputTXRawData.analogOutputData[11] << 4) & 0x00F0) + ((CANTXModel._AnalogOutputTXRawData.analogOutputData[12] >> 8) & 0x000F));
            CANTXModel._DataCANTXMSG[4u] = (byte)(CANTXModel._AnalogOutputTXRawData.analogOutputData[12] & 0x00FF);
            CANTXModel._DataCANTXMSG[5u] = (byte)((CANTXModel._AnalogOutputTXRawData.analogOutputData[13] >> 4) & 0x00FF);
            CANTXModel._DataCANTXMSG[6u] = (byte)(((CANTXModel._AnalogOutputTXRawData.analogOutputData[13] << 4) & 0x00F0) + ((CANTXModel._AnalogOutputTXRawData.analogOutputData[14] >> 8) & 0x000F));
            CANTXModel._DataCANTXMSG[7u] = (byte)(CANTXModel._AnalogOutputTXRawData.analogOutputData[14] & 0x00FF);
        }

        private static void AnalogOutputRawConvertMXP3()
        {
            CANTXModel._DataCANTXMSG[0u] = (byte)((3 << 4) + ((CANTXModel._AnalogOutputTXRawData.analogOutputData[15] >> 8) & 0x000F));
            CANTXModel._DataCANTXMSG[1u] = (byte)(CANTXModel._AnalogOutputTXRawData.analogOutputData[15] & 0x00FF);
            CANTXModel._DataCANTXMSG[2u] = 0;
            CANTXModel._DataCANTXMSG[3u] = 0;
            CANTXModel._DataCANTXMSG[4u] = 0;
            CANTXModel._DataCANTXMSG[5u] = 0;
            CANTXModel._DataCANTXMSG[6u] = 0;
            CANTXModel._DataCANTXMSG[7u] = 0;
        }
        /// <summary>
        /// pwm output
        /// </summary>
        private static void PWMOutputRawConvertMXP0()
        {

            CANTXModel._DataCANTXMSG[0] = (byte)((0 << 4) + (byte)((CANTXModel._PWMOutputTXRawData.frequency[0] >> 14) & 0x000F));
            CANTXModel._DataCANTXMSG[1] = (byte)((CANTXModel._PWMOutputTXRawData.frequency[0] >> 6) & 0x00FF);
            CANTXModel._DataCANTXMSG[2] = (byte)(((byte)(CANTXModel._PWMOutputTXRawData.frequency[0] << 2) & 0x00FC) + (byte)((CANTXModel._PWMOutputTXRawData.dutyCycle[0] >> 8) & 0x0003));
            CANTXModel._DataCANTXMSG[3] = (byte)(CANTXModel._PWMOutputTXRawData.dutyCycle[0] & 0x00FF);

            CANTXModel._DataCANTXMSG[4] = (byte)((CANTXModel._PWMOutputTXRawData.frequency[1] >> 14) & 0x000F);
            CANTXModel._DataCANTXMSG[5] = (byte)((CANTXModel._PWMOutputTXRawData.frequency[1] >> 6) & 0x00FF);
            CANTXModel._DataCANTXMSG[6] = (byte)(((CANTXModel._PWMOutputTXRawData.frequency[1] << 2) & 0x00FC) + (byte)((CANTXModel._PWMOutputTXRawData.dutyCycle[1] >> 8) & 0x0003));
            CANTXModel._DataCANTXMSG[7] = (byte)(CANTXModel._PWMOutputTXRawData.dutyCycle[1] & 0x00FF);
        }

        private static void PWMOutputRawConvertMXP1()
        {
            CANTXModel._DataCANTXMSG[0] = (byte)((1 << 4) + (byte)((CANTXModel._PWMOutputTXRawData.frequency[2] >> 14) & 0x000F));
            CANTXModel._DataCANTXMSG[1] = (byte)((CANTXModel._PWMOutputTXRawData.frequency[2] >> 6) & 0x00FF);
            CANTXModel._DataCANTXMSG[2] = (byte)(((byte)(CANTXModel._PWMOutputTXRawData.frequency[2] << 2) & 0x00FC) + (byte)((CANTXModel._PWMOutputTXRawData.dutyCycle[2] >> 8) & 0x0003));
            CANTXModel._DataCANTXMSG[3] = (byte)(CANTXModel._PWMOutputTXRawData.dutyCycle[2] & 0x00FF);

            CANTXModel._DataCANTXMSG[4] = (byte)((CANTXModel._PWMOutputTXRawData.frequency[3] >> 14) & 0x000F);
            CANTXModel._DataCANTXMSG[5] = (byte)((CANTXModel._PWMOutputTXRawData.frequency[3] >> 6) & 0x00FF);
            CANTXModel._DataCANTXMSG[6] = (byte)(((CANTXModel._PWMOutputTXRawData.frequency[3] << 2) & 0x00FC) + (byte)((CANTXModel._PWMOutputTXRawData.dutyCycle[3] >> 8) & 0x0003));
            CANTXModel._DataCANTXMSG[7] = (byte)(CANTXModel._PWMOutputTXRawData.dutyCycle[3] & 0x00FF);
        }

        /// <summary>
        /// AC OUTPUT
        /// </summary>
        private static void ACOutputRawConvertMXP0()
        {
            CANTXModel._DataCANTXMSG[0] = (byte)((0 << 4) + ((CANTXModel._ACOutputTXRawData.phaseShift[0] << 2) & 0x000C) + (CANTXModel._ACOutputTXRawData.Type[0] & 0x0003));
            CANTXModel._DataCANTXMSG[1] = (byte)((CANTXModel._ACOutputTXRawData.Level[0] >> 4) & 0x00FF);
            CANTXModel._DataCANTXMSG[2] = (byte)(((CANTXModel._ACOutputTXRawData.Level[0] << 4) & 0x00F0) + ((CANTXModel._ACOutputTXRawData.Center[0] >> 8) & 0x000F));
            CANTXModel._DataCANTXMSG[3] = (byte)(CANTXModel._ACOutputTXRawData.Center[0] & 0x00FF);
            CANTXModel._DataCANTXMSG[4] = (byte)(((CANTXModel._ACOutputTXRawData.frequency[0]) >> 4) & 0x00FF);
            CANTXModel._DataCANTXMSG[5] = (byte)(((CANTXModel._ACOutputTXRawData.frequency[0]) & 0x000F) << 4);
            CANTXModel._DataCANTXMSG[6] = 0;
            CANTXModel._DataCANTXMSG[7] = 0;
        }

        public static void ACOutputRawConvertMXP1()
        {
            CANTXModel._DataCANTXMSG[0] = (byte)((1 << 4) + ((CANTXModel._ACOutputTXRawData.Type[1]) & 0x0003));
            CANTXModel._DataCANTXMSG[1] = (byte)((CANTXModel._ACOutputTXRawData.Level[1] >> 4) & 0x00FF);

            CANTXModel._DataCANTXMSG[2] = (byte)(((CANTXModel._ACOutputTXRawData.Level[1] << 4) & 0x00F0) + ((CANTXModel._ACOutputTXRawData.Center[1] >> 8) & 0x000F));


            CANTXModel._DataCANTXMSG[3] = (byte)(CANTXModel._ACOutputTXRawData.Center[1] & 0x00FF);

            CANTXModel._DataCANTXMSG[4] = (byte)(((CANTXModel._ACOutputTXRawData.frequency[1]) >> 4) & 0x00FF);

            CANTXModel._DataCANTXMSG[5] = (byte)(((byte)(CANTXModel._ACOutputTXRawData.frequency[1] << 4) & 0x00F0) + ((byte)(CANTXModel._ACOutputTXRawData.phaseShift[1] >> 8) & 0x0003));
            CANTXModel._DataCANTXMSG[6] = (byte)((CANTXModel._ACOutputTXRawData.phaseShift[1]) & 0x0FF);
            CANTXModel._DataCANTXMSG[7] = 0;
            USBCanDriver.CANSendMessage(515, CANTXModel._DataCANTXMSG);
        }

        private static void ACOutputRawConvertMXP2()
        {
            CANTXModel._DataCANTXMSG[0] = (byte)((2 << 4) + ((CANTXModel._ACOutputTXRawData.Type[2]) & 0x0003));
            CANTXModel._DataCANTXMSG[1] = (byte)((CANTXModel._ACOutputTXRawData.Level[2] >> 4) & 0x00FF);
            CANTXModel._DataCANTXMSG[2] = (byte)(((CANTXModel._ACOutputTXRawData.Level[2] << 4) & 0x00F0) + ((CANTXModel._ACOutputTXRawData.Center[2] >> 8) & 0x000F));
            CANTXModel._DataCANTXMSG[3] = (byte)(CANTXModel._ACOutputTXRawData.Center[2] & 0x00FF);
            CANTXModel._DataCANTXMSG[4] = (byte)(((CANTXModel._ACOutputTXRawData.frequency[2]) >> 4) & 0x00FF);
            CANTXModel._DataCANTXMSG[5] = (byte)(((byte)(CANTXModel._ACOutputTXRawData.frequency[2] << 4) & 0x00F0) + ((byte)(CANTXModel._ACOutputTXRawData.phaseShift[2] >> 8) & 0x0003));
            CANTXModel._DataCANTXMSG[6] = (byte)((CANTXModel._ACOutputTXRawData.phaseShift[2]) & 0x0FF);
            CANTXModel._DataCANTXMSG[7] = 0;

            USBCanDriver.CANSendMessage(515, CANTXModel._DataCANTXMSG);
        }
        private static void ACOutputRawConvertMXP3()
        {
            CANTXModel._DataCANTXMSG[0] = (byte)((3 << 4) + ((CANTXModel._ACOutputTXRawData.Type[3]) & 0x0003));
            CANTXModel._DataCANTXMSG[1] = (byte)((CANTXModel._ACOutputTXRawData.Level[3] >> 4) & 0x00FF);
            CANTXModel._DataCANTXMSG[2] = (byte)(((CANTXModel._ACOutputTXRawData.Level[3] << 4) & 0x00F0) + ((CANTXModel._ACOutputTXRawData.Center[3] >> 8) & 0x000F));
            CANTXModel._DataCANTXMSG[3] = (byte)(CANTXModel._ACOutputTXRawData.Center[3] & 0x00FF);
            CANTXModel._DataCANTXMSG[4] = (byte)(((CANTXModel._ACOutputTXRawData.frequency[3]) >> 4) & 0x00FF);
            CANTXModel._DataCANTXMSG[5] = (byte)(((byte)(CANTXModel._ACOutputTXRawData.frequency[3] << 4) & 0x00F0) + ((byte)(CANTXModel._ACOutputTXRawData.phaseShift[3] >> 8) & 0x0003));
            CANTXModel._DataCANTXMSG[6] = (byte)((CANTXModel._ACOutputTXRawData.phaseShift[3]) & 0x0FF);
            CANTXModel._DataCANTXMSG[7] = 0;

            USBCanDriver.CANSendMessage(515, CANTXModel._DataCANTXMSG);
        }


        /// <summary>
        /// PUBLIC FUNCTION
        /// </summary>
        /// 
        public static void SendRequestMessage()
        {
            RequestMessageConvert();
            USBCanDriver.CANSendMessage(CANTXModel._RequestMessage.ReqMSGOutputID, CANTXModel._DataCANTXMSG);
        }

        public static void SendDigitalOutput()
        {
            DigitalOutputRawConvert();
            if (StateMachine.StateMachineData == StateMachine.StateRun)
            {
                USBCanDriver.CANSendMessage(CANTXModel._DigitalOutputTXRawData.DigitalOutputID, CANTXModel._DataCANTXMSG);
            }
        }

        public static void SendAnalogOutputMXP0()
        {
            AnalogOutputRawConvertMXP0();
            if (StateMachine.StateMachineData == StateMachine.StateRun)
            {
                USBCanDriver.CANSendMessage(CANTXModel._AnalogOutputTXRawData.AnalogOutputID, CANTXModel._DataCANTXMSG);
            }
        }
        public static void SendAnalogOutputMXP1()
        {
            AnalogOutputRawConvertMXP1();
            if (StateMachine.StateMachineData == StateMachine.StateRun)
            {
                USBCanDriver.CANSendMessage(CANTXModel._AnalogOutputTXRawData.AnalogOutputID, CANTXModel._DataCANTXMSG);
            }
        }
        public static void SendAnalogOutputMXP2()
        {
            AnalogOutputRawConvertMXP2();
            if (StateMachine.StateMachineData == StateMachine.StateRun)
            {
                USBCanDriver.CANSendMessage(CANTXModel._AnalogOutputTXRawData.AnalogOutputID, CANTXModel._DataCANTXMSG);
            }
        }
        public static void SendAnalogOutputMXP3()
        {
            AnalogOutputRawConvertMXP3();
            if (StateMachine.StateMachineData == StateMachine.StateRun)
            {
                USBCanDriver.CANSendMessage(CANTXModel._AnalogOutputTXRawData.AnalogOutputID, CANTXModel._DataCANTXMSG);
            }
        }

        public static void SendPWMOutputMXP0()
        {
            PWMOutputRawConvertMXP0();
            if (StateMachine.StateMachineData == StateMachine.StateRun)
            {
                USBCanDriver.CANSendMessage(CANTXModel._PWMOutputTXRawData.PWMOutputID, CANTXModel._DataCANTXMSG);
            }
        }
        public static void SendPWMOutputMXP1()
        {
            PWMOutputRawConvertMXP1();
            if (StateMachine.StateMachineData == StateMachine.StateRun)
            {
                USBCanDriver.CANSendMessage(CANTXModel._PWMOutputTXRawData.PWMOutputID, CANTXModel._DataCANTXMSG);
            }
        }
        public static void SendACOutputMXP0()
        {
            ACOutputRawConvertMXP0();
            if (StateMachine.StateMachineData == StateMachine.StateRun)
            {
                USBCanDriver.CANSendMessage(CANTXModel._ACOutputTXRawData.ACOutputID, CANTXModel._DataCANTXMSG);
            }
        }
        public static void SendACOutputMXP1()
        {
            ACOutputRawConvertMXP1();
            if (StateMachine.StateMachineData == StateMachine.StateRun)
            {
                USBCanDriver.CANSendMessage(CANTXModel._ACOutputTXRawData.ACOutputID, CANTXModel._DataCANTXMSG);
            }
        }
        public static void SendACOutputMXP2()
        {
            ACOutputRawConvertMXP2();
            USBCanDriver.CANSendMessage(CANTXModel._ACOutputTXRawData.ACOutputID, CANTXModel._DataCANTXMSG);
        }

        public static void SendACOutputMXP3()
        {
            ACOutputRawConvertMXP3();
            if (StateMachine.StateMachineData == StateMachine.StateRun)
            {
                USBCanDriver.CANSendMessage(CANTXModel._ACOutputTXRawData.ACOutputID, CANTXModel._DataCANTXMSG);
            }
        }
    }
}
