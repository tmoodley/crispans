using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vue2Spa.Areas.Portal.Models;

namespace Vue2Spa.Models.DTO
{
    public class JobBidDto
    {
        public string JobId { get; set; }
        public Job Job { get; set; }

        public string BidderId { get; set; }
        //public Vue2Spa.Models.Bidder Bidder { get; set; }

        public string Status { get; set; }

        public bool Deleted { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; }

        public DateTime LastUpdated { get; set; }

        public string LastUpdatedBy { get; set; }

    }
}
