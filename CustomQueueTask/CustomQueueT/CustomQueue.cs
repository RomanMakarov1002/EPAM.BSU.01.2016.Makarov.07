using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomQueueT
{
    public class CustomQueue<T> :IEnumerable<T>
    {
        private int _capacity;
        private int _count;
        private int _head;
        private int _tail;
        private T[] _repository;
        private CustomIterator _iterator;

        public CustomQueue(int capacity)
        {
            if (capacity<0)
                throw new ArgumentOutOfRangeException((nameof(capacity)),"Queue's capacity must be positive");
            _repository = new T[capacity];
            _count = 0;
            _head = 0;
            _tail = -1;
            _capacity = capacity;
            _iterator = this.Iterator();
        }

        public CustomQueue() : this(1)
        {
            
        }

        public CustomQueue(IEnumerable<T> collection)
        {
            if (collection==null)
                throw new ArgumentNullException(nameof(collection));
            _repository = new T[collection.ToArray().Length];
            Array.Copy(collection.ToArray(),_repository,_repository.Length);
            _head = 0;
            _tail = _repository.Length-1;
            _capacity = _repository.Length;
            _count = _repository.Length;
            _iterator = this.Iterator();
        }

        public void Enqueue(T item)
        {
            if (_count==Capacity)
                IncreaseQueue(Capacity*2);
            if (++_tail == Capacity)
                _tail = 0;
            _repository[_tail] = item;
            _count++;

        }

        public T Dequeue()
        {
            if (_count == 0)
                throw new InvalidOperationException("This queue is empty");
            int res = _head;
            if (++_head == Capacity)
                _head = 0;
            _count--;
            return _repository[res];

        }

        public T Peek()
        {
            if (_count==0)
                throw new InvalidOperationException("This queue is empty");
            return _repository[_head];
        }

        public int Count => _count;
        public int Capacity => _repository.Length;

        public T this[int index] => _repository[index];

        public CustomIterator Iterator()
        {
            return new CustomIterator(this);
        }

        public struct CustomIterator
        {
            private readonly CustomQueue<T> _customQueue;
            private int _current;

            public CustomIterator(CustomQueue<T> queue)
            {
                _customQueue = queue;
                _current = -1;
            }

            public T Current
            {
                get
                {
                    if (_current == -1 || _current >= _customQueue.Count)
                        throw new IndexOutOfRangeException();
                    return _customQueue[_current];
                }
            }

            public bool MoveNext()
            {
                return ++_current < _customQueue.Count;
            }

            public void Reset()
            {
                _current = -1;
            }
        }

        private void IncreaseQueue(int capacity)
        {
            T[] increased = new T[capacity];
            if (Count>0)
                if (_head<_tail)
                    Array.Copy(_repository,_head,increased,0,Count);
                else
                {
                    Array.Copy(_repository,_head, increased,0,Capacity-_tail);
                    Array.Copy(_repository,0,increased,Capacity-_head,_tail);
                }
            
            _repository = increased;
            _head = 0;
            _tail = Count-1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            while (_iterator.MoveNext())
            {
                yield return _iterator.Current;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
