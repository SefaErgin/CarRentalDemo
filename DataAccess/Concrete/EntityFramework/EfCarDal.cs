using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarSqlContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarSqlContext context = new CarSqlContext())
            {
                var result = from c in context.Cars
                             join co in context.Colors
                             on c.CarId equals co.ColorId
                             select new CarDetailDto {CarId = c.CarId, Description = c.Description, DailyPrice=c.DailyPrice};

                return result.ToList();
            }

        }
    }
}
