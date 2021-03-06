    char cc = '…';
    Console.WriteLine(cc);
    // 2026  <-- note, hex value differs from byte representation shown below
    Console.WriteLine(((int)cc).ToString("x"));
    // 26200000
    Console.WriteLine(BytesToHex(BitConverter.GetBytes((int)cc)));
    // 2620
    Console.WriteLine(BytesToHex(Encoding.GetEncoding("utf-16").GetBytes(new[] { cc })));
