using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.Models
{
    public class ArtifactProperty
    {
        public int Iden { get; set; }
        public string Desciption { get; set; }
        public DateTime DateOfAdding { get; set; }
        public string Version { get; set; }
    }
}