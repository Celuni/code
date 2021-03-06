    // Get number that corresponds to the month that is n months after the current one
    static int GetMonth(int offset)
    {
        int s = DateTime.Now.Month + offset;
        return s > 12 ? s - 12 : s;
    }
    // Get the year containing the month that is n months after the current one
    static int GetYear(int offset)
    {
        int month = GetMonth(offset);
        return month >= DateTime.Now.Month ? DateTime.Now.Year + 1 : DateTime.Now.Year;
    }
    // Get the number of days in the month that is n months after the current one
    static int GetMonthDays(int offset)
    {
        return DateTime.DaysInMonth(GetYear(offset), GetMonth(offset));
    }
    // Get a DateTime which represents the next time a day of number $day comes up in the calendar
    static DateTime GetNextDate(int day)
    {
        // Make sure provided day is valid
        if (day > 0 && day <= 31)
        {
            // Important stuff here
            // Change > operator to >= if you want current day to be included in result (i.e. day has value of 17 and today is the 17th so today's date is returned)
            int offset = day > DateTime.Now.Day ? 0 : 1;
            // Shouldn't repeat more than 3 times max
            while (true)
            {
                if (GetMonthDays(offset) >= day)
                {
                    break;
                }
                offset++;
            }
            return new DateTime(GetYear(offset), GetMonth(offset), day);
        }
        // Day provided wasn't a valid one
        throw new ArgumentOutOfRangeException();
    }
