using Calculo_De_Costos.Controls;
using Calculo_De_Costos.Models;
using Calculo_De_Costos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Calculo_De_Costos.ViewModels
{
    class MenuViewModel : BaseNotifyPropertyChanged
    {
        private ICommand _createNewPICommand;
        public ICommand CreateNewPICommand
        {
            get
            {
                return _createNewPICommand ?? (_createNewPICommand = new CommandHandler(() => CreateNewPIAction(), () => CanExecute));
            }
        }
        public bool CanExecute
        {
            get
            {
                // check if executing is allowed, i.e., validate, check if a process is running, etc. 
                return true;
            }
        }

        public async void CreateNewPIAction()
        {
            PI pi;
            InputDialog inputDialog = new InputDialog("Ingrese el numero de PI:", "");
            if (inputDialog.ShowDialog() == true)
                pi = new PI(inputDialog.Answer, DateTime.Now);
            else
            {
                MessageBox.Show("Se requiere de un numero de PI para continuar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            WaitPlease w = new WaitPlease();
            w.Show();
            
            Response r = await WebService.InsertData(pi, "http://localhost/costs_api/controller/pi/pi.php",PI.DataType.NewPI);
            w.Close();
            if (r != null)
            {
                int aux = -1;
                if (int.TryParse(r.message.ToString(), out aux))
                {
                    pi.id = aux;
                    App.Current.Properties["IDPI"] = pi;
                    AddPIInfo p = new AddPIInfo();
                    p.ShowDialog();
                }
                else
                    MessageBox.Show("Error, " + r.message);
            }
            else
                MessageBox.Show("No se pudo establecer comunicacion con el servidor", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
