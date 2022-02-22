using AutoMapper;
using MMIS.DataAccessLayer.Contracts;
using MMIS.DataAccessLayer.Shared.Contracts;
using MMIS.DomainLayer.SHE.Entities;
using MMIS.DomainLayer.SHE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMIS.BusinessLogicLayer.SHE.Contract
{
    public class AppointmentLogic : IAppointments
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppointmentsRepository _Repository;

        public AppointmentLogic(IMapper mapper, IUnitOfWork unitOfWork, IAppointmentsRepository Repository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _Repository = Repository;
        }

        public async Task<List<Appointments>> GetData()
        {

           var data = await  _Repository.GetData();
            return data;
        }

        public async Task<SHEResultDto> Create(Appointments model)
        {
             var data = _mapper.Map<Appointments>(model);
            _Repository.Add(data);
            _unitOfWork.Commit();
            return new SHEResultDto { appointments = data };
        }

        public async Task Update(Appointments model)
        {
            var data = _mapper.Map<Appointments>(model);
            _Repository.Update(data);
            _unitOfWork.Commit();
         
        }
    }
}