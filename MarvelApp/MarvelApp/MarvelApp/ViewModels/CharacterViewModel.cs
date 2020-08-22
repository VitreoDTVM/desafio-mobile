using MarvelApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelApp.ViewModels
{
    public class CharacterViewModel : ViewModelBase<Character>
    {
        public CharacterViewModel(Character character)
        {
            Entity = character;
        }
    }
}
