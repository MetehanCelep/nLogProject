using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class
    {
        List<T> GetAll();
    }
}