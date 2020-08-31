using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculo_De_Costos.Models
{
    public class PIProducts
    {
        public string id_product { get; set; }
        public string name { get; set; }
        public float quantity { get; set; }
        public float price { get; set; }
        public float weight { get; set; }
    }
}
