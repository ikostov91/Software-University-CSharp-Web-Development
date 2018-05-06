using System;
using System.Collections.Generic;
using System.Text;

namespace StreamProgressInfo
{
    public interface IStreamProgress
    {
        int BytesSent { get; }

        int Length { get; }
    }
}
