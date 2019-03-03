using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace osuGrabber.ViewModel
{
    partial class ViewModel
    {
        private ICommand searchCommand;
        private ICommand downloadCommand;
        public ICommand SearchCommand
        {
            get
            {
                if (searchCommand == null)
                {
                    searchCommand = new RelayCommandAsync(async x =>
                    {
                        
                        Task display = query.SearchAndDisplay();
                        await display;
                        if (display.IsCompleted)
                            OnPropertyChanged("SongsToShow");
                        if (SongsToShow.Count == 0) await Messaging.Report("No results found for this query!", "Sorry!");
                    }, x => true);
                }
                return searchCommand;
            }
        }
        public ICommand DownloadCommand
        {
            get
            {
                if (downloadCommand == null)
                {
                    
                    downloadCommand = new RelayCommandAsync(async x =>
                    {
                        Console.WriteLine("Start");
                        if (selectedItem.Number != "-1")
                        {
                            await Messaging.Report("Download started", "Download message");
                            Task downloader = download.DownloadSong();
                            await downloader;
                            if (downloader.IsCompleted) await Messaging.Report("Download completed", "Download message");
                        }
                    }, x => true);
                }
                return downloadCommand;
            }
        }
        private ICommand findCommand;
        public ICommand FindCommand
        {
            get
            {
                if (findCommand==null)
                {
                    findCommand = new RelayCommand(x =>
                    {
                        if (CommonFileDialog.IsPlatformSupported)
                        {
                            var dialog = new CommonOpenFileDialog();
                            dialog.IsFolderPicker = true;
                            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                            Settings.OsuSongsPath = Directory.Exists(dialog.FileName) ? dialog.FileName : Path.GetDirectoryName(dialog.FileName);
                        }
                    }, x => true
                    );
                }
                return findCommand;
            }
        }

        
    }
}
