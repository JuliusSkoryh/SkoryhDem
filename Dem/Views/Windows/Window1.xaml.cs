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
using System.Windows.Shapes;

namespace Dem.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public int? Quantity { get; private set; }

        public Window1()
        {
            InitializeComponent();
        }
        private void OnOkClick(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(QuantityTextBox.Text, out int quantity) && quantity >= 0)
            {
                Quantity = quantity;
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Введите корректное количество", "Ошибка");
            }
        }
    }
}
