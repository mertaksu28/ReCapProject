using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            if (CheckCar(rental.CarId).Success)
            {
                if (CheckReturnDate(rental.CarId).Success)
                {
                    return new ErrorResult(Messages.DidntAdd);
                }
            }

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int Id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == Id));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.Updated);
        }

        public IResult CheckCar(int carId)
        {
            var result = _rentalDal.GetAll();
            foreach (var rental in result)
            {
                if (rental.CarId == carId)
                {
                    return new SuccessResult();
                }
            }
            return new ErrorResult();
        }

        public IResult CheckReturnDate(int carId)
        {
            var result = _rentalDal.Get(r => r.CarId == carId);
            if (result.ReturnDate == null)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetail()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetail(), Messages.Listed);
        }
    }
}
