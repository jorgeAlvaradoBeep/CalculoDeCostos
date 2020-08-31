using Calculo_De_Costos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Calculo_De_Costos.ViewModels.Commands
{
    public class CancelPIInformationCommand : ICommand
    {
        public PIInfoVM VM { get; set; }
        public event EventHandler CanExecuteChanged;

        public CancelPIInformationCommand(PIInfoVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            Window piInfoWindow = (Window)parameter;
            int result = await VM.DeletePI();
            if (result == 1)
                piInfoWindow.Close();
            else
                MessageBox.Show("No se pudo eliminar el PI", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }   
    }
}
