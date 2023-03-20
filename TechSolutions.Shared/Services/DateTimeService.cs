using System;
using TechSolutions.Application.Interfaces;

namespace TechSolutions.Shared.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
