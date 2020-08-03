using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelApp.DependencyServices
{
    public interface IFileStore
    {
        string GetFilePath(string filename);
    }
}
