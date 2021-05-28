using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builders.Domain.Entities
{
    public class Node
    {
        public int Value { get; private set; }
        public Node Left { get; private set; }
        public Node Right { get; private set; }

        public Node(int value)
        {
            Value = value;
        }

        public void AddChild(Node newNode)
        {

            if (newNode.Value <= Value)
            {
                if (Left is null)
                {
                    Left = newNode;
                    return;
                }

                Left.AddChild(newNode);
            }
            else
            {
                if (Right is null)
                {
                    Right = newNode;
                    return;
                }

                Right.AddChild(newNode);
            }

        }

        public Node FindWithValue(int value)
        {
            if (Value == value)
                return this;

            if (Value >= value)
            {
                return Left?.FindWithValue(value);
            }

            return Right?.FindWithValue(value);
        }
    }
}
