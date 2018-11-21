///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  DataStructuresProject4/DataStructuresProject4
//	File Name:         Node.cs
//	Description:       Manages Node objects that are used in the PriorityQueue class
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
    /// Keeps track of a node and its next node
    /// Used when implementing the PriorityQueue class
    /// </summary>
    /// <typeparam name="T">Generic type T</typeparam>
    public class Node<T> where T : IComparable
    {
        //Properties
        public T Item { get; set; }
        public Node<T> Next { get; set; }

        /// <summary>
        /// Parameterized constructor used to create a new node from data passed in
        /// </summary>
        /// <param name="value">Value to be stored in the node</param>
        /// <param name="link">Next node to be linked to</param>
        public Node(T value, Node<T> link)
        {
            Item = value;
            Next = link;
        }
    }
}
