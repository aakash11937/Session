using Session1.Repository.InterfaceRepo;

namespace Session1.Repository.implementation
{
    public class SessionOneRepository : ISessionOne
    {
        private readonly IConfiguration _configuration;

        public SessionOneRepository(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public string GetMessage()
        {
            string message = _configuration["SampleString"];
            return message;
        }
    }
}
