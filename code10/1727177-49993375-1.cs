    catch (WebException e)
    {
    	if (e.Status == WebExceptionStatus.ProtocolError
              && (HttpWebResponse)e.Response).StatusCode == HttpStatusCode.Forbidden)
    	{
    		Logger.Error(e.ToString());
    		Console.ReadKey(true);
    		return;
    	}
    
    	throw;
    }
