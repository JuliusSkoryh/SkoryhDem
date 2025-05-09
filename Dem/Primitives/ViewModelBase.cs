﻿using System.ComponentModel;

namespace Dem.Primitives
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    { 
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void Dispose() { }
    }
}
