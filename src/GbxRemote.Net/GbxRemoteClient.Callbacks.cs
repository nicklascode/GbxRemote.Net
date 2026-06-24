using System;
using System.Threading.Tasks;
using GbxRemoteNet.Events;
using GbxRemoteNet.Interfaces;
using GbxRemoteNet.Structs;
using GbxRemoteNet.XmlRpc;
using GbxRemoteNet.XmlRpc.ExtraTypes;
using GbxRemoteNet.XmlRpc.Packets;
using GbxRemoteNet.XmlRpc.Types;

namespace GbxRemoteNet;

public partial class GbxRemoteClient
{
    public event IGbxRemoteClient.AsyncEventHandler<CallbackGbxEventArgs<object>> OnAnyCallback;
    public event IGbxRemoteClient.AsyncEventHandler<PlayerConnectGbxEventArgs> OnPlayerConnect;
    public event IGbxRemoteClient.AsyncEventHandler<PlayerDisconnectGbxEventArgs> OnPlayerDisconnect;
    public event IGbxRemoteClient.AsyncEventHandler<PlayerChatGbxEventArgs> OnPlayerChat;
    public event IGbxRemoteClient.AsyncEventHandler<EchoGbxEventArgs> OnEcho;
    public event IGbxRemoteClient.AsyncEventHandler OnBeginRound;
    public event IGbxRemoteClient.AsyncEventHandler OnEndRound;
    public event IGbxRemoteClient.AsyncEventHandler<ChallengeBeginGbxEventArgs> OnBeginChallenge;
    public event IGbxRemoteClient.AsyncEventHandler<ChallengeEndGbxEventArgs> OnEndChallenge;
    public event IGbxRemoteClient.AsyncEventHandler<StatusChangedGbxEventArgs> OnStatusChanged;
    public event IGbxRemoteClient.AsyncEventHandler<PlayerInfoChangedGbxEventArgs> OnPlayerInfoChanged;
    public event IGbxRemoteClient.AsyncEventHandler<ManiaLinkPageActionGbxEventArgs> OnPlayerManialinkPageAnswer;
    public event IGbxRemoteClient.AsyncEventHandler<MapListModifiedGbxEventArgs> OnMapListModified;
    public event IGbxRemoteClient.AsyncEventHandler OnServerStart;
    public event IGbxRemoteClient.AsyncEventHandler OnServerStop;
    public event IGbxRemoteClient.AsyncEventHandler<TunnelDataGbxEventArgs> OnTunnelDataReceived;
    public event IGbxRemoteClient.AsyncEventHandler<VoteUpdatedGbxEventArgs> OnVoteUpdated;
    public event IGbxRemoteClient.AsyncEventHandler<BillUpdatedGbxEventArgs> OnBillUpdated;
    public event IGbxRemoteClient.AsyncEventHandler<PlayerGbxEventArgs> OnPlayerAlliesChanged;
    public event IGbxRemoteClient.AsyncEventHandler<ScriptCloudGbxEventArgs> OnScriptCloudLoadData;
    public event IGbxRemoteClient.AsyncEventHandler<ScriptCloudGbxEventArgs> OnScriptCloudSaveData;

    public async Task EnableCallbackTypeAsync()
    {
        await EnableCallbacksAsync(true);
    }

    private async Task InternalInvokeEventsAsync(Delegate[]? invocationList, EventArgs e)
    {
        if (invocationList == null)
        {
            return;
        }
        
        foreach (var del in invocationList)
        {
            await ((Task)del.DynamicInvoke(this, e))!;
        }
    }
    
