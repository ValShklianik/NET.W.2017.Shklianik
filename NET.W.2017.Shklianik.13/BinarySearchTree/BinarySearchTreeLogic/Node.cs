using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeLogic
{
    public class Node<T>
    {
        public Node<T> LeftChildNode { get; set; }
        public Node<T> RightChildNode { get; set; }
        public T Value { get; }
        public int Count { get; set; }

        public Node(T nodeValue)
        {
            Value = nodeValue;
            Count = 1;
        }
    }
}
