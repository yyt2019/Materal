﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace Materal.WindowsHelper
{
    public class RegistryHelper
    {
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool AnyAll(string name)
        {
            var registryKeys = new List<RegistryKey>
            {
                Registry.ClassesRoot,
                Registry.LocalMachine,
                Registry.CurrentUser,
                Registry.Users,
                Registry.CurrentConfig
            };
            foreach (RegistryKey registryKey in registryKeys)
            {
                RegistryKey temp = registryKey.OpenSubKey(name);
                if (temp != null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
