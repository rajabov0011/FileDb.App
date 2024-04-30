//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

namespace FileDb.App.Services.Files
{
    internal interface IFileSystemComponent
    {
        string Name { get; }
        long getSize();
        void PrintFileInfo();
    }
}