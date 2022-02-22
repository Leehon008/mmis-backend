using AutoMapper;
using MMIS.BusinessLogicLayer.Shift.Contract;
using MMIS.DataAccessLayer.Contracts;
using MMIS.DataAccessLayer.Shared.Contracts;
using MMIS.DomainLayer.Entities.Shifts;
using MMIS.DomainLayer.Models.Shift;
using MMIS.DomainLayer.Models.Users;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMIS.BusinessLogicLayer.Shift
{
    public class ShiftsLogic : IShiftLogic
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IShiftRepository _shiftRepository;

        public ShiftsLogic(IMapper mapper, IUnitOfWork unitOfWork, IShiftRepository shiftRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _shiftRepository = shiftRepository;
        }

       
        public  List<Shifts> Shifts(string PlantId,string moduleId)
        { 
            var shifts =  _shiftRepository.Get(x => x.PlantId == PlantId && x.UserGroupId == moduleId, q => q.OrderBy(s => s.ShiftName),"").ToList(); 
            _unitOfWork.Commit();
            return  shifts;
        }
        public  List<Shifts> GetTasks(string ShiftName)
        {
            var shifts = _shiftRepository.Get(x => x.ShiftName == ShiftName, q => q.OrderBy(s => s.ShiftName), "").ToList();
            _unitOfWork.Commit();
            return  shifts ;
        }

    }
}
