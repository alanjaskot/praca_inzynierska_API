using AutoMapper;
using NLog;
using PracaInzynierskaAPI.DataBase.UnitOfWork;
using PracaInzynierskaAPI.Entities.NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Application.Services.NLog
{
    public class NLogService: INLogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private static IMapper _mapper;
        private ILogger _logger;

        public NLogService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public IEnumerable<NLogDbModel> GetAllNLogs()
        {
            var result = default(IEnumerable<NLogDbModel>);
            try
            {
                result = _unitOfWork.GetNLogRepository.GetAll();
            }
            catch (Exception err)
            {
                _logger.Error(err, "NLogService.GetAllNLogs");
                throw;
            }
            return result;
        }

        public IEnumerable<NLogDbModel> GetNLogsByDateTimeRange(DateTime dateTimeFrom, DateTime dateTimeTo)
        {
            var result = default(IEnumerable<NLogDbModel>);
            try
            {
                result = _unitOfWork.GetNLogRepository.GetByDateTimeRange(dateTimeFrom, dateTimeTo);
            }
            catch (Exception err)
            {
                _logger.Error(err, "NLogService.GetAllNLogs");
                throw;
            }
            return result;
        }
    }
}
