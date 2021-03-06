StringBuilder convertedId = new StringBuilder();
            var idToByte = Encoding.ASCII.GetBytes(id);
            using (SHA1 sha1 = SHA1.Create())
            {
                var bytes = sha1.ComputeHash(idToByte);
                for (int i = 0; i < bytes.Length; i++)
                {
                    if (i == 0 && bytes[i] < 16)
                        convertedId.Append(bytes[i].ToString("x1"));
                    else
                        convertedId.Append(bytes[i].ToString("x2"));
                }
            }
            return convertedId.ToString();
Edit: Considering Peter O's answer below, the following is a better answer:
         var idToByte = Encoding.ASCII.GetBytes(id);
         using (var sha1 = SHA1.Create())
         {
            var bytes = sha1.ComputeHash(idToByte);
            return new BigInteger(bytes.Reverse().ToArray()).ToString("X");
         }
Not that:<p>
1) You'll need to add a reference to System.Numerics<p>
2) BigInteger's constructor expects data in Little Endian order, hence the Reverse statement.
