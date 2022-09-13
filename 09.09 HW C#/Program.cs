

namespace ConsoleApp12
{
    class Program
    {

        public static void Main()
        {
            var pizza = new Product(2, 2, "Pizza");
            var sushi = new Product(2, 2, "sushi");
            var milk = new Product(3, 4, "milk");
            var TV = new Product(100, 2, "TV");

            var cashRegister = new CashRegister(pizza);
            cashRegister.AddProduct(sushi);
            cashRegister.AddProduct(milk);
            cashRegister.AddProduct(TV);
            cashRegister.BuyProduct("pizza");
            cashRegister.SaveAs("aaa.txt");
            Console.WriteLine(cashRegister.ToString());
        }
    }
}
