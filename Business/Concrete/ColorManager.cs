using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            _colorDal.Add(color);

            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);

            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        //Select * from Colors where ColorId=3   gibi bir kod oluyor sql tarafında
        public IDataResult<Color> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(co => co.ColorId == colorId));
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);

            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
