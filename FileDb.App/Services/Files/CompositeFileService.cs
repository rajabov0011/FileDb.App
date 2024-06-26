﻿//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

using System.Collections.Generic;

namespace FileDb.App.Services.Files
{
    internal class CompositeFileService : IFileSystemComponent
    {
        private readonly List<IFileSystemComponent> components = new List<IFileSystemComponent> ();

        public string Name { get; }

        public CompositeFileService(string name)
        {
            this.Name = name;
        }

        public void Add(IFileSystemComponent component) =>
            components.Add(component);

        public void PrintFileInfo()
        {
            foreach (IFileSystemComponent component in components)
            {
                component.PrintFileInfo();
            }
        }

        public long getSize()
        {
            long totalSize = 0;
            foreach (IFileSystemComponent component in components)
            {
                totalSize += component.getSize();
            }

            return totalSize;
        }
    }
}