using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace QueueLogic.Tests
{
    [TestFixture]
    public class QueueTest
    {
        public static IEnumerable IntEnqueueQueue
        {
            get
            {
                var qeueInt = new List<int> { 9, 8, 7, 6 };
                yield return new TestCaseData(qeueInt, 5).Returns(new List<int> { 9, 8, 7, 6, 5 });
                yield return new TestCaseData(qeueInt, 0).Returns(new List<int> { 9, 8, 7, 6, 0 });
            }
        }

        public static IEnumerable IntDequeueQueue
        {
            get
            {
                var intQueue = new Queue<int>(new List<int> { 9, 8, 7, 6 });
                yield return new TestCaseData(intQueue).Returns(9);
                yield return new TestCaseData(intQueue).Returns(8);
                yield return new TestCaseData(intQueue).Returns(7);
            }
        }

        public static IEnumerable IntPeekQueue
        {
            get
            {
                var qeueInt = new Queue<int>(new List<int> { 9, 8, 7, 6 });
                yield return new TestCaseData(qeueInt).Returns(9);
                yield return new TestCaseData(qeueInt).Returns(9);
                yield return new TestCaseData(qeueInt).Returns(9);
            }
        }

        public static IEnumerable IntClearQueue
        {
            get
            {
                var qeueInt = new List<int> { 9, 8, 7, 6 };
                yield return new TestCaseData(qeueInt).Returns(true);
            }
        }

        public static IEnumerable IntMoveNextQueue
        {
            get
            {
                var qeueInt = new Queue<int>(new List<int> { 9, 8, 7, 6 });
                yield return new TestCaseData(qeueInt).Returns(true);
                yield return new TestCaseData(qeueInt).Returns(true);
                yield return new TestCaseData(qeueInt).Returns(true);
                yield return new TestCaseData(qeueInt).Returns(true);
                yield return new TestCaseData(qeueInt).Returns(false);
            }
        }
        
        public static IEnumerable IntMovePrevQueue
        {
            get
            {
                var qeueInt = new Queue<int>(new List<int> { 9, 8, 7, 6 });
                qeueInt.MoveNext();
                qeueInt.MoveNext();
                yield return new TestCaseData(qeueInt).Returns(true);
                yield return new TestCaseData(qeueInt).Returns(true);
                yield return new TestCaseData(qeueInt).Returns(false);
            }
        }

        [Test, TestCaseSource("IntEnqueueQueue")]
        public List<int> IntEnqueueQueueTest(List<int> qeue, int element)
        {
            var intQueue = new Queue<int>(qeue);
            var queueReturn = intQueue.Enqueue(element);
            List<int> list = new List<int>();
            while (!queueReturn.IsEmpty())
            {
                list.Add(queueReturn.Dequeue());
            }

            return list;
        }

        [Test, TestCaseSource("IntDequeueQueue")]
        public int IntDequeueQueueTest(IQueue<int> qeue)
        {
            return qeue.Dequeue();
        }

        [Test, TestCaseSource("IntPeekQueue")]
        public int IntPeekQueueTest(IQueue<int> qeue)
        {
            return qeue.Peek();
        }

        [Test, TestCaseSource("IntClearQueue")]
        public bool IntClearQueueTest(List<int> qeue)
        {
            var intClear = new Queue<int>(qeue);
            intClear.Clear();
            return intClear.IsEmpty();
        }

        [Test, TestCaseSource("IntMoveNextQueue")]
        public bool IntMoveNextQueueTest(IIterator<int> qeue)
        {
            return qeue.MoveNext();
        }

        [Test, TestCaseSource("IntMovePrevQueue")]
        public bool IntMovePrevQueueTest(IIterator<int> qeue)
        {
            return qeue.MovePrev();
        }
    }
}