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
    public class PIMsPOMShrinkPackerLogic : IPIMsPOMsShrinkPackerLogic
    {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IPIMsPOMsShrinkPackerRepository _Logic;

            public PIMsPOMShrinkPackerLogic(IMapper mapper, IUnitOfWork unitOfWork, IPIMsPOMsShrinkPackerRepository Logic)
            {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
                _Logic = Logic;
            }

     
        public ShiftResultDto Create(PIMsPOMShrinkPacker model)
           {

                _Logic.Add(model);
                _unitOfWork.Commit();
               return new ShiftResultDto {spacker  =  model };
            }

        }
    }
