using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using BinarySearchTreeLogic;


namespace BinarySearchTreeTests
{
    [TestFixture]
    public class TestClass
    {
#region int cases
        [TestCase(new[] { 5, 3, 1, 8, 3 }, 5, ExpectedResult = 1)]
        [TestCase(new[] { 5, 5, 5, 4, 1 }, 5, ExpectedResult = 3)]
        [TestCase(new[] { 6, 4, 1, 1, 4 }, 1, ExpectedResult = 2)]
        [TestCase(new[] { 6, 4, 1, 1, 4 }, 9, ExpectedResult = 0)]
        public int FindCountOFElmenetInBinaryTreeTest(int[] array, int req)
        {

            var tree = new BinaryTree<int>(array);
            var count = tree.Find(req);
            return count;
        }


        [TestCase(new[] { 6, 3, 1, 8, 3 }, 5, ExpectedResult = 1)]
        [TestCase(new[] { 5, 5, 5, 4, 1 }, 5, ExpectedResult = 4)]
        [TestCase(new[] { 6, 4, 1, 0, 4 }, 1, ExpectedResult = 2)]
        [TestCase(new[] { 9, 9, 9, 9, 9 }, 9, ExpectedResult = 6)]
        [TestCase(new int[0], 2, ExpectedResult = 1)]
        public int AddElmenetInBinaryTreeTest(int[] array, int req)
        {

            var tree = new BinaryTree<int>(array);
            tree.Add(req);
            return tree.Find(req);
        }

        [TestCase(new[] { 6, 3, 1, 8, 3 }, ExpectedResult = new int[] {6, 3, 1, 8})]
        [TestCase(new[] { 5, 5, 5, 4, 1 }, ExpectedResult = new int[] { 5, 4, 1 })]
        [TestCase(new[] { 6, 4, 10, 0, 4 }, ExpectedResult = new int[] { 6, 4, 0, 10 })]
        [TestCase(new[] { 9, 9, 9, 9, 9 }, ExpectedResult = new int[] { 9 })]
        public IEnumerable<int> PreorderTraversalOfTree(int[] array)
        {
            var tree = new BinaryTree<int>(array);
            return tree.Preorder();
        }

        [TestCase(new[] { 6, 3, 1, 8, 3 }, ExpectedResult = new int[] { 1, 3, 6, 8 })]
        [TestCase(new[] { 5, 5, 5, 4, 1 }, ExpectedResult = new int[] {1, 4, 5 })]
        [TestCase(new[] { 6, 4, 10, 0, 4 }, ExpectedResult = new int[] { 0, 4, 6, 10 })]
        [TestCase(new[] { 9, 9, 9, 9, 9 }, ExpectedResult = new int[] { 9 })]
        public IEnumerable<int> InorderTraversalOfTree(int[] array)
        {
            var tree = new BinaryTree<int>(array);
            return tree.Inorder();
        }

        [TestCase(new[] { 6, 3, 1, 8, 3 }, ExpectedResult = new int[] { 1, 3, 8, 6 })]
        [TestCase(new[] { 5, 5, 5, 4, 1 }, ExpectedResult = new int[] { 1, 4, 5 })]
        [TestCase(new[] { 6, 4, 10, 0, 4 }, ExpectedResult = new int[] { 0, 4, 10, 6 })]
        [TestCase(new[] { 9, 9, 9, 9, 9 }, ExpectedResult = new int[] { 9 })]
        public IEnumerable<int> PostorderTraversalOfTree(int[] array)
        {
            var tree = new BinaryTree<int>(array);
            return tree.Postorder();
        }
        #endregion !int

#region string cases

        [TestCase(new[] { "s", "i", "sh", "a", "rp" }, "s", ExpectedResult = 1)]
        [TestCase(new[] { "zzz", "Z", "zz", "ZZZ", "kEk", "ZzZ" }, "zzz", ExpectedResult = 1)]
        [TestCase(new[] { "", "", "d", "23" }, "", ExpectedResult = 2)]
        [TestCase(new[] { "6, 4, 1, 1, 4" }, "9", ExpectedResult = 0)]
        public int FindCountOFStringElmenetInBinaryTreeTest(string[] array, string req)
        {

            var tree = new BinaryTree<string>(array);
            var count = tree.Find(req);
            return count;
        }


        [TestCase(new[] { "s", "i", "sh", "a", "rp" }, "s", ExpectedResult = 2)]
        [TestCase(new[] { "zzz", "Z", "zz", "zzz", "kEk", "ZzZ" }, "zzz", ExpectedResult = 3)]
        [TestCase(new[] { "", "", "d", "23" }, "", ExpectedResult = 3)]
        [TestCase(new[] { "6, 4, 1, 1, 4" }, "9", ExpectedResult = 1)]
        [TestCase(new string[0], "", ExpectedResult = 1)]
        public int AddStringElmenetInBinaryTreeTest(string[] array, string req)
        {

            var tree = new BinaryTree<string>(array);
            tree.Add(req);
            return tree.Find(req);
        }

