    try
        {
            // Open the configuration file and retrieve 
            // the connectionStrings section.
            Configuration config = ConfigurationManager.
                OpenExeConfiguration(exeConfigName);
    
            ConnectionStringsSection section =
                config.GetSection("connectionStrings")
                as ConnectionStringsSection;
    
            if (section.SectionInformation.IsProtected)
            {
                // Remove encryption.
                section.SectionInformation.UnprotectSection();
            }
            else
            {
                // Encrypt the section.
                section.SectionInformation.ProtectSection(
                    "DataProtectionConfigurationProvider");
            }
            // Save the current configuration.
            config.Save();
    
            Console.WriteLine("Protected={0}",
                section.SectionInformation.IsProtected);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
