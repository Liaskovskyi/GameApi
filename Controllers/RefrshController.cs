using Microsoft.AspNetCore.Mvc;
using GameApi.Model;
using GameApi.Client;
namespace GameApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RefreshController : ControllerBase
    {
        [HttpPost(Name = "Refresh")]
        public void Refresh(string playerID, string ApiKey)
        {
            GameClient client = new GameClient();
            client.PostRefreshAsync(playerID, ApiKey);
            return;

        }        

    }
}
