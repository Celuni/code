    public Baterry(string model, int hoursidle = 0, int hourstalk = 0, BatteryType batterytype = null)
    {
        this.Model = model;
        this.HoursIdle = hoursidle;
        this.HoursTalk = hourstalk;
        this.BatteryType = batterytype;
    }
