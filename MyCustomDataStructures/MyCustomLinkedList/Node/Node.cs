namespace MyCustomLinkedList.Node
{
    /// <summary>
    /// Represents a node in a linked list.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T>
    {
        /// <summary>
        /// Initializes the node.
        /// </summary>
        /// <param name="data"></param>
        public Node(T data)
        {
            this.Data = data;
            this.Next = null;
            this.Previous = null;
        }

        /// <summary>
        /// Returns the next node.
        /// </summary>
        public Node<T> Next { get; set; }

        /// <summary>
        /// Returns the previous node.
        /// </summary>
        public Node<T> Previous { get; set; }

        /// <summary>
        /// Returns the data of the node.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Returns the old data of the node.
        /// </summary>
        public T OldData { get; set; }

        /// <summary>
        /// Adds next node.
        /// </summary>
        /// <param name="data"></param>
        public void AddNext(T data)
        {
            if (this.Next == null)
            {
                this.Next = new Node<T>(data)
                {
                    Previous = this
                };
            }
            else
            {
                this.Next.Previous = this;
                this.Next.AddNext(data);
            }
        }
    }
}
