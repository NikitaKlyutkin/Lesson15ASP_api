using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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
        public MeetingController(IOptions<MeetingSettings> options)
        {
            _settings = options.Value;
        }
        [HttpGet]
        public IEnumerable<MeetingSettings> Get()
        {
            return Enumerable.Range(1, 1).Select(index => new MeetingSettings
            {
                DateMeeting = DateTime.Now.AddDays(index),
                MaxPeople = _settings.MaxPeople,
                TimeMeetingMin = _settings.TimeMeetingMin
            }).ToArray();
        }

        public IActionResult GetAct()
        {
            return new ObjectResult(new MeetingSettings
            {
                MaxPeople = _settings.MaxPeople,
                TimeMeetingMin = _settings.TimeMeetingMin,
                DateMeeting = DateTime.Now.AddDays(0),

            });
        }
    }
}
