    private const int KeySize = 256; // in bits
    static string EncryptStringToBase64String(string plainText, byte[] Key)
    {
        // Check arguments. 
        if (plainText == null || plainText.Length <= 0)
            throw new ArgumentNullException("plainText");
        if (Key == null || Key.Length <= 0)
            throw new ArgumentNullException("Key");
        byte[] returnValue;
        using (var aes = Aes.Create())
        {
            aes.KeySize = KeySize;
            aes.GenerateIV();
            var iv = aes.IV;
            var encryptor = aes.CreateEncryptor(Key, iv);
            // Create the streams used for encryption. 
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        //Write all data to the stream.
                        swEncrypt.Write(plainText);
                    }
                    // this is just our encrypted data
                    var encrypted = msEncrypt.ToArray();
                    returnValue = new byte[encrypted.Length + iv.Length];
                    // append our IV so our decrypt can get it
                    Array.Copy(iv, returnValue, iv.Length);
                    // append our encrypted data
                    Array.Copy(encrypted, 0, returnValue, iv.Length, encrypted.Length);
                }
            }
        }
        // return encrypted bytes converted to Base64String
        return Convert.ToBase64String(returnValue);
    }
    static string DecryptStringFromBase64String(string cipherText, byte[] Key)
    {
        // Check arguments. 
        if (cipherText == null || cipherText.Length <= 0)
            throw new ArgumentNullException("cipherText");
        if (Key == null || Key.Length <= 0)
            throw new ArgumentNullException("Key");
        string plaintext = null;
        // this is all of the bytes
        var allBytes = Convert.FromBase64String(cipherText);
        // get our IV that we pre-pended to the data
        byte[] iv = new byte[KeySize / 16];
        Array.Copy(allBytes, iv, iv.Length);
        // get the data we need to decrypt
        byte[] cipherBytes = new byte[allBytes.Length - iv.Length];
        Array.Copy(allBytes, iv.Length, cipherBytes, 0, cipherBytes.Length);
        using (var aes = Aes.Create())
        {
            // Create a decrytor to perform the stream transform.
            var decryptor = aes.CreateDecryptor(Key, iv);
            // Create the streams used for decryption. 
            using (MemoryStream msDecrypt = new MemoryStream(cipherBytes))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        // Read the decrypted bytes from the decrypting stream 
                        // and place them in a string.
                        plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }
        }
        return plaintext;
    }
