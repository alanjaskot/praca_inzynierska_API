using PracaInzynierskaAPI.Entities.NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Application.Services.NLog
{
    public interface INLogService
    {
        IEnumerable<NLogDbModel> GetAllNLogs();
        IEnumerable<NLogDbModel> GetNLogsByDateTimeRange(DateTime dateTimeFrom, DateTime dateTimeTo);
    }
}
