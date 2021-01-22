    string date = "2009-02-25 16:13:00Z"; // Coordinated Universal Time string from DateTime.Now.ToUniversalTime().ToString("u");
    DateTime localDateTime = DateTime.Parse(date); // Local .NET timeZone.
    DateTime utcDateTime = localDateTime.ToUniversalTime();
    
    // ID from "HKEY_LOCAL_MACHINE\Software\Microsoft\Windows NT\CurrentVersion\Time Zone"
    // See http://msdn.microsoft.com/en-us/library/system.timezoneinfo.id.aspx
    string nzTimeZoneKey = "New Zealand Standard Time";
    TimeZoneInfo nzTimeZone = TimeZoneInfo.FindSystemTimeZoneById(nzTimeZoneKey);
    DateTime nzDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, nzTimeZone);
