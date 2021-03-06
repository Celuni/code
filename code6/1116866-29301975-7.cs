    static async Task Login()
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("https://www.censored.de/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = TimeSpan.FromSeconds(30);
    
            Login l = new Login() { id = "12345", password = "abcde", username = "safsdfasdf" };
            var sTemp = JsonConvert.SerializeObject(l); // DEBUG: Just so I can see the JSON
    
            var response = await client.PostAsJsonAsync("/censored/Service.svc/Login", l);
            Guid g;
            if (response.IsSuccessStatusCode)
            {
                g = await response.Content.ReadAsAsync<Guid>(); // This gives you the GUID
            }
    
            //DEBUG:
            // var rawResponse = await response.Content.ReadAsStringAsync();
            // Console.WriteLine(response);
        }
    }
