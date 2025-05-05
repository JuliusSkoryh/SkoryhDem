using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dem.Services
{
    public interface INavigationService<TViewModel>
    { 
        void Navigate(object? parameter = null);
    }
}
