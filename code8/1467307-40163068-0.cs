    using (HttpClient httpClient = new HttpClient())
    {
        // ...
        HttpResponseMessage responseMessage = await httpClient.PostAsJsonAsync(access.EndpointDirectory, stringContent).ConfigureAwait(false);
        // ...
        string responseBody = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
        // ...
    }
