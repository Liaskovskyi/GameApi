using Microsoft.AspNetCore.Mvc;
using GameApi.Model;
using GameApi.Client;

namespace GameApi.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class matchIDController : ControllerBase
    {                       
        [HttpPost(Name = "PostMatchID")]
        public void PostMatchID(string userID, string matchID)
        {

            GameClient client = new GameClient();
            client.PostMatchAsync(userID, matchID);
            return;
        }

        [HttpPut(Name = "PutMatchID")]
        public void MatchID(string userID, string matchID)
        {

            GameClient client = new GameClient();
            client.PutMatchAsync(userID, matchID);
            return;
        }

        [HttpDelete(Name = "DeleteMatchID")]
        public void DeleteMatchID(string userID)
        {

            GameClient client = new GameClient();
            client.DeleteMatchAsync(userID);
            return;
        }


    }
    
}
