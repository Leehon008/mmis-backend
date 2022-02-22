using AutoMapper;
using MMIS.BusinessLogicLayer.Shared.UserData.Contract;
using MMIS.DataAccessLayer.Contracts;
using MMIS.DataAccessLayer.Shared.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMIS.BusinessLogicLayer.Shared.UserGroupData
{
    public class UserGroupLogic : IUserGroupLogic
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserGroupRepository _repository;

        public UserGroupLogic(IMapper mapper, IUnitOfWork unitOfWork, IUserGroupRepository repository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

       
        public  Task<List<DomainLayer.Entities.Users.UserGroup>> GetData()
        { 
            var shifts =  _repository.GetData(); 
            _unitOfWork.Commit();
            return shifts;
        }

     
    }
}
