using NUnit.Framework;
using BinarySearchLogic;

namespace BinarySearchTests
{
    [TestFixture]
    public class TestClass
    {
        public static int TypeGet(int lhs, int rhs) 
        {
            return lhs > rhs ? 1 : -1;
        }

        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7 }, 4)]
        public void Test(int[] array, int req)
        {

            BinarySearch.Find(array, req, TypeGet);
            
        }


    }
}
