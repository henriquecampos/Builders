using Builders.Application.Palidrome.Queries;
using Builders.Domain.Common;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Builders.Api.Controllers
{
    [Route("api/palindrome")]
    public class PalindromeController : ApiControllerBase
    {
        [HttpPost]
        [Route("check")]
        public async Task<Result> Check(CheckPalindromeQuery command)
        {
            return await Mediator.Send(command);
        }
    }
}
