using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // CarTest();

            // ColorTest();

            // JoinIslemi();

            //ResultTest();

        }

        //private static void ResultTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());

        //    var result = carManager.GetCarDetails();

        //    if (result.Success)
        //    {
        //        foreach (var car in result.Data)
        //        {
        //            Console.WriteLine(car.Description + "/" + car.DailyPrice);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine(result.Message);
        //    }
        //}

        //private static void JoinIslemi()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal(), new ColorManager(new EfColorDal()));

        //    foreach (var car in carManager.GetCarDetails().Data)
        //    {
        //        Console.WriteLine(car.Description + "/" + car.DailyPrice);
        //    }
        //}

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        //private static void CarTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());

        //    /* 
             
        //    foreach (var car in carManager.GetAllByDailyPrice(150, 250))
        //    {
        //        Console.WriteLine(car.DailyPrice);
        //    }

        //    */
        //}
    }
}
