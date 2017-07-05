using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace gLog_FrontEnd.Common
{
    public class File_IO
    {
        /// <summary>
        /// 写文件操作
        /// </summary>
        /// <param name="FilePath">文件路径</param>
        /// <param name="Data">数据</param>
        /// <returns>是否成功</returns>
        public static bool File_Write(string FilePath, string Data)
        {
            try
            {
                if (System.IO.File.Exists(FilePath))
                {
                    System.IO.File.Delete(FilePath);
                }
                using (FileStream fileStream = System.IO.File.Create(FilePath))
                {
                    byte[] bytes = new UTF8Encoding(true).GetBytes(Data);
                    fileStream.Write(bytes, 0, bytes.Length);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 读文件
        /// </summary>
        /// <param name="FilePath">文件路径</param>
        /// <returns>文件数据</returns>
        public static string File_Read(string FilePath)
        {
            string context = string.Empty;
            try
            {
                if (System.IO.File.Exists(FilePath))
                {
                    context = System.IO.File.ReadAllText(FilePath);
                }
                return context;
            }
            catch
            {
                return context;
            }
        }
    }
}