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
        public ReadOnlyCollection<JSChannel> getChannels()
        {
            return channels.AsReadOnly();
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

        public JSSelectedArea getSelectedArea()
        {
            throw new NotImplementedException();
        }
    }
}
