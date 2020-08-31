using Calculo_De_Costos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculo_De_Costos.Controls
{
    /// <summary>
    /// Lógica de interacción para ucMenu.xaml
    /// </summary>
    public partial class ucMenu : UserControl
    {
        public ucMenu()
        {
            InitializeComponent();
            DataContext = new MenuViewModel();
        }
    }
}
