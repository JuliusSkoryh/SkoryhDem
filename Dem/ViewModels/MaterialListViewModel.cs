using Dem.Commands;
using Dem.Models.Entities;
using Dem.Primitives;
using Dem.Services;
using Dem.Services.DbServices.DbServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Dem.ViewModels
{
    public class MaterialListViewModel : ViewModelBase
    {
        private readonly IMaterialService _materialService;
        public NavigationBarViewModel NavigationBarViewModel { get; set; }

        public ObservableCollection<MaterialViewModel> Materials { get; }

        public ICommand AddMaterialCommand { get; }


        private MaterialListViewModel(NavigationBarViewModel navigationBarViewModel, IMaterialService materialService, INavigationService<AddMaterialViewModel> addMaterialNavService)
        {
            _materialService = materialService;
            NavigationBarViewModel = navigationBarViewModel;
            Materials = new ObservableCollection<MaterialViewModel>();
            AddMaterialCommand = new NavigateCommand<AddMaterialViewModel>(addMaterialNavService);
        }

        public static MaterialListViewModel Create(NavigationBarViewModel navigationBarViewModel, IMaterialService materialService,
            INavigationService<AddMaterialViewModel> addMaterialNavService, INavigationService<EditMaterialViewModel> editMaterialNavService)
        {
            var viewModel = new MaterialListViewModel(navigationBarViewModel, materialService, addMaterialNavService);
            viewModel.LoadMaterials(editMaterialNavService);
            return viewModel;
        }

        private void LoadMaterials(INavigationService<EditMaterialViewModel> editMaterialNavService)
        {
            Materials.Clear();
            var materials = _materialService.GetAll();                     

            foreach (var mat in materials)
            {
                Materials.Add(new MaterialViewModel(mat, _materialService, editMaterialNavService));
            }
        }
    }
}
