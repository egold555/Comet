﻿using System;
using System.Runtime.CompilerServices;

namespace FMOD
{
	public delegate RESULT DSP_READCALLBACK(ref DSP_STATE dsp_state, IntPtr inbuffer, IntPtr outbuffer, uint length, int inchannels, int outchannels);
}

