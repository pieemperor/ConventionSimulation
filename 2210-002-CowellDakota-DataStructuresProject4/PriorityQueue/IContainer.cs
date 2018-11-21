///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  DataStructuresProject4/DataStructuresProject4
//	File Name:         IContainer.cs
//	Description:       Implemented in the IPriorityQueue interface - Used to define the methods that are required
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
    /// Interface to define what methods must be implemented for a container
    /// Used in the IPriorityQueue interface
    /// </summary>
    /// <typeparam name="T">Generic type T</typeparam>
    public interface IContainer<T>
    {
        //Remove all objects from the container
        void Clear();
        //Returns true if the container is empty
        bool IsEmpty();
        //Returns the number of entries in the container
        int Count { get; set; }
    }
}
