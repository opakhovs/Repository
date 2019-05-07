using Repository.Viewmodels.ArtifactsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.Services
{
    public class ArtifactSortService
    {
  
        public List<ArtifactViewModel> SortByProperties(IEnumerable<ArtifactViewModel> artifacts, int[] selectedProperties)
        {
            List<ArtifactViewModel> artifactViewModels = artifacts.ToList();
            for(int i = 0; i < NumberOfPropertyKinds; i++)
            {
                int[] idsOfEachProperty = new int[selectedProperties.Length];

            }
        }
    }
}