///*************************************************************************/
///*
///* 文件名    ：ZipTools.cs                             
///* 程序说明  : 压缩/解压工具
///* 原创作者  ：来自网络 
///* 
///* Copyright  : 未知
///**************************************************************************/


using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using Ionic.Zip;
using UpdateSystem.Model.Util;

namespace Common
{
    public class ZipTools
    {
        #region 压缩解压自符串

        public static string ZipString(string unCompressedString)
        {

            byte[] bytData = System.Text.Encoding.UTF8.GetBytes(unCompressedString);
            MemoryStream ms = new MemoryStream();
            Stream s = new GZipStream(ms, CompressionMode.Compress);
            s.Write(bytData, 0, bytData.Length);
            s.Close();
            byte[] compressedData = (byte[])ms.ToArray();
            return System.Convert.ToBase64String(compressedData, 0, compressedData.Length);
        }

        public static string UnzipString(string unCompressedString)
        {
            System.Text.StringBuilder uncompressedString = new System.Text.StringBuilder();
            byte[] writeData = new byte[4096];

            byte[] bytData = System.Convert.FromBase64String(unCompressedString);
            int totalLength = 0;
            int size = 0;

            Stream s = new GZipStream(new MemoryStream(bytData), CompressionMode.Decompress);
            while (true)
            {
                size = s.Read(writeData, 0, writeData.Length);
                if (size > 0)
                {
                    totalLength += size;
                    uncompressedString.Append(System.Text.Encoding.UTF8.GetString(writeData, 0, size));
                }
                else
                {
                    break;
                }
            }
            s.Close();
            return uncompressedString.ToString();
        }

        //Demo
        //string abc = ZipString(txtCompressString.Text.Trim());
        //string Result = UnzipString(abc);

        #endregion

        #region 压缩解压数据集

        public static byte[] CompressionDataSet(DataSet dsOriginal)
        {
            if (dsOriginal == null) return null;
            dsOriginal.RemotingFormat = SerializationFormat.Binary;
            BinaryFormatter bFormatter = new BinaryFormatter();
            MemoryStream mStream = new MemoryStream();
            bFormatter.Serialize(mStream, dsOriginal);
            byte[] bytes = mStream.ToArray();
            MemoryStream oStream = new MemoryStream();
            DeflateStream zipStream = new DeflateStream(oStream, CompressionMode.Compress);
            zipStream.Write(bytes, 0, bytes.Length);
            zipStream.Flush();
            zipStream.Close();
            return oStream.ToArray();
        }

        public static DataSet DecompressionDataSet(byte[] bytes)
        {
            if (bytes == null) return null;
            MemoryStream mStream = new MemoryStream(bytes);
            mStream.Seek(0, SeekOrigin.Begin);
            DeflateStream unZipStream = new DeflateStream(mStream, CompressionMode.Decompress, true);
            DataSet dsResult = new DataSet();
            dsResult.RemotingFormat = SerializationFormat.Binary;
            BinaryFormatter bFormatter = new BinaryFormatter();
            dsResult = (DataSet)bFormatter.Deserialize(unZipStream);
            return dsResult;
        }

        #endregion

        #region 压缩解压文件

        /// <summary>
        /// 压缩文件
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <param name="destinationFile"></param>
        public static void CompressFile(string sourceFile, string destinationFile)
        {
            if (!File.Exists(sourceFile)) throw new FileNotFoundException();
            FileStream sourceStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read, FileShare.Read);
            byte[] buffer = new byte[sourceStream.Length];
            int checkCounter = sourceStream.Read(buffer, 0, buffer.Length);
            if (checkCounter != buffer.Length) throw new ApplicationException();
            FileStream destinationStream = new FileStream(destinationFile, FileMode.OpenOrCreate, FileAccess.Write);
            using (GZipStream compressedStream = new GZipStream(destinationStream, CompressionMode.Compress, true))
            {
                compressedStream.Write(buffer, 0, buffer.Length);
            }
        }

        /// <summary>
        /// 解压文件
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <param name="destinationFile"></param>
        public static void DecompressFile(string sourceFile, string destinationFile)
        {
            if (!File.Exists(sourceFile)) throw new FileNotFoundException();
            FileStream sourceStream = new FileStream(sourceFile, FileMode.Open);

            byte[] quartetBuffer = new byte[4];
            int position = (int)sourceStream.Length - 4;
            sourceStream.Position = position;
            sourceStream.Read(quartetBuffer, 0, 4);
            sourceStream.Position = 0;
            int checkLength = BitConverter.ToInt32(quartetBuffer, 0);
            byte[] buffer = new byte[checkLength + 100];
            GZipStream decompressedStream = new GZipStream(sourceStream, CompressionMode.Decompress, true);
            int total = 0;
            for (int offset = 0; ;)
            {
                int bytesRead = decompressedStream.Read(buffer, offset, 100);
                if (bytesRead == 0) break;
                offset += bytesRead;
                total += bytesRead;
            }
            FileStream destinationStream = new FileStream(destinationFile, FileMode.Create);
            destinationStream.Write(buffer, 0, total);
        }

        //DEMO
        //private void btnCommpress_Click(object sender, EventArgs e)
        //{
        //    string sourceFile = Application.StartupPath + @"\MTLOperatelog.txt";
        //    string destinationFile = Application.StartupPath + @"\abc.rar";
        //    CompressFile(sourceFile, destinationFile);
        //}

        //private void btnDecompressFile_Click(object sender, EventArgs e)
        //{
        //    string sourceFile = Application.StartupPath + @"\abc.rar";
        //    string destinationFile = Application.StartupPath + @"\abc.txt";
        //    DecompressFile(sourceFile, destinationFile);
        //}


