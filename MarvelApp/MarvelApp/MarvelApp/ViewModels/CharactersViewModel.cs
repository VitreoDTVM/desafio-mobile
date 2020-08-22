using MarvelApp.Domain.Entities;
using MarvelApp.Mobile.Services.Base;
using MarvelApp.Mobile.Services.Services;
using MarvelApp.Views;
using Refit;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace MarvelApp.ViewModels
{
    public class CharactersViewModel:ViewModelBase<ObservableCollection<Character>>
    {
        private Character _selectedCharacter;
        public Character SelectedCharacter
        {
            get
            {
                return _selectedCharacter;
            }
            set
            {
                _selectedCharacter = value;
                RaisePropertyChanged("SelectedCharacter");
            }
        }

        private CharacterServices _characterServices;

        public CharactersViewModel()
        {
            _characterServices = new CharacterServices();
            RefreshCommand.Execute(null);
        }

        public ICommand RefreshCommand 
        {
            get 
            {
                return new Command(async () => 
                {
                    LockControls();
                    var rootObject = await _characterServices.GetAll();
                    Entity = new ObservableCollection<Character>(rootObject?.Data?.Characters);
                    
                    UnlockControls();
                });
            }
        }

        public ICommand SelectionChangedCommand 
        {
            get
            {
                return new Command(async () =>
                {
                    await Navigation.PushAsync(new CharacterView(SelectedCharacter));
                });
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                return new Command<string>(value =>
                {
                    LockControls();

                    if (value.Length > 2)
                        Entity = new ObservableCollection<Character>(Entity.Where(c => c.Name.ToUpper().Contains(value.ToUpper())));

                    UnlockControls();
                });
            }
        }
    }
}
