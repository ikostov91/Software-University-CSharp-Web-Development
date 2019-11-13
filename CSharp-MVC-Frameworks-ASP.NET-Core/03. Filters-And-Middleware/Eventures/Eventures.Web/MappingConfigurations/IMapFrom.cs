using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventures.Web.MappingConfigurations
{
    interface IMapFrom<T>
        where T : class, new()
    {
    }
}
