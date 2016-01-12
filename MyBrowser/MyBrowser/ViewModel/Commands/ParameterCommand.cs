using System;
using System.Windows;
using System.Windows.Input;

namespace MyBrowser.ViewModel.Commands
{
    class ParameterCommand : ICommand
    {
        private readonly SiteViewModel _siteViewModel;

        public ParameterCommand(SiteViewModel siteViewModel)
        {
            this._siteViewModel = siteViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter == null) return;
            _siteViewModel.SelectedSiteAddress = _siteViewModel.GetAddress(parameter.ToString());
            _siteViewModel.MenuVisability = false;
            _siteViewModel.BrowserVisability = true;
        }

        public event EventHandler CanExecuteChanged;
    }
}
