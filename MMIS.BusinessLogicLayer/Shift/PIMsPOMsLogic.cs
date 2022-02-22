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
    public class PIMsPOMsLogic : IPIMsPOMsLogic
    {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IPIMsPOMsRepository _pimsPomsLogic;

            public PIMsPOMsLogic(IMapper mapper, IUnitOfWork unitOfWork, IPIMsPOMsRepository pimsPomsLogic)
            {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
                _pimsPomsLogic = pimsPomsLogic;
            }

     
        public ShiftResultDto Create(List<PIMsPOMs> model)
            {
                  var pimsPoms = _mapper.Map <List<PIMsPOMs>>(model);
                _pimsPomsLogic.Add(pimsPoms);
                _unitOfWork.Commit();
              return new ShiftResultDto { pimsPoms = pimsPoms };
            }

        }
    }
