        // Alternatively use a task.....
            Task tcs = Task.Factory.StartNew(() =>
            {
                try
                {
                    // No awaits...  please note that anything bound in the gui must be changed on the dispatcher
                    DriveInfo[] allDrives = DriveInfo.GetDrives();
                    bool cdRomExists = allDrives.Any(x => x.DriveType == DriveType.CDRom);
                    IEnumerable<DriveInfo> cdroms = allDrives.Where(x => x.DriveType == DriveType.CDRom && allDrives.Any(y => y.IsReady));
                }
                catch (Exception ex)
                {
                    // handle your errors here. Note that you must check the innerexception for the real fault
                }
            }).ContinueWith((e) => { 
                if(e.Exception!=null)
                {
                    // hande error.. / 
                }
                else
                {
                    // complete.. do whatever here
                }
            });
