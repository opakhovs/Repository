﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.Models
{
    public class Artifact
    {
        public int ArtifactId { get; set; }
        public DateTime DateOfAdding { get; set; }
        public string Version { get; set; }

        public virtual List<ArtifactProperty> Properties { get; set; } = new List<ArtifactProperty>();
        public virtual List<Project> Projects { get; set; } = new List<Project>();

    }
}