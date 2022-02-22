using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MMIS.BusinessLogicLayer.Shift.Contract;
using MMIS.DataAccessLayer.Contracts;
using MMIS.DataAccessLayer.Shared;
using MMIS.DataAccessLayer.Shared.Contracts;
using MMIS.DomainLayer.Entities.Shifts;
using MMIS.DomainLayer.Entities.Users;
using MMIS.DomainLayer.Models.Shift;
using MMIS.DomainLayer.Models.Users;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MMIS.BusinessLogicLayer.Shift
{
    public class LWHeaderLogic : ILWHeaderLogic
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILWHeaderRepository _userRepository;
        private readonly MMISDbContext _dbContext;
        public LWHeaderLogic(IMapper mapper, IUnitOfWork unitOfWork, ILWHeaderRepository userRepository, MMISDbContext dbContext)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _dbContext = dbContext;
        }
        public FeedBackPanevw GetFeedBack(string id)
        {

            IEnumerable<FeedBackPanevw> lstGate = from tbsite in _dbContext.FeedBackPanevw.Where(i=>i.ShiftNo ==id).ToList()
                                        select new FeedBackPanevw
                                        {
                                            PreviousHour =tbsite.PreviousHour.ToString(),
                                            ShiftNo = tbsite.ShiftNo,
                                            HourlyTPV = (tbsite.HourlyTPV == 0) ? 0 : Convert.ToDouble(tbsite.HourlyTPV),
                                            CumulativeTPV = (tbsite.CumulativeTPV == 0) ? 0 : Convert.ToDouble(tbsite.CumulativeTPV),
                                            CumulativeFactoryHours = (tbsite.CumulativeFactoryHours == 0) ? 0 : Convert.ToInt32(tbsite.CumulativeFactoryHours),
                                            FactoryEfficiency = (tbsite.FactoryEfficiency == 0) ? 0 : Convert.ToDouble(tbsite.FactoryEfficiency),
                                            MachineEfficiency = (tbsite.MachineEfficiency == 0) ? 0 : Convert.ToDouble(tbsite.MachineEfficiency),
                                        };
           // var user = _dbContext.FeedBackPanevw.FromSqlRaw("SELECT ShiftNo,PreviousHour,HourlyTPV  AS HourlyTPV, CumulativeTPV AS CumulativeTPV, CumulativeFactoryHours AS CumulativeFactoryHours, FactoryEfficiency AS FactoryEfficiency, MachineEfficiency AS MachineEfficiency FROM dbo.FeedBackPanevw where ShiftNo = '" + id + "'").ToList();

      
            return lstGate.FirstOrDefault();

        }
        public async Task<List<LossWasteHeader>> GetData(string Id)
        {
            var shifts = _userRepository.Get(null,null, null, "").ToList();
            _unitOfWork.Commit();
            return shifts;
        }
        public async Task<ShiftResultDto> CreateWL(LossWasteHeader model)
        {
            var lw = _mapper.Map<LossWasteHeader>(model);
            _userRepository.Add(lw);
            _unitOfWork.Commit();
            return new ShiftResultDto { lw = lw };
        }

      
     
    }
}