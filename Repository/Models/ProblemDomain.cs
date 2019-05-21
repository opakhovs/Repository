using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.Models
{
    public class ProblemDomain : ArtifactProperty
    {
        public virtual List<SubTask> SubTasks { get; set; } = new List<SubTask>();
    }
}