using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARU.Source.Models
{
    public class SearchModel
    {
        public List<string> SearchClasses { get; set; }
        public Dictionary<string, string> SearchIndividuals { get; set; }

        public SearchModel()
        {
            SearchClasses = new List<string>();
            SearchIndividuals = new Dictionary<string, string>();
        }
    }
}
