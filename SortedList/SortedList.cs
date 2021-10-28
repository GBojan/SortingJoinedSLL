using System;
namespace SortedList
{
    #region Node basics
    /// <summary>
    /// Class definition of Node for singly linked list
    /// </summary>
    public class SLLNode
    {
        public int data;
        internal SLLNode next;
        public SLLNode(int data)
        {
            this.data = data;
        }
    }
    /// <summary>
    /// Class definition of a Single linked list
    /// </summary>
    public class SingleLinkedList
    {
        public SLLNode head;
        public SingleLinkedList()
        {
            //creating empty list
            this.head = null;
        }
        // We override ToString for readability of the list
        public string ToString()
        {
            string listString = string.Empty;
            string connectingSymbol = " -> ";
            SLLNode current = head;
            while (current != null)
            {
                listString += connectingSymbol + current.data;
                current = current.next;
            }
            return '{' + listString.Remove(listString.IndexOf(connectingSymbol), connectingSymbol.Length) + '}';
        }
        /// <summary>
        /// Insert first node
        /// </summary>
        /// <param name="singlyLinkedList">The SLL to modify</param>
        /// <param name="data">The data for the new node</param>
        public void InsertFirst(int data)
        {
            SLLNode node = new SLLNode(data);
            node.next = this.head;
            this.head = node;
        }
        /// <summary>
        /// Insert last node
        /// </summary>
        /// <param name="singlyLinkedList">The SLL to modify</param>
        /// <param name="data">The data for the new node</param>
        public void InsertLast(int data)
        {
            SLLNode node = new SLLNode(data);
            if (this.head == null)
            {
                this.head = node;
                return;
            }
            SLLNode lastNode = GetLastNode();
            lastNode.next = node;
        }
        /// <summary>
        /// Get the last node from a SLL
        /// </summary>
        /// <param name="singlyLinkedList">singlyLinkedList</param>
        /// <returns></returns>
        internal SLLNode GetLastNode()
        {
            SLLNode temp = this.head;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            return temp;
        }
    }
    #endregion
    public class SortedList
    {
        public static SingleLinkedList SortedJoin(SingleLinkedList list1, SingleLinkedList list2)
        {
            SingleLinkedList result = new SingleLinkedList();

            SLLNode node1 = list1.head;
            SLLNode node2 = list2.head;

            while (node1 != null && node2 != null)
            {
                if (node1.data.CompareTo(node2.data) < 0)
                {
                    result.InsertLast(node1.data); node1 = node1.next;
                }
                else
                {
                    result.InsertLast(node2.data); node2 = node2.next;
                }
            }
            if (node1 != null)
            {
                while (node1 != null)
                {
                    result.InsertLast(node1.data); node1 = node1.next;
                }
            }
            if (node2 != null)
            {
                while (node2 != null)
                {
                    result.InsertLast(node2.data); node2 = node2.next;
                }
            }

            return result;
        }

        /// <summary>
        /// Populates the list with custom values from the command line
        /// </summary>
        /// <param name="list">The list you want to populate</param>
        static void PopulateList(SingleLinkedList list)
        {
            Console.WriteLine("Please enter Int32 data to fill the list. To finish populating the list, enter the keyword 'stop'");
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("stop", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                //Lets asume we are entering numbers so it won't throw a parsing exception
                list.InsertLast(Int32.Parse(input));
            }
        }
        static void Main(string[] args)
        {
            // Declaring the lists
            SingleLinkedList firstList = new();
            SingleLinkedList secondList = new();

            // Populating the lists with custom values
            PopulateList(firstList);
            PopulateList(secondList);

            // Doing the sorted join
            var result = SortedJoin(firstList, secondList);

            // Printing the result
            Console.WriteLine("The result is: ");
            Console.WriteLine(result.ToString());

            // Just so the console won't close at the end, to see the result.
            Console.ReadLine();
        }
    }
}
