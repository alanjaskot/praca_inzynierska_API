using NLog;
using PracaInzynierskaAPI.DataBase.Context;
using PracaInzynierskaAPI.Entities.NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.DataBase.Repository.NLog
{
    public class NLogRepository: INLogRepository
    {
        private readonly IPInzDataBaseContext _context;
        private ILogger _logger;

        public NLogRepository(IPInzDataBaseContext context)
        {
            _context = context;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public IEnumerable<NLogDbModel> GetAll()
        {
            try
            {
                return _context.NLogs;
            }
            catch (Exception err)
            {
                _logger.Error(err, "LogsRepostitory_GetAll");
                throw;
            }
        }

        public IEnumerable<NLogDbModel> GetByDateTimeRange(DateTime dateTimeFrom, DateTime dateTimeTo)
        {
            try
            {
                return _context.NLogs
                    .Where(p => p.CreatedAt >= dateTimeFrom 
                    && p.CreatedAt <= dateTimeTo);
            }
            catch (Exception err)
            {
                _logger.Error(err, "LogsRepostitory_GetByDateTimeRange");
                throw;
            }
        }
    }
}
