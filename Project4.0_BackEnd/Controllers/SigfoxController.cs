using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project4._0_BackEnd.Data;
using Project4._0_BackEnd.Helpers;
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
        private HexHelper hexHelper;

        public SigfoxController(ApiContext context)
        {
            _context = context;
        }

        [HttpPost("{Mac}/{data}")]
        public async Task PostMeasurement(string Mac, string data)
        {
            Box box = _context.Boxes.FirstOrDefault(b => b.MacAddress == Mac);
            if (box == null)
            {
                return;
            }
            DateTime date1 = DateTime.UtcNow;
            TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");
            DateTime date2 = TimeZoneInfo.ConvertTime(date1, timeZoneInfo);

            List<string> dummy = HexHelper.HexConv(data);
            if (int.Parse(dummy[0]) == 1)
            {
                dummy.Remove("1");
                dummy.RemoveAll(p => p == "0");
                string test = string.Join(",", dummy);
                box.ConfiguratieString = test;
                await _context.SaveChangesAsync();
                return;
            }
            if (int.Parse(dummy[0]) == 2)
            {
                dummy.Remove("2");
                //string test = string.Join(",", dummy);
                //string[] values = test.Split(",");
                string conf = box.ConfiguratieString;
                string[] sensors = conf.Split(",");
                int i = 0;

                foreach (string sensor in sensors) {

                    SensorBox sensorBox = _context.SensorBoxes.Where(s => s.BoxID == box.BoxID).FirstOrDefault(s => s.SensorID == int.Parse(sensor));
                    if (sensorBox == null)
                    {
                        SensorBox sensorBox1 = new SensorBox();
                        sensorBox1.BoxID = box.BoxID;
                        sensorBox1.SensorID = int.Parse(sensor);
                        _context.SensorBoxes.Add(sensorBox1);
                        await _context.SaveChangesAsync();
                    }

                    Measurement measurement = new Measurement();
                    measurement.BoxID = box.BoxID;
                    measurement.SensorID = int.Parse(sensor);
                    measurement.TimeStamp = date2;
                    measurement.Value = dummy[i];
                    i++;
                    _context.Measurements.Add(measurement);
                    await _context.SaveChangesAsync();
                }
                return;
            }
        }
    }
}
