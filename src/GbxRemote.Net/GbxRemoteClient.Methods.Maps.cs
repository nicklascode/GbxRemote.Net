using System;
using System.Threading.Tasks;
using GbxRemoteNet.Structs;
using GbxRemoteNet.XmlRpc;

namespace GbxRemoteNet;

/// <summary>
/// Method Category: Challenges
/// </summary>
public partial class GbxRemoteClient
{
    public async Task<int> GetCurrentChallengeIndexAsync()
    {
        return (int) XmlRpcTypes.ToNativeValue<int>(
            await CallOrFaultAsync("GetCurrentChallengeIndex")
        );
    }

    public async Task<int> GetNextChallengeIndexAsync()
    {
        return (int) XmlRpcTypes.ToNativeValue<int>(
            await CallOrFaultAsync("GetNextChallengeIndex")
        );
    }

    public async Task<bool> SetNextChallengeIndexAsync(int ChallengeIndex)
    {
        return (bool) XmlRpcTypes.ToNativeValue<bool>(
            await CallOrFaultAsync("SetNextChallengeIndex")
        );
    }
    
    public async Task<bool> SetNextChallengeIdentAsync(string ChallengeId)
    {
        return (bool) XmlRpcTypes.ToNativeValue<bool>(
            await CallOrFaultAsync("SetNextChallengeIdent", ChallengeId)
        );
    }

    public async Task<bool> JumpToChallengeIndexAsync(int ChallengeIndex)
    {
        return (bool) XmlRpcTypes.ToNativeValue<bool>(
            await CallOrFaultAsync("JumpToChallengeIndex")
        );
    }

    public async Task<bool> JumpToChallengeIdentAsync(string ChallengeId)
    {
        return (bool) XmlRpcTypes.ToNativeValue<bool>(
            await CallOrFaultAsync("JumpToChallengeIdent", ChallengeId)
        );
    }

    public async Task<TmChallengeInfo> GetCurrentChallengeInfoAsync()
    {
        return (TmChallengeInfo) XmlRpcTypes.ToNativeValue<TmChallengeInfo>(
            await CallOrFaultAsync("GetCurrentChallengeInfo")
        );
    }

    public async Task<TmChallengeInfo> GetNextChallengeInfoAsync()
    {
        return (TmChallengeInfo) XmlRpcTypes.ToNativeValue<TmChallengeInfo>(
            await CallOrFaultAsync("GetNextChallengeInfo")
        );
    }

    public async Task<TmChallengeInfo> GetChallengeInfoAsync(string filename)
    {
        return (TmChallengeInfo) XmlRpcTypes.ToNativeValue<TmChallengeInfo>(
            await CallOrFaultAsync("GetChallengeInfo", filename)
        );
    }

    public async Task<bool> CheckChallengeForCurrentServerParamsAsync(string filename)
    {
        return (bool) XmlRpcTypes.ToNativeValue<bool>(
            await CallOrFaultAsync("CheckChallengeForCurrentServerParams", filename)
        );
    }

    public async Task<TmChallengeInfo[]> GetChallengeListAsync(int maxInfos, int startIndex)
    {
        return (TmChallengeInfo[]) XmlRpcTypes.ToNativeValue<TmChallengeInfo>(
            await CallOrFaultAsync("GetChallengeList", maxInfos, startIndex)
        );
    }

    public async Task<bool> AddChallengeAsync(string filename)
    {
        return (bool) XmlRpcTypes.ToNativeValue<bool>(
            await CallOrFaultAsync("AddChallenge", filename)
        );
    }

    public async Task<int> AddChallengeListAsync(Array filenames)
    {
        return (int) XmlRpcTypes.ToNativeValue<int>(
            await CallOrFaultAsync("AddChallengeList", filenames)
        );
    }

    public async Task<bool> RemoveChallengeAsync(string filename)
    {
        return (bool) XmlRpcTypes.ToNativeValue<bool>(
            await CallOrFaultAsync("RemoveChallenge", filename)
        );
    }

    public async Task<int> RemoveChallengeListAsync(Array filenames)
    {
        return (int) XmlRpcTypes.ToNativeValue<int>(
            await CallOrFaultAsync("RemoveChallengeList", filenames)
        );
    }

    public async Task<bool> InsertChallengeAsync(string filename)
    {
        return (bool) XmlRpcTypes.ToNativeValue<bool>(
            await CallOrFaultAsync("InsertChallenge", filename)
        );
    }

    public async Task<int> InsertChallengeListAsync(Array filenames)
    {
        return (int) XmlRpcTypes.ToNativeValue<int>(
            await CallOrFaultAsync("InsertChallengeList", filenames)
        );
    }

    public async Task<bool> ChooseNextChallengeAsync(string filename)
    {
        return (bool) XmlRpcTypes.ToNativeValue<bool>(
            await CallOrFaultAsync("ChooseNextChallenge", filename)
        );
    }

    public async Task<int> ChooseNextChallengeListAsync(Array filenames)
    {
        return (int) XmlRpcTypes.ToNativeValue<int>(
            await CallOrFaultAsync("ChooseNextChallengeList", filenames)
        );
    }
}