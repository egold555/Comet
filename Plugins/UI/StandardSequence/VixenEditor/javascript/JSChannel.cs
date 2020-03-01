using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VixenEditor.javascript
{
    public class JSChannel
    {
        private readonly int id;
        private readonly String name;
        private readonly List<JSEvent> events;
        public JSChannel(int id, String name, List<JSEvent> events)
        {
            this.id = id;
            this.name = name;
            this.events = events;
        }

        public int getId()
        {
            return this.id;
        }

        public String getName()
        {
            return this.name;
        }

        public ReadOnlyCollection<JSEvent> getEvents()
        {
            return this.events.AsReadOnly();
        }

        public ReadOnlyCollection<JSEvent> getEventsBetween(int index1, int index2)
        {
            return events.GetRange(index1, index2 - index1).AsReadOnly();
        }

        public JSEvent getEventAt(int index)
        {
            return events[index];
        }

        public int getEventCount()
        {
            return events.Count;
        }
    }
}
