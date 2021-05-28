using Builders.Application.Common.Interfaces;
using Builders.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Builders.Application.BinaryTree.Queries
{
    public class FindNodeQuery : IRequest<Node>
    {
        public int Value { get; set; }
    }

    public class FindNodeQueryHandler : IRequestHandler<FindNodeQuery, Node>
    {
        private readonly IBinaryTreeRepository _repository;

        public FindNodeQueryHandler(IBinaryTreeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Node> Handle(FindNodeQuery request, CancellationToken cancellationToken)
        {
            var root = await _repository.GetRoot();
            return root.FindWithValue(request.Value);
        }
    }
}
