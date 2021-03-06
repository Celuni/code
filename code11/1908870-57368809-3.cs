c#
class WinSocketServer:IDisposable
{
    // I guess this was in your code, necessary to show proper stopping
    private Socket listener = new Socket(......); 
    public ManualResetEvent allDone = new ManualResetEvent(false);
    private CancellationTokenSource cancelSource = new CancellationTokenSource();
    private void _StartListening(CancellationToken cancelToken)
    {
        try
        {
            listener.Listen(...); // I guess 
            allDone.Reset(); // reset once before starting the loop
            while (!cancelToken.IsCancellationRequested)
            {
                Console.WriteLine("Waiting for a connection...");
                listener.BeginAccept(new AsyncCallback(AcceptCallback),listener);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
        allDone.Set(); // notify that the listener is exiting
        Console.WriteLine("Complete");
    }
    public void StartListening()
    {
        Task.Run(() => _StartListening(cancelSource.Token));
    }
    public void StopListening()
    {
        // notify the listener it should exit
        cancelSource.Cancel(); 
        // cancel possibly pending BeginAccept
        listener.Close();
        // wait until the listener notifies that it's actually exiting
        allDone.WaitOne();
    }
    public void Dispose()
    {
        StopListening();
        cancelSource.Dispose();
        allDone.Dispose();
    }
}
### UPDATE
It worth noting that `listener.BeginAccept` won't return until there is a new client connection. When stopping the listener, it is necessary to close the socket (`listener.Close()`) to force `BeginAccept` to exit. 
The difference in Thread/Task behavior is really weird, it probably can originate from the Task thread being a background thread, while the regular thread being a foreground one. 
