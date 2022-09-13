using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ARU.Model
{
    public class SearchViewModel
    {
        public string Campus { get; set; }
        public string Cambridge { get; set; }
        public string Chelmsford { get; set; }
        public string Peterborough { get; set; }
        public string London { get; set; }
        public string UnderGraduate { get; set; }
        public string PostGraduate { get; set; }
        public string PhD { get; set; }
        public string PostDoctorate { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
        public string Courses { get; set; }
        public string Workshop { get; set; }
        public string Conference { get; set; }
        public string Article { get; set; }
        public string Book { get; set; }
        public string Periodical { get; set; }
        public string Thesis { get; set; }

        public List<SelectListItem> AvailableUnderGraduate { get; set; }
        public List<SelectListItem> AvailableCampus { get; set; }
        public List<SelectListItem> AvailableCambridge { get; set; }
        public List<SelectListItem> AvailableChelmsford { get; set; }
        public List<SelectListItem> AvailablePeterborough { get; set; }
        public List<SelectListItem> AvailableLondon { get; set; }
        public List<SelectListItem> AvailablePostGraduate { get; set; }
        public List<SelectListItem> AvailablePhD { get; set; }
        public List<SelectListItem> AvailablePostDoctorate { get; set; }
        public List<SelectListItem> AvailableCourses { get; set; }
        public List<SelectListItem> AvailableWorkshops { get; set; }
        public List<SelectListItem> AvailableConferences { get; set; }
        public List<SelectListItem> AvailableArticles { get; set; }
        public List<SelectListItem> AvailableBooks { get; set; }
        public List<SelectListItem> AvailablePeriodicals { get; set; }
        public List<SelectListItem> AvailableThesis { get; set; }
        public List<string> Results { get; set; }

        public SearchViewModel()
        {
            AvailableCampus = new List<SelectListItem>();
            AvailableCambridge= new List<SelectListItem>();
            AvailableChelmsford= new List<SelectListItem>();
            AvailablePeterborough= new List<SelectListItem>();
            AvailableLondon= new List<SelectListItem>();
            AvailableUnderGraduate = new List<SelectListItem>();
            AvailablePostGraduate = new List<SelectListItem>();
            AvailablePhD = new List<SelectListItem>();
            AvailablePostDoctorate = new List<SelectListItem>();
            AvailableCourses = new List<SelectListItem>();
            AvailableArticles = new List<SelectListItem>();
            AvailableBooks = new List<SelectListItem>();
            AvailableConferences = new List<SelectListItem>();
            AvailablePeriodicals = new List<SelectListItem>();
            AvailableThesis = new List<SelectListItem>();
            AvailableWorkshops = new List<SelectListItem>();
        }
    }
}

