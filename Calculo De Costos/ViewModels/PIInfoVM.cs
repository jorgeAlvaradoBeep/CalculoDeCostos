using Calculo_De_Costos.Controls;
using Calculo_De_Costos.Models;
using Calculo_De_Costos.Services;
using Calculo_De_Costos.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calculo_De_Costos.ViewModels
{
    public class PIInfoVM : BaseNotifyPropertyChanged
    {
        private PIInfo piInfo;
        private int piCode;
        public PIInfo PiInfo
        {
            get { return piInfo; }
            set 
            {
                SetValue(ref piInfo, value);
            }
        }
        public PI PI { get; set; }
        public SavePIInfoCommand SavePIInfoCommand { get; set; }
        public CancelPIInformationCommand CancelPIInformationCommand { get; set; }

        public PIInfoVM()
        {
            PiInfo = new PIInfo();
            SavePIInfoCommand = new SavePIInfoCommand(this);
            CancelPIInformationCommand = new CancelPIInformationCommand(this);
            PI = (PI)App.Current.Properties["IDPI"];
            PiInfo.id_pi = PI.id;
        }
        public async Task<bool> SavePIInfo()
        {
            if(PiInfo.shipping_fee==0)
            {
                MessageBox.Show("El costo de envio no puede ser 0...");
                return false;
            }else if (PiInfo.tax_mx == 0)
            {
                MessageBox.Show("El costo de envio no puede ser 0...");
                return false; ;
            }
            else if (PiInfo.exhange_products == 0)
            {
                MessageBox.Show("El costo de envio no puede estar vacio...");
                return false; ;
            }
            else if (PiInfo.exhange_shipping == 0)
            {
                MessageBox.Show("El costo de envio no puede estar vacio...");
                return false; ;
            }
            else if (PiInfo.exhange_tax == 0)
            {
                MessageBox.Show("El costo de envio no puede estar vacio...");
                return false; ;
            }

            WaitPlease w = new WaitPlease();
            w.Show();

            PI.PIInfo = PiInfo;
            Response r = await WebService.InsertData(PI.PIInfo, "http://localhost/costs_api/controller/pi/pi_info.php", PI.DataType.NewPIData);
            w.Close();
            App.Current.Properties["IDPI"] =PI;
            MessageBox.Show(r.message);
            if (r.statusCode != 200)
                return false;
            return r.succes;

        }

        public async Task<int> DeletePI()
        {
            WaitPlease w = new WaitPlease();
            w.Show();

            Response r = await WebService.DeleteData(PI.id);
            w.Close();
            int rowDeleted = int.Parse(r.message);
            return rowDeleted;
        }
    }
}
