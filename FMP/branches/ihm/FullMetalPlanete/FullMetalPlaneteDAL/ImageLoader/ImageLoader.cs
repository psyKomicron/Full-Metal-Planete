using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Text;

namespace FullMetalPlaneteDAL.ImageLoader
{
    public class ImageLoader : FileLoader
    {
        private Dictionary<string, Uri> images = new Dictionary<string, Uri>();

        private bool failOnUnloadable;

        private string defaultImage;

        public string FilesDirectory { get; private set; }

        public Dictionary<string, Uri> Uris { get => images; }

        public ImageLoader()
        {
        }

        public ImageLoader(string defaultImage)
        {
            if (File.Exists(defaultImage))
            {
                this.defaultImage = defaultImage;
            }
            else
            {
                throw new IOException("Invisible image ?");
            }
        }

        public Uri GetUri(string key)
        {
            return images[key];
        }

        public void Load(string[] names, string currentDirectory)
        {
            failOnUnloadable = false;
            BuildImages(names, currentDirectory);
        }

        public void Load(string[] names, string currentDirectory, bool failOnUnloadable)
        {
            this.failOnUnloadable = failOnUnloadable;
            BuildImages(names, currentDirectory);
        }

        private void BuildImages(string[] names, string currentDirectory)
        {
            FilesDirectory = currentDirectory;
            for (int i = 0; i < names.Length; i++)
            {
                if (File.Exists(currentDirectory + names[i]))
                {
                    images.Add(names[i], new Uri(currentDirectory + names[i]));
                }
                else
                {
                    if (failOnUnloadable)
                    {
                        throw new IOException("File does not exists : " + names[i]);
                    }
                    else
                    {
                        images.Add(names[i], new Uri(currentDirectory + defaultImage));
                    }
                }
            }

        }
    }
}
