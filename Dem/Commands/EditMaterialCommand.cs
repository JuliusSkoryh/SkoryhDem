using Dem.Exceptions.NotFoundExceptions;
using Dem.Primitives;
using Dem.Services.DbServices;
using Dem.Services.DbServices.DbServiceInterfaces;
using Dem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Dem.Commands
{
    public class EditMaterialCommand : CommandBase
    {
        private readonly IMaterialService _materialService;
        private readonly EditMaterialViewModel _editMaterialViewModel;

        public EditMaterialCommand(IMaterialService materialService, EditMaterialViewModel editMaterialViewModel)
        {
            _materialService = materialService;
            _editMaterialViewModel = editMaterialViewModel;
        }

        public override void Execute(object parameter)
        {
            try
            {
                var material = _materialService.Get(_editMaterialViewModel.Id);

                if (material == null)
                {
                    throw new MaterialNotFoundException();
                }
                material.Name = _editMaterialViewModel.Name;
                material.Type = _editMaterialViewModel.Type;
                material.Cost = _editMaterialViewModel.Cost;
                material.QuantityInPackaging = _editMaterialViewModel.QuantityInPackaging;
                material.SupplierId = _editMaterialViewModel.SelectedSupplier.Id;
                material.Measurement = _editMaterialViewModel.Measurement;
                material.ReservedMaterials = _editMaterialViewModel.ReservedMaterials;
                material.Image = _editMaterialViewModel.Image;

                _materialService.Update(material);
                MessageBox.Show("Материал успешно обновлён", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
