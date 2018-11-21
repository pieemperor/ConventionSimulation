///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  DataStructuresProject4/DataStructuresProject4
//	File Name:         Program.cs
//	Description:       Driver of the Program - Contains the main method
//	Course:            CSCI 2210 - Data Structures	
//	Author:            Dakota Cowell, cowelld@etsu.edu, Dept. of Computing, East Tennessee State University
//	Created:           Thursday, November 8, 2018
//	Copyright:         Dakota Cowell, 2018
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2210_002_CowellDakota_DataStructuresProject4
{
    /// <summary>
    /// class to initialize the main window of the application
    /// </summary>
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SettingsForm());
        }
    }
}
