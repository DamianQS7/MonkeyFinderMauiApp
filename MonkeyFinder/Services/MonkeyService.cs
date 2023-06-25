using System.Net.Http.Json;

namespace MonkeyFinder.Services
{
	public class MonkeyService
	{
        HttpClient HttpClient;

        List<Monkey> monkeyList = new();

        public MonkeyService()
        {
            HttpClient = new HttpClient();
        }

        public async Task<List<Monkey>> GetMonkeys()
        {
            if(monkeyList?.Count > 0)
                return monkeyList;

            string url = "https://www.montemagno.com/monkeys.json";

            HttpResponseMessage response = await HttpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                monkeyList = await response.Content.ReadFromJsonAsync<List<Monkey>>();
            }

            return monkeyList;
        }
    }
}
