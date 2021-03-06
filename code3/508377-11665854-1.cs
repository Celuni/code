    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        var item = (DateTime)value;
        if (item != null)
        {
            return item.ToString(culture.DateTimeFormat.ShortDatePattern, culture);
        }
        return null;
    }
