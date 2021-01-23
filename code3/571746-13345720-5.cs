    namespace StackOverflow_13345557
    {
        [ServiceContract]
        public interface IService1
        {
            [WebGet(ResponseFormat = WebMessageFormat.Json)]
            string Ping();
            [WebGet(ResponseFormat = WebMessageFormat.Json)]
            string PingWithParameters(int a, string b);
        }
        public class Service1 : IService1
        {
            public string Ping()
            {
                return "Hello";
            }
            public string PingWithParameters(int a, string b)
            {
                return string.Format("Hello {0} - {1}", a, b);
            }
        }
    }
