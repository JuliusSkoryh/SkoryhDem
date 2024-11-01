using Dem.Primitives;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dem.ViewModels
{
    public class ProductListViewModel : ViewModelBase
    {
        public NavigationBarViewModel NavigationBarViewModel { get; set; }


        private readonly ApplicationDbContext _db;
        private readonly ObservableCollection<ProductViewModel> _productViewModels;

        public ObservableCollection<ProductViewModel> ProductViewModels => _productViewModels;

        public ProductListViewModel()
        {
        }

    }
}
