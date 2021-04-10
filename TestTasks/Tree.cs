using System;
using System.Runtime.Serialization;

namespace Tasks {
    public class Tree {
        private Node _root;

        public void Add(int info) {
            if (_root != null)
            {
                _root.AddNode(new Node(info));
            }
            else
            {
                _root = new Node(info);
            }
        }

        private Node Search(int info) {
            try
            {
                var res = _root.Search(info);
                return res;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("You need add at least 1 node");
                throw;
            }
        }

        public void Delete(int info) {
            var node = _root.Search(info);
            node.DeleteNode();
        }

        public void PrintTree() {
            Console.WriteLine("------------------------------------");
            _root.PrintInfo();
            Console.WriteLine("------------------------------------");
        }
    }

    internal class Exception : System.Exception {
        public Exception() {
        }

        public Exception(string message) : base(message) {
        }

        public Exception(string message, System.Exception innerException) : base(message, innerException) {
        }

        protected Exception(SerializationInfo info, StreamingContext context) : base(info, context) {
        }
    }

    internal class Node {
        private Node _leftNode;
        private Node _rightNode;
        private Node _parent;
        public int Info { get; set; }

        public Node(int info) {
            Info = info;
        }

        public void AddNode(Node node) {
            if (node.Info < Info)
            {
                CheckInternalNode(ref _leftNode, node);
            }
            else if (node.Info > Info)
            {
                CheckInternalNode(ref _rightNode, node);
            }
        }

        public Node Search(int info) {
            if (Info == info)
                return this;
            var node = info > Info ? _rightNode.Search(info) : _leftNode.Search(info);
            if (node == null)
                throw new Exception("There is no node with that value");
            return node;
        }

        

        public void DeleteNode() {
            if (_leftNode == null && _rightNode == null)
            {
                ReplaceParentNode(null);
            }
            else if (_leftNode != null ^ _rightNode != null)
            {
                ReplaceParentNode(_leftNode ?? _rightNode);
            }
            else
            {
                var node = _rightNode.FindMin();
                Info = node.Info;
                node.DeleteNode();
            }
        }
        public override string ToString() { return $"I:{Info}|P:{_parent?.Info}|LC:{_leftNode?.Info}|RC:{_rightNode?.Info}|";
        }

        public void PrintInfo() {
            Console.WriteLine(ToString());
            _leftNode?.PrintInfo();
            _rightNode?.PrintInfo();
        }
        private void CheckInternalNode(ref Node internalNode, Node nodeToAdd) {
            if (internalNode == null)
            {
                nodeToAdd._parent = this;
                internalNode = nodeToAdd;
            }
            else
            {
                internalNode.AddNode(nodeToAdd);
            }
        }
        private void ReplaceParentNode(in Node newNode) {
            if (newNode != null)
                newNode._parent = _parent;
            if (_parent == null) return;
            if (_parent._leftNode == this)
                _parent._leftNode = newNode;
            else
                _parent._rightNode = newNode;
        }

        private Node FindMin() {
            var node = this;
            while (node._leftNode != null)
            {
                node = node._leftNode;
            }

            return node;
        }

        
    }
}