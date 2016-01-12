using System.Collections.Generic;
using System.Linq;
using MyBrowser.Model;

namespace MyBrowser.ViewModel
{
    class SiteViewModel
    {
        private readonly List<Site> sites;

        public SiteViewModel()
        {
            var siteFactory = new SiteFactory();
            sites = siteFactory.GetSites().ToList();
        }

        public List<Site> Sites { get { return sites; }}

    }
}
