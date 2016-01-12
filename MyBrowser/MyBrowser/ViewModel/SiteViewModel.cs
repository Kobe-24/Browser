using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using MyBrowser.Annotations;
using MyBrowser.Model;
using MyBrowser.ViewModel.Commands;

namespace MyBrowser.ViewModel
{
    class SiteViewModel : INotifyPropertyChanged
    {
        private readonly List<Site> sites;
        private bool _browserVisability;
        private bool _menuVisability;
        private string _selectedSiteAddress;

        public SiteViewModel()
        {
            var siteFactory = new SiteFactory();
            sites = siteFactory.GetSites().ToList();
            ParameterCommand = new ParameterCommand(this);
            MenuVisability = true;
            BrowserVisability = false;
        }

        public List<Site> Sites { get { return sites; }}

        public ICommand ParameterCommand { get; set; }

        public string GetAddress(string order)
        {
            return HelperFunctions.AddAddressPrefix(sites.First(x => x.Order == order).Address);
        }

        public string SelectedSiteAddress
        {
            get { return _selectedSiteAddress; }
            set
            {
                if (value == _selectedSiteAddress) return;
                _selectedSiteAddress = value;
                OnPropertyChanged();
            }
        }

        public bool BrowserVisability
        {
            get { return _browserVisability; }
            set
            {
                if (value == _browserVisability) return;
                _browserVisability = value;
                OnPropertyChanged();
            }
        }

        public bool MenuVisability
        {
            get { return _menuVisability; }
            set
            {
                if (value == _menuVisability) return;
                _menuVisability = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
