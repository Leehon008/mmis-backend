using AutoMapper;
using MMIS.BusinessLogicLayer.Shift.Contract;
using MMIS.DataAccessLayer.Contracts;
using MMIS.DataAccessLayer.Shared.Contracts;
using MMIS.DomainLayer.Entities.Shifts;
using MMIS.DomainLayer.Models.Shift;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMIS.BusinessLogicLayer.Shift
{
    public class DIPlannerLogic : IDIPlannerLogic
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IDIPlannerRepository _repository;

            public DIPlannerLogic(IMapper mapper, IUnitOfWork unitOfWork, IDIPlannerRepository repository)
            {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
                _repository = repository;
            }

        public void Update(string id)
        {
            _repository.Update(id);
        }

        public ShiftResultDto Create(List<DIPlannerInput> model)
            {
                  var data = _mapper.Map <List<DIPlannerInput>>(model);
                _repository.Add(data);
                _unitOfWork.Commit();
              return new ShiftResultDto { planner = data };
            }

            public List<DIPlannerInput> Get(string ShiftNo)
            {
                var data = _repository.Get(x=>x.ShiftNo == ShiftNo, c =>c.OrderBy(x=>x.Id), "").ToList();
                _unitOfWork.Commit();
                return data;
            }
        }
    }
