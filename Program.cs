using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;

namespace ApiClient
{
    class Joke
    {
        public int id { get; set; }
        public string type { get; set; }
        public string setup { get; set; }
        public string punchline { get; set; }
    }
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var client = new HttpClient();

            var responseAsStream = await client.GetStreamAsync("https://official-joke-api.appspot.com/random_joke");

            var joke = await JsonSerializer.DeserializeAsync<Joke>(responseAsStream);

            Console.WriteLine($"{joke.setup} - {joke.punchline}");

        }
    }
}
