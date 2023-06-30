using Domain.Interfaces;

namespace Infra
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}
