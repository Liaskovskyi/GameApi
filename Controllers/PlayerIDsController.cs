using Microsoft.AspNetCore.Mvc;
using GameApi.Client;

namespace GameApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PlayerIDsController : ControllerBase
    {
        [HttpPost(Name = "PostPlayerID")]
        public void PostPlayerID(string userID, string playerID)
        {
            GameClient client = new GameClient();
            client.PostPlayerIDAsync(userID, playerID);
            return;
        }

        [HttpPut(Name = "PutPlayerID")]
        public void PutPlayerID(string userID, string playerID)
        {

            GameClient client = new GameClient();
            client.PutPlayerAsync(userID, playerID);
            return;
        }

        [HttpDelete(Name = "DeletePlayerID")]
        public void DeletePlayerID(string userID)
        {
            GameClient client = new GameClient();
            client.DeletePlayerAsync(userID);
            return;
        }
    }
}
