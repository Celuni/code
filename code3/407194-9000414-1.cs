    System.Diagnostics.ProcessStartInfo processInfo = new System.Diagnostics.ProcessStartInfo();
            processInfo.FileName = "explorer.exe";
            processInfo.Arguments = Server.MapPath("YourFolderName");
            Response.Write(processInfo.Arguments.ToString());
            System.Diagnostics.Process.Start(processInfo);
