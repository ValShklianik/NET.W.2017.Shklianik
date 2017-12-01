using System;
using System.Collections.Generic;

namespace BinarySearchTreeLogic
{
    /// <summary>
    /// public class of Binary tree
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryTree<T> : IBinaryTree<T> where T : IComparable<T>
    {
        #region private fields
        private Node<T> headNode;
        private IComparer<T> comparer;
        #endregion !private

        #region ctors
        public BinaryTree() {
            comparer = Comparer<T>.Create((a, b) => a.CompareTo(b));
        }

        /// <summary>
        /// ctor which receive a comparer
        /// </summary>
        /// <param name="comparer"></param>
        public BinaryTree(IComparer<T> comparer)
        {
            this.comparer = comparer;
        }

        /// <summary>
        /// ctor which receive values of nodes
        /// </summary>
        /// <param name="values"></param>
        public BinaryTree(IEnumerable<T> values) : this()
        {
            if (values == null) throw new ArgumentNullException("Valuse is null");
            foreach (var value in values)
            {
                Add(value);
            }
        }

        /// <summary>
        /// ctor which receive values of nodes and comparer
        /// </summary>
        /// <param name="values"></param>
        /// <param name="comparer"></param>
        public BinaryTree(IEnumerable<T> values, IComparer<T> comparer) : this(comparer)
        {
            if (values == null) throw new ArgumentNullException("Valuse is null");
            foreach (var value in values)
            {
                Add(value);
            }
        }
        #endregion !ctors

        #region public methods
        /// <inheritdoc />
        public void Add(T value)
        {
            if (value == null) throw new ArgumentNullException("Value is null");
            var node = new Node<T>(value);
            if (headNode == null) headNode = node;
            else FindPlace(headNode, node);
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
        public IEnumerable<T> Preorder()
        {
            return PreorderTraversal(headNode);
        }

        public IEnumerable<T> Inorder()
        {
            return InorderTraversal(headNode);
        }

        /// <inheritdoc />
        public IEnumerable<T> Postorder()
        {
            return PostorderTraversal(headNode);
        }
        #endregion !public

        /// <summary>
        /// preorder traversal of a binary search tree
        /// </summary>
        /// <param name="node"></param>
        /// <returns> nodes ordered by preorder traversal</returns>
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

        /// <summary>
        /// Inorder traversal of a binary search tree
        /// </summary>
        /// <param name="node"></param>
        /// <returns>nodes ordered by Inorder traversal</returns>
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

        /// <summary>
        ///  Postorder traversal of a binary search tree
        /// </summary>
        /// <param name="node"></param>
        /// <returns>nodes ordered by Postorder traversal</returns>
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

        /// <summary>
        /// find place for adds new node
        /// </summary>
        /// <param name="headNode"></param>
        /// <param name="node"></param>
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