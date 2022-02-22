using AutoMapper;
using MMIS.BusinessLogicLayer.Shift.Contract;
using MMIS.DataAccessLayer.Contracts;
using MMIS.DataAccessLayer.Shared.Contracts;
using MMIS.DataAccessLayer.Users;
using MMIS.DomainLayer.Entities.Shifts;
using MMIS.DomainLayer.Models.Shift;
using MMIS.DomainLayer.Models.Users;
using System.Linq;
using System.Threading.Tasks;

namespace MMIS.BusinessLogicLayer.Shift
{
    public class TeamLeaderLogic : ITeamLeaderLogic
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITeamLeadersRepository _teamleaderRepository;

        public TeamLeaderLogic(IMapper mapper, IUnitOfWork unitOfWork, ITeamLeadersRepository teamleaderRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _teamleaderRepository = teamleaderRepository;
        }

       
        public async Task<PersonnelResultDto> GetTeamLeaderById(string PlantId)
        { 
            var shifts =  _teamleaderRepository.Get(x => x.PlantId == PlantId, q => q.OrderBy(s => s.PlantId),"").ToList(); 
            _unitOfWork.Commit();
            return new PersonnelResultDto { teamLeaders = shifts };
        }

        
    }
}
