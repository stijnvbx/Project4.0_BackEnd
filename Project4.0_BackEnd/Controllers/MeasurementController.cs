using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Measurement>>> GetMeasurement()
        {
            return await _context.Measurement.ToListAsync();
        }

        // GET: api/Measurement/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Measurement>> GetMeasurement(int id)
        {
            var measurement = await _context.Measurement.FindAsync(id);

            if (measurement == null)
            {
                return NotFound();
            }

            return measurement;
        }

        // PUT: api/Measurement/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeasurement(int id, Measurement measurement)
        {
            if (id != measurement.MeasurementID)
            {
                return BadRequest();
            }

            _context.Entry(measurement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeasurementExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Measurement
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Measurement>> PostMeasurement(Measurement measurement)
        {
            _context.Measurement.Add(measurement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMeasurement", new { id = measurement.MeasurementID }, measurement);
        }

        // DELETE: api/Measurement/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Measurement>> DeleteMeasurement(int id)
        {
            var measurement = await _context.Measurement.FindAsync(id);
            if (measurement == null)
            {
                return NotFound();
            }

            _context.Measurement.Remove(measurement);
            await _context.SaveChangesAsync();

            return measurement;
        }

        private bool MeasurementExists(int id)
        {
            return _context.Measurement.Any(e => e.MeasurementID == id);
        }
    }
}
