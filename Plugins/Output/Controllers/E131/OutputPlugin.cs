﻿//=====================================================================
//
//	OutputPlugin - E1.31 Plugin for Vixen 2.1.x.x/2.5.x.x
//
//		The original base code was generated by Visual Studio based
//		on the interface specification intrinsic to the Vixen plugin
//		technology. All other comments and code are the work of the
//		author. Some comments are based on the fundamental work
//		gleaned from published works by others in the Vixen community
//		including those of Jonathon Reinhart.
//
//		version 1.0.0.1 - 2 june 2010
//      version 1.1.0.0 - 1 July 2013 - John McAdams for Vixen+
//      version 1.2.0.0 - 1 May 2014 - John McAdams, fixed for Inline setup.
//
//=====================================================================

//=====================================================================
//
// Copyright (c) 2010 Joshua 1 Systems Inc. All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification, are
// permitted provided that the following conditions are met:
//
//    1. Redistributions of source code must retain the above copyright notice, this list of
//       conditions and the following disclaimer.
//
//    2. Redistributions in binary form must reproduce the above copyright notice, this list
//       of conditions and the following disclaimer in the documentation and/or other materials
//       provided with the distribution.
//
// THIS SOFTWARE IS PROVIDED BY JOSHUA 1 SYSTEMS INC. "AS IS" AND ANY EXPRESS OR IMPLIED
// WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL <COPYRIGHT HOLDER> OR
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
// CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
// SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON
// ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
// NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF
// ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//
// The views and conclusions contained in the software and documentation are those of the
// authors and should not be interpreted as representing official policies, either expressed
// or implied, of Joshua 1 Systems Inc.
//
//=====================================================================

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Xml;

using Controllers.E131.J1Sys;

using VixenPlus;

namespace Controllers.E131 {
    //-----------------------------------------------------------------
    //
    //	UniverseEntry - a class to keep all in memory info together
    //
    //-----------------------------------------------------------------

    public class UniverseEntry {
        // our row # (1-x) for message texts

        public int RowNum; // row # (1-x)

        // these are the fields from the configuration

        public bool Active; // is it active
        public int Universe; // universe number
        public int Start; // starting slot within events (zero based!!!)
        public int Size; // slot count
        public string Unicast; // unicast ip addr (if not null)
        public string Multicast; // multicast nic id (if not null)
        public int Ttl; // time to live

        // these are dynamic fields for processing events

        public Socket Socket; // socket to use
        public IPEndPoint DestIPEndPoint; // destination end point
        public byte[] PhyBuffer; // physical buffer
        public int EventRepeatCount; // how many identical pkts to skip (0 = none)

        // these are the per universe statistics

        public int PktCount; // packet count
        public Int64 SlotCount; // slot count


        public UniverseEntry(int rowNum, bool active, int universe, int start, int size, string unicast, string multicast, int ttl) {
            RowNum = rowNum;
            Active = active;
            Universe = universe;
            Start = start;
            Size = size;
            Unicast = unicast;
            Multicast = multicast;
            Ttl = ttl;

            Socket = null;
            DestIPEndPoint = null;
            PhyBuffer = null;
            EventRepeatCount = 0;

            PktCount = 0;
            SlotCount = 0;
        }


        public string RowUnivToText {
            get {
                var text = new StringBuilder();

                text.Append("Row ");
                text.Append(RowNum.ToString(CultureInfo.InvariantCulture));
                text.Append(":");
                text.Append(" Univ=");
                text.Append(Universe.ToString(CultureInfo.InvariantCulture));
                return text.ToString();
            }
        }

