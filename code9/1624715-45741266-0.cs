    // Download the twilio-csharp library from twilio.com/docs/libraries/csharp
    using System;
    using Twilio;
    using Twilio.Rest.Api.V2010.Account;
    
    class Example
    {
        static void Main(string[] args)
        {
            // Find your Account Sid and Auth Token at twilio.com/console
            const string accountSid = "ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            const string authToken = "your_auth_token";
            TwilioClient.Init(accountSid, authToken);
    
            var messages = MessageResource.Read();
    
            foreach (var message in messages)
            {
                Console.WriteLine(message.Body);
            }
        }
    }
