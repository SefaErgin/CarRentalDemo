using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface ICarService
    {
        IDataResult<List<Car>> GetAll();

        IDataResult<List<Car>> GetAllByColorId(int colorId);

        IDataResult<List<Car>> GetAllByDailyPrice(decimal min, decimal max);

        IDataResult<List<CarDetailDto>> GetCarDetails();

        IResult Add(Car car);

        IDataResult<Car> GetById(int carId);

        IResult Update(Car car);

        IResult AddTransactionalTest(Car car);
    }
}
