using ParkingManager.BusinessLogic.FactoryMethod.TikcetT;

namespace ParkingManager.BusinessLogic.FactoryMethod.FactoryService
{
    public interface IFactoryTicketService
    {
        IParkingTicket CreateDailyTicket(DateTime? issueAt = null);
        IParkingTicket CreateHourlyTicket(DateTime? issueAt = null);
    }
}
