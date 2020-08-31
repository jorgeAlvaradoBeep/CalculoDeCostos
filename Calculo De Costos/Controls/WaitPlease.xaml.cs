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
using System.Windows.Shapes;

namespace Calculo_De_Costos.Controls
{
    /// <summary>
    /// Lógica de interacción para WaitPlease.xaml
    /// </summary>
    public partial class WaitPlease : Window
    {
        public WaitPlease()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }
        private void gif_MediaEnded(object sender, RoutedEventArgs e)
        {
        }
    }
}
