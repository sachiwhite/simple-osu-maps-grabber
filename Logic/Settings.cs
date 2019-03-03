using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;

namespace osuGrabber
{
     class Settings
    {
       public static string OsuSongsPath;
        static Settings()
        {
            Properties.Settings path = Properties.Settings.Default;
            if (path.path == string.Empty) FindPath();
        }
        public static async Task FindPath ()=> await _findPath();
       private static async Task _findPath()
        {
            Properties.Settings settings = Properties.Settings.Default;
            OsuSongsPath = string.Empty;
            string[] disks = Directory.GetLogicalDrives();
            for (int i = 0; i < disks.Length; i++)
            {
                DirectoryInfo di = new DirectoryInfo(disks[i]);
                DirectoryInfo[] possibleOsuDirectories = di.GetDirectories("osu!");
                if(possibleOsuDirectories!=Array.Empty<DirectoryInfo>())
                {
                    foreach (var osudir in possibleOsuDirectories)
                    {
                        var songsdir = osudir.GetDirectories("Songs");
                        if (songsdir != Array.Empty<DirectoryInfo>())
                        {
                            OsuSongsPath = songsdir[0].FullName+@"\";
                            await Messaging.Report($"osu! folder path is now set to {OsuSongsPath}", "Setup completed");
                            break;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(OsuSongsPath)) break;
            }
            settings.path = OsuSongsPath;
            settings.Save();
            if (string.IsNullOrEmpty(OsuSongsPath)) await Messaging.Report("Path of your osu! folder could not be automatically detected." +
                "\n Please set it up manually.", "Setup failure");
            
        }

    }
}
