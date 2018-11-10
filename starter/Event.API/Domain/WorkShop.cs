using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Event.API.Domain
{
    public class WorkShop
    {
        public WorkShop()
        {
            WorkshopUsers = new List<WorkshopUser>();
        }
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool IsFree { get; set; }
        public List<WorkshopUser> WorkshopUsers { get; set; }
    }
}
