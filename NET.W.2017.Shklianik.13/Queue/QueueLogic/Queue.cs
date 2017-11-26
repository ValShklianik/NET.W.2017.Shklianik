using System;
using System.Collections.Generic;

namespace QueueLogic
{
    public interface IQueue<T>
    {
        bool IsEmpty();

        IQueue<T> Enqueue(T element);

        T Dequeue();

        T Peek();
        
        void Clear();
    }

    public interface IIterator<T>
    {
        bool MoveNext();

        bool MovePrev();

        void Reset();

        T GetCurrent();
    }

    public class Queue<T> : IQueue<T>, IIterator<T>
    {
        private readonly List<T> queue;
        private int currentIndex;

        public Queue()
        {
            queue = new List<T>();
        }

        public Queue(List<T> queue) : this()
        {
            foreach (var q in queue)
            {
                this.queue.Add(q);
            }

            currentIndex = -1;
        }

        public bool IsEmpty()
        {
            return queue.Count == 0;
        }
        
        public IQueue<T> Enqueue(T element)
        {
            if (element == null) throw new ArgumentNullException(nameof(element));
            queue.Add(element);
            return this;
        }

        public T Dequeue()
        {
            T firstEl = queue[0];
            queue.Remove(queue[0]);
            return firstEl;
        }

        public T Peek()
        {
            return queue[0];
        }

        public void Clear()
        {
            queue.Clear();
        }

        public bool MoveNext()
        {
            if (currentIndex < queue.Count)
            {
                currentIndex++;
                return currentIndex < queue.Count;
            }

            return false;
        }

        public bool MovePrev()
        {
            currentIndex--;
            return currentIndex >= -1;
        }

        public void Reset()
        {
            currentIndex = -1;
        }

        public T GetCurrent()
        {
            return queue[currentIndex];
        }
    }
}   
