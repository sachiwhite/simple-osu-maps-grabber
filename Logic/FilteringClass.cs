using System;
using System.Collections.Generic;
using System.Linq;

namespace osuGrabber
{
    internal class FilteringClass
    {
        public FilteringClass()
        {
        }
        public void FilterPage(string htmlDocument, ref List<Song_Data> songs_to_return)
        {
            var values = htmlDocument.Split(new string[] { "<a class=\"title", "<a class=\"id\" href" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            values.RemoveAt(0);
            for (int i = 1; i < values.Count - 5; i = i + 2)
            {
                string temp = new string(values[i].SkipWhile(c => !char.IsDigit(c)).TakeWhile(c => c != '<').ToArray());
                string number = new string(temp.TakeWhile(c => char.IsDigit(c)).ToArray());
                string title = new string(temp.SkipWhile(c => !char.IsLetter(c)).ToArray());
                songs_to_return.Add(new Song_Data(number, title));
            }
           
        }


    }
}