using TodoApi.Application.Common.Interfaces.Services;

namespace TodoApi.Infrastructure.Common.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}