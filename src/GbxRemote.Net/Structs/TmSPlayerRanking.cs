using System;

namespace GbxRemoteNet.Structs;

public class TmSPlayerRanking
{
    /// <summary>
    ///     TM2020
    /// </summary>
    public string Login { get; set; }

    /// <summary>
    ///     TM2020
    /// </summary>
    public string NickName { get; set; }

    /// <summary>
    ///     TM2020
    /// </summary>
    public string PlayerId { get; set; }

    /// <summary>
    ///     TM2020
    /// </summary>
    public int Rank { get; set; }

    /// <summary>
    ///     TM2
    /// </summary>
    public int BestTime { get; set; }

    /// <summary>
    ///     TM2
    /// </summary>
    public int[] BestCheckpoints { get; set; }

    /// <summary>
    ///     TM2
    /// </summary>
    public int Score { get; set; }

    /// <summary>
    ///     TM2
    /// </summary>
    public int NbrLapsFinished { get; set; }

    /// <summary>
    ///     TM2
    /// </summary>
    public double LadderScore { get; set; }
}