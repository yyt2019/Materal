﻿using Materal.WebSocket.CommandHandlers;
using Materal.WebSocket.Commands.Model;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using DotNetty.Buffers;
using DotNetty.Transport.Channels;

namespace Materal.WebSocket.Commands
{
    public class CommandBusImpl : ICommandBus
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ICommandHandlerHelper _handlerHelper;
        public CommandBusImpl(IServiceProvider serviceProvider, ICommandHandlerHelper handlerHelper)
        {
            _serviceProvider = serviceProvider;
            _handlerHelper = handlerHelper;
        }
        public void Send(IChannelHandlerContext ctx, IByteBufferHolder frame, ICommand command)
        {
            GetHandler(command.HandlerName).Excute(ctx, frame, command);
        }
        public async Task SendAsync(IChannelHandlerContext ctx, IByteBufferHolder frame, ICommand command)
        {
            await GetHandler(command.HandlerName).ExcuteAsync(ctx, frame, command);
        }
        /// <summary>
        /// 获得处理器
        /// </summary>
        /// <param name="handlerName">处理器名称</param>
        /// <returns>处理器对象</returns>
        public ICommandHandler GetHandler(string handlerName)
        {
            Type handlerType = _handlerHelper.GetHandlerType(handlerName);
            var handler = (ICommandHandler)ActivatorUtilities.CreateInstance(_serviceProvider, handlerType);
            if (handler == null) throw new CommandException("未找到对应处理器");
            return handler;
        }
    }
}
