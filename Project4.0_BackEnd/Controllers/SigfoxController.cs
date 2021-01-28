using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project4._0_BackEnd.Data;
using Project4._0_BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project4._0_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SigfoxController : ControllerBase
    {
        private readonly ApiContext _context;

        public SigfoxController(ApiContext context)
        {
            _context = context;
        }

        [HttpPost("{Mac}/{Value}")]
        public async Task PostMeasurement(string Mac, string Value)
        {
            Box box = _context.Boxes.FirstOrDefault(b => b.MacAddress == Mac);
            if (box == null)
            {
                return;
            }
            Measurement measurement1 = new Measurement();
            measurement1.BoxID = box.BoxID;
            measurement1.SensorID = 12;
            measurement1.Value = Value;
            measurement1.TimeStamp = DateTime.Now;
            _context.Measurements.Add(measurement1);
            await _context.SaveChangesAsync();

        }
    }
}
