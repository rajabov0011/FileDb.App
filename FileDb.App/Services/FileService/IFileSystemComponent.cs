//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

namespace FileDb.App.Services.FileService
{
    internal interface IFileSystemComponent
    {
        string Name { get; }
        long getSize();
        void PrintFileInfo();
    }
}