        public string InfoToText {
            get {
                var text = new StringBuilder();

                text.Append("Row ");
                text.Append(RowNum.ToString(CultureInfo.InvariantCulture));
                text.Append(":");
                text.Append(" Univ=");
                text.Append(Universe.ToString(CultureInfo.InvariantCulture));
                text.Append(" Start=");
                text.Append((Start + 1).ToString(CultureInfo.InvariantCulture));
                text.Append(" Size=");
                text.Append(Size.ToString(CultureInfo.InvariantCulture));
                if (Unicast != null) text.Append(" Unicast");
                if (Multicast != null) text.Append(" Multicast");
                text.Append(" TTL=");
                text.Append(Ttl.ToString(CultureInfo.InvariantCulture));
                return text.ToString();
            }
        }

        public string StatsToText {
            get {
                var text = new StringBuilder();

                text.Append("Row ");
                text.Append(RowNum.ToString(CultureInfo.InvariantCulture));
                text.Append(":");
                text.Append(" Univ=");
                text.Append(Universe.ToString(CultureInfo.InvariantCulture));
                text.Append("  Packets=");
                text.Append(PktCount.ToString(CultureInfo.InvariantCulture));
                text.Append("  Slots=");
                text.Append(SlotCount.ToString(CultureInfo.InvariantCulture));
                return text.ToString();
            }
        }
    }

    //-----------------------------------------------------------------
    //
    //	OutputPlugin - the output plugin class for vixen
    //
    //-----------------------------------------------------------------

    public class OutputPlugin : IEventDrivenOutputPlugIn {
        // our option settings
        private bool _warningsOption;
        private bool _statisticsOption;
        private int _eventRepeatCount;

        // a stringbuilder to store warnings, errors, and statistics
        private StringBuilder _messageTexts;

        // a table of UniverseEntry objects to hold all universes
        private List<UniverseEntry> _universeTable;

        // a sorted list of NetworkInterface object to use for sockets
        private SortedList<string, NetworkInterface> _nicTable;

        // plugin wide statistics
        private int _eventCnt;
        private long _totalTicks;

        // packet sequence # for E1.31
        private byte _seqNum; // should this be changed to per universe?

        // our guid - should it be Empty, Generated, or ESTA supplied?
        private Guid _guid;

        // the xml nodes supplied by vixen
        private XmlNode _setupNode;

        // plugin information supplied by vixen (by xml)
        private int _pluginChannelsFrom;
        private int _pluginChannelsTo;

        public OutputPlugin() {}


        public OutputPlugin(XmlNode setupNode) {
            _setupNode = setupNode;
        }


        //-------------------------------------------------------------
        //
        //	ToString() - vixen expects that a plugin will provide a
        //				 ToString() override returning the Name member
        //
        //-------------------------------------------------------------

        public override string ToString() {
            return Name;
        }


        //-------------------------------------------------------------
        //
        //	TryParseInt32() - a helper function for parsing xml numbers
        //
        //		we can't assume that someone didn't corrupt our xml
        //		and just use a Int32.Parse(). this wrapper uses TryParse()
        //		and is setup to silently apply a default value if needed.
        //
        //-------------------------------------------------------------

        public static Int32 TryParseInt32(string value, int defaultInt32) {
            Int32 converted;

            if (!Int32.TryParse(value, out converted)) converted = defaultInt32;

            return converted;
        }


        //-------------------------------------------------------------
        //
        //	LoadSetupNodeInfo() - transfer the xml dom to tables
        //
        //-------------------------------------------------------------

