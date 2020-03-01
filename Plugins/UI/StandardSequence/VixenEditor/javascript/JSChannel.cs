using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VixenEditor.VixenEditor.javascript
{
    class JSChannel
    {
        private readonly int id;
        private readonly String name;
        private readonly ReadOnlyCollection<JSEvent> events;
        public JSChannel(int id, String name, List<JSEvent> events)
        {
            this.id = id;
            this.name = name;
            this.events = new ReadOnlyCollection<JSEvent>(events);
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
            return this.events;
        }

        public ReadOnlyCollection<JSEvent> getEventsBetween(JSEvent one, JSEvent two)
        {
            throw new NotImplementedException();
        }

        public JSEvent getEventAt(long time)
        {
            foreach (JSEvent e in events)
            {
                if (e.getLocationInSequence() == time)
                {
                    return e;
                }
            }

            return null;
        }
    }
}
