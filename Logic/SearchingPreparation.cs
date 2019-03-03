using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osuGrabber.Model;

namespace osuGrabber
{
    public class SearchingPreparation
    {
        public string PrepareAdress(SearchAndShow searchQuery) => prepareAdress(searchQuery);
        private string prepareAdress(SearchAndShow searchQuery)
        {
            SplitNames(ref searchQuery);
            string rankingStatus = GetRankingStatus(searchQuery);
            string gamemode = GetGameMode(searchQuery);
            return $"https://bloodcat.com/osu/?q={searchQuery.Name}&c=b&s={rankingStatus}&m={gamemode}&g=&l=";
        }

        private static string GetGameMode(SearchAndShow searchQuery)
        {
            string gamemode = "";
            for (int i = 0; i < searchQuery.gameMode.Count; i++)
            {
                if (searchQuery.gameMode[i])
                {
                    if (i != searchQuery.gameMode.Count - 1) gamemode += $"{i},";
                    else gamemode += i;
                }
            }
            return gamemode;
        }

        private static string GetRankingStatus(SearchAndShow searchQuery)
        {
            string rankingStatus = "";
            for (int i = 1; i < searchQuery.rankingState.Count; i++)
            {
                if (searchQuery.rankingState[i])
                    rankingStatus += $"{i},";
            }
            if (searchQuery.rankingState[0]) rankingStatus += ",0";
            return rankingStatus;
        }

        private static void SplitNames(ref SearchAndShow searchQuery)
        {
            if (searchQuery.Name.Contains(" "))
            {
                var temporaryNames = searchQuery.Name.Split(' ');
                searchQuery.Name = string.Join("%20", temporaryNames);
            }
        }
    }
}
