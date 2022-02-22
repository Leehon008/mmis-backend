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
    public class CMArtisanLogic : ICMArtisanLogic
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            private readonly ICMArtisanRepository _repository;

            public CMArtisanLogic(IMapper mapper, IUnitOfWork unitOfWork, ICMArtisanRepository repository)
            {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
                _repository = repository;
            }

        public void Update(string id)
        {
            _repository.Update(id);
        }

        public ShiftResultDto Create(List<CMArtisanInput> model)
            {
                  var data = _mapper.Map <List<CMArtisanInput>>(model);
                _repository.Add(data);
                _unitOfWork.Commit();
              return new ShiftResultDto { CMArtisan = data };
            }

            public List<CMArtisanInput> Get(string ShiftNo)
            {
                var data = _repository.Get(x=>x.ShiftNo == ShiftNo, c =>c.OrderBy(x=>x.Id), "").ToList();
                _unitOfWork.Commit();
                return data;
            }
        }
    }
