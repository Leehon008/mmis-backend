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
    public class PIMsPOMsRoboboxLogic : IPIMsPOMsRoboboxLogic
    {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IPIMsPOMsRoboboxRepository _Logic;

            public PIMsPOMsRoboboxLogic(IMapper mapper, IUnitOfWork unitOfWork, IPIMsPOMsRoboboxRepository Logic)
            {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
                _Logic = Logic;
            }

     
        public ShiftResultDto Create(PIMsPOMsRobobox model)
           {

                _Logic.Add(model);
                _unitOfWork.Commit();
               return new ShiftResultDto {robobox  =  model };
            }

        }
    }
