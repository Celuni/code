    var key1 = Convert.FromBase64String("BOAiqZO6ucAzDlZKKhF1aLjNpU8+R2Pfsz4bQzNpV145D+agNxvLqyu5Q2tLalK2w31RpoDHE8Sipo0m2jiX4WA=").ToList();
    var keyType = new byte[] { 0x45, 0x43, 0x4B, 0x31 };
    var keyLength = new byte[] { 0x20, 0x00, 0x00, 0x00 };
    key1.RemoveAt(0);
    key1 = keyType.Concat(keyLength).Concat(key1).ToList();
    ECDiffieHellmanCng a = new ECDiffieHellmanCng();
    a.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Tls;
    byte[] label = new byte[32];
    string labelStr = "The purpose";
    Encoding.ASCII.GetBytes(labelStr, 0, labelStr.Length, label, 0);
    a.Label = label;
    byte[] seed = new byte[32];
    RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
    rng.GetBytes(seed);
    a.Seed = seed;
    a.HashAlgorithm = CngAlgorithm.ECDiffieHellmanP256;
    a.KeySize = 256;
    CngKey k = CngKey.Import(key1.ToArray(), CngKeyBlobFormat.EccPublicBlob);
    byte[] derivedMaterial = a.DeriveKeyMaterial(k);
