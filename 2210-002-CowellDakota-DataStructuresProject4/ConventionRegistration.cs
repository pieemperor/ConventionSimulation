///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  DataStructuresProject4/DataStructuresProject4
//	File Name:         ConventionRegistration.cs
//	Description:       Manages the generation of events as well as keeping track of all events and the lines of registrants
//	Course:            CSCI 2210 - Data Structures	
//	Author:            Dakota Cowell, cowelld@etsu.edu, Dept. of Computing, East Tennessee State University
//	Created:           Thursday, November 8, 2018
//	Copyright:         Dakota Cowell, 2018
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using _2210_002_CowellDakota_DataStructuresProject4.PriorityQueue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2210_002_CowellDakota_DataStructuresProject4
{
    /// <summary>
    /// Manages the creation of simulation events and keeps track of lines
    /// </summary>
    public class ConventionRegistration
    {
        public PriorityQueue<Event> AllEvents { get; set; }
        public List<Queue<Registrant>> WaitingLines { get; set; }
        public DateTime OpeningTime { get; set; }
        Random r = new Random();

        /// <summary>
        /// Default Constructor
        /// Sets default values for properties
        /// </summary>
        public ConventionRegistration()
        {
            AllEvents = new PriorityQueue<Event>();
            WaitingLines = new List<Queue<Registrant>>();
            OpeningTime = new DateTime();
        }

        /// <summary>
        /// Creates enter events to be processed and adds them to the PriorityQueue
        /// </summary>
        /// <param name="numPatrons">Number of events to generate</param>
        /// <param name="openingTime">Time the registration windows open</param>
        /// <param name="closingTime">Time the registration windows close</param>
        public void GenerateEvents(int numPatrons, DateTime openingTime, DateTime closingTime)
        {
            TimeSpan start;
            TimeSpan totalHoursOpen = closingTime - openingTime;

            for(int patron = 1; patron <= numPatrons + 1; patron++)
            {
                start = TimeSpan.FromSeconds(r.Next((int)totalHoursOpen.TotalSeconds));
                AllEvents.Enqueue(new Event(new Registrant(patron), EVENTTYPE.ENTER, openingTime.Add(start)));
            }
        }

        /// <summary>
        /// Finds the line that has the fewest registrants
        /// </summary>
        /// <returns>Index of the shortest line</returns>
        public int FindShortestLine()
        {
            int shortestLineIndex = 0;

            foreach (Queue<Registrant> line in WaitingLines)
            {
                if (line.Count < WaitingLines[shortestLineIndex].Count)
                {
                    shortestLineIndex = WaitingLines.IndexOf(line);
                }
            }
            return shortestLineIndex;
        }
    }
}
