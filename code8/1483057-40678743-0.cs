    public class MyApitController : ApiController {
        public async Task<HttpResponseMessage> Create([FromBody] AType payload) {
            if (payload == null) {
                throw new ArgumentNullException(nameof(payload));
            }
            await Task.Delay(1);
            var t = new T { Id = 0, Name = payload.tName, Guid = Guid.NewGuid() };
            var response = new MyResponse { T = t };
            
            var result = Request.CreateResponse(HttpStatusCode.OK, response);
            return result;
        }
    }
