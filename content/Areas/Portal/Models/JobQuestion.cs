using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vue2Spa.Models;

namespace Vue2Spa.Areas.Portal.Models
{
    public class JobQuestion
    {
        public string JobId { get; set; }
        public Guid QuestionId { get; set; }

        public Guid? BidderId { get; set; }

        //-----------------------------
        //Relationships
        public Job Job { get; set; }
        public Question Question { get; set; }

        public Vue2Spa.Models.Bidder Bidder { get; set; }
    }
}
