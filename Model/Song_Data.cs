using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osuGrabber
{
    public class Song_Data
    {
        public string Number { get; private set; }
        public string Title { get; private set; }
       public Song_Data(string number, string title)
        {
            Number = number;
            Title = title;
        }

        public Song_Data()
        {
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
