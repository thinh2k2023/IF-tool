using System;
using System.IO.Ports;
using System.Windows;

namespace WPFiftool.Driver
{
    public static class USBCanDriver
    {
        public static SerialPort _serialPort = new SerialPort();   //create a new serial port
        public static event EventHandler dataUpdatedEvent = delegate { };   //create a event handle 
        private static event EventHandler EventTransmitedData = delegate { };   //event data is transmitted

        private const byte PacketStartByte = 0xAA;    //packet start
        private const byte ConfigFrameByte = 0xC8;
        private const byte EndFrameByte = 0x55;

        private static byte[] ComDataReceived;    //array contain the data received from USB to CAN

        private const byte USBCANFrameLength = 13; //Frame send from USB to CAN
        private const byte CANDataLength = 8;   //CAN data length code

        private static string _CANID;
        private static byte[] _CANDATA = new byte[CANDataLength];


        /// <summary>
        /// this function just transmit with standard frame
        /// </summary>
        /// <param name="CANID"></param>
        /// <param name="CANData"></param>
        public static void CANSendMessage(UInt16 CANID, byte[] CANData)
        {
            byte[] data_frame = new byte[USBCANFrameLength];   //create a temp data to send

            /* Byte 0: Packet Start */
            data_frame[0] = PacketStartByte;

            /* Byte 1: CAN Bus Data Frame Information */
            data_frame[1] = ConfigFrameByte;


            /* Byte 2 to 3: ID */
            data_frame[2] = (byte)(CANID & 0x00FF); // ID lsb
            data_frame[3] = (byte)((CANID >> 8) & 0x00FF); //ID msb

            /* Byte 4 to 11: Data */
            data_frame[4] = CANData[0];     //D0
            data_frame[5] = CANData[1];     //D1
            data_frame[6] = CANData[2];     //D2
            data_frame[7] = CANData[3];     //D3
            data_frame[8] = CANData[4];     //D4
            data_frame[9] = CANData[5];     //D5
            data_frame[10] = CANData[6];    //D6
            data_frame[11] = CANData[7];    //D7
            /* Last byte: End of frame */
            data_frame[12] = EndFrameByte;

            /* Write data to serial port*/
            if (_serialPort.IsOpen != false)
            {
                _serialPort.Write(data_frame, 0, USBCANFrameLength);    //0 is offset, write from 0 to USBCANFrameLength
            }
        }

        public static bool CheckFrameDataRecv(byte[] frame)
        {
            //check PacketStartByte, ConfigFrameByte and EndFrameByte value
            if ((frame[0] != PacketStartByte) || (frame[1] != ConfigFrameByte) || (frame[12] != EndFrameByte))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e) //  hàm đăng kí sự kiện
        {

            if (e.EventType == SerialData.Eof)
            {
                return;     //read Eof -> return
            }
            else
            {
                //do nothing
            };

            SerialPort sp = (SerialPort)sender; // get serial port object
            byte data_num = (byte)sp.BytesToRead;  //get number of byte data

            ComDataReceived = new byte[data_num];  //create a array that contain the data



            Console.Write("Data receiced:");
            for (byte i = 0; i < data_num; i++)
            {
                if (_serialPort.IsOpen)
                {
                    ComDataReceived[i] = (byte)sp.ReadByte();
                    Console.Write("\t" + ComDataReceived[i]);
                }                    
            }
            Console.Write("\n");


            if ((data_num >= 13) && (data_num % USBCANFrameLength == 0))
            {
                if (CheckFrameDataRecv(ComDataReceived) != false)
                {
                    byte quotientDataLength = (byte)(data_num / USBCANFrameLength);     //get quotient

                    for (byte i = 0; i < quotientDataLength; i++)
                    {
                        for (byte j2 = 0; j2 < 8; j2++)
                        {
                            _CANDATA[j2] = ComDataReceived[j2 + 13 * (i) + 4];
                        }
                        _CANID = (ComDataReceived[3 + 13 * (i)] * 256 + ComDataReceived[2 + 13 * (i)]).ToString();

                        dataUpdatedEvent(null, EventArgs.Empty);     //create a event after received data
                    }
                }
                else
                {
                    sp.DiscardInBuffer();   //clear buffer if data is not correct
                }

            }
            else
            {
                sp.DiscardInBuffer();   //clear buffer if data is not correct

            }
        }

        public static void init_serial_port(String PortName)
        {
            if (!_serialPort.IsOpen)
            {
                _serialPort.PortName = PortName;
                _serialPort.BaudRate = 115200;
                _serialPort.DataBits = 8;
                _serialPort.Parity = Parity.None;
                _serialPort.StopBits = StopBits.One;
                _serialPort.Open();
                _serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            }
            else
            {
                MessageBox.Show("The port is openning");
            }
        }

        public static void CloseSerialPort()
        {
            if (_serialPort.IsOpen != false)
            {
                _serialPort.DataReceived -= DataReceivedHandler;
                _serialPort.BaseStream.Close();
                _serialPort.Close();
            }
        }

        public static EventHandler GetTransmitedEvent
        {
            set
            {
                EventTransmitedData = value;
            }
            get
            {
                return EventTransmitedData;
            }
        }

        public static void CANInit(string port)
        {
            init_serial_port(port);
        }

        public static void CANClose()
        {
            CloseSerialPort();
        }


        public static string getCANID
        {
            get
            {
                return _CANID;
            }
        }
        public static void CheckCANTransmited()
        {
            try
            {
                if (_serialPort.BytesToWrite == 0)
                {
                    EventTransmitedData(null, EventArgs.Empty);
                }
                else
                {
                    //do nothing
                }
            }
            catch
            {

            }
        }

        public static byte[] getCANDATA
        {
            get
            {
                return _CANDATA;
            }
        }
    }
}
