using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VixenEditor.VixenEditor.betterwatcher
{
	////////////////////////////////////////////////////////////////////////////////////// 
	////////////////////////////////////////////////////////////////////////////////////// 
	/// <summary>
	/// This enum is used to indicate which argument type is valid in the WatcherEventArgs 
	/// object.
	/// </summary>
	public enum ArgumentType { FileSystem, Renamed, Error, StandardEvent, PathAvailability };
}
