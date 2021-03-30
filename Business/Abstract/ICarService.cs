using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<List<Car>> GetAllByColorId(int id);
        IDataResult<List<Car>> GetAllByBrandId(int id);
        IDataResult<List<Car>> GetAllDailyPrice(int min, int max);
        IDataResult<List<CarDetailDto>> GetCarDetail();
        IDataResult<List<CarDetailDto>> GetCarDetailByBrandId(int id);
        IDataResult<List<CarDetailDto>> GetCarDetailByColorId(int id);
        IDataResult<CarDetailDto> GetCarDetailById(int id);
        IDataResult<Car> GetCarByCarId(int id);
        IResult AddTransactionalTest(Car car);
        IDataResult<List<CarDetailDto>> GetCarsFilter(int brandId, int colorId);
    }

}
