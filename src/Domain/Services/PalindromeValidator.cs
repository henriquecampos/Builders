using Builders.Domain.Common;

namespace Builders.Domain.Services
{
    public class PalindromeValidator : IPalindromeChecker
    {
        public Result Validate(string value)
        {
            value = value.ToLower();

            int len = value.Length,
                mid = value.Length / 2;

            for (int i = 0; i < mid; i++)
            {
                var first = value[i];
                var last = value[len - 1 - i];
                if (first != last)
                {
                    return new Result(false, $"'{value}' is not a palindrome.");
                }
            }

            return new Result(true, $"'{value}' is a palindrome.");
        }
    }
}
