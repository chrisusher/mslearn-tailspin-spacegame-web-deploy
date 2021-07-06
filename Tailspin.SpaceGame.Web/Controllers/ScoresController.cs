using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TailSpin.SpaceGame.Web.DB;
using TailSpin.SpaceGame.Web.Models;

namespace TailSpin.SpaceGame.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        private TailspinContext _dbContext;

        public ScoresController(TailspinContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Score>> GetScoresAsync(string mode, string region, int pageCount, int pageSize)
        {
            var skip = pageCount * pageSize;

            var scores = _dbContext.Scores.Where(x=> (string.IsNullOrEmpty(mode) || x.GameMode == mode) &&
                                                (string.IsNullOrEmpty(region) || x.GameRegion == region))
                                            .OrderByDescending(x=>x.HighScore)
                                            .Skip(skip)
                                            .Take(pageSize);

            return await scores.ToListAsync();
        }
    }
}