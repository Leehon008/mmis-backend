using AutoMapper;
using MMIS.BusinessLogicLayer.Shift.Contract;
using MMIS.DataAccessLayer.Contracts;
using MMIS.DataAccessLayer.Shared.Contracts;
using MMIS.DomainLayer.Entities.Shifts;
using MMIS.DomainLayer.Models.Shift;
using MMIS.DomainLayer.Models.Users;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMIS.BusinessLogicLayer.Shift
{
    public class ResourceLogic : IResourceLogic
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IResourceRepository _shiftRepository;

        public ResourceLogic(IMapper mapper, IUnitOfWork unitOfWork, IResourceRepository shiftRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _shiftRepository = shiftRepository;
        }

       
        public  List<Resources> GetResources(string res)
        { 
            var shifts =  _shiftRepository.Get(x => x.ResourceCategoryId == res, q => q.OrderBy(s => s.ResourceName),"").ToList(); 
            _unitOfWork.Commit();
            return  shifts;
        }
        

    }
}
