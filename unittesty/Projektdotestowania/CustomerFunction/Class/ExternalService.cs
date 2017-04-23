    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektdotestowania.CustomerFunction.Class
{
    public class ExternalService
    {
        public virtual bool IsOpenService() => new Random().Next(0, 10) >= 5 ? true : false;
    }
}
