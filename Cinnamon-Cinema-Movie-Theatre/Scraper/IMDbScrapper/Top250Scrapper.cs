using System.Text;
using Microsoft.AspNetCore.Mvc;
using PuppeteerSharp;

namespace Cinnamon_Cinema_Movie_Theatre.Scraper.IMDbScrapper;

public class Top250Scrapper
{
    public static async Task<IActionResult> Index()
    {
        const string fullUrl = "https://www.imdb.com/chart/top";

        var options = new LaunchOptions
        {
            Headless = true,
            ExecutablePath = "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe"
        };

        var browser = await Puppeteer.LaunchAsync(options);
        var page = await browser.NewPageAsync();
        await page.GoToAsync(fullUrl);

        const string links = @"Array.from(document.querySelectorAll('li:not([class^=""toc""]) a')).map(a => a.href);";
        var urls = await page.EvaluateExpressionAsync<string[]>(links);

        var programmerLinks = urls.ToList();

        WriteToCsv(programmerLinks);

        return View();
    }

    private static IActionResult View()
    {
        throw new NotImplementedException();
    }

    private static void WriteToCsv(List<string> links)
    {
        var sb = new StringBuilder();
        foreach (var link in links)
        {
            sb.AppendLine(link);
        }

        File.WriteAllText("top_250_csharp.csv", sb.ToString());
    }
}