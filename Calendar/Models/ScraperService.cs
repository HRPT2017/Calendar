using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Net.Http;
using System.Windows.Documents;
using Calendar.Database;
using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Calendar.Models
{
    public class ScraperService
    {
        private readonly HttpClient _httpClient;
        DataContext context = new DataContext();
        private const string url = "https://portal.fpak.pt/site/races";
        private const string calendarUrl = "https://www.fpak.pt/calendario?d=now";

        public ScraperService()
        {
            _httpClient = new HttpClient();


        }

        public async Task<string> ScrapeCalendarData()
        {

            // Use HttpClient to fetch HTML
            using (var httpClient = new HttpClient())
            {
                // Set a user-agent to mimic a browser
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");

                try
                {
                    string html = await httpClient.GetStringAsync(calendarUrl);
                    var htmlDocument = new HtmlDocument();
                    htmlDocument.LoadHtml(html);
                    var eventNodes = htmlDocument.DocumentNode.SelectNodes("//div[contains(@class, 'col-md-6') and contains(@class, 'col-lg-4') and contains(@class, 'col-xl-3')]");

                    if (eventNodes != null)
                    {
                        foreach (var node in eventNodes)
                        {
                            string? dateRange = node.SelectSingleNode(".//div[@class='date hidden']")?.GetAttributeValue("data-date", "").Trim();
                            string[] parts = dateRange != null ? dateRange.Split(" - ") : [];
                            long timestamp1 = long.Parse(parts[0]);
                            DateTime? endDate = null;

                            if (parts.Length > 1)
                            {
                                long timestamp2 = long.Parse(parts[1]);
                                endDate = DateTimeOffset.FromUnixTimeSeconds(timestamp2).UtcDateTime;

                            }
                            DateTime startDate = DateTimeOffset.FromUnixTimeSeconds(timestamp1).UtcDateTime;
                            string? eventName = node.SelectSingleNode(".//div[contains(@class, 'corpo')]//a")?.InnerText.Trim();
                            var badges = node.SelectNodes(".//span[contains(@class, 'badge-success')]");
                            var checkEvent = context.Event.FirstOrDefault(e => e.name == eventName);
                            if (badges != null)
                            {
                                var competition = context.Competition.FirstOrDefault(c => c.badge == badges[0].InnerText.Trim());
                                if (competition != null)
                                {
                                    
                                    var eventId = 0;
                                    if (checkEvent == null)
                                    {
                                        var event_ = new Event()
                                        {
                                            endDate = endDate,
                                            startDate = startDate,
                                            name = eventName ?? "",
                                            modalityId = competition.modalityId
                                        };
                                        context.Event.Add(event_);
                                        context.SaveChanges();
                                        eventId = event_.id;
                                    }
                                    else
                                    {
                                        eventId = checkEvent.id;
                                        Event events = context.Event.First(c => c.id == eventId);

                                        events.name = eventName ?? "";
                                        events.startDate = startDate;
                                        events.endDate = endDate;
                                        events.modalityId = competition.modalityId;

                                        context.Update(events);
                                        context.SaveChanges();
                                        

                                    }


                                    foreach (var badge in badges)
                                    {
                                        var checkCompetition = context.Competition.FirstOrDefault(c => c.badge == badge.InnerText.Trim());
                                        if (checkCompetition != null)
                                        {
                                            var checkEC = context.EventCompetition.FirstOrDefault(ec => ec.competitionId == checkCompetition.id && ec.eventId == eventId);
                                            if (checkEC == null)
                                            {
                                                var eventCompetition = new EventCompetition()
                                                {
                                                    competitionId = checkCompetition.id,
                                                    eventId = eventId
                                                };
                                                context.EventCompetition.Add(eventCompetition);
                                                context.SaveChanges();
                                            }
                                        }
                                    }

                                }
                            }
                            else
                            {
                                if (checkEvent == null) 
                                {
                                    var event_ = new Event()
                                    {
                                        endDate = endDate,
                                        startDate = startDate,
                                        name = eventName ?? "",
                                        modalityId = 55
                                    };
                                    context.Event.Add(event_);
                                    context.SaveChanges();
                                }
                                else
                                {
                                    Event events = context.Event.First(c => c.id == checkEvent.id);
                                    events.name = eventName ?? "";
                                    events.startDate = startDate;
                                    events.endDate = endDate;
                                    events.modalityId = 55;
                                    context.Update(events);
                                    context.SaveChanges();
                                }

                            }
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
        public async Task<string> ScrapeMCData()
        {
            using (var httpClient = new HttpClient())
            {

                httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");

                try
                {
                    string html = await httpClient.GetStringAsync(url);
                    var htmlDocument = new HtmlDocument();
                    htmlDocument.LoadHtml(html);

                    var eventNodes = htmlDocument.DocumentNode.SelectNodes("//div[contains(@class, 'legenda')]");
                    var tables = htmlDocument.DocumentNode.SelectNodes("//div[@class='legenda']/table");

                    if (tables != null)
                    {
                        foreach (var table in tables)
                        {
                            var titleNode = table.SelectSingleNode(".//thead//td[@class='title']");
                            string title = titleNode != null ? titleNode.InnerText.Trim() : "No title found";
                            var checkTitle = context.Modality.FirstOrDefault(m => m.name == title);
                            var modalityId = 0;
                            if (checkTitle == null)
                            {
                                var modality = new Modality()
                                {
                                    name = title
                                };
                                context.Modality.Add(modality);
                                context.SaveChanges();
                                modalityId = modality.id;
                            }
                            else
                            {
                                modalityId = checkTitle.id;
                            }



                            var rows = table.SelectNodes(".//tr[position()>1]");

                            if (rows != null)
                            {

                                foreach (var row in rows)
                                {
                                    var columns = row.SelectNodes("td");
                                    if (columns != null && columns.Count == 2)
                                    {
                                        string badge = columns[0].InnerText.Trim();
                                        string name = columns[1].InnerText.Trim();
                                        var checkBadge = context.Competition.FirstOrDefault(m => m.badge == badge);
                                        if (checkBadge == null)
                                        {
                                            var competition = new Competition()
                                            {
                                                name = name,
                                                badge = badge,
                                                modalityId = modalityId,

                                            };
                                            context.Competition.Add(competition);
                                            context.SaveChanges();
                                        }
                                        else
                                        {
                                            continue;
                                        }

                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Debug.WriteLine("No tables found in the container.");
                    }

                    return "value";
                }
                catch (Exception ex)
                {

                    Debug.WriteLine($"Error: {ex.Message}");
                    return "erro";
                }
            }
        }
    }
}
