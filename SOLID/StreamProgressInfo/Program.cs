using System;

namespace StreamProgressInfo
{
    public class Program
    {
        static void Main()
        {   
            var progressInfo = new StreamProgressInfo(new File("my file", 100, 1000));
            var progressInfo2 = new StreamProgressInfo(new Music("lili ivanova", "album", 5, 13));
        }
    }
}
