using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project4._0_BackEnd.Data;
using Project4._0_BackEnd.Models;

namespace Project4._0_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementController : ControllerBase
    {
        private readonly ApiContext _context;

        public MeasurementController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Measurement
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Measurement>>> GetMeasurement()
        {
            return await _context.Measurements.ToListAsync();
        }

        [Authorize]
        [HttpGet("Sensor/{id}")]
        public async Task<ActionResult<IEnumerable<Measurement>>> GetMeasurementsFromSensor(int id)
        {
            return await _context.Measurements.Where(m => m.SensorID == id).Take(5000).ToListAsync();
        }

/*        // GET: api/Measurement/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Measurement>> GetMeasurement(int id)
        {
            var measurement = await _context.Measurements.FindAsync(id);

            if (measurement == null)
            {
                return NotFound();
            }

            return measurement;
        }*/
    }
}
