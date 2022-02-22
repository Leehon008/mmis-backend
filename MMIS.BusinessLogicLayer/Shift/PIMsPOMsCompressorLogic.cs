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
    public class PIMsPOMsCompressorLogic : IPIMsPOMsCompressorLogic
    {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IPIMsPOMsCompressorRepository _Logic;

            public PIMsPOMsCompressorLogic(IMapper mapper, IUnitOfWork unitOfWork, IPIMsPOMsCompressorRepository Logic)
            {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
                _Logic = Logic;
            }

     
        public ShiftResultDto Create(PIMsPOMsCompressor model)
           {

                _Logic.Add(model);
                _unitOfWork.Commit();
               return new ShiftResultDto {compressor  =  model };
            }

        }
    }
