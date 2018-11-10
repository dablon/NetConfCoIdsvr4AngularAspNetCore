using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Event.API.Domain
{
    public class EventUser
    {
        public EventUser()
        {
            WorkshopUsers = new List<WorkshopUser>();
        }

        public Guid Id { get; set; }
        public string FullName { get; set; }
        public List<WorkshopUser> WorkshopUsers { get; set; }
    }
}
