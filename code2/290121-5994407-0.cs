    /// <summary>
    ///   Run an executable.
    /// </summary>
    /// <param name = "executablePath">Path to the executable.</param>
    /// <param name = "arguments">The arguments to pass along.</param>
    /// <param name = "workingDirectory">The directory to use as working directory when running the executable.</param>
    /// <returns>A RunResults object which contains the output of the executable, plus runtime information.</returns>
    public static RunResults RunExecutable( string executablePath, string arguments, string workingDirectory )
    {
        RunResults runResults = new RunResults();
    
        if ( File.Exists( executablePath ) )
        {
            using ( Process proc = new Process() )
            {
                proc.StartInfo.FileName = executablePath;
                proc.StartInfo.Arguments = arguments;
                proc.StartInfo.WorkingDirectory = workingDirectory;
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.RedirectStandardError = true;
                proc.OutputDataReceived +=
                    ( o, e ) => runResults.Output.Append( e.Data ).Append( Environment.NewLine );
                proc.ErrorDataReceived +=
                    ( o, e ) => runResults.ErrorOutput.Append( e.Data ).Append( Environment.NewLine );
    
                proc.Start();
                proc.BeginOutputReadLine();
                proc.BeginErrorReadLine();
    
                proc.WaitForExit();
                runResults.ExitCode = proc.ExitCode;
            }
        }
        else
        {
            throw new ArgumentException( "Invalid executable path.", "executablePath" );
        }
    
        return runResults;
    }
    public class RunResults
    {
        public int ExitCode;
        public StringBuilder Output = new StringBuilder();
        public StringBuilder ErrorOutput = new StringBuilder();
    }
