using System;
using GbxRemoteNet.Structs;

namespace GbxRemoteNet.Events;

public class ChallengeBeginGbxEventArgs : EventArgs
{
    /// <summary>
    /// Information about the challenge that will be/was played.
    /// </summary>
    public TmSChallengeInfo Challenge { get; set; }
    public bool WarmpUp { get; set; }
    public bool MatchContinuation { get; set; }
}

public class ChallengeEndGbxEventArgs : EventArgs
{
    /// <summary>
    /// Information about the challenges that was played.
    /// </summary>
    public TmSPlayerRanking[] Rankings { get; set; }
    public TmSChallengeInfo Challenges { get; set; }
    public bool WasWarmUp { get; set; }
    public bool MatchContinuesOnNextChallenge { get; set; }
    public bool ResetChallenge { get; set; }
}