using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using MarvelApp.DependencyServices;
using UIKit;

namespace MarvelApp.iOS.DependencyServices
{
    public class FileStore : IFileStore
    {
        public string GetFilePath(string fileName)
        {
            return "Files/" + fileName;
        }
    }
}