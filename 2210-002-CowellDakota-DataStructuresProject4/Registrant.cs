///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  DataStructuresProject4/DataStructuresProject4
//	File Name:         Registrant.cs
//	Description:       Manages Registrants
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

namespace _2210_002_CowellDakota_DataStructuresProject4
{
    /// <summary>
    /// Keeps track of Registrant information
    /// </summary>
    public class Registrant
    {
        public int Id { get; set; }
        public int LineNumber { get; set; }

        /// <summary>
        /// Default constructor
        /// Sets values to default
        /// </summary>
        public Registrant()
        {
            Id = -1;
            LineNumber = -1;
        }

        /// <summary>
        /// Single parameter constructor
        /// </summary>
        /// <param name="id">Id of the registrant</param>
        public Registrant(int id)
        {
            Id = id;
        }

        /// <summary>
        /// 2 parameter constructor
        /// </summary>
        /// <param name="id">Id of Registrant</param>
        /// <param name="lineNumber">Line that the registrant is waiting in</param>
        public Registrant(int id, int lineNumber)
        {
            Id = id;
            LineNumber = lineNumber;
        }
    }

}
