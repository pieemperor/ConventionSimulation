///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  DataStructuresProject4/DataStructuresProject4
//	File Name:         PriorityQueue.cs
//	Description:       Manages a PriorityQueue class that can be used to keep track of generic objects
//	Course:            CSCI 2210 - Data Structures	
//	Author:            Dakota Cowell, cowelld@etsu.edu, Dept. of Computing, East Tennessee State University
//	Created:           Thursday, November 8, 2018
//	Copyright:         Dakota Cowell, 2018
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2210_002_CowellDakota_DataStructuresProject4.PriorityQueue
{
    /// <summary>
    /// PriorityQueue class to manage a collection of objects in priority order
    /// </summary>
    /// <typeparam name="T">Generic type T</typeparam>
    public class PriorityQueue<T> : IPriorityQueue<T> where T : IComparable
    {
        private Node<T> Top;
        public int Count { get; set; }

        /// <summary>
        /// Empties the PriorityQueue and sets the count to 0
        /// </summary>
        public void Clear()
        {
            Top = null;
            Count = 0;
        }

        /// <summary>
        /// Removes an item from the front of a Priority Queue
        /// </summary>
        public void Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Cannot remove from empty queue.");
            } else
            {
                Node<T> oldNode = Top;
                Top = Top.Next;
                Count--;
                oldNode = null;
            }
        }

        /// <summary>
        /// Adds and item to the Priority Queue based on its priority and arrival time
        /// </summary>
        /// <param name="item">Item to be added to the Priority Queue</param>
        public void Enqueue(T item)
        {
            if (Count == 0)
            {
                Top = new Node<T>(item, null);
            }
            else
            {
                Node<T> current = Top;
                Node<T> previous = null;

                while(current != null && current.Item.CompareTo(item) >= 0)
                {
                    previous = current;
                    current = current.Next;
                }

                Node<T> newNode = new Node<T>(item, current);

                if(previous != null)
                {
                    previous.Next = newNode;
                } else
                {
                    Top = newNode;
                }
            }
            Count++;
        }

        /// <summary>
        /// Checks if the Priority Queue is empty
        /// </summary>
        /// <returns>Boolean representing whether the Priority Queue is empty</returns>
        public bool IsEmpty()
        {
            return Count == 0;
        }

        //Returns the item at the front of the Priority Queue
        public T Peek()
        {
            if (!IsEmpty())
            {
                return Top.Item;
            } else
            {
                throw new InvalidOperationException("Cannot obtain top of empty priority queue");
            }
        }
    }
}
