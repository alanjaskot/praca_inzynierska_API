using PracaInzynierskaAPI.Entities.NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.DataBase.Repository.NLog
{
    public interface INLogRepository
    {
        IEnumerable<NLogDbModel> GetAll();
        IEnumerable<NLogDbModel> GetByDateTimeRange(DateTime dateTimeFrom, DateTime dateTimeTo);
    }
}
