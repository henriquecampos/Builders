using Builders.Application.Common.Interfaces;
using Builders.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Builders.Application.BinaryTree.Commands
{
    public class AddNodeCommand : MediatR.IRequest
    {
        public int Value { get; set; }
    }

    public class AddNodeCommandHandler : MediatR.AsyncRequestHandler<AddNodeCommand>
    {
        private readonly IBinaryTreeRepository _repository;

        public AddNodeCommandHandler(IBinaryTreeRepository repository)
        {
            _repository = repository;
        }

        protected override async Task Handle(AddNodeCommand request, CancellationToken cancellationToken)
        {
            var newNode = new Node(request.Value);

            var root = await _repository.GetRoot();
            if (root is null)
            {
                await _repository.Insert(newNode);
            }
            else
            {
                root.AddChild(newNode);
                await _repository.Replace(root);
            }
        }
    }
}
