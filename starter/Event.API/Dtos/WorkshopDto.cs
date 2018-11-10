using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event.API.Dtos
{
    public class WorkshopDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool IsFree { get; set; }
        public bool IsUserSubscribed { get; set; }
    }
}
