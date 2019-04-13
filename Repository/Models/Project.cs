using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.Models
{
    public class Project : ArtifactProperty
    {
        public string ProjectOwner { get; set; }
        public DateTime LastRelease { get; set; }
    }
}