        private void LoadSetupNodeInfo() {
            var rowNum = 1;

            _universeTable = new List<UniverseEntry>();

            // init from/to to indicate not setup
            _pluginChannelsFrom = 0;
            _pluginChannelsTo = 0;

            // get the attribute collection and the from/to attributes if available
            var setupNodeAttributes = _setupNode.Attributes;
            if (setupNodeAttributes != null) {
                var fromAttribute = setupNodeAttributes.GetNamedItem("from");
                var toAttribute = setupNodeAttributes.GetNamedItem("to");

                // if we got both attributes, try and parse them
                if (fromAttribute != null && toAttribute != null) {
                    // try to parse both attributes
                    _pluginChannelsFrom = TryParseInt32(fromAttribute.Value, 0);
                    _pluginChannelsTo = TryParseInt32(toAttribute.Value, 0);

                    // if either is zero, make both zero to indicate not setup
                    if (_pluginChannelsFrom == 0 || _pluginChannelsTo == 0) {
                        _pluginChannelsFrom = 0;
                        _pluginChannelsTo = 0;
                    }
                }
            }

            _warningsOption = true;
            _statisticsOption = true;
            _eventRepeatCount = 0;

            _guid = Guid.Empty;

            foreach (XmlNode child in _setupNode.ChildNodes) {
                var attributes = child.Attributes;
                XmlNode attribute;

                if (child.Name == "Guid") {
                    if (attributes != null && (attribute = attributes.GetNamedItem("id")) != null) {
                        try {
                            _guid = new Guid(attribute.Value);
                        }

                        catch {
                            _guid = Guid.Empty;
                        }
                    }
                }

                if (child.Name == "Options") {
                    _warningsOption = false;
                    if (attributes != null && (attribute = attributes.GetNamedItem("warnings")) != null)
                        if (attribute.Value == "True") _warningsOption = true;

                    _statisticsOption = false;
                    if (attributes != null && (attribute = attributes.GetNamedItem("statistics")) != null)
                        if (attribute.Value == "True") _statisticsOption = true;

                    _eventRepeatCount = 0;
                    if (attributes != null && (attribute = attributes.GetNamedItem("eventRepeatCount")) != null)
                        _eventRepeatCount = TryParseInt32(attribute.Value, 0);
                }

                if (child.Name != "Universe") {
                    continue;
                }
                var active = false;
                var universe = 1;
                var start = 1;
                var size = 1;
                string unicast = null;
                string multicast = null;
                var ttl = 1;

                if (attributes != null && (attribute = attributes.GetNamedItem("active")) != null)
                    if (attribute.Value == "True") active = true;

                if (attributes != null && (attribute = attributes.GetNamedItem("number")) != null)
                    universe = TryParseInt32(attribute.Value, 1);

                if (attributes != null && (attribute = attributes.GetNamedItem("start")) != null)
                    start = TryParseInt32(attribute.Value, 1);

                if (attributes != null && (attribute = attributes.GetNamedItem("size")) != null)
                    size = TryParseInt32(attribute.Value, 1);

                if (attributes != null && (attribute = attributes.GetNamedItem("unicast")) != null)
                    unicast = attribute.Value;

                if (attributes != null && (attribute = attributes.GetNamedItem("multicast")) != null)
                    multicast = attribute.Value;

                if (attributes != null && (attribute = attributes.GetNamedItem("ttl")) != null)
                    ttl = TryParseInt32(attribute.Value, 1);

                _universeTable.Add(new UniverseEntry(rowNum++, active, universe, start - 1, size, unicast, multicast, ttl));
            }

            if (_guid == Guid.Empty) _guid = Guid.NewGuid();
        }

        #region IEventDrivenOutputPlugIn Members

        //-------------------------------------------------------------
        //
        //	Event() - called each time interval that one of the
        //			  channels within our bank changes with ALL
        //			  channelValues
        //
        //			  to insure that this is called for EVERY event
        //			  the user CAN add an unused channel that changes
        //			  every event.
        //
        //-------------------------------------------------------------

        public void Event(byte[] channelValues) {
            var stopWatch = Stopwatch.StartNew();

            _eventCnt++;

            foreach (var uE in _universeTable.Where(uE => uE.Active)) {
                if (_eventRepeatCount > 0) {
                    if (uE.EventRepeatCount-- > 0) {
                        if (E131Pkt.CompareSlots(uE.PhyBuffer, channelValues, uE.Start, uE.Size)) continue;
                    }
                }

                E131Pkt.CopySeqNumSlots(uE.PhyBuffer, channelValues, uE.Start, uE.Size, _seqNum++);
                uE.Socket.SendTo(uE.PhyBuffer, uE.DestIPEndPoint);
                uE.EventRepeatCount = _eventRepeatCount;

                uE.PktCount++;
                uE.SlotCount += uE.Size;
            }

            stopWatch.Stop();

            _totalTicks += stopWatch.ElapsedTicks;
        }


