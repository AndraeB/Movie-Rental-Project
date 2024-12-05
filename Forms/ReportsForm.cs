using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MovieRentalProject
{
    public partial class ReportsForm : Form
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["MovieRental"].ConnectionString;

        // Dictionary to store filter configurations for each report type
        private readonly Dictionary<string, (string Label1, string[] Options1, string Label2, string[] Options2, string Label3, string[] Options3)> reportFilters = new()
        {
            {
                "Movie Performance",
                (
                    "Genre",
                    new[] { "All Genres", "Action", "Romance", "Drama", "Sci-Fi", "Horror", "Animation" },
                    "Rating",
                    new[] { "All Ratings", "4+ Stars", "3-4 Stars", "Below 3 Stars" },
                    "Performance",
                    new[] { "All Performance", "High Rentals", "Low Rentals", "High Revenue", "Low Revenue" }
                )
            },
            {
                "Inventory Analysis",
                (
                    "Genre",
                    new[] { "All Genres", "Action", "Romance", "Drama", "Sci-Fi", "Horror", "Animation" },
                    "Utilization",
                    new[] { "All Utilization", "High (>80%)", "Medium (40-80%)", "Low (<40%)" },
                    "Queue Status",
                    new[] { "All Queue Status", "High Demand", "Low Demand" }
                )
            },
            {
                "Pricing Suggestions",
                (
                    "Genre",
                    new[] { "All Genres", "Action", "Romance", "Drama", "Sci-Fi", "Horror", "Animation" },
                    "Price Range",
                    new[] { "All Prices", "Above Average", "Below Average" },
                    "Recommendation",
                    new[] { "All Recommendations", "Price Reduction", "Price Increase", "Optimal" }
                )
            },
            {
                "Actor Popularity Analysis",
                (
                    "Performance",
                    new[] { "All Performance", "High Performer", "Good Performer", "Average Performer" },
                    "Genre",
                    new[] { "All Genres", "Action", "Romance", "Drama", "Sci-Fi", "Horror", "Animation" },
                    "Movie Count",
                    new[] { "All Movies", "3+ Movies", "2 Movies", "1 Movie" }
                )
            }
        };

        public ReportsForm()
        {
            InitializeComponent();
            ConfigureReportsGrid();
            InitalizeFilterComboBoxes();
        }

        private void InitalizeFilterComboBoxes()
        {
            // Clear any existing items
            filterComboBox1.Items.Clear();
            filterComboBox2.Items.Clear();
            filterComboBox3.Items.Clear();

            // Set default selected indices
            filterComboBox1.SelectedIndex = -1;
            filterComboBox2.SelectedIndex = -1;
            filterComboBox3.SelectedIndex = -1;
        }

        private void FilterComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle filter changes if needed
        }

        private void FilterComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle filter changes if needed
        }

        private void FilterComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle filter changes if needed
        }

        private void ReportSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedReport = ReportSelector.SelectedItem?.ToString() ?? string.Empty;

            // Check if the selected report type has filters
            bool hasFilters = reportFilters.ContainsKey(selectedReport);
            filterToggleButton.Visible = hasFilters;
            filterPanel.Visible = hasFilters && filterToggleButton.Text == "Hide Filters";

            if (hasFilters)
            {
                var (label1, options1, label2, options2, label3, options3) = reportFilters[selectedReport];

                // Update filter labels
                filterLabel1.Text = label1;
                filterLabel2.Text = label2;
                filterLabel3.Text = label3;

                // Update ComboBox options
                filterComboBox1.Items.Clear();
                filterComboBox1.Items.AddRange(options1);
                filterComboBox1.SelectedIndex = 0;

                filterComboBox2.Items.Clear();
                filterComboBox2.Items.AddRange(options2);
                filterComboBox2.SelectedIndex = 0;

                filterComboBox3.Items.Clear();
                filterComboBox3.Items.AddRange(options3);
                filterComboBox3.SelectedIndex = 0;
            }
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

        private void FilterToggleButton_Click(object sender, EventArgs e)
        {
            // Toggle filter panel visibility
            filterPanel.Visible = !filterPanel.Visible;
            filterToggleButton.Text = filterPanel.Visible ? "Hide Filters" : "Filters";

            // Adjust the position of the reports grid based on filter panel visibility
            reportsGrid.Location = new Point(
                reportsGrid.Location.X,
                filterPanel.Visible ? filterPanel.Bottom + 10 : filterPanel.Location.Y
            );

            // Adjust the height of the reports grid
            reportsGrid.Height = BackButton.Location.Y - reportsGrid.Location.Y - 20;
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

                    // Build filter dictionary only if filters are visible
                    var filters = new Dictionary<string, string>();
                    if (filterPanel.Visible)
                    {
                        if (filterComboBox1.SelectedIndex > 0) // Skip "All" options
                            filters.Add(filterLabel1.Text, filterComboBox1.SelectedItem.ToString());
                        if (filterComboBox2.SelectedIndex > 0)
                            filters.Add(filterLabel2.Text, filterComboBox2.SelectedItem.ToString());
                        if (filterComboBox3.SelectedIndex > 0)
                            filters.Add(filterLabel3.Text, filterComboBox3.SelectedItem.ToString());
                    }

                    string query = GetReportQuery(reportType, filters);

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
                   var suggestionCell = row.Cells["PricingSuggestion"];
        if (suggestionCell?.Value is string suggestion)
        {
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

        private static string GetReportQuery(string reportType, Dictionary<string, string> filters)
        {
            // Helper function to build the WHERE clause based on filters
            string BuildMovieWhereClause(Dictionary<string, string> filters)
            {
                var conditions = new List<string>();

                if (filters.TryGetValue("Genre", out string? genre) && !string.IsNullOrEmpty(genre) && !genre.StartsWith("All"))
                    conditions.Add($"m.MovieType = '{genre}'");

                if (filters.TryGetValue("Rating", out string? rating))
                {
                    switch (rating)
                    {
                        case "4+ Stars":
                            conditions.Add("m.Rating >= 4");
                            break;
                        case "3-4 Stars":
                            conditions.Add("m.Rating >= 3 AND m.Rating < 4");
                            break;
                        case "Below 3 Stars":
                            conditions.Add("m.Rating < 3");
                            break;
                    }
                }

                return conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";
            }

            string BuildPerformanceWhereClause(Dictionary<string, string> filters)
            {
                var conditions = new List<string>();

                if (filters.TryGetValue("Performance", out string? performance) && !string.IsNullOrEmpty(performance))
                {
                    switch (performance)
                    {
                        case "High Rentals":
                            conditions.Add("COUNT(o.OrderID) > 20");
                            break;
                        case "Low Rentals":
                            conditions.Add("COUNT(o.OrderID) < 5");
                            break;
                        case "High Revenue":
                            conditions.Add("SUM(ISNULL(m.DistributionFee, 0)) > (SELECT AVG(TotalRevenue) * 1.2 FROM (SELECT MovieID, SUM(DistributionFee) as TotalRevenue FROM Movie GROUP BY MovieID) as AvgRev)");
                            break;
                        case "Low Revenue":
                            conditions.Add("SUM(ISNULL(m.DistributionFee, 0)) < (SELECT AVG(TotalRevenue) * 0.8 FROM (SELECT MovieID, SUM(DistributionFee) as TotalRevenue FROM Movie GROUP BY MovieID) as AvgRev)");
                            break;
                    }
                }

                return conditions.Count > 0 ? "HAVING " + string.Join(" AND ", conditions) : "";
            }

            return reportType switch
            {
                "Movie Performance" => $@"
            SELECT 
                m.MovieName,
                m.MovieType,
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
            {BuildMovieWhereClause(filters)}
            GROUP BY m.MovieID, m.MovieName, m.MovieType, m.NumOfCopies
            {BuildPerformanceWhereClause(filters)}
            ORDER BY TotalRentals DESC",

                "Inventory Analysis" => $@"
            SELECT 
                m.MovieName,
                m.MovieType,
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
            {BuildMovieWhereClause(filters)}
            GROUP BY m.MovieID, m.MovieName, m.MovieType, m.NumOfCopies
            {(filters.TryGetValue("Utilization", out string? util) && !string.IsNullOrEmpty(util) && !util.StartsWith("All") ?
                $"HAVING CASE " +
                $"WHEN '{util}' LIKE '%High%' THEN UtilizationRate > 80 " +
                $"WHEN '{util}' LIKE '%Medium%' THEN UtilizationRate BETWEEN 40 AND 80 " +
                $"WHEN '{util}' LIKE '%Low%' THEN UtilizationRate < 40 END" : "")}
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

                "Pricing Suggestions" => $@"
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
                {BuildMovieWhereClause(filters)}
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
            {(filters.TryGetValue("Price Range", out string? priceRange) && !string.IsNullOrEmpty(priceRange) && !priceRange.StartsWith("All") ?
                $"WHERE {(priceRange == "Above Average" ? "CurrentPrice > AvgGenrePrice" : "CurrentPrice < AvgGenrePrice")}" : "")}
            ORDER BY RentalCount DESC",

                "Actor Popularity Analysis" => $@"
            WITH ActorStats AS (
                SELECT 
                    a.ActorID,
                    a.FirstName + ' ' + a.LastName AS ActorName,
                    COUNT(DISTINCT ai.MovieID) AS MovieCount,
                    AVG(CAST(ar.Rating AS FLOAT)) AS AvgRating,
                    COUNT(o.OrderID) AS TotalRentals,
                    SUM(m.DistributionFee) AS TotalRevenue,
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
                {BuildMovieWhereClause(filters)}
                LEFT JOIN Ordr o ON m.MovieName = o.MovieName
                LEFT JOIN Actor_Rating ar ON a.ActorID = ar.ActorID
                GROUP BY a.ActorID, a.FirstName, a.LastName
                {(filters.TryGetValue("Movie Count", out string? movieCount) && !string.IsNullOrEmpty(movieCount) && !movieCount.StartsWith("All") ?
                    $"HAVING COUNT(DISTINCT ai.MovieID) {(movieCount == "3+ Movies" ? ">= 3" :
                                        movieCount == "2 Movies" ? "= 2" : "= 1")}" : "")}
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
            {(filters.TryGetValue("Performance", out string? perf) && !string.IsNullOrEmpty(perf) && !perf.StartsWith("All") ?
                $"WHERE PerformanceCategory = '{perf}'" : "")}
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
