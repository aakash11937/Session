using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Session1.Repository.InterfaceRepo;

namespace Session1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionOneController : ControllerBase
    {
        private readonly ISessionOne _session;

        public SessionOneController(ISessionOne session)
        {
            //comment this line for Occour Error for GlobalException Handling 
            //_session = session;
        }

        [HttpGet("getvalueFromJsonFile")]
        public string GetMessageOne()
        {
            var message = _session.GetMessage();
            return message;
        }
    }
}
