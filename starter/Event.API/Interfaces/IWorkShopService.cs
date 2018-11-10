using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event.API.Domain;

namespace Event.API.Interfaces
{
    public interface IWorkShopService
    {
        Task SaveWorkshop(WorkShop workShop);
        Task<ICollection<WorkShop>> Get();
        Task<ICollection<WorkShop>> GetWithUsers();
        Task<ICollection<EventUser>> GetWorkshopUsers(Guid workShopGuid);
        Task SubscribeToWorkShop(Guid workShopGuid, Guid userGuid);
        Task UnSubscribeToWorkShop(Guid workShopGuid, Guid userGuid);
    }
}
