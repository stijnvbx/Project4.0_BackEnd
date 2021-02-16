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
    public class SensorTypeController : ControllerBase
    {
        private readonly ApiContext _context;

        public SensorTypeController(ApiContext context)
        {
            _context = context;
        }

/*        // GET: api/SensorType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SensorType>>> GetSensorType()
        {
            return await _context.SensorTypes.ToListAsync();
        }

        // GET: api/SensorType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SensorType>> GetSensorType(int id)
        {
            var SensorType = await _context.SensorTypes.FindAsync(id);

            if (SensorType == null)
            {
                return NotFound();
            }

            return SensorType;
        }

        // PUT: api/SensorType/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSensorType(int id, SensorType SensorType)
        {
            if (id != SensorType.SensorTypeID)
            {
                return BadRequest();
            }

            _context.Entry(SensorType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SensorTypeExists(id))
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

        // POST: api/SensorType
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SensorType>> PostSensorType(SensorType SensorType)
        {
            _context.SensorTypes.Add(SensorType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSensorType", new { id = SensorType.SensorTypeID }, SensorType);
        }

        // DELETE: api/SensorType/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SensorType>> DeleteSensorType(int id)
        {
            var SensorType = await _context.SensorTypes.FindAsync(id);
            if (SensorType == null)
            {
                return NotFound();
            }

            _context.SensorTypes.Remove(SensorType);
            await _context.SaveChangesAsync();

            return SensorType;
        }

        private bool SensorTypeExists(int id)
        {
            return _context.SensorTypes.Any(e => e.SensorTypeID == id);
        }*/
    }
}
