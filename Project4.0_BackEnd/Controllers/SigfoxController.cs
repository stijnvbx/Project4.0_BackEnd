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

        [HttpPost("{Mac}/{tempMcu}/{tempB}/{temp}/{vocht}/{bVocht}")]
        public async Task PostMeasurement(string Mac, string tempMcu, string tempB, string temp, string vocht, string bVocht)
        {
            Box box = _context.Boxes.FirstOrDefault(b => b.MacAddress == Mac);
            if (box == null)
            {
                return;
            }
            Measurement measurement1 = new Measurement();
            measurement1.BoxID = box.BoxID;
            measurement1.SensorID = 12;
            measurement1.Value = tempMcu;
            measurement1.TimeStamp = DateTime.Now;
            _context.Measurements.Add(measurement1);
            Measurement measurement2 = new Measurement();
            measurement2.BoxID = box.BoxID;
            measurement2.SensorID = 11;
            measurement2.Value = vocht;
            measurement2.TimeStamp = DateTime.Now;
            _context.Measurements.Add(measurement2);
            Measurement measurement3 = new Measurement();
            measurement3.BoxID = box.BoxID;
            measurement3.SensorID = 12;
            measurement3.Value = tempB;
            measurement3.TimeStamp = DateTime.Now;
            _context.Measurements.Add(measurement3);
            Measurement measurement4 = new Measurement();
            measurement4.BoxID = box.BoxID;
            measurement4.SensorID = 11;
            measurement4.Value = bVocht;
            measurement4.TimeStamp = DateTime.Now;
            _context.Measurements.Add(measurement4);
            Measurement measurement5 = new Measurement();
            measurement5.BoxID = box.BoxID;
            measurement5.SensorID = 12;
            measurement5.Value = temp;
            measurement5.TimeStamp = DateTime.Now;
            _context.Measurements.Add(measurement5);
            await _context.SaveChangesAsync();

        }
    }
}
