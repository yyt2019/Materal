﻿using Materal.ConDep.Manager.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Materal.ConDep.Manager
{
    /// <summary>
    /// 应用程序管理器
    /// </summary>
    public interface IAppManager
    {
        /// <summary>
        /// 启动所有应用
        /// </summary>
        /// <returns></returns>
        void StartAllApp();
        /// <summary>
        /// 重启所有应用
        /// </summary>
        /// <returns></returns>
        void RestartAllApp();
        /// <summary>
        /// 停止所有应用
        /// </summary>
        /// <returns></returns>
        void StopAllApp();
        /// <summary>
        /// 根据路径停止
        /// </summary>
        /// <param name="paths"></param>
        void StopAppByPaths(params string[] paths);
        /// <summary>
        /// 添加一个应用
        /// </summary>
        /// <param name="appModel"></param>
        Task AddAppAsync(AppModel appModel);
        /// <summary>
        /// 修改一个应用
        /// </summary>
        /// <param name="appModel"></param>
        /// <returns></returns>
        Task EditAppAsync(AppModel appModel);
        /// <summary>
        /// 删除一个应用
        /// </summary>
        /// <param name="id"></param>
        Task DeleteAppAsync(Guid id);
        /// <summary>
        /// 获得应用信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        AppModel GetAppInfo(Guid id);
        /// <summary>
        /// 启动应用
        /// </summary>
        /// <returns></returns>
        void StartApp(Guid id);
        /// <summary>
        /// 重启应用
        /// </summary>
        /// <returns></returns>
        void RestartApp(Guid id);
        /// <summary>
        /// 停止应用
        /// </summary>
        /// <returns></returns>
        void StopApp(Guid id);
        /// <summary>
        /// 获取应用列表
        /// </summary>
        /// <returns></returns>
        List<AppListModel> GetAppList();
        /// <summary>
        /// 获得控制台列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<string> GetConsoleList(Guid id);
    }
}
