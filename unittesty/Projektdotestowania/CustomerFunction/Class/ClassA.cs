using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projektdotestowania.CustomerFunction.Interfaces;
using System.Text.RegularExpressions;

namespace Projektdotestowania.CustomerFunction.Class
{
    public class ClassA : IFunctionA
    {
        private IExternalServiceAdapter _service;
        public ClassA(IExternalServiceAdapter service)
        {
            _service = service;
        }

        public Dictionary<string, string> Funkcja1(string s)
        {

            var orgService = new ExternalService();
            if (s.Trim().Length == 0)
            {
                throw new NullReferenceException();
                return null;
            }
            if (s.Length < 5)
            {
                return new Dictionary<string, string>()
                {
                    { "Message","String is too small" }
                };
            }
            if (!_service.IsOpenService(orgService))
            {
                throw new Exception("Connection problem!");
            }
            return new Dictionary<string, string>
            {
                ["ILOSC_ZN"] = s.Length.ToString(),
                ["PRW_ZN"] = s.Substring(0, 1),
                ["OST_ZN"] = s.Substring(s.Length - 1, 1),
                ["LICZ"] = Regex.Matches(Regex.Escape(s), "TOTALE", RegexOptions.IgnoreCase).Count.ToString()
            };

            }
        }
    }

