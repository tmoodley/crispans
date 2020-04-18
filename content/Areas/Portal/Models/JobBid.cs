using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vue2Spa.Areas.Portal.Models
{
    public class JobBid
    {

        public string JobId { get; set; }
        public Job Job { get; set; }

        public Guid BidderId { get; set; }
        public Vue2Spa.Models.Bidder Bidder { get; set; }

        public string Status { get; set; }

        public bool Deleted { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; }

        public DateTime LastUpdated { get; set; }

        public string LastUpdatedBy { get; set; }
    }
}
