﻿using Repository.Models;
using Repository.Repositories.Interfaces;
using Repository.Viewmodels.ArtifactsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.Services
{
    public class ArtifactSortService
    {
  
        public List<Artifact> SortByProperties(IEnumerable<Artifact> artifacts, List<IDataSource<ArtifactProperty>> listOfRepositories, int[] selectedProperties)
        {
            List<Artifact> artifactModels = artifacts.ToList();
            if (selectedProperties == null)
                return artifactModels;
            for(int i = 0; i < listOfRepositories.Count; i++)
            {
                List<int> idsOfEachProperty = new List<int>();
                var properties = listOfRepositories[i].GetAll();
                foreach(var property in properties)
                {
                    for(int j = 0; j < selectedProperties.Length; j++)
                    {
                        if (selectedProperties[j] == property.Id)
                        {
                            idsOfEachProperty.Add(property.Id);
                        }
                    }
                }
                if (idsOfEachProperty.Count != 0)
                {
                    Stack<int> toDelete = new Stack<int>();
                    for (int artifactIndex = 0; artifactIndex < artifactModels.Count; artifactIndex++)
                    {
                        int propertyId, artifactPropertyIndex;
                        for (propertyId = 0; propertyId < idsOfEachProperty.Count; propertyId++)
                        {
                            for (artifactPropertyIndex = 0; artifactPropertyIndex < artifactModels[artifactIndex].Properties.Count; artifactPropertyIndex++)
                            {
                                if (idsOfEachProperty[propertyId] == artifactModels[artifactIndex].Properties[artifactPropertyIndex].Id)
                                {
                                    artifactPropertyIndex = artifactModels[artifactIndex].Properties.Count + 1;
                                    propertyId = idsOfEachProperty.Count + 1;
                                }
                            }
                        }
                        if (propertyId == idsOfEachProperty.Count)
                            toDelete.Push(artifactIndex);
                    }
                    while (toDelete.Count != 0)
                    {
                        artifactModels.RemoveAt(toDelete.Pop());
                    }
                }
            }
            return artifactModels;
        }
    }
}