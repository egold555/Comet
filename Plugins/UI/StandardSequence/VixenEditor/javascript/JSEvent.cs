using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VixenEditor.javascript
{
    public class JSEvent
    {
        public static readonly byte MIN_VALUE = 0;
        public static readonly byte MAX_VALUE = 255;

        private byte value;

        public JSEvent(byte value)
        {
            this.value = value;
        }

        public byte getValue()
        {
            return this.value;
        }

        public void setValue(byte newValue)
        {
            this.value = newValue;
        }

        public Boolean isOn()
        {
            return this.value > 0;
        }

    }
}
