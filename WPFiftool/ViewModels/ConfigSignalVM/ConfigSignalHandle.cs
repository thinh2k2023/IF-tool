using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFiftool.Models.ConfigSignal;
using static WPFiftool.Models.Common_string;
using WPFiftool.ViewModels.SignalMonitor;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;

namespace WPFiftool.ViewModels.ConfigSignalVM
{
    public static class ConfigSignalHandle
    {
        private const UInt16 digitalInputOffset = 0;        //16 signals
        private const UInt16 analogInputOffset = 16;        //16 signals
        private const UInt16 PWMInputOffset = 32;           //8 signals
        private const UInt16 ACInputOffset = 40;            //8 signals

        private const UInt16 DigitalOutputOffset = 56;      //16 signals
        private const UInt16 AnalogOutputOffset = 72;       //16 signals
        private const UInt16 PWMOutputOffset = 88;          //8 signals
        private const UInt16 ACOutputOffset = 96;           //16 signals

        private static byte IDCnt = 0;
        public static ObservableCollection<ConfigSignalModel> SignalMonitorConfigData { get; set; } = new ObservableCollection<ConfigSignalModel>(); //contain all data of excel

        private static void ConfigEnableEditData()
        {

            //INPUT
            //digital input
            for (int i = digitalInputOffset; i < analogInputOffset; i++)
            {
                SignalMonitorConfigData[i].EditableSignal.IsUintEditable = false;
                SignalMonitorConfigData[i].EditableSignal.IsResolutionEditable = false;
                SignalMonitorConfigData[i].EditableSignal.IsOffsetEditable = false;
            }

            for (int i = analogInputOffset; i < PWMInputOffset; i++)
            {
                SignalMonitorConfigData[i].EditableSignal.IsResolutionEditable = false;
            }


            //OUTPUT
            //digital output
            for (int i = DigitalOutputOffset; i < AnalogOutputOffset; i++)
            {
                SignalMonitorConfigData[i].EditableSignal.IsUintEditable = false;
                SignalMonitorConfigData[i].EditableSignal.IsResolutionEditable = false;
                SignalMonitorConfigData[i].EditableSignal.IsOffsetEditable = false;
            }

            for (int i = AnalogOutputOffset; i < PWMOutputOffset; i++)
            {
                //SignalMonitorConfigData[i].EditableSignal.IsResolutionEditable = false;
            }
        }
        public static void AddData()
        {
            SignalMonitorConfigData.Clear();
            foreach (Signal_Title signal in InputMonitor.SignalMonitorDataSave)
            {
                string typeValue = signal.Type;
                string Channel = signal.Channel;
                string IO = signal.IO;
                string SignalName = signal.SignalName;
                string Element = signal.Element;
                string Value = signal.Value;
                string Unit = signal.Unit;
                string MinLabel = signal.MinLabel;
                string MaxLabel = signal.MaxLabel;
                string Resolution = signal.Resolution;
                string Offset = signal.Offset;
                string VisibleInput = signal.VisibleMonitor;
                string OrderMonitor = signal.OrderMonitor;
                string VisibleOutput = signal.VisibleOutput;
                string OrderOutput = signal.OrderOutput;

                bool isVisible = false;

                if (VisibleInput == "Yes")
                {
                    isVisible = true;
                }
                else
                {
                    isVisible = false;
                }

                SignalMonitorConfigData.Add(new ConfigSignalModel()
                {
                    ID = IDCnt,
                    IsVisible = isVisible,
                    Type = typeValue,
                    Channel = Channel,
                    IO = IO,
                    SignalName = SignalName,
                    Element = Element,
                    Value = Value,
                    Unit = Unit,
                    MinLabel = MinLabel,
                    MaxLabel = MaxLabel,
                    Resolution = Resolution,
                    Offset = Offset,
                    VisibleMonitor = VisibleInput,
                    OrderMonitor = OrderMonitor,
                    VisibleOutput = VisibleOutput,
                    OrderOutput = OrderOutput
                });

                IDCnt++;
            }

            ConfigEnableEditData();
            InputMonitor.FilterData();
        }
    }
}
