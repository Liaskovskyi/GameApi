using Microsoft.AspNetCore.Mvc;
using GameApi.Model;
using GameApi.Client;

namespace GameApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class userIDController : ControllerBase
    {       
        [HttpGet(Name = "GetuserID")]

        public Task<string> MatchID(string userID)
        {

            GameClient client = new GameClient();
            return client.GetMatchAsync(userID);
        }

    }
}
