    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    using NetworkCommsDotNet;
    
    namespace Client
    {
        class Program
        {
            static void Main(string[] args)
            {
                byte[] bytesToSend = File.ReadAllBytes("filename.xml");
                TCPConnection.GetConnection(new ConnectionInfo("127.0.0.1", 10000)).SendObject("XMLData", bytesToSend);
    
                Console.WriteLine("Press any key to exit client.");
                Console.ReadKey(true);
                NetworkComms.Shutdown();
            }
        }
    }
