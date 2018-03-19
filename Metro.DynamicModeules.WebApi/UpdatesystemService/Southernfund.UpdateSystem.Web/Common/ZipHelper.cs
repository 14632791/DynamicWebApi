using System;
using System.IO;

using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.GZip;

namespace Common
{
    public class ZipHelper
    {
        /// <summary>
        /// 解压文件
        /// </summary>
        /// <param name="ZipPath">被解压的文件路径</param>
        /// <param name="Path">解压后文件的路径</param>
        public static void UnZip(string ZipPath, string strPath)
        {
            ZipInputStream s = new ZipInputStream(File.OpenRead(ZipPath));

            ZipEntry theEntry;
            try
            {
                while ((theEntry = s.GetNextEntry()) != null)
                {
                    if (theEntry.IsDirectory)
                    {
                        continue;
                    }
                    string fileName = Path.GetFileName(theEntry.Name);
                    string strDir = Path.GetDirectoryName(theEntry.Name);
                    string strFullDir = Path.Combine(strPath, strDir);
                    //生成解压目录
                    Directory.CreateDirectory(strFullDir);
                    string strFullFileName = Path.Combine(strFullDir, fileName);
                    if (fileName != String.Empty)
                    {
                        //解压文件
                        FileStream streamWriter = File.Create(strFullFileName);
                        int size = 2048;
                        byte[] data = new byte[2048];
                        while (true)
                        {
                            size = s.Read(data, 0, data.Length);
                            if (size > 0)
                            {
                                streamWriter.Write(data, 0, size);
                            }
                            else
                            {
                                streamWriter.Close();
                                streamWriter.Dispose();
                                break;
                            }
                        }
                        streamWriter.Close();
                        streamWriter.Dispose();
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                s.Close();
                s.Dispose();
            }
        }
        public void ZipFile(string FileToZip, string ZipedFile, int CompressionLevel, int BlockSize)
        {
            //如果文件没有找到，则报错
            if (!System.IO.File.Exists(FileToZip))
            {
                throw new System.IO.FileNotFoundException("The specified file " + FileToZip + " could not be found. Zipping aborderd");
            }

            System.IO.FileStream StreamToZip = new System.IO.FileStream(FileToZip, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            System.IO.FileStream ZipFile = System.IO.File.Create(ZipedFile);
            ZipOutputStream ZipStream = new ZipOutputStream(ZipFile);
            ZipEntry ZipEntry = new ZipEntry("ZippedFile");
            ZipStream.PutNextEntry(ZipEntry);
            ZipStream.SetLevel(CompressionLevel);
            byte[] buffer = new byte[BlockSize];
            System.Int32 size = StreamToZip.Read(buffer, 0, buffer.Length);
            ZipStream.Write(buffer, 0, size);
            try
            {
                while (size < StreamToZip.Length)
                {
                    int sizeRead = StreamToZip.Read(buffer, 0, buffer.Length);
                    ZipStream.Write(buffer, 0, sizeRead);
                    size += sizeRead;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            ZipStream.Finish();
            ZipStream.Close();
            StreamToZip.Close();
        }

        public void ZipFileMain(string[] args)
        {
            ZipOutputStream s = new ZipOutputStream(File.Create(args[1]));
            try
            {
                //找到该目录下的所有文件
                string[] filenames = Directory.GetFiles(args[0]);

                Crc32 crc = new Crc32();

                s.SetLevel(6); // 0 - store only to 9 - means best compression

                foreach (string file in filenames)
                {
                    //打开压缩文件
                    FileStream fs = File.OpenRead(file);

                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    ZipEntry entry = new ZipEntry(file);

                    entry.DateTime = DateTime.Now;

                    // set Size and the crc, because the information
                    // about the size and crc should be stored in the header
                    // if it is not set it is automatically written in the footer.
                    // (in this case size == crc == -1 in the header)
                    // Some ZIP programs have problems with zip files that don't store
                    // the size and crc in the header.
                    entry.Size = fs.Length;
                    fs.Close();

                    crc.Reset();
                    crc.Update(buffer);

                    entry.Crc = crc.Value;

                    s.PutNextEntry(entry);

                    s.Write(buffer, 0, buffer.Length);

                }
            }
            catch
            {

            }
            finally
            {
                s.Finish();
                s.Close();
            }
        }

        /// <summary>
        /// 压缩文件
        /// </summary>
        /// <param name="fileName">要压缩的所有文件（完全路径)</param>
        /// <param name="name">压缩后文件路径</param>
        /// <param name="Level">压缩级别</param>
        public void ZipFileMain(string[] filenames, string name, int Level)
        {
            ZipOutputStream s = new ZipOutputStream(File.Create(name));
            Crc32 crc = new Crc32();
            //压缩级别
            s.SetLevel(Level); // 0 - store only to 9 - means best compression
            try
            {
                foreach (string file in filenames)
                {
                    //打开压缩文件
                    FileStream fs = File.OpenRead(file);

                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    
                    //建立压缩实体
                    ZipEntry entry = new ZipEntry(System.IO.Path.GetFileName(file));

                    //时间
                    entry.DateTime = DateTime.Now;

                    // set Size and the crc, because the information
                    // about the size and crc should be stored in the header
                    // if it is not set it is automatically written in the footer.
                    // (in this case size == crc == -1 in the header)
                    // Some ZIP programs have problems with zip files that don't store
                    // the size and crc in the header.
                    //空间大小
                    entry.Size = fs.Length;
                    fs.Close();
                    crc.Reset();
                    crc.Update(buffer);
                    entry.Crc = crc.Value;
                    s.PutNextEntry(entry);
                    s.Write(buffer, 0, buffer.Length);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                s.Finish();
                s.Close();
            }

        }

       
    }
}
