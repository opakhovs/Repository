using Repository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Repository.Repositories
{
    public class SQLContext:DbContext
    {
        public SQLContext() : base("DbConnection") { }

        public DbSet<Artifact> Artifacts { get; set; }
        public DbSet<ArtifactProperty> ArtifactProperties { get; set; }
        public DbSet<ArtType> ArtTypes { get; set; }
        public DbSet<ProblemDomain> ProblemDomains { get; set; }
        public DbSet<SubTask> SubTasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}