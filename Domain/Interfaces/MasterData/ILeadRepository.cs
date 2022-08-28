using Core.Domain.MasterData;
using System.Threading.Tasks;

namespace Core.Interfaces.MasterData
{
    public interface ILeadRepository
    {
        Task ConvertLeadToContact(Contact contact);
        Task ConvertLeadToOpportunity(Opportunity opportunity);
    }
}