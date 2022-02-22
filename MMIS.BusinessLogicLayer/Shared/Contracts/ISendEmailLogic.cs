using MMIS.DomainLayer.SHE.Entities;

namespace MMIS.BusinessLogicLayer.Shared.Contracts
{
    public interface ISendEmailLogic : ILogic
    {
        void sendEmail(IncidentLogging incidentLogging);
    }
}
