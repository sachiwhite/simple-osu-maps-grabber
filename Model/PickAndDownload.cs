using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osuGrabber.Model
{
    public class PickAndDownload
    {
        public Song_Data Song { get; set; }
        private SongDownloader songDownloader;

        public PickAndDownload()
        {
            songDownloader = new SongDownloader();
            Song = new Song_Data();

        }
        public async Task DownloadSong()
        {
            Task download = songDownloader.DownloadSong(Song.Number);
            await download;
        }




    }
}
