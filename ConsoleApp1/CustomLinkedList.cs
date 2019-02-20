using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListHW
    //Node based Linkedlist
    //T is type of data that the list will hold.
{
    class CustomLinkedList<T>
    {
        //Fields:
        private CustomNode<T> head;
        private CustomNode<T> tail;
        private int count;
        //Get the count of items in the list
        public int Count { get { return count; } }

        //Adds a new node object to the list
        //param name "data"
        public void add(T data)
        {     
            CustomNode<T> node = new CustomNode<T>(data);
            if (count == 0)
            {
                head = node;
                tail = node;
            }
            else if(count==1)
            {
                head.Next = node;
                tail = node;
                tail.Prev = head;
            }
            else
            {
                node.Prev = tail;// current tail
                tail.Next = node; 

                tail = node; // new tail
            }
            count++;
        }
        //inserts a new node to the list
        //Param name "date, the data to insert, and "index", the location of the data
        public void Insert(T data, int index)
        {
            if (head == null)
            {
                add(data);
                return;
            }
            else if (index < 0)
            {
                throw new IndexOutOfRangeException(" Invalid");
            }
            else if (index >= count)
            {
                add(data);
                return;
            }
            
            CustomNode<T> previous = head;
            CustomNode<T> current = head;
            int position = 0;
            while (position < count)
            {
                if (position == index)
                {
                    CustomNode<T> newNode = new CustomNode<T>(data);
                    if (position == 0)
                    {
                        newNode.Next = head;
                        head.Prev = newNode;
                        head = newNode;
                    }
                    else
                    {
                        newNode.Next = current;
                        previous.Next = newNode;
                        newNode.Prev = current.Prev;
                        current.Prev = newNode;
                        count++;
                        position = count;
                    }
                }
                position++;
                previous = current;
                current = current.Next;
            }
            
        }
        //Removing elements from the list and returning its data
        //Param name "index" , the location of the index to remove from
        public T RemoveAt(int index) 
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Index was invalid");
            }
            else if (index == 0)
            {
                CustomNode<T> temp = head;
                head = head.Next;
                count--;
                return temp.Data;               
            }
            //if index is the last data in the list
            else if (index == count-1)
            {
                CustomNode<T> temp = tail;
                tail = tail.Prev;
                tail.Next = null;
                count--;
                return temp.Data;
            }
            //if the index points to a node in the middle of the list
            else
            {
                T tempdata = GetData(index);
                CustomNode<T> current = head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                current.Next.Prev = current.Prev;
                current.Prev.Next = current.Next;
                count--;
                return tempdata;
            }
        }
    //Prints the current list in reversed order
   public   void PrintReversed()
        {
            CustomNode<T> current = tail;
            for (int i = count; i > 0; i--)
            {
                Console.WriteLine(current.Data);
                current = current.Prev;        
            }       
        }
    //Clears the entire list
   public  void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
    //Returns the data value from the node at the index specified
   public T GetData(int index)
    {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Invalid");
            }
            // Loop through the nodes until we get 
            // to the node at index
            CustomNode<T> current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            // Return the data of the current node
            return current.Data;
        }
    }
}
