using DocumentFormat.OpenXml.Vml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WPFiftool.Models.ConfigSignal
{
    public class ConfigSignalModel : SignalModel
    {

        public override event PropertyChangedEventHandler PropertyChanged;

        private byte id;

        public byte ID
        {

            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ID)));
                }
            }
        }


        private bool isVisible;

        public bool IsVisible
        {

            get { return isVisible; }
            set
            {
                if (isVisible != value)
                {
                    isVisible = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsVisible)));
                }
            }
        }

        private EditableSignal editableSignal = new EditableSignal();

        public EditableSignal EditableSignal
        {
            get { return editableSignal; }
            set
            {
                if (editableSignal != value)
                {
                    editableSignal = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EditableSignal)));
                }
            }
        }
    }

    public class EditableSignal
    {
        private bool isUintEditable = true; // Default editable state

        public bool IsUintEditable
        {

            get { return isUintEditable; }
            set
            {
                if (isUintEditable != value)
                {
                    isUintEditable = value;
                }
                else
                {
                    //do nothing
                }
            }
        }

        private bool isMinMaxEditable = true; // Default editable state

        public bool IsMinMaxEditable
        {

            get { return isMinMaxEditable; }
            set
            {
                if (isMinMaxEditable != value)
                {
                    isMinMaxEditable = value;
                }
                else
                {
                    //do nothing
                }
            }
        }

        private bool isResolutionEditable = true; // Default editable state

        public bool IsResolutionEditable
        {
            get { return isResolutionEditable; }
            set
            {
                if (isResolutionEditable != value)
                {
                    isResolutionEditable = value;
                }
                else
                {
                    //do nothing
                }
            }
        }

        private bool isOffsetEditable = true; // Default editable state

        public bool IsOffsetEditable
        {
            get { return isOffsetEditable; }
            set
            {
                if (isOffsetEditable != value)
                {
                    isOffsetEditable = value;
                }
                else
                {
                    //do nothing
                }
            }
        }
    }
}
