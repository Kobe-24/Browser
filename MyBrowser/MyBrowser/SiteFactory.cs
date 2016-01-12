using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using MyBrowser.Model;

namespace MyBrowser
{
    class SiteFactory
    {
        private List<Site> sites; 

        public IEnumerable<Site> GetSites()
        {
            if (sites != null)
            {
                return sites;
            }

            sites = new List<Site>();
            foreach (var key in ConfigurationManager.AppSettings.AllKeys)
            {
                var site = new Site();
                site.Order = key;
                site.Address = ConfigurationManager.AppSettings[key];
                sites.Add(site);
            }
            return sites;
        }

        public Site GetSite(string displayName)
        {
            var mySites = GetSites();

            return mySites.FirstOrDefault(x => x.Order == displayName);
        }



    }
}
