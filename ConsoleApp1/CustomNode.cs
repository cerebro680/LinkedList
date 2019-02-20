using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListHW
{
    //Custom Node class that represents one node in a double linked list
    //Param "T" is the type of data the node will contain
    class CustomNode<T>
    {
        //Fields:
        private T data;
        private CustomNode<T> next;
        private CustomNode<T> prev;
        //Getter and setter methods
        public T Data
        {
           get { return data; }
           set { data = value; }
        }
        public CustomNode<T> Next
        {
            get { return next; }
            set { next = value; }
        }
        //Previous Node
        public CustomNode<T> Prev
        {
            get { return prev; }
            set { prev = value; }
        }
        public CustomNode (T data)
        {
            this.data = data;
            next = null;
        }
    }
}
