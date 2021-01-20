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
    public class SensortypeController : ControllerBase
    {
        private readonly ApiContext _context;

        public SensortypeController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Sensortype
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sensortype>>> GetSensortype()
        {
            return await _context.Sensortypes.ToListAsync();
        }

        // GET: api/Sensortype/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sensortype>> GetSensortype(int id)
        {
            var sensortype = await _context.Sensortypes.FindAsync(id);

            if (sensortype == null)
            {
                return NotFound();
            }

            return sensortype;
        }

        // PUT: api/Sensortype/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSensortype(int id, Sensortype sensortype)
        {
            if (id != sensortype.SensortypeID)
            {
                return BadRequest();
            }

            _context.Entry(sensortype).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SensortypeExists(id))
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

        // POST: api/Sensortype
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Sensortype>> PostSensortype(Sensortype sensortype)
        {
            _context.Sensortypes.Add(sensortype);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSensortype", new { id = sensortype.SensortypeID }, sensortype);
        }

        // DELETE: api/Sensortype/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sensortype>> DeleteSensortype(int id)
        {
            var sensortype = await _context.Sensortypes.FindAsync(id);
            if (sensortype == null)
            {
                return NotFound();
            }

            _context.Sensortypes.Remove(sensortype);
            await _context.SaveChangesAsync();

            return sensortype;
        }

        private bool SensortypeExists(int id)
        {
            return _context.Sensortypes.Any(e => e.SensortypeID == id);
        }
    }
}
