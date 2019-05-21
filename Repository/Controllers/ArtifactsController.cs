using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repository.Models;
using Repository.Repositories.Interfaces;
using Repository.Repositories.Implementations;
using Repository.Viewmodels.ArtifactsViewModels;
using Repository.Repositories;
using Repository.Services;
using Repository.Viewmodels;

namespace Repository.Controllers
{
    public class ArtifactsController : Controller
    {
        private static readonly int NumberOfPropertyKinds = 5;

        private SQLContext context = new SQLContext();
        private IArtifactRepository artifactRep;
        private IArtTypeRepository artTypeRep;
        private IProblemDomainRepository problemDomainRep;
        private IProjectRepository projectRep;
        private IRatingRepository raitingRep;
        private ISubTaskRepository subTaskRep;
        private ITagRepository tagRepository;
        private IArtifactPropertyRepository artPropertyRep;

        public ArtifactsController()
        {
            artifactRep = new ArtifactRepository(context);
            artTypeRep = new ArtTypeRepository(context);
            problemDomainRep = new ProblemDomainRepository(context);
            projectRep = new ProjectRepository(context);
            raitingRep = new RatingRepository(context);
            subTaskRep = new SubTaskRepository(context);
            tagRepository = new TagRepository(context);
            artPropertyRep = new ArtifactTypeRepository(context);
        }

        // GET: Artifacts
        public async Task<ActionResult> Index()
        {
            IndexViewModel viewModel = new IndexViewModel();
            List<ArtifactViewModel> listForViewModel = new List<ArtifactViewModel>();

            InitializeIndexViewModelForSearch(viewModel);

            foreach (var x in artifactRep.GetAll())
            {
                listForViewModel.Add(new ArtifactViewModel() { ArtifactId = x.ArtifactId, DateOfAdding = x.DateOfAdding, Version = x.Version, ArtType = x.Properties.First().Name });
            }

            viewModel.Artifacts = listForViewModel;

            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Index(IndexViewModel viewModel)
        {
            var properties = viewModel.SelectedProperties;
            var allMatchesSelected = viewModel.isAllMatchesSelected;

            ArtifactSortService sortService = new ArtifactSortService();
            
            List<Artifact> resultOfSearch;
            if (allMatchesSelected == "AllMatches")
                resultOfSearch = sortService.SortByPropertiesAllInEachCategory(artifactRep.GetAll(), viewModel.SelectedProperties);
            else
                resultOfSearch = sortService.SortByPropertiesOneOfEachCategory(artifactRep.GetAll(), CreateListOfRepositories(), viewModel.SelectedProperties);

            List<ArtifactViewModel> listForViewModel = new List<ArtifactViewModel>();

            foreach (var x in resultOfSearch)
            {
                listForViewModel.Add(new ArtifactViewModel() { ArtifactId = x.ArtifactId, DateOfAdding = x.DateOfAdding, Version = x.Version, ArtType = x.Properties.First().Name });
            }

            viewModel.Artifacts = listForViewModel;

            InitializeIndexViewModelForSearch(viewModel);

            return View(viewModel);
        }

        private List<IDataSource<ArtifactProperty>> CreateListOfRepositories()
        {
            List<IDataSource<ArtifactProperty>> repositories = new List<IDataSource<ArtifactProperty>>();
            repositories.Add(artTypeRep);
            repositories.Add(problemDomainRep);
            repositories.Add(projectRep);
            repositories.Add(raitingRep);
            repositories.Add(tagRepository);
            return repositories;
        }

        private void InitializeIndexViewModelForSearch(IndexViewModel viewModel)
        {
            var artTypes = artTypeRep.GetAll().Select(c => new
            {
                ArtTypeId = c.Id,
                ArtTypeName = c.Name
            }).ToList();
            viewModel.ArtTypes = new MultiSelectList(artTypes, "ArtTypeId", "ArtTypeName");

            var problemDomains = problemDomainRep.GetAll().Select(c => new
            {
                ProblemDomainId = c.Id,
                ProblemDomainName = c.Name
            }).ToList();
            viewModel.ProblemDomains = new MultiSelectList(problemDomains, "ProblemDomainId", "ProblemDomainName");

            var projects = projectRep.GetAll().Select(c => new
            {
                ProjectId = c.Id,
                ProjectName = c.Name
            }).ToList();
            viewModel.Projects = new MultiSelectList(projects, "ProjectId", "ProjectName");

            var ratings = raitingRep.GetAll().Select(c => new
            {
                RatingId = c.Id,
                RatingName = c.Name
            }).ToList();
            viewModel.Ratings = new MultiSelectList(ratings, "RatingId", "RatingName");

            //var subTasks = subTaskRep.GetAll().Select(c => new
            //{
            //    SubTaskId = c.Id,
            //    SubTaskName = c.Name
            //}).ToList();
            //viewModel.SubTasks = new MultiSelectList(subTasks, "SubTaskId", "SubTaskName");

            var tags = tagRepository.GetAll().Select(c => new
            {
                TagId = c.Id,
                TagName = c.Name
            }).ToList();
            viewModel.Tags = new MultiSelectList(tags, "TagId", "TagName");
        }
        // GET: Artifacts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artifact artifact = artifactRep.GetById(id);
            if (artifact == null)
            {
                return HttpNotFound();
            }

            return View(new ArtifactViewModel() { ArtifactId = artifact.ArtifactId, DateOfAdding = artifact.DateOfAdding, Version = artifact.Version, Properties = GetVmList(artifact.Properties)});
        }

