using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lesson15ASP_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeetingController : ControllerBase
    {
        private readonly MeetingSettings _settings;
        private readonly ILogger<MeetingController> _logger;

        public MeetingController(IOptions<MeetingSettings> options, ILogger<MeetingController> log)
        {
            _settings = options.Value;
            _logger = log;
          
        }
        [HttpGet]
        public IEnumerable<MeetingSettings> Get()
        {
            _logger.LogInformation("Прочитал файл JSON");
            return Enumerable.Range(1, 1).Select(index => new MeetingSettings
            {
                DateMeeting = DateTime.Now.AddDays(index),
                MaxPeople = _settings.MaxPeople,
                TimeMeetingMin = _settings.TimeMeetingMin
                

        }).ToArray();
        
        }

        //public IActionResult GetAct()
        //{
        //    return new ObjectResult(new MeetingSettings
        //    {
        //        MaxPeople = _settings.MaxPeople,
        //        TimeMeetingMin = _settings.TimeMeetingMin,
        //        DateMeeting = DateTime.Now.AddDays(0),

        //    });
        //}
    }
}
