using Calculo_De_Costos.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Calculo_De_Costos.ViewModels.Commands
{
    public class SavePIInfoCommand : ICommand
    {
        public PIInfoVM VM { get; set; }

        public event EventHandler CanExecuteChanged;

        public SavePIInfoCommand(PIInfoVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            var values = (object[])parameter;
            bool[] aux = new bool[6];
            bool success = false ;
            Window piInfoWindow = (Window)values[6]; 
            for (int i=0; i<6; i++)
            {
                aux[i] = (bool)values[i];
            }
            if(!aux[0] && !aux[1] && !aux[2] && !aux[3] && !aux[4] && !aux[5])
                success = await VM.SavePIInfo();
            if(success)
            {
                ProductInfoView pI = new ProductInfoView();
                pI.Show();
                piInfoWindow.Close();
            }
            else
            {
                await VM.DeletePI();
            }
        }
    }
}
