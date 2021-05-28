using Builders.Domain.Common;
using Builders.Domain.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Builders.Application.Palidrome.Queries
{
    public class CheckPalindromeQuery : IRequest<Result>
    {
        public string Value { get; set; }
    }

    public class CheckPalindromeQueryHandler : IRequestHandler<CheckPalindromeQuery, Result>
    {
        private readonly IPalindromeChecker _palindromeChecker;

        public CheckPalindromeQueryHandler(IPalindromeChecker palindromeChecker)
        {
            _palindromeChecker = palindromeChecker;
        }

        public Task<Result> Handle(CheckPalindromeQuery request, CancellationToken cancellationToken)
        {
            var result = _palindromeChecker.Validate(request.Value);
            return Task.FromResult(result);
        }
    }
}
