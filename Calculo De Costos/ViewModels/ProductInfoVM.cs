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
    public class ProductInfoVM : BaseNotifyPropertyChanged
    {
        private ExcelCoordinatesModel productCode;

        public ExcelCoordinatesModel ProductCode
        {
            get { return productCode; }
            set { SetValue(ref productCode, value); }
        }
        private ExcelCoordinatesModel productName;

        public ExcelCoordinatesModel ProductName
        {
            get { return productName; }
            set { SetValue(ref productName, value); }
        }
        private ExcelCoordinatesModel productQuantity;

        public ExcelCoordinatesModel ProductQuantity
        {
            get { return productQuantity; }
            set { SetValue(ref productQuantity, value); }
        }
        private ExcelCoordinatesModel productPrice;

        public ExcelCoordinatesModel ProductPrice
        {
            get { return productPrice; }
            set { SetValue(ref productPrice, value); }
        }
        private ExcelCoordinatesModel productWeight;

        public ExcelCoordinatesModel ProductWeight
        {
            get { return productWeight; }
            set { productWeight = value; }
        }

        //Pripiedad que activara y descativara la entrada de texto
        private bool canDataBeWritten;

        public bool CanDataBeWritten
        {
            get { return canDataBeWritten; }
            set { SetValue(ref canDataBeWritten, value); }
        }


        //Propiedades para los estados de la verificacion de los datos ingresados
        private Visibility checkDataEntrance;

        public Visibility CheckDataEntrance
        {
            get { return checkDataEntrance; }
            set { SetValue(ref checkDataEntrance, value); }
        }

        private bool isCheckDataEntranceAvailable;

        public bool IsCheckDataEntranceAvailables
        {
            get { return isCheckDataEntranceAvailable; }
            set { SetValue(ref isCheckDataEntranceAvailable, value); }
        }

        //Propiedades para la activacion del sistema de carga del archivo
        private bool isLoadFileButtonAvailable;

        public bool IsLoadFileButtonAvailable
        {
            get { return isLoadFileButtonAvailable; }
            set { SetValue(ref isLoadFileButtonAvailable, value); }
        }

        private Visibility checkLoadFile;

        public Visibility CheckLoadFile
        {
            get { return checkLoadFile; }
            set { SetValue(ref checkLoadFile, value); }
        }

        //Propiedades para verificar la carga de los datos del archivo
        private bool isFileDataButtonAvailable;

        public bool IsFileDataButtonAvailable
        {
            get { return isFileDataButtonAvailable; }
            set { SetValue(ref isFileDataButtonAvailable, value); }
        }

        private Visibility checkDataFile;

        public Visibility CheckDataFile
        {
            get { return checkDataFile; }
            set { SetValue(ref checkDataFile, value); }
        }
        //Propiedad de la ubicacion del archivo excel
        public string ExcelFilePathLocation { get; set; }
        public LoadExcelFileCommand LoadExcelFileCommand { get; set; }
        public CheckDataEntranceCommand CheckDataEntranceCommand { get; set; }
        public LoadDataFromExcelFileCommand LoadDataFromExcelFileCommand { get; set; }
        //Propiedad del PI Completo
        public PI PI { get; set; }

        public ProductInfoVM()
        {
            ProductCode = new ExcelCoordinatesModel();
            //ProdcutNAme
            ProductName = new ExcelCoordinatesModel();
            //ProductQuantity
            ProductQuantity = new ExcelCoordinatesModel();
            //ProductPrice
            ProductPrice = new ExcelCoordinatesModel();
            //ProductWeight
            ProductWeight = new ExcelCoordinatesModel();

            //Definimos la escritura como disponible
            CanDataBeWritten = true;

            //Inicializamos el estayus del View
            //Propiedades de la verificacion de los datos ingresados
            CheckDataEntrance = Visibility.Hidden;
            IsCheckDataEntranceAvailables = true;
            //Propiedades para cargar el archivo que sera necesario.
            CheckLoadFile = Visibility.Hidden;
            IsLoadFileButtonAvailable = false;
            //Propiedades para cargar los datos del archivo cargado.
            CheckDataFile = Visibility.Hidden;
            IsFileDataButtonAvailable = false;

            //Propiedad del PI Completo Asignada
            PI = (PI)App.Current.Properties["IDPI"];


            LoadExcelFileCommand = new LoadExcelFileCommand(this);
            CheckDataEntranceCommand = new CheckDataEntranceCommand(this);
            LoadDataFromExcelFileCommand = new LoadDataFromExcelFileCommand(this);
        }

        public void LoadExcelFile()
        {
            System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
            dlg.DefaultExt = ".xlsx";
            dlg.Filter = "ExcelFile Files (*.xlsx)|*.xlsx|2003 Excel Files (*.xls)|*.xls";
            System.Windows.Forms.DialogResult result = dlg.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                // Open document 
                string filename = dlg.FileName;
                ExcelFilePathLocation = filename;
                CheckLoadFile = Visibility.Visible;
                IsLoadFileButtonAvailable = false;
                IsFileDataButtonAvailable = true;
            }
        }

        public void ValidateDataEnter()
        {
            string error = "";
            if (string.IsNullOrEmpty(ProductCode.StartColum))
                error = "La columna no puede estar vacia";
            else if (string.IsNullOrEmpty(ProductCode.StartRow))
                error = "El numero de fila de inicio no puede estar vacia";
            else if (string.IsNullOrEmpty(ProductCode.EndRow))
                error = "El numero de fila de fin no puede estar vacia";
            else if (string.IsNullOrEmpty(ProductName.StartColum))
                error = "La columna no puede estar vacia";
            else if (string.IsNullOrEmpty(productQuantity.StartColum))
                error = "La columna no puede estar vacia";
            else if (string.IsNullOrEmpty(productPrice.StartColum))
                error = "La columna no puede estar vacia";
            else if (string.IsNullOrEmpty(ProductWeight.StartColum))
                error = "La columna no puede estar vacia";

            if (string.IsNullOrEmpty(error))
            {
                CheckDataEntrance = Visibility.Visible;
                IsCheckDataEntranceAvailables = false;
                CanDataBeWritten = false;
                IsLoadFileButtonAvailable = true;
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void LoadDataFromExcelFile()
        {
            CheckDataFile = Visibility.Visible;
            IsFileDataButtonAvailable = false;
            if(!string.IsNullOrEmpty(ExcelFilePathLocation))
            {
                int starCol = int.Parse(ProductCode.StartRow);
                int endCol = int.Parse(ProductCode.EndRow);
                string[] rows = { ProductCode.StartColum, ProductName.StartColum, ProductQuantity.StartColum, ProductPrice.StartColum, ProductWeight.StartColum };
                
                PI.PIProdducts= ExcelClass.GetBaseProductInfo(rows, starCol, endCol, ExcelFilePathLocation);
            }
            
        }
    }
}
