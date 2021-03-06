    public class Message1 : MessageBase
    {}
    public class Message2 : MessageBase
    {
        public override void Action()
        {
            Console.Write(@"Overriding ");
            base.Action();
        }
    }
    public class Message1Handler : IMessageHandler
    {
        public void Execute<T>(T message) where T : MessageBase
        {
            Console.Write(@"MessageHandler1 > ");
            message.Action();
        }
    }
    public class Message2Handler : IMessageHandler
    {
        public void Execute<T>(T message) where T : MessageBase
        {
            Console.Write(@"MessageHandler2 > ");
            message.Action();
            Console.WriteLine(@"...and then some");
        }
    }