        #endregion

        #region 压缩解压Ilist

        public static byte[] CompressionArrayList(IList DataOriginal)
        {
            if (DataOriginal == null) return null;
            BinaryFormatter bFormatter = new BinaryFormatter();
            MemoryStream mStream = new MemoryStream();
            bFormatter.Serialize(mStream, DataOriginal);
            byte[] bytes = mStream.ToArray();
            MemoryStream oStream = new MemoryStream();
            DeflateStream zipStream = new DeflateStream(oStream, CompressionMode.Compress);
            zipStream.Write(bytes, 0, bytes.Length);
            zipStream.Flush();
            zipStream.Close();
            //
            return oStream.ToArray();
        }

        public static IList DecompressionArrayList(byte[] bytes)
        {
            if (bytes == null) return null;
            MemoryStream mStream = new MemoryStream(bytes);
            mStream.Seek(0, SeekOrigin.Begin);
            DeflateStream unZipStream = new DeflateStream(mStream, CompressionMode.Decompress, true);
            IList dsResult = null;
            BinaryFormatter bFormatter = new BinaryFormatter();
            dsResult = (IList)bFormatter.Deserialize(unZipStream);
            return dsResult;
        }
        #endregion

        #region 压缩解压object

        public static byte[] CompressionObject(object DataOriginal)
        {
            if (DataOriginal == null) return null;
            BinaryFormatter bFormatter = new BinaryFormatter();
            MemoryStream mStream = new MemoryStream();
            bFormatter.Serialize(mStream, DataOriginal);
            byte[] bytes = mStream.ToArray();
            MemoryStream oStream = new MemoryStream();
            DeflateStream zipStream = new DeflateStream(oStream, CompressionMode.Compress);
            zipStream.Write(bytes, 0, bytes.Length);
            zipStream.Flush();
            zipStream.Close();
            return oStream.ToArray();
        }

        public static object DecompressionObject(byte[] bytes)
        {
            if (bytes == null) return null;
            MemoryStream mStream = new MemoryStream(bytes);
            mStream.Seek(0, SeekOrigin.Begin);
            DeflateStream unZipStream = new DeflateStream(mStream, CompressionMode.Decompress, true);
            object dsResult = null;
            BinaryFormatter bFormatter = new BinaryFormatter();
            dsResult = (object)bFormatter.Deserialize(unZipStream);
            return dsResult;
        }
        #endregion


        #region bool SaveFile(string filePath, byte[] bytes) 文件保存，  
        /// <summary>  
        ///  文件保存，特别是有些文件放到数据库，可以直接从数据取二进制，然后保存到指定文件夹  
        /// </summary>  
        /// <param name="filePath">保存文件地址</param>  
        /// <param name="bytes">文件二进制</param>  
        /// <returns></returns>  
        public static bool SaveFile(string filePath, byte[] bytes)
        {
            bool result = true;
            try
            {
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    fileStream.Write(bytes, 0, bytes.Length);
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
        #endregion

        #region 判断文件夹是否存在  
        /// <summary>  
        /// 判断文件夹是否存在  
        /// </summary>  
        /// <param name="path">文件夹地址</param>  
        /// <returns></returns>  
        public static bool DirectoryExist(string path)
        {
            if (!string.IsNullOrEmpty(path) && Directory.Exists(path))
            {
                return true;
            }
            return false;
        }
        #endregion

        #region 创建文件夹  
        /// <summary>  
        /// 创建文件夹  
        /// </summary>  
        /// <param name="path">文件地址</param>  
        /// <returns></returns>  
        public static bool DirectoryAdd(string path)
        {
            if (!string.IsNullOrEmpty(path) && !Directory.Exists(path))
            {
                Directory.CreateDirectory(path); //新建文件夹    
                return true;
            }
            return false;
        }
        #endregion

        #region 获取压缩后的文件路径  
        /// <summary>  
        /// 获取压缩后的文件路径  
        /// </summary>  
        /// <param name="dirPath">压缩的文件路径</param>  
        /// <param name="filesPath">多个文件路径</param>  
        /// <returns></returns>  
        public static void GetCompressPath(string zipPath, List<string> filesPath, string directoryPathInArchive)
        {
            string filemem = "";
            try
            {
                using (ZipFile zip = new ZipFile(System.Text.Encoding.Default)) //System.Text.Encoding.Default设置中文附件名称乱码，不设置会出现乱码  
                {
                    int total = filesPath.Count;
                    int index = 0;
                    foreach (var file in filesPath)
                    {
                        filemem = file;
                        index++;
                        string tmpDir = Path.GetDirectoryName(file);
                        string actualDir = tmpDir.Replace(directoryPathInArchive, "");
                        zip.AddFile(file, actualDir);//第二个参数指的是该文件对应的相对目录
                        //第二个参数为空，说明压缩的文件不会存在多层文件夹。比如C:\test\a\b\c.doc 压缩后解压文件会出现c.doc  
                        //如果改成zip.AddFile(file);则会出现多层文件夹压缩，比如C:\test\a\b\c.doc 压缩后解压文件会出现test\a\b\c.doc  
                        double actualVal = index / total * 100;
                    }
                    //保存的完整路径，例如：E:\升级包\20170710105223.zip
                    zip.Save(zipPath);
                }
            }
            catch (Exception ex)
            {
                LogHelper.ErrorLog("当前重复的文件：" + filemem, ex);
            }
        }
        #endregion
    }
}
