using Builders.Domain.Services;
using Xunit;

namespace Builders.Domain.UnitTests
{
    public class PalindromeValidatorTests
    {
        [Fact]
        public void PalindromeWordReturnsTrue()
        {
            var palindromeValidator = new PalindromeValidator();

            var result = palindromeValidator.Validate("Deleveled");
            Assert.True(result.Success);
        }

        [Fact]
        public void NotPalindromeWordReturnFalse()
        {
            var palindromeValidator = new PalindromeValidator();

            var result = palindromeValidator.Validate("something");
            Assert.False(result.Success);
        }
    }
}
