using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.Models
{
    public class Tag : ArtifactProperty
    {
        public string TagName { get; set; }
        public int TagUsage { get; set; }
    }
}