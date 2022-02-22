using AutoMapper;
using MMIS.BusinessLogicLayer.Shift.Contract;
using MMIS.DataAccessLayer.Contracts;
using MMIS.DataAccessLayer.Shared.Contracts;
using MMIS.DomainLayer.Entities.Shifts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMIS.BusinessLogicLayer.Shift
{
    public class LineLogic : ILineLogic
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILineRepository _lineRepository;

        public LineLogic(IMapper mapper, IUnitOfWork unitOfWork, ILineRepository lineRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _lineRepository = lineRepository;
        }

       
        public async Task<List<Lines>> GetLineById(string PlantId)
        { 
            var shifts =  _lineRepository.Get(x => x.PlantId == PlantId, q => q.OrderBy(s => s.PlantId),"").ToList(); 
            _unitOfWork.Commit();
            return shifts;
        }

        
    }
}
