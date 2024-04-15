//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

using System.Collections.Generic;

namespace FileDb.App.Services.SizeOfFiles
{
    internal class Folder : IFileSystemComponent
    {
        private readonly List<IFileSystemComponent> components = new List<IFileSystemComponent> ();

        public string Name { get; }

        public Folder(string name)
        {
            this.Name = name;
        }

        public long Size
        {
            get
            {
                long totalSize = 0;
                foreach (IFileSystemComponent component in components)
                {
                    totalSize += component.Size;
                }

                return totalSize;
            }
        }

        public void Add(IFileSystemComponent component)
        {
            components.Add(component);
        }

        public void Remove(IFileSystemComponent component)
        {
            components.Remove(component);
        }

        public void PrintFileInfo()
        {
            foreach (IFileSystemComponent component in components)
            {
                component.PrintFileInfo();
            }
        }
    }
}