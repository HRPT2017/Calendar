using System.Diagnostics;
using System.Net.Http;
using HtmlAgilityPack;

namespace Calendar.Models
{
    public class CalendarScraper
    {
        private readonly HttpClient _httpClient;

        public CalendarScraper()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> ScrapeDataAsync()
        {
            string url = "https://www.fpak.pt/calendario?d=now";
            // Use HttpClient to fetch HTML
            using (var httpClient = new HttpClient())
            {
                // Set a user-agent to mimic a browser
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");

                try
                {
                    // Get HTML content
                    string html = await httpClient.GetStringAsync(url);

                    // Load HTML into HtmlDocument
                    var htmlDocument = new HtmlDocument();
                    htmlDocument.LoadHtml(html);

                    // Use XPath to select event nodes
                    var eventNodes = htmlDocument.DocumentNode.SelectNodes("//div[contains(@class, 'col-md-6') and contains(@class, 'col-lg-4') and contains(@class, 'col-xl-3')]");

                    if (eventNodes != null)
                    {
                        foreach (var node in eventNodes)
                        {
                            // Extract date range
                            string? dateRange = node.SelectSingleNode(".//div[@class='date hidden']")?.GetAttributeValue("data-date", "").Trim();

                            // Extract start and end dates
                            string? startDate = node.SelectSingleNode(".//div[@class='m-0 data-inicio']//span[@class='date-display-range']/b")?.InnerText.Trim();
                            string? endDate = node.SelectSingleNode(".//div[@class='data-fim border-top pt-1']//span[@class='date-display-range']/b")?.InnerText.Trim();
                            string? endMonth = node.SelectSingleNode(".//div[@class='data-fim border-top pt-1']//span[@class='date-display-range']")?.InnerText.Trim();

                            // Extract event name
                            string? eventName = node.SelectSingleNode(".//div[contains(@class, 'corpo')]//a")?.InnerText.Trim();

                            // Extract badge (e.g., "OPK")
                            string? badge = node.SelectSingleNode(".//span[contains(@class, 'badge')]")?.InnerText.Trim();

                            // Print the extracted data
                            Debug.WriteLine($"Date Range (Unix Timestamps): {dateRange}");
                            Debug.WriteLine($"Start Date: {startDate}");
                            Debug.WriteLine($"End Date: {endDate} {endMonth}");
                            Debug.WriteLine($"Event Name: {eventName}");
                            Debug.WriteLine($"Badge: {badge}");
                            Debug.WriteLine(new string('-', 50)); // Separator
                        }
                    }
                    else
                    {
                        Debug.WriteLine("No events found.");
                    }
                 return "value";
                }
                catch (Exception ex)
                {

                    Console.WriteLine($"Error: {ex.Message}");
                    return "erro";
                }
            }
        }
    
    }
}
