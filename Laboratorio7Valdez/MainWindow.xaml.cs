using Business;
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
using Entity;

namespace Laboratorio7Valdez
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BProduct business = new BProduct();
            string name = txtName.Text;
            var products = business.GetByName(name);
            dataGrid.ItemsSource = products;
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            BProduct business = new BProduct();
            string name = txtName1.Text;
            decimal price = Convert.ToDecimal(txtPrice.Text);
            int stock = Convert.ToInt32(txtStock.Text);

            Product newProduct = new Product
            {
                Name = name,
                Price = price,
                Stock = stock
            };

            business.CreateProduct(newProduct);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            BProduct business = new BProduct();
            Button deleteButton = (Button)sender;
            int productId = (int)deleteButton.Tag;
            business.DeleteProduct(productId);
            
            string name = txtName.Text;
            var products = business.GetByName(name);
            dataGrid.ItemsSource = products;
        }
    }
}