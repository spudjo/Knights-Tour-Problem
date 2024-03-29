﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace shawn_pudjowargono_assignment_01
{
    public partial class Results_Form : Form
    {
        public int number_of_trials;
        public int strategy;
        // Non intelligent method output file
        public static string non_intelligent_output = "ShawnPudjowargonoNonIntelligentMethod.txt";
        // Heuristics method output file
        public static string heuristics_output = "ShawnPudjowargonoHeuristicsMethod.txt";

        /*
         * Results for constructor. Called from Windows_Form after all trials are 
         * executed to display results.
         */
        public Results_Form(int number_of_trials, int strategy)
        {
            InitializeComponent();
            this.strategy = strategy;
            this.number_of_trials = number_of_trials;
            set_results_display_label();
        }

        /*
         * Called upon construction of Results_Form to display results
         */
        private void set_results_display_label()
        {
            string[] output_string; // Declare string to hold results of final trial

            // Determines which text file to read from depending on which strategy is implemented
            // The contents of the text file is stored in the string array
            if (strategy == 0)
            {
                results_label.Text = "Final Non-Intelligent Trial";
                output_string = File.ReadAllLines(non_intelligent_output);
            }
            else
            {
                results_label.Text = "Final Heuristics Trial";
                output_string = File.ReadAllLines(heuristics_output);
            }

            // This loop searches output_string for the final trial
            // and displays the score and resulting step order in the 
            // Results Windows form
            for (int i = 0; i < output_string.Length; i++)
            {
                if (output_string[i].Contains("Trial " + number_of_trials))
                {
                    trial_results_label.Text = output_string[i];
                    i++;
                    for (int k = i; k < i+8; k++)
                    {
                        results_display_box.AppendText(output_string[k]);
                        results_display_box.AppendText("\n");
                    }
                    break;
                }
            }
           
        }

        /*
         * Open text file with full history of trials for the current run
         */ 
        private void results_button_Click(object sender, EventArgs e)
        {
            if (strategy == 0)
            {
                Process.Start("notepad.exe", non_intelligent_output);
            }
            else
            {
                Process.Start("notepad.exe", heuristics_output);
            }
        }
    }
}
