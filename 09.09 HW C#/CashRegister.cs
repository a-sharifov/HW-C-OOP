using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp12
{
   [Serializable]
    public class CashRegister
    {
        private Dictionary<string, Product> Products;

        public CashRegister(params Product[] product)
        {
            Products = new Dictionary<string, Product>();
            foreach (var item in product)
            {
                this.Products.Add(item.Name, item);
            }

        }
        public void AddProduct(Product Product)
        {
            if (!Products.ContainsKey(Product.Name)) Products.Add(Product.Name, Product);
        }
        public void DeleteProduct(Product Product)
        {
            if (Products.ContainsKey(Product.Name)) this.Products.Remove(Product.Name);
        }
        public void AddCount(string Name, uint Count)
        {
            if (Products.ContainsKey(Name)) this.Products[Name].Count = Count;
        }
        public void BuyProduct(string Name)
        {
            if (Products.ContainsKey(Name)) this.Products[Name].Count--;
        }
        public void PriceProduct(string Name, uint Price)
        {
            if (Products.ContainsKey(Name)) this.Products[Name].Price = Price;
        }

        public Product this[string Name]
        {
            get => this.Products[Name];
        }

        public void SaveAs(string Where)
        {
            using (FileStream sw = new FileStream(Where, FileMode.Create))
            {
                using (StreamWriter sw2 = new StreamWriter(sw))
                {
                    var options = new JsonSerializerOptions() { WriteIndented = true };
                    var serializer = JsonSerializer.Serialize(this.Products, options);
                    sw2.Write(serializer);
                }
            }
        }
        public override string ToString()
        {
            var AllProduct = new StringBuilder(this.Products.Count * 7);
            foreach (var item in this.Products)
            {
                AllProduct.AppendLine(item.Value.ToString());
            }
            return AllProduct.ToString();
        }

    }
}
