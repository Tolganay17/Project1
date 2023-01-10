using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Project1.task9_homework
{
    public class GenenricClass<T> where T : Human
    {
        private T[] _myArray;
        private int _size = 0;
        private int _capacity;
        private int _count = 0;

        public GenenricClass(int initialCapacity = 8)
        {
            if (initialCapacity < 1) initialCapacity = 1;
            this._capacity = initialCapacity;
            _myArray = new T[initialCapacity];
        }
        private void ThrowIfIndexOutOfRange(int index)
        {
            if (index > _size - 1 || index < 0)
            {
                throw new ArgumentOutOfRangeException(string.Format($"The current size of the array is {_size}"));
            }
        }
        public int Size => _size;
        public bool IsEmpty => _size == 0;

        private void Resize()
        {
            T[] resized = new T[_capacity * 2];
            for (int i = 0; i < _capacity; i++)
            {
                resized[i] = _myArray[i];
            }
            _myArray = resized;
            _capacity = _capacity * 2;
        }

        public void Add(T newElement)
        {
            if (_size == _capacity)
            {
                Resize();
            }
            _myArray[_size] = newElement;
            _size++;
        }

        public void DeleteAt(int index)
        {
            ThrowIfIndexOutOfRange(index);
            for (int i = index; i < _size - 1; i++)
            {
                _myArray[i] = _myArray[i + 1];
            }
            _myArray[_size - 1] = default(T);
            _size--;
        }
        public T GetAt(int index)
        {
            ThrowIfIndexOutOfRange(index);
            return _myArray[index];
        }

        public void toStringGen()
        {

            for (int i = 0; i < _size; i++)
            {
                var text = _myArray[i] is Man ? "There are only man" : "There are only woman";
                Console.WriteLine(_myArray[i].ToString());

                if (_count == _size - 1)
                {
                    Console.WriteLine($"{text}\n");
                }
                _count++;
            }
        }
    }
}