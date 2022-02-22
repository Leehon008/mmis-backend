using AutoMapper;
using MMIS.BusinessLogicLayer.Shift.Contract;
using MMIS.DataAccessLayer.Contracts;
using MMIS.DataAccessLayer.Shared.Contracts;
using MMIS.DomainLayer.Entities.Shifts;
using MMIS.DomainLayer.Models.Shift;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMIS.BusinessLogicLayer.Shift
{
    public class EndShiftLogic : IEndShiftLogic
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IEndShiftRepository _inspectRepository;

            public EndShiftLogic(IMapper mapper, IUnitOfWork unitOfWork, IEndShiftRepository inspectRepository)
            {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
                _inspectRepository = inspectRepository;
            }

        public void Update(string id, string status)
        {
            _inspectRepository.Update(id,status);
        }

        public ShiftResultDto Create(EndShift model)
        {
            var endshift = _mapper.Map<EndShift>(model);
            _inspectRepository.Add(endshift);
            _unitOfWork.Commit();
            return new ShiftResultDto { endshift = endshift };
        }

    }

}
    
