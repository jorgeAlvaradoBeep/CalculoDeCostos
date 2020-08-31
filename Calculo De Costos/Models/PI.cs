using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculo_De_Costos.Models
{
    public class PI
    {
        public int id { get; set; }
        public string pi_number { get; set; }
        public DateTime date { get; set; }
        public PIInfo PIInfo { get; set; }
        public List<PIProducts> PIProdducts { get; set; }

        public PI(string _pi_number, DateTime _date)
        {
            pi_number = _pi_number;
            date = _date;
        }

        public enum DataType
        {
            NewPI,
            NewPIData,
            NewPIProducts
        }
    }
}
