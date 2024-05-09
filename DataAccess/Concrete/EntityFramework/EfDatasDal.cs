// EfDatasDal.cs
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using NLog;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfDatasDal : EfEntityRepositoryBase<Datas, ErrorLogDatbaseContext>, IDatasDal
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        
        public void LogDataWithZeroData()
        {
            
            using (ErrorLogDatbaseContext context = new ErrorLogDatbaseContext())
            {
                var zeroDataIds = context.Datas.Where(d => d.Data == 0).Select(d => d.Id).ToList();
                if (zeroDataIds.Any())
                {
                    string message = "Data values are zero for DataIds: " + string.Join(", ", zeroDataIds);
                    logger.Info(message);
                    AddErrorToDatabase(message);
                }
            }
        }

        private void AddErrorToDatabase(string errorMessage)
        {
            using (ErrorLogDatbaseContext context = new ErrorLogDatbaseContext())
            {
                Errors error = new Errors
                {
                    ErrorExplanation = errorMessage
                };
                context.Errors.Add(error);
                context.SaveChanges();
            }
        }
    }
}