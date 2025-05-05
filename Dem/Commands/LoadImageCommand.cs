using Dem.Primitives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dem.Commands
{
    class LoadImageCommand : CommandBase
    {
        private readonly Func<byte[]?> _getImage;
        private readonly Action<byte[]?> _setImage;


        public LoadImageCommand(Func<byte[]?> getImage, Action<byte[]?> setImage)
        {
            _getImage = getImage;
            _setImage = setImage;
        }

        public override void Execute(object parameter)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg"
            };

            if (dialog.ShowDialog() == true)
            {
                var imageBytes = File.ReadAllBytes(dialog.FileName);
                _setImage(imageBytes);
            }
        }

    }
}
