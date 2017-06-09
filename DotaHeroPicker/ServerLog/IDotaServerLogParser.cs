namespace DotaHeroPicker.ServerLog
{
    interface IDotaServerLogParser
    {
        IDotaLobby TryParse(string rowServerLog);
    }
}
