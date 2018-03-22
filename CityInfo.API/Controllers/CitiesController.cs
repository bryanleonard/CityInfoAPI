using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{

    [Route("api/cities")]
    public class CitiesController : Controller
    {
        [HttpGet()]
        public IActionResult GetCities()
        {
            //var result = CitiesDataStore.Current.Cities;
            //if (result == null)
            //{
            //    return NotFound();
            //}

            // No NotFound bc empty collection is still valid in this case.
            return Ok(CitiesDataStore.Current.Cities);
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {
            var result = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
                
        }
    }
}