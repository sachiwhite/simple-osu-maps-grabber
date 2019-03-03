using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace osuGrabber
{
    class SongDownloader
    {
        private const int chunkSize = 4*1024;
        private async Task<WebResponse> GetRequestAsync(string address)
        {
            try
            {
                Console.WriteLine("Łączenie z serwerem..");
                var request = WebRequest.CreateHttp(address);
                request.Method = WebRequestMethods.Http.Get;
                request.ContentType = "application/octet-stream";
                return await request.GetResponseAsync();
                
            }
            catch (WebException wex)
            {
                return wex?.Response as WebResponse;
            }
            catch (Exception ex)
            {
                await Messaging.Report(ex.Message, "An exception occurred");
            }
            return null;
        }
        public async Task DownloadSong(string beatmapNumber)
        {
            try
            {
                Console.WriteLine("Start pobierania");
                byte[] songs = await GetData(@"https://bloodcat.com/osu/s/"+beatmapNumber);
                if (songs != null)
                {
                    using (var stream = File.OpenWrite($"{Settings.OsuSongsPath}{beatmapNumber}.osz"))
                    {
                        int i = 0;
                        int Chunks = songs.Length / chunkSize;
                        int lastChunk = songs.Length % chunkSize;
                        for (i = 0; i <= Chunks-1; ++i)
                        {
                          stream.Write(songs, chunkSize*i, chunkSize);
                        }
                        if(lastChunk==0) stream.Write(songs, chunkSize*i, chunkSize);
                        else stream.Write(songs, chunkSize*i, lastChunk);
                    }
                }
                else throw new ArgumentNullException();
            }
            catch (Exception)
            {
                await Messaging.Report("Couldn't write a file", "Saving error");
            }
            
        }
        private async Task<byte[]> GetData(string address)
        {
            try
            {
                var response = await GetRequestAsync(address);
                Stream map_bytes = response.GetResponseStream();
                using (MemoryStream ms = new MemoryStream())
                {
                    await map_bytes.CopyToAsync(ms);
                    return ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                await Messaging.Report(ex.Message, "An exception occurred");
            }

            return null;
        }
    }
}
