        private void RunBackGroundWorkerProcesses1()
        {
            BackgroundWorker worker = new BackgroundWorker();            
            worker.DoWork += new DoWorkEventHandler(worker_DoWork1);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            System.Timers.Timer t = new System.Timers.Timer(10000); //  10 second intervals
            t.Elapsed += (sender, e) =>
            {
                // Don't try to start the work if it's still busy with the previous run...
                if (!worker.IsBusy)
                    worker.RunWorkerAsync();
            };
            t.Start(); // Start the timer
        }
