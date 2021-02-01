using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Task4.BLL.Scheduler
{
    public class SafeStack<T> : IProducerConsumerCollection<T>
    {
        private object m_lockObject = new object();

        private Stack<T> m_sequentialStack = null;

        public SafeStack()
        {
            m_sequentialStack = new Stack<T>();
        }

        public SafeStack(IEnumerable<T> collection)
        {
            m_sequentialStack = new Stack<T>(collection);
        }

        protected void Push(T item)
        {
            lock (m_lockObject)
            {
                m_sequentialStack.Push(item);
            }
        }

        protected bool TryPop(out T item)
        {
            bool rval = true;
            lock (m_lockObject)
            {
                if (m_sequentialStack.Count == 0)
                {
                    item = default(T);
                    rval = false;
                }
                else
                {
                    item = m_sequentialStack.Pop();
                }
            }
            return rval;
        }
        protected T[] Array()
        {
            T[] rval = null;
            lock (m_lockObject)
            {
                rval = m_sequentialStack.ToArray();
            }
            return rval;
        }
        protected void Copy(T[] array, int index)
        {
            lock (m_lockObject)
            {
                m_sequentialStack.CopyTo(array, index);
            }
        }
        public bool TryTake(out T item)
        {
            return TryPop(out item);
        }

        public bool TryAdd(T item)
        {
            Push(item);
            return true;
        }

        public T[] ToArray()
        {
            return Array();
        }

        public void CopyTo(T[] array, int index)
        {
            Copy(array, index);
        }

        public IEnumerator<T> GetEnumerator()
        {
            Stack<T> stackCopy = null;
            lock (m_lockObject)
            {
                stackCopy = new Stack<T>(m_sequentialStack);
            }
            return stackCopy.GetEnumerator();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        public bool IsSynchronized
        {
            get { return true; }
        }

        public object SyncRoot
        {
            get { return m_lockObject; }
        }

        public int Count
        {
            get { return m_sequentialStack.Count; }
        }

        public void CopyTo(Array array, int index)
        {
            lock (m_lockObject)
            {
                ((ICollection)m_sequentialStack).CopyTo(array, index);
            }
        }
    }
}
