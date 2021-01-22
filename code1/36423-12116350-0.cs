    public static class UsingServiceClient
    {
        public static void Do<TClient>(TClient client, Action<TClient> execute)
            where TClient : class, ICommunicationObject
        {
            try
            {
                execute(client);
            }
            finally
            {
                client.DisposeSafely();
            }
        }
    
        public static void DisposeSafely(this ICommunicationObject client)
        {
            if (client == null)
            {
                return;
            }
    
            bool success = false;
    
            try
            {
                if (client.State != CommunicationState.Faulted)
                {
                    client.Close();
                    success = true;
                }
            }
            finally
            {
                if (!success)
                {
                    client.Abort();
                }
            }
        }
    }
