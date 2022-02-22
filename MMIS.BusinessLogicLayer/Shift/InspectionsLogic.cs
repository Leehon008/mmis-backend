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
    public class InspectionsLogic : IInspectionsLogic
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IInspectionRepository _inspectRepository;

            public InspectionsLogic(IMapper mapper, IUnitOfWork unitOfWork, IInspectionRepository inspectRepository)
            {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
                _inspectRepository = inspectRepository;
            }

        public void UpdateWorkAssignments(string id)
        {
            _inspectRepository.UpdateWorkAssignments(id);
        }

        public ShiftResultDto CreateInspections(List<Inspections> model)
            {
                  var inspections = _mapper.Map <List< Inspections>>(model);
                _inspectRepository.Add(inspections);
                _unitOfWork.Commit();
              return new ShiftResultDto { inspections = inspections };
            }

            public List<Inspections> GetInspections(string ShiftNo)
            {
                var shifts = _inspectRepository.Get(x=>x.ShiftNo == ShiftNo, x => x.Status == "Not Done", c =>c.OrderBy(x=>x.Id), "").ToList();
                _unitOfWork.Commit();
                return shifts;
            }
        public List<Inspections> GetInspections(string ShiftNo,string user)
        {
            var shifts = _inspectRepository.GetInspectionsAsync(ShiftNo, user).Result;
                _unitOfWork.Commit();
            return shifts;
        }
    }
    }
