using System;
using System.IO;
using NZTravel2.Droid;
using NZTravel2.Persistence;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace NZTravel2.Droid
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}