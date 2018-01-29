namespace MyCustomQueue
{
    using System;

    /// <summary>
    /// Represents a FIFO collection of elements.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Queue<T>
    {
        /// <summary>
        /// Returns the elements of the queue.
        /// </summary>
        private T[] _elements;
        /// <summary>
        /// Returns the size of the queue.
        /// </summary>
        private int _size;
        /// <summary>
        /// Returns the bottom most element in the queue.
        /// </summary>
        private int _tail;
        /// <summary>
        /// Returns the top most element in the queue.
        /// </summary>
        private int _head;
        /// <summary>
        /// Returns the mininum capacity for the queue.
        /// </summary>
        private const int MinimumCapacity = 4;
        /// <summary>
        /// Returns the double capacity for the queue.
        /// </summary>
        private const int DoubleCapacity = 200;

        /// <summary>
        /// Initialize the queue with default capacity.
        /// </summary>
        public Queue()
        {
            this._size = 0;
            this._elements = new T[0];
        }

        /// <summary>
        /// Initialize the queue with initial capacity.
        /// </summary>
        /// <param name="capacity"></param>
        public Queue(int capacity)
        {
            if (capacity < 0)
            {
                throw new IndexOutOfRangeException("Invalid value!");
            }

            this._size = 0;
            this._head = 0;
            this._tail = 0;
            this._elements = new T[capacity];
        }

        /// <summary>
        /// Returns the count of elements in the queue.
        /// </summary>
        public int Count => this._size;

        /// <summary>
        /// Adds value to the tail of the queue.
        /// </summary>
        /// <param name="value"></param>
        public void Enqueue(T value)
        {
            if (this._size == this._elements.Length)
            {
                int newCapacity = (int)((long)this._elements.Length * (long)DoubleCapacity / 100);

                if (newCapacity < this._elements.Length + MinimumCapacity)
                {
                    newCapacity = this._elements.Length + MinimumCapacity;
                }

                T[] newArray = new T[newCapacity];

                if (this._size > 0)
                {
                    Array.Copy(this._elements, this._head, newArray, 0, this._elements.Length - this._head);
                }

                this._elements = newArray;
                this._head = 0;
                this._tail = (this._size == newCapacity) ? 0 : this._size;
            }

            this._elements[this._tail] = value;
            this._tail = (this._tail + 1) % this._elements.Length;
            this._size++;
        }

        /// <summary>
        /// Returns the top most element and takes it out of the queue.
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            if (this._size == 0)
            {
                throw new InvalidOperationException("Empty queue!");
            }

            var elementToReturn = this._elements[this._head];
            var newArray = new T[this._elements.Length - 1];
            Array.Copy(this._elements, 1, newArray, 0, --this._size);
            this._elements = newArray;

            return elementToReturn;
        }

        /// <summary>
        /// Returns the top most element of the queue.
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (this._size == 0)
            {
                throw new InvalidOperationException("Empty queue!");
            }

            return this._elements[this._head];
        }

        /// <summary>
        /// Clears all elements from the queue.
        /// </summary>
        public void Clear()
        {
            Array.Clear(this._elements, this._head, this._size);

            this._size = 0;
            this._head = 0;
            this._tail = 0;
        }
    }
}
