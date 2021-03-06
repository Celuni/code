            EmailMessage DifferentReplyTo = new EmailMessage(service);
            DifferentReplyTo.Subject = "test";
            DifferentReplyTo.ToRecipients.Add("destination@domain.com");
            DifferentReplyTo.Body = new MessageBody("test");           
            ExtendedPropertyDefinition PidTagReplyRecipientEntries = new ExtendedPropertyDefinition(0x004F, MapiPropertyType.Binary);
            ExtendedPropertyDefinition PidTagReplyRecipientNames = new ExtendedPropertyDefinition(0x0050, MapiPropertyType.String);
            DifferentReplyTo.SetExtendedProperty(PidTagReplyRecipientEntries, ConvertHexStringToByteArray(GenerateFlatList("departmentdg@domain.com", "jc")));
            DifferentReplyTo.SetExtendedProperty(PidTagReplyRecipientNames, "jc");
            DifferentReplyTo.SendAndSaveCopy();
        internal static String GenerateFlatList(String SMTPAddress, String DisplayName)
        {
            String abCount = "01000000";
            String AddressId = GenerateOneOff(SMTPAddress, DisplayName);
            return abCount + BitConverter.ToString(INT2LE((AddressId.Length / 2) + 4)).Replace("-", "") + BitConverter.ToString(INT2LE(AddressId.Length / 2)).Replace("-", "") + AddressId;
        }
        
        internal static String GenerateOneOff(String SMTPAddress,String DisplayName)
        {
            String Flags = "00000000";
            String ProviderUid = "812B1FA4BEA310199D6E00DD010F5402";
            String Version = "0000";
            String xFlags = "0190";
            String DisplayNameHex = BitConverter.ToString(UnicodeEncoding.Unicode.GetBytes(DisplayName + "\0")).Replace("-","");
            String SMTPAddressHex = BitConverter.ToString(UnicodeEncoding.Unicode.GetBytes(SMTPAddress + "\0")).Replace("-", "");
            String AddressType = BitConverter.ToString(UnicodeEncoding.Unicode.GetBytes("SMTP" + "\0")).Replace("-", "");
            return Flags + ProviderUid + Version + xFlags + DisplayNameHex + AddressType + SMTPAddressHex;
        }
        internal static byte[] INT2LE(int data)
        {
            byte[] b = new byte[4];
            b[0] = (byte)data;
            b[1] = (byte)(((uint)data >> 8) & 0xFF);
            b[2] = (byte)(((uint)data >> 16) & 0xFF);
            b[3] = (byte)(((uint)data >> 24) & 0xFF);
            return b;
        }
        internal static byte[] ConvertHexStringToByteArray(string hexString)
        {
            if (hexString.Length % 2 != 0)
            {
                throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", hexString));
            }
            byte[] HexAsBytes = new byte[hexString.Length / 2];
            for (int index = 0; index < HexAsBytes.Length; index++)
            {
                string byteValue = hexString.Substring(index * 2, 2);
                HexAsBytes[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }
            return HexAsBytes;
        }
