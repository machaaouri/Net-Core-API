using Microsoft.AspNetCore.Mvc;
using MyCodeCamp.Data;
using MyCodeCamp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    public class CampsController : Controller
    {
        private ICampRepository _repo;
        public CampsController(ICampRepository repo)
        {
            _repo = repo; // this is injected by the ServiceCollection
        }


        [HttpGet("")]
        public IActionResult Get()
        {
            var camps = _repo.GetAllCamps();
            return Ok(camps);
        }

        [HttpGet("{id}",Name ="ModelGet")]
        public IActionResult Get(int id, bool includeSpeakers =false)
        {

            try
            {
                Camp camp = null;
                if (includeSpeakers) camp = _repo.GetCampWithSpeakers(id);
                else camp = _repo.GetCamp(id);

                if (camp == null) return NotFound($"Camp {id} was not found");

                return Ok(camp);

            }
            catch{ }

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Camp model)
        {
            try
            {
                _repo.Add(model);
                if(await _repo.SaveAllAsync())
                {
                    var newUri = Url.Link("ModelGet",new { id = model.Id });
                    return Created(newUri, model);
                }
            }
            catch(Exception e) {
                Console.WriteLine(e.Message);
            }

            return BadRequest();
        }
    }
}
