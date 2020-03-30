using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vue2Spa.Areas.Portal.Models.DTO
{
    public class JobDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        public DateTime DateClosing { get; set; }
        public string Number { get; set; }
    }
}
