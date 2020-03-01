using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VixenEditor.VixenEditor.javascript
{
    class JSSequence
    {
        private readonly ReadOnlyCollection<JSChannel> channels;

        public JSSequence(/*Take in a actual sequence*/)
        {

        }

		public ReadOnlyCollection<JSChannel> getChannels()
		{
			return channels;
		}

		public JSChannel getChannelById(int id)
		{
			foreach (JSChannel c in channels)
			{
				if (c.getId() == id)
				{
					return c;
				}
			}
			return null;
		}

		public JSChannel getChannelByName(String name)
		{
			foreach (JSChannel c in channels)
			{
				if (c.getName().ToLower() == name.ToLower())
				{
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
