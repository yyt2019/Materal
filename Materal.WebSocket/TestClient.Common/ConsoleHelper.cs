﻿using System;

namespace TestClient.Common
{
    public class ConsoleHelper
    {
        /// <summary>
        /// 控制台输出
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="message">消息</param>
        /// <param name="subTitle">副标题</param>
        /// <param name="consoleColor">颜色</param>
        public static void WriteLine(string title, string message, string subTitle, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            string dateNow = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            Console.WriteLine(string.IsNullOrEmpty(subTitle) ? $"[{dateNow}]{title}：{message}" : $"[{dateNow}]{title}[{subTitle}]：{message}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// 控制台输出
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="subTitle">副标题</param>
        /// <param name="consoleColor">颜色</param>
        public static void TestClientWriteLine(string message, string subTitle = null, ConsoleColor consoleColor = ConsoleColor.White)
        {
            WriteLine("TestClient", message, subTitle, consoleColor);
        }
    }
}
