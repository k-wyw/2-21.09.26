using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21._09._26
{
    internal class Program
    {
        class Result<T>
        {
            public bool IsSuccess { get; set; }
            public T Value { get; set; }
            public string Error { get; set; }

            public static Result<T> Success(T value)
            {
                return new Result<T> { IsSuccess = true, Value = value };
            }

            public static Result<T> Failure(string error)
            {
                return new Result<T> { IsSuccess = false, Error = error };
            }
        }

        class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Count { get; set; }
        }

        static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Ноутбук", Price = 59999m, Count = 10 },
            new Product { Id = 2, Name = "Мышь", Price = 1200m, Count = 50 },
            new Product { Id = 3, Name = "Клавиатура", Price = 4500m, Count = 25 }
        };

        static Result<Product> FindProduct(int id)
        {
            foreach (Product product in products)
            {
                if (product.Id == id)
                {
                    return Result<Product>.Success(product);
                }
            }
            return Result<Product>.Failure("Товар не найден");
        }

        static void Main(string[] args)
        {
            Result<Product> result1 = FindProduct(1);
            Console.WriteLine("Поиск товара с ID 1:");
            if (result1.IsSuccess)
            {
                Console.WriteLine("Найден: " + result1.Value.Name + ", цена: " + result1.Value.Price);
            }
            else
            {
                Console.WriteLine(result1.Error);
            }

            Console.WriteLine();

            Result<Product> result2 = FindProduct(99);
            Console.WriteLine("Поиск товара с ID 99:");
            if (result2.IsSuccess)
            {
                Console.WriteLine("Найден: " + result2.Value.Name);
            }
            else
            {
                Console.WriteLine(result2.Error);
            }
        }
    }
}