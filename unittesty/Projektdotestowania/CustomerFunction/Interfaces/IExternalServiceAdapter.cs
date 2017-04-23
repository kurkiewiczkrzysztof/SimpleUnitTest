using Projektdotestowania.CustomerFunction.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektdotestowania.CustomerFunction.Interfaces
{
    public interface IExternalServiceAdapter
    {
        bool IsOpenService(ExternalService service);
    }
}
