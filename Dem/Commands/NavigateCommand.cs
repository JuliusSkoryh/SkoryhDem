using Dem.Primitives;
using Dem.Services;


namespace Dem.Commands
{
    public class NavigateCommand<TViewModel> : CommandBase where TViewModel : ViewModelBase
    {
        private readonly INavigationService<TViewModel> _navigationService;
        private object? _parameter;

        public NavigateCommand(INavigationService<TViewModel> navigationService, object? parameter = null)
        { 
            _navigationService = navigationService;
            _parameter = parameter;
        }

        public override void Execute(object? parameter)
        {
            _navigationService.Navigate(_parameter);
        }
    }
}
