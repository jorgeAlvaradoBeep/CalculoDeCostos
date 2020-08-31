using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculo_De_Costos.Models
{
    public class PIInfo
    {
        public int id_pi { get; set; }
        public float shipping_fee { get; set; }
        public float tax_mx { get; set; }
        public float tax_mx_calculated { get; set; }
        public float shipper { get; set; }
        public float exhange_products { get; set; }
        public float exhange_shipping { get; set; }
        public float exhange_tax { get; set; }
    }
}
