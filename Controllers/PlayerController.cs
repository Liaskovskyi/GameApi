using Microsoft.AspNetCore.Mvc;
using GameApi.Model;
using GameApi.Client;

namespace GameApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        [HttpGet(Name = "PlayerController")]
        public PlayersStats? Player(string playerID, string ApiKey)
        {
            GameClient client = new GameClient();
            return client.GetPlayerStatsAsync(playerID, ApiKey).Result;
        }
    }
}
