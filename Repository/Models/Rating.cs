using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.Models
{
    public class Rating : ArtifactProperty
    {
        public int Id { get; set; }
        public int RateValue { get; set; }
        public string ValuseDescription { get; set; }
    }
}