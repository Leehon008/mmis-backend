using Microsoft.AspNetCore.Http;
using MMIS.BusinessLogicLayer.Shared.Contracts;
using MMIS.DomainLayer.SHE.Entities;
using MMIS.DomainLayer.SHE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMIS.BusinessLogicLayer.SHE.Contract
{
    public interface IFileUploadLogic : ILogic
    {
        Task<string> UploadFile(IFormFile file, string module, string func);

    }
}
