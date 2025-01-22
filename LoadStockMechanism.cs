using Project_2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Project_2.StockDataUpload
{
    internal class LoadStockMechanism
    {
        //this method read data from a CSV file and return it as a list of aCandleStick objects
        public static List<smartCandleStick> GetCSVdata(string filename)
        {
            //initial a list to contain the aCandleStick objects
            List<smartCandleStick> candleSticks = new List<smartCandleStick>();

            try
            {
                //open and read specific file depend on the filename that entered
                using (StreamReader r = new StreamReader(filename))
                {
                    //read and ignore the first line (row) of the file
                    string firsline = r.ReadLine();

                    //loop to go through the rest of the file
                    while (!r.EndOfStream)
                    {
                        //read the file line by line and store the data as an array using a comma as the delimiter
                        string line = r.ReadLine();
                        string[] value = line.Split(',');

                        /*if-else condition to make sure the array has at least 9 values and 
                         * store the values as new aCandleStick object in a new list*/
                        if (value.Length == 6)
                        {
                            smartCandleStick aCandleStick = new smartCandleStick(value);
                            candleSticks.Add(aCandleStick);
                        }
                        //display am error message if there're not enough values
                        else
                        {
                            MessageBox.Show("Invalid data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            //handle the exceptions and display the error message
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //reverse the list order and return the correct list
            candleSticks.Reverse();
            return candleSticks;
        }
    }
}