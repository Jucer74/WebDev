using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;



// Para agregar a la base de datos

namespace WebDev.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class DiseasesController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Runny Nose", "Coughing", "Sore Throat", "Headache", "Sneeze", "Pain", "Fever"
        };

        private readonly ILogger<DiseasesController> _logger;

        public DiseasesController(ILogger<DiseasesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Diseases> Get()
        {
            var rng = new Random();
            
            return Enumerable.Range(1, 10).Select(index => new Diseases
            {
                Date = DateTime.Now.AddDays(index),
                DiseasesW = rng.Next(index),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}