        //-------------------------------------------------------------
        //
        //	Initialize() - called anytime vixen needs to make sure the
        //				   plugin's setup or initialization is up to
        //				   date. Initialize is called before the plugin
        //				   is setup, before sequence execution, and
        //				   other times. It's called from multiple
        //				   places at any time, therefore the plugin
        //				   can make no assumptions about the state
        //				   of the program or sequence due to a call
        //				   to initialize.
        //
        //-------------------------------------------------------------

        public void Initialize(IExecutable executableObject, SetupData setupData, XmlNode setupNode) {
            // save a local copy of the setup objects

            _setupNode = setupNode;

            // load all of our xml into working objects

            LoadSetupNodeInfo();

            // find all of the network interfaces & build a sorted list indexed by Id

            _nicTable = new SortedList<string, NetworkInterface>();

            var nics = NetworkInterface.GetAllNetworkInterfaces();

            if (nics.Length > 0)
                foreach (var nic in nics.Where(nic => nic.NetworkInterfaceType.CompareTo(NetworkInterfaceType.Tunnel) != 0)) {
                    _nicTable.Add(nic.Id, nic);
                }
        }

        #endregion

        #region IOutputPlugIn Members

        //-------------------------------------------------------------
        //
        //	HardwareMap member - tell vixen what hardware we use
        //
        //-------------------------------------------------------------

        public HardwareMap[] HardwareMap {
            get {
                // define objects
                var activeCnt = _universeTable.Where(uE => uE.Active).Count(uE => uE.Unicast != null || uE.Multicast != null);

                // find how many active universes we have

                // create a HardwareMap array to match active count
                var hardwareMap = new HardwareMap[activeCnt];

                // reset count to use as an index
                activeCnt = 0;

                // build the table for each active universe
                foreach (var uE in _universeTable.Where(uE => uE.Active)) {
                    // unicast is pretty straight forward
                    if (uE.Unicast != null) {
                        hardwareMap[activeCnt++] = new HardwareMap("Universes (E1.31) Unicast >> " + uE.Unicast, uE.Universe);
                    }

                        // multicast has to check for valid nic Id in case hardware has changed
                    else if (uE.Multicast != null) {
                        var nicName = "<<< invalid nic id >>>";

                        if (_nicTable.ContainsKey(uE.Multicast)) nicName = _nicTable[uE.Multicast].Name;

                        hardwareMap[activeCnt++] = new HardwareMap("Universes (E1.31) Multicast >> " + nicName, uE.Universe);
                    }
                }

                return hardwareMap;
            }
        }

        //-------------------------------------------------------------
        //
        //	Setup() - called when the user has requested to setup
        //			  the plugin instance
        //
        //-------------------------------------------------------------

