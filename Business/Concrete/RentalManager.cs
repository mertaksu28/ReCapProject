using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IDataResult<List<RentalDetailDto>> GetRentalDetail()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetail(), Messages.Listed);
        }
        public IResult CheckCar(int carId)
        {
            var result = _rentalDal.GetAll();
            foreach (var rental in result)
            {
                if (rental.CarId == carId)
                {

                    if (CheckReturnDate(carId).Success)
                    {
                        return new SuccessResult("Araç Kiralanabilir");

                    }
                    return new ErrorResult("Araç Kiralanamaz");
                }

            }

            return new SuccessResult("Araç Kiralanabilir");


        }

        private IResult CheckReturnDate(int carId)
        {


            var result = _rentalDal.GetAll(c => c.CarId == carId).LastOrDefault();


            if (result.ReturnDate != null)
            {
                return new SuccessResult();
            }


            return new ErrorResult();
        }

    }
}
