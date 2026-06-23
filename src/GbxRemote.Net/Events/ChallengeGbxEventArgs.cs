using System;
using GbxRemoteNet.Structs;

namespace GbxRemoteNet.Events;

public class ChallengeGbxEventArgs : EventArgs
{
    /// <summary>
    /// Information about the map that will be/was played.
    /// </summary>
    public TmSChallengeInfo Map { get; set; }
}