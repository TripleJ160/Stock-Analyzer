using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Project_2;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Project_2
{
    public partial class Form_display : Form
    {
        private int firstSelectedIndex = -1;
        private int secondSelectedIndex = -1;

        // Lists for storing candlestick data
        List<smartCandleStick> stockStats = null; // Original data
        List<smartCandleStick> tmp = null;        // Filtered data for display
        private BindingList<smartCandleStick> candleSticks { get; set; } // Bindable list for UI

        private Point rubberBandStart;
        private Rectangle rubberBandRectangle;
        private bool isDragging = false;

        // Store current Fibonacci levels for use in Paint event
        private Dictionary<string, decimal> currentFibonacciLevels = null;

        // Constructor for the form
        public Form_display(List<smartCandleStick> stats, DateTime start, DateTime end)
        {
            InitializeComponent(); // Initialize the form components

            // Initialize the candlestick data from the provided list
            stockStats = stats;

            // Set the date range for the start and end date pickers
            startDate.Value = start;
            endDate.Value = end;

            // Populate the comboBox with different candlestick model options for filtering
            List<string> candleStickModel = new List<string>
            {
                "", // Empty option
                "Bullish", // Bullish candlesticks
                "Bearish", // Bearish candlesticks
                "Neutral", // Neutral candlesticks
                "Marubozu", // Marubozu candlestick model
                "Doji", // Doji candlestick model
                "DragonFly Doji", // Dragonfly Doji candlestick
                "Gravestone Doji", // Gravestone Doji candlestick
                "Hammer", // Hammer candlestick
                "Inverted Hammer", // Inverted Hammer candlestick
                "Peak",
                "Valley"
            };

            // Set the data source for the comboBox
            comboBox_modelChange.DataSource = candleStickModel;

            // Set the stock name and period from global variables (Form_input)
            stockName.Text = Form_input.StockText; // Stock name
            period.Text = Form_input.StockPeriod; // Stock period

            // Refresh the chart data based on the selected date range
            dataRefresh();

            candleStick_chart.MouseDown += CandleStick_chart_MouseDown;
            candleStick_chart.MouseMove += CandleStick_chart_MouseMove;
            candleStick_chart.MouseUp += CandleStick_chart_MouseUp;
            candleStick_chart.Paint += CandleStick_chart_Paint;

            candleStick_chart.ChartAreas["AreaOHLC"].AxisX.IsMarginVisible = false;
            candleStick_chart.ChartAreas["AreaOHLC"].AxisY.IsMarginVisible = false;
        }

        // Refreshes the candlestick chart data when date ranges or filters are changed
        public void dataRefresh()
        {
            // Clear existing data and annotations to refresh the chart
            candleSticks?.Clear();
            candleStick_chart.Annotations.Clear();
            candleStick_chart.Series["Series_ohlc"].Points.Clear();

            // Validate if stockStats has data
            if (stockStats == null || !stockStats.Any())
            {
                MessageBox.Show("No stock data available!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Filter the data based on the selected date range (startDate and endDate)
            var data = stockStats.Where(d => d.date >= startDate.Value && d.date <= endDate.Value).ToList();
            tmp = data;

            // Check if the filtered data is null or empty
            if (data == null || data.Count == 0)
            {
                MessageBox.Show("Invalid Data Range!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            for (int i = 0; i < data.Count; i++)
            {
                data[i].DeterminePeakOrValley(data, i);
            }

            // Adjust the chart's Y-axis range based on the filtered data
            normalize(data);

            // Bind the filtered data to a BindingList for chart visualization
            candleSticks = new BindingList<smartCandleStick>(data);

            // Bind the filtered data to the chart's DataSource
            candleStick_chart.DataSource = candleSticks;
            candleStick_chart.DataBind();

            // Calculate the price difference between the first and last candlesticks
            var diff = Math.Round(candleSticks.Last().close - candleSticks.First().close, 2);

            // Display the price difference with appropriate color coding
            diffPrice.ForeColor = diff < 0 ? Color.Red : Color.Green;
            diffPrice.Text = diff > 0
                ? $"{diff}$ up (Price increased over the range)"
                : $"{diff}$ down (Price decreased over the range)";
        }

        // Refresh button click event handler
        private void refreshButton_Click(object sender, EventArgs e)
        {
            dataRefresh();
        }

        // Filter and annotate candlesticks based on the selected model in the combobox
        private void comboBox_modelChange_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear any existing annotations on the chart
            candleStick_chart.Annotations.Clear();

            // Iterate through the filtered list of candlesticks (tmp)
            foreach (smartCandleStick x in tmp)
            {
                // Check if the selected candlestick type matches the current candlestick's properties
                if ((comboBox_modelChange.SelectedValue.ToString() == "Bullish" && x.isBullish) ||
                    (comboBox_modelChange.SelectedValue.ToString() == "Bearish" && x.isBearish) ||
                    (comboBox_modelChange.SelectedValue.ToString() == "Neutral" && x.isNeutral) ||
                    (comboBox_modelChange.SelectedValue.ToString() == "Marubozu" && x.isMarubozu) ||
                    (comboBox_modelChange.SelectedValue.ToString() == "Doji" && x.isDoji) ||
                    (comboBox_modelChange.SelectedValue.ToString() == "DragonFly Doji" && x.isDragonFlyDoji) ||
                    (comboBox_modelChange.SelectedValue.ToString() == "Gravestone Doji" && x.isGravestoneDoji) ||
                    (comboBox_modelChange.SelectedValue.ToString() == "Hammer" && x.isHammer) ||
                    (comboBox_modelChange.SelectedValue.ToString() == "Inverted Hammer" && x.isInvertedHammer) ||
                    (comboBox_modelChange.SelectedValue.ToString() == "Peak" && x.isPeak) ||
                    (comboBox_modelChange.SelectedValue.ToString() == "Valley" && x.isValley))
                {
                    // Create and add an annotation for the matching candlestick
                    CreateAnnotations(x);
                }
            }
        }

        // Create annotations for specific candlesticks
        public void CreateAnnotations(smartCandleStick x)
        {
            // Create a new arrow annotation for marking specific candlestick data points
            var rectangleAnno = new ArrowAnnotation
            {
                // Set the X-axis of the annotation to align with the chart's OHLC (Open, High, Low, Close) area
                AxisX = candleStick_chart.ChartAreas["AreaOHLC"].AxisX,

                // Set the Y-axis of the annotation to align with the chart's OHLC area
                AxisY = candleStick_chart.ChartAreas["AreaOHLC"].AxisY,

                // Set the position of the annotation on the X-axis (candlestick's date converted to OLE automation date format)
                X = x.date.ToOADate(),

                // Set the position of the annotation on the Y-axis (slightly below the candlestick's low value)
                Y = (double)(x.low) - 5,

                // Set the width of the annotation's line
                LineWidth = 1,

                // Set the width of the annotation rectangle (no horizontal span)
                Width = 0,

                // Set the height of the annotation (short vertical span above the low value)
                Height = 5,

                // Set the size of the arrow head at the annotation's end
                ArrowSize = 2,

                // Align the annotation's arrow to point downward from the center
                Alignment = ContentAlignment.TopCenter,

                // Set the color of the annotation's line to red for visibility
                LineColor = Color.Red
            };

            // Add the annotation to the chart for rendering
            candleStick_chart.Annotations.Add(rectangleAnno);
        }

        // Creates a new annotation on the chart for a given candlestick
        private void CreateAnnotation(smartCandleStick candle, Color color, string label)
        {
            // Create a new TextAnnotation object to hold the annotation details
            var annotation = new TextAnnotation
            {
                // Set the X-axis for the annotation to the chart's X-axis
                AxisX = candleStick_chart.ChartAreas["AreaOHLC"].AxisX,

                // Set the Y-axis for the annotation to the chart's Y-axis
                AxisY = candleStick_chart.ChartAreas["AreaOHLC"].AxisY,

                // Set the X-coordinate of the annotation to the date of the candlestick
                X = candle.date.ToOADate(),

                // Set the Y-coordinate of the annotation to the high price of the candlestick
                Y = (double)candle.high,

                // Set the text to be displayed for the annotation
                Text = label,

                // Set the color of the annotation text
                ForeColor = color,

                // Align the annotation text to the top center of the annotation
                Alignment = ContentAlignment.TopCenter
            };

            // Add the annotation to the chart's collection of annotations
            candleStick_chart.Annotations.Add(annotation);
        }

        // Adds annotations to the chart to highlight peak and valley points in the data
        private void AddPeakValleyAnnotations(List<smartCandleStick> data)
        {
            // Iterate through each candlestick in the data
            foreach (var candle in data)
            {
                // Check if the current candlestick is a peak point
                if (candle.isPeak)
                {
                    // Create a new annotation for the peak point with green text
                    CreateAnnotation(candle, Color.Green, "Peak");
                }
                // Check if the current candlestick is a valley point
                else if (candle.isValley)
                {
                    // Create a new annotation for the valley point with red text
                    CreateAnnotation(candle, Color.Red, "Valley");
                }
            }
        }

        // Normalize the Y-axis range for better chart display
        public void normalize(List<smartCandleStick> data)
        {
            // Find the maximum high and minimum low values from the data
            decimal max = data.Max(x => x.high); // The highest value in the dataset
            decimal min = data.Min(x => x.low);  // The lowest value in the dataset

            // Define a buffer of 2% to extend the Y-axis range
            decimal buffer = 0.02m; // 2% margin

            // Set the Y-axis minimum with a margin below the lowest value
            candleStick_chart.ChartAreas["AreaOHLC"].AxisY.Minimum = (double)(min - (min * buffer));

            // Set the Y-axis maximum with a margin above the highest value
            candleStick_chart.ChartAreas["AreaOHLC"].AxisY.Maximum = (double)(max + (max * buffer));
        }

        // Checks if a candlestick at a given index is a peak or valley point
        private bool IsPeakOrValley(int index)
        {
            // Get the candlestick at the specified index
            var candle = tmp[index];

            // Return true if the candlestick is either a peak or valley point
            return candle.isPeak || candle.isValley;
        }

        // Validates a wave between two candlesticks at given indices
        private bool IsValidWave(int firstIndex, int secondIndex)
        {
            // Implement logic to validate the wave (e.g., check for specific patterns or conditions)
            // For example, check if the first index is less than the second index
            return firstIndex < secondIndex; // Example condition
        }

        // Highlights a candlestick at a given index with a specified color
        private void HighlightCandlestick(int index, Color color)
        {
            // Get the point in the chart series corresponding to the candlestick at the specified index
            var point = candleStick_chart.Series["Series_ohlc"].Points[index];

            // Set the color of the point to the specified color
            point.Color = color;
        }

        // Resets the current selection by resetting the color of the selected candlesticks and clearing the indices
        private void ResetSelection()
        {
            // If a first candlestick is selected, reset its color to the original color (black)
            if (firstSelectedIndex != -1)
                HighlightCandlestick(firstSelectedIndex, Color.Black); // Reset to original color

            // If a second candlestick is selected, reset its color to the original color (black)
            if (secondSelectedIndex != -1)
                HighlightCandlestick(secondSelectedIndex, Color.Black); // Reset to original color

            // Clear the indices of the selected candlesticks
            firstSelectedIndex = -1;
            secondSelectedIndex = -1;
        }

        // Stores the valid selection rectangle
        private Rectangle validSelectionRectangle = Rectangle.Empty;

        // Handles the mouse down event on the chart
        private void CandleStick_chart_MouseDown(object sender, MouseEventArgs e)
        {
            // Set the flag to indicate that the user is dragging the mouse
            isDragging = true;

            // Store the starting point of the drag operation
            rubberBandStart = e.Location;

            // Initialize the rubber band rectangle to empty
            rubberBandRectangle = Rectangle.Empty;
        }

        // Handles the mouse move event on the chart
        private void CandleStick_chart_MouseMove(object sender, MouseEventArgs e)
        {
            // If the user is dragging the mouse, update the rubber band rectangle and calculate the Fibonacci levels
            if (isDragging)
            {
                // Get the chart area
                var chartArea = candleStick_chart.ChartAreas["AreaOHLC"];

                // Calculate the width of the rubber band rectangle
                var width = e.X - rubberBandStart.X;

                // Calculate the start and end Y-coordinates of the rubber band rectangle
                var startY = rubberBandStart.Y;
                var endY = e.Y;

                // Update the rubber band rectangle
                rubberBandRectangle = new Rectangle(rubberBandStart.X, Math.Min(startY, endY), width, Math.Abs(endY - startY));

                // Invalidate the chart to force a redraw
                candleStick_chart.Invalidate();

                // Calculate the start and end prices based on the current rectangle
                var startPrice = (decimal)chartArea.AxisY.PixelPositionToValue(Math.Min(startY, endY));
                var endPrice = (decimal)chartArea.AxisY.PixelPositionToValue(Math.Max(startY, endY));

                // Compute the Fibonacci levels dynamically based on the start and end prices
                var fibonacciLevels = ComputeFibonacciLevels(startPrice, endPrice);

                // Draw the Fibonacci lines and labels dynamically
                DrawFibonacciAnnotations(fibonacciLevels);
            }
        }

        // Mouse up event - Finalize selection
        private decimal finalStartPrice;
        private decimal finalEndPrice;

        // Handles the mouse up event on the chart
        private void CandleStick_chart_MouseUp(object sender, MouseEventArgs e)
        {
            // If the user was dragging the mouse, process the selection
            if (isDragging)
            {
                // Set the flag to indicate that the user is no longer dragging the mouse
                isDragging = false;

                // Get the indices of the candlesticks within the selected rectangle
                var selectedCandlestickIndexes = GetCandlesticksInRectangle(rubberBandRectangle);

                // Check if the selection is valid (i.e., contains at least two candlesticks, starts with a peak or valley, and forms a valid wave)
                if (selectedCandlestickIndexes.Count > 1 && IsPeakOrValley(selectedCandlestickIndexes[0]) && IsValidWave(selectedCandlestickIndexes[0], selectedCandlestickIndexes.Last()))
                {
                    // Display a success message to the user
                    MessageBox.Show("Valid wave selected!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Shade the selected wave
                    ShadeSelectedWave(selectedCandlestickIndexes[0], selectedCandlestickIndexes.Last());

                    // Store the valid selection rectangle
                    validSelectionRectangle = rubberBandRectangle;

                    // Get the final start and end prices from the rectangle
                    finalStartPrice = (decimal)candleStick_chart.ChartAreas["AreaOHLC"].AxisY.PixelPositionToValue(rubberBandRectangle.Top);
                    finalEndPrice = (decimal)candleStick_chart.ChartAreas["AreaOHLC"].AxisY.PixelPositionToValue(rubberBandRectangle.Bottom);

                    // Compute the Fibonacci levels for the selected wave
                    var fibonacciLevels = ComputeFibonacciLevels(finalStartPrice, finalEndPrice);

                    // Store the current Fibonacci levels for the Paint event
                    currentFibonacciLevels = fibonacciLevels;

                    // Trigger a chart repaint to draw the Fibonacci labels
                    candleStick_chart.Invalidate();
                }
                else
                {
                    // Display an error message to the user
                    MessageBox.Show("Invalid wave selection. Please try again.", "Invalid Wave", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Clear the valid selection rectangle
                    validSelectionRectangle = Rectangle.Empty;

                    // Reset the highlights on the chart
                    ResetHighlights();

                    // Clear the chart annotations
                    candleStick_chart.Annotations.Clear();

                    // Clear the stored Fibonacci levels
                    currentFibonacciLevels = null;

                    // Trigger a chart repaint to remove the Fibonacci labels
                    candleStick_chart.Invalidate();
                }

                // Clear the rubber band rectangle
                rubberBandRectangle = Rectangle.Empty;

                // Trigger a chart repaint to remove the rubber band rectangle
                candleStick_chart.Invalidate();
            }
        }

        private void ResetHighlights()
        {
            foreach (var point in candleStick_chart.Series["Series_ohlc"].Points)
            {
                point.Color = Color.Black; // Reset to original color or choose a default color
            }
        }

        private void CandleStick_chart_Paint(object sender, PaintEventArgs e)
        {
            if (currentFibonacciLevels != null)
            {
                foreach (var level in currentFibonacciLevels)
                {
                    // Convert Y value to pixel Y position
                    double yValue = (double)level.Value;
                    double pixelY = candleStick_chart.ChartAreas["AreaOHLC"].AxisY.ValueToPixelPosition(yValue);

                    // Fixed pixel X position
                    int fixedPixelX = 1654;

                    // Draw the label at (fixedPixelX, pixelY)
                    string labelText = level.Key; // e.g., "23.6%"

                    // Measure the size of the text
                    SizeF textSize = e.Graphics.MeasureString(labelText, this.Font);

                    // Define the position with some padding
                    float labelX = fixedPixelX + 5; // 5 pixels to the right of the fixed X
                    float labelY = (float)pixelY - (textSize.Height / 2);

                    // Ensure the label does not go out of vertical bounds
                    labelY = Math.Max(0, Math.Min(labelY, candleStick_chart.Height - textSize.Height));

                    // Draw background rectangle for better readability
                    using (SolidBrush backgroundBrush = new SolidBrush(Color.White))
                    using (SolidBrush textBrush = new SolidBrush(Color.Black))
                    {
                        RectangleF backgroundRect = new RectangleF(
                            labelX,
                            labelY,
                            textSize.Width + 4, // Add padding
                            textSize.Height + 2
                        );

                        e.Graphics.FillRectangle(backgroundBrush, backgroundRect);
                        e.Graphics.DrawRectangle(Pens.Black, backgroundRect.X, backgroundRect.Y, backgroundRect.Width, backgroundRect.Height);

                        // Draw the text
                        e.Graphics.DrawString(labelText, this.Font, textBrush, labelX + 2, labelY + 1);
                    }
                }
            }

            if (rubberBandRectangle != Rectangle.Empty)
            {
                using (var pen = new Pen(Color.Blue, 2))
                {
                    e.Graphics.DrawRectangle(pen, rubberBandRectangle);
                }
            }

            if (validSelectionRectangle != Rectangle.Empty)
            {
                using (var pen = new Pen(Color.Green, 2))
                {
                    e.Graphics.DrawRectangle(pen, validSelectionRectangle);
                }
            }
        }

        // Helper method to find candlesticks in the rectangle
        // Returns a list of indices of candlesticks that are within a given rectangle
        private List<int> GetCandlesticksInRectangle(Rectangle rectangle)
        {
            // Initialize an empty list to store the indices of the selected candlesticks
            var selectedCandlestickIndexes = new List<int>();

            // Iterate through each point in the chart series
            for (int i = 0; i < candleStick_chart.Series["Series_ohlc"].Points.Count; i++)
            {
                // Get the current point
                var point = candleStick_chart.Series["Series_ohlc"].Points[i];

                // Convert the point's X and Y values to pixel positions on the chart
                var pointX = candleStick_chart.ChartAreas["AreaOHLC"].AxisX.ValueToPixelPosition(point.XValue);
                var pointY = candleStick_chart.ChartAreas["AreaOHLC"].AxisY.ValueToPixelPosition(point.YValues[0]);

                // Check if the point is within the given rectangle
                if (rectangle.Contains((int)pointX, (int)pointY))
                {
                    // If the point is within the rectangle, add its index to the list of selected candlesticks
                    selectedCandlestickIndexes.Add(i);
                }
            }

            // Return the list of indices of the selected candlesticks
            return selectedCandlestickIndexes;
        }

        // Shades the selected wave on the chart and calculates its beauty score
        private void ShadeSelectedWave(int firstIndex, int secondIndex)
        {
            // Reset any previous highlights and clear annotations
            ResetHighlights();
            candleStick_chart.Annotations.Clear(); // Clear previous annotations

            // Get the start and end prices for the selected wave
            var startPrice = tmp[firstIndex].low;
            var endPrice = tmp[secondIndex].high;

            // Compute Fibonacci levels for the selected wave
            var fibonacciLevels = ComputeFibonacciLevels(startPrice, endPrice);
            currentFibonacciLevels = fibonacciLevels; // Store for Paint event

            // Draw Fibonacci annotations on the chart
            DrawFibonacciAnnotations(fibonacciLevels);

            int totalBeauty = 0;

            // Highlight the selected candlesticks and calculate their beauty score
            for (int i = firstIndex; i <= secondIndex; i++)
            {
                // Highlight the current candlestick
                HighlightCandlestick(i, Color.Yellow);

                // Get the current candlestick
                var candle = tmp[i];

                // Calculate the beauty score for the current candlestick
                int beauty = CalculateBeauty(candle, fibonacciLevels);

                // Add the beauty score to the total
                totalBeauty += beauty;
            }

            // Update the beauty score label with the total beauty score
            beautyscore.Text = $"Total Beauty Score: {totalBeauty}";

            // Compute extended beauty scores for the selected wave
            ComputeExtendedBeauty(startPrice, endPrice, firstIndex, secondIndex);
        }

        // Computes extended beauty scores for a given wave
        private void ComputeExtendedBeauty(decimal startPrice, decimal endPrice, int firstIndex, int secondIndex)
        {
            // Calculate the range of the wave
            decimal range = endPrice - startPrice;

            // Calculate the extension of the wave (25% of the wave height)
            decimal extension = range * 0.25m;

            // Initialize a list to store the beauty scores for each extended price
            List<(decimal price, int beauty)> beautyScores = new List<(decimal, int)>();

            // Compute beauty scores for each extended price
            for (decimal extendedEndPrice = startPrice; extendedEndPrice >= startPrice - extension; extendedEndPrice -= 5)
            {
                // Compute Fibonacci levels for the extended price
                var fibonacciLevels = ComputeFibonacciLevels(extendedEndPrice, endPrice);

                // Initialize the total beauty score for the current extended price
                int totalBeauty = 0;

                // Calculate the beauty score for each candlestick in the wave
                for (int i = firstIndex; i <= secondIndex; i++)
                {
                    // Get the current candlestick
                    var candle = tmp[i];

                    // Calculate the beauty score for the current candlestick
                    totalBeauty += CalculateBeauty(candle, fibonacciLevels);
                }

                // Add the beauty score for the current extended price to the list
                beautyScores.Add((extendedEndPrice, totalBeauty));
            }

            // Plot the beauty scores for each extended price
            PlotBeautyScores(beautyScores);
        }

        // Plots the beauty scores for a given list of scores
        private void PlotBeautyScores(List<(decimal price, int beauty)> beautyScores)
        {
            // Check if there are any beauty scores to plot
            if (!beautyScores.Any())
            {
                // Display an error message if there are no beauty scores
                MessageBox.Show("No beauty scores available to plot.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Define the name of the beauty series and chart area
            string beautySeriesName = "BeautyScores";
            string beautyChartAreaName = "beauty";

            // Check if the beauty chart area exists
            var beautyChartArea = candleStick_chart.ChartAreas.FindByName(beautyChartAreaName);
            if (beautyChartArea == null)
            {
                // Create a new chart area if it does not exist
                beautyChartArea = new ChartArea(beautyChartAreaName)
                {
                    // Set the position of the chart area
                    Position = new ElementPosition(0, 70, 100, 30),
                    // Set the title of the X-axis
                    AxisX = { Title = "Price" },
                    // Set the title of the Y-axis
                    AxisY = { Title = "Beauty Score" }
                };
                // Add the chart area to the chart
                candleStick_chart.ChartAreas.Add(beautyChartArea);
            }

            // Check if the beauty series already exists
            Series beautySeries;
            if (candleStick_chart.Series.IndexOf(beautySeriesName) >= 0)
            {
                // Get the existing beauty series
                beautySeries = candleStick_chart.Series[beautySeriesName];
                // Clear the points in the series
                beautySeries.Points.Clear();
            }
            else
            {
                // Create a new beauty series if it does not exist
                beautySeries = new Series
                {
                    // Set the name of the series
                    Name = beautySeriesName,
                    // Set the chart type to column
                    ChartType = SeriesChartType.Column,
                    // Set the X-value type to double
                    XValueType = ChartValueType.Double,
                    // Set the Y-value type to int32
                    YValueType = ChartValueType.Int32,
                    // Set the chart area for the series
                    ChartArea = beautyChartAreaName,
                    // Set the border width
                    BorderWidth = 2,
                    // Set the color of the series
                    Color = Color.Blue
                };
                // Add the series to the chart
                candleStick_chart.Series.Add(beautySeries);
            }

            // Set the point width to make the bars thinner
            beautySeries["PointWidth"] = "0.5"; // Adjust this value to control the width

            // Add data points to the beauty series
            foreach (var score in beautyScores)
            {
                // Add a point to the series with the price and beauty score
                beautySeries.Points.AddXY((double)score.price, score.beauty);
            }

            // Configure the axes of the beauty chart area
            beautyChartArea.AxisX.Minimum = (double)beautyScores.Min(bs => bs.price) * 0.95;
            beautyChartArea.AxisX.Maximum = (double)beautyScores.Max(bs => bs.price) * 1.05;
            beautyChartArea.AxisY.Minimum = 0;
            beautyChartArea.AxisY.Maximum = beautyScores.Max(bs => bs.beauty) + 1;
        }

        // Displays the beauty scores in a message box
        private void DisplayBeautyScores(List<(decimal price, int beauty)> beautyScores)
        {
            // Create a string builder to build the message
            StringBuilder sb = new StringBuilder("Beauty Scores as Function of Price:\n");
            // Iterate over the beauty scores and add them to the message
            foreach (var score in beautyScores)
            {
                sb.AppendLine($"Price: {score.price}, Beauty: {score.beauty}");
            }
            // Display the message box
            MessageBox.Show(sb.ToString(), "Beauty Scores");
        }

        // Computes the Fibonacci levels for a given start and end price
        private Dictionary<string, decimal> ComputeFibonacciLevels(decimal startPrice, decimal endPrice)
        {
            // Calculate the range of the prices
            decimal range = endPrice - startPrice;
            // Create a dictionary to store the Fibonacci levels
            return new Dictionary<string, decimal>
    {
        // Add the 0% level (start price)
        { "0%", startPrice },
        // Add the 23.6% level
        { "23.6%", startPrice + range * 0.236m },
        // Add the 38.2% level
        { "38.2%", startPrice + range * 0.382m },
        // Add the 50% level
        { "50%", startPrice + range * 0.5m },
        // Add the 61.8% level
        { "61.8%", startPrice + range * 0.618m },
        // Add the 100% level (end price)
        { "100%", endPrice }
    };
        }

        // Draws Fibonacci annotations on the chart for a given set of Fibonacci levels
        private void DrawFibonacciAnnotations(Dictionary<string, decimal> fibonacciLevels)
        {
            // Clear any previous annotations from the chart
            candleStick_chart.Annotations.Clear();

            // Iterate over each Fibonacci level
            foreach (var level in fibonacciLevels)
            {
                // Create a new horizontal line annotation for the current Fibonacci level
                var line = new HorizontalLineAnnotation
                {
                    // Set the X-axis for the annotation to the chart's X-axis
                    AxisX = candleStick_chart.ChartAreas["AreaOHLC"].AxisX,
                    // Set the Y-axis for the annotation to the chart's Y-axis
                    AxisY = candleStick_chart.ChartAreas["AreaOHLC"].AxisY,
                    // Set the Y-coordinate of the annotation to the value of the current Fibonacci level
                    Y = (double)level.Value,
                    // Set the color of the annotation line to black
                    LineColor = Color.Black,
                    // Set the thickness of the annotation line to 2 pixels
                    LineWidth = 2,
                    // Set the dash style of the annotation line to dotted
                    LineDashStyle = ChartDashStyle.Dot,
                    // Clip the annotation to the "AreaOHLC" chart area
                    ClipToChartArea = "AreaOHLC",
                    // Make the annotation infinite (i.e., it will extend across the entire chart)
                    IsInfinitive = true
                };
                // Add the annotation to the chart
                candleStick_chart.Annotations.Add(line);

                // Note: Labels for the Fibonacci levels are now handled in the Paint event
            }
        }

        // Calculates the "beauty" of a candlestick based on its proximity to Fibonacci levels
        private int CalculateBeauty(smartCandleStick candle, Dictionary<string, decimal> fibonacciLevels)
        {
            // Initialize the beauty score to 0
            int beauty = 0;

            // Iterate over each Fibonacci level
            foreach (var level in fibonacciLevels.Values)
            {
                // Check if the open, high, low, or close price of the candlestick is close to the current Fibonacci level
                if (IsClose(candle.open, level) || IsClose(candle.high, level) || IsClose(candle.low, level) || IsClose(candle.close, level))
                {
                    // If the price is close to the level, increment the beauty score
                    beauty++;
                }
            }
            // Return the total beauty score
            return beauty;
        }

        // Checks if a value is close to a target value within a specified tolerance
        private bool IsClose(decimal value, decimal target, decimal tolerance = 0.01m)
        {
            // Calculate the absolute difference between the value and the target
            // If the difference is less than or equal to the tolerance, return true
            return Math.Abs(value - target) <= tolerance;
        }
    }
}