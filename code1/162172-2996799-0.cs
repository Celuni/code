    public static int ExecuteCommand(string Command, int Timeout)
    {
       int ExitCode;
       ProcessStartInfo ProcessInfo;
       Process Process;
    
       ProcessInfo = new ProcessStartInfo("cmd.exe", "/C " + Command);
       ProcessInfo.CreateNoWindow = true; 
       ProcessInfo.UseShellExecute = false;
       Process = Process.Start(ProcessInfo);
       Process.WaitForExit(Timeout);
       ExitCode = Process.ExitCode;
       Process.Close();
    
       return ExitCode;
    }
