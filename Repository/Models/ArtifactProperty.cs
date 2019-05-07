using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.Models
{
    public class ArtifactProperty : Property
    {
        public virtual List<Artifact> Artifacts { get; set; } = new List<Artifact>();
    }
}