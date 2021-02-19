using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarId);  
            }

            Console.WriteLine("---------------GetCarsByBrandId-------------------");

            foreach (var cars in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(cars.BrandId);
            }

            Console.WriteLine("-----------GetCarsByColorId----------------");

            foreach (var carss in carManager.GetCarsByColorId(3))
            {
                Console.WriteLine(carss.ColorId);
            }
        }
    }
}
