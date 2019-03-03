using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Windows;

namespace osuGrabber
{
   public class SearchingClass :IProgress<int>
    {
        #region Zmienne i konstruktor
        Stopwatch stopwatch;
        private FilteringClass filter;
        public SearchingClass()
        {
            stopwatch = new Stopwatch();
            filter = new FilteringClass();
        }

        public void Report(int value)
        {
            throw new NotImplementedException();
        }
        #endregion
        public async Task<List<Song_Data>> TransformHTML(string address)
        {
            stopwatch.Restart();
            string htmlDocument = await DownloadPage(address);
            List<Song_Data> songs_to_return = new List<Song_Data>();
            filter.FilterPage(htmlDocument, ref songs_to_return);
            stopwatch.Stop();
            Console.WriteLine("Performance of transforming {0}", stopwatch.ElapsedMilliseconds);
            return songs_to_return;
        }
                private async Task<string> DownloadPage(string address)
        {
            string htmlDocument = string.Empty;
            stopwatch.Restart();
            using (WebClient client = new WebClient())
            {
                try
                {
                    htmlDocument = await client.DownloadStringTaskAsync(new Uri(address));
                }
                catch (ArgumentNullException ex)
                {
                   await Messaging.Report(ex.Message, "No data provided");
                }
                catch (WebException ex)
                {
                    await Messaging.Report(ex.Message, "An error occured");
                }
            }
            stopwatch.Stop();
            Console.WriteLine("Performance of downloading page {0}", stopwatch.ElapsedMilliseconds);
            return htmlDocument;
        }
    }
}