        public Control Setup() {
            // define/create objects
            using (var setupForm = new SetupForm()) {

                // reload all of our xml into working objects
                LoadSetupNodeInfo();

                // if our channels from/to are setup then tell the setupForm
                if (_pluginChannelsFrom != 0 && _pluginChannelsTo != 0) {
                    setupForm.PluginChannelCount = _pluginChannelsTo - _pluginChannelsFrom + 1;
                }

                // for each universe add it to setup form
                foreach (var uE in _universeTable) {
                    setupForm.UniverseAdd(uE.Active, uE.Universe, uE.Start + 1, uE.Size, uE.Unicast, uE.Multicast, uE.Ttl);
                }

                setupForm.WarningsOption = _warningsOption;
                setupForm.StatisticsOption = _statisticsOption;
                setupForm.EventRepeatCount = _eventRepeatCount;

                if (setupForm.ShowDialog() != DialogResult.OK) {
                    return null;
                }
                // first get rid of our old children
                while (_setupNode.ChildNodes.Count > 0) {
                    _setupNode.RemoveChild(_setupNode.ChildNodes[0]);
                }

                // add the Guid child
                if (_setupNode.OwnerDocument != null) {
                    var newChild = _setupNode.OwnerDocument.CreateElement("Guid");
                    newChild.SetAttribute("id", _guid.ToString());
                    _setupNode.AppendChild(newChild);

                    // add the Options child
                    // ReSharper disable PossibleNullReferenceException
                    newChild = _setupNode.OwnerDocument.CreateElement("Options");
                    // ReSharper restore PossibleNullReferenceException
                    newChild.SetAttribute("warnings", setupForm.WarningsOption.ToString());
                    newChild.SetAttribute("statistics", setupForm.StatisticsOption.ToString());
                    newChild.SetAttribute("eventRepeatCount", setupForm.EventRepeatCount.ToString(CultureInfo.InvariantCulture));
                    _setupNode.AppendChild(newChild);

                    // add each of the universes as a child
                    for (var i = 0; i < setupForm.UniverseCount; i++) {
                        var active = true;
                        var universe = 0;
                        var start = 0;
                        var size = 0;
                        var unicast = string.Empty;
                        var multicast = string.Empty;
                        var ttl = 0;

                        if (!setupForm.UniverseGet(i, ref active, ref universe, ref start, ref size, ref unicast, ref multicast, ref ttl)) {
                            continue;
                        }
                        // ReSharper disable PossibleNullReferenceException
                        newChild = _setupNode.OwnerDocument.CreateElement("Universe");
                        // ReSharper restore PossibleNullReferenceException

                        newChild.SetAttribute("active", active.ToString());
                        newChild.SetAttribute("number", universe.ToString(CultureInfo.InvariantCulture));
                        newChild.SetAttribute("start", start.ToString(CultureInfo.InvariantCulture));
                        newChild.SetAttribute("size", size.ToString(CultureInfo.InvariantCulture));
                        if (unicast != null) newChild.SetAttribute("unicast", unicast);
                        else if (multicast != null) newChild.SetAttribute("multicast", multicast);
                        newChild.SetAttribute("ttl", ttl.ToString(CultureInfo.InvariantCulture));

                        _setupNode.AppendChild(newChild);
                    }
                }

                // update in memory table to match xml
                LoadSetupNodeInfo();
            }

            return null;
        }


        public void GetSetup() {
        }


        public void CloseSetup() {
        }


        public bool SupportsLiveSetup() {
            return false;
        }


        public bool SettingsValid() {
            return true;
        }


        //-------------------------------------------------------------
        //
        //	Shutdown() - called when execution is stopped or the
        //				 plugin instance is no longer going to be
        //				 referenced
        //
        //-------------------------------------------------------------

        public void Shutdown() {
            // keep track of interface ids we have shutdown
            var idList = new SortedList<string, int>();

            // iterate through universetable
            foreach (var uE in _universeTable) {
                // assume multicast
                var id = uE.Multicast;

                // if unicast use psuedo id
                if (uE.Unicast != null) id = "unicast";

                // if active
                if (!uE.Active) {
                    continue;
                }
                // and a usable socket
                if (uE.Socket == null) {
                    continue;
                }
                // if not already done
                if (idList.ContainsKey(id)) {
                    continue;
                }
                // record it & shut it down
                idList.Add(id, 1);
                uE.Socket.Shutdown(SocketShutdown.Both);
                uE.Socket.Close();
            }

            if (!_statisticsOption) {
                return;
            }
            if (_messageTexts.Length > 0) _messageTexts.AppendLine();

            _messageTexts.AppendLine("Events: " + _eventCnt);
            _messageTexts.AppendLine("Total Time: " + _totalTicks + " Ticks;  " + TimeSpan.FromTicks(_totalTicks).Milliseconds + " ms");

            foreach (var uE in _universeTable.Where(uE => uE.Active)) {
                _messageTexts.AppendLine();
                _messageTexts.Append((string) uE.StatsToText);
            }

            J1MsgBox.ShowMsg("Plugin Statistics:", _messageTexts.ToString(), "J1Sys E1.31 Vixen Plugin", MessageBoxButtons.OK,
                             MessageBoxIcon.Information);
        }


