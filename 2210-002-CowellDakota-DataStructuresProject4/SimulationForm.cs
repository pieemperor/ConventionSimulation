///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  DataStructuresProject4/DataStructuresProject4
//	File Name:         SimulationForm.cs
//	Description:       Manages Simulation of the registration
//	Course:            CSCI 2210 - Data Structures	
//	Author:            Dakota Cowell, cowelld@etsu.edu, Dept. of Computing, East Tennessee State University
//	Created:           Thursday, November 8, 2018
//	Copyright:         Dakota Cowell, 2018
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2210_002_CowellDakota_DataStructuresProject4
{
    /// <summary>
    /// Partial class to manage the simulation of the registrations
    /// </summary>
    public partial class SimulationForm : Form
    {
        ConventionRegistration conventionRegistration = new ConventionRegistration();
        public static Random r = new Random();
        public int numPatrons; //Number of patrons expected to register
        public DateTime openingTime; //Time the registration booths open
        public DateTime closingTime; //Time the registration booths close
        public double expectedRegistrationLength; //Amount of time it takes to register
        public int registrationWindows; //Number of registration windows
        public int threadSleepTime; //Amount of time the program pauses before continuing

        private int longestLineLength; //Keeps track of the longest line throughout the registration period
        private int eventsProcessed; //Number of events processed during the simulation
        private int arrivals; //Number of arrival events processed during the simulation
        private int departures; //Number of departure events processed during the simulation

        /// <summary>
        /// Form constructor - Initializes components for the form
        /// </summary>
        public SimulationForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method that loops through the events in the PriorityQueue and handles the events 
        /// Also calls the PrintLines method to show the lines
        /// </summary>
        public void DoSimulation()
        {
            TimeSpan interval; //Amount of time that a registrant takes to register

            //Create the number of lines that the user input
            for (int i = 0; i < registrationWindows; i++)
            {
                conventionRegistration.WaitingLines.Add(new Queue<Registrant>());
            }

            //Loop through the AllEvents PriorityQueue until it is empty
            while (conventionRegistration.AllEvents.Count > 0)
            {
                //If it's an enter event, place them in the correct line. Then, generate a leave event for them
                if (conventionRegistration.AllEvents.Peek().Type == EVENTTYPE.ENTER)
                {
                    //Get the event at the front of the AllEvents PriorityQueue
                    Event currentEvent = conventionRegistration.AllEvents.Peek();

                    //Find the index of the shortest line and set the patron's line number to the shortest line's index - Then, put them in the shortest line
                    int shortestLine = conventionRegistration.FindShortestLine();       
                    currentEvent.Patron.LineNumber = shortestLine;
                    conventionRegistration.WaitingLines[shortestLine].Enqueue(currentEvent.Patron);

                    //Generate the length of the current customer's registration
                    interval = TimeSpan.FromSeconds(90 + NegExp((expectedRegistrationLength * 60) - 90 ));

                    //Generate the leave event and add it to the AllEvents PriorityQueue
                    Event leaveEvent = new Event(currentEvent.Patron, EVENTTYPE.LEAVE, currentEvent.Time + interval);
                    conventionRegistration.AllEvents.Enqueue(leaveEvent);

                    //Find the length of the longest line and update the max line length
                    FindLongestLineLength(conventionRegistration.WaitingLines);

                    //Increase the number of arrivals
                    arrivals++;
                }
                //If the event is a leave event, remove the registrant from the line they were in and increase the number of departures
                else
                {
                    Event currentEvent = conventionRegistration.AllEvents.Peek();
                    conventionRegistration.WaitingLines[currentEvent.Patron.LineNumber].Dequeue();
                    departures++;
                }

                //Display the updated lines
                PrintLines(conventionRegistration.WaitingLines);

                //Remove the event from the PriorityQueue
                conventionRegistration.AllEvents.Dequeue();

                //Increase number of events processed and update all labels
                eventsProcessed++;
                UpdateLabels();

                //Pause the program for the specified time
                Thread.Sleep(threadSleepTime);
            }
        }

        /// <summary>
        /// Method to update the labels on the Simulation Form
        /// </summary>
        private void UpdateLabels()
        {
            eventsProcessedLabel.Text = $"Events Processed: {eventsProcessed}";
            arrivalsLabel.Text = $"Arrivals: {arrivals}";
            departuresLabel.Text = $"Departures: {departures}";
            maxLineLengthLabel.Text = $"Longest Line: {longestLineLength} Registrants";


            arrivalsLabel.Update();
            eventsProcessedLabel.Update();
            departuresLabel.Update();
            maxLineLengthLabel.Update();
        }

        /// <summary>
        /// Generates a random number based on the negative exponential distribution
        /// </summary>
        /// <param name="ExpectedValue">Value that is expected</param>
        /// <returns>Random number based on the Negative Exponential function</returns>
        private double NegExp(double ExpectedValue)
        {
            return -ExpectedValue * Math.Log(r.NextDouble(), Math.E);
        }

        /// <summary>
        /// Generates a random number based on the Poisson distribution
        /// </summary>
        /// <param name="expectedValue">Expected value to be input into the Poisson distribution</param>
        /// <returns>Random value based on the Poisson distribution</returns>
        private static int Poisson(double expectedValue)
        {
            double dLimit = -expectedValue;
            double dSum = Math.Log(r.NextDouble());

            int count;
            for (count = 0; dSum > dLimit; count++)
            {
                dSum += Math.Log(r.NextDouble());
            }

            return count;
        }

        /// <summary>
        /// When the form is shown
        /// Sets the number of patrons based on a Poisson distribution
        /// Generates Events based on the values input by users
        /// Performs the simulation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SimulationForm_Shown(object sender, EventArgs e)
        {
            numPatrons = Poisson(numPatrons);
            conventionRegistration.GenerateEvents(numPatrons, openingTime, closingTime);
            DoSimulation();
        }

        /// <summary>
        /// Prints out a list of all registrants in a Queue
        /// </summary>
        /// <param name="lines">List of lines of Registrants</param>
        private void PrintLines(List<Queue<Registrant>> lines)
        {
            string outputLinesString = "";
            int lineCount = 0;

            //Loop through each Queue in the List and display each registrant in the Queue
            foreach(Queue<Registrant> line in lines)
            {
                outputLinesString += $"Line {lineCount + 1}: ";
                foreach(Registrant registrant in lines[lineCount])
                {
                    outputLinesString += registrant.Id.ToString().PadLeft(4, '0') + "  ";
                }
                lineCount++;
                outputLinesString += "\n";
            }

            //Update the Lines Label
            allLinesLabel.Text = outputLinesString;
            allLinesLabel.Update();
        }
        
        /// <summary>
        /// Find the length of the longest line and if it is longer than the max length, set it to the max length
        /// </summary>
        /// <param name="lines">List of lines to find the longest</param>
        private void FindLongestLineLength(List<Queue<Registrant>> lines)
        { 
            foreach(Queue<Registrant> line in lines)
            {
                if(line.Count > longestLineLength)
                {
                    longestLineLength = line.Count;
                }
            }
        }
    }
}
