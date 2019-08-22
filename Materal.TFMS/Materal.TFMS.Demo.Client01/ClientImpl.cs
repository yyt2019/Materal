﻿using Materal.TFMS.Demo.Client01.EventHandlers;
using Materal.TFMS.Demo.Core;
using Materal.TFMS.Demo.Events;
using Materal.TFMS.EventBus;

namespace Materal.TFMS.Demo.Client01
{
    public class ClientImpl : IClient
    {
        private readonly IEventBus _eventBus;

        public ClientImpl(IEventBus eventBus)
        {
            _eventBus = eventBus;
            eventBus.Subscribe<Event02, Client01Event02Handler>();
            eventBus.Subscribe<Event03, Client01Event03Handler>();
        }

        public void SendEvent()
        {
            var @event = new Event01
            {
                Message = "这是来自Client01的事件"
            };
            _eventBus.Publish(@event);
        }
    }
}