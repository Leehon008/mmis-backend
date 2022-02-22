using AutoMapper;
using MMIS.BusinessLogicLayer.Shared.UserData.Contract;
using MMIS.DataAccessLayer.Contracts;
using MMIS.DataAccessLayer.Shared.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMIS.BusinessLogicLayer.Shared.UserTypeData
{
    public class UserTypeLogic : IUserTypeLogic
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserTypeRepository _repository;

        public UserTypeLogic(IMapper mapper, IUnitOfWork unitOfWork, IUserTypeRepository repository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

       
        public  Task<List<DomainLayer.Entities.Users.UserType>> GetData()
        { 
            var shifts =  _repository.GetData(); 
            _unitOfWork.Commit();
            return shifts;
        }

     
    }
}
