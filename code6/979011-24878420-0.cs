    using System;
    using Twilio;
    class Example {
      static void Main(string[] args) {
        // Find your Account Sid and Auth Token at twilio.com/user/account
        string AccountSid = "AC3094732a3c49700934481addd5ce1659";
        string AuthToken = "{{ auth_token }}";
        var twilio = new TwilioRestClient(AccountSid, AuthToken);
 
        var options = new CallOptions();
        options.Url = "http://demo.twilio.com/docs/voice.xml";
        options.To = "+14155551212";
        options.From = "+14158675309";
        var call = twilio.InitiateOutboundCall(options);
     
        Console.WriteLine(call.Sid);    
      }
    }
