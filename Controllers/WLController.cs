using Microsoft.AspNetCore.Mvc;
using GameApi.Model;
using GameApi.Client;
namespace GameApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WLController : ControllerBase
    {
        [HttpGet(Name = "WLController")]
        public Wl? WL(string playerID, string ApiKey)
        {
            GameClient client = new GameClient();
            return client.GetPlayerWLAsync(playerID, ApiKey).Result;
        }
    }
}
