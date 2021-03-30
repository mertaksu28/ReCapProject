using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _cardal;

        public CarManager(ICarDal cardal)
        {
            _cardal = cardal;
        }
        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]

        public IResult Add(Car car)
        {
            if (car.Description.Length < 2)
            {
                return new ErrorResult(Messages.DidntAdd);
            }
            _cardal.Add(car);
            return new SuccessResult(Messages.Added);
        }
        [CacheAspect]
        [PerformanceAspect(1)]

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_cardal.GetAll(), Messages.Listed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_cardal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_cardal.GetAll(p => p.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_cardal.GetAll(p => p.ColorId == id));
        }

        public IDataResult<Car> GetById(int Id)
        {
            return new SuccessDataResult<Car>(_cardal.Get(p => p.Id == Id));
        }

        public IResult Update(Car car)
        {
            _cardal.Update(car);
            return new SuccessResult(Messages.Updated);
        }

        public IResult Delete(Car car)
        {
            _cardal.Delete(car);
            return new SuccessResult();
        }
        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 150)
            {
                throw new Exception("Fiyat 150 den küçük");
            }
            Add(car);
            return null;

        }
    }
}
