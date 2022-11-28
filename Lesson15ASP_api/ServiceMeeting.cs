using Microsoft.Extensions.Options;

namespace Lesson15ASP_api
{
    public class ServiceMeeting
    {
        private readonly MeetingSettings _settings;
        public ServiceMeeting(IOptions<MeetingSettings> options)
        {
            _settings= options.Value;
        }

        public string GetSettings()
        {
            return $"MaxPeople:{_settings.MaxPeople} , TimeMeeting {_settings.TimeMeeting}";
        }
    }
}
