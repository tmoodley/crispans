using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vue2Spa.Areas.Bidder.Models.DTO
{
    public class MyBidsDto
    {
        public string Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string BidStatus { get; set; }
        public string JobStatus { get; set; }
        public string Source { get; set; }
        
        public Guid BidderId { get; set; }

    }
}
