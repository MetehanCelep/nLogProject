using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class DatasManager : IDatasService
    {
        IDatasDal _datasDal;

        public DatasManager(IDatasDal datasDal)
        {
            _datasDal = datasDal;
        }

        public List<Datas> GetAll()
        {
            return _datasDal.GetAll();
        }
    }
}