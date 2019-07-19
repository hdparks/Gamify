using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Gamify
{
    public interface IViewLocator
    {
        Page CreateAndBindPageFor<TViewModel>(TViewModel viewModel) where TViewModel : ViewModelBase;
    }
}
