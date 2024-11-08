using Dem.Models.Entities;
using Dem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dem.Views.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ProductEdit.xaml
    /// </summary>
    public partial class ProductEdit : UserControl
    {
        public ProductEdit()
        {
            //DataContextChanged += EditProduct_DataContextChanged;
            InitializeComponent();
        }

        //private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    if (sender is ListBox listBox && listBox.SelectedItem is Material selectedMaterial)
        //    {
        //        var viewModel = (ProductEditViewModel)DataContext;
        //        viewModel.AddSelectedMaterial(selectedMaterial);
        //    }
        //}

        //private void EditProduct_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        //{
        //    if (DataContext is ProductEditViewModel viewModel)
        //    {
        //        foreach (var material in viewModel.MaterialsSelected)
        //        {
        //            MaterialsListBox.SelectedItems.Add(material);
        //        }
        //    }
        //}
    }
}
