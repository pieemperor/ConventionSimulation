namespace _2210_002_CowellDakota_DataStructuresProject4
{
    partial class SimulationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimulationForm));
            this.allLinesLabel = new System.Windows.Forms.Label();
            this.maxLineLengthLabel = new System.Windows.Forms.Label();
            this.eventsProcessedLabel = new System.Windows.Forms.Label();
            this.arrivalsLabel = new System.Windows.Forms.Label();
            this.departuresLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // allLinesLabel
            // 
            this.allLinesLabel.AutoSize = true;
            this.allLinesLabel.Location = new System.Drawing.Point(24, 60);
            this.allLinesLabel.Name = "allLinesLabel";
            this.allLinesLabel.Size = new System.Drawing.Size(18, 25);
            this.allLinesLabel.TabIndex = 0;
            this.allLinesLabel.Text = " ";
            // 
            // maxLineLengthLabel
            // 
            this.maxLineLengthLabel.AutoSize = true;
            this.maxLineLengthLabel.Location = new System.Drawing.Point(24, 344);
            this.maxLineLengthLabel.Name = "maxLineLengthLabel";
            this.maxLineLengthLabel.Size = new System.Drawing.Size(160, 25);
            this.maxLineLengthLabel.TabIndex = 1;
            this.maxLineLengthLabel.Text = "Longest Line: 0";
            // 
            // eventsProcessedLabel
            // 
            this.eventsProcessedLabel.AutoSize = true;
            this.eventsProcessedLabel.Location = new System.Drawing.Point(24, 369);
            this.eventsProcessedLabel.Name = "eventsProcessedLabel";
            this.eventsProcessedLabel.Size = new System.Drawing.Size(210, 25);
            this.eventsProcessedLabel.TabIndex = 2;
            this.eventsProcessedLabel.Text = "Events Processed: 0";
            // 
            // arrivalsLabel
            // 
            this.arrivalsLabel.AutoSize = true;
            this.arrivalsLabel.Location = new System.Drawing.Point(24, 394);
            this.arrivalsLabel.Name = "arrivalsLabel";
            this.arrivalsLabel.Size = new System.Drawing.Size(108, 25);
            this.arrivalsLabel.TabIndex = 3;
            this.arrivalsLabel.Text = "Arrivals: 0";
            // 
            // departuresLabel
            // 
            this.departuresLabel.AutoSize = true;
            this.departuresLabel.Location = new System.Drawing.Point(24, 419);
            this.departuresLabel.Name = "departuresLabel";
            this.departuresLabel.Size = new System.Drawing.Size(142, 25);
            this.departuresLabel.TabIndex = 4;
            this.departuresLabel.Text = "Departures: 0";
            // 
            // SimulationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.departuresLabel);
            this.Controls.Add(this.arrivalsLabel);
            this.Controls.Add(this.eventsProcessedLabel);
            this.Controls.Add(this.maxLineLengthLabel);
            this.Controls.Add(this.allLinesLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SimulationForm";
            this.Text = "Event Simulation";
            this.Shown += new System.EventHandler(this.SimulationForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label allLinesLabel;
        private System.Windows.Forms.Label maxLineLengthLabel;
        private System.Windows.Forms.Label eventsProcessedLabel;
        private System.Windows.Forms.Label arrivalsLabel;
        private System.Windows.Forms.Label departuresLabel;
    }
}