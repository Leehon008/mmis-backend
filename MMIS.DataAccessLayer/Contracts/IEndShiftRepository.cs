﻿using MMIS.DataAccessLayer.Shared.Contracts;
using MMIS.DomainLayer.Entities.Shifts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMIS.DataAccessLayer.Contracts
{
    public interface IEndShiftRepository : IRepository<EndShift>
    {

        public void Update(string id, string status);



    }
}
