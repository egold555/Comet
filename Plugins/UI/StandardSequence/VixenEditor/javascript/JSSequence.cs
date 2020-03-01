using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VixenPlus;

namespace VixenEditor.javascript
{
    public class JSSequence
    {
        private List<JSChannel> channels;

        public JSSequence(EventSequence sequence)
        {
            channels = new List<JSChannel>();
            for (int id = 0; id < sequence.Channels.Count; ++id) {
                Channel channel = sequence.Channels[id];
                int eventRow = sequence.FullChannels.IndexOf(channel);
                List<JSEvent> events = new List<JSEvent>();
                for (int eventCol = 0; eventCol < sequence.TotalEventPeriods; ++eventCol) {
                    events.Add(new JSEvent(sequence.EventValues[eventRow, eventCol]));
                }

                channels.Add(new JSChannel(id, channel.Name, events));
            }
        }

        internal void CopyToSequence(EventSequence sequence)
        {
            for (int id = 0; id < sequence.Channels.Count; ++id) {
                Channel channel = sequence.Channels[id];
                int eventRow = sequence.FullChannels.IndexOf(channel);
                for (int eventCol = 0; eventCol < sequence.TotalEventPeriods; ++eventCol) {
                    sequence.EventValues[eventRow, eventCol] = channels[id].getEventAt(eventCol).getValue();
                }
            }
        }

        public int getEventCount()
        {
            return channels[0].getEventCount();
        }

        public JSChannel[] getChannels()
        {
            return channels.ToArray();
        }

        public JSChannel getChannelById(int id)
        {
            foreach (JSChannel c in channels) {
                if (c.getId() == id) {
                    return c;
                }
            }
            return null;
        }

        public JSChannel getChannelByName(String name)
        {
            foreach (JSChannel c in channels) {
                if (c.getName().ToLower() == name.ToLower()) {
                    return c;
                }
            }
            return null;
        }

        public JSChannel[] getChannelsByName(String[] names)
        {
            List<JSChannel> result = new List<JSChannel>();
            foreach (string name in names) {
                result.Add(getChannelByName(name));
            }
            return result.ToArray(); ;
        }

        public JSArea[] getBeatMarkerAreas(JSChannel markerChannel, JSChannel[] channels)
        {
            int lastCol = getEventCount();
            List<JSArea> areas = new List<JSArea>();
            for (int col = 0; col < lastCol; ++col) { 
                if (markerChannel.getEventAt(col).isOn()) {
                    int next;
                    for (next = col + 1; next < lastCol; ++next) {
                        if (markerChannel.getEventAt(next).isOn())
                            break;
                    }
                    areas.Add(new JSArea(channels.ToList(), col, next));
                    col = next - 1;
                }
            }

            return areas.ToArray();
        }

        internal List<JSChannel> getChannelSubset(int first, int last)
        {
            return channels.GetRange(first, last - first);
        }
    }
}
