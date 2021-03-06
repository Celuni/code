    // Returns JSON string
    string GET(string url) 
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        try {
            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream()) {
                StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
                return reader.ReadToEnd();
            }
        }
        catch (WebException ex) {
            WebResponse errorResponse = ex.Response;
            using (Stream responseStream = errorResponse.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("utf-8"));
                String errorText = reader.ReadToEnd();
                // log errorText
            }
            throw;
        }
    }
