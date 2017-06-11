using Microsoft.AspNetCore.Mvc;
using MyCodeCamp.Data;
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

    }
}
