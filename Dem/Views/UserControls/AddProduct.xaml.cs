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
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : UserControl
    {
        public AddProduct()
        {
            DataContextChanged += AddProduct_DataContextChanged;
            InitializeComponent();
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListBox listBox && listBox.SelectedItem is Material selectedMaterial)
            {
                var viewModel = (AddProductViewModel)DataContext;
                viewModel.AddSelectedMaterial(selectedMaterial);
            }
        }

        private void AddProduct_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (DataContext is AddProductViewModel viewModel)
            {
                foreach (var material in viewModel.MaterialsSelected)
                {
                    MaterialsListBox.SelectedItems.Add(material);
                }
            }
        }
    }
}
