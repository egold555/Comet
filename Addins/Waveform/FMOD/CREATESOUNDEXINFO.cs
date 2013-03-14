﻿namespace FMOD
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct CREATESOUNDEXINFO
    {
        public int cbsize;
        public uint length;
        public uint fileoffset;
        public int numchannels;
        public int defaultfrequency;
        public SOUND_FORMAT format;
        public uint decodebuffersize;
        public int initialsubsound;
        public int numsubsounds;
        public IntPtr inclusionlist;
        public int inclusionlistnum;
        public SOUND_PCMREADCALLBACK pcmreadcallback;
        public SOUND_PCMSETPOSCALLBACK pcmsetposcallback;
        public SOUND_NONBLOCKCALLBACK nonblockcallback;
        public string dlsname;
        public string encryptionkey;
        public int maxpolyphony;
        public IntPtr userdata;
        public SOUND_TYPE suggestedsoundtype;
        public FILE_OPENCALLBACK useropen;
        public FILE_CLOSECALLBACK userclose;
        public FILE_READCALLBACK userread;
        public FILE_SEEKCALLBACK userseek;
        public SPEAKERMAPTYPE speakermap;
        public IntPtr initialsoundgroup;
        public uint initialseekposition;
        public TIMEUNIT initialseekpostype;
    }
}

