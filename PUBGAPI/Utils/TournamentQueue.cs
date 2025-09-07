using System.Collections.Concurrent;

namespace PUBGAPI.Utils;
public static class TournamentQueue
{
    public static ConcurrentQueue<QueuePlayer> Queue = new();

}

