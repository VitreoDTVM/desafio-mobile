using System;
using Prism;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;

namespace MVitreo.ViewModels
{
    public class BaseViewModel : BindableBase, INavigationAware, IDestructible, IActiveAware
    {
        protected INavigationService NavigationService { get; set; }
        protected IPageDialogService PageDialogService { get; set; }

        protected bool HasInitialized { get; set; }

        public event EventHandler IsActiveChanged;


        public BaseViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            NavigationService = navigationService;
            PageDialogService = pageDialogService;

        }
        bool isBusy;

        public bool IsBusy
        {
            get => isBusy;
            set
            {
                if (SetProperty(ref isBusy, value))
                    IsNotBusy = !isBusy;
            }
        }

        bool isNotBusy = true;

        public bool IsNotBusy
        {
            get => isNotBusy;
            set
            {
                if (SetProperty(ref isNotBusy, value))
                    IsBusy = !isNotBusy;
            }
        }

        private bool _isActive;
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value, RaiseIsActiveChanged);
        }
        public void Destroy()
        {
        }
        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {

        }
        protected virtual void RaiseIsActiveChanged()
        {
            IsActiveChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
