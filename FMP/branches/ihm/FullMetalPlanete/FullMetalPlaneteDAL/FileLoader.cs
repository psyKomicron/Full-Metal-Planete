using System;
using System.Collections.Generic;

namespace FullMetalPlaneteDAL
{
    public interface FileLoader
    {
        void Load(string[] names, string currentDirectory);

        void Load(string[] names, string currentDirectory, bool failOnUnloadable);

        Uri GetUri(string key);

        string FilesDirectory { get; }

        Dictionary<string, Uri> Uris { get; }
    }
}
