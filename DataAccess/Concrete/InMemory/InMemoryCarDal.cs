using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{ CarId=1, BrandId="BMW", ColorId="Metalic", DailyPrice=1000, ModelYear=2021, Description="New Car"},
                new Car{ CarId=2, BrandId="Ferrari", ColorId="Mat", DailyPrice=2000, ModelYear=2019, Description="Old Car"},
                new Car{ CarId=3, BrandId="Volkswagen", ColorId="Metalic", DailyPrice=500, ModelYear=2017, Description="Nice Car"},
                new Car{ CarId=4, BrandId="Audi", ColorId="Saydam", DailyPrice=250, ModelYear=2011, Description="Old Car"},
                new Car{ CarId=5, BrandId="Mustang", ColorId="Metalic", DailyPrice=9000, ModelYear=2021, Description="Perfect Car"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(string brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;


        }
    }
}
