c#
    String pname = "Fredysploit_v2";
    String dlink = "https://pastebin.com/raw/dnfHuGAK"; 
    //^ changed the download link to the raw paste so you can extract your link
    string title = @"Title ";
    Console.Title = pname + " Bootstrapper";
    
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine(title);
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Downloading new Files...");
    WebClient wc = new WebClient();
    string key = wc.DownloadString(dlink);
    string path = @"Update\" + pname + ".exe";
    System.Net.WebClient Dow = new WebClient();
    string patch = (@"Update");
    Directory.CreateDirectory(patch);
    Dow.DownloadFile(key, path);
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(pname + " Downloaded | Updated!");
    Console.WriteLine($"Now open { patch } and Run { pname }.exe");
    //^ since you are using String.Format(), make use of it :)
    Console.ReadKey();
