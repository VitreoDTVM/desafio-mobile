using MarvelApp.Models;
using MarvelApp.Services;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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
        public async Task InitializeAsync()
        {
            try
            {
                var guid = Guid.NewGuid().ToString();
                var publickey = GetHash(guid  + AppSettings.PrivateKey + AppSettings.PublicKey);
                var privatekey = GetHash(AppSettings.PrivateKey);
                var endpoint = $"characters?apikey={AppSettings.PublicKey}&hash={publickey}&ts={guid}";
                var response = await dataService.GetAsync<Character>(endpoint, "character", 100);
                var list = (List<Models.Result>)response.Result;
                if (list.Count > 0 && list != null)
                {

                }
                else
                {
                    Characters = new ObservableRangeCollection<Character>();
                    Characters.AddRange(Characters);
                }
            }
            catch (Exception exception)
            {

                var properties = new Dictionary<string, string> {{"CharacterViewModel.cs", "InitializeAsync"}};
                //Crashes.TrackError(exception, properties);

                Characters = new ObservableRangeCollection<Character>();
                Characters.AddRange(Characters);
            }
        }
        //Inspirado nessa implementação com adaptações https://www.c-sharpcorner.com/article/compute-sha256-hash-in-c-sharp/
        public string GetHash(string input)
        {
            using (var hash = MD5.Create())
            {
                byte[] data = hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                var strBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    strBuilder.Append(data[i].ToString("x2"));
                }

                return strBuilder.ToString();
            }
        }
    }
}
