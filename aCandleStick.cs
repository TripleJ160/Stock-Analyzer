using System;

namespace Project_2
{
    //create a new aCandleStick object
    public class aCandleStick
    {
        //initial properties for the object
        public DateTime date { get; set; }      //date property that contain both date and time values
        public Decimal open { get; set; }       //opening price of the stock in the selected time period
        public Decimal close { get; set; }      //closing price of the stock in the selected time period
        public Decimal high { get; set; }       //highest price during the selected time period
        public Decimal low { get; set; }        //lowest price during the selected time period
        public long volume { get; set; }        //volume of he stock trade during the selected time period

        public aCandleStick()
        {
            //default constructor which don't contain any properties
        }

        //constructor that takes in an array of string data and initialize the properties
        public aCandleStick(string[] data)
        {
            //if-else condition to make sure the array has at least 8 values
            if (data.Length == 6)
            {
                try
                {
                    // Parse and assign values from the input array and convert them to the appropriate data types
                    date = DateTime.Parse(data[0].Trim());
                    open = Convert.ToDecimal(data[1]);
                    high = Convert.ToDecimal(data[2]);
                    low = Convert.ToDecimal(data[3]);
                    close = Convert.ToDecimal(data[4]);
                    volume = Convert.ToInt64(data[5]);
                }
                //handling format exception during parsing and display error message
                catch (FormatException ex)
                {
                    throw new FormatException("Fail to parse candle stick values.", ex);
                }
            }
            //display am error message if there're not enough values
            else
            {
                throw new ArgumentException("Input values array should have t least 6 elements.");
            }
        }
    }
}
