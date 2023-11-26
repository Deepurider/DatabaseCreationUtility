using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DatabaseUtilityTriggerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DatabaseCreationController : ControllerBase
    {
        private IConfiguration _onfiguration { get; set; }
        public DatabaseCreationController(IConfiguration configuration)
        {
            _onfiguration = configuration;
        }
    
        [HttpPost]
        public async Task<IActionResult> CreateDatabase([FromBody] DatabaseConfiguration configuration)
        {

            var path = _onfiguration.GetSection("ConsoleAppPath").Value;

            Process process = new Process()
            {
                StartInfo = {
                    Arguments = $"{configuration.ServerName} {configuration.DatabaseName} {configuration.Username} {configuration.Password}",
                    FileName = path
                },
            };
            process.Start();
            configuration.ReturnMessage = "Database Sucessfully Created";
            return Ok(configuration);
        }
    }

    public class DatabaseConfiguration()
    {
        public string DatabaseName { get; set; }
        public string ServerName { get; set; }
        public string Username { get; set; }    
        public string Password { get; set; }    
        public string ReturnMessage { get; set; } = string.Empty;
    }
}
