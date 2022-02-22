using AutoMapper;
using MMIS.BusinessLogicLayer.Operators.Contract;
using MMIS.DataAccessLayer.Contracts;
using MMIS.DataAccessLayer.Shared.Contracts;
using MMIS.DomainLayer.Models.Users;
using System.Linq;
using System.Threading.Tasks;

namespace MMIS.BusinessLogicLayer.Shift
{
    public class OperatorLogic : IOperatorLogic
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOperatorRepository _operatorRepository;

        public OperatorLogic(IMapper mapper, IUnitOfWork unitOfWork, IOperatorRepository operatorRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _operatorRepository = operatorRepository;
        }

        public async Task<PersonnelResultDto> GetOperators(string Id)
        {
            var ops = _operatorRepository.Get(x => x.PlantId == Id, q => q.OrderBy(s => s.PlantId), "").ToList();
            _unitOfWork.Commit();
            return new PersonnelResultDto { ops = ops };
        }


        public async Task<PersonnelResultDto> GetOperators(string Id,string moduleId)
        {
            var ops = _operatorRepository.Get(x => x.PlantId == Id && x.OperatorGroupId == moduleId, q => q.OrderBy(s => s.PlantId), "").ToList();
            _unitOfWork.Commit();
            return new PersonnelResultDto { ops = ops };
        }
    }
}
