        string args;
        //Handle della finestra di Media Player
        Variables.MediaPlayerHandle = 0;
        Variables.MediaPlayerHandle = (int)MediaPlayer.Handle;
        ProcessStartInfo psi = new ProcessStartInfo();
        //psi.FileName = FindMediaPlayerPath("mplayer.exe");
        psi.FileName = System.AppDomain.CurrentDomain.BaseDirectory + @"\Resources\FFmpeg\mplayer.exe";
        psi.UseShellExecute = true;
        //psi.CreateNoWindow = true;
        psi.Verb = "runas";
        psi.WindowStyle = ProcessWindowStyle.Hidden;
        //psi.WorkingDirectory = System.AppDomain.CurrentDomain.BaseDirectory + @"\Resources\FFmpeg\";
        psi.WorkingDirectory = @"x:\mplayer\";
        psi.Verb = "runas";
        args = "-wid ";
        args += Variables.MediaPlayerHandle;
        args += " -ao pcm:fast:file=";
        args += "aaa.wav";
        args += " aaa.avi";
        psi.Arguments = args;
        Process.Start(psi);
