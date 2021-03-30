using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarManagerTest();
            //BrandManagerTest();
            //ColorManagerTest();
            //Data Transformation Object = DTO

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental = new Rental { CarId = 3, CustomerId = 1, RentDate = DateTime.Now };
            var result = rentalManager.Add(rental);
            Console.WriteLine(result.Message + "  " + result.Success);


        }

        private static void ColorManagerTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void BrandManagerTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarManagerTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails().Data)
            {

                Console.WriteLine(car.BrandName + " : " + car.ColorName + " : " + car.DailyPrice);
            }
            var result = carManager.Add(new Car { BrandId = 1, ColorId = 1, DailyPrice = 87665543, ModelYear = "2021", Description = "A" });
            Console.WriteLine(result.Message + " : " + result.Success);

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
