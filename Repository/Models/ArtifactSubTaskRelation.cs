using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.Models
{
    public class ArtifactSubTaskRelation
    {
        public ArtifactProperty ArtifactId { get; set; }
        public ProblemDomain ProblemDomainId { get; set; }
        public SubTask SubTaskId { get; set; }
    }
}