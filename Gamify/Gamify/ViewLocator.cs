using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Gamify
{
    public class ViewLocator : IViewLocator
    {
        public Page CreateAndBindPageFor<TViewModel>(TViewModel viewModel) where TViewModel : ViewModelBase
        {
            var pageType = FindPageForViewModel(viewModel.GetType());
            var page = (Page)Activator.CreateInstance(pageType);
            page.BindingContext = viewModel;

            return page;
        }

        protected virtual Type FindPageForViewModel(Type viewModelType)
        {

            //  Here we assume the following naming conventions for view and viewmodel:
            //  (All views must end in "View", corresponding viewmodels end in "ViewModel)
            //  View: ExampleView
            //  ViewModel: ExampleViewModel
            //  This makes navigation a breeze using these hacks
            //  This Navigation method was found at https://www.rocksolidknowledge.com/articles/decoupling-views-and-navigation-xamarinforms

            var pageTypeName = viewModelType.AssemblyQualifiedName.Replace("ViewModel", "View");

            var pageType = Type.GetType(pageTypeName);

            if(pageType == null)
            {
                throw new ArgumentException(pageTypeName + " type does not exist");
            }

            return pageType;
        }
    }
}
