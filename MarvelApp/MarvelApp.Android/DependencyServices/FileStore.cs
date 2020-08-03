using System.IO;
using MarvelApp.DependencyServices;


namespace MarvelApp.Droid.DependencyServices
{
    public class FileStore : IFileStore
    {
        public string GetFilePath(string filename)
        {

            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }

    }
}