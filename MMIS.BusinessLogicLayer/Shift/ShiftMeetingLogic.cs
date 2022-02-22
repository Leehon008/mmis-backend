using AutoMapper;
using MMIS.BusinessLogicLayer.Shift.Contract;
using MMIS.DataAccessLayer.Contracts;
using MMIS.DataAccessLayer.Shared.Contracts;
using MMIS.DataAccessLayer.Users;
using MMIS.DomainLayer.Entities.Shifts;
using MMIS.DomainLayer.Models.Shift;
using MMIS.DomainLayer.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMIS.BusinessLogicLayer.Shift
{
    public class ShiftMeetingLogic : IShiftMeetingsLogic
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IShiftMeetingRepository _ishiftMeetingRepository;

        public ShiftMeetingLogic(IMapper mapper, IUnitOfWork unitOfWork, IShiftMeetingRepository shiftRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _ishiftMeetingRepository = shiftRepository;
        }


        public async Task<List<ShiftMeetingActions>> GetMeetingActions(string ShiftName)
        {
            string status = "Not Completed";
            var shifts = _ishiftMeetingRepository.Get(x => x.ShiftName == ShiftName, x => x.Status == status, q => q.OrderBy(s => s.ShiftName), "").ToList();
            _unitOfWork.Commit();
            return shifts;
        }

        public ShiftMeetingActions GetActionItemById(string Id)
        {
            var actionItems = _ishiftMeetingRepository.GetByStingId(Id);
            _unitOfWork.Commit();
            return actionItems;
        }

        public void UpdateActionItem(ShiftMeetingActions model)
        {
           
            _ishiftMeetingRepository.UpdateActionItem(model);
            _unitOfWork.Commit();


        }

       public void UpdateTaskItem(string id)
        {
            _ishiftMeetingRepository.UpdateTaskItem(id);
        }
    } }