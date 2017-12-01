namespace BinarySearchTreeLogic
{
    public class Node<T>
    {
        #region ctor
        public Node(T nodeValue)
        {
            Value = nodeValue;
            Count = 1;
        }
        #endregion !ctor

        #region public properties
        public Node<T> LeftChildNode { get; set; }

        public Node<T> RightChildNode { get; set; }

        public T Value { get; }

        public int Count { get; set; }
        #endregion
    }
}
