
using System.IO;
using System.IO.Compression;


namespace lab11
{
    internal class Zipper
    {
        public void ZipFolder(string folderPath)
        {
            foreach (var file in Directory.GetFiles(folderPath)) { 
                FileStream fileStream = File.Open(file, FileMode.Open, FileAccess.Read);
                FileStream compressedFileStream = File.Create(file+".gz");

                GZipStream zipper = new GZipStream(compressedFileStream, CompressionMode.Compress);
                fileStream.CopyTo(zipper);

                zipper.Close();
                fileStream.Close();
                compressedFileStream.Close();
            }
        }

        public void UnzipFolder(string folderPath)
        {            
            foreach (var file in Directory.GetFiles(folderPath))         
            {
                FileInfo fileInfo = new FileInfo(file);
                if (fileInfo.Extension.Equals(".gz"))
                {
                    FileStream compressedFileStream = File.Open(file, FileMode.Open);
                    string decompressedPath = Directory.GetParent(file)+"\\"+Path.GetFileNameWithoutExtension(file);
                    FileStream decompressedFileStream = File.Create(decompressedPath);

                    GZipStream zipper = new GZipStream(compressedFileStream, CompressionMode.Decompress);
                    zipper.CopyTo(decompressedFileStream);

                    compressedFileStream.Close();
                    decompressedFileStream.Close();
                }
            }
        }
    }
}
