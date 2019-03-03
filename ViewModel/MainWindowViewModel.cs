using osuGrabber.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Controls;

namespace osuGrabber.ViewModel
{

    // class Search : ICommand
    //{
    //    private readonly ViewModel view;
    //     public Search(ViewModel _view)
    //    {
    //        view =_view ?? throw new ArgumentNullException(nameof(_view));
    //    }
    //    public event EventHandler CanExecuteChanged;

    //    public bool CanExecute(object parameter) => true;


    //    public void Execute(object parameter)
    //    {
    //       if(view!=null)
    //        {
    //            view.query.SearchAndDisplay();
    //            Console.WriteLine("wykonano");
    //        }
    //    }
    //}
    partial class ViewModel : INotifyPropertyChanged
    {
        #region Properties
        public string Name {
            get => query.Name;
            set { query.Name = value; OnPropertyChanged("Name"); }
        }
            BooleanToVisibilityConverter VisibilityConverter;
        //public System.Windows.Visibility DoingThings
        //{
        //    get
        //    {
        //        return (System.Windows.Visibility)converter.Convert(doingThings);
        //    }
        //    set => DoingThings = value;
        //}
        public bool DoingThings {
            get => RelayCommandAsync.DoingThings;
            set
            {
                RelayCommandAsync.DoingThings = value;
                OnPropertyChanged("DoingThings");
            }
        }
       // {
       //     get
       //     {
       //         if (doingThings == true) DoingThings = System.Windows.Visibility.Visible;
       //         else DoingThings = System.Windows.Visibility.Hidden;
       //         return this.doingThings;
       //     }
       //     set
       //     {
       //         doingThings = value;
       //         OnPropertyChanged("doingThings");
       //     }
       // }
       //// public bool DoingThings = true;

        public List<Song_Data> SongsToShow
       // public ObservableCollection<Song_Data> SongsToShow
        {
            get => query.SongsToShow;
            set { query.SongsToShow = value; OnPropertyChanged("SongsToShow"); }
        }
        public bool ChkUnranked
        {
            get => query.rankingState[0];
            set { query.rankingState[0] = value; OnPropertyChanged("rankingState"); }
        }
        public bool ChkRanked
        {
            get => query.rankingState[1];
            set { query.rankingState[1] = value; OnPropertyChanged("rankingState"); }
        }
        public bool ChkApproved
        {
            get => query.rankingState[2];
            set { query.rankingState[2] = value; OnPropertyChanged("rankingState"); }
        }
        public bool ChkQualified
        {
            get => query.rankingState[3];
            set { query.rankingState[3] = value; OnPropertyChanged("rankingState"); }
        }
        public bool ChkLoved
        {
            get => query.rankingState[4];
            set { query.rankingState[4] = value; OnPropertyChanged("rankingState"); }
        }
        public bool chkOsuStandard { get => query.gameMode[0]; set { query.gameMode[0] = value; OnPropertyChanged("gameMode"); } }
        public bool chkOsuTaiko { get => query.gameMode[1]; set { query.gameMode[1] = value; OnPropertyChanged("gameMode"); } }
        public bool chkOsuCatch { get => query.gameMode[2]; set { query.gameMode[2] = value; OnPropertyChanged("gameMode"); } }
        public bool chkOsuMania { get => query.gameMode[3]; set { query.gameMode[3] = value; OnPropertyChanged("gameMode"); } }
        public Song_Data selectedItem
        {
            get => download.Song;
            set { download.Song = value; OnPropertyChanged("Song"); }
        }
        #endregion
        public SearchAndShow query;
        private PickAndDownload download;
        public event PropertyChangedEventHandler PropertyChanged;
        public ViewModel()
        {
            query = new SearchAndShow();
            download = new PickAndDownload();
        }
       
        public void OnPropertyChanged(params string[] propertyNames)
        {
            if(PropertyChanged!=null)
            {
                foreach (string name in propertyNames)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
                    Console.WriteLine("{0} changed",name);
                }
            }
        }
        
       
        }
    }

