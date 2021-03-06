    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(new Uri(url));
    webRequest.Method = WebRequestMethods.Http.Get;
    NetworkCredential nc = new NetworkCredential("theUsername", "thePassword");
    webRequest.Credentials = nc;
    webRequest.PreAuthenticate = true; 
    RequestState rs = new RequestState();
    rs.Request = webRequest;
    WebResponse response = await webRequest.GetResponseAsync();
