using System;
using System.Collections.Generic;
using Entity;
using Data;

namespace Business
{
    public class BProduct
    {
        private DProduct data;

        public BProduct()
        {
            data = new DProduct();
        }

        public List<Product> GetByName(string name)
        {
            List<Product> result = new List<Product>();

            var products = data.Get();

            foreach (var product in products)
            {
                if (product.Name == name)
                {
                    result.Add(product);
                }
            }

            return result;
        }

        public void CreateProduct(Product product)
        {

            data.Create(product);
        }
    }
}