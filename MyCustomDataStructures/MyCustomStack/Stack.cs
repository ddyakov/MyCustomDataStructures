namespace MyCustomStack
{
    using System;

    /// <summary>
    /// Represents a LIFO collection of elements.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Stack<T>
    {
        /// <summary>
        /// Returns the elements of the stack.
        /// </summary>
        private T[] _elements;
        /// <summary>
        /// Sets the default value for the stack capacity.
        /// </summary>
        private int _defaultCapacity = 4;
        /// <summary>
        /// Returns the size of the stack.
        /// </summary>
        private int _size;

        /// <summary>
        /// Initialize the stack with default capacity.
        /// </summary>
        public Stack()
        {
            this._size = 0;
            this._elements = new T[0];
        }

        /// <summary>
        /// Initialize the stack with initial capacity.
        /// </summary>
        /// <param name="capacity"></param>
        public Stack(int capacity)
        {
            if (capacity < 0)
            {
                throw new IndexOutOfRangeException("Invalid value!");
            }

            this._size = 0;
            this._elements = new T[capacity];
        }

        /// <summary>
        /// Returns the count of elements in the stack.
        /// </summary>
        public int Count => this._size;

        /// <summary>
        /// Adds value to the stack.
        /// </summary>
        /// <param name="value"></param>
        public void Push(T value)
        {
            if (this._size == this._elements.Length)
            {
                var newArray = new T[this._elements.Length == 0 ? this._defaultCapacity : 2 * this._elements.Length];
                Array.Copy(this._elements, 0, newArray, 0, this._size);
                this._elements = newArray;
            }

            this._elements[this._size++] = value;
        }

        /// <summary>
        /// Returns the top most element and takes it out of the stack.
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (this._size == 0)
            {
                throw new InvalidOperationException("Empty stack!");
            }

            T item = this._elements[--this._size];
            this._elements[this._size] = default(T);

            return item;
        }

        /// <summary>
        /// Returns the top most element of the stack.
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (this._size == 0)
            {
                throw new InvalidOperationException("Empty stack!");
            }

            return this._elements[this._size - 1];
        }

        /// <summary>
        /// Clears all elements from the stack.
        /// </summary>
        public void Clear()
        {
            if (this._size == 0)
            {
                throw new InvalidOperationException("Empty stack!");
            }

            while (this._size != 0)
            {
                this._elements[--this._size] = default(T);
            }
        }
    }
}
