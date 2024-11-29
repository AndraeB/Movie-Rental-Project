using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace MovieRentalProject
{
    public partial class ReportsForm : Form
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["MovieRental"].ConnectionString;

        public ReportsForm()
        {
            InitializeComponent();
            ConfigureReportsGrid();
        }

        private void ConfigureReportsGrid()
        {
            reportsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            reportsGrid.AllowUserToAddRows = false;
            reportsGrid.AllowUserToDeleteRows = false;
            reportsGrid.ReadOnly = true;
            reportsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            reportsGrid.RowHeadersVisible = false;
            reportsGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            reportsGrid.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;

            reportsGrid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Make the grid more visually appealing
            reportsGrid.BackgroundColor = Color.White;
            reportsGrid.BorderStyle = BorderStyle.None;
            reportsGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            reportsGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            reportsGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            reportsGrid.GridColor = Color.LightGray;
            reportsGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            reportsGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            var menuForm = new MenuForm();
            menuForm.Show();
            this.Hide();
        }

        private void ReportSelector_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            if (ReportSelector.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a report type.");
                return;
            }

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string reportType = ReportSelector.SelectedItem?.ToString() ?? string.Empty;
                    string query = GetReportQuery(reportType);

                    using (var adapter = new SqlDataAdapter(query, conn))
                    {
                        var dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        reportsGrid.DataSource = dataTable;
                        FormatGridViewColumns(reportType);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report: {ex.Message}");
            }
        }

        private void FormatGridViewColumns(string reportType)
        {
            foreach (DataGridViewColumn column in reportsGrid.Columns)
            {
                // Improved header text formatting
                string headerText = column.Name.Replace("_", " ");

                // Add spaces before capital letters
                headerText = System.Text.RegularExpressions.Regex.Replace(
                    headerText,
                    "([a-z])([A-Z])",
                    "$1 $2"
                );

                column.HeaderText = System.Globalization.CultureInfo.CurrentCulture
                    .TextInfo.ToTitleCase(headerText.ToLower());

                // Set column styles based on content type
                switch (column.HeaderText)
                {
                    case var h when h.Contains("Revenue") || h.Contains("Price") || h.Contains("Fee"):
                        column.DefaultCellStyle.Format = "C2";
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        column.DefaultCellStyle.ForeColor = Color.DarkGreen;
                        break;

                    case var h when h.Contains("Rate") || h.Contains("Percentage"):
                        column.DefaultCellStyle.Format = "0.0\\%";
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        break;

                    case var h when h.Contains("Rating"):
                        column.DefaultCellStyle.Format = "0.0";
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;

                    case var h when h.Contains("Count") || h.Contains("Copies"):
                        column.DefaultCellStyle.Format = "N0";
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        break;
                }

                // Adjust column widths based on content
                switch (column.HeaderText)
                {
                    case var h when h.Contains("Name") || h.Contains("Genres"):
                        column.MinimumWidth = 150;
                        break;
                    case var h when h.Contains("Recommendation") || h.Contains("Suggestion"):
                        column.MinimumWidth = 200;
                        column.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        break;
                    default:
                        column.MinimumWidth = 100;
                        break;
                }
            }

            // Apply report-specific formatting
            switch (reportType)
            {
                case "Movie Performance":
                    ApplyMoviePerformanceFormatting();
                    break;
                case "Inventory Analysis":
                    ApplyInventoryAnalysisFormatting();
                    break;
                case "Pricing Suggestions":
                    ApplyPricingFormatting();
                    break;
            }
        }

        private void ApplyPricingFormatting()
        {
            foreach (DataGridViewRow row in reportsGrid.Rows)
            {
                if (row.Cells["PricingSuggestion"].Value != DBNull.Value)
                {
                    string suggestion = row.Cells["PricingSuggestion"].Value.ToString();

                    switch (suggestion)
                    {
                        case "Consider price reduction":
                            row.DefaultCellStyle.BackColor = Color.MistyRose;
                            row.DefaultCellStyle.ForeColor = Color.DarkRed;
                            break;
                        case "Potential to increase price":
                            row.DefaultCellStyle.BackColor = Color.Honeydew;
                            row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                            break;
                    }
                }
            }
        }

        private void ApplyMoviePerformanceFormatting()
        {
            foreach (DataGridViewRow row in reportsGrid.Rows)
            {
                if (row.Cells["TotalRentals"].Value != DBNull.Value &&
                    row.Cells["AvgRating"].Value != DBNull.Value)
                {
                    int rentals = Convert.ToInt32(row.Cells["TotalRentals"].Value);
                    float rating = Convert.ToSingle(row.Cells["AvgRating"].Value);

                    if (rentals > 10 && rating >= 4.0)
                    {
                        row.DefaultCellStyle.BackColor = Color.Honeydew;
                        row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                    }
                    else if (rentals < 5 || rating < 3.0)
                    {
                        row.DefaultCellStyle.BackColor = Color.MistyRose;
                        row.DefaultCellStyle.ForeColor = Color.DarkRed;
                    }
                }
            }
        }

        private void ApplyInventoryAnalysisFormatting()
        {
            foreach (DataGridViewRow row in reportsGrid.Rows)
            {
                if (row.Cells["UtilizationRate"].Value != DBNull.Value)
                {
                    float rate = Convert.ToSingle(row.Cells["UtilizationRate"].Value);

                    if (rate > 80)
                    {
                        row.DefaultCellStyle.BackColor = Color.MistyRose;
                        row.DefaultCellStyle.ForeColor = Color.DarkRed;
                    }
                    else if (rate < 20)
                    {
                        row.DefaultCellStyle.BackColor = Color.LemonChiffon;
                        row.DefaultCellStyle.ForeColor = Color.DarkGoldenrod;
                    }
                }
            }
        }

        private static string GetReportQuery(string reportType)
        {
            return reportType switch
            {
                "Movie Performance" => @"
                        SELECT 
                            m.MovieName,
                            COUNT(o.OrderID) AS TotalRentals,
                            SUM(m.DistributionFee) AS Revenue,
                            AVG(CAST(mr.Rating AS FLOAT)) AS AvgRating,
                            m.NumOfCopies AS AvailableCopies,
                            CAST(SUM(m.DistributionFee) / m.NumOfCopies AS DECIMAL(10,2)) AS RevenuePerCopy,
                            CAST(COUNT(o.OrderID) AS FLOAT) / 
                                NULLIF(DATEDIFF(DAY, MIN(o.CheckoutDateTime), GETDATE()), 0) * 30 AS MonthlyRentalRate,
                            (SELECT COUNT(*) FROM Ordr o2 
                             WHERE o2.MovieName = m.MovieName 
                             AND o2.ReturnDateTime IS NULL) AS CurrentlyRented
                        FROM Movie m
                        LEFT JOIN Ordr o ON m.MovieName = o.MovieName
                        LEFT JOIN Movie_Rating mr ON mr.MovieID = m.MovieID
                        GROUP BY m.MovieID, m.MovieName, m.NumOfCopies
                        ORDER BY TotalRentals DESC",

                "Inventory Analysis" => @"
                        SELECT 
                            m.MovieName,
                            m.NumOfCopies,
                            COUNT(o.OrderID) AS CurrentRentals,
                            COUNT(q.CustomerID) AS QueueLength,
                            CAST(COUNT(o.OrderID) AS FLOAT) / NULLIF(m.NumOfCopies, 0) * 100 AS UtilizationRate,
                            AVG(DATEDIFF(DAY, o.CheckoutDateTime, o.ReturnDateTime)) AS AvgRentalDuration,
                            CASE 
                                WHEN CAST(COUNT(o.OrderID) AS FLOAT) / NULLIF(m.NumOfCopies, 0) > 0.8 
                                THEN 'Consider adding copies'
                                WHEN CAST(COUNT(o.OrderID) AS FLOAT) / NULLIF(m.NumOfCopies, 0) < 0.2 
                                THEN 'Consider reducing copies'
                                ELSE 'Stock level optimal'
                            END AS Recommendation
                        FROM Movie m
                        LEFT JOIN Ordr o ON m.MovieName = o.MovieName AND o.ReturnDateTime IS NULL
                        LEFT JOIN Queue_up q ON m.MovieID = q.MovieID
                        GROUP BY m.MovieID, m.MovieName, m.NumOfCopies
                        ORDER BY UtilizationRate DESC",

                "Revenue-Time Analysis" => @"
                        WITH MonthlyRevenue AS (
                            SELECT 
                                DATEPART(year, o.CheckoutDateTime) AS Year,
                                DATEPART(month, o.CheckoutDateTime) AS Month,
                                DATENAME(month, o.CheckoutDateTime) AS MonthName,
                                COUNT(*) AS TotalRentals,
                                SUM(m.DistributionFee) AS Revenue
                            FROM Ordr o
                            JOIN Movie m ON o.MovieName = m.MovieName
                            GROUP BY 
                                DATEPART(year, o.CheckoutDateTime),
                                DATEPART(month, o.CheckoutDateTime),
                                DATENAME(month, o.CheckoutDateTime)
                        )
                        SELECT 
                            Year,
                            MonthName,
                            TotalRentals,
                            Revenue,
                            LAG(Revenue) OVER (ORDER BY Year, Month) AS PrevMonthRevenue,
                            CASE 
                                WHEN LAG(Revenue) OVER (ORDER BY Year, Month) > 0 
                                THEN ((Revenue - LAG(Revenue) OVER (ORDER BY Year, Month)) / 
                                    LAG(Revenue) OVER (ORDER BY Year, Month)) * 100
                                ELSE 0 
                            END AS MonthlyGrowthRate
                        FROM MonthlyRevenue
                        ORDER BY Year, Month",

                "Pricing Suggestions" => @"
                        WITH MovieStats AS (
                            SELECT 
                                m.MovieName,
                                m.MovieType,
                                m.DistributionFee AS CurrentPrice,
                                AVG(m2.DistributionFee) AS AvgGenrePrice,
                                COUNT(o.OrderID) AS RentalCount,
                                AVG(CAST(mr.Rating AS FLOAT)) AS AvgRating
                            FROM Movie m
                            LEFT JOIN Movie m2 ON m.MovieType = m2.MovieType
                            LEFT JOIN Ordr o ON m.MovieName = o.MovieName
                            LEFT JOIN Movie_Rating mr ON m.MovieID = mr.MovieID
                            GROUP BY m.MovieID, m.MovieName, m.MovieType, m.DistributionFee
                        )
                        SELECT 
                            MovieName,
                            MovieType,
                            CurrentPrice,
                            AvgGenrePrice,
                            RentalCount,
                            AvgRating,
                            CASE 
                                WHEN RentalCount < 5 AND CurrentPrice > AvgGenrePrice 
                                THEN 'Consider price reduction'
                                WHEN RentalCount > 20 AND CurrentPrice < AvgGenrePrice 
                                THEN 'Potential to increase price'
                                ELSE 'Price is optimal'
                            END AS PricingSuggestion
                        FROM MovieStats
                        ORDER BY RentalCount DESC",

                "Actor Popularity Analysis" => @"
                    WITH ActorStats AS (
                        SELECT 
                            a.FirstName + ' ' + a.LastName AS ActorName,
                            COUNT(DISTINCT ai.MovieID) AS MovieCount,
                            AVG(CAST(ar.Rating AS FLOAT)) AS AvgRating,
                            COUNT(o.OrderID) AS TotalRentals,
                            SUM(m.DistributionFee) AS TotalRevenue,
                            -- Modified to remove duplicates and clean up formatting
                            (SELECT DISTINCT STUFF(
                                (SELECT DISTINCT ', ' + RTRIM(MovieType)
                                FROM (SELECT DISTINCT MovieType
                                    FROM Movie m2
                                    JOIN Appears_in ai2 ON m2.MovieID = ai2.MovieID
                                    WHERE ai2.ActorID = a.ActorID) t
                                FOR XML PATH('')), 1, 2, ''
                            )) AS TopGenres
                        FROM Actor a
                        LEFT JOIN Appears_in ai ON a.ActorID = ai.ActorID
                        LEFT JOIN Movie m ON ai.MovieID = m.MovieID
                        LEFT JOIN Ordr o ON m.MovieName = o.MovieName
                        LEFT JOIN Actor_Rating ar ON a.ActorID = ar.ActorID
                        GROUP BY a.ActorID, a.FirstName, a.LastName
                    )
                    SELECT 
                        ActorName,
                        MovieCount,
                        AvgRating,
                        TotalRentals,
                        TotalRevenue,
                        TopGenres,
                        CASE 
                            WHEN TotalRentals > 100 AND AvgRating >= 4 THEN 'High Performer'
                            WHEN TotalRentals > 50 AND AvgRating >= 3.5 THEN 'Good Performer'
                            ELSE 'Average Performer'
                        END AS PerformanceCategory
                    FROM ActorStats
                    ORDER BY TotalRentals DESC, AvgRating DESC",

                _ => throw new ArgumentException("Invalid report type")
            };
        }

        // Not needed unless we decide to handle cell clicks later, but I'll keep it here for now
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
