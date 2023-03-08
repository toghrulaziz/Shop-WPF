using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace ShopTaskWPF
{
    /// <summary>
    /// Interaction logic for SelectedProduct.xaml
    /// </summary>
    public partial class SelectedProduct : Window, INotifyPropertyChanged
    {


        private string? name;

        public string? SName
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }



        private string? content;

        public string? SContent
        {
            get { return content; }
            set { content = value;OnPropertyChanged(); }
        }

        private double price;

        public double SPrice
        {
            get { return price; }
            set { price = value; OnPropertyChanged(); }
        }

        private string? photo;

        public string? SPhoto
        {
            get { return photo; }
            set { photo = value; OnPropertyChanged(); }
        }

        

        public SelectedProduct()
        {
            InitializeComponent();
            DataContext= this;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void btn_sEdit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
