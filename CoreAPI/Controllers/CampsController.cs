﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    public class CampsController : Controller
    {
        [HttpGet("")]
        public IActionResult Get()
        {
            var camps = null;
            return Ok(camps);
        }

    }
}
