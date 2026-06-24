using System;
using GbxRemoteNet.Structs;

namespace GbxRemoteNet.Events;

public class EndRoundGbxEventArgs : EventArgs
{
    /// <summary>
    /// Array containing the ranking results of the round.
    /// </summary>
    public TmSPlayerRanking[] Rankings { get; set; }
    /// <summary>
    /// The ID of the team that won the round if the Teams game-mode is played.
    /// </summary>
    public int WinnerTeam { get; set; }
}