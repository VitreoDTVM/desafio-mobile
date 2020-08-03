using MarvelApp.Models;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelApp.ViewModels
{
    public class CharacterDetailViewModel:BaseViewModel
    {
        private ObservableRangeCollection<Item> _items;

        public string ImagePath { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ObservableRangeCollection<Item> Items {
            get {
                return _items;
            }
            set {
                SetProperty(ref _items, value);
            }
        }
        public CharacterDetailViewModel(Result result)
        {
            Items = new ObservableRangeCollection<Item>();

            this.ImagePath = result.Thumbnail.ImagePath;
            this.Description = result.Description;
            this.Name = result.Name;
            Items.AddRange(result.Comics.Items);

        }
      
    }
}
