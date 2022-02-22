using AutoMapper;
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
using System.Linq;
using System.Threading.Tasks;

namespace MMIS.BusinessLogicLayer.Shift
{
    public class BeginShiftLogic : IBeginShiftLogic
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IShiftHeaderRepository _userRepository;
        private readonly MMISDbContext _context;

        public BeginShiftLogic(MMISDbContext context,IMapper mapper, IUnitOfWork unitOfWork, IShiftHeaderRepository userRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _context = context;
        }

        public async Task<List<ShiftHeader>> GetActiveShifts(string Plant)
        {
            var shifts = _userRepository.Get(x => x.StatusId == 1,z=>z.PlantId == Plant, null, "").ToList();
          
            _unitOfWork.Commit();
            return shifts;
        }
        public async Task<List<ShiftHeader>> GetShifts(string Plant, string moduleId)
        {
            var shifts = _context.ShiftHeader.Where(x => x.ShiftGroupId == moduleId && x.PlantId == Plant && x.ShiftStartDate > DateTime.Now.AddDays(-365));

            //.Get(x => x.ShiftStartDate > DateTime.Now.AddDays(-7),y=>y.ShiftGroupId == moduleId, z => z.PlantId == Plant, null, "").ToList();

            _unitOfWork.Commit();
            return shifts.ToList();
        }

        public async Task<ShiftHeader> GetShift(string Id)
        {
            var shift = _context.ShiftHeader.Find(Id);
            _unitOfWork.Commit();
            return shift;
        }

        public async Task<ShiftResultDto> BeginShift(ShiftHeader model)
        {
            var shift = _mapper.Map<ShiftHeader>(model);
            int interval = 1;
            do
            {
                DateTime start = shift.ShiftStartDate.AddHours((interval - 1));
                DateTime end = shift.ShiftStartDate.AddHours(interval) < shift.ShiftEndDate ? shift.ShiftStartDate.AddHours(interval) : shift.ShiftEndDate;
                int length = (int) end.Subtract(start).TotalMinutes;
                shift.LWIntervals.Add(new LWInterval
                {
                    Interval = interval,
                    Start = start,
                    End = end,
                    Length = length
                });
            } while (shift.ShiftStartDate.AddHours(interval++) <= shift.ShiftEndDate);

            _userRepository.Add(shift);
            _unitOfWork.Commit();
            return new ShiftResultDto { shiftHeader = shift };
        }
    }
}