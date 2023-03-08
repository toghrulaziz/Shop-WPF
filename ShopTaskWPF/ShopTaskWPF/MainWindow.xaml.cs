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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShopTaskWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Product>? Products { get; set; } = new ObservableCollection<Product>();

        Cart cart = new Cart();

        SelectedProduct sp = new SelectedProduct();

        public MainWindow()
        {
            Product p1 = new Product() { Name = "Cola", Content = "Drink", Photo = @"https://www.bakenroll.az/en/image/coca-cola.jpg", Price = 1.2 };
            Product p2 = new Product() { Name = "Fanta", Content = "Drink", Photo = @"https://yousoon.az/storage/2021/08/fanta-orange-soft-drink-can-330ml.jpg", Price = 1.1 };
            Product p3 = new Product() { Name = "Lays", Content = "Snack", Photo = @"https://m.media-amazon.com/images/I/8141nrQe0aL._AC_UF1000,1000_QL80_.jpg", Price = 1.7 };
            Product p4 = new Product() { Name = "Doritos", Content = "Snack", Photo = @"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS6ZduFn0-qrXN2EmMVvecKSdcE0SzRH9vLWw&usqp=CAU", Price = 1.9 };

            Products.Add(p1);
            Products.Add(p2);
            Products.Add(p3);
            Products.Add(p4);

            InitializeComponent();

            DataContext = this;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void btn_addProduct_Click(object sender, RoutedEventArgs e)
        {
            var addProduct = new AddProduct();
            addProduct.ShowDialog();
            Product? p = new() { Name = addProduct.textbox_name.Text, Content = addProduct.textbox_content.Text, Price = Convert.ToDouble(addProduct.textbox_price.Text), Photo = addProduct.textbox_photo.Text };
            Products?.Add(p);
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            var search = textbox_search.Text;

            var result = Products?.FirstOrDefault(x => x.Name == search);

            if (result != null)
            {
                MessageBox.Show("Product is exist!");
            }
            else
                MessageBox.Show("Product don't exist!");
        }

        private void btn_cart_Click(object sender, RoutedEventArgs e)
        {
            cart.ShowDialog();
        }

        private void btn_addCart_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                // Parent element of the button is ListBoxItem
                ListBoxItem item = FindAncestor<ListBoxItem>(button);
                if (item != null)
                {
                    // Get the DataContext of the ListBoxItem
                    var product = item.DataContext as Product;
                    if (product != null)
                    {
                        cart.CartProducts.Add(product);
                    }
                }
            }
        }


        public static T FindAncestor<T>(DependencyObject dependencyObject)
    where T : DependencyObject
        {
            DependencyObject parent = VisualTreeHelper.GetParent(dependencyObject);
            if (parent == null) return null;

            T parentT = parent as T;
            return parentT ?? FindAncestor<T>(parent);
        }

        private void listBox_Products_Loaded(object sender, RoutedEventArgs e)
        {
            listBox_Products.MouseDoubleClick += listBox_Products_MouseDoubleClick;
        }

        private void listBox_Products_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selected = listBox_Products.SelectedItem;

            var selectedProduct = (Product)selected;

            sp.SName = selectedProduct.Name;
            sp.SContent= selectedProduct.Content;
            sp.SPrice = selectedProduct.Price;
            sp.SPhoto = selectedProduct.Photo;

            sp.ShowDialog();
        }
    }
}
