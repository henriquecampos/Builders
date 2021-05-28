using Builders.Domain.Entities;
using Xunit;

namespace Builders.Domain.UnitTests
{
    public class NodeTests
    {
        [Theory]
        [InlineData(2, 2)]
        [InlineData(2, 1)]
        public void Node_LessThanOrEqualShoudBeLeft(int rootValue, int newValue)
        {
            Node root = new Node(rootValue);

            Node newNode = new Node(newValue);
            root.AddChild(newNode);

            Assert.True(root.Value >= root.Left.Value);
            Assert.True(root.Right is null);
            Assert.Equal(newNode, root.Left);
        }

        [Theory]
        [InlineData(2, 4)]
        public void Node_GreaterShoudBeRight(int rootValue, int newValue)
        {
            Node root = new Node(rootValue);

            Node newNode = new Node(newValue);
            root.AddChild(newNode);

            Assert.True(root.Value < root.Right.Value);
            Assert.True(root.Left is null);
            Assert.Equal(newNode, root.Right);
        }

        [Theory]
        [InlineData(10, 19)]
        public void Node_SearchShouldFindExistingValue(int rootValue, int searchValue)
        {
            Node root = new Node(rootValue);

            Node childNode = new Node(searchValue);
            root.AddChild(childNode);

            var node = root.FindWithValue(searchValue);
            Assert.Equal(searchValue, node.Value);
            Assert.Equal(root.Right.Value, searchValue);
        }
    }
}
