using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Viking_API.Models;

namespace Viking_API.Controllers
{
    public class VikingController : ApiController
    {
        private readonly VikingDbContext _ctx = new VikingDbContext();

        //POST
        [HttpPost]
        public async Task<IHttpActionResult> PostViking(Viking model)
        {
            if(ModelState.IsValid)
            {
                _ctx.Vikings.Add(model);
                await _ctx.SaveChangesAsync();
                return Ok();
            }
            return BadRequest(ModelState);
        }

        //GET
        [HttpGet]
        public async Task<IHttpActionResult> GetViikings()
        {
            List<Viking> listOfVikings = await _ctx.Vikings.ToListAsync();
            return Ok(listOfVikings);
        }

        //GetByID
        [HttpGet]
        public async Task<IHttpActionResult> GetVikingByID(int id)
        {
            Viking viking = await _ctx.Vikings.FindAsync(id);
            if(viking != null)
            {
                return Ok(viking);
            }
            return NotFound();
        }

        //Put
        [HttpPut]
        public async Task<IHttpActionResult> UpdateViking([FromUri] int id, [FromBody] Viking model)
        {
            if(ModelState.IsValid)
            {
                var foundVik = await _ctx.Vikings.FindAsync(id);
                if(foundVik != null)
                {
                    foundVik.Name = model.Name;
                    foundVik.Tribe = model.Tribe;
                    foundVik.Job = model.Job;
                    await _ctx.SaveChangesAsync();
                    return Ok();
                }
                return NotFound();
            }
            return BadRequest(ModelState);
        }
    }
}
