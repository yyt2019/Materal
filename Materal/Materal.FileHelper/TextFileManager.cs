﻿using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Materal.FileHelper
{
    public class TextFileManager
    {
        /// <summary>
        /// 写入文本
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static async Task WriteTextAsync(string fileName, string text)
        {
            using (var streamWriter = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                await streamWriter.WriteLineAsync(text);
                await streamWriter.FlushAsync();
            }
        }
        /// <summary>
        /// 写入文本
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static void WriteText(string fileName, string text)
        {
            using (var streamWriter = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                streamWriter.WriteLine(text);
                streamWriter.Flush();
            }
        }
        /// <summary>
        /// 追加文本
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static async Task AppendTextAsync(string fileName, string text)
        {
            using (var streamWriter = new StreamWriter(fileName, true, Encoding.UTF8))
            {
                await streamWriter.WriteLineAsync(text);
                await streamWriter.FlushAsync();
            }
        }
        /// <summary>
        /// 追加文本
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static void AppendText(string fileName, string text)
        {
            using (var streamWriter = new StreamWriter(fileName, true, Encoding.UTF8))
            {
                streamWriter.WriteLine(text);
                streamWriter.Flush();
            }
        }
        /// <summary>
        /// 写入文本
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static async Task WriteTextAsync(string fileName, string text, Encoding encoding)
        {
            using (var streamWriter = new StreamWriter(fileName, false, encoding))
            {
                await streamWriter.WriteLineAsync(text);
                await streamWriter.FlushAsync();
            }
        }
        /// <summary>
        /// 写入文本
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static void WriteText(string fileName, string text, Encoding encoding)
        {
            using (var streamWriter = new StreamWriter(fileName, false, encoding))
            {
                streamWriter.WriteLine(text);
                streamWriter.Flush();
            }
        }
        /// <summary>
        /// 追加文本
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static async Task AppendTextAsync(string fileName, string text, Encoding encoding)
        {
            using (var streamWriter = new StreamWriter(fileName, true, encoding))
            {
                await streamWriter.WriteLineAsync(text);
                await streamWriter.FlushAsync();
            }
        }
        /// <summary>
        /// 追加文本
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static void AppendText(string fileName, string text, Encoding encoding)
        {
            using (var streamWriter = new StreamWriter(fileName, true, encoding))
            {
                streamWriter.WriteLine(text);
                streamWriter.Flush();
            }
        }
    }
}
