using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListHW
{
    //Takes in user input and adds them to the list.
    //Reads in specific commands and executes them. The commands are q/quit, print, count, clear , remove, reverse, scramble
    
    class Program
    {
        static void Main(string[] args)
        {        
            //Creates Custom Linked List
            CustomLinkedList<string> words = new CustomLinkedList<string>();
            Console.WriteLine("Type Something:");
            String input ;
            //Looks for a specific sets of commands and executes the right function from the LinkedList class.
            while (true)
            {        
                input = Console.ReadLine();
                if (input == "quit" || input== "q" )
                {
                    Console.WriteLine("The loop has ended");
                    return;                   
                }
               else if (input == "print")
                {
                    Console.WriteLine(" The following items are in the list");
                    for (int i=0; i < words.Count; i++)
                    {                       
                    Console.WriteLine(words.GetData(i));
                    }
                }
              else  if (input == "count" )
                {
                    Console.WriteLine(" There are currently " + words.Count + " items in the list");
                }
              else   if (input == "clear")
                {
                    words.Clear();
                    Console.WriteLine("The list has been cleared");
                }
               else if (input == "remove")
                {
                    Random t = new Random();
                    words.RemoveAt(t.Next(words.Count));
                    Console.WriteLine("One element has been randomly removed from the list");
                }
             else   if (input == "reverse")
                {
                    Console.WriteLine("The following items are in the list in reversed order");
                    words.PrintReversed();
                }
              else  if (input == "scramble")
                {
              //Removes a single random element from the list and insert it back into the list at another random index
              //Press print after the scramble command to see the results
                    Random t = new Random();
                    int randomIndex = t.Next(words.Count);
                    CustomNode <string> temp = new CustomNode<string>(words.GetData(randomIndex));
                    words.RemoveAt(randomIndex);
                    int newrandom = t.Next(words.Count);
                    words.Insert(temp.Data, newrandom);
                }
                //simply adds any input to the list other than the command
            else
                {
                    words.add(input);
                }
            }                    
        }
    }
}
