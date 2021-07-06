using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TailSpin.SpaceGame.Web.DB;
using TailSpin.SpaceGame.Web.Models;

namespace TailSpin.SpaceGame.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private TailspinContext _dbContext;

        public ProfileController(TailspinContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public Profile GetProfile(int profileId)
        {
            return _dbContext.Profiles.FirstOrDefault(x=>x.Id == profileId);
        }
    }
}