using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.Models
{
    public class ArtType : ArtifactProperty
    {
        public int Id { get; set; }
        public string ArtTypeName { get; set; }
        public string ArtTypeDescription { get; set; }
    }
}