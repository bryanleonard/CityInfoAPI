using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    public class DummyController : Controller
    {
        private CityInfoContext _context;

        public DummyController(CityInfoContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("api/testdatabase")]
        public IActionResult TestDatabase()
        {
            return Ok();
        }
    }
}