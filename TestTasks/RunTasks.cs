using System;
using System.Runtime.Serialization;

namespace Tasks {
    internal class Program {
        public static void Main(string[] args) {
            TestBinaryTree();
            // TestList();
            // TestInsertionSort();
        }

        public static void TestList() {
            var list = new List();
            list.InsertLast(5);
            list.InsertLast(7);
            list.InsertLast(9);
            list.InsertLast(9);
            list.InsertLast(9);
            list.InsertLast(9);
            list.PrintContent();
            list.InsertInPlace(0, 8);
            list.InsertInPlace(1, 8);
            list.PrintContent();
            list.DeleteInPlace(1);
            list.DeleteInPlace(1);
            list.PrintContent();
            list.DeleteLast();
            list.PrintContent();
            list.ReverseList();
            list.PrintContent();
        }

        public static void TestBinaryTree() {
            var tree = new Tree();
            tree.Add(5);
            tree.Add(1);
            tree.Add(3);
            tree.Add(13);
            tree.Add(4);
            tree.Add(12);
            tree.Add(10);
            tree.Add(11);
            tree.Add(7);
            tree.Add(6);
            tree.Add(8);
            tree.PrintTree();
            tree.Delete(10);
            tree.Delete(8);
            tree.PrintTree();
            tree.Delete(5);
            tree.PrintTree();
            tree.Delete(11);
            tree.Delete(4);
            tree.Delete(6);
            tree.Delete(12);
            tree.Delete(13);
            tree.Delete(3);
            tree.PrintTree();
        }

        public static void TestInsertionSort() {
            var rand = new Random();
            var arr = new int[40];
            for (var i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(-100, 100);
            }
            
            Console.WriteLine("Before sort: ");
            foreach (var i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            
            Sort.InsertionSort(arr);
            
            Console.WriteLine("After sort: ");
            foreach (var i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}