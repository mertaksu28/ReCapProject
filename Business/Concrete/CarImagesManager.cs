using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImagesManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImagesManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;

        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(
                CheckIfImageCountLimit(carImage.CarId)
                );

            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.AddAsync(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            IResult result = BusinessRules.Run(
                 FileHelper.DeleteAsync(_carImageDal.Get(p => p.Id == carImage.Id).ImagePath));

            if (result != null)
            {
                return result;
            }

            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            List<CarImage> list = new List<CarImage>();
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result == 0)
            {
                CarImage carImage = new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = @"C:\Users\MERT\Desktop\Dosyalarım\Engin Hoca\Rent a Car\ReCapProject\Business\Uploads\BMW.jpg" };
                list.Add(carImage);
                return new SuccessDataResult<List<CarImage>>(list);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(
                CheckIfImageCountLimit(carImage.CarId)
                );

            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.UpdateAsync(_carImageDal.Get(p => p.Id == carImage.Id).ImagePath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();

        }

        private IResult CheckIfImageCountLimit(int CarId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == CarId).Count;
            if (result >= 5)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }
    }
}
