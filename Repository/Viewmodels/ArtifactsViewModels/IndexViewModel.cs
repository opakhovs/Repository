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

        public MultiSelectList ArtTypes;
        public MultiSelectList ProblemDomains;
        public MultiSelectList Projects;
        public MultiSelectList Ratings;
        public MultiSelectList SubTasks;
        public MultiSelectList Tags;
    }
}