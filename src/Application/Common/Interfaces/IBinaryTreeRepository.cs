using Builders.Domain.Entities;
using System.Threading.Tasks;

namespace Builders.Application.Common.Interfaces
{
    public interface IBinaryTreeRepository
    {
        Task<Node> GetRoot();
        Task Insert(Node root);
        Task Replace(Node root);
    }
}
