    string value = "9quali52ty3";
    // Convert the string into a byte[].
    byte[] asciiBytes = Encoding.ASCII.GetBytes(value);
    int total = 0;
    Array.ForEach(asciiBytes, delegate (byte i) { total += i; });
