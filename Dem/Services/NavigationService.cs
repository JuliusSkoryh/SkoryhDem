﻿using Dem.Services.Stores;
using Dem.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dem.Services
{ 
    public class NavigationService<TViewModel> : INavigationService<TViewModel> where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<object?, TViewModel> _createViewModel;

        public NavigationService(NavigationStore navigationStore, Func<object?, TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate(object? parameter = null)
        {
            _navigationStore.CurrentViewModel = _createViewModel(parameter);
        }
    }
}
