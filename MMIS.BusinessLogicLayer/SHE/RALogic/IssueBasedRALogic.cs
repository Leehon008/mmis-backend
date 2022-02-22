using AutoMapper;
using MMIS.BusinessLogicLayer.SHE.RALogic.Contract;
using MMIS.DataAccessLayer.Contracts;
using MMIS.DataAccessLayer.Shared.Contracts;
using MMIS.DomainLayer.SHE.Entities;
using MMIS.DomainLayer.SHE.Models;
using System.Threading.Tasks;

namespace MMIS.BusinessLogicLayer.SHE.RALogic
{
    public class IssueBasedRALogic : IIssueBasedRALogic
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIssueBasedRARepository _Repository;

        public IssueBasedRALogic(IMapper mapper, IUnitOfWork unitOfWork, IIssueBasedRARepository Repository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _Repository = Repository;
        }

    
        public async Task<SHEResultDto> Create(IssueBasedRAHeader model)
        {
            var data = _mapper.Map<IssueBasedRAHeader>(model);
            _Repository.Add(data);
            _unitOfWork.Commit();
            return new SHEResultDto { issueBased = data };
        }
    }
}