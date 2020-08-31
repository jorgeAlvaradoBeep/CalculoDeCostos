using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Calculo_De_Costos.ViewModels.Commands
{
    public class CheckDataEntranceCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public ProductInfoVM PIVM { get; set; }

        public CheckDataEntranceCommand(ProductInfoVM piVM)
        {
            PIVM = piVM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var values = (object[])parameter;
            bool aux = true;
            Window productInfoView = (Window)values[7];
            for (int i = 0; i < 7; i++)
            {
                aux &= !(bool)values[i];
            }
            if (aux)
                PIVM.ValidateDataEnter();
            else
                MessageBox.Show("Existen errores en el formulario");
        }
    }
}
