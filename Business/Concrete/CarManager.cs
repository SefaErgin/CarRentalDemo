using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CorssCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IColorService _colorService;

        public CarManager(ICarDal carDal, IColorService colorService)
        {
            _carDal = carDal;
            _colorService = colorService;
        }

       // [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfCarCountOfColorCorrect(car.ColorId), CheckIfColorLimitExceded());

            if (result != null)
            {
                return result;
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded); 
           
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice<10)
            {
                throw new Exception("");
            }
            Add(car);

            return null;
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 10)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetAllByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>> (_carDal.GetAll(c => c.ColorId == colorId));
        }

        public IDataResult<List<Car>> GetAllByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>> (_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c=>c.CarId==carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {

            var result = _carDal.GetAll(c => c.ColorId == car.ColorId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.CarCountOfColorError);
            }
            throw new NotImplementedException();
        }

        //Bir renkten en fazla 10 araba olabilir.
        private IResult CheckIfCarCountOfColorCorrect(int colorId)
        {
            //Select count (*) from cars where colorId=1        bu kod joinlerde bu kodlarla aynı işlemler 
            var result = _carDal.GetAll(c => c.ColorId == colorId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.CarCountOfColorError);
            }

            return new SuccessResult();
        } 

        private IResult CheckIfColorLimitExceded()
        {
            var result = _colorService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.ColorLimitExceded);
            }
            return new SuccessResult();
        }
    }
}
