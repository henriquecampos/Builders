using Builders.Application.BinaryTree.Commands;
using Builders.Application.IntegrationTests.Setup;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace Builders.Application.IntegrationTests
{
    public class NodeTests : IClassFixture<Fixture>
    {
        private readonly Fixture _fixture;

        public NodeTests(Fixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task AddNodeShouldBeReturnSucess()
        {
            var command = new AddNodeCommand() { Value = 99 };
            var response = await _fixture.Client.PostAsJsonAsync("api/binarytree/addnode", command);
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}
