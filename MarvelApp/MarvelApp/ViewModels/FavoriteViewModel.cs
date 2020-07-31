using MarvelApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelApp.ViewModels
{
    public class FavoriteViewModel
    {
        private DataService dataService;

        public FavoriteViewModel(DataService dataService)
        {
            this.dataService = dataService;
        }
    }
}
