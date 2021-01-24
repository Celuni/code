    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var person = new Person
            {
                FirstName = "Sam",
                BillingAddress = new Address
                {
                    StreeNumber = "100",
                    Street = "Somewhere",
                    Suburb = "Sometown"
                },
                Surname = "Smith"
            };
            var data = person.ToByteArray();
            return File(data, "application/octet-stream");
        }
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var stream = Request.BodyReader.AsStream();
            return File(stream, "application/octet-stream");
        }
        [HttpPut]
        public async Task<IActionResult> Put()
        {
            var stream = Request.BodyReader.AsStream();
            var person = Person.Parser.ParseFrom(stream);
            if (!Request.Headers.ContainsKey("PersonKey")) throw new Exception("No key");
            person.PersonKey = Request.Headers["PersonKey"];
            var data = person.ToByteArray();
            return File(data, "application/octet-stream");
        }
    }
