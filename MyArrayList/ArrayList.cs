using System;
using System.Collections;

namespace CustomCollections
{
    class ArrayList<T> : IList<T>
    {
        private T[] buffer;
        private int used;
        private int pointer;

        public T Current => buffer[pointer];

        object IEnumerator.Current => buffer[pointer];

        public ArrayList() => buffer = new T[32];

        public ArrayList(uint size) => buffer = new T[size];

        public T Add(T obj)
        {

            if (used == buffer.Length)
            {
                T[] swap = new T[Size];
                swap = buffer;

                buffer = new T[Size * 2];
                for (int i = 0; i < Size; ++i)
                {
                    buffer[i] = swap[i];
                }
            }

            buffer[used] = obj;
            ++used;

            return obj;
        }

        public void AddAll(IList<T> objs)
        {
            for (int i = 0; i < objs.Size; ++i)
            {
                Add(objs.Get(i));
            }
        }

        public T Get(int index)
        {
            if (index >= used)
            {
                throw new IndexOutOfRangeException($"Value {index} out of range");
            }

            return buffer[index];
        }

        public int Capacity => buffer.Length;

        public int Size => used;

        public bool Empty => used == 0;

        public void Reserve(int size)
        {
            buffer = new T[size];
            used = 0;
        }

        public void Resize(int capacity)
        {
            used = Math.Min(capacity, Size);

            T[] swap = buffer;

            buffer = new T[capacity];
            for (int i = 0; i < Size; ++i)
            {
                buffer[i] = swap[i];
            }
        }

        public T Remove(int index)
        {
            T obj = buffer[index];
            for (int i = index; i <= Size - index; ++i)
            {
                buffer[i] = buffer[i + 1];
            }

            --used;
            return obj;
        }

        public T Remove(T obj)
        {
            for (int i = 0; i <= Size; ++i)
            {
                if(obj.Equals(buffer[i]))
                {
                    return Remove(i);
                }
            }

            throw new ArgumentException("Object not found in array");
        }

        public bool MoveNext()
        {
            if (pointer < Size - 1)
            {
                ++pointer;
                return true;
            }

            return false;
        }

        public void Reset() => pointer = 0;

        public void Dispose() { }

        public System.Collections.Generic.IEnumerator<T> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => this;
    }
}
