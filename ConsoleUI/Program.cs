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
            CarManagerTest();
            //BrandManagerTest();
            //ColorManagerTest();
            //Data Transformation Object = DTO

        }

        private static void ColorManagerTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void BrandManagerTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarManagerTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDeteails())
            {
                Console.WriteLine(car.BrandName + " : " + car.ColorName + " : " + car.DailyPrice);
            }

            //Console.WriteLine("---------------GetCarsByBrandId-------------------");

            //foreach (var cars in carManager.GetCarsByBrandId(1))
            //{
            //    Console.WriteLine(cars.BrandId);
            //}

            //Console.WriteLine("-----------GetCarsByColorId----------------");

            //foreach (var carss in carManager.GetCarsByColorId(3))
            //{
            //    Console.WriteLine(carss.ColorId);
            //}
        }
    }
}
