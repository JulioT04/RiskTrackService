using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Support.UI;
using RiskTrack.Models;
namespace RiskTrack.Util {
    public class Scraper {

        public Scraper()
        {

        }

        public List<OffshoreLeaksEntity> ScrapeOffShoreFirms(string searchTerm)
        {
            var options = new ChromeOptions();
            string userAgent = UserAgentManager.GetRandomUserAgent();
            options.AddArgument($"--user-agent={userAgent}");
            options.AddArgument("--headless"); 

            var entities = new List<OffshoreLeaksEntity>();

            using (var driver = new ChromeDriver(options))
            {
                Thread.Sleep(3000);
                driver.Navigate().GoToUrl("https://offshoreleaks.icij.org/search");

                IWebElement checkbox = driver.FindElement(By.XPath("//input[@type='checkbox' and contains(@id, 'accept')]"));
                checkbox.Click();
                //Thread.Sleep(5000);
                IWebElement submitButton = driver.FindElement(By.XPath("//button[@type='submit']"));

                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("document.querySelector('.modal.fade.show').style.display='none';");
                js.ExecuteScript("document.querySelector('.modal-backdrop').remove();");
                js.ExecuteScript("document.querySelector('.modal.fade.show').remove();");
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", submitButton);
                Thread.Sleep(5000);

                IWebElement searchBox = driver.FindElement(By.Name("q"));
                //Thread.Sleep(10000);
                searchBox.SendKeys(searchTerm);
                //Thread.Sleep(10000);
                searchBox.Submit();
                Thread.Sleep(10000);

                var results = driver.FindElements(By.CssSelector("table.table.table-sm tbody tr"));

                foreach (var result in results)
                {
                    var entity = new OffshoreLeaksEntity
                    {
                        Entity = result.FindElement(By.CssSelector("td:nth-child(1)")).Text,
                        Jurisdiction = result.FindElement(By.CssSelector("td.jurisdiction")).Text,
                        LinkedTo = result.FindElement(By.CssSelector("td.country")).Text,
                        DataFrom = result.FindElement(By.CssSelector("td.source")).Text
                    };
                    entities.Add(entity);
                }
            }

            return entities;
        }

        public List<WorldBankEntity> ScrapeWorldBankFirms(string searchTerm)
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless"); 
            var entities = new List<WorldBankEntity>();

            using (var driver = new ChromeDriver(options))
            {
                driver.Navigate().GoToUrl("https://projects.worldbank.org/en/projects-operations/procurement/debarred-firms");
                Thread.Sleep(10000);

                IWebElement searchBox = driver.FindElement(By.Id("category"));
                searchBox.SendKeys(searchTerm);
                Thread.Sleep(5000);
                
                var table = driver.FindElement(By.Id("k-debarred-firms"));
                var rows = table.FindElements(By.CssSelector("tbody tr"));

                foreach (var row in rows)
                {
                    var columns = row.FindElements(By.CssSelector("td")); 

                    var entity = new WorldBankEntity
                        {
                            FirmName = columns[0].Text,
                            Address = columns[2].Text,
                            Country = columns[3].Text,
                            FromDate = columns[4].Text,
                            ToDate = columns[5].Text,
                            Grounds = columns[6].Text
                        };

                        entities.Add(entity);
                }
            }

            return entities;
        }
        public List<OFACEntity> ScrapeOFACFirms(string searchTerm)
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless"); 
            var entities = new List<OFACEntity>();

            using (var driver = new ChromeDriver(options))
            {
                driver.Navigate().GoToUrl("https://sanctionssearch.ofac.treas.gov");
                Thread.Sleep(10000);

                IWebElement searchBox = driver.FindElement(By.Id("ctl00_MainContent_txtLastName"));
                searchBox.SendKeys(searchTerm);
                IWebElement scoreBox = driver.FindElement(By.Id("ctl00_MainContent_Slider1_Boundcontrol"));
                scoreBox.Clear();

                for(int i = 0; i < 10; i++)
                {
                    scoreBox.SendKeys(Keys.Backspace);
                }

                scoreBox.SendKeys("50");
                Thread.Sleep(2000);

                IWebElement searchButton = driver.FindElement(By.Id("ctl00_MainContent_btnSearch"));

                searchButton.Click();
                Thread.Sleep(10000);

                var table = driver.FindElement(By.Id("gvSearchResults"));

                var rows = table.FindElements(By.CssSelector("tbody tr"));

                foreach (var row in rows)
                {
                    var columns = row.FindElements(By.CssSelector("td"));

                    if (columns.Count <= 7)
                    {
                        var entity = new OFACEntity
                        {
                            Name = columns[0].Text,
                            Address = columns[1].Text,  
                            Type = columns[2].Text,
                            Programs = columns[3].Text,
                            List = columns[4].Text,
                            Score = columns[5].Text
                        };

                        entities.Add(entity);
                    }

                }
            }

            return entities;
        }
    }

    public class UserAgentManager
    {
        private static readonly List<string> userAgents = new List<string>
    {
        "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36",
        "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:91.0) Gecko/20100101 Firefox/91.0",
        "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36",
        "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36",
        "Mozilla/5.0 (X11; Ubuntu; Linux x86_64; rv:91.0) Gecko/20100101 Firefox/91.0",
        "Mozilla/5.0 (iPhone; CPU iPhone OS 15_2 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/15.2 Mobile/15E148 Safari/604.1",
        "Mozilla/5.0 (iPad; CPU OS 15_2 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/15.2 Mobile/15E148 Safari/604.1",
        "Mozilla/5.0 (Linux; Android 11; SM-G981B) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Mobile Safari/537.36",
        "Mozilla/5.0 (Linux; Android 11; Pixel 4) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Mobile Safari/537.36",
        "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:104.0) Gecko/20100101 Firefox/104.0"
    };

        public static string GetRandomUserAgent()
        {
            Random random = new Random();
            int index = random.Next(userAgents.Count);
            return userAgents[index];
        }
    }
}
