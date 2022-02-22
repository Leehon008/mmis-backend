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
    public class DIArtisanLogic : IDIArtisanLogic
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IDIArtisanRepository _repository;

            public DIArtisanLogic(IMapper mapper, IUnitOfWork unitOfWork, IDIArtisanRepository repository)
            {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
                _repository = repository;
            }

        public void Update(string id)
        {
            _repository.Update(id);
        }

        public ShiftResultDto Create(List<DIArtisanInput> model)
            {
                  var data = _mapper.Map <List<DIArtisanInput>>(model);
                _repository.Add(data);
                _unitOfWork.Commit();
              return new ShiftResultDto { artisan = data };
            }

            public List<DIArtisanInput> Get(string ShiftNo)
            {
                var data = _repository.Get(x=>x.ShiftNo == ShiftNo, c =>c.OrderBy(x=>x.Id), "").ToList();
                _unitOfWork.Commit();
                return data;
            }
        }
    }
