     private  void SetTimer()
            {
                dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
                dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
              
                dispatcherTimer.Interval = new TimeSpan(0, 0, 60);
                dispatcherTimer.Start();
               
            }
