///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  DataStructuresProject4/DataStructuresProject4
//	File Name:         SettingsForm.cs
//	Description:       Allows user to input data that changes how the simulation runs
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2210_002_CowellDakota_DataStructuresProject4
{
    /// <summary>
    /// Partial class to manage the settings form for the simulation
    /// </summary>
    public partial class SettingsForm : Form
    {
        /// <summary>
        /// Default constructor - Initializes components
        /// </summary>
        public SettingsForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets values to the user input settings and validates the input
        /// Then, displays the simulation window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startSimulationButton_Click(object sender, EventArgs e)
        {
            int threadSleepTime;

            //Make sure the data is input in the correct format
            if (int.TryParse(expectedRegistrantTextBox.Text, out int numPatrons) &&
                double.TryParse(expectedLengthTextBox.Text, out double expectedRegistrationLength) &&
                int.TryParse(numRegistrationWindowsTextBox.Text, out int registrationWindows))
            {
                //Make sure the closing time is after the opening time
                if (closingTimePicker.Value > openingTimePicker.Value)
                {
                    if (slowRadioButton.Checked)
                    {
                        threadSleepTime = 500;
                    }
                    else if (fastRadioButton.Checked)
                    {
                        threadSleepTime = 0;
                    }
                    else
                    {
                        threadSleepTime = 100;
                    }

                    //Create simulation form with settings from this window
                    SimulationForm simulationForm = new SimulationForm
                    {
                        numPatrons = numPatrons,
                        expectedRegistrationLength = expectedRegistrationLength,
                        openingTime = openingTimePicker.Value,
                        closingTime = closingTimePicker.Value,
                        registrationWindows = registrationWindows,
                        threadSleepTime = threadSleepTime
                    };

                    //Show simulation window
                    simulationForm.Show(); 
                } else
                {
                    MessageBox.Show("Closing time must come after opening time.", "Time Input Error");
                }
            } else
            {
                MessageBox.Show("Please check your input values.", "Input Error");
            }
        }
    }
}