    /// <summary>
    ///     Main callback handler.
    /// </summary>
    /// <param name="call"></param>
    /// <returns></returns>
    private async Task GbxRemoteClient_OnCallback(MethodCall call)
    {
        switch (call.Method)
        {
            case "TrackMania.PlayerConnect":
                await InternalInvokeEventsAsync(OnPlayerConnect?.GetInvocationList(), new PlayerConnectGbxEventArgs
                {
                    Login = (string) XmlRpcTypes.ToNativeValue<string>(call.Arguments[0]),
                    IsSpectator = (bool) XmlRpcTypes.ToNativeValue<bool>(call.Arguments[1])
                });
                break;
            case "TrackMania.PlayerDisconnect":
                await InternalInvokeEventsAsync(OnPlayerDisconnect?.GetInvocationList(), new PlayerDisconnectGbxEventArgs
                {
                    Login = (string) XmlRpcTypes.ToNativeValue<string>(call.Arguments[0]),
                    Reason = (string) XmlRpcTypes.ToNativeValue<string>(call.Arguments[1])
                });
                break;
            case "TrackMania.PlayerChat":
                await InternalInvokeEventsAsync(OnPlayerChat?.GetInvocationList(), new PlayerChatGbxEventArgs
                {
                    PlayerId = (int) XmlRpcTypes.ToNativeValue<int>(call.Arguments[0]),
                    Login = (string) XmlRpcTypes.ToNativeValue<string>(call.Arguments[1]),
                    Text = (string) XmlRpcTypes.ToNativeValue<string>(call.Arguments[2]),
                    IsRegisteredCmd = (bool) XmlRpcTypes.ToNativeValue<bool>(call.Arguments[3]),
                });
                break;
            case "TrackMania.Echo":
                await InternalInvokeEventsAsync(OnEcho?.GetInvocationList(), new EchoGbxEventArgs
                {
                    InternalParam = (string) XmlRpcTypes.ToNativeValue<string>(call.Arguments[0]),
                    PublicParam = (string) XmlRpcTypes.ToNativeValue<string>(call.Arguments[1])
                });
                break;
            case "TrackMania.BeginRound":
                await InternalInvokeEventsAsync(OnBeginRound?.GetInvocationList(), new EventArgs());
                break;
            case "TrackMania.EndRound":
                await InternalInvokeEventsAsync(OnEndRound?.GetInvocationList(), new EventArgs());
                break;
            case "TrackMania.BeginChallenge":
                await InternalInvokeEventsAsync(OnBeginChallenge?.GetInvocationList(), new ChallengeBeginGbxEventArgs
                {
                    Challenge = (TmSChallengeInfo) XmlRpcTypes.ToNativeValue<TmSChallengeInfo>(call.Arguments[0]),
                    WarmpUp= (bool) XmlRpcTypes.ToNativeValue<bool>(call.Arguments[1]),
                    MatchContinuation = (bool) XmlRpcTypes.ToNativeValue<bool>(call.Arguments[2])

                });
                break;
            case "TrackMania.EndChallenge":
                await InternalInvokeEventsAsync(OnEndChallenge?.GetInvocationList(), new ChallengeEndGbxEventArgs
                {
                    Rankings = (TmSPlayerRanking[]) XmlRpcTypes.ToNativeValue<TmSPlayerRanking>(call.Arguments[0]),
                    Challenges = (TmSChallengeInfo) XmlRpcTypes.ToNativeValue<TmSChallengeInfo>(call.Arguments[1]),
                    WasWarmUp = (bool) XmlRpcTypes.ToNativeValue<bool>(call.Arguments[2]),
                    MatchContinuesOnNextChallenge = (bool) XmlRpcTypes.ToNativeValue<bool>(call.Arguments[3]),
                    ResetChallenge = (bool) XmlRpcTypes.ToNativeValue<bool>(call.Arguments[4])

                });
                break;
            case "TrackMania.StatusChanged":
                await InternalInvokeEventsAsync(OnStatusChanged?.GetInvocationList(), new StatusChangedGbxEventArgs
                {
                    StatusCode = (int) XmlRpcTypes.ToNativeValue<int>(call.Arguments[0]),
                    StatusName = (string) XmlRpcTypes.ToNativeValue<string>(call.Arguments[1])
                });
                break;
            case "TrackMania.PlayerInfoChanged":
                await InternalInvokeEventsAsync(OnPlayerInfoChanged?.GetInvocationList(), new PlayerInfoChangedGbxEventArgs
                {
                    PlayerInfo = (TmSPlayerInfo) XmlRpcTypes.ToNativeValue<TmSPlayerInfo>(call.Arguments[0])
                });
                break;
            case "TrackMania.PlayerManialinkPageAnswer":
                await InternalInvokeEventsAsync(OnPlayerManialinkPageAnswer?.GetInvocationList(), new ManiaLinkPageActionGbxEventArgs
                {
                    PlayerId = (int) XmlRpcTypes.ToNativeValue<int>(call.Arguments[0]),
                    Login = (string) XmlRpcTypes.ToNativeValue<string>(call.Arguments[1]),
                    Answer = (string) XmlRpcTypes.ToNativeValue<string>(call.Arguments[2]),
                    Entries = (TmSEntryVal[]) XmlRpcTypes.ToNativeValue<TmSEntryVal>(call.Arguments[3])
                });
                break;
            case "TrackMania.MapListModified":
                await InternalInvokeEventsAsync(OnMapListModified?.GetInvocationList(), new MapListModifiedGbxEventArgs
                {
                    CurrentMapIndex = (int) XmlRpcTypes.ToNativeValue<int>(call.Arguments[0]),
                    NextMapIndex = (int) XmlRpcTypes.ToNativeValue<int>(call.Arguments[1]),
                    IsListModified = (bool) XmlRpcTypes.ToNativeValue<bool>(call.Arguments[2])
                });
                break;
            case "TrackMania.ServerStart":
                await InternalInvokeEventsAsync(OnServerStart?.GetInvocationList(), new EventArgs());
                break;
            case "TrackMania.ServerStop":
                await InternalInvokeEventsAsync(OnServerStop?.GetInvocationList(), new EventArgs());
                break;
            case "TrackMania.TunnelDataReceived":
                await InternalInvokeEventsAsync(OnTunnelDataReceived?.GetInvocationList(), new TunnelDataGbxEventArgs
                {
                    PlayerId = (int) XmlRpcTypes.ToNativeValue<int>(call.Arguments[0]),
                    Login = (string) XmlRpcTypes.ToNativeValue<string>(call.Arguments[1]),
                    Data = (GbxBase64) XmlRpcTypes.ToNativeValue<GbxBase64>(call.Arguments[2])
                });
                break;
            case "TrackMania.VoteUpdated":
                await InternalInvokeEventsAsync(OnVoteUpdated?.GetInvocationList(), new VoteUpdatedGbxEventArgs
                {
                    StateName = (string) XmlRpcTypes.ToNativeValue<string>(call.Arguments[0]),
                    Login = (string) XmlRpcTypes.ToNativeValue<string>(call.Arguments[1]),
                    CmdName = (string) XmlRpcTypes.ToNativeValue<string>(call.Arguments[2]),
                    CmdParam = (string) XmlRpcTypes.ToNativeValue<string>(call.Arguments[3])
                });
                break;
            case "TrackMania.BillUpdated":
                await InternalInvokeEventsAsync(OnBillUpdated?.GetInvocationList(), new BillUpdatedGbxEventArgs
                {
                    BillId = (int) XmlRpcTypes.ToNativeValue<int>(call.Arguments[0]),
                    State = (int) XmlRpcTypes.ToNativeValue<int>(call.Arguments[1]),
                    StateName = (string) XmlRpcTypes.ToNativeValue<string>(call.Arguments[2]),
                    TransactionId = (int) XmlRpcTypes.ToNativeValue<int>(call.Arguments[3])
                });
                break;
            case "TrackMania.PlayerAlliesChanged":
                await InternalInvokeEventsAsync(OnPlayerAlliesChanged?.GetInvocationList(), new PlayerGbxEventArgs
                {
                    Login = (string) XmlRpcTypes.ToNativeValue<string>(call.Arguments[0])
                });
                break;
            case "ScriptCloud.LoadData":
                await InternalInvokeEventsAsync(OnScriptCloudLoadData?.GetInvocationList(), new ScriptCloudGbxEventArgs
                {
                    Type = (string) XmlRpcTypes.ToNativeValue<string>(call.Arguments[0]),
                    Id = (string) XmlRpcTypes.ToNativeValue<string>(call.Arguments[1])
                });
                break;
            case "ScriptCloud.SaveData":
                await InternalInvokeEventsAsync(OnScriptCloudSaveData?.GetInvocationList(), new ScriptCloudGbxEventArgs
                {
                    Type = (string) XmlRpcTypes.ToNativeValue<string>(call.Arguments[0]),
                    Id = (string) XmlRpcTypes.ToNativeValue<string>(call.Arguments[1])
                });
                break;
        }

        OnAnyCallback?.Invoke(this, new CallbackGbxEventArgs<object>
        {
            Call = call,
            Parameters = (object[]) XmlRpcTypes.ToNativeValue<object>(new XmlRpcArray(call.Arguments))
        });
    }
}