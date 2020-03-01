using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VixenEditor.javascript
{
    public class JSArea
    {
        private readonly List<JSChannel> channels;
        private readonly int startIndex;
        private readonly int endIndex;

        public JSArea(List<JSChannel> channels, int startIndex, int endIndex)
        {
            this.channels = channels;
            this.startIndex = startIndex;
            this.endIndex = endIndex;
        }

        public JSChannel[] getChannels()
        {
            return channels.ToArray();
        }

        public JSEvent getEventAt(int row, int col)
        {
            return channels[row].getEventAt(col + startIndex);
        }

        public int getRowCount()
        {
            return channels.Count;
        }

        public int getColumnCount()
        {
            return endIndex - startIndex;
        }

        public void fillChannel(int row, byte value)
        {
            channels[row].fillMany(startIndex, endIndex, value);
        }
    }
}
