using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projektdotestowania.CustomerFunction.Interfaces;
using Projektdotestowania.CustomerFunction.Class;

namespace Projektdotestowania.CustomerFunction.Adapters
{
    class ExternalServiceAdapter : IExternalServiceAdapter
    {
        public bool IsOpenService(ExternalService service) => service.IsOpenService();
    }
}