        //-------------------------------------------------------------
        //
        //	Startup() - called when a sequence is executed
        //
        //
        //	todo:
        //
        //		1) probably add error checking on all 'new' operations
        //		and system calls
        //
        //		2) better error reporting and logging
        //	
        //-------------------------------------------------------------


        public void Startup() {

            // a single socket to use for unicast (if needed)
            Socket unicastSocket = null;

            // a sortedlist containing the multicast sockets we've already done
            var nicSockets = new SortedList<string, Socket>();

            // reload all of our xml into working objects
            LoadSetupNodeInfo();

            // initialize plugin wide stats
            _eventCnt = 0;
            _totalTicks = 0;

            // initialize sequence # for E1.31 packet (should it be per universe?)
            _seqNum = 0;

            // initialize messageTexts stringbuilder to hold all warnings/errors
            _messageTexts = new StringBuilder();

            // check for configured from/to
            if (_pluginChannelsFrom == 0 && _pluginChannelsTo == 0) {
                foreach (var uE in _universeTable) {
                    uE.Active = false;
                }

                _messageTexts.AppendLine("Plugin Channels From/To Configuration Error!!");
            }

            // now we need to scan the universeTable
            foreach (var uE in _universeTable) {
                // active? - check universeentry start and size
                if (uE.Active) {
                    // is start out of range?
                    if (_pluginChannelsFrom + uE.Start > _pluginChannelsTo) {
                        _messageTexts.AppendLine("Start Error - " + uE.InfoToText);
                        uE.Active = false;
                    }

                    // is size (end) out of range?
                    if (_pluginChannelsFrom + uE.Start + uE.Size - 1 > _pluginChannelsTo) {
                        _messageTexts.AppendLine("Start/Size Error - " + uE.InfoToText);
                        uE.Active = false;
                    }
                }

                // if it's still active we'll look into making a socket for it
                if (!uE.Active) {
                    continue;
                }
                // if it's unicast it's fairly easy to do
                IPAddress ipAddress;
                if (uE.Unicast != null) {
                    // is this the first unicast universe?
                    if (unicastSocket == null) {
                        // yes - make a new socket to use for ALL unicasts
                        unicastSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                    }

                    // use the common unicastsocket
                    uE.Socket = unicastSocket;

                    // try to parse our ip address
                    if (!IPAddress.TryParse(uE.Unicast, out ipAddress)) {
                        // oops - bad ip, fuss and deactivate
                        uE.Active = false;
                        uE.Socket = null;
                        _messageTexts.AppendLine("Invalid Unicast IP: " + uE.Unicast + " - " + uE.RowUnivToText);
                    }

                    else {
                        // if good, make our destination endpoint
                        uE.DestIPEndPoint = new IPEndPoint(ipAddress, 5568);
                    }
                }

                // if it's multicast roll up your sleeves we've got work to do
                if (uE.Multicast != null) {
                    // create an ipaddress object based on multicast universe ip rules
                    var multicastIPAddress = new IPAddress(new byte[] {239, 255, (byte) (uE.Universe >> 8), (byte) (uE.Universe & 0xff)});
                    // create an ipendpoint object based on multicast universe ip/port rules
                    var multicastIPEndPoint = new IPEndPoint(multicastIPAddress, 5568);

                    // first check for multicast id in nictable
                    if (!_nicTable.ContainsKey(uE.Multicast)) {
                        // no - deactivate and scream & yell!!
                        uE.Active = false;
                        _messageTexts.AppendLine("Invalid Multicast NIC ID: " + uE.Multicast + " - " + uE.RowUnivToText);
                    }

                    else {
                        // yes - let's get a working networkinterface object
                        var networkInterface = _nicTable[uE.Multicast];

                        // have we done this multicast id before?
                        if (nicSockets.ContainsKey(uE.Multicast)) {
                            // yes - easy to do - use existing socket
                            uE.Socket = nicSockets[uE.Multicast];

                            // setup destipendpoint based on multicast universe ip rules
                            uE.DestIPEndPoint = multicastIPEndPoint;
                        }

                            // is the interface up?
                        else if (networkInterface.OperationalStatus != OperationalStatus.Up) {
                            // no - deactivate and scream & yell!!
                            uE.Active = false;
                            _messageTexts.AppendLine("Multicast Interface Down: " + networkInterface.Name + " - " + uE.RowUnivToText);
                        }

                        else {
                            // new interface in 'up' status - let's make a new udp socket
                            uE.Socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                            // get a working copy of ipproperties
                            var ipProperties = networkInterface.GetIPProperties();

                            // get a working copy of the ipv4interfaceproperties
                            ipProperties.GetIPv4Properties();

                            // get a working copy of all unicasts
                            var unicasts = ipProperties.UnicastAddresses;

                            ipAddress = null;

                            foreach (var unicast in unicasts.Where(unicast => unicast.Address.AddressFamily == AddressFamily.InterNetwork)) {
                                ipAddress = unicast.Address;
                            }

                            if (ipAddress == null) {
                                _messageTexts.AppendLine("No IP On Multicast Interface: " + networkInterface.Name + " - " + uE.InfoToText);
                            }

                            else {
                                // set the multicastinterface option
                                uE.Socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastInterface, ipAddress.GetAddressBytes());
                                // set the multicasttimetolive option
                                uE.Socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastTimeToLive, uE.Ttl);

                                // setup destipendpoint based on multicast universe ip rules
                                uE.DestIPEndPoint = multicastIPEndPoint;

                                // add this socket to the socket table for reuse
                                nicSockets.Add(uE.Multicast, uE.Socket);
                            }
                        }
                    }
                }

