using System;

namespace GbxRemoteNet.Structs;

public class TmPlayerRanking
{
    public string Login { get; set; }
    public string NickName { get; set; }
    public int PlayerId { get; set; }
    public int Rank { get; set; }

    public int BestTime { get; set; }

    public int[] BestCheckpoints { get; set; }

    public int Score { get; set; }

    public int NbrLapsFinished { get; set; }

    public double LadderScore { get; set; }
}