    [Route("api/[controller]")]
    public class OCRController : ControllerBase
     {
        [HttpPost]
        public async Task<IActionResult> Post([FromForm(Name = "file")] IFormFile file)
        {
        }
    }
