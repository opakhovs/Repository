using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.Models
{
    public class Project
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        
        public string ProjectOwner { get; set; }
        public DateTime LastRelease { get; set; }

        public virtual List<Artifact> Artifacts { get; set; }
    }
}