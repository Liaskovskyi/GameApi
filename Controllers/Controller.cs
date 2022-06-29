using Microsoft.AspNetCore.Mvc;
using GameApi.Model;
using GameApi.Client;


namespace GameApi.GameController
{ 
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        [HttpGet(Name = "GameController")]
        public GameStats? Game (string matchID, string ApiKey)
        {
            GameClient client = new GameClient(); 
            return client.GetGameStatsAsync(matchID, ApiKey).Result;  
        }
        
    }
}
