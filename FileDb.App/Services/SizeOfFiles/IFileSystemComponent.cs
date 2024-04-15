//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

namespace FileDb.App.Services.SizeOfFiles
{
    internal interface IFileSystemComponent
    {
        string Name { get; }
        long Size { get; }
        void PrintFileInfo();
    }
}
