using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculo_De_Costos.Services
{
    class Response
    {
        public bool succes { get; set; }
        public int statusCode { get; set; }
        public string message { get; set; }
        public object data { get; set; }
    }
}
