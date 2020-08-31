using Calculo_De_Costos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculo_De_Costos.Models
{
    public class ExcelCoordinatesModel : BaseNotifyPropertyChanged
    {
        private string startColum;

        public string StartColum
        {
            get { return startColum; }
            set { SetValue(ref startColum, value); }
        }
        private string startRow;

        public string StartRow
        {
            get { return startRow; }
            set { SetValue(ref startRow, value); }
        }
        private string endRow;

        public string EndRow
        {
            get { return endRow; }
            set { SetValue(ref endRow, value); }
        }
    }
}
