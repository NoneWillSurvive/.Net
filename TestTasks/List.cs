using System;
using System.Runtime.Serialization;
using System.Text;

namespace Tasks {
        internal class ListException : System.Exception {
        public ListException() {
        }

        public ListException(string message) : base(message) {
        }

        public ListException(string message, System.Exception innerException) : base(message, innerException) {
        }

        protected ListException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }
    }
    
    public class List {
        private uint _len = 0;
        private ListNode _head = null;

        public List() {
        }

        public void InsertLast(int info) {
            if (_len == 0)
            {
                _head = new ListNode(info);
            }
            else
            {
                _head.InsertNode(_len -1, new ListNode(info));
            }

            _len++;
        }

        public void InsertInPlace(uint place, int info) {
            if (place > _len - 1)
            {
                throw new ListException(
                    $"Cant insert node. Number of node to insert is too big. Current size of list = {_len}");
            }
            _head.InsertNode(place, new ListNode(info));
            _len++;
        }

        public void PrintContent() {
            Console.Write(_head.Information + " ");
            var node = _head.Next();
            while (node != null)
            {
                Console.Write(node.Information + " ");
                node = node.Next();
            }
            Console.WriteLine();
        }

        public void DeleteLast() {
            _head.DeleteNode(_len - 1);
            _len--;
        }

        public void DeleteInPlace(uint place) {
            if (place > _len - 1)
            {
                throw new ListException(
                    $"Cant insert node. Number of node to delete is too big. Current size of list = {_len}");
            }
            if (place == 0)
                _head = _head.DeleteNode();
            else
            {
                _head.DeleteNode(place);
            }

            _len--;
        }

        public void ReverseList() {
            _head = _head.Reverse();
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            var node = _head;
            while (node != null)
            {
                sb.Append(node.Information);
                node = node.Next();
            }
            return sb.ToString();
        }
    }

    internal class ListNode {
        private ListNode _nextListNode;
        private ListNode _prevListNode;
        public int Information { get; }

        public ListNode(int information) {
            Information = information;
            _nextListNode = null;
            _prevListNode = null;
        }

        private void AddNode(ListNode nextListNode) {
            _nextListNode = nextListNode;
            nextListNode._prevListNode = this;
        }

        public ListNode Next() {
            return _nextListNode;
        }

        public void InsertNode(uint numberOfNode, ListNode listNodeToInsert) {
            var i = 0;
            var node = this;
            while (node != null && i < numberOfNode)
            {
                node = node.Next();
                i++;
            }
            var nextToInsertedNode = node._nextListNode;
            node.AddNode(listNodeToInsert);
            if (nextToInsertedNode != null)
                listNodeToInsert.AddNode(nextToInsertedNode);
        }


        public void DeleteNode(uint numberOfNode) {
            if (numberOfNode < 1)
            {
                throw new ListException("Number of node should be > 0");
            }

            var i = 1;
            var node = Next();
            while (node != null && i < numberOfNode)
            {
                node = node.Next();
                i++;
            }

            if (node == null)
            {
                throw new ListException(
                    $"Cant insert node. Number of node to insert is too big. Current size of list = {i}");
            }

            var nextToDeletedNode = node._nextListNode;
            var prevToDeletedNode = node._prevListNode;
            if (nextToDeletedNode != null)
            {
                prevToDeletedNode.AddNode(nextToDeletedNode);
            }
            else
            {
                prevToDeletedNode._nextListNode = null;
            }

            node._nextListNode = null;
            node._prevListNode = null;
        }

        public ListNode DeleteNode() {
            var toReturn = Next();
            _nextListNode = null;
            _prevListNode = null;
            return toReturn;
        }

        public ListNode Reverse() {
            ListNode current = this, prev = null;
            while (current != null) {
                var next = current._nextListNode;
                prev = current._prevListNode;
                current._nextListNode = prev;
                current._prevListNode = next;
                current = next;
            }
            return prev._prevListNode;
        }
    }
}