using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VixenEditor.VixenEditor.javascript
{
    class JSEvent
    {
        public static readonly byte MIN_VALUE = 0;
        public static readonly byte MAX_VALUE = 255;

        private byte value;
        private readonly long locationInSequence;

        public JSEvent(long locationInSequence) : this(locationInSequence, MAX_VALUE) {
        }

        public JSEvent(long locationInSequence, byte value)
        {
            this.locationInSequence = locationInSequence;
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

        public long getLocationInSequence()
        {
            return locationInSequence;
        }

        public Boolean isOn()
        {
            return this.value > 0;
        }

    }
}
