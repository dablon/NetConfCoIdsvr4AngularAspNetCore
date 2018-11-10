using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event.API.Domain
{
    public class WorkshopUser
    {
        public Guid WorkshopId { get; set; }
        public WorkShop WorkShop { get; set; }
        public Guid EventUserId { get; set; }
        public EventUser EventUser { get; set; }
    }
}
