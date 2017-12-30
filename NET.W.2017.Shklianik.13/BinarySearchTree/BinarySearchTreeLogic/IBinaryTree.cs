using System.Collections.Generic;

namespace BinarySearchTreeLogic
{
    public interface IBinaryTree<T>
    {
        /// <summary>
        /// preorder traversal of a binary search tree
        /// </summary>
        /// <param name="tree"></param>
        /// <returns> nodes ordered by preorder traversal</returns>
        IEnumerable<T> Preorder();

        /// <summary>
        /// Inorder traversal of a binary search tree
        /// </summary>
        /// <param name="tree"></param>
        /// <returns >nodes ordered by Inorder traversal</returns>
        IEnumerable<T> Inorder();

        /// <summary>
        /// Postorder traversal of a binary search tree
        /// </summary>
        /// <param name="tree"></param>
        /// <returns >nodes ordered by Postorder traversal</returns>
        IEnumerable<T> Postorder();

        /// <summary>
        /// Adds node to the tree
        /// </summary>
        /// <param name="node"></param>
        void Add(T node);

        /// <summary>
        /// finds the number of occurrences of values in the tree
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the number of occurrences of values in the tree</returns>
        int Find(T value);
    }
}
