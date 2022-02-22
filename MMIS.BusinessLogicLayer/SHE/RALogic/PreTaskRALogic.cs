using AutoMapper;
using MMIS.BusinessLogicLayer.SHE.RALogic.Contract;
using MMIS.DataAccessLayer.Contracts;
using MMIS.DataAccessLayer.Shared.Contracts;
using MMIS.DomainLayer.SHE.Entities;
using MMIS.DomainLayer.SHE.Models;
using System.Threading.Tasks;

namespace MMIS.BusinessLogicLayer.SHE.RALogic
{
    public class PreTaskRALogic : IPreTaskRALogic
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPreTaskRARepository _Repository;

        public PreTaskRALogic(IMapper mapper, IUnitOfWork unitOfWork, IPreTaskRARepository Repository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _Repository = Repository;
        }

    
        public async Task<SHEResultDto> Create(PreTaskRAHeader model)
        {
            var data = _mapper.Map<PreTaskRAHeader>(model);
            _Repository.Add(data);
            _unitOfWork.Commit();
            return new SHEResultDto { PreTask = data };
        }
    }
}