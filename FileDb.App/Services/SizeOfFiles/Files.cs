//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

using System;

namespace FileDb.App.Services.SizeOfFiles
{
    internal class Files : IFileSystemComponent
    {
        public string Name { get; set; }
        public long Size { get; set; }
        
        public Files(string name, long size) 
        {
            this.Name = name;
            this.Size = size;
        }

        public void PrintFileInfo()
        {
            Console.WriteLine($"File:  {this.Name} -> Size:  {this.Size} bytes");
        }
    }
}