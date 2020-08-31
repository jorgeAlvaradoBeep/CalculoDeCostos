using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace Calculo_De_Costos.ViewModels.Commands
{
    public class LoadExcelFileCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public ProductInfoVM PIVM { get; set; }
        public LoadExcelFileCommand(ProductInfoVM piVM)
        {
            PIVM = piVM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            PIVM.LoadExcelFile();
        }
    }
}
