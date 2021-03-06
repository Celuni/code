    class Listener
    {
        public static Listener listener = null;  //singleton instance
        //member variables
        private HttpListener httpListener = null;
        private int port = -1;
        static Listener GetListener()
        {
            if (listener != null)
            {
                return listener;
            }
            try
            {
                listener = new Listener();
                listener.StartListening();
            }
            catch (Exception)
            {
                //cant listen on randomly chosen port
                listener.Cleanup();
                listener = null;
            }
            return listener;
        }
        private Listener()
        {
            port = RandomlyGenerate();
            httpListener = new HttpListener();
        }
        private void StartListening()
        {
            //start listening
        }
        private void Cleanup()
        {
            httpListener.Close();
            httpListener = null;
            port = -1;
        }
    }
