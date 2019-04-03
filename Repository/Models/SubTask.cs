using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.Models
{
    public class SubTask : ArtifactProperty
    {
        public int Id { get; set; }
        public string SubTaskName { get; set; }
        public string SubTaskDescription { get; set; }
    }
}