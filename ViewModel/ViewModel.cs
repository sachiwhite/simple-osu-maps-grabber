//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Input;

//namespace osuGrabber.ViewModel
//{
//    class ViewModel
//    {

//       Model.SearchQuery query { get; set; }
//        public string TxtSongName
//        {
//            get => query.Name;
//            set => query.Name = value;
//        }
//        #region Ranking status
//        public bool ChkUnranked
//        {
//            get => query.rankingState[0];
//            set => query.rankingState[0] = value;
//        }
//        public bool ChkRanked
//        {
//            get => query.rankingState[1];
//            set => query.rankingState[1] = value;
//        }
//        public bool ChkApproved
//        {
//            get => query.rankingState[2];
//            set => query.rankingState[2] = value;
//        }
//        public bool ChkQualified
//        {
//            get => query.rankingState[3];
//            set => query.rankingState[3] = value;
//        }
//        public bool ChkLoved
//        {
//            get => query.rankingState[4];
//            set => query.rankingState[4] = value;
//        }
//        #endregion
//        #region Game mode
//        public bool chkOsuStandard { get => query.gameMode[0]; set => query.gameMode[0] = value; }
//        public bool chkOsuTaiko { get => query.gameMode[1]; set => query.gameMode[1] = value; }
//        public bool chkOsuCatch { get => query.gameMode[2]; set => query.gameMode[2] = value; }
//        public bool chkOsuMania { get => query.gameMode[3]; set => query.gameMode[3] = value; }
//        #endregion
//        #region Lista map
//        public List<Song_Data> Songs_to_preview
//        {
//            get;
//        }
//        #endregion
//        public ViewModel()
//        {
//            query = new Model.SearchQuery();
//        }
//        private ICommand search_button_handle;
//        public ICommand Search_Button_Handle
//        {
//            get
//            {
//                if (search_button_handle == null) search_button_handle = new Search_Button_Handling();
//                return search_button_handle;
//            }
//        }
//    }

//}