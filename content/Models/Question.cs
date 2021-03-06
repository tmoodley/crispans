using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vue2Spa.Areas.Portal.Models;

namespace Vue2Spa.Models
{
    public class Question
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int Score { get; set; }

        public DateTime CreationTime { get; set; }
        [JsonIgnore]
        public ICollection<Answer> Answers { get; set; }
        [JsonIgnore]
        public ICollection<JobQuestion> JobQuestions { get; set; }
        [JsonIgnore]
        public ICollection<POQuestion> PurchaseOrderQuestions { get; set; }

    }

    public class Answer
    {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public string Body { get; set; }
    }
}
