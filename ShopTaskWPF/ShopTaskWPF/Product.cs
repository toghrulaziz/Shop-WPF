using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ShopTaskWPF
{
    public class Product : INotifyPropertyChanged
    {
        private string? name;

        public string? Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        private string? content;

        public string? Content
        {
            get { return content; }
            set { content = value; OnPropertyChanged(); }
        }


        private string? photo;

        public string? Photo
        {
            get { return photo; }
            set { photo = value; OnPropertyChanged(); }
        }

        private double price;

        public double Price
        {
            get { return price; }
            set { price = value; OnPropertyChanged(); }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        public Product()
        {

        }


        public Product(string? name, string? content, string? photo, int price)
        {
            Name = name;
            Content = content;
            Photo = photo;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Name} {Content}";
        }
    }
}
