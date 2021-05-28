using Builders.Domain.Common;

namespace Builders.Domain.Services
{
    public interface IPalindromeChecker
    {
        Result Validate(string value);
    }
}