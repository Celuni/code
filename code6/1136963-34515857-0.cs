        using System;
        using Twilio;
        class Example 
        {
           static void Main(string[] args) 
           {
             // Find your Account Sid and Auth Token at twilio.com/user/account
             string AccountSid = "AC5ef8732a3c49700934481addd5ce1659";
             string AuthToken = "{{ auth_token }}";
             var twilio = new TwilioRestClient(AccountSid, AuthToken);
        
            var request = new MessageListRequest();
            // 10 days ago.
            request.DateSent = (DateTime.UtcNow - TimeSpan.FromDays(10));
            
            // this will do the comparison for greater than or eqal to
            request.DateSentComparison = ComparisonType.GreaterThanOrEqualTo;
           // use following if want to do less than or equal to
           //request.DateSentComparison = ComparisonType.LessThanOrEqualTo;
            
            var messages = twilio.ListMessages(request);
        
            foreach (var message in messages.Messages)
            {
              Console.WriteLine(message.Body);
            }
          }
        }
