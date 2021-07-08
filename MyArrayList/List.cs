
using System.Collections.Generic;

namespace CustomCollections
{
    interface IList<T> : IEnumerator<T>, IEnumerable<T>
    {
        int Size => Size;
        bool Empty => Empty;
        T Add(T obj);
        void AddAll(IList<T> objs);
        T Get(int index);
        T Remove(int index);
        T Remove(T obj);
        void Resize(int newSize);
        void Reserve(int capacity);
        int Capacity => Capacity;
    }
}
