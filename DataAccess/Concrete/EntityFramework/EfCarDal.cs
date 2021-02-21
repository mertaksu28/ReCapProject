using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from p in context.Cars
                             join b in context.Brands on p.CarId equals b.BrandId
                             select
                             new CarDetailDto { CarId = p.CarId, BrandName = b.BrandName, DailyPrice = p.DailyPrice, };
                return result.ToList();
            }
        }
    }
}
