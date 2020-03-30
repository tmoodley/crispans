using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vue2Spa.Areas.Portal.Models.DTO
{
    public class JobQuestionCreateDto
    {
        public string JobId { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }

        [Display(Name ="Title")]
        public string QuestionTitle { get; set; }
        [Display(Name="Body")]
        public string QuestionBody { get; set; }
    }
}
