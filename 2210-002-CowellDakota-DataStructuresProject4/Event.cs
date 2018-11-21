///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  DataStructuresProject4/DataStructuresProject4
//	File Name:         Event.cs
//	Description:       Manages Events
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
    /// Enumerated type for events
    /// Either an enter or leave event
    /// </summary>
    public enum EVENTTYPE { ENTER, LEAVE }

    /// <summary>
    /// Class to manage events
    /// </summary>
    public class Event : IComparable
    {
        public Registrant Patron { get; set; }
        public EVENTTYPE Type { get; set; }
        public DateTime Time { get; set; }
       
        /// <summary>
        /// Default constructor - Sets default values
        /// </summary>
        public Event()
        {
            Patron = new Registrant();
            Type = EVENTTYPE.ENTER;
            Time = DateTime.Now;
        }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="patron">Registrant associated with the event</param>
        /// <param name="type">Event Type - Enter or Leave</param>
        /// <param name="time">Time that the event occurs</param>
        public Event(Registrant patron, EVENTTYPE type, DateTime time)
        {
            Patron = patron;
            Type = type;
            Time = time;
        }

        /// <summary>
        /// Compares 2 events 
        /// Used for the PriorityQueue
        /// </summary>
        /// <param name="obj">Object being compared to</param>
        /// <returns>Integer representing whether the object is greater or less than what it's being compared to</returns>
        public int CompareTo(Object obj)
        {
            if(!(obj is Event))
            {
                throw new ArgumentException("Parameter is not an Event object");
            }

            Event e = (Event)obj;
            return e.Time.CompareTo(Time);
        }
    }
}
