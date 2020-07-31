using MarvelApp.Models;
using MarvelApp.Services;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelApp.ViewModels
{
    public class CharacterViewModel:BaseViewModel
    {
        private DataService dataService;
        private ObservableRangeCollection<Character> _characters;

        public CharacterViewModel(DataService dataService)
        {
            this.dataService = dataService;
        }
        public ObservableRangeCollection<Character> Characters {
            get {
                return _characters;
            }
            set {
                SetProperty(ref _characters, value);
            }
        }
    }
}
