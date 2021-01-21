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
    public class MonitoringController : ControllerBase
    {
        private readonly ApiContext _context;

        public MonitoringController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Monitoring
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Monitoring>>> GetMonitoring()
        {
            return await _context.Monitorings.ToListAsync();
        }

        // GET: api/Monitoring/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Monitoring>> GetMonitoring(int id)
        {
            var Monitoring = await _context.Monitorings.FindAsync(id);

            if (Monitoring == null)
            {
                return NotFound();
            }

            return Monitoring;
        }

        // PUT: api/Monitoring/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMonitoring(int id, Monitoring Monitoring)
        {
            if (id != Monitoring.MonitoringID)
            {
                return BadRequest();
            }

            _context.Entry(Monitoring).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonitoringExists(id))
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

        // POST: api/Monitoring
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Monitoring>> PostMonitoring(Monitoring Monitoring)
        {
            _context.Monitorings.Add(Monitoring);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMonitoring", new { id = Monitoring.MonitoringID }, Monitoring);
        }

        // DELETE: api/Monitoring/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Monitoring>> DeleteMonitoring(int id)
        {
            var Monitoring = await _context.Monitorings.FindAsync(id);
            if (Monitoring == null)
            {
                return NotFound();
            }

            _context.Monitorings.Remove(Monitoring);
            await _context.SaveChangesAsync();

            return Monitoring;
        }

        private bool MonitoringExists(int id)
        {
            return _context.Monitorings.Any(e => e.MonitoringID == id);
        }
    }
}
