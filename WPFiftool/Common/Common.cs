using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFiftool.Common
{
    public static class Common
    {
        #region INPUT
        //DIGITAL INPUT MAX CHANNEL VALUE
        public static readonly byte MaxDigitalOutputChannel = 16;

        //ANALOG INPUT MAX CHANNEL VALUE
        public static readonly byte MaxAnalogOutputChannel = 16;

        //PWM INPUT MAX CHANNEL VALUE
        public static readonly byte MaxPWMOutputChannel = 4;

        //AC INPUT MAX CHANNEL VALUE
        public static readonly byte MaxACOutputChannel = 4;

        #endregion

        #region OUTPUT
        //DIGITAL INPUT MAX CHANNEL VALUE
        public static readonly byte MaxDigitalInputChannel = 16;

        //ANALOG INPUT MAX CHANNEL VALUE
        public static readonly byte MaxAnalogInputChannel = 16;

        //PWM INPUT MAX CHANNEL VALUE
        public static readonly byte MaxPWMInputChannel = 4;

        //AC INPUT MAX CHANNEL VALUE
        public static readonly byte MaxACInputChannel = 4;
        #endregion
    }
}
