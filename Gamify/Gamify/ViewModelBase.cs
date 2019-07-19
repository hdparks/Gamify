using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Gamify
{
    public abstract class PropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaiseAllPropertyChanged()
        {
            OnPropertyChanged(string.Empty);
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetPropertyAndRaise<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, newValue)) return false;
            field = newValue;
            OnPropertyChanged(propertyName);
            return true;
        }
    }

    public abstract class ViewModelBase : PropertyChangedBase, IViewModelLifecycle
    {
        public virtual Task BeforeFirstShown()
        {
            return Task.CompletedTask;
        }
        public Task AfterDismissed()
        {
            throw new NotImplementedException();
        }



    }
}
