using System.Threading.Tasks;

namespace Gamify
{
    interface IViewModelLifecycle
    {
        /// <summary>
        /// Called exactly once, before the viewmodel enters the navigation stack
        /// </summary>
        /// 
        Task BeforeFirstShown();

        /// <summary>
        /// Called exactly once, when the viewmodel leaves the navigation stack
        /// </summary>
        /// 
        Task AfterDismissed();
    }
}