                // if still active we need to create an empty packet
                if (!uE.Active) {
                    continue;
                }
                var zeroBfr = new byte[uE.Size];
                var e131Pkt = new E131Pkt(_guid, "", 0, (ushort) uE.Universe, zeroBfr, 0, uE.Size);
                uE.PhyBuffer = e131Pkt.PhyBuffer;
            }

            // any warnings/errors recorded?
            if (_messageTexts.Length > 0)
                // should we display them
                if (_warningsOption) {
                    // show our warnings/errors
                    J1MsgBox.ShowMsg("The following warnings and errors were detected during startup:", _messageTexts.ToString(),
                                     "Startup Warnings/Errors", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    // discard warning/errors after reporting them
                    _messageTexts = new StringBuilder();
                }
        }

        #endregion

        #region IPlugIn Members

        //-------------------------------------------------------------
        //
        //	Author member - return our Author string
        //
        //-------------------------------------------------------------

        public string Author {
            get { return "Edward D. Bryson (J1Sys) and John McAdams (Vixen+)"; }
        }

        //-------------------------------------------------------------
        //
        //	Description member - return our Description string
        //
        //-------------------------------------------------------------

        public string Description {
            get { return "J1Sys E1.31 Vixen Plugin v1.1"; }
        }

        //-------------------------------------------------------------
        //
        //	Name member - return our Name string
        //
        //-------------------------------------------------------------

        public string Name {
            get { return "J1Sys E1.31"; }
        }

        #endregion
    }
}