using BE;
using System;
using System.Collections.Generic;
using Newtonsoft;
using CefSharp.OffScreen;
using System.IO;
using CefSharp;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Wrapper
{
    public class FlightWrapper : IFlightSchedulesWrapper
    {
        #region consts

        const string BASE_URL = "https://www.iaa.gov.il/he-IL/airports/";
        const string PATH_URL = "/Pages/OnlineFlights.aspx";

        #endregion

        private static ChromiumWebBrowser _browser;


        public FlightWrapper(string p_airportPage)
        {
            initChromium(p_airportPage);
            Console.WriteLine(p_airportPage);
        }

        private void initChromium(string p_airportPage)
        {
            var settings = new CefSettings()
            {
                //By default CefSharp will use an in-memory cache, you need to specify a Cache Folder to persist data
                CachePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CefSharp\\Cache")
            };

            //Perform dependency check to make sure all relevant resources are in our output directory.
            Cef.Initialize(settings, performDependencyCheck: true, browserProcessHandler: null);
            var url = BASE_URL + p_airportPage + PATH_URL;
            initPageAsync(url);
        }

        private static async Task initPageAsync(string url)
        {
            // Create the offscreen Chromium browser.
            _browser = new ChromiumWebBrowser(url);
            while (!_browser.IsBrowserInitialized || _browser.IsLoading)
            {
                Console.WriteLine("Loading url...");
                Thread.Sleep(500);
            }
            var task = _browser.EvaluateScriptAsync(Scripts.ShowScheduledFlightsTab).Result;
            var task1 = _browser.EvaluateScriptAsync(Scripts.WaitPopupColaps).Result;
            while (task1.Result.ToString() != "none")
            {
                Thread.Sleep(200);
                task1 = _browser.EvaluateScriptAsync(Scripts.WaitPopupColaps).Result;
            }
            //TakeScreenShot();
            var cookies = await Cef.GetGlobalCookieManager().VisitAllCookiesAsync();
            var cookie = cookies.Find(c => c.Name.Contains("1276841"));
        }

        private static void TakeScreenShot()
        {
            var ScreenShootTask = _browser.ScreenshotAsync();
            ScreenShootTask.ContinueWith(x =>
            {
                var screenshotPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "CefSharp screenshot.png");

                Console.WriteLine();
                Console.WriteLine("Screenshot ready. Saving to {0}", screenshotPath);
                ScreenShootTask.Result.Save(screenshotPath);
                ScreenShootTask.Result.Dispose();
                Console.WriteLine("Screenshot saved.  Launching your default image viewer...");
                Process.Start(screenshotPath);
                Console.WriteLine("Image viewer launched.  Press any key to exit.");
            }, TaskScheduler.Default);
        }

        public List<Flight> GetFlightsByDate(DateTime p_date)
        {
            var date = p_date.ToString("dd/MM/yyyy");
            var script = Scripts.searchForDateScript(date);
            var task2 = _browser.EvaluateScriptAsync(script).Result;
            var task1 = _browser.EvaluateScriptAsync(Scripts.WaitPopupColaps).Result;
            while (task1.Result == null || task1.Result.ToString() != "none")
            {
                Thread.Sleep(200);
                task1 = _browser.EvaluateScriptAsync(Scripts.WaitPopupColaps).Result;
            }
            var task2_01 = _browser.EvaluateScriptAsync(Scripts.ExpandTable).Result;
            task1 = _browser.EvaluateScriptAsync(Scripts.WaitPopupColaps).Result;
            while (task1.Result == null || task1.Result.ToString() != "none")
            {
                Thread.Sleep(200);
                task1 = _browser.EvaluateScriptAsync(Scripts.WaitPopupColaps).Result;
            }
            var task2_1 = _browser.EvaluateScriptAsync(Scripts.CountRows).Result;
            var response = _browser.EvaluateScriptAsync(Scripts.CollectFlightsData).Result;
            var jsResult = (List<object>)response.Result;
            var asJson = JsonConvert.SerializeObject(jsResult);
            var format = "dd/MM/yyyy HH:mm:ss";
            var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = format };
            var asFlights = JsonConvert.DeserializeObject <List<Flight>>(asJson, dateTimeConverter);
            return asFlights;
        }
    }

    public static class AirportPages
    {
        public const string BenGurion = "BenGurion";
        public const string Ramon = "ramonairport";
    }
}