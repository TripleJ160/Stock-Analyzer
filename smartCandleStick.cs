using Project_2; // Include the namespace Project_2 for accessing other project elements
using System; // Namespace for basic functionalities like math and exception handling
using System.Collections.Generic; // Namespace for using generic collections
using System.Drawing; // Namespace for graphics-related functionalities (not used here explicitly)
using System.Linq; // Namespace for LINQ queries (not used here explicitly)
using System.Text; // Namespace for string manipulation functionalities (not used here explicitly)
using System.Threading.Tasks; // Namespace for async programming (not used here explicitly)
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip; // Static import for ToolTip (not used here explicitly)

namespace Project_2 // Defines the Project_2 namespace
{
    // Define a new class `smartCandleStick` that extends `aCandleStick`
    public class smartCandleStick : aCandleStick
    {
        // Define properties for additional attributes of the candlestick
        public decimal range { get; set; } // Total range (high - low)
        public decimal bodyRange { get; set; } // Range of the candlestick body (close - open)
        public decimal topTail { get; set; } // Length of the upper wick (high - topPrice)
        public decimal bottomTail { get; set; } // Length of the lower wick (bottomPrice - low)
        public decimal topPrice { get; set; } // Higher value between open and close
        public decimal bottomPrice { get; set; } // Lower value between open and close


        // Boolean properties to classify candlestick types
        public bool isPeak { get; set; }
        public bool isValley { get; set; }
        public bool isBullish { get; set; } // True if close > open
        public bool isMarubozu { get; set; } // True if body occupies almost entire range with no tails
        public bool isBearish { get; set; } // True if open > close
        public bool isNeutral { get; set; } // True if open == close
        public bool isDoji { get; set; } // True if body is very small
        public bool isDragonFlyDoji { get; set; } // True if candlestick looks like a Dragonfly Doji
        public bool isGravestoneDoji { get; set; } // True if candlestick looks like a Gravestone Doji
        public bool isHammer { get; set; } // True if candlestick resembles a Hammer
        public bool isInvertedHammer { get; set; } // True if candlestick resembles an Inverted Hammer

        // Constructor that takes an array of values and initializes the `smartCandleStick` object
        public smartCandleStick(string[] vals) : base(vals) // Calls the base class constructor with `vals`
        {
            // Calculate candlestick attributes based on provided values
            bodyRange = Math.Abs(close - open); // Absolute body range
            range = high - low; // Total range of the candlestick
            topTail = high - Math.Max(open, close); // Upper wick length
            bottomTail = Math.Min(open, close) - low; // Lower wick length
            topPrice = Math.Max(open, close); // Higher price between open and close
            bottomPrice = Math.Min(open, close); // Lower price between open and close


            // Determine if the candlestick is bullish, bearish, or neutral

            isNeutral = open == close; // Neutral if open == close
            isBullish = close > open; // Bullish if close > open
            isBearish = open > close; // Bearish if open > close

            // Calculate shadow ratios for upper and lower parts of the candlestick
            double lowerShadowRatio = (double)(close - low) / (double)range; // Ratio of lower shadow
            double upperShadowRatio = (double)(high - close) / (double)range; // Ratio of upper shadow

            // Determine specific candlestick patterns
            isDoji = bodyRange <= range * 0.05m; // Doji if body is very small compared to range
            isMarubozu = (bodyRange / range) >= 0.95m && topTail == 0 && bottomTail == 0; // Marubozu if body covers range and no tails
            isDragonFlyDoji = lowerShadowRatio >= 0.98 && upperShadowRatio < 0.02; // Dragonfly Doji if large lower shadow and small upper shadow
            isGravestoneDoji = open == close && close == high; // Gravestone Doji if open, close, and high are equal
            isInvertedHammer = topTail > range * 0.6m && bottomTail < range * 0.1m; // Inverted Hammer if large top tail and small bottom tail
            isHammer = bottomTail > range * 0.6m && topTail < range * 0.1m; // Hammer if large bottom tail and small top tail
        }

        public void DeterminePeakOrValley(List<smartCandleStick> data, int index)
        {
            if (index > 0 && index < data.Count - 1)
            {
                var prev = data[index - 1];
                var next = data[index + 1];

                isPeak = high > prev.high && high > next.high;
                isValley = low < prev.low && low < next.low;
            }
        }

    }
}