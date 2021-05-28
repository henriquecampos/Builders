using Builders.Application.BinaryTree.Commands;
using Builders.Application.BinaryTree.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Builders.Api.Controllers
{
    [Route("api/binarytree")]
    public class BinaryTreeController : ApiControllerBase
    {
        [HttpPost]
        [Route("addnode")]
        public async Task<IActionResult> AddNode(AddNodeCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        [Route("find")]
        public async Task<IActionResult> FindWithValue([FromQuery] FindNodeQuery query)
        {
            var node = await Mediator.Send(query);
            return Ok(node);
        }
    }
}
