using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Repository.Viewmodels.ArtifactsViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<ArtifactViewModel> Artifacts { get; set; } = new List<ArtifactViewModel>();

        public MultiSelectList ArtTypes { get; set; }
        public MultiSelectList ProblemDomains { get; set; }
        public MultiSelectList Projects { get; set; }
        public MultiSelectList Ratings { get; set; }
        public MultiSelectList SubTasks { get; set; }
        public MultiSelectList Tags { get; set; }

        public String isAllMatchesSelected { get; set; }

        public int[] SelectedProperties { get; set; }
    }
}