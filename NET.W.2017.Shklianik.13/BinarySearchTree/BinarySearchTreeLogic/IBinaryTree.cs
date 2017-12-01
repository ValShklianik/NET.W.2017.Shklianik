using System.Collections.Generic;

namespace BinarySearchTreeLogic
{
    public interface IBinaryTree<T>
    {
        /// <summary>
        /// preorder traversal of a binary search tree
        /// </summary>
        /// <param name="tree"></param>
        /// <returns nodes ordered by preorder traversal></returns>
        IEnumerable<T> Preorder();

        /// <summary>
        /// Inorder traversal of a binary search tree
        /// </summary>
        /// <param name="tree"></param>
        /// <returns nodes ordered by Inorder traversal></returns>
        IEnumerable<T> Inorder();


        /// <summary>
        /// Postorder traversal of a binary search tree
        /// </summary>
        /// <param name="tree"></param>
        /// <returns nodes ordered by Postorder traversal></returns>
        IEnumerable<T> Postorder();

        void Add(T node);

        int Find(T value);
    }
}
