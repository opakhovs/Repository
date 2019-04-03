using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.Models
{
    public class ProblemDomain : ArtifactProperty
    {
        public int Id { get; set; }
        public string ProblemDomainName { get; set; }
        public string ProblemDomainDecription { get; set; }
        public List<SubTask> SubTasks { get; set; }
    }
}