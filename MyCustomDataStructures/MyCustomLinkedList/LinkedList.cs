namespace MyCustomLinkedList
{
    using System.Collections.Generic;
    using Node;

    /// <summary>
    /// Represents a doubly linked list.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedList<T>
    {
        /// <summary>
        /// Returns the current node.
        /// </summary>
        private Node<T> _currentNode;

        /// <summary>
        /// Initializes the list. 
        /// </summary>
        public LinkedList()
        {
            this.HeadNode = null;
            this.LastNode = null;
        }

        /// <summary>
        /// Returns the first node of the list.
        /// </summary>
        public Node<T> HeadNode { get; set; }

        /// <summary>
        /// Returns the last node of the list.
        /// </summary>
        public Node<T> LastNode { get; set; }

        /// <summary>
        /// Returns true if a node has been removed from the list.
        /// </summary>
        public bool IsNodeRemoved { get; set; }

        /// <summary>
        /// Adds new node in the beginning of the list.
        /// </summary>
        /// <param name="data"></param>
        public void AddFirst(T data)
        {
            if (this.HeadNode == null)
            {
                this.HeadNode = new Node<T>(data);
            }
            else
            {
                var newNode = new Node<T>(data)
                {
                    Next = HeadNode,
                    Previous = null
                };

                this.HeadNode.Previous = newNode;
                this.HeadNode = newNode;
            }
        }

        /// <summary>
        /// Adds new node in the end of the list.
        /// </summary>
        /// <param name="data"></param>
        public void AddNext(T data)
        {
            if (this.HeadNode == null)
            {
                this.HeadNode = new Node<T>(data);
                this.LastNode = this.HeadNode;
                this._currentNode = this.LastNode;
            }
            else
            {
                this.HeadNode.AddNext(data);
                this._currentNode = this._currentNode.Next;
                this.LastNode = _currentNode;
            }
        }

        /// <summary>
        /// Adds new node before a specified node to the list.
        /// </summary>
        /// <param name="nodeData"></param>
        /// <param name="newData"></param>
        public void AddBefore(T nodeData, T newData)
        {
            var node = this.GetNode(nodeData);

            if (node != null)
            {
                var newNode = new Node<T>(newData)
                {
                    Next = node,
                    Previous = node.Previous
                };

                if (node == HeadNode)
                {
                    this.AddFirst(newData);

                    return;
                }

                node.Previous = newNode;

                if (newNode.Previous != null)
                {
                    newNode.Previous.Next = newNode;
                }
            }
        }

        /// <summary>
        /// Adds new node after a specified node tp the list.
        /// </summary>
        /// <param name="nodeData"></param>
        /// <param name="newData"></param>
        public void AddAfter(T nodeData, T newData)
        {
            var node = this.GetNode(nodeData);

            if (node != null)
            {
                var newNode = new Node<T>(newData)
                {
                    Next = node.Next,
                    Previous = node
                };

                node.Next = newNode;

                if (newNode.Next != null)
                {
                    newNode.Next.Previous = newNode;
                }
                else
                {
                    this.LastNode = newNode;
                    this._currentNode = this.LastNode;
                }
            }
        }

        /// <summary>
        /// Changes node's data with a specified value.
        /// </summary>
        /// <param name="nodeData"></param>
        /// <param name="newData"></param>
        public void ChangeNodeData(T nodeData, T newData)
        {
            var node = this.GetNode(nodeData);

            if (node != null)
            {
                node.OldData = node.Data;
                node.Data = newData;
            }
        }

        /// <summary>
        /// Changes all node's data with a specified value.
        /// </summary>
        /// <param name="data"></param>
        public void ChangeAllNodesWithData(T data)
        {
            var currentNode = this.HeadNode;

            while (currentNode != null)
            {
                currentNode.OldData = currentNode.Data;
                currentNode.Data = data;
                currentNode = currentNode.Next;
            }
        }

        /// <summary>
        /// Sets all nodes data to the last saved values.
        /// </summary>
        public void ReturnAllNodesOldData()
        {
            var currentNode = this.HeadNode;

            while (currentNode != null)
            {
                currentNode.Data = currentNode.OldData;
                currentNode = currentNode.Next;
            }
        }

        /// <summary>
        /// Removes a specified node from the list.
        /// </summary>
        /// <param name="nodeData"></param>
        public void RemoveNode(T nodeData)
        {
            var node = this.GetNode(nodeData);

            if (node != null)
            {
                node.Previous.Next = node.Next;
                node.Next.Previous = node.Previous;

                this.IsNodeRemoved = true;
            }
        }

        /// <summary>
        /// Removes the first node of the list.
        /// </summary>
        public void RemoveFirst()
        {
            if (this.HeadNode != null)
            {
                this.HeadNode = this.HeadNode.Next;
                this.HeadNode.Previous = null;

                this.IsNodeRemoved = true;
            }
        }

        /// <summary>
        /// Removes the last node of the list.
        /// </summary>
        public void RemoveLast()
        {
            if (this.LastNode != null)
            {
                this.LastNode = this.LastNode.Previous;
                this.LastNode.Next = null;

                this.IsNodeRemoved = true;
            }
        }

        /// <summary>
        /// Clears all nodes from the list.
        /// </summary>
        public void Clear()
        {
            this.HeadNode = null;
            this.LastNode = null;
            this._currentNode = null;
        }

        /// <summary>
        /// Returns a specified node from the list.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Node<T> GetNode(T data)
        {
            var currentNode = this.HeadNode;

            while (currentNode != null)
            {
                if (currentNode.Data.Equals(data))
                {
                    return currentNode;
                }

                currentNode = currentNode.Next;
            }

            return null;
        }

        /// <summary>
        /// Checks if a node exists in the list.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool NodeExists(T data)
        {
            return this.GetNode(data) != null;
        }

        /// <summary>
        /// Returns the nodes count in the list.
        /// </summary>
        /// <returns></returns>
        public int GetNodesCount()
        {
            return this.GetAllNodes().Count;
        }

        /// <summary>
        /// Returns all nodes with a specified value from the list.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<Node<T>> GetAllNodesWithData(T data)
        {
            var nodes = new List<Node<T>>();
            var currentNode = this.HeadNode;

            while (currentNode != null)
            {
                if (currentNode.Data.Equals(data))
                {
                    nodes.Add(currentNode);
                }

                currentNode = currentNode.Next;
            }

            return nodes;
        }

        /// <summary>
        /// Returns all nodes from the list.
        /// </summary>
        /// <returns></returns>
        public List<Node<T>> GetAllNodes()
        {
            var nodes = new List<Node<T>>();
            var currentNode = this.HeadNode;

            while (currentNode != null)
            {
                nodes.Add(currentNode);
                currentNode = currentNode.Next;
            }

            return nodes;
        }
    }
}
