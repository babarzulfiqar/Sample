using Core.Domain.MasterData;
using Core.Interfaces.MasterData;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.MasterData
{
    public class LeadRepository : ILeadRepository
    {
        public Task ConvertLeadToContact(Contact contact)
        {
            throw new System.NotImplementedException();
        }
        public Task ConvertLeadToOpportunity(Opportunity opportunity)
        {
            throw new System.NotImplementedException();
        }
    }
}
