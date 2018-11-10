using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event.API.Domain;

namespace Event.API.Data
{
    public static class EventDbContextExtensions
    {
        public static void EnsureSeedDataForContext(this EventDbContext context)
        {
            if (context.WorkShops.Any())
            {
                return;
            }

            var workshops = new List<WorkShop>
            {
                new WorkShop
                {
                    Id = new Guid("7BB3875D-F789-45D8-84D0-E24236820D7B"),
                    Description = "Angular + ASP.NET CORE + Idsvr4", IsFree = true
                },
                new WorkShop
                {
                    Id = new Guid("5CA87793-33C1-4718-89BC-9861706A2D70"), Description = "SignalR Core", IsFree = true
                },
                new WorkShop
                    {Id = new Guid("BC883F86-9FED-49D5-8C06-67C89986933A"), Description = "VueJs", IsFree = false},
                new WorkShop
                {
                    Id = new Guid("38EC9C2F-BB00-4F9A-8E2A-5A3AC0B325DC"), Description = "Xamarin Form", IsFree = false
                },
            };
            context.WorkShops.AddRange(workshops);
            context.SaveChanges();
        }
    }
}
