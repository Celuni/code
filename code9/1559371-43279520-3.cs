    // include these namespaces :
    using System;
    using System.Collections.Generic;
    public class Message
    {
        int m_MessageLength;
        // your other fields
        char m_OtherField1;
        char m_OtherField2;
        char m_OtherField3;
        char m_OtherField4;
        // message content as I assume is string
        string m_MessageContent;
    
        public Message(string message, int field1, int field2, int field3, int field4)
        {
            m_MessageConten = message;
            m_OtherField1 = field1;
            m_OtherField2 = field2;
            m_OtherField3 = field3;
            m_OtherField4 = field4;
        }
    
        public static explicit operator byte[](this Message message)
        {
            List<byte> buffer = new List<byte>();
            // 4 fields each 2bytes wide gives us 16 bytes
            // ASCII character is 7 bits wide but is packed into 8 bits which is 1byte
            // gives us the result of ( length_of_message * 1byte == length_of_message )
            buffer.AddRange(BitConverter.GetBytes(8 + m_MessageContent.Length));
            buffer.AddRange(BitConverter.GetBytes(m_OtherField1));
            buffer.AddRange(BitConverter.GetBytes(m_OtherField2));
            buffer.AddRange(BitConverter.GetBytes(m_OtherField3));
            buffer.AddRange(BitConverter.GetBytes(m_OtherField4));
            buffer.AddRange(Encoding.ASCII.GetBytes(m_MessageContent));
            return buffer.ToArray();
        } 
    }
