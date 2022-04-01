using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using LetsGoBiking_tc.Lib.Models;
using Newtonsoft.Json;

namespace LetsGoBiking_tc.WF.Helpers
{
    public static class Helpers
    {
        public static string ConstructSoapRequest(int a, int b)
        {
            return string.Format(@"<?xml version=""1.0"" encoding=""utf-8""?>
                <s:Envelope xmlns:s=""http://schemas.xmlsoap.org/soap/envelope/"">
                    <s:Body>
                        <Add xmlns=""http://localhost:5157/api/LGBiking/"">
                            <a>{0}</a>
                            <b>{1}</b>
                        </Add>
                    </s:Body>
                </s:Envelope>", a, b);
        }

        public static List<Station> ParseSoapResponse(string response)
        {
            // var soap = XDocument.Parse(response);
            XNamespace ns = "http://localhost:5157/api/LGBiking/";
            return JsonConvert.DeserializeObject<List<Station>>(response);
        }
    }
}
