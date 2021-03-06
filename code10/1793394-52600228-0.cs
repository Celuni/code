    private void button1_Click(object sender, EventArgs e)
    {
        WqlEventQuery query = new WqlEventQuery() {
            EventClassName = "__InstanceOperationEvent",
            WithinInterval = new TimeSpan(0, 0, 3),
            Condition = @"TargetInstance ISA 'Win32_DiskDrive'"
        };
        using (ManagementEventWatcher MOWatcher = new ManagementEventWatcher(query))
        {
            MOWatcher.EventArrived += new EventArrivedEventHandler(DeviceInsertedEvent);
            MOWatcher.Start();
        }
    }
    private void DeviceInsertedEvent(object sender, EventArrivedEventArgs e)
    {
        using (ManagementBaseObject MOBbase = (ManagementBaseObject)e.NewEvent.Properties["TargetInstance"].Value)
        {
            bool DriveArrival = false;
            string EventMessage = string.Empty;
            string oInterfaceType = MOBbase.Properties["InterfaceType"]?.Value.ToString();
                
            if (e.NewEvent.ClassPath.ClassName.Equals("__InstanceDeletionEvent"))
            {
                DriveArrival = false;
                EventMessage = oInterfaceType + " Drive removed";
            }
            else
            {
                DriveArrival = true;
                EventMessage = oInterfaceType + " Drive inserted";
            }
            EventMessage += ": " + MOBbase.Properties["Caption"]?.Value.ToString();
            this.BeginInvoke((MethodInvoker)delegate { this.UpdateUI(DriveArrival, EventMessage); });
        }
    }
    private void UpdateUI(bool IsDriveInserted, string message)
    {
        if (IsDriveInserted)
            this.lblDeviceArrived.Text = message;
        else
            this.lblDeviceRemoved.Text = message;
    }
