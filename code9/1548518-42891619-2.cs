    public static void Main()
    {
      Action<string> messageTarget; 
      if (Environment.GetCommandLineArgs().Length > 1)
         messageTarget = ShowWindowsMessage;
      else
         messageTarget = Console.WriteLine;
      messageTarget("Hello, World!");   
    }      
    private static void ShowWindowsMessage(string message)
    {
       MessageBox.Show(message);      
    }
