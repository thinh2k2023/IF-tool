using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFiftool.Driver;

namespace WPFiftool.ViewModels.CANViewModel
{
    public class CANControl
    {
        CANRawTXViewModel _CANRawTXViewModel = new CANRawTXViewModel();
        public void InitializeDataTX()
        {
            for (UInt16 i = 0; i < 16; i++)
            {
                //initial analog output
                //_CANRawTXViewModel._OutputControlRawValueModel._AnalogOutputTXRawData.analogOutputData[i] = 4095;
            }

            for (UInt16 i = 0; i < 4; i++)
            {
                //initial analog output
                //_CANRawTXViewModel._OutputControlRawValueModel._AnalogOutputTXRawData.analogOutputData[i] = 4095;

                ////initial ac output
                //_CANRawTXViewModel._OutputControlRawValueModel._ACOutputTXRawData.frequency[i] = 2000;
                //_CANRawTXViewModel._OutputControlRawValueModel._ACOutputTXRawData.Level[i] = 4095;
                //_CANRawTXViewModel._OutputControlRawValueModel._ACOutputTXRawData.phaseShift[i] = 60;
                //_CANRawTXViewModel._OutputControlRawValueModel._ACOutputTXRawData.center[i] = 4095;
                //_CANRawTXViewModel._OutputControlRawValueModel._ACOutputTXRawData.Type[i] = 3;
            }
        }

        public void Close_serial_port(String PortName)
        {
            try
            {
                //USBCanDriver._serialPort.Close();
            }
            catch { }
        }
    }
}
