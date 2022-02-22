using AutoMapper;
using MMIS.BusinessLogicLayer.Shared.PlantData.Contract;
using MMIS.BusinessLogicLayer.Shift.Contract;
using MMIS.DataAccessLayer.Contracts;
using MMIS.DataAccessLayer.Shared.Contracts;
using MMIS.DataAccessLayer.Users;
using MMIS.DomainLayer.Entities.Plants;
using MMIS.DomainLayer.Entities.Shifts;
using MMIS.DomainLayer.Models.Shift;
using MMIS.DomainLayer.Models.Users;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMIS.BusinessLogicLayer.Shared.PlantData
{
    public class PlantLogic : IPlantLogic
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPlantRepository _lineRepository;

        public PlantLogic(IMapper mapper, IUnitOfWork unitOfWork, IPlantRepository lineRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _lineRepository = lineRepository;
        }

       
        public  Task<List<Plant>> GetData()
        { 
            var shifts =  _lineRepository.GetData(); 
            _unitOfWork.Commit();
            return shifts;
        }

     
    }
}
