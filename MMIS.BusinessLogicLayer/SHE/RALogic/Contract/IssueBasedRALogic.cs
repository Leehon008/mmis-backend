using MMIS.BusinessLogicLayer.Shared.Contracts;
using MMIS.DomainLayer.SHE.Entities;
using MMIS.DomainLayer.SHE.Models;
using System.Threading.Tasks;

namespace MMIS.BusinessLogicLayer.SHE.RALogic.Contract
{
    public interface IIssueBasedRALogic : ILogic
    {
        Task<SHEResultDto> Create(IssueBasedRAHeader model);

    }
}
