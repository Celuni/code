                using (Process LMUTIL = new Process())
                {
                    string arg1 ="argument"
                    LMUTIL.StartInfo.FileName = "program.exe";
                    LMUTIL.StartInfo.Arguments = arg1
                    LMUTIL.StartInfo.UseShellExecute = false;
                    LMUTIL.StartInfo.RedirectStandardOutput = true;
                    LMUTIL.StartInfo.CreateNoWindow = true;
                    LMUTIL.EnableRaisingEvents = true;
                    LMUTIL.OutputDataReceived += p_WriteData;
                    LMUTIL.Start();
                    LMUTIL.BeginOutputReadLine();
                }
