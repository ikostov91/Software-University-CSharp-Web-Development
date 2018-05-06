using System;
using System.Collections.Generic;
using System.Text;

namespace StreamProgressInfo
{
    public class StreamProgressInfo
    {
        private IStreamProgress iStreamProgress;

        // If we want to stream a music file, we can't
        public StreamProgressInfo(IStreamProgress iStreamProgress)
        {
            this.iStreamProgress = iStreamProgress;
        }

        public int CalculateCurrentPercent()
        {
            return (this.iStreamProgress.BytesSent * 100) / this.iStreamProgress.Length;
        }
    }
}
