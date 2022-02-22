using AutoMapper;
using MMIS.BusinessLogicLayer.Shared.UserData.Contract;
using MMIS.DataAccessLayer.Contracts;
using MMIS.DataAccessLayer.Shared.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMIS.BusinessLogicLayer.Shared.UserRoleData
{
    public class UserRoleLogic : IUserRoleLogic
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRoleRepository _repository;

        public UserRoleLogic(IMapper mapper, IUnitOfWork unitOfWork, IUserRoleRepository repository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

       
        public  Task<List<DomainLayer.Entities.Users.UserRole>> GetData()
        { 
            var shifts =  _repository.GetData(); 
            _unitOfWork.Commit();
            return shifts;
        }

        public Task<List<DomainLayer.Entities.Users.UserRole>> GetData(string id)
        {
            var shifts = _repository.GetData(id);
            _unitOfWork.Commit();
            return shifts;
        }


    }
}