        [TestCase(new[] { "s", "i", "sh", "a", "rp" }, "a", ExpectedResult = new[] { "s","i", "a", "rp", "sh" })]
        [TestCase(new[] { "zzz", "Z", "zz", "zzz", "kEk", "ZzZ" }, "zzz", ExpectedResult = new[] { "zzz", "Z", "kEk", "zz", "ZzZ" })]
        [TestCase(new[] { "", "", "d", "23" }, "a", ExpectedResult = new[] { "", "d", "23" })]
        [TestCase(new[] { "6, 4, 1, 1, 4" }, "9", ExpectedResult = new[] { "6, 4, 1, 1, 4" })]
        public IEnumerable<string> PreorderTraversalStringOfTree(string[] array, string a)
        {
            var tree = new BinaryTree<string>(array);
            return tree.Preorder();
        }

        [TestCase(new[] { "s", "i", "sh", "a", "rp" }, "a", ExpectedResult = new[] { "a", "i", "rp", "s", "sh" })]
        [TestCase(new[] { "zzz", "Z", "zz", "zzz", "kEk", "ZzZ" }, "zzz", ExpectedResult = new[] { "kEk", "Z", "zz", "zzz", "ZzZ" })]
        [TestCase(new[] { "", "", "d", "23" }, "a", ExpectedResult = new[] { "", "23", "d" })]
        [TestCase(new[] { "6, 4, 1, 1, 4" }, "6", ExpectedResult = new[] { "6, 4, 1, 1, 4" })]
        public IEnumerable<string> InorderTraversalStringsOfTree(string[] array, string a)
        {
            var tree = new BinaryTree<string>(array);
            return tree.Inorder();
        }

        [TestCase(new[] { "s", "i", "sh", "a", "rp" }, "a", ExpectedResult = new[] { "a", "rp", "i", "sh", "s" })]
        [TestCase(new[] { "zzz", "Z", "zz", "zzz", "kEk", "ZzZ" }, "zzz", ExpectedResult = new[] { "kEk", "zz", "Z", "ZzZ", "zzz" })]
        [TestCase(new[] { "", "", "d", "23" }, "a", ExpectedResult = new[] { "23", "d", "" })]
        [TestCase(new[] { "6, 4, 1, 1, 4" }, "6", ExpectedResult = new[] { "6, 4, 1, 1, 4" })]
        public IEnumerable<string> PostorderTraversalStringsOfTree(string[] array, string a)
        {
            var tree = new BinaryTree<string>(array);
            return tree.Postorder();
        }
        #endregion

#region book cases
        public static IEnumerable BookAddTest
        {
            get
            {
                Book.Logic.Book[] books = new Book.Logic.Book[3];
                books[0] = new Book.Logic.Book("123-4-56-123456-1", "ss", "qq", "ffff", 2, 5, 1m);
                books[1] = new Book.Logic.Book("123-4-56-123456-2", "sSSs", "qq2", "122ffff", 25, 5, 1m);
                books[2] = new Book.Logic.Book("123-4-56-123456-3", "SsSs3", "qq3", "f4fff", 1, 10, 1m);
                IBinaryTree<Book.Logic.Book> tree = new BinaryTree<Book.Logic.Book>(books);
                foreach(var book in books)
                {
                    yield return new TestCaseData(book, tree).Returns(1);
                    yield return new TestCaseData(book, tree).Returns(2);

                }

            }
        }

        [Test, TestCaseSource("BookAddTest")]
        public int BookAddTestTest(Book.Logic.Book book, IBinaryTree<Book.Logic.Book> tree)
        {
            var f = tree.Find(book);
            tree.Add(book);
            return f;
        }
        #endregion !book

#region point cases
        public static IEnumerable PointAddTest
        {
            get
            {
                IComparer<Point> comparer = Comparer<Point>.Create((p1, p2) =>
                {
                    return p1.x - p2.x;
                });

                IBinaryTree<Point> tree = new BinaryTree<Point>(comparer);
                int x = 0;
                int y = 0;
                for(int i = 0; i<3; i++)
                {
                    var point = new Point(x, y);
                    yield return new TestCaseData(point, tree).Returns(1);
                    yield return new TestCaseData(point, tree).Returns(2);
                    x++; y += 2;
                }
            }
        }

        [Test, TestCaseSource("PointAddTest")]
        public int PointAddTesttTest(Point point, IBinaryTree<Point> tree)
        {

            tree.Add(point);
            var f = tree.Find(point);
            return f;
        }
#endregion !point
    }
}
