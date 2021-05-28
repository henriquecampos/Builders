using Builders.Application.IntegrationTests.Setup;
using Builders.Application.Palidrome.Queries;
using Builders.Domain.Common;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace Builders.Application.IntegrationTests
{
    public class PalindromeTests : IClassFixture<Fixture>
    {
        private readonly Fixture _fixture;

        public PalindromeTests(Fixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task PalindromeWordReturnsTrue()
        {
            var query = new CheckPalindromeQuery { Value = "Deleveled" };
            var response = await _fixture.Client.PostAsJsonAsync("api/palindrome/check", query);

            var result = await response.Content.ReadFromJsonAsync<Result>();
            Assert.True(result.Success);
        }

        [Fact]
        public async Task NotPalindromeWordReturnFalse()
        {
            var query = new CheckPalindromeQuery { Value = "something" };
            var response = await _fixture.Client.PostAsJsonAsync("api/palindrome/check", query);

            var result = await response.Content.ReadFromJsonAsync<Result>();
            Assert.False(result.Success);
        }
    }
}