        private List<PropertyViewModel> GetVmList(List<ArtifactProperty> properties)
        {
            var listOfVmProps = new List<PropertyViewModel>();

            foreach (var x in properties)
            {
                switch (x)
                {
                    case ArtType artType:
                        listOfVmProps.Add(new ArtTypeViewModel(x as ArtType));
                        break;
                    case ProblemDomain problemDomain:
                        listOfVmProps.Add(new ProblemDomainViewModel(x as ProblemDomain));
                        break;
                    case Project project:
                        listOfVmProps.Add(new ProjectViewModel(x as Project));
                        break;
                    case Rating rating:
                        listOfVmProps.Add(new RatingViewModel(x as Rating));
                        break;
                    case Tag tag:
                        listOfVmProps.Add(new TagViewModel(x as Tag));
                        break;
                }
            }

            return listOfVmProps;
        }

        // GET: Artifacts/Create
        public ActionResult Create()
        {
            CreateViewModel viewModel = new CreateViewModel();
            var artTypes = artTypeRep.GetAll().Select(c => new ArtType
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
            viewModel.Types = artTypes;

            var problemDomains = problemDomainRep.GetAll().Select(c => new ProblemDomain
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
            viewModel.Domains = problemDomains;

            var projects = projectRep.GetAll().Select(c => new Project
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
            viewModel.Projects = projects;

            var ratings = raitingRep.GetAll().Select(c => new Rating
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
            viewModel.Ratings = ratings;

            //var subTasks = subTaskRep.GetAll().Select(c => new SubTask
            //{
            //    Id = c.Id,
            //    Name = c.Name
            //}).ToList();
            //viewModel.SubTasks = subTasks;

            var tags = tagRepository.GetAll().Select(c => new Tag
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
            viewModel.Tags = tags;

            return View(viewModel);
        }

        // POST: Artifacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Artifact artifact = new Artifact() { Version = viewModel.Version, DateOfAdding = viewModel.DateOfAdding };
                var listOfIndexes = viewModel.SelectedIds;

                artifact.Properties.Add(artPropertyRep.GetById(viewModel.ArtifactTypeId));

                if (listOfIndexes != null)
                { 
                    artifact.Properties.AddRange(listOfIndexes
                        .ToList()
                        .SelectMany(i => artPropertyRep.GetAll()
                        .Where(p => p.Id == i)));
                }

                Artifact newArtifact = artifact;

                artifactRep.Add(artifact);
                artifactRep.Save();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Artifacts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artifact artifact = artifactRep.GetById(id);
            if (artifact == null)
            {
                return HttpNotFound();
            }
            return View(artifact);
        }

        // POST: Artifacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ArtifactId,DateOfAdding,Version")] Artifact artifact)
        {
            if (ModelState.IsValid)
            {
                artifactRep.Update(artifact);
                artifactRep.Save();
                return RedirectToAction("Index");
            }
            return View(artifact);
        }

        // GET: Artifacts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artifact artifact = artifactRep.GetById(id);
            if (artifact == null)
            {
                return HttpNotFound();
            }
            return View(artifact);
        }

        // POST: Artifacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            artifactRep.Delete(id);
            artifactRep.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                artifactRep.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
