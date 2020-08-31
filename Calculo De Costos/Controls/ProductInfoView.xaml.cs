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
using System.Windows.Shapes;

namespace Calculo_De_Costos.Controls
{
    /// <summary>
    /// Lógica de interacción para ProductInfoView.xaml
    /// </summary>
    public partial class ProductInfoView : Window
    {
        public ProductInfoView()
        {
            InitializeComponent();
            DataContext = new ProductInfoVM();
        }
    }
}
