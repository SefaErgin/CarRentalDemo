using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {

                new Car{CarId=1, BrandId=1, ColorId=1, DailyPrice=100, ModelYear=2017, Description="Araçlarımızın günlük bakımı yapılmaktadır."},
                new Car{CarId=2, BrandId=2, ColorId=2, DailyPrice=150, ModelYear=2018, Description="Araçlarımızın günlük bakımı yapılmaktadır."},
                new Car{CarId=3, BrandId=3, ColorId=3, DailyPrice=200, ModelYear=2019, Description="Araçlarımızın günlük bakımı yapılmaktadır."},
                new Car{CarId=4, BrandId=4, ColorId=4, DailyPrice=250, ModelYear=2020, Description="Araçlarımızın günlük bakımı yapılmaktadır."},
                new Car{CarId=5, BrandId=5, ColorId=5, DailyPrice=300, ModelYear=2021, Description="Araçlarımızın günlük bakımı yapılmaktadır."}
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

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllByColor(int colorId)
        {
           return _cars.Where(c => c.ColorId == colorId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }
    }
}
