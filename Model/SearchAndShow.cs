using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osuGrabber.Model
{
   public class SearchAndShow
    {
        //public ObservableCollection<Song_Data> SongsToShow;
        public List<Song_Data> SongsToShow;
        public string Name { get; set; }
        //public bool[] rankingState { get; set; }
        public ObservableCollection<bool> rankingState { get; set; }
        public ObservableCollection<bool> gameMode { get; set; }

        private SearchingPreparation search;
        private SearchingClass analyze;
        
        public SearchAndShow()
        {
            Name = string.Empty;
            rankingState = new ObservableCollection<bool>();
            for(int i=0;i<5;i++) rankingState.Add(false);
            gameMode = new ObservableCollection<bool>();
            for (int i = 0; i < 4; i++) gameMode.Add(false);
            SongsToShow = new List<Song_Data>();
            search = new SearchingPreparation();
            analyze = new SearchingClass();
        }
        public async Task SearchAndDisplay()
        {
            SongsToShow = await analyze.TransformHTML(search.PrepareAdress(this));
            if (SongsToShow.Count == 61) SongsToShow.Add(new Song_Data("-1", "Sooo many results, maybe you'd precise your search?"));
        }
                
    }
}
