///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  DataStructuresProject4/DataStructuresProject4
//	File Name:         IPriorityQueue.cs
//	Description:       Interface for PriorityQueue
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
    /// Interface to help manage the PriorityQueue class
    /// </summary>
    /// <typeparam name="T">Generic type T</typeparam>
    public interface IPriorityQueue<T> : IContainer<T> where T : IComparable
    {
        //Inserts Item based on its priority
        void Enqueue(T item);
        //Removes first item in the queue
        void Dequeue();
        //Query
        T Peek();
    }
}
