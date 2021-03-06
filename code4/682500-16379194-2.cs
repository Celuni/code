    private static bool IsNumeric<T>(T input)
    {
        double d;
        return double.TryParse(input.ToString(), NumberStyles.Any,CultureInfo.InvariantCulture, out d);
    }
---
    bool b1 = IsNumeric(1); //<-- true
    bool b2 = IsNumeric(1.0); //<-- true
    bool b3 = IsNumeric("a"); //<-- false
    bool b4 = IsNumeric("3E+10"); //<-- true
    bool b5 = IsNumeric("1,234,567.0"); //<-- true
