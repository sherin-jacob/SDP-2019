using System;
using System.Collections.Generic;
using System.Text;

namespace NZTravel2.Persistence
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);
    }
}

