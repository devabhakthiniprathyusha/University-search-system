using ARU.Model;
using ARU.Source;
using ARU.Source.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ARU.Controllers
{
    public class HomeController : Controller
    {
        private const string NO_FILTER_WARNING = @"No filters selected - returning all publications by default.";

        private readonly ILogger<HomeController> logger;

        public Server Server { get; set; }

        private bool initializeServer;

        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;

            if (!initializeServer)
            {
                Server = new Server();

                if (Server.Connect())
                {
                    initializeServer = true;
                }
            }
        }

        [HttpGet]
        public IActionResult Index()
        {

            SearchViewModel viewModel = new SearchViewModel();
            PopulateSearchFilters(viewModel);

            if (viewModel.Results != null)
            {
                if (viewModel.Results.Count == 0)
                {
                    viewModel.Results = Server.Query.QueryAllIndividuals();
                }
            }
            else
            {
                List<string> Results = new List<string>();
                Results.Add("Raghu");
                Results.Add("Varun");
                Results.Add("Pranav Kumar");
                Results.Add("Vidhya");
                Results.Add("Joel Sujith");
                Results.Add("Joe Doe");
                Results.Add("Christopher");
                Results.Add("Annadurai Baga");
                Results.Add("Ramana");
                viewModel.Results = Results;
            }

            logger.LogInformation("Index:GET");
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(SearchViewModel viewModel)
        {
            SearchModel searchModel = new SearchModel();

            int tries = 0;
            if (!String.IsNullOrWhiteSpace(viewModel.UnderGraduate))
            {
                searchModel.SearchIndividuals.Add("Author", viewModel.UnderGraduate);
                tries++;
            }

            if (!String.IsNullOrWhiteSpace(viewModel.PostGraduate))
            {
                searchModel.SearchClasses.Add(viewModel.PostGraduate);
                tries++;
            }

            if (!String.IsNullOrWhiteSpace(viewModel.PhD))
            {
                searchModel.SearchClasses.Add(viewModel.PhD);
                tries++;
            }

            if (!String.IsNullOrWhiteSpace(viewModel.PostDoctorate))
            {
                searchModel.SearchClasses.Add(viewModel.PostDoctorate);
                tries++;
            }

            //if (!String.IsNullOrWhiteSpace(viewModel.Series))
            //{
            //    searchModel.SearchIndividuals.Add("Series", viewModel.Series);
            //    tries++;
            //}

            viewModel = new SearchViewModel();

            if (tries == 0)
            {
                //viewModel.Results = Server.QueryAllIndividuals(); // Get all individuals by default.
                viewModel.Message = NO_FILTER_WARNING;
            }
            else
            {
                List<string> results = Server.Query.QueryIndividualsWithSearchModel(searchModel); //TODO: Query Ontology - Take values from viewModel and construct a query with them.

                if (results != null)
                {
                    if (results.Count > 0)
                    {
                        viewModel.Results = results;
                    }
                }
            }

            PopulateSearchFilters(viewModel);

            logger.LogInformation("Index:POST");
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Search(SearchViewModel viewModel)
        {
            if (!String.IsNullOrWhiteSpace(viewModel.Title))
            {
                string title = viewModel.Title.Trim().ToLower();
                List<string> results = Server.Query.QueryIndividualsWithTextContains(title);

                if (results != null)
                {
                    if (results.Count > 0)
                    {
                        viewModel.Results = results;
                    }
                }
            }
            else
            {
                //viewModel.Results = Server.QueryAllIndividuals(); // Get all individuals by default.
                viewModel.Message = NO_FILTER_WARNING;
            }

            PopulateSearchFilters(viewModel);

            logger.LogInformation("Search:POST");
            return View("Index", viewModel);
        }

        [HttpGet]
        public IActionResult Reset()
        {
            logger.LogInformation("Reset:GET");
            return RedirectToAction("Index");
        }

        private void PopulateSearchFilters(SearchViewModel viewModel)
        {
            foreach (string option in Server.Query.QueryFilterOptions("Location", QueryFilterType.Individual))
            {
                viewModel.AvailableUnderGraduate.Add(new SelectListItem(option, option));
            }

            foreach (string option in Server.Query.QueryFilterOptions("Literary_Form", QueryFilterType.Class))
            {
                viewModel.AvailablePostGraduate.Add(new SelectListItem(option, option));
            }

            foreach (string option in Server.Query.QueryFilterOptions("Genre", QueryFilterType.Class))
            {
                viewModel.AvailablePhD.Add(new SelectListItem(option, option));
            }

            foreach (string option in Server.Query.QueryFilterOptions("Publication", QueryFilterType.Class))
            {
                viewModel.AvailablePostDoctorate.Add(new SelectListItem(option, option));
            }
        }
    }
}