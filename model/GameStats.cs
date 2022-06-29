using System.Collections.Concurrent;
using System.Collections.Generic;
namespace GameApi.Model

{
    public class GameStats
    {        
            
            public int Radiant_Score { get; set; }        
            public string GameScore
            {
                get { return $"{Radiant_Score}-{Dire_Score}"; }               
            }
            public int Dire_Score { get; set; }
            public int duration { get; set; }
            public bool Radiant_Win { get; set; }
            public string? region { get; set; }
            public string? Replay_Url { get; set; }
        public players[]? players { get; set; }
        public MatchID? matchID { get; set; }


    }
    public class PlayersStats
    {
        public int rank_tier { get; set; }
        public profile? profile { get; set; }
        public Wl? wl { get; set; }

    }
    public class rank_tier
    {
        public int rank { get; set; }
    }
    public class profile
    {
        public string? personaname { get; set; }
        public bool plus { get; set; }
    }
    public class Wl
    {
        public int win { get; set; }
        public int lose { get; set; }
    }
    public class players
    {
        public int kills { get; set; }
        public int deaths { get; set; }
        public int assists { get; set; }
        public string? personaname { get; set; }
        public bool isRadiant { get; set; }
    }        
    public class refresh
    {        
    }
    public class MatchID
    {
        public string? matchID { get; set; }
    }
    
}
