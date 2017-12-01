using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeLogic
{
    public class BinaryTree<T> : IBinaryTree<T> where T : IComparable<T>
    {
        private Node<T> headNode;
        private IComparer<T> comparer;

        public BinaryTree() {
            comparer = Comparer<T>.Create((a, b) => a.CompareTo(b));
        }

        public BinaryTree(IComparer<T> comparer)
        {
            this.comparer = comparer;
        }

        public BinaryTree(IEnumerable<T> values) : this()
        {
            if (values == null) throw new ArgumentNullException("Valuse is null");
            foreach (var value in values)
            {
                Add(value);
            }
        }

        public BinaryTree(IEnumerable<T> values, IComparer<T> comparer) : this(comparer)
        {
            if (values == null) throw new ArgumentNullException("Valuse is null");
            foreach (var value in values)
            {
                Add(value);
            }
        }

        public void Add(T value)
        {
            if (value == null) throw new ArgumentNullException("Value is null");
            var node = new Node<T>(value);
            if (headNode == null) headNode = node;
            else FindPlace(headNode, node);
        }

        public int Find(T value)
        {
            if (value == null) throw new ArgumentNullException("Value is null");
            if (headNode == null) throw new ArgumentNullException("Tree is empty");

            var current = headNode;
            while (current != null)
            {
                if (comparer.Compare(current.Value, value) > 0)
                {
                    current = current.LeftChildNode;
                }
                else if (comparer.Compare(current.Value, value) < 0)
                {
                    current = current.RightChildNode;
                }
                else return current.Count;
            }

            return 0;
        }

        public IEnumerable<T> Preorder()
        {
            return PreorderTraversal(headNode);
        }

        public IEnumerable<T> Inorder()
        {
            return InorderTraversal(headNode);
        }

        public IEnumerable<T> Postorder()
        {
            return PostorderTraversal(headNode);
        }

        private IEnumerable<T> PreorderTraversal(Node<T> node)
        {
            while (true)
            {
                yield return node.Value;

                if (!ReferenceEquals(node.LeftChildNode, null))
                {
                    foreach (var item in PreorderTraversal(node.LeftChildNode))
                    {
                        yield return item;
                    }
                }

                if (!ReferenceEquals(node.RightChildNode, null))
                {
                    node = node.RightChildNode;
                    continue;
                }

                break;
            }
        }

        private IEnumerable<T> InorderTraversal(Node<T> node)
        {
            while (true)
            {
                if (!ReferenceEquals(node.LeftChildNode, null))
                {
                    foreach (var item in InorderTraversal(node.LeftChildNode))
                    {
                        yield return item;
                    }
                }

                yield return node.Value;

                if (!ReferenceEquals(node.RightChildNode, null))
                {
                    node = node.RightChildNode;
                    continue;
                }

                break;
            }
        }

        private IEnumerable<T> PostorderTraversal(Node<T> node)
        {
            if (!ReferenceEquals(node.LeftChildNode, null))
            {
                foreach (var item in PostorderTraversal(node.LeftChildNode))
                {
                    yield return item;
                }
            }

            if (!ReferenceEquals(node.RightChildNode, null))
            {
                foreach (var item in PostorderTraversal(node.RightChildNode))
                {
                    yield return item;
                }
            }

            yield return node.Value;
        }

        private void FindPlace(Node<T> headNode, Node<T> node)
        {
            if (comparer.Compare(headNode.Value, node.Value) > 0)
            {
                if (headNode.LeftChildNode != null) FindPlace(headNode.LeftChildNode, node);
                else headNode.LeftChildNode = node;
            }
            else if (comparer.Compare(headNode.Value, node.Value) < 0)
            {
                if (headNode.RightChildNode != null) FindPlace(headNode.RightChildNode, node);
                else headNode.RightChildNode = node;
            }
            else
            {
                headNode.Count++;
            }
        }
    }
}

