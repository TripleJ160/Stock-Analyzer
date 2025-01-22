using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Project_2;
using Project_2.StockDataUpload;

namespace Project_2
{
    // Partial class definition for the input form
    public partial class Form_input : Form
    {
        // Static properties to hold stock name and period extracted from file names
        public static string StockText { get; set; } // Stock name, e.g., "AAPL"
        public static string StockPeriod { get; set; } // Stock period, e.g., "Monthly"

        // Binding list to hold candlestick data for the UI
        private BindingList<aCandleStick> candleSticks { get; set; }

        // Constructor to initialize the form
        public Form_input()
        {
            InitializeComponent(); // Initialize UI components
        }

        // Event handler for when the form loads
        private void Form1_Load(object sender, EventArgs e)
        {
            // Default constructor logic, currently unused
        }

        // Event handler for the "Load" button click
        private void loadButton_Click(object sender, EventArgs e)
        {
            // Show the Open File Dialog to allow users to upload stock data files
            openFileDialog_stockUpload.ShowDialog();
        }

        // Event handler for when a file is selected in the Open File Dialog
        private void openFileDialog_stockUpload_FileOk(object sender, CancelEventArgs e)
        {
            // Loop through the selected files to retrieve data
            foreach (string openedFile in openFileDialog_stockUpload.FileNames)
            {
                // Extract the file name without extension
                string fileName = Path.GetFileNameWithoutExtension(openedFile);

                // Split the file name to extract the stock period and name
                string[] nameParts = fileName.Split('-');
                if (nameParts.Length == 2)
                {
                    // Assign values to static properties for use in other forms
                    Form_input.StockPeriod = nameParts[0];   // e.g., "AAPL"
                    Form_input.StockText = nameParts[1];     // e.g., "Monthly"
                }

                // Load the stock data from the selected file
                List<smartCandleStick> data = LoadStockMechanism.GetCSVdata(openedFile);

                // Create a new display form to visualize the data
                Form_display newChart = new Form_display(data, dateTimePicker_startDate.Value, dateTimePicker_endDate.Value);
                newChart.Show(); // Show the new form
            }
        }
    }
}
