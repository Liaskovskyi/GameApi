using GameApi.Constant;
using GameApi.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace GameApi.Client
{
    public class GameClient
    {
        private HttpClient _client;
        private static string? _address;
        private static string? _apikey;
        Dictionary<string, string> _data;

        public GameClient()
        {
            _address = constant.address;            
            _apikey = constant.apikey;
            _client = new HttpClient();          
            _client.BaseAddress = new Uri(_address);            
            _data = new Dictionary<string, string>();
        }
        public async Task<GameStats?> GetGameStatsAsync(string matchID, string ApiKey)
        {
            var response = await _client.GetAsync($"/api/matches/{matchID}?api_key={ApiKey}");
            var content = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<GameStats>(content);
            return result;
        }
        public async Task<PlayersStats?> GetPlayerStatsAsync(string playerID, string ApiKey)
        {
            var response = await _client.GetAsync($"/api/players/{playerID}?api_key={ApiKey}");
            var content = response.Content.ReadAsStringAsync().Result;
            try
            {
                var result = JsonConvert.DeserializeObject<PlayersStats>(content);
                return result;
            }
            catch
            {
                return null;
            }               
        }
        public async Task<Wl?> GetPlayerWLAsync(string playerID, string ApiKey)
        {
            var response = await _client.GetAsync($"/api/players/{playerID}/wl?api_key={ApiKey}");
            var content = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<Wl>(content);
            return result;
        }
        public async void PostRefreshAsync(string playerID, string ApiKey)
        {
            HttpContent? refresh = null;
            var response = await _client.PostAsync($"/api/players/{playerID}/refresh", refresh);           
            return ;
        }             
        public async void PostMatchAsync(string userID, string matchID)
        {
            string path = @"D:\matchIDs\1.txt";
            _data.Add(userID, matchID);           
                    using (StreamWriter writer = new StreamWriter(path, true))
                    {
                        await writer.WriteAsync("");
                        await writer.WriteLineAsync($"{userID} {matchID}");
                    }
        }
        public async void PutMatchAsync(string userID, string matchID)
        {
            string path = @"D:\matchIDs\1.txt";
            using (StreamReader reader = new StreamReader(path))
            {
                string? content;
                content = await reader.ReadToEndAsync();
                reader.Close();
                using (StreamReader LineReader = new StreamReader(path))
                {
                    string? line;
                    while ((line = await LineReader.ReadLineAsync()) != null)
                    {
                        if (line.StartsWith($"{userID}"))
                        {
                            LineReader.Close();
                            string searchText = line;
                            content = Regex.Replace(content, searchText, $"{userID} {matchID}");
                            StreamWriter writer = new StreamWriter(path);
                            writer.Write(content);
                            writer.Close();
                            break;
                        }
                    }
                }
            }
        }        
        public async Task<string> GetMatchAsync(string userID)
        {
            string path = @"D:\matchIDs\1.txt";
            using (StreamReader reader = new StreamReader(path))
            {
                string? line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    if (line.StartsWith(userID)) return line.Split(' ').Last();

                }
            }
            return "ID матчу не знайдено";
        }
        public async void DeleteMatchAsync(string userID)
        {
            string path = @"D:\matchIDs\1.txt";
            using (StreamReader reader = new StreamReader(path))
            {
                string? content;
                content = await reader.ReadToEndAsync();
                reader.Close();
                using (StreamReader LineReader = new StreamReader(path))
                {                    
                    
                    string? line;
                    while ((line = await LineReader.ReadLineAsync()) != null)
                    {
                        if (line.StartsWith($"{userID}"))
                        {
                            LineReader.Close();
                                string searchText = line;
                            content = Regex.Replace(content, searchText, "");
                            StreamWriter writer = new StreamWriter(path);
                            writer.WriteLine(content);
                            writer.Close();
                            break;
                        }
                    }
                }
            }
        }
        public async void PostPlayerIDAsync(string userID, string playerID)
        {
            string path = @"D:\playerIDs\1.txt";            
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                await writer.WriteAsync("");
                await writer.WriteLineAsync($"{userID} {playerID}");
            }
        }
        public async void PutPlayerAsync(string userID, string playerID)
        {
            string path = @"D:\playerIDs\1.txt";
            using (StreamReader reader = new StreamReader(path))
            {
                string? content;
                content = await reader.ReadToEndAsync();
                reader.Close();
                using (StreamReader LineReader = new StreamReader(path))
                {
                    string? line;
                    while ((line = await LineReader.ReadLineAsync()) != null)
                    {
                        if (line.StartsWith($"{userID}"))
                        {
                            LineReader.Close();
                            string searchText = line;
                            content = Regex.Replace(content, searchText, $"{userID} {playerID}");
                            StreamWriter writer = new StreamWriter(path);
                            writer.Write(content);
                            writer.Close();
                            break;
                        }
                    }
                }
            }
        }
        public async void DeletePlayerAsync(string userID)
        {
            string path = @"D:\playerIDs\1.txt";
            using (StreamReader reader = new StreamReader(path))
            {
                string? content;
                content = await reader.ReadToEndAsync();
                reader.Close();
                using (StreamReader LineReader = new StreamReader(path))
                {

                    string? line;
                    while ((line = await LineReader.ReadLineAsync()) != null)
                    {
                        if (line.StartsWith($"{userID}"))
                        {
                            LineReader.Close();
                            string searchText = line;
                            content = Regex.Replace(content, searchText, "");
                            StreamWriter writer = new StreamWriter(path);
                            writer.WriteLine(content);
                            writer.Close();
                            break;
                        }
                    }
                }
            }
        }
    }
}
