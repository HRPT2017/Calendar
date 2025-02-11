using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Calendar.Database;
using HtmlAgilityPack;

namespace Calendar.Models
{
    internal class ModalityCompetitionScrapper
    {
        private readonly HttpClient _httpClient;
        DataContext context = new DataContext();
        public ModalityCompetitionScrapper()
        {
            _httpClient = new HttpClient();

        }
        public async Task<string> ScrapeDataAsync()
        {
            string url = "https://portal.fpak.pt/site/races";

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
                                        var checkBadge= context.Competition.FirstOrDefault(m => m.badge == badge);
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
